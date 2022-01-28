using System.Windows;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wreath.Model;
using Wreath.Controls.Tables;
using System.Windows.Controls;

namespace Wreath.ViewModel
{
    public class GlobalViewModel : INotifyPropertyChanged
    {
        public GlobalViewModel()
        {
            CurrentState = _defaultState;
            Transitions = new Stack();
            SelectedRowIndexes = new Dictionary<int, ulong>();
            TableView = new LayoutMaster(this);
            FastActions = new Pair<FastAction, FastAction>();
        }

        private static readonly TransitionBase _defaultState = new TransitionBase(null, "Пополнений стека:", 0);

        private TransitionBase _currentState;
        public TransitionBase CurrentState
        {
            get => _currentState;
            set
            {
                _currentState = value;
                OnPropertyChanged();
            }
        }

        public bool IsTopTransition => IsTop(Transitions.Count, 1);
        public static bool IsTop(int original, int toCompare) => original <= toCompare;
        public Visibility BackOperations => IsTopTransition ? Visibility.Hidden : Visibility.Visible;

        private Stack _transitions;
        public Stack Transitions
        {
            get => _transitions;
            set
            {
                _transitions = value;
                OnPropertyChanged();
            }
        }

        public int SelectedRows => SelectedRowIndexes.Count;

        private Dictionary<int, ulong> _selectedRowIndexes;
        public Dictionary<int, ulong> SelectedRowIndexes
        {
            get => _selectedRowIndexes;
            set
            {
                _selectedRowIndexes = value;
                OnPropertyChanged();
            }
        }

        public bool CanBeAffected => SelectedRows > 0;

        public void SelectRow(int key, ulong id)
        {
            SelectedRowIndexes.Add(key, id);
            SelectionChanged();
        }

        public void DeSelectRow(int key)
        {
            _ = SelectedRowIndexes.Remove(key);
            SelectionChanged();
        }

        public void NullifySelection()
        {
            SelectedRowIndexes.Clear();
            SelectionChanged();
        }

        private void SelectionChanged()
        {
            OnPropertyChanged(nameof(SelectedRowIndexes));
            OnPropertyChanged(nameof(SelectedRows));
            OnPropertyChanged(nameof(CanBeAffected));
        }

        public void CleanBuffer()
        {
            Transitions.Clear();
            TransitionStateChanged();
        }

        public void AddTransition(TransitionBase.Transition way, string name, uint id)
        {
            TransitionBase transition = new TransitionBase(way, name, id);
            Transitions.Push(transition);
            TransitionStateChanged();
            NullifySelection();
        }

        public void RefreshTransition()
        {
            TransitionBase transition = PopTransition();
            transition.MakeTransition();
            NullifySelection();
        }

        public TransitionBase GetTransition()
        {
            TransitionBase transition = Transitions.Peek() as TransitionBase;
            return transition;
        }

        public TransitionBase PopTransition()
        {
            TransitionBase transition = Transitions.Pop() as TransitionBase;
            TransitionStateChanged();
            return transition;
        }

        public void BackTransition()
        {
            _ = PopTransition();
            GetTransition().MakeTransition();
            if (!IsTopTransition)
                _ = PopTransition();
        }

        public void TransitionStateChanged()
        {
            if (!IsTop(Transitions.Count, 0))
                CurrentState = GetTransition();
            OnPropertyChanged(nameof(BackOperations));
        }

        public delegate void FastAction();
        public Pair<FastAction, FastAction> FastActions { get; }

        public void UnMarkAll()
        {
            FastActions.Name();
        }

        public void DropAll()
        {
            FastActions.Value();
        }

        private void ConfirmUnMarking(StackPanel view)
        {
            foreach (KeyValuePair<int, ulong> pair in SelectedRowIndexes)
            {
                int index = pair.Key;
                if (view.Children[index] is IMarkable row && row.IsMarked)
                    row.UnMarkConfirm();
            }
            RefreshTransition();
        }

        internal void UnMarkRows(StackPanel view)
        {
            if (RowsAffectedDialog("снято пометок с"))
                ConfirmUnMarking(view);
        }

        private void ConfirmDrop(StackPanel view)
        {
            foreach (KeyValuePair<int, ulong> pair in SelectedRowIndexes)
            {
                int index = pair.Key;
                if (view.Children[index] is IMarkable row && row.IsMarked)
                    row.DropConfirm();
            }
            RefreshTransition();
        }

        internal void DropRows(StackPanel view)
        {
            if (RowsAffectedDialog("безвозвратно удалено"))
                ConfirmDrop(view);
        }

        internal bool RowsAffectedDialog(string operation)
        {
            string message = $"Будет {operation} записей: {SelectedRows}\nПродолжить?";
            MessageBoxResult result = MessageBox.Show(message, "Подтверждение операции",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            return result == MessageBoxResult.Yes;
        }

        private LayoutMaster _tableView;
        public LayoutMaster TableView
        {
            get => _tableView;
            set
            {
                _tableView = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
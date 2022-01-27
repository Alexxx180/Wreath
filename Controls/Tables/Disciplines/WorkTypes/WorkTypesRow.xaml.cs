using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Convert;
using static Wreath.Controls.Tables.EditHelper;

namespace Wreath.Controls.Tables.Disciplines.WorkTypes
{
    /// <summary>
    /// Work types table row component
    /// </summary>
    public partial class WorkTypesRow : UserControl, INotifyPropertyChanged, IMarkable
    {
        private int _no = 1;
        public int No
        {
            get => _no;
            set
            {
                _no = value;
                OnPropertyChanged();
            }
        }

        private int _rowKey;
        public int RowKey
        {
            get => _rowKey;
            set
            {
                _rowKey = value;
                OnPropertyChanged();
            }
        }

        private uint _id = 1;
        public uint Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _workType;
        public string WorkType
        {
            get => _workType;
            set
            {
                _workType = value;
                OnPropertyChanged();
            }
        }

        private bool _isMarked;
        public bool IsMarked
        {
            get => _isMarked;
            set
            {
                _isMarked = value;
                OnPropertyChanged();
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        private Style _selection;
        public Style Selection
        {
            get => _selection;
            set
            {
                _selection = value;
                OnPropertyChanged();
            }
        }

        private Style _unselected;
        private Style _selected;
        private Style _marked;

        private void SetStyles()
        {
            _unselected = TryFindResource("UnSelected") as Style;
            _selected = TryFindResource("Selected") as Style;
            _marked = TryFindResource("Marked") as Style;
            Selection = _unselected;
        }

        private void SetDefaults()
        {
            WorkType = null;
            IsMarked = false;
            IsSelected = false;
            SetStyles();
        }

        public WorkTypesRow()
        {
            InitializeComponent();
            SetDefaults();
        }

        public void SetElement(string[] row)
        {
            Id = ToUInt32(row[0]);
            WorkType = row[1];
        }

        public void Select()
        {
            IsSelected = !IsSelected;
            if (IsSelected)
            {
                _tables.ViewModel.SelectRow(RowKey, Id);
                Selection = _selected;
            }
            else
            {
                _tables.ViewModel.DeSelectRow(RowKey);
                Selection = _marked;
            }
        }

        private void Select(object sender, RoutedEventArgs e)
        {
            Select();
        }

        public void Index(int no)
        {
            No = no;
        }

        private LayoutMaster _tables;
        public void SetTools(StackPanel table)
        {
            _tables = GetLayout(table);
        }

        public void Mark()
        {
            IsMarked = true;
            Selection = _marked;
        }

        public void UnMarkConfirm()
        {
            _tables.Tools.UnMarkRow.WorkType(Id);
        }

        public void DropConfirm()
        {
            _tables.Tools.DropRow.WorkType(Id);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
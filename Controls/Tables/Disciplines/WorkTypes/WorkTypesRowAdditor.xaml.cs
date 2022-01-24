using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static Wreath.Controls.Tables.EditHelper;

namespace Wreath.Controls.Tables.Disciplines.WorkTypes
{
    /// <summary>
    /// Work types table special row to add new rows
    /// </summary>
    public partial class WorkTypesRowAdditor : UserControl, INotifyPropertyChanged, IAutoIndexing
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

        private string _workType = "";
        public string WorkType
        {
            get => _workType;
            set
            {
                _workType = value;
                OnPropertyChanged();
            }
        }

        public bool CanBeEdited => HaveSpace();
        private StackPanel _table;

        private bool HaveSpace()
        {
            return (_table != null) && _table.Children.Count < ushort.MaxValue;
        }

        public WorkTypesRowAdditor()
        {
            InitializeComponent();
        }

        public void Index(int no)
        {
            No = no;
        }

        private LayoutMaster _tables;
        public void SetTools(StackPanel table)
        {
            _table = table;
            _tables = GetLayout(table);
            OnPropertyChanged(nameof(CanBeEdited));
        }

        private void AddNewRow(object sender, RoutedEventArgs e)
        {
            _tables.Tools.AddRow.WorkType(WorkType);
            _tables.ViewModel.RefreshTransition();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
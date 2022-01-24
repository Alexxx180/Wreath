using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static Wreath.Controls.Tables.EditHelper;

namespace Wreath.Controls.Tables.Disciplines.WorkTypes.Hours
{
    /// <summary>
    /// Hours table special row to add new rows
    /// </summary>
    public partial class HoursRowAdditor : UserControl, INotifyPropertyChanged, IAutoIndexing
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

        private uint? _hoursType = null;
        public uint? HoursType
        {
            get => _hoursType;
            set
            {
                _hoursType = value;
                OnPropertyChanged();
            }
        }

        private string _hoursCount = "";
        public string HoursCount
        {
            get => _hoursCount;
            set
            {
                _hoursCount = value;
                OnPropertyChanged();
            }
        }

        public ushort Hours => ParseHours(HoursCount);

        public bool CanBeEdited => HaveSpace();
        private StackPanel _table;

        private bool HaveSpace()
        {
            return (_table != null) && _table.Children.Count < ushort.MaxValue;
        }

        public HoursRowAdditor()
        {
            InitializeComponent();
        }

        private LayoutMaster _tables;
        public void SetTools(StackPanel table)
        {
            _table = table;
            _tables = GetLayout(table);
            OnPropertyChanged(nameof(CanBeEdited));
        }

        public void SetCode(uint id)
        {
            HoursType = id;
        }

        private void SelectCode(object sender, RoutedEventArgs e)
        {
            SelectionFields(0, _tables.Data.WorkTypes, "Тип работ:",
                "Общие часы", _tables.FillWorkTypes, SetCode);
            e.Handled = true;
        }

        private void AddNewRow(object sender, RoutedEventArgs e)
        {
            if (HoursType == null)
                return;
            uint disciplineId = _tables.ViewModel.CurrentState.Id;
            _tables.Tools.AddRow.TotalHour(disciplineId, HoursType.Value, Hours);
            _tables.ViewModel.RefreshTransition();
        }

        public void Index(int no)
        {
            No = no;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
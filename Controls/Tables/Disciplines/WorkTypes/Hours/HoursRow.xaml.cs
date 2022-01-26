using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Convert;
using static Wreath.Controls.Tables.EditHelper;

namespace Wreath.Controls.Tables.Disciplines.WorkTypes.Hours
{
    /// <summary>
    /// Hours table row component
    /// </summary>
    public partial class HoursRow : UserControl, INotifyPropertyChanged, IMarkable
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

        private uint? _hoursType;
        public uint? HoursType
        {
            get => _hoursType;
            set
            {
                _hoursType = value;
                OnPropertyChanged();
            }
        }

        private string _hoursCount;
        public string HoursCount
        {
            get => _hoursCount;
            set
            {
                _hoursCount = value;
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

        public ushort Hours => ToUInt16(HoursCount);

        private Style _unselected;
        private Style _selected;
        private Style _marked;

        private void SetStyles()
        {
            _unselected = TryFindResource("Impact1") as Style;
            _selected = TryFindResource("Impact2") as Style;
            _marked = TryFindResource("Impact2") as Style;
            Selection = _unselected;
        }

        private void SetDefaults()
        {
            HoursType = null;
            HoursCount = "";
            IsMarked = false;
            IsSelected = false;
            SetStyles();
        }

        public HoursRow()
        {
            InitializeComponent();
            SetDefaults();
        }

        public void SetElement(string[] row)
        {
            Id = ToUInt32(row[0]);
            HoursType = ToUInt32(row[1]);
            HoursCount = row[2];
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

        private LayoutMaster _tables;
        public void SetTools(StackPanel table)
        {
            _tables = GetLayout(table);
        }

        public void SetCode(uint id)
        {
            HoursType = id;
        }

        private void SelectCode(object sender, RoutedEventArgs e)
        {
            SelectionFields(Id, _tables.Data.WorkTypes, "Типы работ:",
                "Общие часы", _tables.FillWorkTypes, SetCode);
            e.Handled = true;
        }

        public void Index(int no)
        {
            No = no;
        }

        public void Mark()
        {
            IsMarked = true;
            Selection = _marked;
        }

        public void UnMarkConfirm()
        {
            _tables.Tools.UnMarkRow.TotalHour(Id);
        }

        public void DropConfirm()
        {
            _tables.Tools.DropRow.TotalHour(Id);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
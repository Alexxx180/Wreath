using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Convert;
using static Wreath.Controls.Tables.EditHelper;

namespace Wreath.Controls.Tables.Disciplines.WorkTypes.ThemePlan.Themes
{
    /// <summary>
    /// Themes table row component
    /// </summary>
    public partial class ThemeRow : UserControl, INotifyPropertyChanged, IMarkable
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

        private ushort? _themeLevel;
        public ushort? ThemeLevel
        {
            get => _themeLevel;
            set
            {
                _themeLevel = value;
                OnPropertyChanged();
            }
        }

        private string _themeNo;
        public string ThemeNo
        {
            get => _themeNo;
            set
            {
                _themeNo = value;
                OnPropertyChanged();
            }
        }


        private string _themeName;
        public string ThemeName
        {
            get => _themeName;
            set
            {
                _themeName = value;
                OnPropertyChanged();
            }
        }

        private string _hoursCount;
        public string ThemeHours
        {
            get => _hoursCount;
            set
            {
                _hoursCount = value;
                OnPropertyChanged();
            }
        }

        public ushort ThemeNumber => ToUInt16(ThemeNo);
        public ushort HoursCount => ToUInt16(ThemeHours);

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
            _unselected = TryFindResource("Impact1") as Style;
            _selected = TryFindResource("Impact2") as Style;
            _marked = TryFindResource("Impact2") as Style;
            Selection = _unselected;
        }

        private void SetDefaults()
        {
            ThemeNo = "";
            ThemeName = "";
            ThemeHours = "";
            ThemeLevel = null;
            IsMarked = false;
            IsSelected = false;
            SetStyles();
        }

        public ThemeRow()
        {
            InitializeComponent();
            SetDefaults();
        }

        public void SetElement(string[] row)
        {
            Id = ToUInt32(row[0]);
            ThemeNo = row[1];
            ThemeName = row[2];
            ThemeHours = row[3];
            ThemeLevel = ToUInt16(row[4]);
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

        private void CheckSelection(ComboBox selector)
        {
            switch (selector.SelectedIndex)
            {
                case 0:
                    _tables.FillWorks(Id);
                    break;
                case 1:
                    _tables.FillThemeGeneralCompetetions(Id);
                    break;
                case 2:
                    _tables.FillThemeProfessionalCompetetions(Id);
                    break;
                default:
                    break;
            }
        }

        private void SecondaryTables_Select(object sender, SelectionChangedEventArgs e)
        {
            ComboBox selector = sender as ComboBox;
            CheckSelection(selector);
            e.Handled = true;
        }

        public void Mark()
        {
            IsMarked = true;
            Selection = _marked;
        }

        public void UnMarkConfirm()
        {
            _tables.Tools.UnMarkRow.Theme(Id);
        }

        public void DropConfirm()
        {
            _tables.Tools.DropRow.Theme(Id);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
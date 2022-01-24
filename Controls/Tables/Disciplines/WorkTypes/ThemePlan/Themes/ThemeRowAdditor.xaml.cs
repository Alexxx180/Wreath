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
    public partial class ThemeRowAdditor : UserControl, INotifyPropertyChanged, IAutoIndexing
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

        private ushort? _themeLevel = null;
        public ushort? ThemeLevel
        {
            get => _themeLevel;
            set
            {
                _themeLevel = value;
                OnPropertyChanged();
            }
        }

        private string _themeNo = "1";
        public string ThemeNo
        {
            get => _themeNo;
            set
            {
                _themeNo = value;
                OnPropertyChanged();
            }
        }


        private string _themeName = "";
        public string ThemeName
        {
            get => _themeName;
            set
            {
                _themeName = value;
                OnPropertyChanged();
            }
        }

        private string _hoursCount = "";
        public string ThemeHours
        {
            get => _hoursCount;
            set
            {
                _hoursCount = value;
                OnPropertyChanged();
            }
        }

        public ushort ThemeNumber => ParseHours(ThemeNo);
        public ushort HoursCount => ParseHours(ThemeHours);

        public bool CanBeEdited => HaveSpace();
        private StackPanel _table;

        private bool HaveSpace()
        {
            return (_table != null) && _table.Children.Count < ushort.MaxValue;
        }

        public ThemeRowAdditor()
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
            ThemeLevel = ToUInt16(id);
        }

        private void SelectCode(object sender, RoutedEventArgs e)
        {
            SelectionFields(0, _tables.Data.Levels, "Уровни компетенций:",
                "Тема", _tables.FillCompetetionLevels, SetCode);
            e.Handled = true;
        }

        private void AddNewRow(object sender, RoutedEventArgs e)
        {
            if (ThemeLevel == null)
                return;
            uint topicId = _tables.ViewModel.CurrentState.Id;
            _tables.Tools.AddRow.Theme(topicId, ThemeLevel.Value, ThemeNumber, ThemeName, HoursCount);
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
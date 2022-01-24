using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static Wreath.Controls.Tables.EditHelper;

namespace Wreath.Controls.Tables.Disciplines.WorkTypes.ThemePlan.Themes.GeneralMastering
{
    /// <summary>
    /// General selection table special row to add new rows
    /// </summary>
    public partial class ThemeGeneralMasteringRowAdditor : UserControl, INotifyPropertyChanged, IAutoIndexing
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

        private uint? _code = null;
        public uint? Code
        {
            get => _code;
            set
            {
                _code = value;
                OnPropertyChanged();
            }
        }

        public bool CanBeEdited => HaveSpace();
        private StackPanel _table;

        private bool HaveSpace()
        {
            return (_table != null) && _table.Children.Count < ushort.MaxValue;
        }

        public ThemeGeneralMasteringRowAdditor()
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
            Code = id;
        }

        private void SelectCode(object sender, RoutedEventArgs e)
        {
            uint themeId = _tables.ViewModel.CurrentState.Id;
            List<string[]> rows = _tables.Data.DisciplineGeneralMasteringByTheme(themeId);
            if (rows.Count > 0)
                SelectionFields(themeId, rows, 
                    "Общие компетенции дисциплины:", "Освоение общей компетенции",
                    _tables.FillDisciplineGeneralFromMastering, SetCode);
            e.Handled = true;
        }

        private void AddNewRow(object sender, RoutedEventArgs e)
        {
            if (Code == null)
                return;
            uint themeId = _tables.ViewModel.CurrentState.Id;
            _tables.Tools.AddRow.GeneralSelection(themeId, Code.Value);
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
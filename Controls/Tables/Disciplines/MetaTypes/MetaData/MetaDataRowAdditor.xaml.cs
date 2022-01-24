using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using static Wreath.Controls.Tables.EditHelper;

namespace Wreath.Controls.Tables.Disciplines.MetaTypes.MetaData
{
    /// <summary>
    /// Metadata table special row to add new rows
    /// </summary>
    public partial class MetaDataRowAdditor : UserControl, INotifyPropertyChanged, IAutoIndexing
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

        private uint? _metaType = null;
        public uint? MetaType
        {
            get => _metaType;
            set
            {
                _metaType = value;
                OnPropertyChanged();
            }
        }

        private string _metaValue = "";
        public string MetaValue
        {
            get => _metaValue;
            set
            {
                _metaValue = value;
                OnPropertyChanged();
            }
        }

        public bool CanBeEdited => HaveSpace();
        private StackPanel _table;

        private bool HaveSpace()
        {
            return (_table != null) && _table.Children.Count < ushort.MaxValue;
        }

        public MetaDataRowAdditor()
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
            MetaType = id;
        }

        private void SelectCode(object sender, RoutedEventArgs e)
        {
            SelectionFields(0, _tables.Data.MetaTypes,
                "Типы метаданных:", "Метаданные", _tables.FillMetaTypes, SetCode);
            e.Handled = true;
        }

        private void AddNewRow(object sender, RoutedEventArgs e)
        {
            if (MetaType == null)
                return;
            uint disciplineId = _tables.ViewModel.CurrentState.Id;
            _tables.Tools.AddRow.MetaData(disciplineId, MetaType.Value, MetaValue);
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
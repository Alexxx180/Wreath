using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Convert;
using static Wreath.Controls.Tables.EditHelper;

namespace Wreath.Controls.Tables.Disciplines
{
    /// <summary>
    /// Disciplines table row component
    /// </summary>
    public partial class DisciplineRow : UserControl, INotifyPropertyChanged, IRedactable
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

        private string _name = "";
        public string DisciplineName
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private bool _canBeEdited = false;
        public bool CanBeEdited
        {
            get => _canBeEdited;
            set
            {
                _canBeEdited = value;
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

        public DisciplineRow()
        {
            InitializeComponent();
            SetStyles();
        }

        public void SetElement(string[] row)
        {
            Id = ToUInt32(row[0]);
            Code = ToUInt32(row[1]);
            DisciplineName = row[2];
        }

        private LayoutMaster _tables;
        public void SetTools(StackPanel table)
        {
            _tables = GetLayout(table);
        }

        public void Select()
        {
            CanBeEdited = !CanBeEdited;
            if (CanBeEdited)
            {
                _tables.ViewModel.SelectRow(RowKey, Id);
                Selection = _selected;
            }
            else
            {
                _tables.ViewModel.DeSelectRow(RowKey);
                Selection = _unselected;
            }
        }

        private void Select(object sender, RoutedEventArgs e)
        {
            Select();
        }

        public void SetCode(uint id)
        {
            Code = id;
        }

        private void SelectCode(object sender, RoutedEventArgs e)
        {
            SelectionFields(Id, _tables.Data.DisciplineCodes, "Коды дисциплин:",
                "Дисциплина", _tables.FillDisciplineCodes, SetCode);
            e.Handled = true;
        }

        public void Index(int no)
        {
            No = no;
        }

        private void CheckSelection(ComboBox selector)
        {
            switch (selector.SelectedIndex)
            {
                case 0:
                    _tables.FillTopics(Id);
                    break;
                case 1:
                    _tables.FillDisciplineGeneralCompetetions(Id);
                    break;
                case 2:
                    _tables.FillDisciplineProfessionalCompetetions(Id);
                    break;
                case 3:
                    _tables.FillSources(Id);
                    break;
                case 4:
                    _tables.FillMetaData(Id);
                    break;
                case 5:
                    _tables.FillHours(Id);
                    break;
                default:
                    break;
            }
        }

        public void EditConfirm()
        {
            if (Code == null)
                return;
            _tables.Tools.EditRow.Discipline(Id, Code.Value, DisciplineName);
        }

        public void MarkPrepare()
        {
            Selection = _marked;
        }

        public void MarkConfirm()
        {
            _tables.Tools.MarkRow.Discipline(Id);
        }

        public void UnMark()
        {
            Selection = _selected;
        }

        private void SecondaryTables_Select(object sender, SelectionChangedEventArgs e)
        {
            ComboBox selector = sender as ComboBox;
            CheckSelection(selector);
            e.Handled = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Convert;
using static Wreath.Controls.Tables.EditHelper;

namespace Wreath.Controls.Tables.Conformity
{
    /// <summary>
    /// Conformity table row component
    /// </summary>
    public partial class ConformityRow : UserControl, INotifyPropertyChanged, IRedactable
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

        private uint? _discipline = null;
        public uint? Discipline
        {
            get => _discipline;
            set
            {
                _discipline = value;
                OnPropertyChanged();
            }
        }

        private uint? _speciality = null;
        public uint? Speciality
        {
            get => _speciality;
            set
            {
                _speciality = value;
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
            _marked = TryFindResource("Impact3") as Style;
            Selection = _unselected;
        }

        public ConformityRow()
        {
            InitializeComponent();
            SetStyles();
        }

        public void SetElement(string[] row)
        {
            Id = ToUInt32(row[0]);
            Discipline = ToUInt32(row[1]);
            Speciality = ToUInt32(row[2]);
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

        private LayoutMaster _tables;
        public void SetTools(StackPanel table)
        {
            _tables = GetLayout(table);
        }

        private void SetDisciplineId(uint id)
        {
            Discipline = id;
        }

        private void SetSpecialityId(uint id)
        {
            Speciality = id;
        }

        private void SelectDiscipline(object sender, RoutedEventArgs e)
        {
            SelectionFields(Id, _tables.Data.Disciplines,
                "Дисциплины:", "Соответствие", _tables.FillDisciplines, SetDisciplineId);
            e.Handled = true;
        }

        private void SelectSpeciality(object sender, RoutedEventArgs e)
        {
            SelectionFields(Id, _tables.Data.Specialities,
                "Специальности:", "Соответствие", _tables.FillSpecialities, SetSpecialityId);
            e.Handled = true;
        }

        public void Index(int no)
        {
            No = no;
        }

        public void EditConfirm()
        {
            if (Discipline == null || Speciality == null)
                return;
            _tables.Tools.EditRow.Conformity(Id, Discipline.Value, Speciality.Value);
        }

        public void MarkPrepare()
        {
            Selection = _marked;
        }

        public void MarkConfirm()
        {
            _tables.Tools.MarkRow.Conformity(Id);
        }

        public void UnMark()
        {
            Selection = _selected;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
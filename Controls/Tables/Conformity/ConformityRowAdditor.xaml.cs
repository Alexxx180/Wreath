using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static Wreath.Controls.Tables.EditHelper;

namespace Wreath.Controls.Tables.Conformity
{
    /// <summary>
    /// Conformity table special row to add new rows
    /// </summary>
    public partial class ConformityRowAdditor : UserControl, INotifyPropertyChanged, IAutoIndexing
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

        public bool CanBeEdited => HaveSpace();
        private StackPanel _table;

        private bool HaveSpace()
        {
            return (_table != null) && _table.Children.Count < ushort.MaxValue;
        }

        public ConformityRowAdditor()
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
            SelectionFields(0, _tables.Data.Disciplines,
                "Дисциплины:", "Соответствие", _tables.FillDisciplines, SetDisciplineId);
            e.Handled = true;
        }

        private void SelectSpeciality(object sender, RoutedEventArgs e)
        {
            SelectionFields(0, _tables.Data.Specialities,
                "Специальности:", "Соответствие", _tables.FillSpecialities, SetSpecialityId);
            e.Handled = true;
        }

        private void AddNewRow(object sender, RoutedEventArgs e)
        {
            if (Discipline == null || Speciality == null)
                return;
            _tables.Tools.AddRow.Conformity(Discipline.Value, Speciality.Value);
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
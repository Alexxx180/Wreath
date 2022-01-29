using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Convert;
using static Wreath.Controls.Tables.EditHelper;

namespace Wreath.Controls.Tables.Specialities.ProfessionalCompetetions
{
    /// <summary>
    /// Professional competetions table row component
    /// </summary>
    public partial class ProfessionalCompetetionRow : UserControl, INotifyPropertyChanged, IMarkable
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

        private string _professionalNo1;
        public string ProfessionalNo1
        {
            get => _professionalNo1;
            set
            {
                _professionalNo1 = value;
                OnPropertyChanged();
            }
        }

        private string _professionalNo2;
        public string ProfessionalNo2
        {
            get => _professionalNo2;
            set
            {
                _professionalNo2 = value;
                OnPropertyChanged();
            }
        }

        private string _name;
        public string ProfessionalName
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _experience;
        public string Experience
        {
            get => _experience;
            set
            {
                _experience = value;
                OnPropertyChanged();
            }
        }

        private string _skills;
        public string Skills
        {
            get => _skills;
            set
            {
                _skills = value;
                OnPropertyChanged();
            }
        }

        private string _knowledge;
        public string Knowledge
        {
            get => _knowledge;
            set
            {
                _knowledge = value;
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

        public ushort CompetetionNo1 => ToUInt16(ProfessionalNo1);
        public ushort CompetetionNo2 => ToUInt16(ProfessionalNo2);

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
            _unselected = TryFindResource("UnSelected") as Style;
            _selected = TryFindResource("Selected") as Style;
            _marked = TryFindResource("Marked") as Style;
            Selection = _unselected;
        }

        private void SetDefaults()
        {
            IsMarked = false;
            IsSelected = false;
            ProfessionalNo1 = "";
            ProfessionalNo2 = "";
            ProfessionalName = "";
            Knowledge = "";
            Skills = "";
            Experience = "";
            SetStyles();
        }

        public ProfessionalCompetetionRow()
        {
            InitializeComponent();
            SetDefaults();
        }

        public void SetElement(string[] row)
        {
            Id = ToUInt32(row[0]);
            ProfessionalNo1 = row[1];
            ProfessionalNo2 = row[2];
            ProfessionalName = row[3];
            Knowledge = row[4];
            Skills = row[5];
            Experience = row[6];
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

        public void Mark()
        {
            IsMarked = true;
            Selection = _marked;
        }

        public void UnMarkConfirm()
        {
            _tables.Tools.UnMarkRow.ProfessionalCompetetion(Id);
        }

        public void DropConfirm()
        {
            _tables.Tools.DropRow.ProfessionalCompetetion(Id);
        }

        private void FastSelect(object sender, MouseEventArgs e)
        {
            if (!IsMarked)
                return;
            if (Keyboard.IsKeyDown(Key.LeftShift))
                Select();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
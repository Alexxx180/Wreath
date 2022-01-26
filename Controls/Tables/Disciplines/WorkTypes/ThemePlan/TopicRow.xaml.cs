using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Convert;
using static Wreath.Controls.Tables.EditHelper;

namespace Wreath.Controls.Tables.Disciplines.WorkTypes.ThemePlan
{
    /// <summary>
    /// Theme plan table row component
    /// </summary>
    public partial class TopicRow : UserControl, INotifyPropertyChanged, IMarkable
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

        private string _topicNo;
        public string TopicNo
        {
            get => _topicNo;
            set
            {
                _topicNo = value;
                OnPropertyChanged();
            }
        }


        private string _topicName;
        public string TopicName
        {
            get => _topicName;
            set
            {
                _topicName = value;
                OnPropertyChanged();
            }
        }

        private string _hoursCount;
        public string TopicHours
        {
            get => _hoursCount;
            set
            {
                _hoursCount = value;
                OnPropertyChanged();
            }
        }

        public ushort TopicNumber => ToUInt16(TopicNo);
        public ushort HoursCount => ToUInt16(TopicHours);

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
            TopicNo = "";
            TopicName = "";
            TopicHours = "";
            IsMarked = false;
            IsSelected = false;
            SetStyles();
        }

        public TopicRow()
        {
            InitializeComponent();
            SetDefaults();
        }

        public void SetElement(string[] row)
        {
            Id = ToUInt32(row[0]);
            TopicNo = row[1];
            TopicName = row[2];
            TopicHours = row[3];
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

        private void SelectCode(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
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

        private void GoToThemes(object sender, RoutedEventArgs e)
        {
            _tables.FillThemes(Id);
            e.Handled = true;
        }

        public void Mark()
        {
            IsMarked = true;
            Selection = _marked;
        }

        public void UnMarkConfirm()
        {
            _tables.Tools.UnMarkRow.Topic(Id);
        }

        public void DropConfirm()
        {
            _tables.Tools.DropRow.Topic(Id);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
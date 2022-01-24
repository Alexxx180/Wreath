using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static Wreath.Controls.Tables.EditHelper;

namespace Wreath.Controls.Tables.Disciplines.WorkTypes.ThemePlan
{
    /// <summary>
    /// Theme plan table specilai row to add new rows
    /// </summary>
    public partial class TopicRowAdditor : UserControl, INotifyPropertyChanged, IAutoIndexing
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

        private string _topicNo = "";
        public string TopicNo
        {
            get => _topicNo;
            set
            {
                _topicNo = value;
                OnPropertyChanged();
            }
        }


        private string _topicName = "";
        public string TopicName
        {
            get => _topicName;
            set
            {
                _topicName = value;
                OnPropertyChanged();
            }
        }

        private string _hoursCount = "";
        public string TopicHours
        {
            get => _hoursCount;
            set
            {
                _hoursCount = value;
                OnPropertyChanged();
            }
        }

        public ushort TopicNumber => ParseHours(TopicNo);
        public ushort HoursCount => ParseHours(TopicHours);

        public bool CanBeEdited => HaveSpace();
        private StackPanel _table;

        private bool HaveSpace()
        {
            return (_table != null) && _table.Children.Count < ushort.MaxValue;
        }

        public TopicRowAdditor()
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

        private void AddNewRow(object sender, RoutedEventArgs e)
        {
            uint disciplineId = _tables.ViewModel.CurrentState.Id;
            _tables.Tools.AddRow.Topic(disciplineId, TopicNumber, TopicName, HoursCount);
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
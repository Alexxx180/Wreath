using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using static System.Convert;
using Wreath.Model;

namespace Wreath.Controls.RecordForm
{
    /// <summary>
    /// Part responsible for record choosing
    /// </summary>
    public partial class MainPart : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<Pair<uint, string>> _rows;
        public ObservableCollection<Pair<uint, string>> Rows
        {
            get => _rows;
            set
            {
                _rows = value;
                OnPropertyChanged();
            }
        }

        private Pair<uint, string> _selectedRow;
        public Pair<uint, string> SelectedRow
        {
            get { return _selectedRow; }
            set
            {
                _selectedRow = value;
                OnPropertyChanged();
            }
        }

        private RecordSelection _dialog;
        private RecordSelection GetMainPart()
        {
            Grid mainGrid = Parent as Grid;
            return mainGrid.Parent as RecordSelection;
        }

        public MainPart()
        {
            InitializeComponent();
        }

        private void AddAnotherOne(object sender, RoutedEventArgs e)
        {
            _dialog = GetMainPart();
            _dialog.NeedMoreRecords();
        }

        private void SelectOne(object sender, RoutedEventArgs e)
        {
            if (SelectedRow == null)
                return;
            _dialog = GetMainPart();
            _dialog.SelectARecord(SelectedRow.Name);
        }

        private void CurrentView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SelectedRow == null)
                return;
            _dialog = GetMainPart();
            _dialog.SelectARecord(SelectedRow.Name);
        }

        public void SetHeader(string records, string main)
        {
            RecordsName.Text = " " + records;
            MainTableName.Text = main + " ";
        }

        public void FillRows(List<string[]> rows)
        {
            Rows = new ObservableCollection<Pair<uint, string>>();
            for (ushort i = 0; i < rows.Count; i++)
            {
                string[] row = rows[i];
                Rows.Add(ConvertRow(row));
            }
        }

        private static Pair<uint, string> ConvertRow(string[] row)
        {
            uint id = ToUInt32(row[0]);
            string data = string.Join(';', row);
            return new Pair<uint, string>(id, data);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
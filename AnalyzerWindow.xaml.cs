using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wreath.Model;

namespace Wreath
{
    /// <summary>
    /// Marked rows count analyzer window
    /// </summary>
    public partial class AnalyzerWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<TreeViewItem> _rowsCountItems;
        public ObservableCollection<TreeViewItem> RowsCountItems
        {
            get => _rowsCountItems;
            set
            {
                _rowsCountItems = value;
                OnPropertyChanged();
            }
        }

        private AnalyzerWindow()
        {
            InitializeComponent();
            RowsCountItems = new ObservableCollection<TreeViewItem>();
        }

        public AnalyzerWindow(string name) : this()
        {
            SetParent(name);
        }

        public void AddElements(params Pair<string, List<int>>[] items)
        {
            for (byte i = 0; i < items.Length; i++)
            {
                Pair<string, List<int>> item = items[i];
                AddElement(item.Value, item.Name);
            }
        }

        public void AddElement(List<int> levels, string name)
        {
            TreeViewItem rowItem = RowsCountItems[0];
            for (byte i = 0; i < levels.Count; i++)
                rowItem = PeekItem(rowItem, levels[i]);
            rowItem.Items.Add(RowCountItem(name));
            OnPropertyChanged(nameof(RowsCountItems));
        }

        private void SetParent(string name)
        {
            TreeViewItem rowItem = RowCountItem(name);
            RowsCountItems.Add(rowItem);
            OnPropertyChanged(nameof(RowsCountItems));
        }

        private static TreeViewItem PeekItem(TreeViewItem rowItem, int deepLevel)
        {
            TreeViewItem deeperItem = rowItem.Items[deepLevel] as TreeViewItem;
            return deeperItem;
        }

        private static TreeViewItem RowCountItem(string name)
        {
            TreeViewItem rowCount = new TreeViewItem();
            rowCount.Header = name;
            rowCount.IsExpanded = true;
            return rowCount;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
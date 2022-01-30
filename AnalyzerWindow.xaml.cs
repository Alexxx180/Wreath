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

        public AnalyzerWindow()
        {
            InitializeComponent();
            RowsCountItems = new ObservableCollection<TreeViewItem>();
        }

        public void AddElements(params Pair<string, List<int>>[] items)
        {
            for (byte i = 1; i < items.Length; i++)
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

        public void AddParent(string name)
        {
            TreeViewItem rowItem = RowCountItem(name);
            RowsCountItems.Add(rowItem);
            OnPropertyChanged(nameof(RowsCountItems));
        }

        private TreeViewItem PeekItem(TreeViewItem rowItem, int deepLevel)
        {
            //ItemCollection itemCollection = ;
            System.Diagnostics.Trace.WriteLine(rowItem.Header);
            TreeViewItem deeperItem = (TreeViewItem)rowItem.Items[deepLevel];
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
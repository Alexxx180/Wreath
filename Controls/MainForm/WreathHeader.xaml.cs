using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using Wreath.Controls.Tables;
using Wreath.ViewModel;
using Wreath.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wreath.Controls.MainForm
{
    /// <summary>
    /// Part responsible for functionality switching
    /// </summary>
    public partial class WreathHeader : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
                typeof(GlobalViewModel), typeof(WreathHeader),
                new PropertyMetadata(OnConnectionChangedCallBack));

        public static readonly DependencyProperty
            LayoutProperty = DependencyProperty.Register(
                nameof(Layout), typeof(MainWindow), typeof(WreathHeader));

        internal MainWindow Layout
        {
            get => GetValue(LayoutProperty) as MainWindow;
            set => SetValue(LayoutProperty, value);
        }

        internal GlobalViewModel ViewModel
        {
            get => GetValue(ViewModelProperty) as GlobalViewModel;
            set => SetValue(ViewModelProperty, value);
        }

        #region ConnectionCallBack Members
        private static void
            OnConnectionChangedCallBack(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            if (sender is WreathHeader header)
            {
                header?.OnConnectionChanged();
            }
        }

        protected virtual void OnConnectionChanged()
        {
            Tables = ViewModel.TableView;
        }
        #endregion

        internal LayoutMaster Tables { get; set; }

        // Set tools and table by default
        public void SetTablePart(in int id)
        {
            Records.Tag = Layout.RowView;
            ColumnSizes.Tag = Layout.SizeScaler;
            Roles.Tag = Layout.Roles;
            _lastVisited = new Pair<Button, UserControl>
                (Records, Layout.RowView);

            TableSelector.SelectedIndex = id;
        }

        public WreathHeader()
        {
            InitializeComponent();
        }

        private Pair<Button, UserControl> _lastVisited;

        private void ChangeTab(object sender, RoutedEventArgs e)
        {
            _lastVisited.Name.SetActive(true);
            _lastVisited.Value.SetActive(false);

            Button tab = sender as Button;
            UserControl panel = tab.Tag as UserControl;

            tab.SetActive(false);
            panel.SetActive(true);

            _lastVisited.Name = tab;
            _lastVisited.Value = panel;
        }

        private void CheckSelection(ComboBox selector)
        {
            switch (selector.SelectedIndex)
            {
                case 0:
                    Tables.FillDisciplines();
                    break;
                case 1:
                    Tables.FillSpecialities();
                    break;
                case 2:
                    Tables.FillConformity();
                    break;
                default:
                    break;
            }
        }

        private void PrimaryTables_Select(object sender, SelectionChangedEventArgs e)
        {
            ComboBox selector = sender as ComboBox;
            CheckSelection(selector);
        }

        private void PrimaryTables_Click(object sender, MouseButtonEventArgs e)
        {
            ComboBox selector = sender as ComboBox;
            CheckSelection(selector);
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
    }
}
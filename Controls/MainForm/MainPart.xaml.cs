using System.Windows;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Wreath.ViewModel;

namespace Wreath.Controls.MainForm
{
    /// <summary>
    /// Part responsible for viewing and editing data
    /// </summary>
    public partial class MainPart : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
                typeof(GlobalViewModel), typeof(MainPart));

        internal GlobalViewModel ViewModel
        {
            get => GetValue(ViewModelProperty) as GlobalViewModel;
            set => SetValue(ViewModelProperty, value);
        }

        public MainPart()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            ViewModel.BackTransition();
        }

        private void UnMarkRows(object sender, RoutedEventArgs e)
        {
            ViewModel.UnMarkRows(ViewModel.TableView.Records);
        }

        private void DropRows(object sender, RoutedEventArgs e)
        {
            ViewModel.DropRows(ViewModel.TableView.Records);
        }

        #region DangerZone Members
        private void OpenDangerZone(in bool opened)
        {
            FastAction.SetActive(!opened);
            DropAll.SetActive(opened);
            UnmarkAll.SetActive(opened);
        }

        private void FastActions(object sender, RoutedEventArgs e)
        {
            OpenDangerZone(true);
        }

        private void UnMarkAllRows(object sender, RoutedEventArgs e)
        {
            ViewModel.UnMarkAll();
            OpenDangerZone(false);
        }

        private void DropAllRows(object sender, RoutedEventArgs e)
        {
            ViewModel.DropAll();
            OpenDangerZone(false);
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
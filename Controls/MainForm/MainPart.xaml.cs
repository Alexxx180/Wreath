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
        public GlobalViewModel ViewModel { get; }

        public MainPart()
        {
            InitializeComponent();
            ViewModel = DataContext as GlobalViewModel;
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

        // Danger zone

        private void OpenDangerZone(in bool closed)
        {
            FastAction.SetActive(closed);
            bool operations = !closed;
            DropAll.SetActive(operations);
            UnmarkAll.SetActive(operations);
        }

        private void FastActions(object sender, RoutedEventArgs e)
        {
            OpenDangerZone(false);
        }

        private void UnMarkAllRows(object sender, RoutedEventArgs e)
        {
            ViewModel.UnMarkAll();
            OpenDangerZone(true);
        }

        private void DropAllRows(object sender, RoutedEventArgs e)
        {
            ViewModel.DropAll();
            OpenDangerZone(true);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
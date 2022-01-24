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

        private void EditRows(object sender, RoutedEventArgs e)
        {
            ViewModel.EditRows(ViewModel.TableView.Records);
        }

        private void MarkRows(object sender, RoutedEventArgs e)
        {
            ViewModel.MarkRows(ViewModel.TableView.Records);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
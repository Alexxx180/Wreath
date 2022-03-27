using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Wreath.ViewModel;

namespace Wreath
{
    /// <summary>
    /// Main administrator window Interaction logic
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private GlobalViewModel _totalViewModel;
        public GlobalViewModel TotalViewModel
        {
            get => _totalViewModel;
            set
            {
                _totalViewModel = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            TotalViewModel = new GlobalViewModel();

            if (TotalViewModel.Connect())
            {
                ActivateAdmin();
            }
            else
            {
                Close();
            }
        }

        private void ActivateAdmin()
        {
            InitializeComponent();
            Header.SetTablePart(0);
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
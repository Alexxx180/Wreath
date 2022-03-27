using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Wreath
{
    /// <summary>
    /// User log in window
    /// </summary>
    public partial class EntryWindow : Window, INotifyPropertyChanged
    {
        #region EntryWindow Members
        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public string Pass => PassBox.Password;

        private bool _memberMe;
        public bool MemberMe
        {
            get => _memberMe;
            set
            {
                _memberMe = value;
                OnPropertyChanged();
            }
        }

        private bool _newConfig;
        public bool NewConfig
        {
            get => _newConfig;
            set
            {
                _newConfig = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public EntryWindow()
        {
            InitializeComponent();
            MemberMe = false;
            Login = "";
        }

        private void LogInClick(object sender, RoutedEventArgs e)
        {
            OnPropertyChanged(nameof(Pass));
            if (Login.Length <= 0)
                return;
            DialogResult = true;
        }

        private void ConfigSet(object sender, RoutedEventArgs e)
        {
            NewConfig = true;
            DialogResult = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

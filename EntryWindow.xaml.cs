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

        private string _pass;
        public string Pass
        {
            get => _pass;
            set
            {
                _pass = value;
                OnPropertyChanged();
            }
        }

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

        public EntryWindow()
        {
            InitializeComponent();
            MemberMe = false;
            Login = "";
            Pass = "";
        }

        private void LogInClick(object sender, RoutedEventArgs e)
        {
            Pass = PassBox.Password;
            if (Login.Length <= 0)
                return;
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

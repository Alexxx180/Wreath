using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Convert;
using System.Collections.Generic;
using Wreath.Controls.MainForm;

namespace Wreath.Controls.Users
{
    /// <summary>
    /// Redactors table special row to add new rows
    /// </summary>
    public partial class RedactorRowAdditor : UserControl, INotifyPropertyChanged
    {
        private string _host;
        public string Host
        {
            get => _host;
            set
            {
                _host = value;
                OnPropertyChanged();
            }
        }

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

        public RedactorRowAdditor()
        {
            InitializeComponent();
            Host = "%";
        }

        public RedactorRowAdditor(RolesPart administrating) : this()
        {
            SetRoleAdmin(administrating);
        }

        private RolesPart _roles;
        internal void SetRoleAdmin(RolesPart administrating)
        {
            _roles = administrating;
        }

        private void AddRedactor(object sender, RoutedEventArgs e)
        {
            if (Login is null)
                return;
            if (Login.Length <= 0 || PassBox.Password.Length <= 0)
                return;
            if (ToUInt32(_roles.Redactors.CountRedactors(Login)) > 0)
                return;
            _roles.Redactors.AddRedactor(
                new Dictionary<string, object> {
                    { "redactor_login", Login },
                    { "redactor_host", Host },
                    { "redactor_pass", PassBox.Password }
                }
            );
            _roles.ResetRecords();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
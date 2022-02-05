using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Convert;
using static Wreath.Controls.Tables.EditHelper;
using System.Collections.Generic;
using static Wreath.ViewModel.GlobalViewModel;
using Wreath.Controls.MainForm;

namespace Wreath.Controls.Users
{
    /// <summary>
    /// Redactors table row component
    /// </summary>
    public partial class RedactorRow : UserControl, INotifyPropertyChanged
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

        private string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                OnPropertyChanged();
            }
        }

        public RedactorRow()
        {
            InitializeComponent();
        }

        internal static void AddElements(StackPanel stack, List<string[]> rows)
        {
            for (byte i = 0; i < rows.Count; i++)
            {
                RedactorRow redactor = new RedactorRow();
                redactor.SetElement(rows[i]);
                redactor.SetRoleAdmin(stack.Tag as RolesPart);
                _ = stack.Children.Add(redactor);
            }
        }

        private RolesPart _roles;
        internal void SetRoleAdmin(RolesPart administrating)
        {
            _roles = administrating;
        }

        private void DropRow(object sender, RoutedEventArgs e)
        {
            if (!AllRowsDialog("Данный пользователь не будет\nпринимать участие в редактировании."))
                return;
            _roles.Redactors.DropRedactor(
                new Dictionary<string, object> {
                    { "redactor_login", Login },
                    { "redactor_host", Host }
                }
            );
            _roles.ResetRecords();
        }

        private void ViewRow(object sender, RoutedEventArgs e)
        {
            ViewFields(
                new Model.Pair<string, string>("Подключение", Host),
                new Model.Pair<string, string>("Логин", Login),
                new Model.Pair<string, string>("Комментарий", Comment)
            );
        }

        public void SetElement(string[] row)
        {
            Login = row[0];
            Pass = new string('*', ToInt32(row[1]));
            Host = row[2];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
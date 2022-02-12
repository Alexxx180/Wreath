using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Wreath.Controls.Users;
using Wreath.Model.Tools;
using Wreath.Model.Tools.DataBase;
using Wreath.Model.Tools.DataBase.View;
using Wreath.ViewModel;

namespace Wreath.Controls.MainForm
{
    /// <summary>
    /// Part responsible for roles (redactors) administrating
    /// </summary>
    public partial class RolesPart : UserControl
    {
        private GlobalViewModel _viewModel;
        public GlobalViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                Redactors = ViewModel.Connector;
                if (Sql.IsConnected)
                    ResetRecords();
                OnPropertyChanged();
            }
        }

        private UserControl _header;
        public UserControl Header
        {
            get => _header;
            set
            {
                _header = value;
                OnPropertyChanged();
            }
        }

        public RolesPart()
        {
            if (Sql.IsConnected)
                InitializeComponent();
        }

        internal void ResetRecords()
        {
            Records.Children.Clear();
            RedactorRow.AddElements(Records,
                Converters.ConvertAll(Redactors.GetRedactors(),
                Converters.ElementsToString));
            _ = Records.Children.Add(new RedactorRowAdditor(this));
        }

        private IRolesAdministrating _redactors;
        internal IRolesAdministrating Redactors
        {
            get => _redactors;
            set
            {
                _redactors = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

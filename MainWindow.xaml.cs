using System.Windows;
using static Wreath.Model.Tools.DataBase.UserConnectionHelper;

namespace Wreath
{
    /// <summary>
    /// Main administrator window Interaction logic
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if (FileConnection() || Connect())
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
            Header.SetTables(0);
        }
    }
}
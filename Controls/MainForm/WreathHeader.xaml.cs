using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using Wreath.Controls.Tables;
using Wreath.ViewModel;
using Wreath.Model;
using Wreath.Model.DataBase;

namespace Wreath.Controls.MainForm
{
    /// <summary>
    /// Part responsible for functionality switching
    /// </summary>
    public partial class WreathHeader : UserControl
    {
        internal GlobalViewModel ViewModel { get; set; }
        internal LayoutMaster Tables { get; set; }
        internal MainWindow Layout { get; set; }

        // Set table view and table by default
        public void SetTables(in int id)
        {
            SetTablePart();
            TableSelector.SelectedIndex = id;
        }

        private void SetTablePart()
        {
            Tables = ViewModel.TableView;

            Records.Tag = Layout.RowView;
            ColumnSizes.Tag = Layout.SizeScaler;
            Roles.Tag = Layout.Roles;
            _lastVisited = new Pair<Button, UserControl>(Records, Layout.RowView);
        }

        public WreathHeader()
        {
            if (Sql.IsConnected)
                InitializeComponent();
        }

        private Pair<Button, UserControl> _lastVisited;

        private void ChangeTab(object sender, RoutedEventArgs e)
        {
            _lastVisited.Name.SetActive(true);
            _lastVisited.Value.SetActive(false);

            Button tab = sender as Button;
            UserControl panel = tab.Tag as UserControl;

            tab.SetActive(false);
            panel.SetActive(true);

            _lastVisited.Name = tab;
            _lastVisited.Value = panel;
        }

        private void CheckSelection(ComboBox selector)
        {
            switch (selector.SelectedIndex)
            {
                case 0:
                    Tables.FillDisciplines();
                    break;
                case 1:
                    Tables.FillSpecialities();
                    break;
                case 2:
                    Tables.FillConformity();
                    break;
                default:
                    break;
            }
        }

        private void PrimaryTables_Select(object sender, SelectionChangedEventArgs e)
        {
            ComboBox selector = sender as ComboBox;
            CheckSelection(selector);
        }

        private void PrimaryTables_Click(object sender, MouseButtonEventArgs e)
        {
            ComboBox selector = sender as ComboBox;
            CheckSelection(selector);
        }
    }
}
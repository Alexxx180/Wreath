using System.Windows.Input;
using System.Windows.Controls;
using Wreath.Controls.Tables;

namespace Wreath.Controls.MainForm
{
    /// <summary>
    /// Part responsible for primary tables selection
    /// </summary>
    public partial class ProsperityHeader : UserControl
    {
        internal LayoutMaster Tables { get; set; }
        private LayoutMaster GetTablePart()
        {
            Grid mainGrid = Parent as Grid;
            MainWindow window = mainGrid.Parent as MainWindow;
            MainPart rowView = window.RowView;
            return rowView.ViewModel.TableView;
        }

        // Set table view and table by default
        public void SetTables(in int id)
        {
            SetTablePart();
            TableSelector.SelectedIndex = id;
        }

        public void SetTablePart()
        {
            Tables = GetTablePart();
        }

        public ProsperityHeader()
        {
            InitializeComponent();
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
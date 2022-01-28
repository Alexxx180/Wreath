using System.Windows;
using System.Windows.Controls;

namespace Wreath.Controls.Tables.Disciplines.GeneralMastering
{
    /// <summary>
    /// General mastering columns header
    /// </summary>
    public partial class DisciplineGeneralMasteringColumns : UserControl
    {
        public DisciplineGeneralMasteringColumns()
        {
            InitializeComponent();
        }

        private LayoutMaster _tables;
        public DisciplineGeneralMasteringColumns(LayoutMaster view) : this()
        {
            _tables = view;
        }

        private void SelectCode(object sender, RoutedEventArgs e)
        {
            _tables.FillGeneralFromMastering(_tables.ViewModel.CurrentState.Id);
        }
    }
}
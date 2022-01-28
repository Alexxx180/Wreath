using System.Windows;
using System.Windows.Controls;

namespace Wreath.Controls.Tables.Disciplines.WorkTypes.ThemePlan.Themes.GeneralMastering
{
    /// <summary>
    /// General selection table columns header
    /// </summary>
    public partial class ThemeGeneralMasteringColumns : UserControl
    {
        public ThemeGeneralMasteringColumns()
        {
            InitializeComponent();
        }

        private LayoutMaster _tables;
        public ThemeGeneralMasteringColumns(LayoutMaster view) : this()
        {
            _tables = view;
        }

        private void SelectCode(object sender, RoutedEventArgs e)
        {
            _tables.FillDisciplineGeneralFromMastering(_tables.ViewModel.CurrentState.Id);
        }
    }
}
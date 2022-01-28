using System.Windows;
using System.Windows.Controls;

namespace Wreath.Controls.Tables.Disciplines.WorkTypes.ThemePlan.Themes.ProfessionalMastering
{
    /// <summary>
    /// Professional selection table columns header
    /// </summary>
    public partial class ThemeProfessionalMasteringColumns : UserControl
    {
        public ThemeProfessionalMasteringColumns()
        {
            InitializeComponent();
        }

        private LayoutMaster _tables;
        public ThemeProfessionalMasteringColumns(LayoutMaster view) : this()
        {
            _tables = view;
        }

        private void SelectCode(object sender, RoutedEventArgs e)
        {
            _tables.FillDisciplineProfessionalFromMastering(_tables.ViewModel.CurrentState.Id);
        }
    }
}
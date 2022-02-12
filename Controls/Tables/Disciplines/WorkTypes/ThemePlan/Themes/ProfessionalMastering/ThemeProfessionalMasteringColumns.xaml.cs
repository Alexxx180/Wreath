using System;
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
            uint themeId = _tables.ViewModel.CurrentState.Id;
            uint disciplineId = Convert.ToUInt32(_tables.Data.DisciplineByTheme(themeId));
            _tables.FillDisciplineGeneralCompetetions(disciplineId);
        }
    }
}
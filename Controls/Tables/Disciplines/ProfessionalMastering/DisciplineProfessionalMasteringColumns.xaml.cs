using System.Windows;
using System.Windows.Controls;

namespace Wreath.Controls.Tables.Disciplines.ProfessionalMastering
{
    /// <summary>
    /// Professional mastering table columns header
    /// </summary>
    public partial class DisciplineProfessionalMasteringColumns : UserControl
    {
        public DisciplineProfessionalMasteringColumns()
        {
            InitializeComponent();
        }

        private LayoutMaster _tables;
        public DisciplineProfessionalMasteringColumns(LayoutMaster view) : this()
        {
            _tables = view;
        }

        private void SelectCode(object sender, RoutedEventArgs e)
        {
            _tables.FillProfessionalFromMastering(_tables.ViewModel.CurrentState.Id);
        }
    }
}
using System.Windows;
using System.Windows.Controls;

namespace Wreath.Controls.Tables.Disciplines
{
    /// <summary>
    /// Disciplines table columns header
    /// </summary>
    public partial class DisciplineColumns : UserControl
    {
        public DisciplineColumns()
        {
            InitializeComponent();
        }

        private LayoutMaster _tables;
        public DisciplineColumns(LayoutMaster view) : this()
        {
            _tables = view;
        }

        private void SelectCode(object sender, RoutedEventArgs e)
        {
            _tables.FillDisciplineCodes(0);
        }
    }
}
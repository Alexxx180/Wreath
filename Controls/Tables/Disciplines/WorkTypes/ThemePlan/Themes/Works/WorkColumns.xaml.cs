using System.Windows;
using System.Windows.Controls;

namespace Wreath.Controls.Tables.Disciplines.WorkTypes.ThemePlan.Themes.Works
{
    /// <summary>
    /// Works table columns header
    /// </summary>
    public partial class WorkColumns : UserControl
    {
        public WorkColumns()
        {
            InitializeComponent();
        }

        private LayoutMaster _tables;
        public WorkColumns(LayoutMaster view) : this()
        {
            _tables = view;
        }

        private void SelectCode(object sender, RoutedEventArgs e)
        {
            _tables.FillWorkTypes(0);
        }
    }
}
using System.Windows;
using System.Windows.Controls;

namespace Wreath.Controls.Tables.Disciplines.WorkTypes.Hours
{
    /// <summary>
    /// Hours table columns header
    /// </summary>
    public partial class HoursColumns : UserControl
    {
        public HoursColumns()
        {
            InitializeComponent();
        }

        private LayoutMaster _tables;
        public HoursColumns(LayoutMaster view) : this()
        {
            _tables = view;
        }

        private void SelectCode(object sender, RoutedEventArgs e)
        {
            _tables.FillWorkTypes(0);
        }
    }
}
using System.Windows;
using System.Windows.Controls;

namespace Wreath.Controls.Tables.Specialities
{
    /// <summary>
    /// Specialities table columns header
    /// </summary>
    public partial class SpecialityColumns : UserControl
    {
        public SpecialityColumns()
        {
            InitializeComponent();
        }

        private LayoutMaster _tables;
        public SpecialityColumns(LayoutMaster view) : this()
        {
            _tables = view;
        }

        private void SelectCode(object sender, RoutedEventArgs e)
        {
            _tables.FillSpecialityCodes(0);
        }
    }
}
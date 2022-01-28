using System.Windows;
using System.Windows.Controls;

namespace Wreath.Controls.Tables.Disciplines.SourceTypes.Sources
{
    /// <summary>
    /// Sources table columns header
    /// </summary>
    public partial class SourceColumns : UserControl
    {
        public SourceColumns()
        {
            InitializeComponent();
        }

        private LayoutMaster _tables;
        public SourceColumns(LayoutMaster view) : this()
        {
            _tables = view;
        }

        private void SelectCode(object sender, RoutedEventArgs e)
        {
            _tables.FillSourceTypes(0);
        }
    }
}
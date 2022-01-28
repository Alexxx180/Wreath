using System.Windows;
using System.Windows.Controls;

namespace Wreath.Controls.Tables.Disciplines.MetaTypes.MetaData
{
    /// <summary>
    /// Metadata table columns header
    /// </summary>
    public partial class MetaDataColumns : UserControl
    {
        public MetaDataColumns()
        {
            InitializeComponent();
        }

        private LayoutMaster _tables;
        public MetaDataColumns(LayoutMaster view) : this()
        {
            _tables = view;
        }

        private void SelectCode(object sender, RoutedEventArgs e)
        {
            _tables.FillMetaTypes(0);
        }
    }
}
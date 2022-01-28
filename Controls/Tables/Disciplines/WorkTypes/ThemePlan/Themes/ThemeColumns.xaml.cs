using System.Windows;
using System.Windows.Controls;

namespace Wreath.Controls.Tables.Disciplines.WorkTypes.ThemePlan.Themes
{
    /// <summary>
    /// Themes table columns header
    /// </summary>
    public partial class ThemeColumns : UserControl
    {
        public ThemeColumns()
        {
            InitializeComponent();
        }

        private LayoutMaster _tables;
        public ThemeColumns(LayoutMaster view) : this()
        {
            _tables = view;
        }

        private void SelectCode(object sender, RoutedEventArgs e)
        {
            _tables.FillCompetetionLevels(0);
        }
    }
}
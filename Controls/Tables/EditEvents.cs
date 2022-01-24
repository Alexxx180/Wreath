using System.Windows;
using System.Windows.Input;
using static Wreath.Controls.Tables.EditHelper;

namespace Wreath.Controls.Tables
{
    public partial class EditEvents
    {
        private void Hours(object sender, TextCompositionEventArgs e)
        {
            CheckForHours(sender, e);
        }

        private void PastingHours(object sender, DataObjectPastingEventArgs e)
        {
            CheckForPastingHours(sender, e);
        }
    }
}
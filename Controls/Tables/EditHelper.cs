using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using static System.Convert;
using Wreath.Model;

namespace Wreath.Controls.Tables
{
    public static class EditHelper
    {
        public static ushort ParseHours(string numberText)
        {
            return ushort.TryParse(numberText, out ushort result) ? result : ToUInt16(0);
        }

        public static LayoutMaster GetLayout(StackPanel tableView)
        {
            return tableView.Tag as LayoutMaster;
        }

        public static void ViewFields(params Pair<string, string>[] row)
        {
            RecordFields fields = new RecordFields(row);
            fields.Show();
        }

        private static string GetProposedText(TextBox textBox, string newText)
        {
            var text = textBox.Text;
            if (textBox.SelectionStart != -1)
                text = text.Remove(textBox.SelectionStart, textBox.SelectionLength);
            text = text.Insert(textBox.CaretIndex, newText);
            return text;
        }

        private static readonly Regex _hours = new Regex("^([1-9]|[1-9]\\d\\d?)$");
        public static void CheckForHours(object sender, TextCompositionEventArgs e)
        {
            TextBox box = e.OriginalSource as TextBox;
            string full = box.Text.Insert(box.CaretIndex, e.Text);
            e.Handled = !_hours.IsMatch(full);
        }
        public static void CheckForPastingHours(object sender, DataObjectPastingEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string pastedText = e.DataObject.GetData(typeof(string)) as string;
                string proposedText = GetProposedText(textBox, pastedText);

                if (!_hours.IsMatch(proposedText))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
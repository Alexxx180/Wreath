using System.Windows;
using Wreath.Model;

namespace Wreath
{
    /// <summary>
    /// Record selection window dialog
    /// </summary>
    public partial class RecordFields : Window
    {
        public RecordFields()
        {
            InitializeComponent();
        }

        public RecordFields(params Pair<string, string>[] record) : this()
        {
            FieldsView.SeparateTopics(record);
        }
    }
}
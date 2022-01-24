using System.Collections.Generic;
using System.Windows;

namespace Wreath
{
    /// <summary>
    /// Record selection window dialog
    /// </summary>
    public partial class RecordSelection : Window
    {
        public bool EditsNeeded { get; set; }
        public uint Id { get; set; }

        public RecordSelection()
        {
            InitializeComponent();
        }

        public RecordSelection(List<string[]> records) : this()
        {
            ListTableView.FillRows(records);
        }

        public RecordSelection(List<string[]> records,
            string selectionName, string mainName) : this()
        {
            ListTableView.SetHeader(selectionName, mainName);
            ListTableView.FillRows(records);
        }

        public void NeedMoreRecords()
        {
            EditsNeeded = true;
            DialogResult = true;
        }

        public void SelectARecord(uint id)
        {
            Id = id;
            EditsNeeded = false;
            DialogResult = true;
        }
    }
}
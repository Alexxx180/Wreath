namespace Wreath.Controls.Tables
{
    public interface IRedactable : IAutoIndexing
    {
        public bool CanBeEdited { get; }

        public void SetElement(string[] row);

        public void EditConfirm();
        public void MarkPrepare();
        public void MarkConfirm();
        public void UnMark();
    }
}
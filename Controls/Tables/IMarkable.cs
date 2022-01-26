namespace Wreath.Controls.Tables
{
    public interface IMarkable : IAutoIndexing
    {
        public bool IsMarked { get; }

        public void SetElement(string[] row);

        public void DropConfirm();
        public void UnMarkConfirm();
        public void Mark();
    }
}
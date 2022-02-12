namespace Wreath.Model.Tools.DataBase.Edit
{
    public class RedactorTools
    {
        public RedactorTools(Sql connector)
        {
            UnMarkRow = new UnMark(connector);
            DropRow = new Drop(connector);
        }

        internal UnMark UnMarkRow { get; }
        internal Drop DropRow { get; }
    }
}
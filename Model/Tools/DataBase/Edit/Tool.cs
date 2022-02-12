namespace Wreath.Model.Tools.DataBase.Edit
{
    public class Tool
    {
        protected IDataAdministrator DataBase { get; }

        public Tool(Sql connector)
        {
            DataBase = connector;
        }
    }
}
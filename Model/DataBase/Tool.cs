namespace Wreath.Model.DataBase
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
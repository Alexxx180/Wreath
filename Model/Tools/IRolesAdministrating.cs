using System.Collections.Generic;

namespace Wreath.Model.Tools
{
    internal interface IRolesAdministrating
    {
        public List<object[]> GetRedactors();

        public object CountRedactors(string value);

        public void AddRedactor(Dictionary<string, object> parameters);

        public void ResetRedactorPass(Dictionary<string, object> parameters);

        public void DropRedactor(Dictionary<string, object> parameters);
    }
}
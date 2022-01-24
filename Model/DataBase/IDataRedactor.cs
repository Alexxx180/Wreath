using System.Collections.Generic;

namespace Wreath.Model.DataBase
{
    public interface IDataRedactor
    {
        public void AddConformity(Dictionary<string, object> parameters);

        public void AddSpeciality(Dictionary<string, object> parameters);

        public void AddSpecialityCode(string value);

        public void AddGeneralCompetetion(Dictionary<string, object> parameters);

        public void AddProfessionalCompetetion(Dictionary<string, object> parameters);

        public void AddDiscipline(Dictionary<string, object> parameters);

        public void AddDisciplineCode(string value);

        public void AddTotalHour(Dictionary<string, object> parameters);

        public void AddTopic(Dictionary<string, object> parameters);

        public void AddTheme(Dictionary<string, object> parameters);

        public void AddWork(Dictionary<string, object> parameters);

        public void AddWorkType(string value);

        public void AddTask(Dictionary<string, object> parameters);

        public void AddMetaData(Dictionary<string, object> parameters);

        public void AddMetaType(string value);

        public void AddSource(Dictionary<string, object> parameters);

        public void AddSourceType(string value);

        public void AddGeneralMastering(Dictionary<string, object> parameters);

        public void AddProfessionalMastering(Dictionary<string, object> parameters);

        public void AddGeneralSelection(Dictionary<string, object> parameters);

        public void AddProfessionalSelection(Dictionary<string, object> parameters);

        public void AddLevel(Dictionary<string, object> parameters);


        public void SetConformity(Dictionary<string, object> parameters);

        public void SetSpeciality(Dictionary<string, object> parameters);

        public void SetSpecialityCode(Dictionary<string, object> parameters);

        public void SetGeneralCompetetion(Dictionary<string, object> parameters);

        public void SetProfessionalCompetetion(Dictionary<string, object> parameters);

        public void SetDiscipline(Dictionary<string, object> parameters);

        public void SetDisciplineCode(Dictionary<string, object> parameters);

        public void SetTotalHour(Dictionary<string, object> parameters);

        public void SetTopic(Dictionary<string, object> parameters);

        public void SetTheme(Dictionary<string, object> parameters);

        public void SetWork(Dictionary<string, object> parameters);

        public void SetWorkType(Dictionary<string, object> parameters);

        public void SetTask(Dictionary<string, object> parameters);

        public void SetMetaData(Dictionary<string, object> parameters);

        public void SetMetaType(Dictionary<string, object> parameters);

        public void SetSource(Dictionary<string, object> parameters);

        public void SetSourceType(Dictionary<string, object> parameters);

        public void SetGeneralMastering(Dictionary<string, object> parameters);

        public void SetProfessionalMastering(Dictionary<string, object> parameters);

        public void SetGeneralSelection(Dictionary<string, object> parameters);

        public void SetProfessionalSelection(Dictionary<string, object> parameters);

        public void SetLevel(Dictionary<string, object> parameters);


        public void MarkConformity(ulong value);

        public void MarkSpeciality(ulong value);

        public void MarkSpecialityCode(ulong value);

        public void MarkGeneralCompetetion(ulong value);

        public void MarkProfessionalCompetetion(ulong value);

        public void MarkDiscipline(ulong value);

        public void MarkDisciplineCode(ulong value);

        public void MarkTotalHour(ulong value);

        public void MarkTopic(ulong value);

        public void MarkTheme(ulong value);

        public void MarkWork(ulong value);

        public void MarkWorkType(ulong value);

        public void MarkTask(ulong value);

        public void MarkMetaData(ulong value);

        public void MarkMetaType(ulong value);

        public void MarkSource(ulong value);

        public void MarkSourceType(ulong value);

        public void MarkGeneralMastering(ulong value);

        public void MarkProfessionalMastering(ulong value);

        public void MarkGeneralSelection(ulong value);

        public void MarkProfessionalSelection(ulong value);

        public void MarkLevel(ulong value);
    }
}
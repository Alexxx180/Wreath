namespace Wreath.Model.DataBase
{
    public interface IDataAdministrator
    {
        public void UnMarkConformity(ulong value);

        public void UnMarkSpeciality(ulong value);

        public void UnMarkSpecialityCode(ulong value);

        public void UnMarkGeneralCompetetion(ulong value);

        public void UnMarkProfessionalCompetetion(ulong value);

        public void UnMarkDiscipline(ulong value);

        public void UnMarkDisciplineCode(ulong value);

        public void UnMarkTotalHour(ulong value);

        public void UnMarkTopic(ulong value);

        public void UnMarkTheme(ulong value);

        public void UnMarkWork(ulong value);

        public void UnMarkWorkType(ulong value);

        public void UnMarkTask(ulong value);

        public void UnMarkMetaData(ulong value);

        public void UnMarkMetaType(ulong value);

        public void UnMarkSource(ulong value);

        public void UnMarkSourceType(ulong value);

        public void UnMarkGeneralMastering(ulong value);

        public void UnMarkProfessionalMastering(ulong value);

        public void UnMarkGeneralSelection(ulong value);

        public void UnMarkProfessionalSelection(ulong value);

        public void UnMarkLevel(ulong value);


        public void DropConformity(ulong value);

        public void DropSpeciality(ulong value);

        public void DropSpecialityCode(ulong value);

        public void DropGeneralCompetetion(ulong value);

        public void DropProfessionalCompetetion(ulong value);

        public void DropDiscipline(ulong value);

        public void DropDisciplineCode(ulong value);

        public void DropTotalHour(ulong value);

        public void DropTopic(ulong value);

        public void DropTheme(ulong value);

        public void DropWork(ulong value);

        public void DropWorkType(ulong value);

        public void DropTask(ulong value);

        public void DropMetaData(ulong value);

        public void DropMetaType(ulong value);

        public void DropSource(ulong value);

        public void DropSourceType(ulong value);

        public void DropGeneralMastering(ulong value);

        public void DropProfessionalMastering(ulong value);

        public void DropGeneralSelection(ulong value);

        public void DropProfessionalSelection(ulong value);

        public void DropLevel(ulong value);



        public void UnMarkAllConformity();

        public void UnMarkAllSpecialities();

        public void UnMarkAllSpecialityCodes();

        public void UnMarkAllGeneralCompetetions();

        public void UnMarkAllProfessionalCompetetions();

        public void UnMarkAllDisciplines();

        public void UnMarkAllDisciplineCodes();

        public void UnMarkAllTotalHours();

        public void UnMarkAllTopics();

        public void UnMarkAllThemes();

        public void UnMarkAllWorks();

        public void UnMarkAllWorkTypes();

        public void UnMarkAllTasks();

        public void UnMarkAllMetaData();

        public void UnMarkAllMetaTypes();

        public void UnMarkAllSources();

        public void UnMarkAllSourceTypes();

        public void UnMarkAllGeneralMastering();

        public void UnMarkAllProfessionalMastering();

        public void UnMarkAllGeneralSelection();

        public void UnMarkAllProfessionalSelection();

        public void UnMarkAllLevels();


        public void DropAllConformity();

        public void DropAllSpecialities();

        public void DropAllSpecialityCodes();

        public void DropAllGeneralCompetetions();

        public void DropAllProfessionalCompetetions();

        public void DropAllDisciplines();

        public void DropAllDisciplineCodes();

        public void DropAllTotalHours();

        public void DropAllTopics();

        public void DropAllThemes();

        public void DropAllWorks();

        public void DropAllWorkTypes();

        public void DropAllTasks();

        public void DropAllMetaData();

        public void DropAllMetaTypes();

        public void DropAllSources();

        public void DropAllSourceTypes();

        public void DropAllGeneralMastering();

        public void DropAllProfessionalMastering();

        public void DropAllGeneralSelection();

        public void DropAllProfessionalSelection();

        public void DropAllLevels();
    }
}
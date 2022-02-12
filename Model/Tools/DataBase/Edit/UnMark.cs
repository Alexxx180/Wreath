namespace Wreath.Model.Tools.DataBase.Edit
{
    internal class UnMark : Tool
    {
        public UnMark(Sql connector) : base(connector)
        {
        }

        public void Conformity(ulong id)
        {
            DataBase.UnMarkConformity(id);
        }

        public void Speciality(ulong id)
        {
            DataBase.UnMarkSpeciality(id);
        }

        public void SpecialityCode(ulong id)
        {
            DataBase.UnMarkSpecialityCode(id);
        }

        public void GeneralCompetetion(ulong id)
        {
            DataBase.UnMarkGeneralCompetetion(id);
        }

        public void ProfessionalCompetetion(ulong id)
        {
            DataBase.UnMarkProfessionalCompetetion(id);
        }

        public void Discipline(ulong id)
        {
            DataBase.UnMarkDiscipline(id);
        }

        public void DisciplineCode(ulong id)
        {
            DataBase.UnMarkDisciplineCode(id);
        }

        public void TotalHour(ulong id)
        {
            DataBase.UnMarkTotalHour(id);
        }

        public void Topic(ulong id)
        {
            DataBase.UnMarkTopic(id);
        }

        public void Theme(ulong id)
        {
            DataBase.UnMarkTheme(id);
        }

        public void Work(ulong id)
        {
            DataBase.UnMarkWork(id);
        }

        public void WorkType(ulong id)
        {
            DataBase.UnMarkWorkType(id);
        }

        public void Task(ulong id)
        {
            DataBase.UnMarkTask(id);
        }

        public void MetaData(ulong id)
        {
            DataBase.UnMarkMetaData(id);
        }

        public void MetaType(ulong id)
        {
            DataBase.UnMarkMetaType(id);
        }

        public void Source(ulong id)
        {
            DataBase.UnMarkSource(id);
        }

        public void SourceType(ulong id)
        {
            DataBase.UnMarkSourceType(id);
        }

        public void GeneralMastering(ulong id)
        {
            DataBase.UnMarkGeneralMastering(id);
        }

        public void ProfessionalMastering(ulong id)
        {
            DataBase.UnMarkProfessionalMastering(id);
        }

        public void GeneralSelection(ulong id)
        {
            DataBase.UnMarkGeneralSelection(id);
        }

        public void ProfessionalSelection(ulong id)
        {
            DataBase.UnMarkProfessionalSelection(id);
        }

        public void Level(ulong id)
        {
            DataBase.UnMarkLevel(id);
        }

        // Methods with increased responsibility

        public void AllConformity()
        {
            DataBase.UnMarkAllConformity();
        }

        public void AllSpeciality()
        {
            DataBase.UnMarkAllSpecialities();
        }

        public void AllSpecialityCode()
        {
            DataBase.UnMarkAllSpecialityCodes();
        }

        public void AllGeneralCompetetion()
        {
            DataBase.UnMarkAllGeneralCompetetions();
        }

        public void AllProfessionalCompetetion()
        {
            DataBase.UnMarkAllProfessionalCompetetions();
        }

        public void AllDiscipline()
        {
            DataBase.UnMarkAllDisciplines();
        }

        public void AllDisciplineCode()
        {
            DataBase.UnMarkAllDisciplineCodes();
        }

        public void AllTotalHour()
        {
            DataBase.UnMarkAllTotalHours();
        }

        public void AllTopic()
        {
            DataBase.UnMarkAllTopics();
        }

        public void AllTheme()
        {
            DataBase.UnMarkAllThemes();
        }

        public void AllWork()
        {
            DataBase.UnMarkAllWorks();
        }

        public void AllWorkType()
        {
            DataBase.UnMarkAllWorkTypes();
        }

        public void AllTask()
        {
            DataBase.UnMarkAllTasks();
        }

        public void AllMetaData()
        {
            DataBase.UnMarkAllMetaData();
        }

        public void AllMetaType()
        {
            DataBase.UnMarkAllMetaTypes();
        }

        public void AllSource()
        {
            DataBase.UnMarkAllSources();
        }

        public void AllSourceType()
        {
            DataBase.UnMarkAllSourceTypes();
        }

        public void AllGeneralMastering()
        {
            DataBase.UnMarkAllGeneralMastering();
        }

        public void AllProfessionalMastering()
        {
            DataBase.UnMarkAllProfessionalMastering();
        }

        public void AllGeneralSelection()
        {
            DataBase.UnMarkAllGeneralSelection();
        }

        public void AllProfessionalSelection()
        {
            DataBase.UnMarkAllProfessionalSelection();
        }

        public void AllLevel()
        {
            DataBase.UnMarkAllLevels();
        }
    }
}

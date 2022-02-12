namespace Wreath.Model.Tools.DataBase.Edit
{
    internal class Drop : Tool
    {
        public Drop(Sql connector) : base(connector)
        {
        }

        public void Conformity(ulong id)
        {
            DataBase.DropConformity(id);
        }

        public void Speciality(ulong id)
        {
            DataBase.DropSpeciality(id);
        }

        public void SpecialityCode(ulong id)
        {
            DataBase.DropSpecialityCode(id);
        }

        public void GeneralCompetetion(ulong id)
        {
            DataBase.DropGeneralCompetetion(id);
        }

        public void ProfessionalCompetetion(ulong id)
        {
            DataBase.DropProfessionalCompetetion(id);
        }

        public void Discipline(ulong id)
        {
            DataBase.DropDiscipline(id);
        }

        public void DisciplineCode(ulong id)
        {
            DataBase.DropDisciplineCode(id);
        }

        public void TotalHour(ulong id)
        {
            DataBase.DropTotalHour(id);
        }

        public void Topic(ulong id)
        {
            DataBase.DropTopic(id);
        }

        public void Theme(ulong id)
        {
            DataBase.DropTheme(id);
        }

        public void Work(ulong id)
        {
            DataBase.DropWork(id);
        }

        public void WorkType(ulong id)
        {
            DataBase.DropWorkType(id);
        }

        public void Task(ulong id)
        {
            DataBase.DropTask(id);
        }

        public void MetaData(ulong id)
        {
            DataBase.DropMetaData(id);
        }

        public void MetaType(ulong id)
        {
            DataBase.DropMetaType(id);
        }

        public void Source(ulong id)
        {
            DataBase.DropSource(id);
        }

        public void SourceType(ulong id)
        {
            DataBase.DropSourceType(id);
        }

        public void GeneralMastering(ulong id)
        {
            DataBase.DropGeneralMastering(id);
        }

        public void ProfessionalMastering(ulong id)
        {
            DataBase.DropProfessionalMastering(id);
        }

        public void GeneralSelection(ulong id)
        {
            DataBase.DropGeneralSelection(id);
        }

        public void ProfessionalSelection(ulong id)
        {
            DataBase.DropProfessionalSelection(id);
        }

        public void Level(ulong id)
        {
            DataBase.DropLevel(id);
        }

        // Methods with increased responsibility

        public void AllConformity()
        {
            DataBase.DropAllConformity();
        }

        public void AllSpeciality()
        {
            DataBase.DropAllSpecialities();
        }

        public void AllGeneralCompetetion()
        {
            DataBase.DropAllGeneralCompetetions();
        }

        public void AllProfessionalCompetetion()
        {
            DataBase.DropAllProfessionalCompetetions();
        }

        public void AllDiscipline()
        {
            DataBase.DropAllDisciplines();
        }

        public void AllTotalHour()
        {
            DataBase.DropAllTotalHours();
        }

        public void AllTopic()
        {
            DataBase.DropAllTopics();
        }

        public void AllTheme()
        {
            DataBase.DropAllThemes();
        }

        public void AllWork()
        {
            DataBase.DropAllWorks();
        }

        public void AllTask()
        {
            DataBase.DropAllTasks();
        }

        public void AllMetaData()
        {
            DataBase.DropAllMetaData();
        }

        public void AllSource()
        {
            DataBase.DropAllSources();
        }

        public void AllGeneralMastering()
        {
            DataBase.DropAllGeneralMastering();
        }

        public void AllProfessionalMastering()
        {
            DataBase.DropAllProfessionalMastering();
        }

        public void AllGeneralSelection()
        {
            DataBase.DropAllGeneralSelection();
        }

        public void AllProfessionalSelection()
        {
            DataBase.DropAllProfessionalSelection();
        }

        public static void None()
        {
            Sql.DropAllCantBeApplied();
        }
    }
}

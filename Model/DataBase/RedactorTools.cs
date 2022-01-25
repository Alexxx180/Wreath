namespace Wreath.Model.DataBase
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

            public void AllSpecialityCode()
            {
                DataBase.DropAllSpecialityCodes();
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

            public void AllDisciplineCode()
            {
                DataBase.DropAllDisciplineCodes();
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

            public void AllWorkType()
            {
                DataBase.DropAllWorkTypes();
            }

            public void AllTask()
            {
                DataBase.DropAllTasks();
            }

            public void AllMetaData()
            {
                DataBase.DropAllMetaData();
            }

            public void AllMetaType()
            {
                DataBase.DropAllMetaTypes();
            }

            public void AllSource()
            {
                DataBase.DropAllSources();
            }

            public void AllSourceType()
            {
                DataBase.DropAllSourceTypes();
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

            public void AllLevel()
            {
                DataBase.DropAllLevels();
            }
        }
    }
}
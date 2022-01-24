using System.Collections.Generic;

namespace Wreath.Model.DataBase
{
    public class RedactorTools
    {
        public RedactorTools(Sql connector)
        {
            AddRow = new Add(connector);
            EditRow = new Edit(connector);
            MarkRow = new Mark(connector);
        }

        internal Add AddRow { get; }
        internal Edit EditRow { get; }
        internal Mark MarkRow { get; }

        internal class Add : Tool
        {
            public Add(Sql connector) : base(connector)
            {
            }

            public void Conformity(uint discipline, uint speciality)
            {
                Dictionary<string, object> parameters = ConformityFields(discipline, speciality);
                DataBase.AddConformity(parameters);
            }

            public void Speciality(uint code, string name)
            {
                Dictionary<string, object> parameters = SpecialityFields(code, name);
                DataBase.AddSpeciality(parameters);
            }

            public void SpecialityCode(string code)
            {
                DataBase.AddSpecialityCode(code);
            }

            public void GeneralCompetetion(uint speciality,
                ushort no, string name, string knowledge, string skills)
            {
                Dictionary<string, object> parameters = GeneralCompetetionFields(
                    speciality, no, name, knowledge, skills);
                DataBase.AddGeneralCompetetion(parameters);
            }

            public void ProfessionalCompetetion(uint speciality, ushort no1, ushort no2,
                string name, string knowledge, string skills, string experience)
            {
                Dictionary<string, object> parameters = ProfessionalCompetetionFields(
                    speciality, no1, no2, name, knowledge, skills, experience);
                DataBase.AddProfessionalCompetetion(parameters);
            }

            public void Discipline(uint code, string name)
            {
                Dictionary<string, object> parameters = DisciplineFields(code, name);
                DataBase.AddDiscipline(parameters);
            }

            public void DisciplineCode(string code)
            {
                DataBase.AddDisciplineCode(code);
            }

            public void TotalHour(uint discipline, uint workType, ushort count)
            {
                Dictionary<string, object> parameters = TotalHourFields(discipline, workType, count);
                DataBase.AddTotalHour(parameters);
            }

            public void Topic(uint discipline, ushort no, string name, ushort hours)
            {
                Dictionary<string, object> parameters = TopicFields(discipline, no, name, hours);
                DataBase.AddTopic(parameters);
            }

            public void Theme(uint topic, ushort masteringLevel,
                ushort no, string name, ushort hours)
            {
                Dictionary<string, object> parameters = ThemeFields(
                    topic, masteringLevel, no, name, hours);
                DataBase.AddTheme(parameters);
            }

            public void Work(uint theme, uint type)
            {
                Dictionary<string, object> parameters = WorkFields(theme, type);
                DataBase.AddWork(parameters);
            }

            public void WorkType(string name)
            {
                DataBase.AddWorkType(name);
            }

            public void Task(ulong work, string name, ushort hours)
            {
                Dictionary<string, object> parameters = TaskFields(work, name, hours);
                DataBase.AddTask(parameters);
            }

            public void MetaData(uint discipline, uint type, string name)
            {
                Dictionary<string, object> parameters = MetaDataFields(discipline, type, name);
                DataBase.AddMetaData(parameters);
            }

            public void MetaType(string name)
            {
                DataBase.AddMetaType(name);
            }

            public void Source(uint discipline, uint type, string name)
            {
                Dictionary<string, object> parameters = SourceFields(discipline, type, name);
                DataBase.AddSource(parameters);
            }

            public void SourceType(string name)
            {
                DataBase.AddSourceType(name);
            }

            public void GeneralMastering(uint discipline, uint generalCompetetion)
            {
                Dictionary<string, object> parameters = GeneralMasteringFields(
                    discipline, generalCompetetion);
                DataBase.AddGeneralMastering(parameters);
            }

            public void ProfessionalMastering(uint discipline, uint professionalCompetetion)
            {
                Dictionary<string, object> parameters = ProfessionalMasteringFields(
                    discipline, professionalCompetetion);
                DataBase.AddProfessionalMastering(parameters);
            }

            public void GeneralSelection(uint theme, uint selection)
            {
                Dictionary<string, object> parameters = GeneralSelectionFields(
                    theme, selection);
                DataBase.AddGeneralSelection(parameters);
            }

            public void ProfessionalSelection(uint theme, uint selection)
            {
                Dictionary<string, object> parameters = ProfessionalSelectionFields(
                    theme, selection);
                DataBase.AddProfessionalSelection(parameters);
            }

            public void Level(string name, string description)
            {
                Dictionary<string, object> parameters = LevelFields(name, description);
                DataBase.AddLevel(parameters);
            }
        }

        internal class Edit : Tool
        {
            public Edit(Sql connector) : base(connector)
            {
            }

            public void Conformity(uint id, uint discipline, uint speciality)
            {
                Dictionary<string, object> parameters = ConformityFields(discipline, speciality);
                parameters.Add("conformity_id", id);
                DataBase.SetConformity(parameters);
            }

            public void Speciality(uint id, uint code, string name)
            {
                Dictionary<string, object> parameters = SpecialityFields(code, name);
                parameters.Add("speciality_id", id);
                DataBase.SetSpeciality(parameters);
            }

            public void SpecialityCode(uint id, string code)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "code_id", id },
                    { "speciality_code", code }
                };
                DataBase.SetSpecialityCode(parameters);
            }

            public void GeneralCompetetion(uint id, uint speciality,
                ushort no, string name, string knowledge, string skills)
            {
                Dictionary<string, object> parameters = GeneralCompetetionFields(
                    speciality, no, name, knowledge, skills);
                parameters.Add("comp_id", id);
                DataBase.SetGeneralCompetetion(parameters);
            }

            public void ProfessionalCompetetion(uint id, uint speciality, ushort no1,
                ushort no2, string name, string knowledge, string skills, string experience)
            {
                Dictionary<string, object> parameters = ProfessionalCompetetionFields(
                    speciality, no1, no2, name, knowledge, skills, experience);
                parameters.Add("comp_id", id);
                DataBase.SetProfessionalCompetetion(parameters);
            }

            public void Discipline(uint id, uint code, string name)
            {
                Dictionary<string, object> parameters = DisciplineFields(code, name);
                parameters.Add("discipline_id", id);
                DataBase.SetDiscipline(parameters);
            }

            public void DisciplineCode(uint id, string code)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "code_id", id },
                    { "discipline_code", code }
                };
                DataBase.SetDisciplineCode(parameters);
            }

            public void TotalHour(uint id, uint discipline, uint workType, ushort count)
            {
                Dictionary<string, object> parameters = TotalHourFields(discipline, workType, count);
                parameters.Add("hour_id", id);
                DataBase.SetTotalHour(parameters);
            }

            public void Topic(uint id, uint discipline, ushort no, string name, ushort hours)
            {
                Dictionary<string, object> parameters = TopicFields(discipline, no, name, hours);
                parameters.Add("section_id", id);
                DataBase.SetTopic(parameters);
            }

            public void Theme(uint id, uint topic, ushort masteringLevel,
                ushort no, string name, ushort hours)
            {
                Dictionary<string, object> parameters = ThemeFields(
                    topic, masteringLevel, no, name, hours);
                parameters.Add("theme_id", id);
                DataBase.SetTheme(parameters);
            }

            public void Work(ulong id, uint theme, uint type)
            {
                Dictionary<string, object> parameters = WorkFields(theme, type);
                parameters.Add("work_id", id);
                DataBase.SetWork(parameters);
            }

            public void WorkType(uint id, string name)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "type_id", id },
                    { "type_name", name }
                };
                DataBase.SetWorkType(parameters);
            }

            public void Task(ulong id, ulong work, string name, ushort hours)
            {
                Dictionary<string, object> parameters = TaskFields(work, name, hours);
                parameters.Add("task_id", id);
                DataBase.SetTask(parameters);
            }

            public void MetaData(uint id, uint discipline, uint type, string name)
            {
                Dictionary<string, object> parameters = MetaDataFields(discipline, type, name);
                parameters.Add("data_id", id);
                DataBase.SetMetaData(parameters);
            }

            public void MetaType(uint id, string name)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "type_id", id },
                    { "type_name", name }
                };
                DataBase.SetMetaType(parameters);
            }

            public void Source(uint id, uint discipline, uint type, string name)
            {
                Dictionary<string, object> parameters = SourceFields(discipline, type, name);
                parameters.Add("source_id", id);
                DataBase.SetSource(parameters);
            }

            public void SourceType(uint id, string name)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "type_id", id },
                    { "type_name", name }
                };
                DataBase.SetSourceType(parameters);
            }

            public void GeneralMastering(uint id, uint discipline, uint generalCompetetion)
            {
                Dictionary<string, object> parameters = GeneralMasteringFields(
                    discipline, generalCompetetion);
                parameters.Add("mastering_id", id);
                DataBase.SetGeneralMastering(parameters);
            }

            public void ProfessionalMastering(uint id, uint discipline, uint professionalCompetetion)
            {
                Dictionary<string, object> parameters = ProfessionalMasteringFields(
                    discipline, professionalCompetetion);
                parameters.Add("mastering_id", id);
                DataBase.SetProfessionalMastering(parameters);
            }

            public void GeneralSelection(uint id, uint theme, uint selection)
            {
                Dictionary<string, object> parameters = GeneralSelectionFields(
                    theme, selection);
                parameters.Add("selection_id", id);
                DataBase.SetGeneralSelection(parameters);
            }

            public void ProfessionalSelection(uint id, uint theme, uint selection)
            {
                Dictionary<string, object> parameters = ProfessionalSelectionFields(
                    theme, selection);
                parameters.Add("selection_id", id);
                DataBase.SetProfessionalSelection(parameters);
            }

            public void Level(uint id, string name, string description)
            {
                Dictionary<string, object> parameters = LevelFields(name, description);
                parameters.Add("level_id", id);
                DataBase.SetLevel(parameters);
            }
        }

        internal class Mark : Tool
        {
            public Mark(Sql connector) : base(connector)
            {
            }

            public void Conformity(ulong id)
            {
                DataBase.MarkConformity(id);
            }

            public void Speciality(ulong id)
            {
                DataBase.MarkSpeciality(id);
            }

            public void SpecialityCode(ulong id)
            {
                DataBase.MarkSpecialityCode(id);
            }

            public void GeneralCompetetion(ulong id)
            {
                DataBase.MarkGeneralCompetetion(id);
            }

            public void ProfessionalCompetetion(ulong id)
            {
                DataBase.MarkProfessionalCompetetion(id);
            }

            public void Discipline(ulong id)
            {
                DataBase.MarkDiscipline(id);
            }

            public void DisciplineCode(ulong id)
            {
                DataBase.MarkDisciplineCode(id);
            }

            public void TotalHour(ulong id)
            {
                DataBase.MarkTotalHour(id);
            }

            public void Topic(ulong id)
            {
                DataBase.MarkTopic(id);
            }

            public void Theme(ulong id)
            {
                DataBase.MarkTheme(id);
            }

            public void Work(ulong id)
            {
                DataBase.MarkWork(id);
            }

            public void WorkType(ulong id)
            {
                DataBase.MarkWorkType(id);
            }

            public void Task(ulong id)
            {
                DataBase.MarkTask(id);
            }

            public void MetaData(ulong id)
            {
                DataBase.MarkMetaData(id);
            }

            public void MetaType(ulong id)
            {
                DataBase.MarkMetaType(id);
            }

            public void Source(ulong id)
            {
                DataBase.MarkSource(id);
            }

            public void SourceType(ulong id)
            {
                DataBase.MarkSourceType(id);
            }

            public void GeneralMastering(ulong id)
            {
                DataBase.MarkGeneralMastering(id);
            }

            public void ProfessionalMastering(ulong id)
            {
                DataBase.MarkProfessionalMastering(id);
            }

            public void GeneralSelection(ulong id)
            {
                DataBase.MarkGeneralSelection(id);
            }

            public void ProfessionalSelection(ulong id)
            {
                DataBase.MarkProfessionalSelection(id);
            }

            public void Level(ulong id)
            {
                DataBase.MarkLevel(id);
            }
        }
    }
}
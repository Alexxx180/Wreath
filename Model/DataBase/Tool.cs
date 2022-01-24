using System.Collections.Generic;

namespace Wreath.Model.DataBase
{
    public class Tool
    {
        protected IDataRedactor DataBase { get; }

        public Tool(Sql connector)
        {
            DataBase = connector;
        }

        protected static Dictionary<string, object> ConformityFields(
            uint discipline, uint speciality) => new Dictionary<string, object>
        {
            { "conformity_discipline", discipline },
            { "conformity_speciality", speciality }
        };

        protected static Dictionary<string, object> SpecialityFields(
            uint code, string name) => new Dictionary<string, object>
        {
            { "speciality_code", code },
            { "speciality_name", name }
        };

        protected static Dictionary<string, object> GeneralCompetetionFields(
            uint speciality, ushort no, string name, string knowledge,
            string skills) => new Dictionary<string, object>
        {
            { "comp_speciality", speciality },
            { "comp_no", no },
            { "comp_name", name },
            { "comp_knowledge", knowledge },
            { "comp_skills", skills }
        };

        protected static Dictionary<string, object> ProfessionalCompetetionFields(
            uint speciality, ushort no1, ushort no2, string name, string knowledge,
            string skills, string experience) => new Dictionary<string, object>
        {
            { "comp_speciality", speciality },
            { "comp_no1", no1 },
            { "comp_no2", no2 },
            { "comp_name", name },
            { "comp_knowledge", knowledge },
            { "comp_skills", skills },
            { "comp_experience", experience }
        };

        protected static Dictionary<string, object> DisciplineFields(
            uint code, string name) => new Dictionary<string, object>
        {
            { "discipline_code", code },
            { "discipline_name", name }
        };

        protected static Dictionary<string, object> TotalHourFields(uint discipline,
            uint workType, ushort count) => new Dictionary<string, object>
        {
            { "discipline_id", discipline },
            { "work_type_id", workType },
            { "hours_count", count }
        };

        protected static Dictionary<string, object> TopicFields(uint discipline,
            ushort no, string name, ushort hours) => new Dictionary<string, object>
        {
            { "section_discipline", discipline },
            { "section_no", no },
            { "section_name", name },
            { "section_hours", hours }
        };

        protected static Dictionary<string, object> ThemeFields(
            uint topic, ushort masteringLevel, ushort no, string name,
            ushort hours) => new Dictionary<string, object>
        {
            { "theme_topic", topic },
            { "theme_mastering_level", masteringLevel },
            { "theme_no", no },
            { "theme_name", name },
            { "theme_hours", hours }
        };

        protected static Dictionary<string, object> WorkFields(
            uint theme, uint type) => new Dictionary<string, object>
        {
            { "work_theme", theme },
            { "work_type", type }
        };

        protected static Dictionary<string, object> TaskFields(ulong work,
            string name, ushort hours) => new Dictionary<string, object>
        {
            { "task_work_id", work },
            { "task_name", name },
            { "task_hours", hours }
        };

        protected static Dictionary<string, object> MetaDataFields(uint discipline,
            uint type, string name) => new Dictionary<string, object>
        {
            { "data_discipline", discipline },
            { "data_type_id", type },
            { "data_name", name }
        };

        protected static Dictionary<string, object> SourceFields(uint discipline,
            uint type, string name) => new Dictionary<string, object>
        {
            { "discipline_id", discipline },
            { "type_id", type },
            { "source_name", name }
        };

        protected static Dictionary<string, object> GeneralMasteringFields(
            uint discipline, uint generalCompetetion) => new Dictionary<string, object>
        {
            { "mastering_discipline", discipline },
            { "general_id", generalCompetetion }
        };

        protected static Dictionary<string, object> ProfessionalMasteringFields(
            uint discipline, uint professionalCompetetion) => new Dictionary<string, object>
        {
            { "mastering_discipline", discipline },
            { "professional_id", professionalCompetetion }
        };

        protected static Dictionary<string, object> GeneralSelectionFields(
            uint theme, uint selection) => new Dictionary<string, object>
        {
            { "selection_theme", theme },
            { "mastering_selection", selection }
        };

        protected static Dictionary<string, object> ProfessionalSelectionFields(
            uint theme, uint selection) => new Dictionary<string, object>
        {
            { "selection_theme", theme },
            { "mastering_selection", selection }
        };

        protected static Dictionary<string, object> LevelFields(string name,
            string description) => new Dictionary<string, object>
        {
            { "level_name", name },
            { "level_description", description }
        };
    }
}
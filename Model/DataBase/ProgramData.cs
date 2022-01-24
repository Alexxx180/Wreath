using System.Collections.Generic;

namespace Wreath.Model.DataBase
{
    /// <summary>
    /// Educational programs data from database
    /// </summary>
    public class ProgramData
    {
        public ProgramData(Sql connector)
        {
            Converters.Connect(connector);
        }

        public List<string[]> Conformity => Converters.Conformity;

        public List<string[]> Specialities => Converters.Specialities;

        public List<string[]> SpecialityCodes => Converters.SpecialityCodes;

        public List<string[]> GeneralCompetetions(uint specialityId) => Converters.GeneralCompetetions(specialityId);

        public List<string[]> ProfessionalCompetetions(uint specialityId) => Converters.ProfessionalCompetetions(specialityId);

        public List<string[]> Disciplines => Converters.Disciplines;

        public List<string[]> DisciplineCodes => Converters.DisciplineCodes;

        public List<string[]> TotalHours(uint disciplineId) => Converters.TotalHours(disciplineId);

        public List<string[]> ThemePlan(uint disciplineId) => Converters.ThemePlan(disciplineId);

        public List<string[]> Themes(uint topicId) => Converters.Themes(topicId);

        public List<string[]> Works(uint themeId) => Converters.Works(themeId);

        public List<string[]> WorkTypes => Converters.WorkTypes;

        public List<string[]> Tasks(ulong workId) => Converters.Tasks(workId);

        public List<string[]> MetaData(uint disciplineId) => Converters.MetaData(disciplineId);

        public List<string[]> MetaTypes => Converters.MetaTypes;

        public List<string[]> Sources(uint disciplineId) => Converters.Sources(disciplineId);

        public List<string[]> SourceTypes => Converters.SourceTypes;

        public List<string[]> DisciplineGeneralMastering(uint disciplineId) => Converters.DisciplineGeneralMastering(disciplineId);

        public List<string[]> DisciplineProfessionalMastering(uint disciplineId) => Converters.DisciplineProfessionalMastering(disciplineId);

        public List<string[]> ThemeGeneralMastering(uint themeId) => Converters.ThemeGeneralMastering(themeId);

        public List<string[]> ThemeProfessionalMastering(uint themeId) => Converters.ThemeProfessionalMastering(themeId);

        public List<string[]> ConformityGeneralCompetetions(uint disciplineId) => Converters.ConformityGeneralCompetetions(disciplineId);

        public List<string[]> ConformityProfessionalCompetetions(uint disciplineId) => Converters.ConformityProfessionalCompetetions(disciplineId);

        public List<string[]> DisciplineGeneralMasteringByTheme(uint themeId) => Converters.DisciplineGeneralMasteringByTheme(themeId);

        public List<string[]> DisciplineProfessionalMasteringByTheme(uint themeId) => Converters.DisciplineProfessionalMasteringByTheme(themeId);

        public List<string[]> Levels => Converters.Levels;
    }
}
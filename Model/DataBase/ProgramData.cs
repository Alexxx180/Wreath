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


        public List<string[]> MConformity => Converters.MConformity;

        public List<string[]> MSpecialities => Converters.MSpecialities;

        public List<string[]> MSpecialityCodes => Converters.MSpecialityCodes;

        public List<string[]> MGeneralCompetetions(uint specialityId) => Converters.MGeneralCompetetions(specialityId);

        public List<string[]> MProfessionalCompetetions(uint specialityId) => Converters.MProfessionalCompetetions(specialityId);

        public List<string[]> MDisciplines => Converters.MDisciplines;

        public List<string[]> MDisciplineCodes => Converters.MDisciplineCodes;

        public List<string[]> MTotalHours(uint disciplineId) => Converters.MTotalHours(disciplineId);

        public List<string[]> MThemePlan(uint disciplineId) => Converters.MThemePlan(disciplineId);

        public List<string[]> MThemes(uint topicId) => Converters.MThemes(topicId);

        public List<string[]> MWorks(uint themeId) => Converters.MWorks(themeId);

        public List<string[]> MWorkTypes => Converters.MWorkTypes;

        public List<string[]> MTasks(ulong workId) => Converters.MTasks(workId);

        public List<string[]> MMetaData(uint disciplineId) => Converters.MMetaData(disciplineId);

        public List<string[]> MMetaTypes => Converters.MMetaTypes;

        public List<string[]> MSources(uint disciplineId) => Converters.MSources(disciplineId);

        public List<string[]> MSourceTypes => Converters.MSourceTypes;

        public List<string[]> MDisciplineGeneralMastering(uint disciplineId) => Converters.MDisciplineGeneralMastering(disciplineId);

        public List<string[]> MDisciplineProfessionalMastering(uint disciplineId) => Converters.MDisciplineProfessionalMastering(disciplineId);

        public List<string[]> MThemeGeneralMastering(uint themeId) => Converters.MThemeGeneralMastering(themeId);

        public List<string[]> MThemeProfessionalMastering(uint themeId) => Converters.MThemeProfessionalMastering(themeId);

        public List<string[]> MConformityGeneralCompetetions(uint disciplineId) => Converters.MConformityGeneralCompetetions(disciplineId);

        public List<string[]> MConformityProfessionalCompetetions(uint disciplineId) => Converters.MConformityProfessionalCompetetions(disciplineId);

        public List<string[]> MDisciplineGeneralMasteringByTheme(uint themeId) => Converters.MDisciplineGeneralMasteringByTheme(themeId);

        public List<string[]> MDisciplineProfessionalMasteringByTheme(uint themeId) => Converters.MDisciplineProfessionalMasteringByTheme(themeId);

        public List<string[]> MLevels => Converters.MLevels;
    }
}
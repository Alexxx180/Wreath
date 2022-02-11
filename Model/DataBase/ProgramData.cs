using System.Collections.Generic;
using static Wreath.Model.DataBase.Converters;

namespace Wreath.Model.DataBase
{
    /// <summary>
    /// Educational programs data from database
    /// </summary>
    public class ProgramData
    {
        public ProgramData(Sql connector)
        {
            _dataBase = connector;
        }

        public List<string[]> Conformity => ConvertAll(_dataBase.ConformityList(), ElementsToString);

        public List<string[]> Specialities => ConvertAll(_dataBase.SpecialitiesList(), ElementsToString);

        public List<string[]> SpecialityCodes => ConvertAll(_dataBase.SpecialityCodes(), ElementsToString);

        public List<string[]> GeneralCompetetions(uint specialityId)
        {
            return ConvertAll(_dataBase.GeneralCompetetions(specialityId), ElementsToString);
        }

        public List<string[]> ProfessionalCompetetions(uint specialityId)
        {
            return ConvertAll(_dataBase.ProfessionalCompetetions(specialityId), ElementsToString);
        }

        public List<string[]> Disciplines => ConvertAll(_dataBase.DisciplinesList(), ElementsToString);

        public List<string[]> DisciplineCodes => ConvertAll(_dataBase.DisciplineCodes(), ElementsToString);

        public List<string[]> TotalHours(uint disciplineId)
        {
            return ConvertAll(_dataBase.TotalHours(disciplineId), ElementsToString);
        }

        public List<string[]> ThemePlan(uint disciplineId)
        {
            return ConvertAll(_dataBase.ThemePlan(disciplineId), ElementsToString);
        }

        public List<string[]> Themes(uint topicId)
        {
            return ConvertAll(_dataBase.Themes(topicId), ElementsToString);
        }

        public List<string[]> Works(uint themeId)
        {
            return ConvertAll(_dataBase.Works(themeId), ElementsToString);
        }

        public List<string[]> WorkTypes => ConvertAll(_dataBase.WorkTypes(), ElementsToString);

        public List<string[]> Tasks(ulong workId)
        {
            return ConvertAll(_dataBase.Tasks(workId), ElementsToString);
        }

        public List<string[]> MetaData(uint disciplineId)
        {
            return ConvertAll(_dataBase.MetaData(disciplineId), ElementsToString);
        }

        public List<string[]> MetaTypes => ConvertAll(_dataBase.MetaTypes(), ElementsToString);

        public List<string[]> Sources(uint disciplineId)
        {
            return ConvertAll(_dataBase.Sources(disciplineId), ElementsToString);
        }

        public List<string[]> SourceTypes => ConvertAll(_dataBase.SourceTypes(), ElementsToString);

        public List<string[]> DisciplineGeneralMastering(uint disciplineId)
        {
            return ConvertAll(_dataBase.DisciplineGeneralMastering(disciplineId), ElementsToString);
        }

        public List<string[]> DisciplineProfessionalMastering(uint disciplineId)
        {
            return ConvertAll(_dataBase.DisciplineProfessionalMastering(disciplineId), ElementsToString);
        }

        public List<string[]> ThemeGeneralMastering(uint themeId)
        {
            return ConvertAll(_dataBase.ThemeGeneralMastering(themeId), ElementsToString);
        }

        public List<string[]> ThemeProfessionalMastering(uint themeId)
        {
            return ConvertAll(_dataBase.ThemeProfessionalMastering(themeId), ElementsToString);
        }

        public List<string[]> Levels => ConvertAll(_dataBase.Levels(), ElementsToString);

        public List<string[]> ConformityGeneralCompetetions(uint disciplineId)
        {
            return ConvertAll(_dataBase.ConformityGeneralCompetetions(disciplineId), ElementsToString);
        }

        public List<string[]> ConformityProfessionalCompetetions(uint disciplineId)
        {
            return ConvertAll(_dataBase.ConformityProfessionalCompetetions(disciplineId), ElementsToString);
        }

        public List<string[]> DisciplineGeneralMasteringByTheme(uint themeId)
        {
            return ConvertAll(_dataBase.DisciplineGeneralMasteringByTheme(themeId), ElementsToString);
        }

        public List<string[]> DisciplineProfessionalMasteringByTheme(uint themeId)
        {
            return ConvertAll(_dataBase.DisciplineProfessionalMasteringByTheme(themeId), ElementsToString);
        }

        public List<string[]> MConformity => ConvertAll(_dataBase.MConformityList(), ElementsToString);

        public List<string[]> MSpecialities => ConvertAll(_dataBase.MSpecialitiesList(), ElementsToString);

        public List<string[]> MSpecialityCodes => ConvertAll(_dataBase.MSpecialityCodes(), ElementsToString);

        public List<string[]> MGeneralCompetetions(uint specialityId)
        {
            return ConvertAll(_dataBase.MGeneralCompetetions(specialityId), ElementsToString);
        }

        public List<string[]> MProfessionalCompetetions(uint specialityId)
        {
            return ConvertAll(_dataBase.MProfessionalCompetetions(specialityId), ElementsToString);
        }

        public List<string[]> MDisciplines => ConvertAll(_dataBase.MDisciplinesList(), ElementsToString);

        public List<string[]> MDisciplineCodes => ConvertAll(_dataBase.MDisciplineCodes(), ElementsToString);

        public List<string[]> MTotalHours(uint disciplineId)
        {
            return ConvertAll(_dataBase.MTotalHours(disciplineId), ElementsToString);
        }

        public List<string[]> MThemePlan(uint disciplineId)
        {
            return ConvertAll(_dataBase.MThemePlan(disciplineId), ElementsToString);
        }

        public List<string[]> MThemes(uint topicId)
        {
            return ConvertAll(_dataBase.MThemes(topicId), ElementsToString);
        }

        public List<string[]> MWorks(uint themeId)
        {
            return ConvertAll(_dataBase.MWorks(themeId), ElementsToString);
        }

        public List<string[]> MWorkTypes => ConvertAll(_dataBase.MWorkTypes(), ElementsToString);

        public List<string[]> MTasks(ulong workId)
        {
            return ConvertAll(_dataBase.MTasks(workId), ElementsToString);
        }

        public List<string[]> MMetaData(uint disciplineId)
        {
            return ConvertAll(_dataBase.MMetaData(disciplineId), ElementsToString);
        }

        public List<string[]> MMetaTypes => ConvertAll(_dataBase.MMetaTypes(), ElementsToString);

        public List<string[]> MSources(uint disciplineId)
        {
            return ConvertAll(_dataBase.MSources(disciplineId), ElementsToString);
        }

        public List<string[]> MSourceTypes => ConvertAll(_dataBase.MSourceTypes(), ElementsToString);

        public List<string[]> MDisciplineGeneralMastering(uint disciplineId)
        {
            return ConvertAll(_dataBase.MDisciplineGeneralMastering(disciplineId), ElementsToString);
        }

        public List<string[]> MDisciplineProfessionalMastering(uint disciplineId)
        {
            return ConvertAll(_dataBase.MDisciplineProfessionalMastering(disciplineId), ElementsToString);
        }

        public List<string[]> MThemeGeneralMastering(uint themeId)
        {
            return ConvertAll(_dataBase.MThemeGeneralMastering(themeId), ElementsToString);
        }

        public List<string[]> MThemeProfessionalMastering(uint themeId)
        {
            return ConvertAll(_dataBase.MThemeProfessionalMastering(themeId), ElementsToString);
        }

        public List<string[]> MLevels => ConvertAll(_dataBase.MLevels(), ElementsToString);

        public List<string[]> MConformityGeneralCompetetions(uint disciplineId)
        {
            return ConvertAll(_dataBase.MConformityGeneralCompetetions(disciplineId), ElementsToString);
        }

        public List<string[]> MConformityProfessionalCompetetions(uint disciplineId)
        {
            return ConvertAll(_dataBase.MConformityProfessionalCompetetions(disciplineId), ElementsToString);
        }

        public List<string[]> MDisciplineGeneralMasteringByTheme(uint themeId)
        {
            return ConvertAll(_dataBase.MDisciplineGeneralMasteringByTheme(themeId), ElementsToString);
        }

        public List<string[]> MDisciplineProfessionalMasteringByTheme(uint themeId)
        {
            return ConvertAll(_dataBase.MDisciplineProfessionalMasteringByTheme(themeId), ElementsToString);
        }

        public List<string> SpecialityMarkedRowsAnalyze(uint disciplineId)
        {
            return ConvertAll(_dataBase.SpecialityMarkedRowsAnalyze(disciplineId), ElementToString);
        }

        public List<string> DisciplineMarkedRowsAnalyze(uint disciplineId)
        {
            return ConvertAll(_dataBase.DisciplineMarkedRowsAnalyze(disciplineId), ElementToString);
        }

        public List<string> TopicMarkedRowsAnalyze(uint themeId)
        {
            return ConvertAll(_dataBase.TopicMarkedRowsAnalyze(themeId), ElementToString);
        }

        public List<string> ThemeMarkedRowsAnalyze(uint themeId)
        {
            return ConvertAll(_dataBase.ThemeMarkedRowsAnalyze(themeId), ElementToString);
        }

        // Overall tables: 22
        private readonly IDataViewer _dataBase;
    }
}
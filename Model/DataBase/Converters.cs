using System;
using System.Collections.Generic;

namespace Wreath.Model.DataBase
{
    /// <summary>
    /// Converters used for converting database objects to string fields
    /// </summary>
    public static class Converters
    {
        public static void Connect(Sql connector)
        {
            _dataBase = connector;
        }

        public static TOutput[] ConvertAll<TInput, TOutput>(TInput[] array, Func<TInput, TOutput> converter)
        {
            TOutput[] result = new TOutput[array.Length];
            for (int i = 0; i < array.Length; i++)
                result[i] = converter(array[i]);
            return result;
        }

        public static List<TOutput> ConvertAll<TInput, TOutput>(List<TInput> list, Func<TInput, TOutput> converter)
        {
            List<TOutput> result = new List<TOutput>();
            for (int i = 0; i < list.Count; i++)
                result.Add(converter(list[i]));
            return result;
        }

        private static string ElementToString(object value) => value.ToString();
        private static string[] ElementsToString(object[] values) => ConvertAll(values, ElementToString);

        // Overall tables: 22

        public static List<string[]> Conformity => ConvertAll(_dataBase.ConformityList(), ElementsToString);

        public static List<string[]> Specialities => ConvertAll(_dataBase.SpecialitiesList(), ElementsToString);

        public static List<string[]> SpecialityCodes => ConvertAll(_dataBase.SpecialityCodes(), ElementsToString);

        public static List<string[]> GeneralCompetetions(uint specialityId) => ConvertAll(_dataBase.GeneralCompetetions(specialityId), ElementsToString);

        public static List<string[]> ProfessionalCompetetions(uint specialityId) => ConvertAll(_dataBase.ProfessionalCompetetions(specialityId), ElementsToString);

        public static List<string[]> Disciplines => ConvertAll(_dataBase.DisciplinesList(), ElementsToString);

        public static List<string[]> DisciplineCodes => ConvertAll(_dataBase.DisciplineCodes(), ElementsToString);

        public static List<string[]> TotalHours(uint disciplineId) => ConvertAll(_dataBase.TotalHours(disciplineId), ElementsToString);

        public static List<string[]> ThemePlan(uint disciplineId) => ConvertAll(_dataBase.ThemePlan(disciplineId), ElementsToString);

        public static List<string[]> Themes(uint topicId) => ConvertAll(_dataBase.Themes(topicId), ElementsToString);

        public static List<string[]> Works(uint themeId) => ConvertAll(_dataBase.Works(themeId), ElementsToString);

        public static List<string[]> WorkTypes => ConvertAll(_dataBase.WorkTypes(), ElementsToString);

        public static List<string[]> Tasks(ulong workId) => ConvertAll(_dataBase.Tasks(workId), ElementsToString);

        public static List<string[]> MetaData(uint disciplineId) => ConvertAll(_dataBase.MetaData(disciplineId), ElementsToString);

        public static List<string[]> MetaTypes => ConvertAll(_dataBase.MetaTypes(), ElementsToString);

        public static List<string[]> Sources(uint disciplineId) => ConvertAll(_dataBase.Sources(disciplineId), ElementsToString);

        public static List<string[]> SourceTypes => ConvertAll(_dataBase.SourceTypes(), ElementsToString);

        public static List<string[]> DisciplineGeneralMastering(uint disciplineId) => ConvertAll(_dataBase.DisciplineGeneralMastering(disciplineId), ElementsToString);

        public static List<string[]> DisciplineProfessionalMastering(uint disciplineId) => ConvertAll(_dataBase.DisciplineProfessionalMastering(disciplineId), ElementsToString);

        public static List<string[]> ThemeGeneralMastering(uint themeId) => ConvertAll(_dataBase.ThemeGeneralMastering(themeId), ElementsToString);

        public static List<string[]> ThemeProfessionalMastering(uint themeId) => ConvertAll(_dataBase.ThemeProfessionalMastering(themeId), ElementsToString);

        public static List<string[]> Levels => ConvertAll(_dataBase.Levels(), ElementsToString);

        public static List<string[]> ConformityGeneralCompetetions(uint disciplineId) => ConvertAll(_dataBase.ConformityGeneralCompetetions(disciplineId), ElementsToString);

        public static List<string[]> ConformityProfessionalCompetetions(uint disciplineId) => ConvertAll(_dataBase.ConformityProfessionalCompetetions(disciplineId), ElementsToString);

        public static List<string[]> DisciplineGeneralMasteringByTheme(uint themeId) => ConvertAll(_dataBase.DisciplineGeneralMasteringByTheme(themeId), ElementsToString);

        public static List<string[]> DisciplineProfessionalMasteringByTheme(uint themeId) => ConvertAll(_dataBase.DisciplineProfessionalMasteringByTheme(themeId), ElementsToString);


        public static List<string[]> MConformity => ConvertAll(_dataBase.MConformityList(), ElementsToString);

        public static List<string[]> MSpecialities => ConvertAll(_dataBase.MSpecialitiesList(), ElementsToString);

        public static List<string[]> MSpecialityCodes => ConvertAll(_dataBase.MSpecialityCodes(), ElementsToString);

        public static List<string[]> MGeneralCompetetions(uint specialityId) => ConvertAll(_dataBase.MGeneralCompetetions(specialityId), ElementsToString);

        public static List<string[]> MProfessionalCompetetions(uint specialityId) => ConvertAll(_dataBase.MProfessionalCompetetions(specialityId), ElementsToString);

        public static List<string[]> MDisciplines => ConvertAll(_dataBase.MDisciplinesList(), ElementsToString);

        public static List<string[]> MDisciplineCodes => ConvertAll(_dataBase.MDisciplineCodes(), ElementsToString);

        public static List<string[]> MTotalHours(uint disciplineId) => ConvertAll(_dataBase.MTotalHours(disciplineId), ElementsToString);

        public static List<string[]> MThemePlan(uint disciplineId) => ConvertAll(_dataBase.MThemePlan(disciplineId), ElementsToString);

        public static List<string[]> MThemes(uint topicId) => ConvertAll(_dataBase.MThemes(topicId), ElementsToString);

        public static List<string[]> MWorks(uint themeId) => ConvertAll(_dataBase.MWorks(themeId), ElementsToString);

        public static List<string[]> MWorkTypes => ConvertAll(_dataBase.MWorkTypes(), ElementsToString);

        public static List<string[]> MTasks(ulong workId) => ConvertAll(_dataBase.MTasks(workId), ElementsToString);

        public static List<string[]> MMetaData(uint disciplineId) => ConvertAll(_dataBase.MMetaData(disciplineId), ElementsToString);

        public static List<string[]> MMetaTypes => ConvertAll(_dataBase.MMetaTypes(), ElementsToString);

        public static List<string[]> MSources(uint disciplineId) => ConvertAll(_dataBase.MSources(disciplineId), ElementsToString);

        public static List<string[]> MSourceTypes => ConvertAll(_dataBase.MSourceTypes(), ElementsToString);

        public static List<string[]> MDisciplineGeneralMastering(uint disciplineId) => ConvertAll(_dataBase.MDisciplineGeneralMastering(disciplineId), ElementsToString);

        public static List<string[]> MDisciplineProfessionalMastering(uint disciplineId) => ConvertAll(_dataBase.MDisciplineProfessionalMastering(disciplineId), ElementsToString);

        public static List<string[]> MThemeGeneralMastering(uint themeId) => ConvertAll(_dataBase.MThemeGeneralMastering(themeId), ElementsToString);

        public static List<string[]> MThemeProfessionalMastering(uint themeId) => ConvertAll(_dataBase.MThemeProfessionalMastering(themeId), ElementsToString);

        public static List<string[]> MLevels => ConvertAll(_dataBase.MLevels(), ElementsToString);

        public static List<string[]> MConformityGeneralCompetetions(uint disciplineId) => ConvertAll(_dataBase.MConformityGeneralCompetetions(disciplineId), ElementsToString);

        public static List<string[]> MConformityProfessionalCompetetions(uint disciplineId) => ConvertAll(_dataBase.MConformityProfessionalCompetetions(disciplineId), ElementsToString);

        public static List<string[]> MDisciplineGeneralMasteringByTheme(uint themeId) => ConvertAll(_dataBase.MDisciplineGeneralMasteringByTheme(themeId), ElementsToString);

        public static List<string[]> MDisciplineProfessionalMasteringByTheme(uint themeId) => ConvertAll(_dataBase.MDisciplineProfessionalMasteringByTheme(themeId), ElementsToString);

        private static IDataViewer _dataBase;
    }
}
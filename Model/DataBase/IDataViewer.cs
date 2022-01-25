using System.Collections.Generic;

namespace Wreath.Model.DataBase
{
    public interface IDataViewer
    {
        public List<object[]> ConformityList();

        public List<object[]> SpecialitiesList();

        public List<object[]> SpecialityCodes();

        public List<object[]> GeneralCompetetions(uint value);

        public List<object[]> ProfessionalCompetetions(uint value);

        public List<object[]> DisciplinesList();

        public List<object[]> DisciplineCodes();

        public List<object[]> TotalHours(uint value);

        public List<object[]> ThemePlan(uint value);

        public List<object[]> Themes(uint value);

        public List<object[]> Works(uint value);

        public List<object[]> WorkTypes();

        public List<object[]> Tasks(ulong value);

        public List<object[]> MetaData(uint value);

        public List<object[]> MetaTypes();

        public List<object[]> Sources(uint value);

        public List<object[]> SourceTypes();

        public List<object[]> DisciplineGeneralMastering(uint value);

        public List<object[]> DisciplineProfessionalMastering(uint value);

        public List<object[]> ThemeGeneralMastering(uint value);

        public List<object[]> ThemeProfessionalMastering(uint value);

        public List<object[]> Levels();

        public List<object[]> ConformityGeneralCompetetions(uint value);

        public List<object[]> ConformityProfessionalCompetetions(uint value);

        public List<object[]> DisciplineGeneralMasteringByTheme(uint value);

        public List<object[]> DisciplineProfessionalMasteringByTheme(uint value);


        public List<object[]> MConformityList();

        public List<object[]> MSpecialitiesList();

        public List<object[]> MSpecialityCodes();

        public List<object[]> MGeneralCompetetions(uint value);

        public List<object[]> MProfessionalCompetetions(uint value);

        public List<object[]> MDisciplinesList();

        public List<object[]> MDisciplineCodes();

        public List<object[]> MTotalHours(uint value);

        public List<object[]> MThemePlan(uint value);

        public List<object[]> MThemes(uint value);

        public List<object[]> MWorks(uint value);

        public List<object[]> MWorkTypes();

        public List<object[]> MTasks(ulong value);

        public List<object[]> MMetaData(uint value);

        public List<object[]> MMetaTypes();

        public List<object[]> MSources(uint value);

        public List<object[]> MSourceTypes();

        public List<object[]> MDisciplineGeneralMastering(uint value);

        public List<object[]> MDisciplineProfessionalMastering(uint value);

        public List<object[]> MThemeGeneralMastering(uint value);

        public List<object[]> MThemeProfessionalMastering(uint value);

        public List<object[]> MLevels();

        public List<object[]> MConformityGeneralCompetetions(uint value);

        public List<object[]> MConformityProfessionalCompetetions(uint value);

        public List<object[]> MDisciplineGeneralMasteringByTheme(uint value);

        public List<object[]> MDisciplineProfessionalMasteringByTheme(uint value);
    }
}
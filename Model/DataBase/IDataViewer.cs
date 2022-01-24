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
    }
}
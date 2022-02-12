namespace Wreath.Model.Tools
{
    internal interface ISizeScaler
    {
        public void IncreaseDisciplinesName(ushort value);

        public void IncreaseDisciplineCodesCode(ushort value);

        public void IncreaseGeneralCompetetionsKnowledge(ushort value);

        public void IncreaseGeneralCompetetionsName(ushort value);

        public void IncreaseGeneralCompetetionsSkills(ushort value);

        public void IncreaseLevelsDescription(ushort value);

        public void IncreaseLevelsName(ushort value);

        public void IncreaseMetaDataName(ushort value);

        public void IncreaseMetaTypesName(ushort value);

        public void IncreaseProfessionalCompetetionsExperience(ushort value);

        public void IncreaseProfessionalCompetetionsKnowledge(ushort value);

        public void IncreaseProfessionalCompetetionsName(ushort value);

        public void IncreaseProfessionalCompetetionsSkills(ushort value);

        public void IncreaseSourcesName(ushort value);

        public void IncreaseSourceTypesName(ushort value);

        public void IncreaseSpecialitiesName(ushort value);

        public void IncreaseSpecialityCodesCode(ushort value);

        public void IncreaseTasksName(ushort value);

        public void IncreaseThemesName(ushort value);

        public void IncreaseThemePlanName(ushort value);

        public void IncreaseWorkTypesName(ushort value);

        public delegate void ColumnSizeIncrease(ushort value);

        public object CheckDisciplinesName();

        public object CheckDisciplineCodesCode();

        public object CheckGeneralCompetetionsKnowledge();

        public object CheckGeneralCompetetionsName();

        public object CheckGeneralCompetetionsSkills();

        public object CheckLevelsDescription();

        public object CheckLevelsName();

        public object CheckMetaDataName();

        public object CheckMetaTypesName();

        public object CheckProfessionalCompetetionsExperience();

        public object CheckProfessionalCompetetionsKnowledge();

        public object CheckProfessionalCompetetionsName();

        public object CheckProfessionalCompetetionsSkills();

        public object CheckSourcesName();

        public object CheckSourceTypesName();

        public object CheckSpecialitiesName();

        public object CheckSpecialityCodesCode();

        public object CheckTasksName();

        public object CheckThemesName();

        public object CheckThemePlanName();

        public object CheckWorkTypesName();
        
        public delegate object CheckForDefaultSize();
    }
}
﻿using System;
using System.Windows;
using System.Collections.Generic;
using Serilog;

namespace Wreath.Model.Tools.DataBase
{
    /// <summary>
    /// Class containing necessary methods to work with database
    /// </summary>
    public abstract class Sql : IDataViewer, IDataAdministrator, ISizeScaler, IRolesAdministrating
    {
        #region Configuration Members
        public bool IndependentMode { get; set; }

        internal abstract void SetConfiguration(in string dbName, in string host);

        public abstract bool TestConnection(in string login, in string pass);

        internal abstract bool Connect();
        #endregion

        #region WorkWithParameters Members
        public abstract void PassParameter(in string ParamName, in object newParam);

        public void PassParameters(Dictionary<string, object> parameters)
        {
            foreach (KeyValuePair<string, object> entry in parameters)
                PassParameter(entry.Key, entry.Value);
        }

        public abstract void ClearParameters();
        #endregion

        #region ProcedureExecuteOnly Members
        public abstract void OnlyExecute();

        public abstract void Procedure(in string name);

        public void ExecuteProcedure(string name)
        {
            Procedure(name);
            OnlyExecute();
        }

        public void ExecuteProcedure
            (string name, string paramName, object value)
        {
            Procedure(name);
            PassParameter(paramName, value);
            OnlyExecute();
            ClearParameters();
        }

        public void ExecuteProcedure
            (string name, Dictionary<string, object> parameters)
        {
            Procedure(name);
            PassParameters(parameters);
            OnlyExecute();
            ClearParameters();
        }
        #endregion

        #region ReadRecords Members
        public abstract object ReadScalar();

        public abstract List<object[]> ReadData();

        public abstract List<object> ReadData(in int column);

        public abstract List<object[]> ReadData(in byte StartValue, in byte EndValue);

        public object GetRecord(string name)
        {
            Procedure(name);
            return ReadScalar();
        }

        public object GetRecord(string name,
            string paramName, object value)
        {
            Procedure(name);
            PassParameter(paramName, value);
            object field = ReadScalar();
            ClearParameters();
            return field;
        }

        public List<object> GetRecords
            (string name, in int column)
        {
            Procedure(name);
            List<object> records = ReadData(column);
            return records;
        }

        public List<object> GetRecords(
            string name, string paramName,
            object value, in int column)
        {
            Procedure(name);
            PassParameter(paramName, value);
            List<object> records = ReadData(column);
            ClearParameters();
            return records;
        }

        public List<object[]> GetRecords(string name)
        {
            Procedure(name);
            List<object[]> records = ReadData();
            ClearParameters();
            return records;
        }

        public List<object[]> GetRecords
            (string name, string paramName, object value)
        {
            Procedure(name);
            PassParameter(paramName, value);
            List<object[]> records = ReadData();
            ClearParameters();
            return records;
        }

        public List<object[]> GetRecords(string name,
            Dictionary<string, object> parameters)
        {
            Procedure(name);
            PassParameters(parameters);
            List<object[]> records = ReadData();
            ClearParameters();
            return records;
        }
        #endregion



        #region GetUnmarkedRecords Members
        public List<object[]> ConformityList()
        {
            return GetRecords("get_conformity_full_unmarked");
        }

        // Specialities
        public List<object[]> SpecialitiesList()
        {
            return GetRecords("get_specialities_unmarked");
        }

        public List<object[]> SpecialityCodes()
        {
            return GetRecords("get_speciality_codes_unmarked");
        }

        public List<object[]> GeneralCompetetions(uint value)
        {
            return GetRecords("get_speciality_general_unmarked", "speciality_id", value);
        }

        public List<object[]> ProfessionalCompetetions(uint value)
        {
            return GetRecords("get_speciality_professional_unmarked", "speciality_id", value);
        }

        // Disciplines
        public List<object[]> DisciplinesList()
        {
            return GetRecords("get_disciplines_unmarked");
        }

        public List<object[]> DisciplineCodes()
        {
            return GetRecords("get_discipline_codes_unmarked");
        }

        public List<object[]> TotalHours(uint value)
        {
            return GetRecords("get_discipline_total_hours_unmarked", "discipline_id", value);
        }

        public List<object[]> ThemePlan(uint value)
        {
            return GetRecords("get_theme_plan_by_discipline_unmarked", "discipline_id", value);
        }

        public List<object[]> Themes(uint value)
        {
            return GetRecords("get_themes_by_section_unmarked", "section_id", value);
        }

        public List<object[]> Works(uint value)
        {
            return GetRecords("get_work_by_theme_unmarked", "theme_id", value);
        }

        public List<object[]> WorkTypes()
        {
            return GetRecords("get_work_types_unmarked");
        }

        public List<object[]> Tasks(ulong value)
        {
            return GetRecords("get_task_by_work_unmarked", "work_id", value);
        }

        public List<object[]> MetaData(uint value)
        {
            return GetRecords("get_discipline_meta_data_unmarked", "discipline_id", value);
        }

        public List<object[]> MetaTypes()
        {
            return GetRecords("get_meta_types_unmarked");
        }

        public List<object[]> Sources(uint value)
        {
            return GetRecords("get_discipline_sources_unmarked", "discipline_id", value);
        }

        public List<object[]> SourceTypes()
        {
            return GetRecords("get_source_types_unmarked");
        }

        public List<object[]> DisciplineGeneralMastering(uint value)
        {
            return GetRecords("get_discipline_general_mastering_unmarked", "discipline_id", value);
        }

        public List<object[]> DisciplineProfessionalMastering(uint value)
        {
            return GetRecords("get_discipline_professional_mastering_unmarked", "discipline_id", value);
        }

        public List<object[]> ThemeGeneralMastering(uint value)
        {
            return GetRecords("get_theme_general_mastering_selection_unmarked", "theme_id", value);
        }

        public List<object[]> ThemeProfessionalMastering(uint value)
        {
            return GetRecords("get_theme_professional_mastering_selection_unmarked", "theme_id", value);
        }

        public List<object[]> Levels()
        {
            return GetRecords("get_all_levels_unmarked");
        }


        public List<object[]> ConformityGeneralCompetetions(uint value)
        {
            return GetRecords("get_conformity_general_competetions_unmarked", "discipline_id", value);
        }

        public List<object[]> ConformityProfessionalCompetetions(uint value)
        {
            return GetRecords("get_conformity_professional_competetions_unmarked", "discipline_id", value);
        }

        public object DisciplineByTheme(uint value)
        {
            return GetRecord("get_discipline_by_theme", "theme_id", value);
        }
        #endregion

        #region GetMarkedRows Members
        public List<object[]> MConformityList()
        {
            return GetRecords("get_conformity_full_marked");
        }

        // Specialities
        public List<object[]> MSpecialitiesList()
        {
            return GetRecords("get_specialities_marked");
        }

        public List<object[]> MSpecialityCodes()
        {
            return GetRecords("get_speciality_codes_marked");
        }

        public List<object[]> MGeneralCompetetions(uint value)
        {
            return GetRecords("get_speciality_general_marked", "speciality_id", value);
        }

        public List<object[]> MProfessionalCompetetions(uint value)
        {
            return GetRecords("get_speciality_professional_marked", "speciality_id", value);
        }

        // Disciplines
        public List<object[]> MDisciplinesList()
        {
            return GetRecords("get_disciplines_marked");
        }

        public List<object[]> MDisciplineCodes()
        {
            return GetRecords("get_discipline_codes_marked");
        }

        public List<object[]> MTotalHours(uint value)
        {
            return GetRecords("get_discipline_total_hours_marked", "discipline_id", value);
        }

        public List<object[]> MThemePlan(uint value)
        {
            return GetRecords("get_theme_plan_by_discipline_marked", "discipline_id", value);
        }

        public List<object[]> MThemes(uint value)
        {
            return GetRecords("get_themes_by_section_marked", "section_id", value);
        }

        public List<object[]> MWorks(uint value)
        {
            return GetRecords("get_work_by_theme_marked", "theme_id", value);
        }

        public List<object[]> MWorkTypes()
        {
            return GetRecords("get_work_types_marked");
        }

        public List<object[]> MTasks(ulong value)
        {
            return GetRecords("get_task_by_work_marked", "work_id", value);
        }

        public List<object[]> MMetaData(uint value)
        {
            return GetRecords("get_discipline_meta_data_marked", "discipline_id", value);
        }

        public List<object[]> MMetaTypes()
        {
            return GetRecords("get_meta_types_marked");
        }

        public List<object[]> MSources(uint value)
        {
            return GetRecords("get_discipline_sources_marked", "discipline_id", value);
        }

        public List<object[]> MSourceTypes()
        {
            return GetRecords("get_source_types_marked");
        }

        public List<object[]> MDisciplineGeneralMastering(uint value)
        {
            return GetRecords("get_discipline_general_mastering_marked", "discipline_id", value);
        }

        public List<object[]> MDisciplineProfessionalMastering(uint value)
        {
            return GetRecords("get_discipline_professional_mastering_marked", "discipline_id", value);
        }

        public List<object[]> MThemeGeneralMastering(uint value)
        {
            return GetRecords("get_theme_general_mastering_selection_marked", "theme_id", value);
        }

        public List<object[]> MThemeProfessionalMastering(uint value)
        {
            return GetRecords("get_theme_professional_mastering_selection_marked", "theme_id", value);
        }

        public List<object[]> MLevels()
        {
            return GetRecords("get_all_levels_marked");
        }


        public List<object[]> MConformityGeneralCompetetions(uint value)
        {
            return GetRecords("get_conformity_general_competetions_marked", "discipline_id", value);
        }

        public List<object[]> MConformityProfessionalCompetetions(uint value)
        {
            return GetRecords("get_conformity_professional_competetions_marked", "discipline_id", value);
        }

        // Data analyze methods - analyzer feature

        public List<object> SpecialityMarkedRowsAnalyze(uint value)
        {
            return GetRecords("analyze_speciality", "speciality_id", value, 0);
        }

        public List<object> DisciplineMarkedRowsAnalyze(uint value)
        {
            return GetRecords("analyze_discipline", "discipline_id", value, 0);
        }

        public List<object> TopicMarkedRowsAnalyze(uint value)
        {
            return GetRecords("analyze_topic", "topic_id", value, 0);
        }

        public List<object> ThemeMarkedRowsAnalyze(uint value)
        {
            return GetRecords("analyze_theme", "theme_id", value, 0);
        }
        #endregion

        #region UsedTypeLikeRecordsCount Members
        private object UsedWorkType(ulong value)
        {
            return GetRecord("get_work_type_linked", "type_id", value);
        }

        private object UsedMetaType(ulong value)
        {
            return GetRecord("get_meta_type_linked", "type_id", value);
        }

        private object UsedSourceType(ulong value)
        {
            return GetRecord("get_source_type_linked", "type_id", value);
        }

        private object UsedLevel(ulong value)
        {
            return GetRecord("get_level_linked", "level_id", value);
        }

        private object UsedDisciplineCode(ulong value)
        {
            return GetRecord("get_discipline_linked", "code_id", value);
        }

        private object UsedSpecialityCode(ulong value)
        {
            return GetRecord("get_discipline_linked", "code_id", value);
        }
        #endregion


        #region UnmarkRow Members
        public void UnMarkConformity(ulong value)
        {
            ExecuteProcedure("unmark_conformity", "conformity_id", value);
        }

        // Specialities
        public void UnMarkSpeciality(ulong value)
        {
            ExecuteProcedure("unmark_speciality", "speciality_id", value);
        }

        public void UnMarkSpecialityCode(ulong value)
        {
            ExecuteProcedure("unmark_speciality_code", "code_id", value);
        }

        public void UnMarkGeneralCompetetion(ulong value)
        {
            ExecuteProcedure("unmark_general_competetion", "comp_id", value);
        }

        public void UnMarkProfessionalCompetetion(ulong value)
        {
            ExecuteProcedure("unmark_professional_competetion", "comp_id", value);
        }

        // Disciplines
        public void UnMarkDiscipline(ulong value)
        {
            ExecuteProcedure("unmark_discipline", "discipline_id", value);
        }

        public void UnMarkDisciplineCode(ulong value)
        {
            ExecuteProcedure("unmark_discipline_code", "code_id", value);
        }

        public void UnMarkTotalHour(ulong value)
        {
            ExecuteProcedure("unmark_hour", "hour_id", value);
        }

        public void UnMarkTopic(ulong value)
        {
            ExecuteProcedure("unmark_section", "section_id", value);
        }

        public void UnMarkTheme(ulong value)
        {
            ExecuteProcedure("unmark_theme", "theme_id", value);
        }

        public void UnMarkWork(ulong value)
        {
            ExecuteProcedure("unmark_work", "work_id", value);
        }

        public void UnMarkWorkType(ulong value)
        {
            ExecuteProcedure("unmark_work_type", "type_id", value);
        }

        public void UnMarkTask(ulong value)
        {
            ExecuteProcedure("unmark_task", "task_id", value);
        }

        public void UnMarkMetaData(ulong value)
        {
            ExecuteProcedure("unmark_meta_data", "data_id", value);
        }

        public void UnMarkMetaType(ulong value)
        {
            ExecuteProcedure("unmark_meta_type", "type_id", value);
        }

        public void UnMarkSource(ulong value)
        {
            ExecuteProcedure("unmark_source", "source_id", value);
        }

        public void UnMarkSourceType(ulong value)
        {
            ExecuteProcedure("unmark_source_type", "type_id", value);
        }

        public void UnMarkGeneralMastering(ulong value)
        {
            ExecuteProcedure("unmark_general_mastering", "mastering_id", value);
        }

        public void UnMarkProfessionalMastering(ulong value)
        {
            ExecuteProcedure("unmark_professional_mastering", "mastering_id", value);
        }

        public void UnMarkGeneralSelection(ulong value)
        {
            ExecuteProcedure("unmark_general_selection", "selection_id", value);
        }

        public void UnMarkProfessionalSelection(ulong value)
        {
            ExecuteProcedure("unmark_professional_selection", "selection_id", value);
        }

        public void UnMarkLevel(ulong value)
        {
            ExecuteProcedure("unmark_level", "level_id", value);
        }
        #endregion

        #region DropRow Members
        public void DropConformity(ulong value)
        {
            ExecuteProcedure("drop_conformity", "conformity_id", value);
        }

        // Specialities
        public void DropSpeciality(ulong value)
        {
            ExecuteProcedure("drop_speciality", "speciality_id", value);
        }

        public void DropSpecialityCode(ulong value)
        {
            if (!OperationViolated(Convert.ToUInt64(UsedSpecialityCode(value))))
                ExecuteProcedure("drop_speciality_code", "code_id", value);
        }

        public void DropGeneralCompetetion(ulong value)
        {
            ExecuteProcedure("drop_general_competetion", "comp_id", value);
        }

        public void DropProfessionalCompetetion(ulong value)
        {
            ExecuteProcedure("drop_professional_competetion", "comp_id", value);
        }

        // Disciplines
        public void DropDiscipline(ulong value)
        {
            ExecuteProcedure("drop_discipline", "discipline_id", value);
        }

        public void DropDisciplineCode(ulong value)
        {
            if (!OperationViolated(Convert.ToUInt64(UsedDisciplineCode(value))))
                ExecuteProcedure("drop_discipline_code", "code_id", value);
        }

        public void DropTotalHour(ulong value)
        {
            ExecuteProcedure("drop_hour", "hour_id", value);
        }

        public void DropTopic(ulong value)
        {
            ExecuteProcedure("drop_section", "section_id", value);
        }

        public void DropTheme(ulong value)
        {
            ExecuteProcedure("drop_theme", "theme_id", value);
        }

        public void DropWork(ulong value)
        {
            ExecuteProcedure("drop_work", "work_id", value);
        }

        public void DropWorkType(ulong value)
        {
            if (!OperationViolated(Convert.ToUInt64(UsedWorkType(value))))
                ExecuteProcedure("drop_work_type", "type_id", value);
        }

        public void DropTask(ulong value)
        {
            ExecuteProcedure("drop_task", "task_id", value);
        }

        public void DropMetaData(ulong value)
        {
            ExecuteProcedure("drop_meta_data", "data_id", value);
        }

        public void DropMetaType(ulong value)
        {
            if (!OperationViolated(Convert.ToUInt64(UsedMetaType(value))))
                ExecuteProcedure("drop_meta_type", "type_id", value);
        }

        public void DropSource(ulong value)
        {
            ExecuteProcedure("drop_source", "source_id", value);
        }

        public void DropSourceType(ulong value)
        {
            if (!OperationViolated(Convert.ToUInt64(UsedSourceType(value))))
                ExecuteProcedure("drop_source_type", "type_id", value);
        }

        public void DropGeneralMastering(ulong value)
        {
            ExecuteProcedure("drop_general_mastering", "mastering_id", value);
        }

        public void DropProfessionalMastering(ulong value)
        {
            ExecuteProcedure("drop_professional_mastering", "mastering_id", value);
        }

        public void DropGeneralSelection(ulong value)
        {
            ExecuteProcedure("drop_general_selection", "selection_id", value);
        }

        public void DropProfessionalSelection(ulong value)
        {
            ExecuteProcedure("drop_professional_selection", "selection_id", value);
        }

        public void DropLevel(ulong value)
        {
            if (!OperationViolated(Convert.ToUInt64(UsedLevel(value))))
                ExecuteProcedure("drop_level", "level_id", value);
        }
        #endregion


        #region UnmarkAllRows Members
        public void UnMarkAllConformity()
        {
            ExecuteProcedure("unmark_all_conformity");
        }

        // Specialities
        public void UnMarkAllSpecialities()
        {
            ExecuteProcedure("unmark_all_specialities");
        }

        public void UnMarkAllSpecialityCodes()
        {
            ExecuteProcedure("unmark_all_speciality_codes");
        }

        public void UnMarkAllGeneralCompetetions()
        {
            ExecuteProcedure("unmark_all_general_competetions");
        }

        public void UnMarkAllProfessionalCompetetions()
        {
            ExecuteProcedure("unmark_all_professional_competetions");
        }

        // Disciplines
        public void UnMarkAllDisciplines()
        {
            ExecuteProcedure("unmark_all_disciplines");
        }

        public void UnMarkAllDisciplineCodes()
        {
            ExecuteProcedure("unmark_all_discipline_codes");
        }

        public void UnMarkAllTotalHours()
        {
            ExecuteProcedure("unmark_all_hours");
        }

        public void UnMarkAllTopics()
        {
            ExecuteProcedure("unmark_all_sections");
        }

        public void UnMarkAllThemes()
        {
            ExecuteProcedure("unmark_all_themes");
        }

        public void UnMarkAllWorks()
        {
            ExecuteProcedure("unmark_all_works");
        }

        public void UnMarkAllWorkTypes()
        {
            ExecuteProcedure("unmark_all_work_types");
        }

        public void UnMarkAllTasks()
        {
            ExecuteProcedure("unmark_all_tasks");
        }

        public void UnMarkAllMetaData()
        {
            ExecuteProcedure("unmark_all_meta_data");
        }

        public void UnMarkAllMetaTypes()
        {
            ExecuteProcedure("unmark_all_meta_types");
        }

        public void UnMarkAllSources()
        {
            ExecuteProcedure("unmark_all_sources");
        }

        public void UnMarkAllSourceTypes()
        {
            ExecuteProcedure("unmark_all_source_types");
        }

        public void UnMarkAllGeneralMastering()
        {
            ExecuteProcedure("unmark_all_general_mastering");
        }

        public void UnMarkAllProfessionalMastering()
        {
            ExecuteProcedure("unmark_all_professional_mastering");
        }

        public void UnMarkAllGeneralSelection()
        {
            ExecuteProcedure("unmark_all_general_selection");
        }

        public void UnMarkAllProfessionalSelection()
        {
            ExecuteProcedure("unmark_all_professional_selection");
        }

        public void UnMarkAllLevels()
        {
            ExecuteProcedure("unmark_all_level");
        }
        #endregion

        #region DropAllMarkedRows Members
        public void DropAllConformity()
        {
            ExecuteProcedure("drop_all_marked_conformity");
        }

        // Specialities
        public void DropAllSpecialities()
        {
            ExecuteProcedure("drop_all_marked_specialities");
        }

        public void DropAllGeneralCompetetions()
        {
            ExecuteProcedure("drop_all_marked_general_competetions");
        }

        public void DropAllProfessionalCompetetions()
        {
            ExecuteProcedure("drop_all_marked_professional_competetions");
        }

        // Disciplines
        public void DropAllDisciplines()
        {
            ExecuteProcedure("drop_all_marked_disciplines");
        }

        public void DropAllTotalHours()
        {
            ExecuteProcedure("drop_all_marked_hours");
        }

        public void DropAllTopics()
        {
            ExecuteProcedure("drop_all_marked_sections");
        }

        public void DropAllThemes()
        {
            ExecuteProcedure("drop_all_marked_themes");
        }

        public void DropAllWorks()
        {
            ExecuteProcedure("drop_all_marked_works");
        }

        public void DropAllTasks()
        {
            ExecuteProcedure("drop_all_marked_tasks");
        }

        public void DropAllMetaData()
        {
            ExecuteProcedure("drop_all_marked_meta_data");
        }

        public void DropAllSources()
        {
            ExecuteProcedure("drop_all_marked_sources");
        }

        public void DropAllGeneralMastering()
        {
            ExecuteProcedure("drop_all_marked_general_mastering");
        }

        public void DropAllProfessionalMastering()
        {
            ExecuteProcedure("drop_all_marked_professional_mastering");
        }

        public void DropAllGeneralSelection()
        {
            ExecuteProcedure("drop_all_marked_general_selection");
        }

        public void DropAllProfessionalSelection()
        {
            ExecuteProcedure("drop_all_marked_professional_selection");
        }
        #endregion
        

        #region IncreaseColumnSize Members
        public void IncreaseDisciplinesName(ushort value)
        {
            ExecuteProcedure("increase_disciplines_name", "column_size", value);
        }

        public void IncreaseDisciplineCodesCode(ushort value)
        {
            ExecuteProcedure("increase_discipline_codes_code", "column_size", value);
        }

        public void IncreaseGeneralCompetetionsKnowledge(ushort value)
        {
            ExecuteProcedure("increase_general_competetions_knowledge", "column_size", value);
        }

        public void IncreaseGeneralCompetetionsName(ushort value)
        {
            ExecuteProcedure("increase_general_competetions_name", "column_size", value);
        }

        public void IncreaseGeneralCompetetionsSkills(ushort value)
        {
            ExecuteProcedure("increase_general_competetions_skills", "column_size", value);
        }

        public void IncreaseLevelsDescription(ushort value)
        {
            ExecuteProcedure("increase_levels_description", "column_size", value);
        }

        public void IncreaseLevelsName(ushort value)
        {
            ExecuteProcedure("increase_levels_name", "column_size", value);
        }

        public void IncreaseMetaDataName(ushort value)
        {
            ExecuteProcedure("increase_meta_data_name", "column_size", value);
        }

        public void IncreaseMetaTypesName(ushort value)
        {
            ExecuteProcedure("increase_meta_types_name", "column_size", value);
        }

        public void IncreaseProfessionalCompetetionsExperience(ushort value)
        {
            ExecuteProcedure("increase_professional_competetions_experience", "column_size", value);
        }

        public void IncreaseProfessionalCompetetionsKnowledge(ushort value)
        {
            ExecuteProcedure("increase_professional_competetions_knowledge", "column_size", value);
        }

        public void IncreaseProfessionalCompetetionsName(ushort value)
        {
            ExecuteProcedure("increase_professional_competetions_name", "column_size", value);
        }

        public void IncreaseProfessionalCompetetionsSkills(ushort value)
        {
            ExecuteProcedure("increase_professional_competetions_skills", "column_size", value);
        }

        public void IncreaseSourcesName(ushort value)
        {
            ExecuteProcedure("increase_sources_name", "column_size", value);
        }

        public void IncreaseSourceTypesName(ushort value)
        {
            ExecuteProcedure("increase_source_types_name", "column_size", value);
        }

        public void IncreaseSpecialitiesName(ushort value)
        {
            ExecuteProcedure("increase_specialities_name", "column_size", value);
        }

        public void IncreaseSpecialityCodesCode(ushort value)
        {
            ExecuteProcedure("increase_speciality_codes_code", "column_size", value);
        }

        public void IncreaseTasksName(ushort value)
        {
            ExecuteProcedure("increase_tasks_name", "column_size", value);
        }

        public void IncreaseThemesName(ushort value)
        {
            ExecuteProcedure("increase_themes_name", "column_size", value);
        }

        public void IncreaseThemePlanName(ushort value)
        {
            ExecuteProcedure("increase_theme_plan_name", "column_size", value);
        }

        public void IncreaseWorkTypesName(ushort value)
        {
            ExecuteProcedure("increase_work_types_name", "column_size", value);
        }
        #endregion

        #region CheckColumnSize Members
        public object CheckDisciplinesName()
        {
            return GetRecord("check_disciplines_name");
        }

        public object CheckDisciplineCodesCode()
        {
            return GetRecord("check_discipline_codes_code");
        }

        public object CheckGeneralCompetetionsKnowledge()
        {
            return GetRecord("check_general_competetions_knowledge");
        }

        public object CheckGeneralCompetetionsName()
        {
            return GetRecord("check_general_competetions_name");
        }

        public object CheckGeneralCompetetionsSkills()
        {
            return GetRecord("check_general_competetions_skills");
        }

        public object CheckLevelsDescription()
        {
            return GetRecord("check_levels_description");
        }

        public object CheckLevelsName()
        {
            return GetRecord("check_levels_name");
        }

        public object CheckMetaDataName()
        {
            return GetRecord("check_meta_data_name");
        }

        public object CheckMetaTypesName()
        {
            return GetRecord("check_meta_types_name");
        }

        public object CheckProfessionalCompetetionsExperience()
        {
            return GetRecord("check_professional_competetions_experience");
        }

        public object CheckProfessionalCompetetionsKnowledge()
        {
            return GetRecord("check_professional_competetions_knowledge");
        }

        public object CheckProfessionalCompetetionsName()
        {
            return GetRecord("check_professional_competetions_name");
        }

        public object CheckProfessionalCompetetionsSkills()
        {
            return GetRecord("check_professional_competetions_skills");
        }

        public object CheckSourcesName()
        {
            return GetRecord("check_sources_name");
        }

        public object CheckSourceTypesName()
        {
            return GetRecord("check_source_types_name");
        }

        public object CheckSpecialitiesName()
        {
            return GetRecord("check_specialities_name");
        }

        public object CheckSpecialityCodesCode()
        {
            return GetRecord("check_speciality_codes_code");
        }

        public object CheckTasksName()
        {
            return GetRecord("check_tasks_name");
        }

        public object CheckThemesName()
        {
            return GetRecord("check_themes_name");
        }

        public object CheckThemePlanName()
        {
            return GetRecord("check_theme_plan_name");
        }

        public object CheckWorkTypesName()
        {
            return GetRecord("check_work_types_name");
        }
        #endregion

        #region RolesAdministrating Members
        public List<object[]> GetRedactors()
        {
            return GetRecords("get_redactors");
        }

        public object CountRedactors(string value)
        {
            return GetRecord("check_redactor", "redactor_login", value);
        }

        public void AddRedactor(Dictionary<string, object> parameters)
        {
            ExecuteProcedure("add_redactor", parameters);
        }

        public void ResetRedactorPass(Dictionary<string, object> parameters)
        {
            ExecuteProcedure("reset_redactor_pass", parameters);
        }

        public void DropRedactor(Dictionary<string, object> parameters)
        {
            ExecuteProcedure("drop_redactor", parameters);
        }
        #endregion


        #region BaseMessage Members
        public static void ConnectionMessage(string loadProblem, string exception)
        {
            string noLoad = "Не удалось обработать: ";
            string message = "\nОшибка подключения. Вы не можете продолжать работу.\n";
            string advice = "Проверьте конфигурации подключения и текущее состояние сервера.\nПолное сообщение:\n";

            string caption = "Ошибка";
            string fullMessage = noLoad + loadProblem + message + advice + exception;
            _ = MessageBox.Show(fullMessage, caption, MessageBoxButton.OK, MessageBoxImage.Error);
            Application.Current.Shutdown();
        }

        public static void NetMessage(Exception exception, string problem)
        {
            string fullMessage = $"{exception.HelpLink}\n{exception.Message}";
            Log.Error("Operation is invalid or unstated: " + exception.Message);
            ConnectionMessage(problem, fullMessage);
        }

        public static void DropAllCantBeApplied()
        {
            string noOperation = "Быстрое удаление не применимо";
            string message = "\nк данным типам записей.";

            string caption = "Отказ исполнения операции";
            string fullMessage = noOperation + message;
            _ = MessageBox.Show(fullMessage, caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static bool OperationViolatedMessage(in ulong count)
        {
            string noOperation = "Продолжать действие невозможно,";
            string message = "\nт.к. эта запись используется.\n";
            string useCount = "Использована раз: " + count;

            string caption = "Отказ исполнения операции";
            string fullMessage = noOperation + message + useCount;
            _ = MessageBox.Show(fullMessage, caption, MessageBoxButton.OK, MessageBoxImage.Error);
            return true;
        }

        public static bool OperationViolated(in ulong count)
        {
            if (count > 0)
            {
                OperationViolatedMessage(0);
                return true;
            }
            return false;
        }
        #endregion
    }
}
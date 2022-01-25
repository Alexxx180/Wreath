using System;
using System.Windows;
using System.Collections.Generic;

namespace Wreath.Model.DataBase
{
    /// <summary>
    /// Class containing necessary methods to work with database
    /// </summary>
    public abstract class Sql : IDataViewer, IDataAdministrator
    {
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
            ConnectionMessage(problem, fullMessage);
        }

        public abstract void PassParameter(in string ParamName, in object newParam);

        public void PassParameters(Dictionary<string, object> parameters)
        {
            foreach (KeyValuePair<string, object> entry in parameters)
                PassParameter(entry.Key, entry.Value);                
        }

        public abstract void OnlyExecute();

        public abstract void Procedure(in string name);

        public void ExecuteProcedure(string name)
        {
            Procedure(name);
            OnlyExecute();
        }

        public void ExecuteProcedure(string name, string paramName, object value)
        {
            Procedure(name);
            PassParameter(paramName, value);
            OnlyExecute();
            ClearParameters();
        }

        public void ExecuteProcedure(string name, Dictionary<string, object> parameters)
        {
            Procedure(name);
            PassParameters(parameters);
            OnlyExecute();
            ClearParameters();
        }

        public abstract List<object[]> ReadData();

        public abstract List<object> ReadData(in int column);

        public abstract List<object[]> ReadData(in byte StartValue, in byte EndValue);

        public abstract void ClearParameters();

        public List<object[]> GetRecords(string name)
        {
            Procedure(name);
            List<object[]> records = ReadData();
            ClearParameters();
            return records;
        }

        public List<object[]> GetRecords(string name, string paramName, object value)
        {
            Procedure(name);
            PassParameter(paramName, value);
            List<object[]> records = ReadData();
            ClearParameters();
            return records;
        }

        public List<object[]> GetRecords(string name, Dictionary<string, object> parameters)
        {
            Procedure(name);
            PassParameters(parameters);
            List<object[]> records = ReadData();
            ClearParameters();
            return records;
        }

        // Data view methods

        // Unmarked records

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

        public List<object[]> DisciplineGeneralMasteringByTheme(uint value)
        {
            return GetRecords("get_discipline_general_by_theme_unmarked", "theme_id", value);
        }

        public List<object[]> DisciplineProfessionalMasteringByTheme(uint value)
        {
            return GetRecords("get_discipline_professional_by_theme_unmarked", "theme_id", value);
        }

        // Marked records

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

        public List<object[]> MDisciplineGeneralMasteringByTheme(uint value)
        {
            return GetRecords("get_discipline_general_by_theme_marked", "theme_id", value);
        }

        public List<object[]> MDisciplineProfessionalMasteringByTheme(uint value)
        {
            return GetRecords("get_discipline_professional_by_theme_marked", "theme_id", value);
        }

        // Data editing methods

        // Unmark elements

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

        // Drop elements

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
            ExecuteProcedure("drop_meta_type", "type_id", value);
        }

        public void DropSource(ulong value)
        {
            ExecuteProcedure("drop_source", "source_id", value);
        }

        public void DropSourceType(ulong value)
        {
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
            ExecuteProcedure("drop_level", "level_id", value);
        }

        // Unmark all elements in table

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

        // Drop all marked elements in table

        public void DropAllConformity()
        {
            ExecuteProcedure("drop_all_conformity");
        }

        // Specialities
        public void DropAllSpecialities()
        {
            ExecuteProcedure("drop_all_specialities");
        }

        public void DropAllSpecialityCodes()
        {
            ExecuteProcedure("drop_all_speciality_codes");
        }

        public void DropAllGeneralCompetetions()
        {
            ExecuteProcedure("drop_all_general_competetions");
        }

        public void DropAllProfessionalCompetetions()
        {
            ExecuteProcedure("drop_all_professional_competetions");
        }

        // Disciplines
        public void DropAllDisciplines()
        {
            ExecuteProcedure("drop_all_disciplines");
        }

        public void DropAllDisciplineCodes()
        {
            ExecuteProcedure("drop_all_discipline_codes");
        }

        public void DropAllTotalHours()
        {
            ExecuteProcedure("drop_all_hours");
        }

        public void DropAllTopics()
        {
            ExecuteProcedure("drop_all_sections");
        }

        public void DropAllThemes()
        {
            ExecuteProcedure("drop_all_themes");
        }

        public void DropAllWorks()
        {
            ExecuteProcedure("drop_all_works");
        }

        public void DropAllWorkTypes()
        {
            ExecuteProcedure("drop_all_work_types");
        }

        public void DropAllTasks()
        {
            ExecuteProcedure("drop_all_tasks");
        }

        public void DropAllMetaData()
        {
            ExecuteProcedure("drop_all_meta_data");
        }

        public void DropAllMetaTypes()
        {
            ExecuteProcedure("drop_all_meta_types");
        }

        public void DropAllSources()
        {
            ExecuteProcedure("drop_all_sources");
        }

        public void DropAllSourceTypes()
        {
            ExecuteProcedure("drop_all_source_types");
        }

        public void DropAllGeneralMastering()
        {
            ExecuteProcedure("drop_all_general_mastering");
        }

        public void DropAllProfessionalMastering()
        {
            ExecuteProcedure("drop_all_professional_mastering");
        }

        public void DropAllGeneralSelection()
        {
            ExecuteProcedure("drop_all_general_selection");
        }

        public void DropAllProfessionalSelection()
        {
            ExecuteProcedure("drop_all_professional_selection");
        }

        public void DropAllLevels()
        {
            ExecuteProcedure("drop_all_level");
        }
    }
}
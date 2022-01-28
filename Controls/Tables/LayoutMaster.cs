using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Wreath.Controls.Tables.Conformity;
using Wreath.Controls.Tables.Specialities;
using Wreath.Controls.Tables.Specialities.SpecialityCodes;
using Wreath.Controls.Tables.Specialities.GeneralCompetetions;
using Wreath.Controls.Tables.Specialities.ProfessionalCompetetions;
using Wreath.Controls.Tables.Disciplines;
using Wreath.Controls.Tables.Disciplines.DisciplineCodes;
using Wreath.Controls.Tables.Disciplines.GeneralMastering;
using Wreath.Controls.Tables.Disciplines.ProfessionalMastering;
using Wreath.Controls.Tables.Disciplines.SourceTypes;
using Wreath.Controls.Tables.Disciplines.SourceTypes.Sources;
using Wreath.Controls.Tables.Disciplines.MetaTypes;
using Wreath.Controls.Tables.Disciplines.MetaTypes.MetaData;
using Wreath.Controls.Tables.Disciplines.WorkTypes;
using Wreath.Controls.Tables.Disciplines.WorkTypes.Hours;
using Wreath.Controls.Tables.Disciplines.WorkTypes.ThemePlan;
using Wreath.Controls.Tables.Disciplines.WorkTypes.ThemePlan.Themes;
using Wreath.Controls.Tables.Disciplines.WorkTypes.ThemePlan.Themes.CompetetionLevels;
using Wreath.Controls.Tables.Disciplines.WorkTypes.ThemePlan.Themes.GeneralMastering;
using Wreath.Controls.Tables.Disciplines.WorkTypes.ThemePlan.Themes.ProfessionalMastering;
using Wreath.Controls.Tables.Disciplines.WorkTypes.ThemePlan.Themes.Works;
using Wreath.Controls.Tables.Disciplines.WorkTypes.ThemePlan.Themes.Works.Tasks;
using Wreath.Model;
using Wreath.ViewModel;
using Wreath.Model.DataBase;

namespace Wreath.Controls.Tables
{
    public class LayoutMaster : INotifyPropertyChanged
    {
        private GlobalViewModel _viewModel;
        public GlobalViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        public LayoutMaster()
        {
            Records = new StackPanel
            {
                Tag = this
            };
        }

        public LayoutMaster(GlobalViewModel viewModel) : this()
        {
            ViewModel = viewModel;
            _connector = new MySQL();
            Tools = new RedactorTools(_connector);
            Data = new ProgramData(_connector);
        }

        private UserControl _header;
        public UserControl Header
        {
            get => _header;
            set
            {
                _header = value;
                OnPropertyChanged();
            }
        }

        private StackPanel _records;
        public StackPanel Records
        {
            get => _records;
            set
            {
                _records = value;
                OnPropertyChanged();
            }
        }

        public int Count => Records.Children.Count;

        private void RecordsChanged()
        {
            OnPropertyChanged(nameof(Records));
            OnPropertyChanged(nameof(Count));
        }

        public ushort AddElements<T>(List<string[]> records)
        {
            ushort i = 0;
            for (; i < records.Count; i++)
                AddElement<T>(records[i]).Index(i + 1);
            RecordsChanged();
            return i;
        }

        public IMarkable AddElement<T>(string[] record)
        {
            IMarkable row = Activator.CreateInstance(typeof(T)) as IMarkable;
            row.SetElement(record);
            row.RowKey = Records.Children.Add(row as UserControl);
            row.SetTools(Records);
            return row;
        }

        public void AddMarkedElements<T>(ushort no, List<string[]> records)
        {
            for (ushort i = 0; i < records.Count; i++, no++)
                AddMarkedElement<T>(records[i]).Index(no);
            RecordsChanged();
        }

        public IMarkable AddMarkedElement<T>(string[] record)
        {
            IMarkable row = AddElement<T>(record);
            row.Mark();
            return row;
        }

        private void ResetHeaders(UserControl currentHeader)
        {
            Header = null;
            Header = currentHeader;
        }

        private string Before(string name) => "Ранее смотрели: " + name;

        private void FillTables<T>(UserControl header,
            List<string[]> rows, List<string[]> markedRows,
            GlobalViewModel.FastAction unMarkAll,
            GlobalViewModel.FastAction deleteAll)
        {
            ResetHeaders(header);
            Records.Children.Clear();
            ushort no = Convert.ToUInt16(AddElements<T>(rows) + 1);
            AddMarkedElements<T>(no, markedRows);
            ViewModel.FastActions.Name = unMarkAll;
            ViewModel.FastActions.Value = deleteAll;
        }

        private void FillSecondaryTables<T>(uint id, string name,
            TransitionBase.Transition transition, UserControl header,
            List<string[]> rows, List<string[]> markedRows,
            GlobalViewModel.FastAction unMarkAll,
            GlobalViewModel.FastAction deleteAll)
        {
            ViewModel.AddTransition(transition, name, id);
            FillTables<T>(header, rows, markedRows, unMarkAll, deleteAll);
        }

        private void FillPrimaryTables<T>(uint id, string name,
            TransitionBase.Transition transition, UserControl header,
            List<string[]> rows, List<string[]> markedRows,
            GlobalViewModel.FastAction unMarkAll,
            GlobalViewModel.FastAction deleteAll)
        {
            ViewModel.CleanBuffer();
            FillSecondaryTables<T>(id, name, transition, header,
                rows, markedRows, unMarkAll, deleteAll);
        }

        public void FillConformity(uint id = 0)
        {
            FillPrimaryTables<ConformityRow>(id, Before("Соответствие - ID"), FillConformity,
                new ConformityColumns(), Data.Conformity, Data.MConformity,
                Tools.UnMarkRow.AllConformity, Tools.DropRow.AllConformity);
        }


        public void FillSpecialities(uint id = 0)
        {
            FillPrimaryTables<SpecialityRow>(id, Before("Специальность - ID"), FillSpecialities,
                new SpecialityColumns(this), Data.Specialities, Data.MSpecialities,
                Tools.UnMarkRow.AllSpeciality, Tools.DropRow.AllSpeciality);
        }


        public void FillGeneral(List<string[]> records, List<string[]> markedRecords,
            uint id, string name, TransitionBase.Transition transition)
        {
            FillSecondaryTables<GeneralCompetetionRow>(id,
                name, transition, new GeneralCompetetionColumns(), records, markedRecords,
                Tools.UnMarkRow.AllGeneralCompetetion, Tools.DropRow.AllGeneralCompetetion);
        }

        public void FillGeneralCompetetions(uint id)
        {
            FillGeneral(Data.GeneralCompetetions(id), Data.MGeneralCompetetions(id),
                id, "Специальность - ID", FillGeneralCompetetions);
        }

        public void FillGeneralFromMastering(uint id)
        {
            FillGeneral(Data.ConformityGeneralCompetetions(id),
                Data.MConformityGeneralCompetetions(id), id,
                "Дисциплина - ID", FillGeneralFromMastering);
        }


        public void FillProfessional(List<string[]> records, List<string[]> markedRecords,
            uint id, string name, TransitionBase.Transition transition)
        {
            FillSecondaryTables<ProfessionalCompetetionRow>
                (id, name, transition, new ProfessionalCompetetionColumns(), records, markedRecords,
                Tools.UnMarkRow.AllProfessionalCompetetion, Tools.DropRow.AllProfessionalCompetetion);
        }

        public void FillProfessionalCompetetions(uint id)
        {
            FillProfessional(Data.ProfessionalCompetetions(id),
                Data.MProfessionalCompetetions(id), id,
                "Специальность - ID", FillProfessionalCompetetions);
        }

        public void FillProfessionalFromMastering(uint id)
        {
            FillProfessional(Data.ConformityProfessionalCompetetions(id),
                Data.MConformityProfessionalCompetetions(id), id,
                "Дисциплина - ID", FillProfessionalFromMastering);
        }


        public void FillDisciplines(uint id = 0)
        {
            FillPrimaryTables<DisciplineRow>(id, Before("Дисциплина - ID"), FillDisciplines,
                new DisciplineColumns(this), Data.Disciplines, Data.MDisciplines,
                Tools.UnMarkRow.AllDiscipline, Tools.DropRow.AllDiscipline);
        }


        public void FillDisciplineGeneral(List<string[]> records, List<string[]> markedRecords,
            uint id, string name, TransitionBase.Transition transition)
        {
            FillSecondaryTables<DisciplineGeneralMasteringRow>(id, name, transition,
                new DisciplineGeneralMasteringColumns(this), records, markedRecords,
                Tools.UnMarkRow.AllGeneralMastering, Tools.DropRow.AllGeneralMastering);
        }

        public void FillDisciplineGeneralCompetetions(uint id)
        {
            FillDisciplineGeneral(Data.DisciplineGeneralMastering(id),
                Data.MDisciplineGeneralMastering(id), id,
                "Дисциплина - ID", FillDisciplineGeneralCompetetions);
        }

        public void FillDisciplineGeneralFromMastering(uint id)
        {
            FillDisciplineGeneral(Data.DisciplineGeneralMasteringByTheme(id),
                Data.MDisciplineGeneralMasteringByTheme(id), id,
                "Дисциплина - ID", FillDisciplineGeneralFromMastering);
        }


        public void FillDisciplineProfessional(List<string[]> records, List<string[]> markedRecords,
            uint id, string name, TransitionBase.Transition transition)
        {
            FillSecondaryTables<DisciplineProfessionalMasteringRow>(id, name, transition,
                new DisciplineProfessionalMasteringColumns(this), records, markedRecords,
                Tools.UnMarkRow.AllProfessionalMastering, Tools.DropRow.AllProfessionalMastering);
        }

        public void FillDisciplineProfessionalCompetetions(uint id)
        {
            FillDisciplineProfessional(Data.DisciplineProfessionalMastering(id),
                Data.MDisciplineProfessionalMastering(id), id,
                "Дисциплина - ID", FillDisciplineProfessionalCompetetions);
        }

        public void FillDisciplineProfessionalFromMastering(uint id)
        {
            FillDisciplineProfessional(Data.DisciplineProfessionalMasteringByTheme(id),
                Data.MDisciplineProfessionalMasteringByTheme(id), id,
                "Дисциплина - ID", FillDisciplineProfessionalFromMastering);
        }


        public void FillSources(uint id)
        {
            FillSecondaryTables<SourceRow>(id, "Дисциплина - ID", FillSources,
                new SourceColumns(this), Data.Sources(id), Data.MSources(id),
                Tools.UnMarkRow.AllSource, Tools.DropRow.AllSource);
        }

        public void FillMetaData(uint id)
        {
            FillSecondaryTables<MetaDataRow>(id, "Дисциплина - ID", FillMetaData,
                new MetaDataColumns(this), Data.MetaData(id), Data.MMetaData(id),
                Tools.UnMarkRow.AllMetaData, Tools.DropRow.AllMetaData);
        }

        public void FillHours(uint id)
        {
            FillSecondaryTables<HoursRow>(id, "Дисциплина - ID", FillHours,
                new HoursColumns(this), Data.TotalHours(id), Data.MTotalHours(id),
                Tools.UnMarkRow.AllTotalHour, Tools.DropRow.AllTotalHour);
        }

        public void FillTopics(uint id)
        {
            FillSecondaryTables<TopicRow>(id, "Дисциплина - ID", FillTopics,
                new TopicColumns(), Data.ThemePlan(id), Data.MThemePlan(id),
                Tools.UnMarkRow.AllTopic, Tools.DropRow.AllTopic);
        }

        public void FillThemes(uint id)
        {
            FillSecondaryTables<ThemeRow>(id, "Раздел - ID", FillThemes,
                new ThemeColumns(this), Data.Themes(id), Data.MThemes(id),
                Tools.UnMarkRow.AllTheme, Tools.DropRow.AllTheme);
        }

        public void FillThemeGeneralCompetetions(uint id)
        {
            FillSecondaryTables<ThemeGeneralMasteringRow>(id, "Тема - ID",
                FillThemeGeneralCompetetions, new ThemeGeneralMasteringColumns(this),
                Data.ThemeGeneralMastering(id), Data.MThemeGeneralMastering(id),
                Tools.UnMarkRow.AllGeneralSelection, Tools.DropRow.AllGeneralSelection);
        }

        public void FillThemeProfessionalCompetetions(uint id)
        {
            FillSecondaryTables<ThemeProfessionalMasteringRow>(id, "Тема - ID",
                FillThemeProfessionalCompetetions, new ThemeProfessionalMasteringColumns(this),
                Data.ThemeProfessionalMastering(id), Data.MThemeProfessionalMastering(id),
                Tools.UnMarkRow.AllProfessionalSelection, Tools.DropRow.AllProfessionalSelection);
        }

        public void FillWorks(uint id)
        {
            FillSecondaryTables<WorkRow>(id, "Тема - ID", FillWorks,
                new WorkColumns(this), Data.Works(id), Data.MWorks(id),
                Tools.UnMarkRow.AllWork, Tools.DropRow.AllWork);
        }

        public void FillTasks(uint id)
        {
            FillSecondaryTables<TaskRow>(id, "Работа - ID", FillTasks,
                new TaskColumns(), Data.Tasks(id), Data.MTasks(id),
                Tools.UnMarkRow.AllTask, Tools.DropRow.AllTask);
        }


        public void FillSpecialityCodes(uint id)
        {
            ViewModel.AddTransition(FillSpecialities, Before("Специальность - ID"), id);
            FillSecondaryTables<SpecialityCodeRow>(id, Before("Специальность - ID"), FillSpecialityCodes,
                new SpecialityCodeColumns(), Data.SpecialityCodes, Data.MSpecialityCodes,
                Tools.UnMarkRow.AllSpecialityCode, Tools.DropRow.AllSpecialityCode);
        }

        public void FillDisciplineCodes(uint id)
        {
            ViewModel.AddTransition(FillDisciplines, "Ранее смотрели: Дисциплина - ID", id);
            FillSecondaryTables<DisciplineCodeRow>(id, Before("Дисциплина - ID"), FillDisciplineCodes,
                new DisciplineCodeColumns(), Data.DisciplineCodes, Data.MDisciplineCodes,
                Tools.UnMarkRow.AllDisciplineCode, Tools.DropRow.AllDisciplineCode);
        }

        public void FillWorkTypes(uint id)
        {
            FillSecondaryTables<WorkTypesRow>(id, Before("Работа | Час - ID"),
                FillWorkTypes, new WorkTypesColumns(), Data.WorkTypes, Data.MWorkTypes,
                Tools.UnMarkRow.AllWorkType, Tools.DropRow.AllWorkType);
        }

        public void FillMetaTypes(uint id)
        {
            FillSecondaryTables<MetaTypeRow>(id, Before("Метаданные - ID"),
                FillMetaTypes, new MetaTypeColumns(), Data.MetaTypes, Data.MMetaTypes,
                Tools.UnMarkRow.AllMetaType, Tools.DropRow.AllMetaType);
        }

        public void FillSourceTypes(uint id)
        {
            FillSecondaryTables<SourceTypeRow>(id, Before("Источник - ID"), FillSourceTypes,
                new SourceTypeColumns(), Data.SourceTypes, Data.MSourceTypes,
                Tools.UnMarkRow.AllSourceType, Tools.DropRow.AllSourceType);
        }

        public void FillCompetetionLevels(uint id)
        {
            FillSecondaryTables<LevelRow>(id, Before("Тема - ID"), FillCompetetionLevels,
                new LevelColumns(), Data.Levels, Data.MLevels,
                Tools.UnMarkRow.AllLevel, Tools.DropRow.AllLevel);
        }

        private readonly Sql _connector;
        public RedactorTools Tools { get; }
        public ProgramData Data { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
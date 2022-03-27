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
using Wreath.Model.Tools.DataBase;
using Wreath.Model.Tools.DataBase.Edit;
using Wreath.Model.Tools.DataBase.View;


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
            _connector = viewModel.Connector;
            Tools = new RedactorTools(_connector);
            Data = new ProgramData(_connector);
        }

        public bool Connect()
        {
            return _connector.Connect();
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
            FillPrimaryTables<ConformityRow>(id, "Соответствия. Ранее смотрели: ", FillConformity,
                new ConformityColumns(), Data.Conformity, Data.MConformity,
                Tools.UnMarkRow.AllConformity, Tools.DropRow.AllConformity);
        }


        public void FillSpecialities(uint id = 0)
        {
            FillPrimaryTables<SpecialityRow>(id, "Специальности. Ранее смотрели: ", FillSpecialities,
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
                id, "ОК. Специальность: ", FillGeneralCompetetions);
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
            FillProfessional(Data.ProfessionalCompetetions(id), Data.MProfessionalCompetetions(id), id,
                "ПК. Специальность: ", FillProfessionalCompetetions);
        }


        public void FillDisciplines(uint id = 0)
        {
            FillPrimaryTables<DisciplineRow>(id, "Дисциплины. Ранее смотрели: ", FillDisciplines,
                new DisciplineColumns(this), Data.Disciplines, Data.MDisciplines,
                Tools.UnMarkRow.AllDiscipline, Tools.DropRow.AllDiscipline);
        }


        public void FillDisciplineGeneral(List<string[]> records, List<string[]> markedRecords,
            uint id, string name, TransitionBase.Transition transition)
        {
            FillSecondaryTables<DisciplineGeneralMasteringRow>(id, name, transition,
                new DisciplineGeneralMasteringColumns(), records, markedRecords,
                Tools.UnMarkRow.AllGeneralMastering, Tools.DropRow.AllGeneralMastering);
        }

        public void FillDisciplineGeneralCompetetions(uint id)
        {
            FillDisciplineGeneral(Data.DisciplineGeneralMastering(id),
                Data.MDisciplineGeneralMastering(id), id,
                "Освоение ОК. Дисциплина: ", FillDisciplineGeneralCompetetions);
        }


        public void FillDisciplineProfessional(List<string[]> records, List<string[]> markedRecords,
            uint id, string name, TransitionBase.Transition transition)
        {
            FillSecondaryTables<DisciplineProfessionalMasteringRow>(id, name,
                transition, new DisciplineProfessionalMasteringColumns(), records, markedRecords,
                Tools.UnMarkRow.AllProfessionalMastering, Tools.DropRow.AllProfessionalMastering);
        }

        public void FillDisciplineProfessionalCompetetions(uint id)
        {
            FillDisciplineProfessional(Data.DisciplineProfessionalMastering(id),
                Data.MDisciplineProfessionalMastering(id), id,
                "Освоение ПК. Дисциплина: ", FillDisciplineProfessionalCompetetions);
        }


        public void FillSources(uint id)
        {
            FillSecondaryTables<SourceRow>(id, "Источники. Дисциплина: ", FillSources,
                new SourceColumns(this), Data.Sources(id), Data.MSources(id),
                Tools.UnMarkRow.AllSource, Tools.DropRow.AllSource);
        }

        public void FillMetaData(uint id)
        {
            FillSecondaryTables<MetaDataRow>(id, "Метаданные. Дисциплина: ", FillMetaData,
                new MetaDataColumns(this), Data.MetaData(id), Data.MMetaData(id),
                Tools.UnMarkRow.AllMetaData, Tools.DropRow.AllMetaData);
        }

        public void FillHours(uint id)
        {
            FillSecondaryTables<HoursRow>(id, "Общие часы. Дисциплина: ", FillHours,
                new HoursColumns(this), Data.TotalHours(id), Data.MTotalHours(id),
                Tools.UnMarkRow.AllTotalHour, Tools.DropRow.AllTotalHour);
        }

        public void FillTopics(uint id)
        {
            FillSecondaryTables<TopicRow>(id, "Разделы. Дисциплина: ", FillTopics,
                new TopicColumns(), Data.ThemePlan(id), Data.MThemePlan(id),
                Tools.UnMarkRow.AllTopic, Tools.DropRow.AllTopic);
        }

        public void FillThemes(uint id)
        {
            FillSecondaryTables<ThemeRow>(id, "Темы. Раздел: ", FillThemes,
                new ThemeColumns(this), Data.Themes(id), Data.MThemes(id),
                Tools.UnMarkRow.AllTheme, Tools.DropRow.AllTheme);
        }

        public void FillThemeGeneralCompetetions(uint id)
        {
            FillSecondaryTables<ThemeGeneralMasteringRow>(id, "Освоение ОК. Тема: ",
                FillThemeGeneralCompetetions, new ThemeGeneralMasteringColumns(this),
                Data.ThemeGeneralMastering(id), Data.MThemeGeneralMastering(id),
                Tools.UnMarkRow.AllGeneralSelection, Tools.DropRow.AllGeneralSelection);
        }

        public void FillThemeProfessionalCompetetions(uint id)
        {
            FillSecondaryTables<ThemeProfessionalMasteringRow>(id, "Освоение ПК. Тема: ",
                FillThemeProfessionalCompetetions, new ThemeProfessionalMasteringColumns(this),
                Data.ThemeProfessionalMastering(id), Data.MThemeProfessionalMastering(id),
                Tools.UnMarkRow.AllProfessionalSelection, Tools.DropRow.AllProfessionalSelection);
        }

        public void FillWorks(uint id)
        {
            FillSecondaryTables<WorkRow>(id, "Работы. Тема: ", FillWorks,
                new WorkColumns(this), Data.Works(id), Data.MWorks(id),
                Tools.UnMarkRow.AllWork, Tools.DropRow.AllWork);
        }

        public void FillTasks(uint id)
        {
            FillSecondaryTables<TaskRow>(id, "Задачи. Работа: ", FillTasks,
                new TaskColumns(), Data.Tasks(id), Data.MTasks(id),
                Tools.UnMarkRow.AllTask, Tools.DropRow.AllTask);
        }


        public void FillSpecialityCodes(uint id)
        {
            ViewModel.AddTransition(FillSpecialities, "Специальности. Ранее смотрели: ", id);
            FillSecondaryTables<SpecialityCodeRow>(id, "Коды специальностей. Переход от: ", FillSpecialityCodes,
                new SpecialityCodeColumns(), Data.SpecialityCodes, Data.MSpecialityCodes,
                Tools.UnMarkRow.AllSpecialityCode, Drop.None);
        }

        public void FillDisciplineCodes(uint id)
        {
            ViewModel.AddTransition(FillDisciplines, "Дисциплины. Ранее смотрели: ", id);
            FillSecondaryTables<DisciplineCodeRow>(id, "Коды дисциплин. Переход от: ", FillDisciplineCodes,
                new DisciplineCodeColumns(), Data.DisciplineCodes, Data.MDisciplineCodes,
                Tools.UnMarkRow.AllDisciplineCode, Drop.None);
        }

        public void FillWorkTypes(uint id)
        {
            FillSecondaryTables<WorkTypesRow>(id, "Типы работ. Переход от: ",
                FillWorkTypes, new WorkTypesColumns(), Data.WorkTypes, Data.MWorkTypes,
                Tools.UnMarkRow.AllWorkType, Drop.None);
        }

        public void FillMetaTypes(uint id)
        {
            FillSecondaryTables<MetaTypeRow>(id, "Типы метаданных. Переход от: ",
                FillMetaTypes, new MetaTypeColumns(), Data.MetaTypes, Data.MMetaTypes,
                Tools.UnMarkRow.AllMetaType, Drop.None);
        }

        public void FillSourceTypes(uint id)
        {
            FillSecondaryTables<SourceTypeRow>(id, "Типы источников. Переход от: ", FillSourceTypes,
                new SourceTypeColumns(), Data.SourceTypes, Data.MSourceTypes,
                Tools.UnMarkRow.AllSourceType, Drop.None);
        }

        public void FillCompetetionLevels(uint id)
        {
            FillSecondaryTables<LevelRow>(id, "Уровни компетенций. Переход от: ", FillCompetetionLevels,
                new LevelColumns(), Data.Levels, Data.MLevels,
                Tools.UnMarkRow.AllLevel, Drop.None);
        }

        public void AnalyzeSpeciality(uint id)
        {
            List<string> rowCounts = Data.SpecialityMarkedRowsAnalyze(id);
            AnalyzerWindow analyzer = new AnalyzerWindow("Специальность, ID: " + id);
            analyzer.AddElements(
                new Pair<string, List<int>>("Общие компетенции: " + rowCounts[0], new List<int> { }),
                new Pair<string, List<int>>("Профессиональные компетенции: " + rowCounts[1], new List<int> { })
                );
            analyzer.Show();
        }

        public void AnalyzeDiscipline(uint id)
        {
            List<string> rowCounts = Data.DisciplineMarkedRowsAnalyze(id);
            AnalyzerWindow analyzer = new AnalyzerWindow("Дисциплина, ID: " + id);
            analyzer.AddElements(
                new Pair<string, List<int>>("Освоение ОК: " + rowCounts[0], new List<int>()),
                new Pair<string, List<int>>("Освоение ПК: " + rowCounts[1], new List<int>()),
                new Pair<string, List<int>>("Источники: " + rowCounts[2], new List<int>()),
                new Pair<string, List<int>>("Метаданные: " + rowCounts[3], new List<int>()),
                new Pair<string, List<int>>("Общие часы: " + rowCounts[4], new List<int>()),
                new Pair<string, List<int>>("Разделы: " + rowCounts[5], new List<int>()),
                new Pair<string, List<int>>("Темы: " + rowCounts[6], new List<int> { 5 }),
                new Pair<string, List<int>>("Освоение ОК: " + rowCounts[7], new List<int> { 5, 0 }),
                new Pair<string, List<int>>("Освоение ПК: " + rowCounts[8], new List<int> { 5, 0 }),
                new Pair<string, List<int>>("Работы: " + rowCounts[9], new List<int> { 5, 0 }),
                new Pair<string, List<int>>("Задачи: " + rowCounts[10], new List<int> { 5, 0, 2 })
                );
            analyzer.Show();
        }

        public void AnalyzeTopic(uint id)
        {
            List<string> rowCounts = Data.TopicMarkedRowsAnalyze(id);
            AnalyzerWindow analyzer = new AnalyzerWindow("Раздел, ID: " + id);
            analyzer.AddElements(
                new Pair<string, List<int>>("Темы: " + rowCounts[0], new List<int>()),
                new Pair<string, List<int>>("Освоение ОК: " + rowCounts[1], new List<int> { 0 }),
                new Pair<string, List<int>>("Освоение ПК: " + rowCounts[2], new List<int> { 0 }),
                new Pair<string, List<int>>("Работы: " + rowCounts[3], new List<int> { 0 }),
                new Pair<string, List<int>>("Задачи: " + rowCounts[4], new List<int> { 0, 2 })
                );
            analyzer.Show();
        }

        public void AnalyzeTheme(uint id)
        {
            List<string> rowCounts = Data.ThemeMarkedRowsAnalyze(id);
            AnalyzerWindow analyzer = new AnalyzerWindow("Тема, ID: " + id);
            analyzer.AddElements(
                new Pair<string, List<int>>("Освоение ОК: " + rowCounts[0], new List<int>()),
                new Pair<string, List<int>>("Освоение ПК: " + rowCounts[1], new List<int>()),
                new Pair<string, List<int>>("Работы: " + rowCounts[2], new List<int>()),
                new Pair<string, List<int>>("Задачи: " + rowCounts[3], new List<int> { 2 })
                );
            analyzer.Show();
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
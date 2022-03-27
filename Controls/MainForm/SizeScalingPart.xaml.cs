using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wreath.Model.Tools;
using Wreath.ViewModel;

namespace Wreath.Controls.MainForm
{
    /// <summary>
    /// Size scalers panel
    /// </summary>
    public partial class SizeScalingPart : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
                typeof(GlobalViewModel), typeof(SizeScalingPart),
                new PropertyMetadata(OnConnectionChangedCallBack));

        internal GlobalViewModel ViewModel
        {
            get => GetValue(ViewModelProperty) as GlobalViewModel;
            set => SetValue(ViewModelProperty, value);
        }

        #region ConnectionCallBack Members
        private static void
            OnConnectionChangedCallBack(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            if (sender is SizeScalingPart connector)
            {
                connector?.OnConnectionChanged();
            }
        }

        protected virtual void OnConnectionChanged()
        {
            Scaler = ViewModel.Connector;
            SetDefaults();
        }
        #endregion

        public SizeScalingPart()
        {
            InitializeComponent();
        }

        private void SetDefaults()
        {
            for (byte i = 0; i < MainPanel.Children.Count; i++)
            {
                SizeScaler sizeScaler = MainPanel.Children[i] as SizeScaler;
                sizeScaler.SetDefaultSize();
            }
        }

        private ISizeScaler _scaler;
        internal ISizeScaler Scaler
        {
            get => _scaler;
            set
            {
                _scaler = value;
                OnPropertyChanged();
            }
        }

        #region IncreaseColumnSize Members
        public void IncreaseDisciplinesName(ushort value)
        {
            Scaler.IncreaseDisciplinesName(value);
        }

        public void IncreaseDisciplineCodesCode(ushort value)
        {
            Scaler.IncreaseDisciplineCodesCode(value);
        }

        public void IncreaseGeneralCompetetionsKnowledge(ushort value)
        {
            Scaler.IncreaseGeneralCompetetionsKnowledge(value);
        }

        public void IncreaseGeneralCompetetionsName(ushort value)
        {
            Scaler.IncreaseGeneralCompetetionsName(value);
        }

        public void IncreaseGeneralCompetetionsSkills(ushort value)
        {
            Scaler.IncreaseGeneralCompetetionsSkills(value);
        }

        public void IncreaseLevelsDescription(ushort value)
        {
            Scaler.IncreaseLevelsDescription(value);
        }

        public void IncreaseLevelsName(ushort value)
        {
            Scaler.IncreaseLevelsName(value);
        }

        public void IncreaseMetaDataName(ushort value)
        {
            Scaler.IncreaseMetaDataName(value);
        }

        public void IncreaseMetaTypesName(ushort value)
        {
            Scaler.IncreaseMetaTypesName(value);
        }

        public void IncreaseProfessionalCompetetionsExperience(ushort value)
        {
            Scaler.IncreaseProfessionalCompetetionsExperience(value);
        }

        public void IncreaseProfessionalCompetetionsKnowledge(ushort value)
        {
            Scaler.IncreaseProfessionalCompetetionsKnowledge(value);
        }

        public void IncreaseProfessionalCompetetionsName(ushort value)
        {
            Scaler.IncreaseProfessionalCompetetionsName(value);
        }

        public void IncreaseProfessionalCompetetionsSkills(ushort value)
        {
            Scaler.IncreaseProfessionalCompetetionsSkills(value);
        }

        public void IncreaseSourcesName(ushort value)
        {
            Scaler.IncreaseSourcesName(value);
        }

        public void IncreaseSourceTypesName(ushort value)
        {
            Scaler.IncreaseSourceTypesName(value);
        }

        public void IncreaseSpecialitiesName(ushort value)
        {
            Scaler.IncreaseSpecialitiesName(value);
        }

        public void IncreaseSpecialityCodesCode(ushort value)
        {
            Scaler.IncreaseSpecialityCodesCode(value);
        }

        public void IncreaseTasksName(ushort value)
        {
            Scaler.IncreaseTasksName(value);
        }

        public void IncreaseThemesName(ushort value)
        {
            Scaler.IncreaseThemesName(value);
        }

        public void IncreaseThemePlanName(ushort value)
        {
            Scaler.IncreaseThemePlanName(value);
        }

        public void IncreaseWorkTypesName(ushort value)
        {
            Scaler.IncreaseWorkTypesName(value);
        }
        #endregion

        #region CheckColumnSize Members
        public object CheckDisciplinesName()
        {
            return Scaler.CheckDisciplinesName();
        }

        public object CheckDisciplineCodesCode()
        {
            return Scaler.CheckDisciplineCodesCode();
        }

        public object CheckGeneralCompetetionsKnowledge()
        {
            return Scaler.CheckGeneralCompetetionsKnowledge();
        }

        public object CheckGeneralCompetetionsName()
        {
            return Scaler.CheckGeneralCompetetionsName();
        }

        public object CheckGeneralCompetetionsSkills()
        {
            return Scaler.CheckGeneralCompetetionsSkills();
        }

        public object CheckLevelsDescription()
        {
            return Scaler.CheckLevelsDescription();
        }

        public object CheckLevelsName()
        {
            return Scaler.CheckLevelsName();
        }

        public object CheckMetaDataName()
        {
            return Scaler.CheckMetaDataName();
        }

        public object CheckMetaTypesName()
        {
            return Scaler.CheckMetaTypesName();
        }

        public object CheckProfessionalCompetetionsExperience()
        {
            return Scaler.CheckProfessionalCompetetionsExperience();
        }

        public object CheckProfessionalCompetetionsKnowledge()
        {
            return Scaler.CheckProfessionalCompetetionsKnowledge();
        }

        public object CheckProfessionalCompetetionsName()
        {
            return Scaler.CheckProfessionalCompetetionsName();
        }

        public object CheckProfessionalCompetetionsSkills()
        {
            return Scaler.CheckProfessionalCompetetionsSkills();
        }

        public object CheckSourcesName()
        {
            return Scaler.CheckSourcesName();
        }

        public object CheckSourceTypesName()
        {
            return Scaler.CheckSourceTypesName();
        }

        public object CheckSpecialitiesName()
        {
            return Scaler.CheckSpecialitiesName();
        }

        public object CheckSpecialityCodesCode()
        {
            return Scaler.CheckSpecialityCodesCode();
        }

        public object CheckTasksName()
        {
            return Scaler.CheckTasksName();
        }

        public object CheckThemesName()
        {
            return Scaler.CheckThemesName();
        }

        public object CheckThemePlanName()
        {
            return Scaler.CheckThemePlanName();
        }

        public object CheckWorkTypesName()
        {
            return Scaler.CheckWorkTypesName();
        }
        #endregion


        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
    }
}
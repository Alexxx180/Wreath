﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wreath.Controls.Users;
using Wreath.Model.Tools;
using Wreath.Model.Tools.DataBase.View;
using Wreath.ViewModel;

namespace Wreath.Controls.MainForm
{
    /// <summary>
    /// Part responsible for roles (redactors) administrating
    /// </summary>
    public partial class RolesPart : UserControl
    {
        public static readonly DependencyProperty
            ViewModelProperty = DependencyProperty.Register(
                nameof(ViewModel), typeof(GlobalViewModel), typeof(RolesPart),
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
            if (sender is RolesPart connector)
            {
                connector?.OnConnectionChanged();
            }
        }

        protected virtual void OnConnectionChanged()
        {
            Redactors = ViewModel.Connector;
            ResetRecords();
        }
        #endregion

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

        public RolesPart()
        {
            InitializeComponent();
        }

        internal void ResetRecords()
        {
            Records.Children.Clear();
            RedactorRow.AddElements(Records,
                Converters.ConvertAll(Redactors.GetRedactors(),
                Converters.ElementsToString));
            _ = Records.Children.Add(new RedactorRowAdditor(this));
        }

        private IRolesAdministrating _redactors;
        internal IRolesAdministrating Redactors
        {
            get => _redactors;
            set
            {
                _redactors = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

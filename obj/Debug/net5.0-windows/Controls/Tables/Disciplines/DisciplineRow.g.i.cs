﻿#pragma checksum "..\..\..\..\..\..\Controls\Tables\Disciplines\DisciplineRow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A9B60B09A3D2663B386A0DA26E8A16BFAA4EDA60"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Wreath.Controls.Tables.Disciplines {
    
    
    /// <summary>
    /// DisciplineRow
    /// </summary>
    public partial class DisciplineRow : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Wreath;component/controls/tables/disciplines/disciplinerow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Controls\Tables\Disciplines\DisciplineRow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\..\..\..\Controls\Tables\Disciplines\DisciplineRow.xaml"
            ((Wreath.Controls.Tables.Disciplines.DisciplineRow)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.FastSelect);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 22 "..\..\..\..\..\..\Controls\Tables\Disciplines\DisciplineRow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ViewRow);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 28 "..\..\..\..\..\..\Controls\Tables\Disciplines\DisciplineRow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AnalyzeRow);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 35 "..\..\..\..\..\..\Controls\Tables\Disciplines\DisciplineRow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Select);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 65 "..\..\..\..\..\..\Controls\Tables\Disciplines\DisciplineRow.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SecondaryTables_Select);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


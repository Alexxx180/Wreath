﻿#pragma checksum "..\..\..\..\..\Controls\MainForm\WreathHeader.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7D5EAD5EDD620FC1233721B47856BFC3CB1447FA"
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
using Wreath.Controls.Binds.Converters;


namespace Wreath.Controls.MainForm {
    
    
    /// <summary>
    /// WreathHeader
    /// </summary>
    public partial class WreathHeader : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\..\..\Controls\MainForm\WreathHeader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ColumnSizes;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\Controls\MainForm\WreathHeader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Roles;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\Controls\MainForm\WreathHeader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TableSelector;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\..\Controls\MainForm\WreathHeader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Records;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.15.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Wreath;component/controls/mainform/wreathheader.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Controls\MainForm\WreathHeader.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.15.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ColumnSizes = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\..\Controls\MainForm\WreathHeader.xaml"
            this.ColumnSizes.Click += new System.Windows.RoutedEventHandler(this.ChangeTab);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Roles = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\..\Controls\MainForm\WreathHeader.xaml"
            this.Roles.Click += new System.Windows.RoutedEventHandler(this.ChangeTab);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TableSelector = ((System.Windows.Controls.ComboBox)(target));
            
            #line 52 "..\..\..\..\..\Controls\MainForm\WreathHeader.xaml"
            this.TableSelector.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.PrimaryTables_Select);
            
            #line default
            #line hidden
            
            #line 52 "..\..\..\..\..\Controls\MainForm\WreathHeader.xaml"
            this.TableSelector.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.PrimaryTables_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Records = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\..\..\Controls\MainForm\WreathHeader.xaml"
            this.Records.Click += new System.Windows.RoutedEventHandler(this.ChangeTab);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


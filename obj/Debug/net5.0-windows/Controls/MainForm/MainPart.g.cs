﻿#pragma checksum "..\..\..\..\..\Controls\MainForm\MainPart.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64793083B1B41D1530FC9C95981D1F94E9BE5DAC"
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
using Wreath.ViewModel;


namespace Wreath.Controls.MainForm {
    
    
    /// <summary>
    /// MainPart
    /// </summary>
    public partial class MainPart : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\..\..\Controls\MainForm\MainPart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wreath.Controls.MainForm.MainPart MainRedactor;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\Controls\MainForm\MainPart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border CurrentHeaders;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\..\Controls\MainForm\MainPart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Data.Binding TableHeader;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\..\Controls\MainForm\MainPart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border TableViewControl;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\..\Controls\MainForm\MainPart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Data.Binding AllRecords;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\..\Controls\MainForm\MainPart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CountRecords;
        
        #line default
        #line hidden
        
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
            System.Uri resourceLocater = new System.Uri("/Wreath;component/controls/mainform/mainpart.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Controls\MainForm\MainPart.xaml"
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
            this.MainRedactor = ((Wreath.Controls.MainForm.MainPart)(target));
            return;
            case 2:
            
            #line 25 "..\..\..\..\..\Controls\MainForm\MainPart.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Back);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CurrentHeaders = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.TableHeader = ((System.Windows.Data.Binding)(target));
            return;
            case 5:
            this.TableViewControl = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.AllRecords = ((System.Windows.Data.Binding)(target));
            return;
            case 7:
            this.CountRecords = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            
            #line 141 "..\..\..\..\..\Controls\MainForm\MainPart.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UnMarkRows);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 153 "..\..\..\..\..\Controls\MainForm\MainPart.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DropRows);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

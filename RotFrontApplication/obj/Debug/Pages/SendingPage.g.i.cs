﻿#pragma checksum "..\..\..\Pages\SendingPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7B2C6A9550861206909F84728F4A85CE5380DD99356A239578187E6E0CCAB758"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using RotFrontApplication.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace RotFrontApplication.Pages {
    
    
    /// <summary>
    /// SendingPage
    /// </summary>
    public partial class SendingPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\Pages\SendingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TxbNumber;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Pages\SendingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TxbAddress;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Pages\SendingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBack;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Pages\SendingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSendEnd;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RotFrontApplication;component/pages/sendingpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\SendingPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TxbNumber = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.TxbAddress = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.BtnBack = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\Pages\SendingPage.xaml"
            this.BtnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnSendEnd = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\Pages\SendingPage.xaml"
            this.BtnSendEnd.Click += new System.Windows.RoutedEventHandler(this.BtnSendEnd_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\..\..\Windows\Edit\EditOperationWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "011512FA0D5B3F6DF38C8637920ADA858FA8A0EF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Bank;
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


namespace Bank {
    
    
    /// <summary>
    /// EditOperationWindow
    /// </summary>
    public partial class EditOperationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\..\Windows\Edit\EditOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteBtn;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\..\Windows\Edit\EditOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Bank;V1.0.0.0;component/windows/edit/editoperationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Windows\Edit\EditOperationWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.DeleteBtn = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\..\..\Windows\Edit\EditOperationWindow.xaml"
            this.DeleteBtn.Click += new System.Windows.RoutedEventHandler(this.DeleteBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ExitBtn = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\..\..\Windows\Edit\EditOperationWindow.xaml"
            this.ExitBtn.Click += new System.Windows.RoutedEventHandler(this.ExitBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


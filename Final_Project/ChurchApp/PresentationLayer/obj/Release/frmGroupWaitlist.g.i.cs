﻿#pragma checksum "..\..\frmGroupWaitlist.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BF52A41A96304E5E18CB82B2ADB23156D1077670"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PresentationLayer;
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


namespace PresentationLayer {
    
    
    /// <summary>
    /// frmGroupWaitlist
    /// </summary>
    public partial class frmGroupWaitlist : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\frmGroupWaitlist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgGroupWaitlist;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\frmGroupWaitlist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\frmGroupWaitlist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnApprove;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\frmGroupWaitlist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeny;
        
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
            System.Uri resourceLocater = new System.Uri("/PresentationLayer;component/frmgroupwaitlist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\frmGroupWaitlist.xaml"
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
            this.dgGroupWaitlist = ((System.Windows.Controls.DataGrid)(target));
            
            #line 17 "..\..\frmGroupWaitlist.xaml"
            this.dgGroupWaitlist.AutoGeneratedColumns += new System.EventHandler(this.DgGroupWaitlist_AutoGeneratedColumns);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\frmGroupWaitlist.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnApprove = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\frmGroupWaitlist.xaml"
            this.btnApprove.Click += new System.Windows.RoutedEventHandler(this.BtnApprove_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnDeny = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\frmGroupWaitlist.xaml"
            this.btnDeny.Click += new System.Windows.RoutedEventHandler(this.BtnDeny_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


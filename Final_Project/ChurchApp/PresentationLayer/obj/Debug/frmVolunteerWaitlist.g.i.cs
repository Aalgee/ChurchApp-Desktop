﻿#pragma checksum "..\..\frmVolunteerWaitlist.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "90DBE85462075B811061AD29A5323E6987DC7A507538B55BE15C09E62984FF94"
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
    /// frmVolunteerWaitlist
    /// </summary>
    public partial class frmVolunteerWaitlist : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\frmVolunteerWaitlist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgVolunteerWaitlist;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\frmVolunteerWaitlist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\frmVolunteerWaitlist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnApprove;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\frmVolunteerWaitlist.xaml"
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
            System.Uri resourceLocater = new System.Uri("/PresentationLayer;component/frmvolunteerwaitlist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\frmVolunteerWaitlist.xaml"
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
            this.dgVolunteerWaitlist = ((System.Windows.Controls.DataGrid)(target));
            
            #line 18 "..\..\frmVolunteerWaitlist.xaml"
            this.dgVolunteerWaitlist.AutoGeneratedColumns += new System.EventHandler(this.DgVolunteerWaitlist_AutoGeneratedColumns);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\frmVolunteerWaitlist.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnApprove = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\frmVolunteerWaitlist.xaml"
            this.btnApprove.Click += new System.Windows.RoutedEventHandler(this.BtnApprove_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnDeny = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\frmVolunteerWaitlist.xaml"
            this.btnDeny.Click += new System.Windows.RoutedEventHandler(this.BtnDeny_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


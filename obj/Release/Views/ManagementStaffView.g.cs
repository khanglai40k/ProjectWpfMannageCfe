﻿#pragma checksum "..\..\..\Views\ManagementStaffView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "73821515F1CF8431BD1546F5C6919BC303032AE139EABFA64663A32512D8A7C6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace QuanLiCaphe.Views {
    
    
    /// <summary>
    /// ManagementStaffView
    /// </summary>
    public partial class ManagementStaffView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\Views\ManagementStaffView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal QuanLiCaphe.Views.ManagementStaffView StaffManagementUserControl;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Views\ManagementStaffView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmployeeName;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Views\ManagementStaffView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUsername;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Views\ManagementStaffView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Views\ManagementStaffView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbPosition;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Views\ManagementStaffView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSalary;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Views\ManagementStaffView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgEmployees;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLiCaphe;component/views/managementstaffview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ManagementStaffView.xaml"
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
            this.StaffManagementUserControl = ((QuanLiCaphe.Views.ManagementStaffView)(target));
            return;
            case 2:
            this.txtEmployeeName = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\Views\ManagementStaffView.xaml"
            this.txtEmployeeName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtEmployeeName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            this.cmbPosition = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.txtSalary = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 56 "..\..\..\Views\ManagementStaffView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddStaff_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 57 "..\..\..\Views\ManagementStaffView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateStaff_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 58 "..\..\..\Views\ManagementStaffView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteStaff_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.dgEmployees = ((System.Windows.Controls.DataGrid)(target));
            
            #line 62 "..\..\..\Views\ManagementStaffView.xaml"
            this.dgEmployees.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgEmployees_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


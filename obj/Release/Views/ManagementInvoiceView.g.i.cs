﻿#pragma checksum "..\..\..\Views\ManagementInvoiceView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E46E6617CD9F8EFBC73F5A7DE925402CE41B6B076908FF7233E4C5F222CC6EF2"
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
    /// ManagementInvoiceView
    /// </summary>
    public partial class ManagementInvoiceView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\Views\ManagementInvoiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal QuanLiCaphe.Views.ManagementInvoiceView InvoiceManagementUserControl;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Views\ManagementInvoiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbTables;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Views\ManagementInvoiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgBills;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Views\ManagementInvoiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgBillDetails;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Views\ManagementInvoiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image qrCodeImage;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLiCaphe;component/views/managementinvoiceview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ManagementInvoiceView.xaml"
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
            this.InvoiceManagementUserControl = ((QuanLiCaphe.Views.ManagementInvoiceView)(target));
            return;
            case 2:
            this.cbTables = ((System.Windows.Controls.ComboBox)(target));
            
            #line 14 "..\..\..\Views\ManagementInvoiceView.xaml"
            this.cbTables.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbTables_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dgBills = ((System.Windows.Controls.DataGrid)(target));
            
            #line 19 "..\..\..\Views\ManagementInvoiceView.xaml"
            this.dgBills.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DgBills_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\Views\ManagementInvoiceView.xaml"
            this.dgBills.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.DgBills_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 26 "..\..\..\Views\ManagementInvoiceView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddFood_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 27 "..\..\..\Views\ManagementInvoiceView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditFood_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 28 "..\..\..\Views\ManagementInvoiceView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteFood_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dgBillDetails = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.qrCodeImage = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            
            #line 51 "..\..\..\Views\ManagementInvoiceView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PayBill_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


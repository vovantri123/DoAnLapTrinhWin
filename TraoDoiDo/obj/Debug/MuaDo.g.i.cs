﻿#pragma checksum "..\..\MuaDo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8EA0D9A23FB3A89C5611D8D518F98707186726C5B4E3BAE20A65CCF0E32AB5E1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using TraoDoiDo;


namespace TraoDoiDo {
    
    
    /// <summary>
    /// MuaDo
    /// </summary>
    public partial class MuaDo : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 99 "..\..\MuaDo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel wpnlHienThi;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\MuaDo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lsvList;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\MuaDo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnThanhToan;
        
        #line default
        #line hidden
        
        
        #line 235 "..\..\MuaDo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgChoNguoiBanXacNhan;
        
        #line default
        #line hidden
        
        
        #line 325 "..\..\MuaDo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgChoGiaoHang;
        
        #line default
        #line hidden
        
        
        #line 416 "..\..\MuaDo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgDaNhan;
        
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
            System.Uri resourceLocater = new System.Uri("/TraoDoiDo;component/muado.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MuaDo.xaml"
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
            
            #line 21 "..\..\MuaDo.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.wpnlHienThi = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 3:
            this.lsvList = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.btnThanhToan = ((System.Windows.Controls.Button)(target));
            
            #line 185 "..\..\MuaDo.xaml"
            this.btnThanhToan.Click += new System.Windows.RoutedEventHandler(this.btnThanhToan_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dgChoNguoiBanXacNhan = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.dgChoGiaoHang = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.dgDaNhan = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 4:
            
            #line 134 "..\..\MuaDo.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.SelectAllCheckBox_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}


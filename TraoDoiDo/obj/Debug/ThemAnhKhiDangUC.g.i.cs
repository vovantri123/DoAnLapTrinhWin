﻿#pragma checksum "..\..\ThemAnhKhiDangUC.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1A945CD9204F93C1EE7B6F14257514A3E00AF23201CC2933BA28B06F7F3BAE07"
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
    /// ThemAnhKhiDangUC
    /// </summary>
    public partial class ThemAnhKhiDangUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\ThemAnhKhiDangUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtbDuongDanAnh;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\ThemAnhKhiDangUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtbTenFileAnh;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\ThemAnhKhiDangUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgAnhSP;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\ThemAnhKhiDangUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnChonAnh;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\ThemAnhKhiDangUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnXoaAnh;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\ThemAnhKhiDangUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon btnHuyAnh;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\ThemAnhKhiDangUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbMoTa;
        
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
            System.Uri resourceLocater = new System.Uri("/TraoDoiDo;component/themanhkhidanguc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ThemAnhKhiDangUC.xaml"
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
            this.txtbDuongDanAnh = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.txtbTenFileAnh = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.imgAnhSP = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.btnChonAnh = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\ThemAnhKhiDangUC.xaml"
            this.btnChonAnh.Click += new System.Windows.RoutedEventHandler(this.btnChonAnh_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnXoaAnh = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\ThemAnhKhiDangUC.xaml"
            this.btnXoaAnh.Click += new System.Windows.RoutedEventHandler(this.btnXoaAnh_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnHuyAnh = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 7:
            this.txtbMoTa = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


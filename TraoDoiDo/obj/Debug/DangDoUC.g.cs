﻿#pragma checksum "..\..\DangDoUC.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "70480F1311A3D79B341ED72C404BC8D0E269304CF43173AA9D6795B0A42511C4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LiveCharts.Wpf;
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
    /// DangDoUC
    /// </summary>
    public partial class DangDoUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 11 "..\..\DangDoUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal TraoDoiDo.DangDoUC dangDoUC;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\DangDoUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnThemSanPhamMoi;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\DangDoUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbTimKiem;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\DangDoUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lsvQuanLySanPham;
        
        #line default
        #line hidden
        
        
        #line 248 "..\..\DangDoUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lsvChoDongGoi;
        
        #line default
        #line hidden
        
        
        #line 357 "..\..\DangDoUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lsvDangGiao;
        
        #line default
        #line hidden
        
        
        #line 457 "..\..\DangDoUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lsvDaGiao;
        
        #line default
        #line hidden
        
        
        #line 557 "..\..\DangDoUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lsvDonHangBiHoanTra;
        
        #line default
        #line hidden
        
        
        #line 832 "..\..\DangDoUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.PieChart pieChart;
        
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
            System.Uri resourceLocater = new System.Uri("/TraoDoiDo;component/dangdouc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DangDoUC.xaml"
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
            this.dangDoUC = ((TraoDoiDo.DangDoUC)(target));
            return;
            case 2:
            this.btnThemSanPhamMoi = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\DangDoUC.xaml"
            this.btnThemSanPhamMoi.Click += new System.Windows.RoutedEventHandler(this.btnThemSanPhamMoi_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txbTimKiem = ((System.Windows.Controls.TextBox)(target));
            
            #line 110 "..\..\DangDoUC.xaml"
            this.txbTimKiem.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txbTiemKiem_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lsvQuanLySanPham = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.lsvChoDongGoi = ((System.Windows.Controls.ListView)(target));
            return;
            case 10:
            this.lsvDangGiao = ((System.Windows.Controls.ListView)(target));
            return;
            case 12:
            this.lsvDaGiao = ((System.Windows.Controls.ListView)(target));
            return;
            case 14:
            this.lsvDonHangBiHoanTra = ((System.Windows.Controls.ListView)(target));
            return;
            case 16:
            this.pieChart = ((LiveCharts.Wpf.PieChart)(target));
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
            case 5:
            
            #line 183 "..\..\DangDoUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnSuaDo_Click);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 192 "..\..\DangDoUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnXoa_Click);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 303 "..\..\DangDoUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnDiaChiGuiHang_Click);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 312 "..\..\DangDoUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnGuiHang_Click);
            
            #line default
            #line hidden
            break;
            case 11:
            
            #line 412 "..\..\DangDoUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnDiaChiGuiHang_Click);
            
            #line default
            #line hidden
            break;
            case 13:
            
            #line 512 "..\..\DangDoUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnDiaChiGuiHang_Click);
            
            #line default
            #line hidden
            break;
            case 15:
            
            #line 612 "..\..\DangDoUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnDiaChiGuiHang_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}


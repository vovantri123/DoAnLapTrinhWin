﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TraoDoiDo.Models;
using TraoDoiDo.ViewModels;


namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NguoiDung nguoi = new NguoiDung();
        public MainWindow()
        {
            InitializeComponent(); 
        }

        public MainWindow(NguoiDung nguoiDung)
        {
            nguoi = nguoiDung;
            InitializeComponent();
            TrangChu_Click(Owner, new RoutedEventArgs());
            Loaded += MainWindow_Loaded;
            ucThanhDieuKhien.btn_close.Click += HienThiDangNhap;
            if(nguoiDung.Id == "0")
            {
                lviMuaDo.Visibility = Visibility.Collapsed;
                lviDangDo.Visibility = Visibility.Collapsed;
                lviViTien.Visibility = Visibility.Collapsed;
            }    
            else
                lviQuanLy.Visibility = Visibility.Collapsed;

        }
         
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_contacts.Visibility = Visibility.Collapsed;
                tt_messages.Visibility = Visibility.Collapsed;
                tt_maps.Visibility = Visibility.Collapsed;
                tt_settings.Visibility = Visibility.Collapsed;
                tt_signout.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_contacts.Visibility = Visibility.Visible;
                tt_messages.Visibility = Visibility.Visible;
                tt_maps.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
                tt_signout.Visibility = Visibility.Visible;
            }
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        { 
            lopPhu.Visibility = Visibility.Collapsed;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        { 
            lopPhu.Visibility = Visibility.Visible;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void MainWindow_MuaDoTuUCGoi(object sender, MuaDoUC.ThamSoThayDoi e)
        {
            txtbTienNguoiDung.Text = Convert.ToDouble(e.SoTienMoi).ToString("#,##0") + " đ";
        }

        private void MuaDo_Click(object sender, RoutedEventArgs e)
        {
            MuaDoUC md = new MuaDoUC(nguoi);
            md.SuKienGoiChaKhiTienNguoiDungThayDoi += MainWindow_MuaDoTuUCGoi;
            contentControlHienThi.Content = md;
            txtbTenTrang.Text = "Mua đồ";
            Tg_Btn.IsChecked = false;
        }

        private void DangDo_Click(object sender, RoutedEventArgs e)
        {
            contentControlHienThi.Content = new DangDoUC(nguoi);
            txtbTenTrang.Text = "Đăng đồ";
            Tg_Btn.IsChecked = false;
        }
        private void TrangChu_Click(object sender, RoutedEventArgs e)
        {
            contentControlHienThi.Content = new TrangChuUC(nguoi.Id);
            txtbTenTrang.Text = "Trang chủ";
            Tg_Btn.IsChecked = false;
        }

        private void MainWindow_ViDienTuUCGoi(object sender, ViDienTuUC.ThamSoThayDoi e)
        {
            txtbTienNguoiDung.Text = Convert.ToDouble(e.SoTienMoi).ToString("#,##0") + " đ";
        }

        private void ViDienTu_Click(object sender, RoutedEventArgs e)
        {
            ViDienTuUC vdt = new ViDienTuUC(nguoi);
            vdt.SuKienGoiChaKhiTienNguoiDungThayDoi += MainWindow_ViDienTuUCGoi;
            contentControlHienThi.Content = vdt;
            txtbTenTrang.Text = "Ví điện tử";
            Tg_Btn.IsChecked = false;
        }

        private void ThongTinCaNhan_Click(object sender, RoutedEventArgs e)
        {
            contentControlHienThi.Content = new ThongTinCaNhanUC(nguoi);
            txtbTenTrang.Text = "Thông tin cá nhân";
            Tg_Btn.IsChecked = false;
        }
         
        private void QuanLy_Click(object sender, RoutedEventArgs e)
        {
            contentControlHienThi.Content = new QuanLyUC(nguoi);
            txtbTenTrang.Text = "Quản lý";
            Tg_Btn.IsChecked = false;
        }

        private void Thoat_Click(object sender, RoutedEventArgs e)
        {
            Thoat f = new Thoat();
            f.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            f.ShowDialog();
            Tg_Btn.IsChecked = false;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadWindow();
            imgNguoiDung.Source = new BitmapImage(new Uri(XuLyAnh.layDuongDanDayDuToiFileAnhDaiDien(nguoi.Anh)));
        }

        public void LoadWindow()
        {
            txtbTenNguoiDung.Text = nguoi.HoTen; 
            txtbTienNguoiDung.Text = Convert.ToDouble(nguoi.Tien).ToString("#,##0") + " đ";
        }
          
        private void btnHienThiThongBao_Click(object sender, RoutedEventArgs e)
        {
            if (myPopup.IsOpen)
                myPopup.IsOpen = false;
            else
                myPopup.IsOpen = true;
        }
        

        private void HienThiDangNhap(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Show();
        }
    }
}

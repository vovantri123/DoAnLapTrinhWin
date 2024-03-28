using System;
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
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using MaterialDesignThemes.Wpf;
using TraoDoiDo.Models;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for TrangChu.xaml
    /// </summary>
    public partial class NguoiDung : Window
    {
        private KhachHang kh;
        public NguoiDung()
        {
            InitializeComponent();
            TrangChu_Click(Owner, new RoutedEventArgs());
        }
        public NguoiDung(KhachHang nguoiDung)
        {
            InitializeComponent();
            TrangChu_Click(Owner, new RoutedEventArgs());
            kh = nguoiDung;
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
            //img_bg.Opacity = 1;
            lopPhu.Visibility = Visibility.Collapsed;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            //img_bg.Opacity = 0.3;
            lopPhu.Visibility = Visibility.Visible;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void DangDo_Click(object sender, RoutedEventArgs e)
        {
            contentControlHienThi.Content = new DangDoUC();
            txtbTenTrang.Text = "Đăng đồ";
        }
        private void TrangChu_Click(object sender, RoutedEventArgs e)
        {
            contentControlHienThi.Content = new TrangChuUC();
            txtbTenTrang.Text = "Trang chủ";
        }

        private void ViDienTu_Click(object sender, RoutedEventArgs e)
        {
            contentControlHienThi.Content = new ViDienTuUC(kh);
            txtbTenTrang.Text = "Ví điện tử";
        }

        private void ThongTinCaNhan_Click(object sender, RoutedEventArgs e)
        {
            contentControlHienThi.Content = new ThongTinCaNhanUC(kh);
            txtbTenTrang.Text = "Thông tin cá nhân";
        }

        private void MuaDo_Click(object sender, RoutedEventArgs e)
        {
            contentControlHienThi.Content = new MuaDoUC();
            txtbTenTrang.Text = "Mua đồ";
        }

        private void QuanLy_Click(object sender, RoutedEventArgs e)
        {
            contentControlHienThi.Content = new QuanLyUC();
            txtbTenTrang.Text = "Quản lý";
        }

        private void Thoat_Click(object sender, RoutedEventArgs e)
        {
            Thoat f = new Thoat();
            f.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            f.ShowDialog();
        }

    }
}

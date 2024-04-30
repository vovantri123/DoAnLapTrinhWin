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
            TrangChu_Click(Owner, new RoutedEventArgs());
            Loaded += mainWindow_Loaded;
        }
        public MainWindow(NguoiDung nguoiDung)
        {
            nguoi = nguoiDung;
            InitializeComponent();
            TrangChu_Click(Owner, new RoutedEventArgs());
            Loaded += mainWindow_Loaded;
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

        private void ViDienTu_Click(object sender, RoutedEventArgs e)
        {
            contentControlHienThi.Content = new ViDienTuUC(nguoi);
            txtbTenTrang.Text = "Ví điện tử";
            Tg_Btn.IsChecked = false;
        }

        private void ThongTinCaNhan_Click(object sender, RoutedEventArgs e)
        {
            contentControlHienThi.Content = new ThongTinCaNhanUC(nguoi);
            txtbTenTrang.Text = "Thông tin cá nhân";
            Tg_Btn.IsChecked = false;
        }

        private void MuaDo_Click(object sender, RoutedEventArgs e)
        {

            contentControlHienThi.Content = new MuaDoUC(nguoi);
            txtbTenTrang.Text = "Mua đồ";
            Tg_Btn.IsChecked = false;
        }

        private void QuanLy_Click(object sender, RoutedEventArgs e)
        {
            contentControlHienThi.Content = new QuanLyUC();
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

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadWindow();
            imgNguoiDung.Source = new BitmapImage(new Uri(XuLyAnh.layDuongDanDayDuToiFileAnhDaiDien(nguoi.Anh)));
        }
        public void LoadWindow()
        {
            txtbTenNguoiDung.Text = nguoi.HoTen;
            txtbTienNguoiDung.Text = DinhDangTien(Convert.ToDecimal(nguoi.Tien)) + " đ";
        }
        private void btnHienThiThongBao_Click(object sender, RoutedEventArgs e)
        {
            if (myPopup.IsOpen)
                myPopup.IsOpen = false;
            else
                myPopup.IsOpen = true;
        }
        private static string DinhDangTien(decimal t)
        {
            return t.ToString("#,0");
        }
    }
}

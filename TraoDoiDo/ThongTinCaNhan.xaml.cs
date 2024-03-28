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
using TraoDoiDo.Models;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for ThongTinCaNhan.xaml
    /// </summary>
    public partial class ThongTinCaNhan : Window
    {
        KhachHang ngDung = new KhachHang();
        public ThongTinCaNhan()
        {
            InitializeComponent();
            Loaded += FThongTinCaNhan_Loaded;
        }
        public ThongTinCaNhan(KhachHang nguoiDung)
        {
            InitializeComponent();
            ngDung = nguoiDung;
        }

        private void FThongTinCaNhan_Loaded(object sender, RoutedEventArgs e)
        {
            txtHoTen.Text = ngDung.HoTen;
            txtSdt.Text = ngDung.Sdt;
            txtCmnd.Text = ngDung.Cmnd;
            txtDiaChi.Text = ngDung.DiaChi;
            txtEmail.Text = ngDung.Email;
            txtId.Text = ngDung.Id;
            txtTenDangNhap.Text = ngDung.TaiKhoan.TenDangNhap;
            txtMatKhau.Password = ngDung.TaiKhoan.MatKhau;
        }
    }
}

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
using TraoDoiDo.Database;
using TraoDoiDo.Models;
using TraoDoiDo.ViewModels;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        private TaiKhoanDao tkDao = new TaiKhoanDao();
        private KhacHangDao khDao = new KhacHangDao();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            TaiKhoan taiKhoan = new TaiKhoan(txtTenDangNhap.Text, txtMatKhau.Password.ToString(), null);
            TaiKhoan taiKhoanMoi = tkDao.TimKiemBangTen(taiKhoan.TenDangNhap);
            List<string> listNguoiDung = khDao.TimKiemBangTenDangNhap(taiKhoan.TenDangNhap);
            string tienNguoiDung = khDao.TimKiemTienBangId(taiKhoanMoi.IDNguoiDung);
            KhachHang kh = new KhachHang(taiKhoanMoi.IDNguoiDung, listNguoiDung[0], listNguoiDung[2].ToString(), listNguoiDung[4].ToString(), listNguoiDung[1].ToString(), listNguoiDung[6].ToString(), listNguoiDung[3].ToString(), listNguoiDung[5].ToString(), listNguoiDung[7].ToString(), taiKhoanMoi, tienNguoiDung);
            if (taiKhoanMoi == null || !string.Equals(taiKhoan.MatKhau, taiKhoanMoi.MatKhau))
            {
                MessageBox.Show("Tài khoản sai! Vui lòng đăng nhập lại");
                return;
            }
            else
            {
                //MessageBox.Show("Đăng nhập thành công");
                //this.Hide();
                NguoiDung f = new NguoiDung(kh);
                f.Show();
            }
        }

        private void btnDangKy_Click(object sender, RoutedEventArgs e)
        {
            DangKy dangKy = new DangKy();
            dangKy.Show();
        }

        private void btnQuenMatKhau_Click(object sender, RoutedEventArgs e)
        {

        }
        private void txtQuenMatKhau_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            QuenMatKhau quenMK = new QuenMatKhau();
            quenMK.Show();
        }
    }
}

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
    /// Interaction logic for DangKy.xaml
    /// </summary>
    public partial class DangKy : Window
    {
        ThongTinKhachHangViewModel thongTinKH = new ThongTinKhachHangViewModel();
        public DangKy(ThongTinKhachHangViewModel thongTin)
        {
            InitializeComponent();
            thongTin = new ThongTinKhachHangViewModel();
            thongTinKH = thongTin;
            this.DataContext = thongTin;
        }

        private void btnDangKy_Click(object sender, RoutedEventArgs e)
        {
            TaiKhoan tk = new TaiKhoan();
            TaiKhoanDao tkDao = new TaiKhoanDao();
            KhachHang khachHang = new KhachHang(tkDao.TaoID(tk),thongTinKH.HoTen,thongTinKH.GioiTinh,thongTinKH.NgaySinh,thongTinKH.CMND,thongTinKH.Email,thongTinKH.SDT,thongTinKH.DiaChi,thongTinKH.Anh);
            KhacHangDao khachHangDao = new KhacHangDao();
            khachHangDao.Them(khachHang);
        }
    }
}

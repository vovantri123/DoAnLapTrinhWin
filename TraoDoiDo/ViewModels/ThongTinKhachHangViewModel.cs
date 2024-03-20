using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraoDoiDo.Models;
using TraoDoiDo.Database;
using System.Windows;

namespace TraoDoiDo.ViewModels
{
    public class ThongTinKhachHangViewModel : ThuocTinhViewModel
    {
        private KhachHang khachHang = new KhachHang();

        public KhachHang KhachHangThongTin { get => khachHang; set => khachHang = value; }

        public string TenDangNhap { get => khachHang.TaiKhoan.TenDangNhap; set { khachHang.TaiKhoan.TenDangNhap = value; OnPropertyChanged(); } }
        public string MatKhau { get => khachHang.TaiKhoan.MatKhau; set { khachHang.TaiKhoan.MatKhau = value; OnPropertyChanged(); } }
        public string HoTen { get => khachHang.HoTen; set { khachHang.HoTen = value; OnPropertyChanged(); } }
        public string GioiTinh { get => khachHang.GioiTinh; set { khachHang.GioiTinh = value; OnPropertyChanged(); } }
        public DateTime NgaySinh { get => khachHang.NgaySinh; set { khachHang.NgaySinh = value; OnPropertyChanged(); } }
        public string SDT { get => khachHang.Sdt; set { khachHang.Sdt = value; OnPropertyChanged(); } }
        public string CMND { get => khachHang.Cmnd; set { khachHang.Cmnd = value; OnPropertyChanged(); } }
        public string Email { get => khachHang.Email; set { khachHang.Email = value; OnPropertyChanged(); } }
        public string DiaChi { get => khachHang.DiaChi; set { khachHang.DiaChi = value; OnPropertyChanged(); } }
        public string Anh { get => khachHang.Anh; set { khachHang.Anh = value; OnPropertyChanged(); } }

        public ThongTinKhachHangViewModel()
        {

        }

    }
}

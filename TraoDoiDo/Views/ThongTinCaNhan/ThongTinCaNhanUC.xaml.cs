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
using TraoDoiDo.Database;
using TraoDoiDo.Models;
using Microsoft.Win32;
using TraoDoiDo.ViewModels;
using System.IO;
namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for ThongTinCaNhanUC.xaml
    /// </summary>
    public partial class ThongTinCaNhanUC : UserControl
    {
        NguoiDung nguoiDung;
        TaiKhoan taiKhoan;

        NguoiDungDao nguoiDungDao = new NguoiDungDao();
        TaiKhoanDao tkDao = new TaiKhoanDao();

        public ThongTinCaNhanUC()
        {
            InitializeComponent();
        }

        public ThongTinCaNhanUC(NguoiDung nguoi)
        {
            InitializeComponent();
            this.DataContext = this;
            Loaded += UCThongTinCaNhan_Loaded;
            this.nguoiDung = nguoiDungDao.TimNguoiBangIdNguoi(nguoi.Id);
        }

        private void UCThongTinCaNhan_Loaded(object sender, RoutedEventArgs e)
        {
            LoadThongTin(nguoiDung);
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            taiKhoan = new TaiKhoan(txtTenDangNhap.Text, txtMatKhau.Password, txtId.Text);

            string tenAnh = XuLyAnh.layDuongDanDayDuToiFileAnhDaiDien(imageHinhDaiDien.Source.ToString());
            string tenFileAnh = Path.GetFileName(tenAnh);
            nguoiDung = new NguoiDung(txtId.Text, txtHoTen.Text, cbGioiTinh.Text, dtpNgaySinh.Text, txtCmnd.Text, txtEmail.Text, txtSdt.Text, txtDiaChi.Text, tenFileAnh, taiKhoan, "0");

            if (nguoiDung.kiemTraCacTextBox())
            {
                nguoiDungDao.CapNhat(nguoiDung);
                MessageBox.Show("Cập nhật thành công");
            }
        }

        private void btnDoiMatKhau_Click(object sender, RoutedEventArgs e)
        {
            taiKhoan = new TaiKhoan(txtTenDangNhap.Text, txtMatKhau.Password, txtId.Text);
            if (taiKhoan.kiemTraCacTextBox())
            {
                tkDao.CapNhat(taiKhoan);
                MessageBox.Show("Đổi mật khẩu thành công");
            }
        }

        private void btnChonAnh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image files(*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files(*.*)|*.*";
            if (file.ShowDialog() == true)
            {
                string imagePath = file.FileName;
                BitmapImage hinh = new BitmapImage(new Uri(imagePath));
                imageHinhDaiDien.Source = hinh;
            }
        }

        private void LoadThongTin(NguoiDung nguoi)
        {
            txtHoTen.Text = nguoi.HoTen;
            txtCmnd.Text = nguoi.Cmnd;
            txtDiaChi.Text = nguoi.DiaChi;
            txtId.Text = nguoi.Id;
            txtSdt.Text = nguoi.Sdt;
            txtTenDangNhap.Text = nguoi.TaiKhoan.TenDangNhap;
            txtMatKhau.Password = nguoi.TaiKhoan.MatKhau;
            txtEmail.Text = nguoi.Email;
            cbGioiTinh.Text = nguoi.GioiTinh;

            string selectedDate = nguoi.NgaySinh;
            dtpNgaySinh.Text = selectedDate;

            imageHinhDaiDien.Source = new BitmapImage(new Uri(XuLyAnh.layDuongDanDayDuToiFileAnhDaiDien(nguoi.Anh)));
        }
    }
}

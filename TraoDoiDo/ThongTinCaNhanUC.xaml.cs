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
        NguoiDung kh = new NguoiDung();
        NguoiDungDao nguoiDungDao = new NguoiDungDao();
        NguoiDung ngDung = new NguoiDung();
        TaiKhoan taiKhoan = new TaiKhoan();
        NguoiDung nguoi = new NguoiDung();
        TaiKhoanDao tkDao = new TaiKhoanDao();
        int count = 0;
        public ThongTinCaNhanUC()
        {
            InitializeComponent();
            this.DataContext = this;
            Loaded += UCThongTinCaNhan_Loaded;
        }
        public ThongTinCaNhanUC(NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.DataContext = this;
            Loaded += UCThongTinCaNhan_Loaded;
            kh = nguoiDung;

        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UCThongTinCaNhan_Loaded(object sender, RoutedEventArgs e)
        {
            taiKhoan = tkDao.TimKiemBangId(kh.Id);
            ngDung = nguoiDungDao.TimKiemBangId(kh.Id);
            nguoi = new NguoiDung(ngDung.Id, ngDung.HoTen, ngDung.GioiTinh, ngDung.NgaySinh, ngDung.Cmnd, ngDung.Email, ngDung.Sdt, ngDung.DiaChi, ngDung.Anh, taiKhoan, "0");
            LoadThongTin(nguoi);
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            TaiKhoan taiKhoan = new TaiKhoan(txtTenDangNhap.Text, txtMatKhau.Password, txtId.Text);

            string tenAnh = XuLyAnh.layDuongDanDayDuToiFileAnhDaiDien(imageHinhDaiDien.Source.ToString());
            string tenFileAnh = Path.GetFileName(tenAnh);
            nguoi = new NguoiDung(txtId.Text, txtHoTen.Text, cbGioiTinh.Text, dtpNgaySinh.Text, txtCmnd.Text, txtEmail.Text, txtSdt.Text, txtDiaChi.Text, tenFileAnh, taiKhoan, "0");

            if (nguoi.kiemTraCacTextBox())
            {
                nguoiDungDao.CapNhat(nguoi);
                MessageBox.Show("Cập nhật thành công");
                LoadThongTin(nguoi);
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
            chonAnh();
        }
        private void LoadThongTin(NguoiDung kh)
        {
            txtHoTen.Text = kh.HoTen;
            txtCmnd.Text = kh.Cmnd;
            txtDiaChi.Text = kh.DiaChi;
            txtId.Text = kh.Id;
            txtSdt.Text = kh.Sdt;
            txtTenDangNhap.Text = kh.TaiKhoan.TenDangNhap;
            txtMatKhau.Password = kh.TaiKhoan.MatKhau;
            txtEmail.Text = kh.Email;
            cbGioiTinh.Text = kh.GioiTinh;

            string selectedDate = kh.NgaySinh;
            dtpNgaySinh.Text = selectedDate;

            imageHinhDaiDien.Source = new BitmapImage(new Uri(XuLyAnh.layDuongDanDayDuToiFileAnhDaiDien(kh.Anh)));
        }
        public void chonAnh()
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
    }
}

using Microsoft.Win32;
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
        public DangKy()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void btnDangKy_Click(object sender, RoutedEventArgs e)
        {
            TaiKhoanDao tkDao = new TaiKhoanDao();
            TaiKhoan taiKhoan = new TaiKhoan(txtTenDangNhap.Text, txtMatKhau.Password, null);
            NguoiDung nguoi = new NguoiDung(null, txtHoTen.Text, cbGioiTinh.Text, dtpNgaySinh.Text, txtCMND.Text, txtEmail.Text, txtSdt.Text, txtDiaChi.Text, txtbTenFileAnh.Text, taiKhoan, "0");
            ThongTinKhachHangViewModel ttkh = new ThongTinKhachHangViewModel(nguoi);
            NguoiDungDao nguoiDao = new NguoiDungDao();
            bool checkThongTinHopLe = ttkh.kiemTraCacTextBox();
            if (checkThongTinHopLe)
            { 
                try
                {
                    nguoiDao.Them(nguoi);
                    tkDao.Them(taiKhoan);
                    XuLyAnh.LuuAnhVaoThuMuc(txtbDuongDanAnh.Text, "HinhDaiDien");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đăng ký thất bại: " + ex.Message);
                }
                MessageBox.Show("Đăng kí thành công");
            }
        }

        private void btnChonAnh_Click(object sender, RoutedEventArgs e) //Chọn để hiển thị chứ chưa có lưu dô folder và csdl
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFileName = openFileDialog.FileName;
                imageDaiDien.Source = new BitmapImage(new Uri(selectedFileName));
                txtbDuongDanAnh.Text = selectedFileName;
                txtbTenFileAnh.Text = System.IO.Path.GetFileName(selectedFileName);


            }
        }
    }
}

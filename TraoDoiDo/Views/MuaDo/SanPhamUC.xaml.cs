using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
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
using TraoDoiDo.Database;
using TraoDoiDo.Models;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for UCSanPham.xaml
    /// </summary>
    public partial class SanPhamUC : UserControl
    {
        public string idNguoiDang;
        public string idNguoiMua; 
        public int yeuThich = 0;
         
        SanPham sp;
        DanhGiaNguoiDang danhGia;
        NguoiDung nguoiDang = new NguoiDung();
        DanhGiaNguoiDangDao danhGiaNgDangDao = new DanhGiaNguoiDangDao();
        SanPhamDao sanPhamDao = new SanPhamDao();
        NguoiDungDao nguoiDao = new NguoiDungDao();

        public SanPhamUC()
        {
            InitializeComponent();
        }

        public SanPhamUC(int yeuThich, string idNguoiMua, string idNguoiDang)
        {
            InitializeComponent();

            this.yeuThich = yeuThich;
            this.idNguoiMua = idNguoiMua;
            this.idNguoiDang = idNguoiDang;
            sp = sanPhamDao.timKiemSanPhamBangIdSanPham(txtbIdSanPham.Text);
             
            if (yeuThich == 0)
            {
                btnThemVaoYeuThich.Visibility = Visibility.Visible;
                btnBoYeuThich.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnThemVaoYeuThich.Visibility = Visibility.Collapsed;
                btnBoYeuThich.Visibility = Visibility.Visible;
            }
            nguoiDang = nguoiDao.TimNguoiBangIdNguoi(idNguoiDang); 
        }
         
         
        private void tangSoLuotXemThem1()
        {  
            try
            {
                string idSanPham = txtbIdSanPham.Text; 
                sanPhamDao.TangLuotXemThem1(idSanPham);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThongTinChiTietSanPham_Click(object sender, MouseButtonEventArgs e)
        { 
            try
            {
                tangSoLuotXemThem1();

                sp = new SanPham(txtbIdSanPham.Text, nguoiDang.Id, txtbTen.Text, sp.LinkAnh, txtbLoai.Text, sp.SoLuong, sp.SoLuongDaBan, txtbGiaGoc.Text, txtbGiaBan.Text, sp.PhiShip, sp.TrangThai, txtbNoiBan.Text, sp.XuatXu, sp.NgayMua, sp.MoTaChung, sp.PhanTramMoi, txtbSoLuotXem.Text, idNguoiMua, sp.NgayDang);
                ThongTinChiTietSanPham f = new ThongTinChiTietSanPham(sp);
                f.idNguoiDang = nguoiDang.Id;
                f.txtbTenNguoiDang.Text = nguoiDang.HoTen; 
                f.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                f.idSanPham = txtbIdSanPham.Text;

                f.idNguoiMua = idNguoiMua;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            
        }

        private void btnThemVaoYeuThich_Click(object sender, RoutedEventArgs e)
        {
            btnThemVaoYeuThich.Visibility = Visibility.Collapsed;
            btnBoYeuThich.Visibility = Visibility.Visible;
            try
            { 
                DanhMucYeuThich danhMuc = new DanhMucYeuThich(idNguoiMua, txtbIdSanPham.Text);
                DanhMucYeuThichDao danhMucDao = new DanhMucYeuThichDao();
                danhMucDao.Them(danhMuc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnBoYeuThich_Click(object sender, RoutedEventArgs e)
        {
            btnBoYeuThich.Visibility = Visibility.Collapsed;
            btnThemVaoYeuThich.Visibility = Visibility.Visible;
            try
            { 
                DanhMucYeuThich danhMuc = new DanhMucYeuThich(idNguoiMua, txtbIdSanPham.Text);
                DanhMucYeuThichDao danhMucDao = new DanhMucYeuThichDao();
                danhMucDao.Xoa(danhMuc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}

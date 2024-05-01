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

        DanhGiaNguoiDangDao danhGiaNgDangDao = new DanhGiaNguoiDangDao();
        SanPhamDao sanPhamDao = new SanPhamDao();

        public SanPhamUC()
        {
            InitializeComponent();
        }

        public SanPhamUC(int yeuThich, string idNguoiMua)
        {
            InitializeComponent();

            this.yeuThich = yeuThich;
            this.idNguoiMua = idNguoiMua;
            sp = sanPhamDao.timKiemSanPhamBangId(txtbIdSanPham.Text);
             
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
        }
         
         
        private void tangSoLuotXemThem1()
        {  
            try
            {
                string idSanPham = txtbIdSanPham.Text;
                int soLuotXem = Convert.ToInt32(sanPhamDao.LayLuotXem(idSanPham));
                sanPhamDao.CapNhatLuotXem(idSanPham, soLuotXem);
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
                danhGia = danhGiaNgDangDao.timTenNguoiDangVaNhanXet(idNguoiDang);

                sp = new SanPham(txtbIdSanPham.Text, idNguoiDang, txtbTen.Text, sp.LinkAnh, txtbLoai.Text, sp.SoLuong, sp.SoLuongDaBan, txtbGiaGoc.Text, txtbGiaBan.Text, sp.PhiShip, sp.TrangThai, txtbNoiBan.Text, sp.XuatXu, sp.NgayMua, sp.MoTaChung, sp.PhanTramMoi, txtbSoLuotXem.Text, idNguoiMua, sp.NgayDang);
                ThongTinChiTietSanPham f = new ThongTinChiTietSanPham(sp);
                f.idNguoiDang = idNguoiDang;
                f.txtbTenNguoiDang.Text = danhGia.TenNguoiDang;
                f.txtbSoLuotDanhGia.Text = danhGia.SoLuotDanhGia;
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

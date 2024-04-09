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
        private string tenNguoiDang;
        private string soLuotDanhGia;
        public int yeuThich = 0;

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        SanPham sanPham = new SanPham();
        SanPhamDao sanPhamDao = new SanPhamDao();
        QuanLyDonHangDao quanLyDonHangDao = new QuanLyDonHangDao();
        List<string> listSP = new List<string>();
        public SanPhamUC(int yeuThich)
        {
            this.yeuThich = yeuThich;
            InitializeComponent();
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
        
        private void FSanPhamUC_Loaded(object sender, RoutedEventArgs e)
        {
            listSP = sanPhamDao.timKiemToanBoBangId(txtbIdSanPham.Text);
            sanPham = new SanPham(listSP[0], listSP[1], listSP[2],listSP[3].ToString(), listSP[4], listSP[5], listSP[6], listSP[7], listSP[8], listSP[9], listSP[10], listSP[11], listSP[12], listSP[13], listSP[15], listSP[14], txtbSoLuotXem.Text);
            idNguoiMua = quanLyDonHangDao.timIdNguoiMua(listSP[1], listSP[0]);
        }
        private void timTenVaSoLuotDanhGiaNguoiDang()
        {
            try
            {
                DanhGiaNguoiDungDao danhGiaNgDungDao = new DanhGiaNguoiDungDao();
                List<string> list = new List<string>();
                list = danhGiaNgDungDao.timTenNguoiDangVaNhanXet(sanPham.IdNguoi);
                tenNguoiDang = list[0].ToString();
                soLuotDanhGia = list[1].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tangSoLuotXemThem1()
        {
            int soLuotXem = 0;
            string idSanPham = txtbIdSanPham.Text;
            try
            {
                //B1 Lấy số lượt xem từ bảng SanPham
                soLuotXem = Convert.ToInt32(sanPhamDao.LayLuotXem(idSanPham));
                //B2 Cập nhật số lượt xem
                sanPhamDao.CapNhatLuotXem(idSanPham, soLuotXem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThongTinChiTietSanPham_Click(object sender, MouseButtonEventArgs e)
        {
            timTenVaSoLuotDanhGiaNguoiDang();
            tangSoLuotXemThem1();
            sanPham = new SanPham(txtbIdSanPham.Text, sanPham.IdNguoi, txtbTen.Text,sanPham.LinkAnh, txtbLoai.Text,sanPham.SoLuong,sanPham.SoLuongDaBan, txtbGiaGoc.Text, txtbGiaBan.Text,sanPham.PhiShip,sanPham.TrangThai, txtbNoiBan.Text,sanPham.XuatXu,sanPham.NgayMua,sanPham.MoTaChung,sanPham.PhanTramMoi,txtbSoLuotXem.Text);
            ThongTinChiTietSanPham f = new ThongTinChiTietSanPham(sanPham);
            f.idNguoiDang = idNguoiDang;
            f.txtbTenNguoiDang.Text = tenNguoiDang;
            f.txtbSoLuotDanhGia.Text = soLuotDanhGia;
            f.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            f.idSanPham = txtbIdSanPham.Text;
            f.idNguoiMua = idNguoiMua;
            f.ShowDialog();
        }

        private void btnThemVaoYeuThich_Click(object sender, RoutedEventArgs e)
        {
            btnThemVaoYeuThich.Visibility = Visibility.Collapsed;
            btnBoYeuThich.Visibility = Visibility.Visible;
            try
            {
                // Câu lệnh SQL INSERT
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
                // Câu lệnh SQL INSERT
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

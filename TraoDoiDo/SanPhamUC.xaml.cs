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
            //sanPham = new SanPham(txtbIdSanPham.Text,idNguoiMua,txtbTen.Text,imgSP.Source.ToString(),txtbLoai.Text,null,null,txtbGiaGoc.Text,txtbGiaBan.Text,null,null,txtbNoiBan.Text,null,null,null,null,txtbSoLuotXem.Text);

        }
        private void timTenVaSoLuotDanhGiaNguoiDang()
        {
            try
            {
                DanhGiaNguoiDungDao danhGiaNgDungDao = new DanhGiaNguoiDungDao();
                List<string> list = new List<string>();
                list = danhGiaNgDungDao.timTenNguoiDangVaNhanXet(idNguoiDang);
                tenNguoiDang = list[0];
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
            sanPham = new SanPham(txtbIdSanPham.Text, idNguoiDang, txtbTen.Text, null, txtbLoai.Text, null, null, txtbGiaGoc.Text, txtbGiaBan.Text, null, null, txtbNoiBan.Text,null,null,null,null,txtbSoLuotXem.Text);
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

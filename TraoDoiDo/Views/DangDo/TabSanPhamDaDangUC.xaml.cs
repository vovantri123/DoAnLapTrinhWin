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
using System.Windows.Shapes;
using TraoDoiDo.Database;
using TraoDoiDo.Models;
using TraoDoiDo.Utilities;
using TraoDoiDo.ViewModels;

namespace TraoDoiDo.Views.DangDo
{
    /// <summary>
    /// Interaction logic for TabQuanLySanPham.xaml
    /// </summary>
    public partial class TabSanPhamDaDangUC : UserControl
    {
        
        List<SanPham> dsSanPham;

        SanPham sanPham;
        NguoiDung nguoiDung;
        MoTaHangHoa moTaHangHoa;

        SanPhamDao sanPhamDao = new SanPhamDao();
        MoTaHangHoaDao moTaDao = new MoTaHangHoaDao();
        QuanLyDonHangDao quanLyDonHangDao = new QuanLyDonHangDao();
        TrangThaiDonHangDao trangThaiHangDao = new TrangThaiDonHangDao();
        DanhGiaNguoiDangDao danhGiaNguoiDungDao = new DanhGiaNguoiDangDao();
        public TabSanPhamDaDangUC()
        {
            InitializeComponent();
        }
        public TabSanPhamDaDangUC(NguoiDung nguoi)
        {
            InitializeComponent();
            Loaded += QuanLySanPham_Load;
            nguoiDung = nguoi;
        }
          
        private void QuanLySanPham_Load(object sender, RoutedEventArgs e) //Form load của Tab1
        {
            HienThi_QuanLySanPham();
        }

        private void HienThi_QuanLySanPham()
        {
            lsvQuanLySanPham.Items.Clear();
            dsSanPham = sanPhamDao.LoadDanhSachSanPhamTheoIdNguoiDang(nguoiDung.Id);
            foreach (var sanPham in dsSanPham)
            {
                string duongDanDayDu = XuLyAnh.layDuongDanDayDuToiFileAnhSanPham(sanPham.LinkAnh);
                lsvQuanLySanPham.Items.Add(new { Id = sanPham.Id, Ten = sanPham.Ten, LinkAnh = duongDanDayDu, Loai = sanPham.Loai, SoLuong = sanPham.SoLuong, SoLuongDaBan = sanPham.SoLuongDaBan, GiaGoc = sanPham.GiaGoc, GiaBan = sanPham.GiaBan, PhiShip = sanPham.PhiShip, NgayDang = sanPham.NgayDang });
            }
        }

        private void btnThemSanPhamMoi_Click(object sender, RoutedEventArgs e)
        {
            DangDo_Dang f = new DangDo_Dang(nguoiDung);

            f.ucThongTin.txtbIdSanPham.Text = (sanPhamDao.timKiemIdMax() + 1).ToString();

            // Load lại lsvQuanLySanPham sau khi (thêm sản phẩm và đóng cái DangDo_Dang)
            f.Closed += (s, ev) =>
            {
                HienThi_QuanLySanPham();
            };
            f.ShowDialog();
        }
          
        private void btnSuaDo_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button; // Lấy button được click 
            ListViewItem dongChuaButton = HoTroTimPhanTu.FindAncestor<ListViewItem>(btn); // Lấy dòng chứa button 
            dynamic duLieuCuaDongChuaButton = dongChuaButton.DataContext; // Lấy dữ liệu của dong

            if (duLieuCuaDongChuaButton != null)
            {
                try
                {
                    //Load thông tin sản phẩm lên 
                    SanPham sp = sanPhamDao.timKiemSanPhamBangIdSanPham(duLieuCuaDongChuaButton.Id);
                    DangDo_Sua f = new DangDo_Sua(sp);
                    List<MoTaHangHoa> dsMoTaHangHoa = moTaDao.TimKiemDanhSachAnhVaMoTaBangId(duLieuCuaDongChuaButton.Id);

                    //Load ảnh và mô tả lên
                    foreach (var dong in dsMoTaHangHoa)
                    {
                        f.DanhSachAnhVaMoTa[f.soLuongAnh] = new ThemAnhKhiDangUC();

                        f.DanhSachAnhVaMoTa[f.soLuongAnh].txtbTenFileAnh.Text = dong.LinkAnh; 

                        string duongDanAnh = XuLyAnh.layDuongDanDayDuToiFileAnhSanPham(dong.LinkAnh);
                        f.DanhSachAnhVaMoTa[f.soLuongAnh].txtbDuongDanAnh.Text = duongDanAnh;

                        f.DanhSachAnhVaMoTa[f.soLuongAnh].imgAnhSP.Source = new BitmapImage(new Uri(duongDanAnh));

                        f.DanhSachAnhVaMoTa[f.soLuongAnh].txtbMoTa.Text = dong.MoTa;

                        f.ucThongTin.wpnlChuaAnh.Children.Add(f.DanhSachAnhVaMoTa[f.soLuongAnh]);
                        f.soLuongAnh++;
                    }
                    f.Closed += (s, ev) =>
                    {
                        HienThi_QuanLySanPham();
                    };
                    f.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button; // Lấy button được click 
            ListViewItem dongChuaButton = HoTroTimPhanTu.FindAncestor<ListViewItem>(btn); // Lấy dòng chứa button 
            dynamic duLieuCuaDongChuaButton = dongChuaButton.DataContext; // Lấy dữ liệu của dong

            if (duLieuCuaDongChuaButton != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa mục đã chọn?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        string idSanPhamMuonXoa = duLieuCuaDongChuaButton.Id;

                        moTaDao.Xoa(idSanPhamMuonXoa);
                        sanPhamDao.Xoa(idSanPhamMuonXoa);

                        MessageBox.Show("Xóa thành công");
                        lsvQuanLySanPham.Items.Remove(duLieuCuaDongChuaButton);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xảy ra khi xóa sản phẩm: " + ex.Message);
                    }
                }
            }
        }
         
        private void txbTiemKiem_TextChanged(object sender, TextChangedEventArgs e)
        { 
            lsvQuanLySanPham.Items.Clear();
            if (txbTimKiem.Text == null)
                HienThi_QuanLySanPham();
                 
            foreach (var sanPham in dsSanPham)
            {
                if(sanPham.Ten.ToLower().Contains(txbTimKiem.Text.Trim().ToLower()))
                {
                    string duongDanDayDu = XuLyAnh.layDuongDanDayDuToiFileAnhSanPham(sanPham.LinkAnh);
                    lsvQuanLySanPham.Items.Add(new { Id = sanPham.Id, Ten = sanPham.Ten, LinkAnh = duongDanDayDu, Loai = sanPham.Loai, SoLuong = sanPham.SoLuong, SoLuongDaBan = sanPham.SoLuongDaBan, GiaGoc = sanPham.GiaGoc, GiaBan = sanPham.GiaBan, PhiShip = sanPham.PhiShip });
                }    
            } 
        }

        private void cbLocLoai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox; 
            lsvQuanLySanPham.Items.Clear();
            string mucDaChon = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();
            if (string.Equals(mucDaChon, "Tất cả"))
                HienThi_QuanLySanPham();
            else
                foreach (var sanPham in dsSanPham)
                    if (sanPham.Loai.ToLower().Contains(mucDaChon.Trim().ToLower()))
                    {
                        string duongDanDayDu = XuLyAnh.layDuongDanDayDuToiFileAnhSanPham(sanPham.LinkAnh);
                        lsvQuanLySanPham.Items.Add(new { Id = sanPham.Id, Ten = sanPham.Ten, LinkAnh = duongDanDayDu, Loai = sanPham.Loai, SoLuong = sanPham.SoLuong, SoLuongDaBan = sanPham.SoLuongDaBan, GiaGoc = sanPham.GiaGoc, GiaBan = sanPham.GiaBan, PhiShip = sanPham.PhiShip });
                    } 
        }

        private void cboSapXep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            try
            {
                lsvQuanLySanPham.Items.Clear();
                string selectedItemContent = (comboBox.SelectedItem as ComboBoxItem).Content.ToString().Trim();
                int index = comboBox.SelectedIndex;
                if (string.Equals(selectedItemContent, "Tất cả"))
                    HienThi_QuanLySanPham();
                else if (index == 0)
                {
                    HienThiNgayMuaLau(true);
                }
                else
                {
                    HienThiNgayMuaLau(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static int TinhKhoangCachSoNgay(DateTime ngay)
        {
            TimeSpan kc = DateTime.Now.Date - ngay.Date;
            return Math.Abs(kc.Days);
        }
        private void HienThiNgayMuaLau(bool kt)
        {
            lsvQuanLySanPham.Items.Clear();
            List<SanPham> dsSanPham = sanPhamDao.LoadDanhSachSanPhamTheoIdNguoiDang(nguoiDung.Id);
            foreach (var sp in dsSanPham)
            {
                int soNgay = TinhKhoangCachSoNgay(DateTime.ParseExact(sp.NgayDang, "d/M/yyyy", null));
                if (kt)
                {
                    if (soNgay < 100)
                    {
                        string linkAnh = sp.LinkAnh;
                        string tenAnh = XuLyAnh.layDuongDanDayDuToiFileAnhSanPham(linkAnh);
                        lsvQuanLySanPham.Items.Add(new { Id = sp.Id, Ten = sp.Ten, LinkAnh = tenAnh, Loai = sp.Loai, SoLuong = sp.SoLuong, SoLuongDaBan = sp.SoLuongDaBan, GiaGoc = sp.GiaGoc, GiaBan = sp.GiaBan, PhiShip = sp.PhiShip, NgayDang = sp.NgayDang });
                    }
                }
                else
                {
                    if (soNgay >= 100)
                    {
                        string linkAnh = sp.LinkAnh;
                        string tenAnh = XuLyAnh.layDuongDanDayDuToiFileAnhSanPham(linkAnh);
                        lsvQuanLySanPham.Items.Add(new { Id = sp.Id, Ten = sp.Ten, LinkAnh = tenAnh, Loai = sp.Loai, SoLuong = sp.SoLuong, SoLuongDaBan = sp.SoLuongDaBan, GiaGoc = sp.GiaGoc, GiaBan = sp.GiaBan, PhiShip = sp.PhiShip, NgayDang = sp.NgayDang });
                    }
                }

            }
        }
    }
} 
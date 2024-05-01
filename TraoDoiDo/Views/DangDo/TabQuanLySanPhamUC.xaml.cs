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
    public partial class TabQuanLySanPhamUC : UserControl
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
        public TabQuanLySanPhamUC()
        {
            InitializeComponent();
        }
        public TabQuanLySanPhamUC(NguoiDung nguoi)
        {
            InitializeComponent();
            Loaded += QuanLySanPham_Load;
            nguoiDung = nguoi;
        }
         
        #region TAB1 QUẢN LÝ SẢN PHẨM
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

            f.ucThongTin.txtbIdSanPham.Text = (timIdMaxTrongBangSanPham() + 1).ToString();

            // Load lại lsvQuanLySanPham sau khi (thêm sản phẩm và đóng cái DangDo_Dang)
            f.Closed += (s, ev) =>
            {
                HienThi_QuanLySanPham();
            };
            f.ShowDialog();
        }

        private int timIdMaxTrongBangSanPham()
        {
            List<List<string>> danhSachId = sanPhamDao.timKiemDanhSachId();
            int maxId = 0;
            foreach (var dong in danhSachId)
            {
                int id = Convert.ToInt32(dong[0]);
                if (maxId < id)
                {
                    maxId = id;
                }
            }
            return maxId;
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
                    SanPham sp = sanPhamDao.timKiemSanPhamBangId(duLieuCuaDongChuaButton.Id);
                    DangDo_Sua f = new DangDo_Sua(sp);
                    List<MoTaHangHoa> dsMoTaHangHoa = moTaDao.TimKiemDanhSachAnhVaMoTaBangId(duLieuCuaDongChuaButton.Id);

                    //Load ảnh và mô tả lên
                    foreach (var dong in dsMoTaHangHoa)
                    {
                        f.DanhSachAnhVaMoTa[f.soLuongAnh] = new ThemAnhKhiDangUC();

                        f.DanhSachAnhVaMoTa[f.soLuongAnh].txtbTenFileAnh.Text = dong.LinkAnh; // Rãnh sửa thuộc tính LinkAnh thành TenFileAnh

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
            try
            {
                lsvQuanLySanPham.Items.Clear();
                if (txbTimKiem.Text == null)
                    HienThi_QuanLySanPham();
                dsSanPham = sanPhamDao.timKiemDanhSachSanPhamTheoTen(txbTimKiem.Text.Trim(), nguoiDung.Id);
                foreach (var sanPham in dsSanPham)
                {
                    string tenAnh = XuLyAnh.layDuongDanDayDuToiFileAnhSanPham(sanPham.LinkAnh);
                    lsvQuanLySanPham.Items.Add(new { Id = sanPham.Id, Ten = sanPham.Ten, LinkAnh = tenAnh, Loai = sanPham.Loai, SoLuong = sanPham.SoLuong, SoLuongDaBan = sanPham.SoLuongDaBan, GiaGoc = sanPham.GiaGoc, GiaBan = sanPham.GiaBan, PhiShip = sanPham.PhiShip });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbLocLoai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            try
            {
                lsvQuanLySanPham.Items.Clear();
                string mucDaChon = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();
                if (string.Equals(mucDaChon, "Tất cả"))
                    HienThi_QuanLySanPham();
                else
                {
                    dsSanPham = sanPhamDao.timKiemBangLoai(mucDaChon, nguoiDung.Id);
                    foreach (var sanPham in dsSanPham)
                    {
                        string tenAnh = XuLyAnh.layDuongDanDayDuToiFileAnhSanPham(sanPham.LinkAnh);
                        lsvQuanLySanPham.Items.Add(new { Id = sanPham.Id, Ten = sanPham.Ten, LinkAnh = tenAnh, Loai = sanPham.Loai, SoLuong = sanPham.SoLuong, SoLuongDaBan = sanPham.SoLuongDaBan, GiaGoc = sanPham.GiaGoc, GiaBan = sanPham.GiaBan, PhiShip = sanPham.PhiShip });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
#endregion
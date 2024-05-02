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

namespace TraoDoiDo.Views.QuanLy
{
    /// <summary>
    /// Interaction logic for TabQuanLySanPhamUC.xaml
    /// </summary>
    public partial class TabQuanLySanPhamUC : UserControl
    {
        SanPhamDao sanPhamDao = new SanPhamDao();
        List<SanPham> dsSanPham = new List<SanPham>();
        MoTaHangHoaDao moTaDao = new MoTaHangHoaDao();
        NguoiDung nguoiDung = new NguoiDung();
        public TabQuanLySanPhamUC()
        {
            InitializeComponent();
            
        }
        public TabQuanLySanPhamUC(NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
            Loaded += FQuanLySanPham_Loaded;
        }
        private void FQuanLySanPham_Loaded(object sender, RoutedEventArgs e)
        {
            HienThi_QuanLySanPham();
        }
        private void HienThi_QuanLySanPham()
        {
            try
            {
                lsvQuanLySanPham.Items.Clear();
                dsSanPham = sanPhamDao.LoadToanBoSanPham();
                foreach (var sanPham in dsSanPham)
                {
                    string tenAnh = XuLyAnh.layDuongDanDayDuToiFileAnhSanPham(sanPham.LinkAnh);
                    lsvQuanLySanPham.Items.Add(new { Id = sanPham.Id.ToString(), Ten = sanPham.Ten, LinkAnh = tenAnh, Loai = sanPham.Loai, SoLuong = sanPham.SoLuong, SoLuongDaBan = sanPham.SoLuongDaBan, GiaGoc = sanPham.GiaGoc, GiaBan = sanPham.GiaBan, PhiShip = sanPham.PhiShip, NgayDang = sanPham.NgayDang });

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
            List<SanPham> dsSanPham = sanPhamDao.LoadToanBoSanPham();
            foreach (var sp in dsSanPham)
            {
                int soNgay = TinhKhoangCachSoNgay(DateTime.ParseExact(sp.NgayDang, "dd/MM/yyyy", null));
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
        private void cbLocLoai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            try
            {
                lsvQuanLySanPham.Items.Clear();
                string selectedItemContent = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();
                if (string.Equals(selectedItemContent, "Tất cả"))
                    HienThi_QuanLySanPham();
                else
                {
                    dsSanPham = sanPhamDao.timKiemBangLoai(selectedItemContent);
                    foreach (var sanPham in dsSanPham)
                    {
                        string tenAnh = XuLyAnh.layDuongDanDayDuToiFileAnhSanPham(sanPham.LinkAnh);
                        lsvQuanLySanPham.Items.Add(new { Id = sanPham.Id.ToString(), Ten = sanPham.Ten.ToString(), LinkAnh = tenAnh, Loai = sanPham.Loai.ToString(), SoLuong = sanPham.SoLuong.ToString(), SoLuongDaBan = sanPham.SoLuongDaBan.ToString(), GiaGoc = sanPham.GiaGoc.ToString(), GiaBan = sanPham.GiaBan.ToString(), PhiShip = sanPham.PhiShip.ToString(), NgayDang = sanPham.NgayDang });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txbTimKiemSanPham_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                lsvQuanLySanPham.Items.Clear();
                if (string.IsNullOrEmpty(txbTimKiemSanPham.Text))
                    HienThi_QuanLySanPham();
                else
                {
                    SanPham sanPham = sanPhamDao.timKiemSanPhamBangId(txbTimKiemSanPham.Text.Trim());
                    string tenAnh = XuLyAnh.layDuongDanDayDuToiFileAnhSanPham(sanPham.LinkAnh);
                    lsvQuanLySanPham.Items.Add(new { Id = sanPham.Id.ToString(), Ten = sanPham.Ten.ToString(), LinkAnh = tenAnh, Loai = sanPham.Loai.ToString(), SoLuong = sanPham.SoLuong.ToString(), SoLuongDaBan = sanPham.SoLuongDaBan.ToString(), GiaGoc = sanPham.GiaGoc.ToString(), GiaBan = sanPham.GiaBan.ToString(), PhiShip = sanPham.PhiShip.ToString() });

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void btnSuaSP_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            
            ListViewItem item = HoTroTimPhanTu.FindAncestor<ListViewItem>(btn);

            if (item != null)
            {
                dynamic dataItem = item.DataContext;
                //Đổ thông tin sản phẩm lên DangDo_Sua
                SanPham sp = sanPhamDao.timKiemSanPhamBangId(dataItem.Id);
                DangDo_Sua f = new DangDo_Sua(sp);

                //Đổ ảnh và mô tả lên DangDo_Sua
                List<MoTaHangHoa> dsAnhVaMoTaSanPham = moTaDao.TimKiemDanhSachAnhVaMoTaBangId(dataItem.Id);
                foreach (var dong in dsAnhVaMoTaSanPham)
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
                f.ShowDialog();
            }
        }

        private void btnXoaSP_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ListViewItem item = HoTroTimPhanTu.FindAncestor<ListViewItem>(btn);
            dynamic dataItem = item.DataContext;
            if (dataItem != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa sản phầm này?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        sanPhamDao.Xoa(dataItem);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xảy ra khi xóa sản phẩm: " + ex.Message);
                    }
                }
            }

        }

        

        private void lsvQuanLySanPham_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using TraoDoiDo.Models;
using TraoDoiDo.Database;
using System.Data.SqlClient;
using TraoDoiDo.ViewModels;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for QuanLy.xaml
    /// </summary>
    public partial class QuanLyUC : UserControl
    {
        VoucherDao voucherDao = new VoucherDao();
        NguoiDungVoucherDao ndvcDao = new NguoiDungVoucherDao();
        List<NguoiDung> listNguoiDung = new List<NguoiDung>();
        private TaiKhoanDao tkDao = new TaiKhoanDao();
        NguoiDungDao ngDungDao = new NguoiDungDao();
        DanhGiaNguoiDangDao danhGiaDao = new DanhGiaNguoiDangDao();
        SanPhamDao sanPhamDao = new SanPhamDao();
        List<SanPham> dsSanPham = new List<SanPham>();
        List<NguoiDung> dsNguoiDung = new List<NguoiDung>();
        MoTaHangHoaDao moTaDao = new MoTaHangHoaDao();

        public QuanLyUC()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += QuanLyUC_Loaded;
            Loaded += QuanLyVoucher_Load;
        }
        public QuanLyUC(NguoiDung nguoiDung)
        {
            InitializeComponent();
            DataContext = this;
            Loaded += QuanLyUC_Loaded;
            Loaded += QuanLyVoucher_Load;
        }
        private void QuanLyUC_Loaded(object sender, RoutedEventArgs e)
        {
            //QUAN LY SAN PHAM
            HienThi_QuanLySanPham();
            HienThi_QuanLyNguoiDung();

        }

        #region QuanLySanPham
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
                    SanPham sanPham = sanPhamDao.timKiemToanBoBangId(txbTimKiemSanPham.Text.Trim());
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

            ListViewItem item = FindAncestor<ListViewItem>(btn);

            if (item != null)
            {
                dynamic dataItem = item.DataContext;
                SanPham sp = sanPhamDao.timKiemToanBoBangId(dataItem.Id);
                DangDo_Sua f = new DangDo_Sua(sp);

                List<MoTaHangHoa> dsMoTaHangHoa = moTaDao.TimKiemBangId(dataItem.Id);

                //Đổ ảnh và mô tả lên
                foreach (var moTaHangHoa in dsMoTaHangHoa) // i : item, tí tìm cái tên khác để đặt
                {
                    f.DanhSachAnhVaMoTa[f.soLuongAnh] = new ThemAnhKhiDangUC();

                    f.DanhSachAnhVaMoTa[f.soLuongAnh].txtbTenFileAnh.Text = moTaHangHoa.LinkAnh; // Rãnh sửa thuộc tính LinkAnh thành TenFileAnh

                    string duongDanAnh = XuLyAnh.layDuongDanDayDuToiFileAnhSanPham(moTaHangHoa.LinkAnh);
                    f.DanhSachAnhVaMoTa[f.soLuongAnh].txtbDuongDanAnh.Text = duongDanAnh;

                    f.DanhSachAnhVaMoTa[f.soLuongAnh].imgAnhSP.Source = new BitmapImage(new Uri(duongDanAnh));

                    f.DanhSachAnhVaMoTa[f.soLuongAnh].txtbMoTa.Text = moTaHangHoa.MoTa;

                    f.wpnlChuaAnh.Children.Add(f.DanhSachAnhVaMoTa[f.soLuongAnh]);
                    f.soLuongAnh++;

                }
                f.Show();
            }
        }

        private void btnXoaSP_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ListViewItem item = FindAncestor<ListViewItem>(btn);
            if (item != null)
            {
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

        }
        #endregion
        #region QuanLyNguoiDung
        private void HienThi_QuanLyNguoiDung()
        {
            try
            {
                lsvQuanLyNguoiDung.Items.Clear();
                dsNguoiDung = ngDungDao.LoadNguoiDung();
                foreach (var nguoiDung in dsNguoiDung)
                {

                    listNguoiDung.Add(nguoiDung);
                    lsvQuanLyNguoiDung.Items.Add(new { UserId = nguoiDung.Id, FullName = nguoiDung.HoTen, Identification = nguoiDung.Cmnd, Gender = nguoiDung.GioiTinh, PhoneNumber = nguoiDung.Sdt, DateOfBirth = nguoiDung.NgaySinh, Address = nguoiDung.DiaChi, Email = nguoiDung.Email });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Tab Quản lý người dùng


        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            ListViewItem item = FindAncestor<ListViewItem>(btn);

            if (item != null)
            {
                dynamic dataItem = item.DataContext;
                int index = lsvQuanLyNguoiDung.Items.IndexOf(dataItem);
                ThongTinNguoiDang f = new ThongTinNguoiDang(listNguoiDung[index].Id);
                f.Show();
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ListViewItem item = FindAncestor<ListViewItem>(btn);
            if (item != null)
            {
                dynamic dataItem = item.DataContext;
                if (dataItem != null)
                {
                    if (MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            ngDungDao.Xoa(dataItem.Id);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xảy ra khi xóa người dùng: " + ex.Message);
                        }
                        try
                        {
                            tkDao.Xoa(dataItem.Id);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xảy ra khi xóa người dùng: " + ex.Message);
                        }
                    }
                }
            }

        }


        private void btnDuyet_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nếu chưa duyệt thì chuyển sang đã duyệt\nNếu đã duyệt rồi, thì khi ấn nút này nó báo là sp đã được duyệt(hoặc vô hiệu hóa cái nút được thì càng tốt)");
        }
        

        private void cbSoSao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void HienThiNguoiDangUyTien(string soSaoDau, string soSaoCuoi)
        {
            List<DanhGiaNguoiDang> dsDanhGiaSoSao = danhGiaDao.TinhTrungBinhSoSao(soSaoDau, soSaoCuoi);
            foreach (var danhGia in dsDanhGiaSoSao)
            {
                NguoiDung nguoiDung = danhGiaDao.LoadThongTinNguoiDang(danhGia.IdNguoiDang);
                lsvQuanLyNguoiDung.Items.Add(new { UserId = nguoiDung.Id, FullName = nguoiDung.HoTen, Identification = nguoiDung.Cmnd, Gender = nguoiDung.GioiTinh, PhoneNumber = nguoiDung.Sdt, DateOfBirth = nguoiDung.NgaySinh, Address = nguoiDung.DiaChi, Email = nguoiDung.Email });
            }
        }


        private void cbNgayMua_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbSoSao_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            try
            {
                lsvQuanLyNguoiDung.Items.Clear();
                string selectedItemContent = (comboBox.SelectedItem as ComboBoxItem).Content.ToString().Trim();
                if (string.Equals(selectedItemContent, "Tất cả"))
                    HienThi_QuanLyNguoiDung();
                else if (string.Equals(selectedItemContent, "Số sao từ 0 đến 2"))
                    HienThiNguoiDangUyTien("0", "2");
                else
                {
                    HienThiNguoiDangUyTien("3", "5");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txbTimKiemNguoiDung_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                lsvQuanLyNguoiDung.Items.Clear();
                if (string.IsNullOrEmpty(txbTimKiemNguoiDung.Text))
                    HienThi_QuanLyNguoiDung();
                else
                {
                    NguoiDung nguoiDung = ngDungDao.TimKiemBangId(txbTimKiemNguoiDung.Text.Trim());

                    lsvQuanLyNguoiDung.Items.Add(new { UserId = nguoiDung.Id, FullName = nguoiDung.HoTen, Identification = nguoiDung.Cmnd, Gender = nguoiDung.GioiTinh, PhoneNumber = nguoiDung.Sdt, DateOfBirth = nguoiDung.NgaySinh, Address = nguoiDung.DiaChi, Email = nguoiDung.Email });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region TAB1 MUA SẮM
        private void QuanLyVoucher_Load(object sender, RoutedEventArgs e)
        {
            LoadDanhSachVoucer();
        }

        private void LoadDanhSachVoucer()
        { 
            try
            {
                List<Voucher> dsVoucher = voucherDao.LoadVoucher();  
                lsvQLVoucher.ItemsSource = dsVoucher;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void lsvQLVoucher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (lsvQLVoucher.SelectedItem != null)
            {
                // Lấy dữ liệu của dòng được chọn
                Voucher dongDuocChon = lsvQLVoucher.SelectedItem as Voucher; // Thay YourDataModel bằng kiểu dữ liệu thực tế của bạn

                if (dongDuocChon != null)
                {
                    txtbIdVoucher.Text = dongDuocChon.IdVoucher;
                    txtbTenVoucher.Text = dongDuocChon.TenVoucher;
                    txtbGiaTri.Text = dongDuocChon.GiaTri;
                    dtpNgayBatDau.SelectedDate = DateTime.Parse(dongDuocChon.NgayBatDau);
                    dtpNgayKetThuc.SelectedDate = DateTime.Parse(dongDuocChon.NgayKetThuc);
                    ucTangGiamSoLuotSuDungToiDa.txtbSoLuong.Text = dongDuocChon.SoLuotSuDungToiDa;
                    ucTangGiamSoLuotDaSuDung.txtbSoLuong.Text = dongDuocChon.SoLuotDaSuDung;
                }
            }
        }
        private void btnDangVoucher_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng ?", "Xác nhận đăng", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Voucher voucher = new Voucher("1", txtbTenVoucher.Text, txtbGiaTri.Text, ucTangGiamSoLuotSuDungToiDa.txtbSoLuong.Text, ucTangGiamSoLuotDaSuDung.txtbSoLuong.Text, dtpNgayBatDau.Text, dtpNgayKetThuc.Text);
                if (voucher.kiemTraCacTextBox())
                {
                    try
                    {
                        voucherDao.Them(voucher);

                        // Load lại tab QL Voucher
                        QuanLyVoucher_Load(sender, e);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xảy ra khi đăng sản phẩm: " + ex.Message);
                    }
                }
                
            }
        }
        private void btnSuaVoucher_Click(object sender, RoutedEventArgs e)
        { 
            if (MessageBox.Show("Bạn có chắc chắn muốn sửa mục đã chọn?", "Xác nhận sửa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Voucher voucher = new Voucher(txtbIdVoucher.Text, txtbTenVoucher.Text, txtbGiaTri.Text, ucTangGiamSoLuotSuDungToiDa.txtbSoLuong.Text, ucTangGiamSoLuotDaSuDung.txtbSoLuong.Text, dtpNgayBatDau.Text, dtpNgayKetThuc.Text);
                if (voucher.kiemTraCacTextBox())
                {
                    try
                    {
                        voucherDao.Sua(voucher);

                        // Load lại tab QL Voucher
                        QuanLyVoucher_Load(sender, e);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xảy ra khi đăng sản phẩm: " + ex.Message);
                    }
                }
            }
        }
         
        private void btnXoaVoucher_Click(object sender, RoutedEventArgs e) // truy vấn id trên lsv sẽ hiệu quả hơn thay vì lấy id từ textblock , từ đó ta có thể đặt thuộc tính isReadOnly thành True
        {
            // Lấy button được click
            Button btn = sender as Button; 
            // Lấy ListViewItem chứa button
            ListViewItem item = FindAncestor<ListViewItem>(btn);

            if (item != null)
            {
                // Lấy dữ liệu của ListViewItem
                dynamic dataItem = item.DataContext;

                if (dataItem != null)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa mục đã chọn?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        { 
                            string idVoucher = dataItem.IdVoucher;
                            // Xóa dữ liệu từ bảng SanPham
                            ndvcDao.XoaTheoIdVoucher(idVoucher);
                            voucherDao.XoaVoucherTheoIdVoucher(idVoucher);
                            // Load lại tab QL Voucher
                            QuanLyVoucher_Load(sender, e);


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xảy ra khi xóa sản phẩm: " + ex.Message);
                        }
                           
                    }
                }
            }
            else
            {
                MessageBox.Show("Không thể xác định dòng chứa nút 'Xóa'.");
            }
        }

        // Hàm trợ giúp để tìm thành phần cha của một kiểu cụ thể
        public static T FindAncestor<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);

            if (parent == null)
                return null;

            var parentT = parent as T;
            return parentT ?? FindAncestor<T>(parent);
        }

        #endregion
    }
}

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

namespace TraoDoiDo.Views.MuaDo
{
    /// <summary>
    /// Interaction logic for TabTrangThaiDonHangUC.xaml
    /// </summary>
    public partial class TabTrangThaiDonHangUC : UserControl
    {
        private int soLuongSP = 0;
        private SanPhamUC[] DanhSachSanPham = new SanPhamUC[100];
        List<TrangThaiDonHang> dsSanPhamDeThanhToan = new List<TrangThaiDonHang>();

        NguoiDung ngMua;

        SanPhamDao sanPhamDao = new SanPhamDao();
        GioHangDao gioHangDao = new GioHangDao();
        NguoiDungDao ngDungDao = new NguoiDungDao();
        TrangThaiDonHangDao trangThaiDonHangDao = new TrangThaiDonHangDao();
        QuanLyDonHangDao quanLyDonHangDao = new QuanLyDonHangDao();
        VoucherDao voucherDao = new VoucherDao();

        public TabTrangThaiDonHangUC()
        {
            InitializeComponent();
        }
        public TabTrangThaiDonHangUC(NguoiDung ngMua)
        {
            InitializeComponent();
            this.ngMua = ngMua;
            Loaded += TrangThaiDonHang_Load;
        }

        #region Từ con gọi cha 
        public class ThamSoThayDoi : EventArgs
        {
            public string SoTienMoi { get; set; }
        }

        public event EventHandler<ThamSoThayDoi> SuKien_TabTrangThaiDonHang_GoiChaKhiTienNguoiDungThayDoi;

        private void txbTienNguoiDung_TextChanged(object sender, TextChangedEventArgs e)
        {
            SuKien_TabTrangThaiDonHang_GoiChaKhiTienNguoiDungThayDoi?.Invoke(this, new ThamSoThayDoi
            {
                SoTienMoi = txbTienNguoiDung.Text
            });
        }
        #endregion

        private void TrangThaiDonHang_Load(object sender, RoutedEventArgs e)
        {
            LoadLsvTrongTabTrangThaiDonHang("lsvChoNguoiBanXacNhan", "Chờ xác nhận");
            LoadLsvTrongTabTrangThaiDonHang("lsvChoGiaoHang", "Chờ giao hàng");
            LoadLsvTrongTabTrangThaiDonHang("lsvDaNhan", "Đã nhận");
        }

        private void LoadLsvTrongTabTrangThaiDonHang(string tenLsv, string trangthai)
        {
            try
            { 
                List<TrangThaiDonHang> dsTrangThaiDon = trangThaiDonHangDao.LoadTrangThaiDonHang(ngMua.Id, trangthai);

                if (tenLsv == "lsvChoNguoiBanXacNhan")
                    lsvChoNguoiBanXacNhan.Items.Clear();
                else if (tenLsv == "lsvChoGiaoHang")
                    lsvChoGiaoHang.Items.Clear();
                else if (tenLsv == "lsvDaNhan")
                    lsvDaNhan.Items.Clear();

                foreach (var dong in dsTrangThaiDon)
                {
                    string tenFileAnh = dong.AnhSP;
                    string linkAnhBia = XuLyAnh.layDuongDanDayDuToiFileAnhSanPham(tenFileAnh);

                    if (tenLsv == "lsvChoNguoiBanXacNhan")
                        lsvChoNguoiBanXacNhan.Items.Add(new { IdSP = dong.IdSanPham, TenSP = dong.TenSanPham, LinkAnhBia = linkAnhBia, Gia = Tien.DinhDangTien(dong.GiaBan), PhiShip = Tien.DinhDangTien(dong.PhiShip), SoLuongMua = dong.SoLuongMua, TongThanhToan = Tien.DinhDangTien(dong.TongThanhToan), Ngay = dong.Ngay });
                    else if (tenLsv == "lsvChoGiaoHang")
                        lsvChoGiaoHang.Items.Add(new { IdSP = dong.IdSanPham, TenSP = dong.TenSanPham, LinkAnhBia = linkAnhBia, Gia = Tien.DinhDangTien(dong.GiaBan), PhiShip = Tien.DinhDangTien(dong.PhiShip), SoLuongMua = dong.SoLuongMua, TongThanhToan = Tien.DinhDangTien(dong.TongThanhToan), Ngay = dong.Ngay });
                    else if (tenLsv == "lsvDaNhan")
                        lsvDaNhan.Items.Add(new { IdSP = dong.IdSanPham, TenSP = dong.TenSanPham, LinkAnhBia = linkAnhBia, Gia = Tien.DinhDangTien(dong.GiaBan), PhiShip = Tien.DinhDangTien(dong.PhiShip), SoLuongMua = dong.SoLuongMua, TongThanhToan = Tien.DinhDangTien(dong.TongThanhToan), Ngay = dong.Ngay });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuyDatHang_Click(object sender, RoutedEventArgs e)
        { 
            Button btn = sender as Button; 
            ListViewItem dongChuaButton = HoTroTimPhanTu.FindAncestor<ListViewItem>(btn);  
            dynamic duLieuCuaDongChuaButton = dongChuaButton.DataContext;

            if (duLieuCuaDongChuaButton != null)
            {
                if (MessageBox.Show("Bạn có chắc là muốn hủy đặt hàng 0_o\nĐơn hàng mà bạn hủy sẽ được hoàn tiền", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        string tongtt = duLieuCuaDongChuaButton.TongThanhToan;
                        TrangThaiDonHang trangThaiDonHang = new TrangThaiDonHang(ngMua.Id, duLieuCuaDongChuaButton.IdSP, duLieuCuaDongChuaButton.SoLuongMua, duLieuCuaDongChuaButton.TongThanhToan, duLieuCuaDongChuaButton.Ngay, null, null, null, null, null);
                        trangThaiDonHangDao.Xoa(trangThaiDonHang);
                         
                        QuanLyDonHang quanLyDonHang = new QuanLyDonHang(null, null, ngMua.Id, duLieuCuaDongChuaButton.IdSP, null, null);
                        quanLyDonHangDao.Xoa(quanLyDonHang);

                        sanPhamDao.GiamSoLuongDaBan(duLieuCuaDongChuaButton.IdSP, Convert.ToInt32(duLieuCuaDongChuaButton.SoLuongMua));

                        TrangThaiDonHang_Load(sender, e);
                        ngDungDao.CongThemVaoSoTienHienTai(ngMua.Id, tongtt.Replace(".",""));

                        txbTienNguoiDung.Text = ngDungDao.TimKiemTienBangId(ngMua.Id); 
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xảy ra khi xóa: " + ex.Message);
                    } 
                } 
            } 
        }
         
        private void btnDaNhanHang_Click(object sender, RoutedEventArgs e)
        { 
            Button btn = sender as Button; 
            ListViewItem dongChuaButton = HoTroTimPhanTu.FindAncestor<ListViewItem>(btn); 
            dynamic duLieuCuaDongChuaButton = dongChuaButton.DataContext;

            if (duLieuCuaDongChuaButton != null)
            {
                if (MessageBox.Show("Bạn có chắc là đã nhận được hàng 0_o", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        TrangThaiDonHang trangThaiDonHang = new TrangThaiDonHang(ngMua.Id, duLieuCuaDongChuaButton.IdSP, duLieuCuaDongChuaButton.SoLuongMua, duLieuCuaDongChuaButton.TongThanhToan, duLieuCuaDongChuaButton.Ngay, "Đã nhận", null, null, null, null);
                        trangThaiDonHangDao.CapNhat(trangThaiDonHang);

                        QuanLyDonHang quanLyDonHang = new QuanLyDonHang(null, null, ngMua.Id, duLieuCuaDongChuaButton.IdSP, "Đã giao", null);
                        quanLyDonHangDao.CapNhat(quanLyDonHang);
                        TrangThaiDonHang_Load(sender, e);
                        string idNguoiDang = ngDungDao.timKiemNguoiDangTheoIdSP(duLieuCuaDongChuaButton.Id).Id; 
                        ngDungDao.CongThemVaoSoTienHienTai(idNguoiDang, duLieuCuaDongChuaButton.TongThanhToan);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xảy ra: " + ex.Message);
                    } 
                }
            } 
        }

        private void btnDanhGia_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ListViewItem dongChuaButton = HoTroTimPhanTu.FindAncestor<ListViewItem>(btn);
            dynamic duLieuCuaDongChuaButton = dongChuaButton.DataContext;

            if (duLieuCuaDongChuaButton != null)
            {
                try
                {
                    NguoiDung nguoiDang = ngDungDao.timKiemNguoiDangTheoIdSP(duLieuCuaDongChuaButton.IdSP);
                    DanhGia f = new DanhGia(ngMua.Id, nguoiDang.Id);
                    f.txtbTenNguoiDang.Text = nguoiDang.HoTen;
                    f.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra: " + ex.Message);
                }
            }
        }
         
        private void btnTraHang_Click(object sender, RoutedEventArgs e)
        {
            ucLyDoTraHang.idNguoiMua = ngMua.Id; 
            Button btn = sender as Button; 
            ListViewItem dongChuaButton = HoTroTimPhanTu.FindAncestor<ListViewItem>(btn);  
            dynamic duLieuCuaDongChuaButton = dongChuaButton.DataContext;

            if (duLieuCuaDongChuaButton != null)
            {
                ucLyDoTraHang.idSP = duLieuCuaDongChuaButton.IdSP;
                ucLyDoTraHang.DrawerClosed += (btnSender, args) =>
                { 
                    LoadLsvTrongTabTrangThaiDonHang("lsvChoGiaoHang", "Chờ giao hàng");

                    ngDungDao.CongThemVaoSoTienHienTai(ngMua.Id, duLieuCuaDongChuaButton.TongThanhToan);
                    txbTienNguoiDung.Text = ngDungDao.TimKiemTienBangId(ngMua.Id);
                };
            } 
        } 
    }
}

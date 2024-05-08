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
    /// Interaction logic for TabQuanLyDonHangUC.xaml
    /// </summary>
    public partial class TabQuanLyDonHangUC : UserControl
    {
        List<SanPham> dsSanPham;

        SanPham sanPham;
        NguoiDung nguoiDung;
        MoTaHangHoa moTaHangHoa;

        SanPhamDao sanPhamDao = new SanPhamDao();
        MoTaHangHoaDao moTaDao = new MoTaHangHoaDao();
        NguoiDungDao nguoiDao = new NguoiDungDao();
        QuanLyDonHangDao quanLyDonHangDao = new QuanLyDonHangDao();
        TrangThaiDonHangDao trangThaiHangDao = new TrangThaiDonHangDao();
        DanhGiaNguoiDangDao danhGiaNguoiDungDao = new DanhGiaNguoiDangDao();

        public TabQuanLyDonHangUC()
        {
            InitializeComponent();
        }

        public TabQuanLyDonHangUC(NguoiDung nguoi)
        {
            InitializeComponent();
            Loaded += QuanLyDonHang_Load;
            nguoiDung = nguoi;
        }
        private void QuanLyDonHang_Load(object sender, RoutedEventArgs e)
        {
            LoadLsvTrongTabQuanLyDonHang("lsvChoDongGoi", "Chờ đóng gói");
            LoadLsvTrongTabQuanLyDonHang("lsvDangGiao", "Đang giao");
            LoadLsvTrongTabQuanLyDonHang("lsvDaGiao", "Đã giao");
            LoadLsvTrongTabQuanLyDonHang("lsvDonHangBiHoanTra", "Bị hoàn trả");
        }
        private void LoadLsvTrongTabQuanLyDonHang(string tenLsv, string trangthai)
        {
            try
            {
                List<QuanLyDonHang> dsQuanLyDonHang = new List<QuanLyDonHang>();
                dsQuanLyDonHang = quanLyDonHangDao.TimKiemTheoIdNguoiDang(nguoiDung.Id, trangthai);
                if (tenLsv == "lsvChoDongGoi")
                    lsvChoDongGoi.Items.Clear();
                else if (tenLsv == "lsvDangGiao")
                    lsvDangGiao.Items.Clear();
                else if (tenLsv == "lsvDaGiao")
                    lsvDaGiao.Items.Clear();
                else if (tenLsv == "lsvDonHangBiHoanTra")
                    lsvDonHangBiHoanTra.Items.Clear();

                foreach (var dong in dsQuanLyDonHang)
                {
                    string tenFileAnh = dong.LinkAnhBia;
                    string linkAnhBia = XuLyAnh.layDuongDanDayDuToiFileAnhSanPham(tenFileAnh);

                    if (tenLsv == "lsvChoDongGoi")
                        lsvChoDongGoi.Items.Add(new { IdSP = dong.IdSanPham, IdNguoiMua = dong.IdNguoiMua, TenSP = dong.TenSanPham, LinkAnhBia = linkAnhBia, SoLuongMua = dong.SoLuongMua, Gia = Tien.DinhDangTien(dong.Gia), PhiShip = Tien.DinhDangTien(dong.PhiShip), TongTien = Tien.DinhDangTien(dong.TongTien) });
                    else if (tenLsv == "lsvDangGiao")
                        lsvDangGiao.Items.Add(new { IdSP = dong.IdSanPham, IdNguoiMua = dong.IdNguoiMua, TenSP = dong.TenSanPham, LinkAnhBia = linkAnhBia, SoLuongMua = dong.SoLuongMua, Gia = Tien.DinhDangTien(dong.Gia), PhiShip = Tien.DinhDangTien(dong.PhiShip), TongTien = Tien.DinhDangTien(dong.TongTien) });
                    else if (tenLsv == "lsvDaGiao")
                        lsvDaGiao.Items.Add(new { IdSP = dong.IdSanPham, IdNguoiMua = dong.IdNguoiMua, TenSP = dong.TenSanPham, LinkAnhBia = linkAnhBia, SoLuongMua = dong.SoLuongMua, Gia = Tien.DinhDangTien(dong.Gia), PhiShip = Tien.DinhDangTien(dong.PhiShip), TongTien = Tien.DinhDangTien(dong.TongTien) });
                    else if (tenLsv == "lsvDonHangBiHoanTra")
                        lsvDonHangBiHoanTra.Items.Add(new { IdSP = dong.IdSanPham, IdNguoiMua = dong.IdNguoiMua, TenSP = dong.TenSanPham, LinkAnhBia = linkAnhBia, SoLuongMua = dong.SoLuongMua, Gia = Tien.DinhDangTien(dong.Gia), PhiShip = Tien.DinhDangTien(dong.PhiShip), TongTien = Tien.DinhDangTien(dong.TongTien), LyDoTraHang = dong.LyDo });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         
        private void btnDiaChiGuiHang_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ListViewItem dongChuaButton = HoTroTimPhanTu.FindAncestor<ListViewItem>(btn);
            dynamic duLieuCuaDongChuaButton = dongChuaButton.DataContext;

            if (duLieuCuaDongChuaButton != null)
            {
                try
                { 
                    NguoiDung nguoi = nguoiDao.TimThongTinNguoiMuaDeGuihang(duLieuCuaDongChuaButton.IdNguoiMua, duLieuCuaDongChuaButton.IdSP);

                    DiaChi f = new DiaChi(nguoi);
                    f.txtbTieuDe.Text = "Địa chỉ khách hàng";
                    f.btnXacNhanThanhToan.Visibility = Visibility.Collapsed;
                    f.Height = 318;
                    f.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private void btnGuiHang_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ListViewItem dongChuaButton = HoTroTimPhanTu.FindAncestor<ListViewItem>(btn);
            dynamic duLieuCuaDongChuaButton = dongChuaButton.DataContext;

            if (duLieuCuaDongChuaButton != null)
            {
                try
                {
                    QuanLyDonHang quanLy = new QuanLyDonHang(null, null, duLieuCuaDongChuaButton.IdNguoiMua, duLieuCuaDongChuaButton.IdSP, "Đang giao", null);
                    quanLyDonHangDao.CapNhat(quanLy);
                    TrangThaiDonHang trangThaiDon = new TrangThaiDonHang(duLieuCuaDongChuaButton.IdNguoiMua, duLieuCuaDongChuaButton.IdSP, null, null, null, "Chờ giao hàng", null, null, null, null);
                    trangThaiHangDao.CapNhat(trangThaiDon);
                    QuanLyDonHang_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi:" + ex.Message);
                }
            }
        }

    }
}

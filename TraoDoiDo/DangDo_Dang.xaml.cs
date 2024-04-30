using System.Windows;
using System;
using TraoDoiDo.Database;
using TraoDoiDo.Models;
using TraoDoiDo.ViewModels;
using System.Windows.Navigation;
namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for DangDo_Dang.xaml
    /// </summary>
    public partial class DangDo_Dang : Window
    {
        private int soLuongAnh = 0;
        private ThemAnhKhiDangUC[] DanhSachAnhVaMoTa = new ThemAnhKhiDangUC[100]; //Khi dùng thì phải khai báo là DanhSachAnhVaMoTa[i] = new ThemAnhKhiDangUC();
        NguoiDung ngDung = new NguoiDung();
        XuLyAnh xuLyAnh = new XuLyAnh();
        SanPham sp = new SanPham();
        SanPhamDao sanPhamDao = new SanPhamDao();
        public DangDo_Dang()
        {
            InitializeComponent();
            Loaded += btnThemAnh_Click;
        }
        public DangDo_Dang(NguoiDung kh)
        {
            InitializeComponent();
            this.DataContext = this;
            Loaded += btnThemAnh_Click;
            ngDung = kh;
        }
        private void themThongTinVaoCSDL()
        {
            string tenFileAnh = "no_image.jpg";
            for (int i = 0; i < soLuongAnh; i++)
                if (DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text != null && !string.IsNullOrEmpty(DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text.Trim()) && DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text != "no_image.jpg")
                {
                    tenFileAnh = DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text;
                    break;
                }
            string ngayHienTai = DateTime.Today.ToShortDateString();
            string ngayMua = dtpNgayMua.Text;
            sp = new SanPham(txtbIdSanPham.Text, ngDung.Id, txtbTen.Text, tenFileAnh, txtbLoai.Text, ucTangGiamSoLuongTong.txtbSoLuong.Text, ucTangGiamSoLuongDaBan.txtbSoLuong.Text, txtbGiaGoc.Text, txtbGiaBan.Text, txtbPhiShip.Text, "Đã duyệt", cboNoiBan.Text, cboXuatXu.Text, ngayMua, txtbMoTaChung.Text, progressSlidere_PhanTramMoi.Value.ToString(), "0", "1", ngayHienTai);
            //sanPhamDao.Them(sp);
        }
        private void themAnhVaMoTaVaoCSDL()
        {
            string id = txtbIdSanPham.Text;
            for (int i = 0; i < soLuongAnh; i++)
            {
                if (DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text != null && !string.IsNullOrEmpty(DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text.Trim()) && DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text != "no_image.jpg")
                {
                    string idAnhMinhHoa = (i + 1).ToString();
                    string tenFileAnh = DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text;
                    string moTa = DanhSachAnhVaMoTa[i].txtbMoTa.Text;
                    MoTaHangHoa mta = new MoTaHangHoa(id, idAnhMinhHoa, tenFileAnh, moTa);
                    MoTaHangHoaDao mtaDao = new MoTaHangHoaDao();
                    mtaDao.Them(mta);
                    XuLyAnh.LuuAnhVaoThuMuc(DanhSachAnhVaMoTa[i].txtbDuongDanAnh.Text, "HinhSanPham");
                }
                else
                    continue;
            }

        }

        private void btnDang_Click(object sender, RoutedEventArgs e)
        {
            bool coAnh = false;
            bool coTT = false;
            themThongTinVaoCSDL();
            bool check = sp.kiemTraCacTextBox();
            if (check)
            {
                try
                {
                    sanPhamDao.Them(sp);
                    coTT = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    themAnhVaMoTaVaoCSDL();
                    coAnh = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (coAnh && coTT)
                {
                    MessageBox.Show("Đăng đồ thành công");
                }
            }

        }


        private void btnThemAnh_Click(object sender, RoutedEventArgs e)
        {
            DanhSachAnhVaMoTa[soLuongAnh] = new ThemAnhKhiDangUC();
            wpnlChuaAnh.Children.Add(DanhSachAnhVaMoTa[soLuongAnh]);
            soLuongAnh++;
        }
    }
}

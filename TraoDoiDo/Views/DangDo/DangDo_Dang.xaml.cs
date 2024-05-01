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
        int soLuongAnh = 0;
        ThemAnhKhiDangUC[] DanhSachAnhVaMoTa = new ThemAnhKhiDangUC[100];

        NguoiDung ngDang; 
        SanPham sp;

        SanPhamDao sanPhamDao = new SanPhamDao();

        public DangDo_Dang()
        {
            InitializeComponent();
        }

        public DangDo_Dang(NguoiDung nguoi)
        {
            InitializeComponent();
            Loaded += btnThemAnh_Click;
            ngDang = nguoi;
            ucThongTin.btnSua.Visibility = Visibility.Collapsed;
            ucThongTin.btnDang.Click += btnDang_Click;
            ucThongTin.btnThemAnh.Click += btnThemAnh_Click;
        }
        private void themThongTinVaoCSDL()
        {
            try
            { 
                string tenFileAnh = "no_image.jpg";
                for (int i = 0; i < soLuongAnh; i++)
                    if (DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text != null && !string.IsNullOrEmpty(DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text.Trim()) && DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text != "no_image.jpg")
                    {
                        tenFileAnh = DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text; //Lấy cái ảnh đầu tiên làm ảnh bìa
                        break;
                    }
                string ngayHienTai = DateTime.Today.ToShortDateString();
                string ngayMua = ucThongTin.dtpNgayMua.Text;
                sp = new SanPham(ucThongTin.txtbIdSanPham.Text, ngDang.Id, ucThongTin.txtbTen.Text, tenFileAnh, ucThongTin.txtbLoai.Text, ucThongTin.ucTangGiamSoLuongTong.txtbSoLuong.Text, ucThongTin.ucTangGiamSoLuongDaBan.txtbSoLuong.Text, ucThongTin.txtbGiaGoc.Text, ucThongTin.txtbGiaBan.Text, ucThongTin.txtbPhiShip.Text, "Đã duyệt", ucThongTin.cboNoiBan.Text, ucThongTin.cboXuatXu.Text, ngayMua, ucThongTin.txtbMoTaChung.Text, ucThongTin.progressSlidere_PhanTramMoi.Value.ToString(), "0", "1", ngayHienTai);
                sanPhamDao.Them(sp);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }
        private void themAnhVaMoTaVaoCSDL()
        {
            try
            {
                string id = ucThongTin.txtbIdSanPham.Text;
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        private void btnDang_Click(object sender, RoutedEventArgs e)
        {  
            //bool check = sp.kiemTraCacTextBox();
            //if (check)
            {
                try
                {
                    themThongTinVaoCSDL();
                    themAnhVaMoTaVaoCSDL();
                    MessageBox.Show("Đăng đồ thành công"); 
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                } 
            }

        }

        private void btnThemAnh_Click(object sender, RoutedEventArgs e)
        {
            DanhSachAnhVaMoTa[soLuongAnh] = new ThemAnhKhiDangUC();
            ucThongTin.wpnlChuaAnh.Children.Add(DanhSachAnhVaMoTa[soLuongAnh]);
            soLuongAnh++;
        }
    }
}

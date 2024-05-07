using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using TraoDoiDo.Models;
using TraoDoiDo.ViewModels;
using TraoDoiDo.Database;
namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for DangDo_Sua.xaml
    /// </summary>
    public partial class DangDo_Sua : Window
    {
        public int soLuongAnh = 0; 
        public ThemAnhKhiDangUC[] DanhSachAnhVaMoTa = new ThemAnhKhiDangUC[100];   

        SanPham sanPham;
        MoTaAnhSanPhamDao moTaAnhSanPhamDao;

        SanPhamDao sanPhamDao = new SanPhamDao();

        public DangDo_Sua() 
        {
            InitializeComponent(); 
        }

        public DangDo_Sua(SanPham sp)
        {
            InitializeComponent();
            sanPham = sp;
            ucThongTin.btnSua.Click += btnSua_Click;
            ucThongTin.btnThemAnh.Click += btnThemAnh_Click;
        }
         

        private void FDangDoSua_Loaded(object sender, RoutedEventArgs e)
        {
            ucThongTin.txtbIdSanPham.Text = sanPham.Id;
            ucThongTin.txtbTen.Text = sanPham.Ten;
            ucThongTin.txtbLoai.Text = sanPham.Loai;

            string dateString = sanPham.NgayMua;
            ucThongTin.dtpNgayMua.SelectedDate = DateTime.Parse(dateString);

            ucThongTin.txtbGiaBan.Text = sanPham.GiaBan;
            ucThongTin.txtbGiaGoc.Text = sanPham.GiaGoc;
            ucThongTin.cboXuatXu.Text = sanPham.XuatXu;
            ucThongTin.txtbMoTaChung.Text = sanPham.MoTaChung;
            ucThongTin.progressSlidere_PhanTramMoi.Value = Convert.ToInt32(sanPham.PhanTramMoi);
            ucThongTin.txtbPhiShip.Text = sanPham.PhiShip;
            ucThongTin.cboNoiBan.Text = sanPham.NoiBan;
            ucThongTin.ucTangGiamSoLuongTong.txtbSoLuong.Text = sanPham.SoLuong;
            ucThongTin.ucTangGiamSoLuongDaBan.txtbSoLuong.Text = sanPham.SoLuongDaBan;
        }
        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            suaAnhVaMoTaTrongCSDL(); //Phải để cái này ở trên cái dưới
            suaThongTinSanPhamTrongCSDL();
        }
        private void suaAnhVaMoTaTrongCSDL()
        {
            bool coSanPham = false;
            bool coMoTa = false;
            try
            {
                // Xóa dữ liệu cũ khỏi bảng MoTaAnhSanPham
                MoTaAnhSanPham moTaAnhSP = new MoTaAnhSanPham(ucThongTin.txtbIdSanPham.Text, null, null, null,null);
                moTaAnhSanPhamDao.Xoa(moTaAnhSP);
                coMoTa = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            //Cập  nhật dữ liệu mới
            for (int i = 0; i < soLuongAnh; i++)
            {
                coSanPham = false;
                if (DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text != null && !string.IsNullOrEmpty(DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text.Trim()) && DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text != "no_image.jpg")
                    {

                        try
                        {
                            if (coSanPham==false)
                            {
                                MoTaAnhSanPham moTaAnhSP = new MoTaAnhSanPham(ucThongTin.txtbIdSanPham.Text, (i + 1).ToString(), null, DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text, DanhSachAnhVaMoTa[i].txtbMoTa.Text);
                                moTaAnhSanPhamDao.Them(moTaAnhSP);
                                coSanPham = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message);
                        }
                         
                        XuLyAnh.LuuAnhVaoThuMuc(DanhSachAnhVaMoTa[i].txtbDuongDanAnh.Text, "HinhSanPham");
                    }
                    else
                        continue;
            }
            if (coMoTa && coSanPham)
            {
                MessageBox.Show("Thành công");
            }
        }
        
        private void suaThongTinSanPhamTrongCSDL()
        {
            try
            { 

                // Dữ liệu cần chèn
                string tenFileAnh = "no_image.jpg";
                for (int i = 0; i < soLuongAnh; i++)
                    if (DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text != null && !string.IsNullOrEmpty(DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text.Trim()) && DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text != "no_image.jpg")
                    {
                        tenFileAnh = DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text;
                        break;
                    }
                SanPham sp= new SanPham(ucThongTin.txtbIdSanPham.Text, sanPham.IdNguoiDang, ucThongTin.txtbTen.Text, tenFileAnh, ucThongTin.txtbLoai.Text, ucThongTin.ucTangGiamSoLuongTong.txtbSoLuong.Text, ucThongTin.ucTangGiamSoLuongDaBan.txtbSoLuong.Text, ucThongTin.txtbGiaGoc.Text,
                    ucThongTin.txtbGiaBan.Text, ucThongTin.txtbPhiShip.Text, "Đã duyệt", ucThongTin.cboNoiBan.Text, ucThongTin.cboXuatXu.Text, ucThongTin.dtpNgayMua.SelectedDate.Value.ToString("dd/MM/yyyy"), ucThongTin.txtbMoTaChung.Text, ucThongTin.progressSlidere_PhanTramMoi.Value.ToString(), null, null,null);
                sanPhamDao.CapNhat(sp);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        public void btnThemAnh_Click(object sender, RoutedEventArgs e)
        { 
            DanhSachAnhVaMoTa[soLuongAnh] = new ThemAnhKhiDangUC();
            ucThongTin.wpnlChuaAnh.Children.Add(DanhSachAnhVaMoTa[soLuongAnh]);
            soLuongAnh++;
        }
    }
}


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

namespace TraoDoiDo.Views.Windows
{
    /// <summary>
    /// Interaction logic for TabGioHangUC.xaml
    /// </summary>
    public partial class TabGioHangUC : UserControl
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

        public TabGioHangUC()
        {
            InitializeComponent();
        }

        public TabGioHangUC(NguoiDung ngMua)
        {
            InitializeComponent();
            this.ngMua = ngMua;
            Loaded += GioHang_Load;
        }

        private void GioHang_Load(object sender, RoutedEventArgs e)
        {
            LsvGioHang_Load(sender, e);
            LoadVoucherCuaToi(sender, e);
        }

        private void LsvGioHang_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                List<GioHang> dsGioHang = gioHangDao.timThongTinSanPhamTheoIDNguoiMua(ngMua.Id);
                lsvGioHang.Items.Clear();
                foreach (var dong in dsGioHang)
                {
                    string tenFileAnh = dong.AnhSP;
                    string linkAnhBia = XuLyAnh.layDuongDanDayDuToiFileAnhSanPham(tenFileAnh);

                    int soLuongTong = Convert.ToInt32(dong.SoLuongTong); 
                    int soLuongDaBan = Convert.ToInt32(dong.SoLuongDaBan);
                    string trangThai = "";

                    if (soLuongDaBan >= soLuongTong)
                        trangThai = "Hết hàng";
                    else
                        trangThai = "Còn hàng";
                    lsvGioHang.Items.Add(new { IdSP = dong.IdSanPham, TenSP = dong.Ten, LinkAnhBia = linkAnhBia, Gia = Convert.ToDecimal(dong.GiaBan).ToString("#,##0"), PhiShip = Convert.ToDecimal(dong.PhiShip).ToString("#,##0"), SoLuongMua = dong.SoLuongMua, TrangThaiConHayHet = trangThai });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadVoucherCuaToi(object sender, RoutedEventArgs e)
        {
            spnlVoucherCuaToi.Children.Clear();
            try
            {
                List<Voucher> dsVoucher = voucherDao.LoadVoucherTheoIdNguoiMua(ngMua.Id); 

                foreach (var dong in dsVoucher)
                {
                    VoucherUC vcUC = new VoucherUC(ngMua.Id);

                    vcUC.txtbTenVoucher.Text = dong.TenVoucher;
                    vcUC.txtbGiaTri.Text = Convert.ToDecimal(dong.GiaTri).ToString("#,##0");
                    vcUC.txtbSoLuotSuDungConLai.Text = (Convert.ToInt32(dong.SoLuotSuDungToiDa) - Convert.ToInt32(dong.SoLuotDaSuDung)).ToString();
                    vcUC.txtbNGayKetThuc.Text = dong.NgayKetThuc;
                    vcUC.txtbIdVoucher.Text = dong.IdVoucher;

                    vcUC.TextBlockChanged += vcUC_TextBlockChanged;
                    vcUC.btnNhanVoucher.Visibility = Visibility.Collapsed;

                    spnlVoucherCuaToi.Children.Add(vcUC);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void vcUC_TextBlockChanged(object sender, VoucherUC.TextBlockChangedEventArgs e) //Cho phep voucherUC có thể thay đổi textBlock của cha và gọi hàm của cha
        {
            // Cập nhật TextBlock trên form cha
            txtbgiaTriVoucher.Text = e.GiaTriMoi;
            txtbIdVoucher.Text = e.IdMoi;

            // Gọi hàm của form cha
            TinhTien();
        }
         
        private void btnXoaKhoiGioHang_Click(object sender, RoutedEventArgs e)
        { 
            Button btn = sender as Button; 
            ListViewItem dongChuaButton = HoTroTimPhanTu.FindAncestor<ListViewItem>(btn); 
            dynamic duLieuCuaDongChuaButton = dongChuaButton.DataContext;
             
            if (duLieuCuaDongChuaButton != null && MessageBox.Show("Bạn có chắc chắn muốn xóa mục đã chọn?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                try
                {
                    gioHangDao.Xoa(duLieuCuaDongChuaButton.IdSP, ngMua.Id);
                    GioHang_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra khi xóa sản phẩm: " + ex.Message);
                }  
        }
         
        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            DiaChi f = new DiaChi(ngMua, dsSanPhamDeThanhToan); 
            f.tongThanhToan = txtbTongThanhToan.Text;
            f.idVoucher = txtbIdVoucher.Text;
            f.ShowDialog();
        }

        private void ChonTatCaCacDong_Checked(object sender, RoutedEventArgs e)
        { 
            // Kiểm tra xem checkBox tổng đã được chọn hay không
            if (sender is CheckBox checkBoxTong && checkBoxTong.IsChecked.HasValue)
            {
                // Lặp qua mỗi dong trong ListView để đặt trạng thái thành đã chọn
                foreach (var dong in lsvGioHang.Items)
                { 
                    ListViewItem duLieuCuaDong = lsvGioHang.ItemContainerGenerator.ContainerFromItem(dong) as ListViewItem;
                    if (duLieuCuaDong != null)
                    { 
                        CheckBox checkBoxCuaDong = HoTroTimPhanTu.FindVisualChild<CheckBox>(duLieuCuaDong);
                        if (checkBoxCuaDong != null)
                        {
                            // Đặt trạng thái của CheckBox theo trạng thái của CheckBox chọn tất cả
                            checkBoxCuaDong.IsChecked = checkBoxTong.IsChecked;
                        }
                    }
                }
            }
            TinhTien();
        }

        private void TinhTienCuaNhungDongDuocChon_Checked(object sender, RoutedEventArgs e)
        {
            TinhTien();
        }

        private void TinhTien()
        {
            double tongTienHang = 0;
            double tongTienShip = 0;
            double tongThanhToan = 0;
            foreach (var dongDuocChon in lsvGioHang.SelectedItems)
            {
                dynamic dong = dongDuocChon;

                string idSP = dong.IdSP;
                string tenSP = dong.TenSP;

                string giaBan = dong.Gia;
                string phiShip = dong.PhiShip;
                string soLuongMua = dong.SoLuongMua; 


                string ngayThanhToan = DateTime.Now.ToString("dd/MM/yyyy");
                string trangThai = "Chờ xác nhận";


                tongTienHang += Convert.ToDouble(giaBan.Replace(",","")) * Convert.ToInt32(soLuongMua.Replace(",", ""));
                tongTienShip += Convert.ToDouble(phiShip.Replace(",", ""));

                tongThanhToan = tongTienHang + tongTienShip - Convert.ToDouble(txtbgiaTriVoucher.Text.Replace(",",""));


                dsSanPhamDeThanhToan.Add(new TrangThaiDonHang(ngMua.Id, idSP, soLuongMua, tongThanhToan.ToString(), ngayThanhToan, trangThai, tenSP, null, giaBan, phiShip, null, null, null, null));
            }

            txtbTongTienHang.Text = Convert.ToDecimal(tongTienHang).ToString("#,##0");
            txtbTongTienShip.Text = Convert.ToDecimal(tongTienShip).ToString("#,##0");
            txtbTongThanhToan.Text = Convert.ToDecimal(tongThanhToan).ToString("#,##0");
        } 
    }
}

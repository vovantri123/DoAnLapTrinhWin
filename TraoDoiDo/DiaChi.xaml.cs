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
using TraoDoiDo.Database;
using TraoDoiDo.Models;
using TraoDoiDo.ViewModels;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for DiaChiNhanHang.xaml
    /// </summary>
    public partial class DiaChi : Window
    {
        public string tongThanhToan;
        KhachHang ngDung = new KhachHang(); 
        KhacHangDao ngDungDao = new KhacHangDao();
        GioHangDao gioHangDao = new GioHangDao();
        SanPhamDao sanPhamDao = new SanPhamDao();
        TrangThaiDonHangDao trangThaiDonHangDao = new TrangThaiDonHangDao();
        QuanLyDonHangDao quanLyDonHangDao = new QuanLyDonHangDao();
        List<List<string>> listIdSP = new List<List<string>>();
        public DiaChi()
        {
            InitializeComponent();
            Loaded += FDiaChi_Loaded;
        } 
        public DiaChi(KhachHang kh)
        {
            InitializeComponent();
            ngDung = kh;
            Loaded += FDiaChi_Loaded;
        } 
        public DiaChi(KhachHang kh, List<List<string>> listId)
        {
            InitializeComponent();
            ngDung = kh;
            listIdSP = listId;
            Loaded += FDiaChi_Loaded;
        } 
        

        private void btnXacNhanThanhToan_Click_1(object sender, RoutedEventArgs e)
        {
            bool co = false;
            try
            {
                capNhatThongTinCaNhan();
                foreach (var item in listIdSP)
                {
                    GioHang gioHang = new GioHang(ngDung.Id, item[1].ToString(), item[2].ToString());
                    TrangThaiDonHang trangThaiDonHang = new TrangThaiDonHang(ngDung.Id, item[1].ToString(), item[2].ToString(), item[3].ToString(), item[4].ToString(), item[5].ToString());
                    List<string> listNguoiDang = sanPhamDao.timKiemIdNguoiDang(item[1].ToString());
                    QuanLyDonHang quanLyDonHang = new QuanLyDonHang(null, listNguoiDang[0], ngDung.Id, item[1].ToString(),"Chờ đóng gói",null);
                    quanLyDonHangDao.Xoa(quanLyDonHang);
                    quanLyDonHangDao.Them(quanLyDonHang);
                    trangThaiDonHangDao.Xoa(trangThaiDonHang);
                    trangThaiDonHangDao.Them(trangThaiDonHang);
                    gioHangDao.Xoa(gioHang);
                }
                double tienTT = Convert.ToDouble(ngDung.Tien) - Convert.ToDouble(tongThanhToan);
                if (tienTT < 0)
                    MessageBox.Show("Số tiền trong tài khoản của bạn không đủ vui lòng nạp thêm!!!!", "Thông báo",MessageBoxButton.OK, MessageBoxImage.Information);
                else
                {
                    ngDungDao.CapNhatSoTien(tienTT.ToString(), ngDung.Id);
                    co = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (co)
                MessageBox.Show("Thanh toán thành công");
        }
        private void capNhatThongTinCaNhan()
        {
            KhachHang user = new KhachHang(ngDung.Id,txtHoTen.Text,ngDung.GioiTinh,ngDung.NgaySinh,ngDung.Cmnd,txtEmail.Text,txtSoDienThoai.Text,txtDiaChi.Text,ngDung.Anh,ngDung.TaiKhoan,ngDung.Tien);
            ThongTinKhachHangViewModel ttkh = new ThongTinKhachHangViewModel(user);
            bool check = ttkh.kiemTraCacTextBox();
            if(check)
            {
                try
                {
                    List<string> listNguoiDung = new List<string>();
                    ngDungDao.CapNhatDiaChi(user);
                    listNguoiDung = ngDungDao.TimKiemTheoIdNguoi(user);
                    txtHoTen.Text = listNguoiDung[0];
                    txtSoDienThoai.Text = listNguoiDung[1];
                    txtEmail.Text = listNguoiDung[2];
                    txtDiaChi.Text = listNguoiDung[3];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void FDiaChi_Loaded(object sender, RoutedEventArgs e)
        {
            txtHoTen.Text = ngDung.HoTen.ToString();
            txtSoDienThoai.Text = ngDung.Sdt.ToString();
            txtEmail.Text = ngDung.Email.ToString();
            txtDiaChi.Text = ngDung.DiaChi.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Channels;
using TraoDoiDo.ViewModels;
using System.Reflection;
using TraoDoiDo.Models;
using TraoDoiDo.Database; 



namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for ThongTinChiTietSanPham.xaml
    /// </summary>
    public partial class ThongTinChiTietSanPham : Window
    {
        public string idNguoiMua;
        public string idNguoiDang;
        public string idSanPham ;
        private SanPhamUC[] DanhSachSanPham ;
        public string linkAnhBiaGlobal = "";
        SanPham sanPham = new SanPham();
        SanPham sp = new SanPham();
        SanPhamDao spDao = new SanPhamDao();
        QuanLyDonHangDao quanLyDonHangDao = new QuanLyDonHangDao();
        KhacHangDao khDao = new KhacHangDao();
        private List<string> danhSachAnh = new List<string>();

        private int currentIndex = -1;
        public ObservableCollection<ListViewItem> Items { get; set; }

        public ThongTinChiTietSanPham()
        {

            InitializeComponent();
            
            Loaded += LoadAnhVaMoTa;
            Loaded += LoadThongTinSanPham;
            Loaded += btnAnhSau_Click;
            Loaded += LoadThongTinNguoiDang;
        }

        public ThongTinChiTietSanPham(SanPham sp)
        {

            InitializeComponent();
            
            Loaded += LoadAnhVaMoTa;
            Loaded += LoadThongTinSanPham;
            Loaded += btnAnhSau_Click;
            Loaded += LoadThongTinNguoiDang;
          
            sanPham = sp;
        }

        #region THÊM SẢN PHẨM CÙNG LOẠI VÀO MỤC KHÁM PHÁ THÊM


        


        private void LoadSanPhamlenWpnlHienThi(object sender, RoutedEventArgs e)
        {
            try
            {
                List<List<string>> listSanPhamCungLoai = new List<List<string>>();
                listSanPhamCungLoai = spDao.LoadSanPhamCungLoai(sp);
                DanhSachSanPham = new SanPhamUC[listSanPhamCungLoai.Count+1];
                wpnlHienThiSPCungLoai.Children.Clear();
                int i = 0;
                foreach(var list in listSanPhamCungLoai)
                {
                    int yeuThich = 0;
                    if (!string.IsNullOrEmpty(list[6])) //Neu nguoi mua co trong bang yeu thich (tức đang yêu thich một sản phẩm nào đó)
                    {
                        yeuThich = 1;
                    }
                    DanhSachSanPham[i] = new SanPhamUC(yeuThich);

                    DanhSachSanPham[i].txtbIdSanPham.Text = list[0].ToString();
                    DanhSachSanPham[i].txtbTen.Text = list[1];

                    string tenFileAnh = list[2];
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    string duongDanhAnh = XuLyAnh.layDuongDanDayDuToiFileAnh(tenFileAnh);
                    bitmap.UriSource = new Uri(duongDanhAnh);
                    bitmap.EndInit();
                    // Gán BitmapImage tới Source của Image control
                    DanhSachSanPham[i].imgSP.Source = bitmap;

                    DanhSachSanPham[i].txtbGiaGoc.Text = list[3];
                    DanhSachSanPham[i].txtbGiaBan.Text = list[4];
                    DanhSachSanPham[i].txtbNoiBan.Text = list[5];
                    DanhSachSanPham[i].txtbLoai.Text = list[7];

                    //SanPham sanPham = new SanPham(id, name, imageUrl); 
                    //lsvQuanLySanPham.Items.Add(sanPham);
                    DanhSachSanPham[i].Margin = new Thickness(8);
                    DanhSachSanPham[i].btnBoYeuThich.Visibility = Visibility.Collapsed;
                    DanhSachSanPham[i].btnThemVaoYeuThich.Visibility = Visibility.Collapsed;
                    wpnlHienThiSPCungLoai.Children.Add(DanhSachSanPham[i]);
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void LoadThongTinNguoiDang(object sender, RoutedEventArgs e)
        {
            string linkAnh = khDao.TimKiemLinkAnh(idNguoiDang);
            imgAnhNguoiDang.Source = new BitmapImage(new Uri(XuLyAnh.layDuongDanDayDuToiFileAnhDaiDien(linkAnh)));
            List<string> listNgDang = spDao.timKiemIdNguoiDang(idNguoiDang);
            txtbTenNguoiDang.Text = listNgDang[1];
        }


        private void LoadAnhVaMoTa(object sender, RoutedEventArgs e)
        {
            try
            {
                List<List<string>> listAnhVaMoTa = new List<List<string>>();
                listAnhVaMoTa = spDao.LoadAnhVaMoTa(sanPham);

                foreach (var list in listAnhVaMoTa)
                {
                    string linkAnhBia = list[0];
                    linkAnhBiaGlobal = list[0];
                    string moTa = list[2];
                    string linkAnhMinhHoa = XuLyAnh.layDuongDanDayDuToiFileAnh(list[1]);
                    danhSachAnh.Add(linkAnhMinhHoa); //Lấy đường dẫn để bỏ vào hình bên trên
                    if (moTa.Trim() == "")
                        continue;
                    //lsvThongTinChiTietSP.Items.Add(new { LinkAnhMinhHoa = linkAnhMinhHoa, MoTa = moTa });
                    lsvThongTinChiTietSP.Items.Add(new { MoTa = "- " + moTa }); 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadThongTinSanPham(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> listThongTinSP = spDao.LoadThongTinSanPham(sanPham);
                sp = new SanPham(sanPham.Id, sanPham.IdNguoi, listThongTinSP[0], linkAnhBiaGlobal, listThongTinSP[1], listThongTinSP[2], listThongTinSP[3], listThongTinSP[4],listThongTinSP[5], listThongTinSP[6],null, listThongTinSP[7], listThongTinSP[8], listThongTinSP[9],listThongTinSP[11], listThongTinSP[10], sanPham.LuotXem);
                string soLuong = listThongTinSP[2];
                string soLuongDaBan = listThongTinSP[3];
                txtbSoLuongConLai.Text = (Convert.ToInt32(soLuong) - Convert.ToInt32(soLuongDaBan)).ToString();
                txtbTen.Text = sp.Ten;
                txtbLoai.Text = sp.Loai;
                txtbGiaGoc.Text = sp.GiaGoc;
                txtbGiaBan.Text = sp.GiaBan;
                txtbPhiShip.Text = sp.PhiShip;
                txtbNoiBan.Text = sp.NoiBan;
                txtbXuatXu.Text = sp.XuatXu;
                txtbNgayMua.Text = sp.NgayMua;
                txtbPhanTramConMoi.Text = sp.PhanTramMoi;
                txtbMoTaChung.Text = sp.MoTaChung;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadSanPhamlenWpnlHienThi(sender, e);
            }
        }

        private void ThongTinNguoiDang_Click(object sender, RoutedEventArgs e)
        {
            ThongTinNguoiDang f = new ThongTinNguoiDang(idNguoiDang.ToString());
            f.Show();
        }


        private void DisplayImage()
        {
            // Load and display the current image
            string imagePath = danhSachAnh[currentIndex];
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imagePath);
            bitmapImage.EndInit();

            imgAnhSP.Source = bitmapImage;
        }


        private void btnAnhTruoc_Click(object sender, RoutedEventArgs e)
        {
            if (danhSachAnh.Count > 0)
            {
                // Move to the previous image
                currentIndex--;

                // Check if we have reached the beginning of the list
                if (currentIndex < 0)
                {
                    // Set currentIndex to the last image index
                    currentIndex = danhSachAnh.Count - 1;
                }

                DisplayImage();
            }
        }

        private void btnAnhSau_Click(object sender, RoutedEventArgs e)
        {
            if (danhSachAnh.Count > 0)
            {
                // Move to the next image
                currentIndex++;

                // Check if we have reached the end of the list
                if (currentIndex >= danhSachAnh.Count)
                {
                    // Set currentIndex back to the first image index
                    currentIndex = 0;
                }

                DisplayImage();
            }
        }


        private void btnThemVaoGioHang_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> listSP = spDao.timKiemToanBoBangId(sp.Id);
                idNguoiMua = quanLyDonHangDao.timIdNguoiMua(listSP[1], listSP[0]);
                GioHang gioHang = new GioHang(idNguoiMua, idSanPham, txtbSoLuongHienTai.Text);
                GioHangDao gioHangDao = new GioHangDao();
                gioHangDao.Xoa(gioHang);
                gioHangDao.Them(gioHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        private void btnTang_Click(object sender, RoutedEventArgs e)
        {
            int n = Convert.ToInt32(txtbSoLuongHienTai.Text);
            if (n + 1 <= Convert.ToInt32(txtbSoLuongConLai.Text))
            {
                n += 1;
            }

            txtbSoLuongHienTai.Text = n.ToString();


        }

        private void btnGiam_Click(object sender, RoutedEventArgs e)
        {
            int n = Convert.ToInt32(txtbSoLuongHienTai.Text);
            if (n - 1 > 0)
            {
                n -= 1;
            }
            txtbSoLuongHienTai.Text = n.ToString();
        }
    }
}

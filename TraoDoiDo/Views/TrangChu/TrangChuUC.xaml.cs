using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using TraoDoiDo.Database;
using TraoDoiDo.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for TrangChu.xaml
    /// </summary>
    public partial class TrangChuUC : UserControl
    { 
        private VoucherUC[] DanhSachVoucher = new VoucherUC[150]; //Load lên UI
        private int soLuongVoucher;
        VoucherDao voucherDao;
        NguoiDungDao nguoiDao;
        TrangThaiDonHangDao trangThaiDonHangDao;
        private string idNguoiMua;

        private List<string> imagePaths = new List<string>
        {
            "/HinhCuaToi/TrangChu/tc5.jpg", 
            "/HinhCuaToi/TrangChu/tc6.jpg", 
            "/HinhCuaToi/TrangChu/tc4.jpg",
            "/HinhCuaToi/TrangChu/tc9.jpg",
            "/HinhCuaToi/TrangChu/tc1.jpg", 
            "/HinhCuaToi/TrangChu/tc2.png", 
            "/HinhCuaToi/TrangChu/tc3.jpg", 
            "/HinhCuaToi/TrangChu/tc7.jpg", 
            "/HinhCuaToi/TrangChu/tc8.jpg",  
            "/HinhCuaToi/TrangChu/tc10.jpg",  
            // Add more image paths as needed
        }; 
        private int currentIndex = 0;
        private DispatcherTimer timer;

        public TrangChuUC(string idNguoiMua)
        {
            this.idNguoiMua = idNguoiMua;
            InitializeComponent();

            if (imagePaths.Count > 0)
            {
                // Khởi động timer cho slideshow
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(3.0); // Thay đổi khoảng thời gian theo ý muốn
                timer.Tick += Timer_Tick;
                timer.Start();

                // Hiển thị ảnh đầu tiên
                DisplayImage();
            }
            LoadVoucherlenWpnlDanhSachVoucher();
            loadDSNGuoiHayMua();
        }

        private void LoadVoucherlenWpnlDanhSachVoucher()
        {
            soLuongVoucher = 0;
            wpnlDSVoucher.Children.Clear();
            try
            {  
                voucherDao = new VoucherDao();
                List<Voucher> dsVoucher = voucherDao.LoadVoucher(); // DS này lấy từ database

                foreach (var dong in dsVoucher)
                {
                    DanhSachVoucher[soLuongVoucher] = new VoucherUC(idNguoiMua);
                    DanhSachVoucher[soLuongVoucher].txtbTenVoucher.Text = dong.TenVoucher;
                    DanhSachVoucher[soLuongVoucher].txtbGiaTri.Text = dong.GiaTri;
                    DanhSachVoucher[soLuongVoucher].txtbSoLuotSuDungConLai.Text = (Convert.ToInt32(dong.SoLuotSuDungToiDa) - Convert.ToInt32(dong.SoLuotDaSuDung)).ToString();
                    DanhSachVoucher[soLuongVoucher].txtbNGayKetThuc.Text = dong.NgayKetThuc;
                    DanhSachVoucher[soLuongVoucher].txtbIdVoucher.Text = dong.IdVoucher;

                    DanhSachVoucher[soLuongVoucher].btnDungVoucher.Visibility = Visibility.Collapsed;

                    wpnlDSVoucher.Children.Add(DanhSachVoucher[soLuongVoucher]); //Có thể không cần dùng LIST DanhSachVoucher cũng được, do không có dùng lại như bên mua đồ
                    soLuongVoucher++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
          
        } 
        public void loadDSNGuoiHayMua()
        {
            int demSoNguoiMuonLoc = 0; 
            wpnlDSNguoiHayMua.Children.Clear();
            try
            {
                nguoiDao = new NguoiDungDao(); 
                List<NguoiDung> dsNguoiHayMua = nguoiDao.LoadDanhSachNguoiHayMuaNhat();
                foreach (var dong in dsNguoiHayMua)
                {
                    if (demSoNguoiMuonLoc >= 5)
                        break;
                    //MessageBox.Show( + " hehehihi");
                    MucXepHangNguoiMuaNhieuNhatUC nguoiHayMuaUC = new MucXepHangNguoiMuaNhieuNhatUC(dong);
                      
                    wpnlDSNguoiHayMua.Children.Add(nguoiHayMuaUC);
                    demSoNguoiMuonLoc++;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }




        // Các phương thức khác của lớp
        private void DisplayImage()
        {
            // Load and display the current image
            string imagePath = imagePaths[currentIndex];
            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
            imageControl.Source = bitmapImage;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Move to the next image
            currentIndex = (currentIndex + 1) % imagePaths.Count;
            DisplayImage();
        }

        // Sự kiện khi nhấn nút Previous
        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            // Move to the previous image
            currentIndex--;

            // Check if we have reached the beginning of the list
            if (currentIndex < 0)
            {
                // Set currentIndex to the last image index
                currentIndex = imagePaths.Count - 1;
            }

            DisplayImage();
        }

        // Sự kiện khi nhấn nút Next
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Move to the next image
            currentIndex++;

            // Check if we have reached the end of the list
            if (currentIndex >= imagePaths.Count)
            {
                // Set currentIndex back to the first image index
                currentIndex = 0;
            }

            DisplayImage();
        }
    }
}

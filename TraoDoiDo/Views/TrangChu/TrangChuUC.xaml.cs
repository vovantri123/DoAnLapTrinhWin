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
        private VoucherUC[] DanhSachVoucher = new VoucherUC[150];
        private int soLuongVoucher = 0; 

        private string idNguoiMua;
        private int indexAnhHienTai = 0;
        private DispatcherTimer timer;

        VoucherDao voucherDao;
        NguoiDungDao nguoiDao; 

        private List<string> LishDuongDanAnh = new List<string>
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
            // Thêm nhiều đường dẫn nữa nêu muốn
        }; 
        

        public TrangChuUC(string idNguoiMua)
        {
            this.idNguoiMua = idNguoiMua;
            InitializeComponent();

            if (LishDuongDanAnh.Count > 0)
            {
                // Khởi động timer cho slideshow
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(3.0); // Thay đổi khoảng thời gian theo ý muốn
                timer.Tick += Timer_Tick;
                timer.Start();

                // Hiển thị ảnh đầu tiên
                HienThiAnh();
            }
            LoadVoucherlenWpnlDanhSachVoucher();
            loadDSNGuoiHayMua();
        }

        private void LoadVoucherlenWpnlDanhSachVoucher()
        {
            
            wpnlDSVoucher.Children.Clear();
            try
            {  
                voucherDao = new VoucherDao();
                List<Voucher> dsVoucher = voucherDao.LoadVoucher();  

                foreach (var dong in dsVoucher)
                {
                    DanhSachVoucher[soLuongVoucher] = new VoucherUC(idNguoiMua);
                    DanhSachVoucher[soLuongVoucher].txtbTenVoucher.Text = dong.TenVoucher;
                    DanhSachVoucher[soLuongVoucher].txtbGiaTri.Text = Convert.ToDecimal(dong.GiaTri).ToString("#,##0");
                    
                    DanhSachVoucher[soLuongVoucher].txtbSoLuotSuDungConLai.Text = (Convert.ToInt32(dong.SoLuotSuDungToiDa) - Convert.ToInt32(dong.SoLuotDaSuDung)).ToString();
                    DanhSachVoucher[soLuongVoucher].txtbNGayKetThuc.Text = dong.NgayKetThuc;
                    DanhSachVoucher[soLuongVoucher].txtbIdVoucher.Text = dong.IdVoucher;

                    DanhSachVoucher[soLuongVoucher].btnDungVoucher.Visibility = Visibility.Collapsed;

                    wpnlDSVoucher.Children.Add(DanhSachVoucher[soLuongVoucher]); 
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
         
        private void HienThiAnh()
        { 
            string duongDanAnh = LishDuongDanAnh[indexAnhHienTai];
            BitmapImage bitmapImage = new BitmapImage(new Uri(duongDanAnh, UriKind.RelativeOrAbsolute));
            imageControl.Source = bitmapImage;
        }

        private void Timer_Tick(object sender, EventArgs e)
        { 
            indexAnhHienTai = (indexAnhHienTai + 1) % LishDuongDanAnh.Count;
            HienThiAnh();
        }
         
        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        { 
            indexAnhHienTai--;
             
            if (indexAnhHienTai < 0) 
                indexAnhHienTai = LishDuongDanAnh.Count - 1; 

            HienThiAnh();
        }
         
        private void NextButton_Click(object sender, RoutedEventArgs e)
        { 
            indexAnhHienTai++;
             
            if (indexAnhHienTai >= LishDuongDanAnh.Count) 
                indexAnhHienTai = 0; 

            HienThiAnh();
        }
    }
}

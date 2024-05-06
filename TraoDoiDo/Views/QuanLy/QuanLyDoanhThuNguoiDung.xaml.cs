using LiveCharts.Wpf;
using LiveCharts;
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
using System.Windows.Shapes;
using TraoDoiDo.Models;
using TraoDoiDo.Database;

namespace TraoDoiDo.Views.QuanLy
{
    /// <summary>
    /// Interaction logic for QuanLyDoanhThuNguoiDung.xaml
    /// </summary>
    public partial class QuanLyDoanhThuNguoiDung : Window
    {
        TrangThaiDonHangDao trangThaiDao = new TrangThaiDonHangDao();
        SanPhamDao sanPhamDao = new SanPhamDao();
        NguoiDung nguoiDung = new NguoiDung();
        
        public QuanLyDoanhThuNguoiDung()
        {
            InitializeComponent();
        }
        public QuanLyDoanhThuNguoiDung(NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
            
        }
        #region Hàm Load tỉ lệ
        // Hàm load doanh thu theo tháng trong năm
        private void LoadTiLeDoanhThuTheoNam(string idNguoi, string nam)
        {
            try
            {
                List<string> dsNhan = new List<string>(12)
                {
                    "1","2","3","4","5","6","7","8","9","10","11","12",
                };
                List<int> dsCotDoanhThu = new List<int>();
                for (int i = 0; i < 12; i++)
                {
                    dsCotDoanhThu.Add(0);
                }

                List<SanPham> dsTiLeDoanhThu = sanPhamDao.LoadThongSoSanPhamDeThongKeTheoNam(idNguoi, nam);
                foreach (var dong in dsTiLeDoanhThu)
                {
                    DateTime t = DateTime.ParseExact(dong.NgayMua, "d/M/yyyy", null);
                    int thang = t.Month;
                    dsCotDoanhThu[thang - 1] += Convert.ToInt32(dong.GiaBan);

                }

                // Tạo SeriesCollection cho biểu đồ PieChart
                SeriesCollection TiLePhanTramDoanhThuTheoSanPham_SC = new SeriesCollection();

                // Tạo các Slice (phần chia) cho PieChart từ dữ liệu
                for (int i = 0; i < dsNhan.Count; i++)
                {
                    TiLePhanTramDoanhThuTheoSanPham_SC.Add(new PieSeries
                    {
                        Title = dsNhan[i], // Tên sản phẩm
                        Values = new ChartValues<int> { dsCotDoanhThu[i] } // Doanh thu tương ứng với sản phẩm

                    });
                }

                chart_TiLePhanTramDoanhThuTheoSanPham.Series = TiLePhanTramDoanhThuTheoSanPham_SC;

            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e);
            }
        }
        private void LoadTiLeSoLuongDaBanTheoNam(string idNguoi, string nam)
        {
            try
            {
                List<string> dsNhan = new List<string>(12)
                {
                    "1","2","3","4","5","6","7","8","9","10","11","12",
                };
                List<int> dsCotSoLuongDaBan = new List<int>();
                for (int i = 0; i < 12; i++)
                {
                    dsCotSoLuongDaBan.Add(0);
                }

                List<SanPham> dsTiLeSLDaBan = sanPhamDao.LoadThongSoSanPhamDeThongKeTheoNam(idNguoi, nam);
                foreach (var dong in dsTiLeSLDaBan)
                {
                    DateTime t = DateTime.ParseExact(dong.NgayMua, "d/M/yyyy", null);
                    int thang = t.Month;
                    dsCotSoLuongDaBan[thang - 1] += Convert.ToInt32(dong.SoLuongDaBan);

                }

                // Tạo SeriesCollection cho biểu đồ PieChart
                SeriesCollection TiLePhanTramDoanhThuTheoSanPham_SC = new SeriesCollection();

                // Tạo các Slice (phần chia) cho PieChart từ dữ liệu
                for (int i = 0; i < dsNhan.Count; i++)
                {
                    TiLePhanTramDoanhThuTheoSanPham_SC.Add(new PieSeries
                    {
                        Title = dsNhan[i], // Tên sản phẩm
                        Values = new ChartValues<int> { dsCotSoLuongDaBan[i] } // Doanh thu tương ứng với sản phẩm

                    });
                }

                chart_TiLePhanTramSoLuongSanPham.Series = TiLePhanTramDoanhThuTheoSanPham_SC;

            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e);
            }
        }
        private void LoadTiLeSoLuongKhachHangTheoNam(string idNguoi, string nam)
        {
            try
            {
                List<string> dsNhan = new List<string>(12)
                {
                    "1","2","3","4","5","6","7","8","9","10","11","12",
                };
                List<int> dsCotSoKH= new List<int>();
                
               
                for (int i = 1; i <= 12; i++)
                {

                    int soLuongKH = Convert.ToInt32(sanPhamDao.tinhTongKhachHangTheoNam(idNguoi, nam, i.ToString()));
                    dsCotSoKH.Add(soLuongKH);
                }

                // Tạo SeriesCollection cho biểu đồ PieChart
                SeriesCollection TiLePhanTramDoanhThuTheoSanPham_SC = new SeriesCollection();

                // Tạo các Slice (phần chia) cho PieChart từ dữ liệu
                for (int i = 0; i < dsNhan.Count; i++)
                {
                    TiLePhanTramDoanhThuTheoSanPham_SC.Add(new PieSeries
                    {
                        Title = dsNhan[i], // Tên sản phẩm
                        Values = new ChartValues<int> { dsCotSoKH[i] } // Doanh thu tương ứng với sản phẩm

                    });
                }

                chart_TiLePhanTramSoLuongKhachHang.Series = TiLePhanTramDoanhThuTheoSanPham_SC;

            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e);
            }
        }
        #endregion
        #region Hàm load đồ thị cột
        private void LoadSoLuongKhachHangTheoNam(string idNguoi, string nam)
        {
            try
            {
                List<string> dsNhan = new List<string>(12)
                {
                    "1","2","3","4","5","6","7","8","9","10","11","12",
                };
                List<int> dsCotSoLuongKH = new List<int>();

                for(int i=1;i<=12;i++)
                {

                    int soLuongKH = Convert.ToInt32(sanPhamDao.tinhTongKhachHangTheoNam(idNguoi, nam, i.ToString()));
                    dsCotSoLuongKH.Add(soLuongKH);
                }

                // Tạo 2 cột cạnh nhau
                SeriesCollection SoLuongKH_SC = new SeriesCollection
                {
                     new ColumnSeries
                     {
                         Title = "Số lượng khách hàng",
                         Values = new ChartValues<int>(dsCotSoLuongKH),

                         Fill = Brushes.Cyan, // Màu của cột số lượng đã bán
                         ScalesYAt = 0

                     },

                };

                // Đặt dữ liệu vào Chart
                chart_SoLuongKhachHang.Series = SoLuongKH_SC;

                var xAxis = new LiveCharts.Wpf.Axis
                {
                    Title = "Tháng",
                    Labels = dsNhan.ToArray(),
                    FontSize = 9.5,
                    Separator = LiveCharts.Wpf.DefaultAxes.CleanSeparator

                };
                chart_SoLuongKhachHang.AxisX.Add(xAxis);

                var yAxis = new LiveCharts.Wpf.Axis
                {
                    Title = "Số lượng",
                    FontSize = 9.5,
                    LabelFormatter = value => value.ToString("#,##0") // Định dạng label cho trục Y thứ nhất
                };
                chart_SoLuongKhachHang.AxisY.Add(yAxis);
                txtbTongSoLuongKhachHang.Text = Convert.ToDecimal(dsCotSoLuongKH.Sum()).ToString("#,##0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
        }
        
        private void LoadSoLuongSanPhamDaBan(string idNguoi,string nam)
        {
            try
            {
                List<string> dsNhan = new List<string>(12)
                {
                    "1","2","3","4","5","6","7","8","9","10","11","12",
                };
                
                List<int> dsCotSoLuongDaBan = new List<int>();
                for (int i = 0; i < 12; i++)
                {
                    dsCotSoLuongDaBan.Add(0);
                }
               
                List<SanPham> dsSLDaBan = sanPhamDao.LoadThongSoSanPhamDeThongKeTheoNam(idNguoi, nam);

                foreach (var dong in dsSLDaBan)
                {
                    DateTime t = DateTime.ParseExact(dong.NgayMua, "d/M/yyyy", null);
                    int thang = t.Month;
                    dsCotSoLuongDaBan[thang - 1] += Convert.ToInt32(dong.SoLuongDaBan);
                }

                // Tạo 2 cột cạnh nhau
                SeriesCollection DoanhThuTheoSanPham_SC = new SeriesCollection
                {
                     new ColumnSeries
                     {
                         Title = "Số lượng đã bán",
                         Values = new ChartValues<int>(dsCotSoLuongDaBan),

                         Fill = Brushes.LightSkyBlue, // Màu của cột số lượng đã bán
                         ScalesYAt = 0

                     },

                };

                // Đặt dữ liệu vào Chart
                chart_SoLuongSanPhamDaBan.Series = DoanhThuTheoSanPham_SC;

                var xAxis = new LiveCharts.Wpf.Axis
                {
                    Title = "Tháng",
                    Labels = dsNhan.ToArray(),
                    FontSize = 9.5,
                    Separator = LiveCharts.Wpf.DefaultAxes.CleanSeparator

                };
                chart_SoLuongSanPhamDaBan.AxisX.Add(xAxis);

                var yAxis = new LiveCharts.Wpf.Axis
                {
                    Title = "Số lượng",
                    FontSize = 9.5,
                    LabelFormatter = value => value.ToString("#,##0") // Định dạng label cho trục Y thứ nhất
                };
                chart_SoLuongSanPhamDaBan.AxisY.Add(yAxis);
                txtbTongSoLuongSanPhamDaBan.Text = Convert.ToDecimal(dsCotSoLuongDaBan.Sum()).ToString("#,##0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
           
        }
        
        private void LoadDoanhThuTheoNam(string idNguoi, string nam)
        {
            List<string> dsNhan = new List<string>(12)
                {
                    "1","2","3","4","5","6","7","8","9","10","11","12",
                };

            List<int> dsCotDoanhThu = new List<int>();
            for (int i = 0; i < 12; i++)
            {
                dsCotDoanhThu.Add(0);
            }
           
            List<TrangThaiDonHang> dsDoanhThuSanPham = trangThaiDao.LoadDoThiThongKeDoanhThuTheoNam(idNguoi, nam);
            foreach (var dong in dsDoanhThuSanPham)
            {
                DateTime t = DateTime.ParseExact(dong.Ngay, "d/M/yyyy", null);
                int thang = t.Month;
                dsCotDoanhThu[thang - 1] += Convert.ToInt32(dong.TongThanhToan);
            }
            

            SeriesCollection DoanhThuTheoSanPham_SC = new SeriesCollection
                    {
                         new ColumnSeries
                         {
                             Title = "Doanh thu",
                             Values = new ChartValues<int> (dsCotDoanhThu)
                         }
                    };


            // Đặt dữ liệu vào Chart
            chart_TongDoanhThuTheoSanPham.Series = DoanhThuTheoSanPham_SC;

            var xAxis = new LiveCharts.Wpf.Axis
            {
                Title = "Tháng",
                FontSize = 9.5,
                Labels = dsNhan.ToArray(),
                Separator = LiveCharts.Wpf.DefaultAxes.CleanSeparator
            };
            chart_TongDoanhThuTheoSanPham.AxisX.Add(xAxis);

            var yAxis = new LiveCharts.Wpf.Axis
            {
                Title = "Doanh thu",
                FontSize = 9.5,
                LabelFormatter = value => value.ToString("#,##0,##0") // Định dạng label
            };
            chart_TongDoanhThuTheoSanPham.AxisY.Add(yAxis);
            txtbDoanhThuCaoNhat.Text = Convert.ToDecimal(dsCotDoanhThu.Sum()).ToString("#,##0");

        }
        #endregion
        private void cboNam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ComboBox comboBox = sender as ComboBox;

            string selectedItemContent = comboBox.SelectedItem.ToString().Trim();

            //lblChartDoanhThuTheoNam.Text = $"Tổng doanh thu theo năm {selectedItemContent}";
            chart_TongDoanhThuTheoSanPham.Series.Clear();
            chart_TongDoanhThuTheoSanPham.AxisX.Clear();
            chart_TongDoanhThuTheoSanPham.AxisY.Clear();
            LoadDoanhThuTheoNam(nguoiDung.Id, selectedItemContent);

            chart_TiLePhanTramDoanhThuTheoSanPham.Series.Clear();
            LoadTiLeDoanhThuTheoNam(nguoiDung.Id, selectedItemContent);

            chart_SoLuongSanPhamDaBan.Series.Clear();   
            chart_SoLuongSanPhamDaBan.AxisX.Clear();
            chart_SoLuongSanPhamDaBan.AxisY.Clear();
            LoadSoLuongSanPhamDaBan(nguoiDung.Id,selectedItemContent);

            chart_TiLePhanTramSoLuongSanPham.Series.Clear();
            LoadTiLeSoLuongDaBanTheoNam(nguoiDung.Id,selectedItemContent);

            chart_SoLuongKhachHang.Series.Clear();
            chart_SoLuongKhachHang.AxisX.Clear();
            chart_SoLuongKhachHang.AxisY.Clear();
            LoadSoLuongKhachHangTheoNam(nguoiDung.Id, selectedItemContent);

            chart_TiLePhanTramSoLuongKhachHang.Series.Clear();
            LoadTiLeSoLuongKhachHangTheoNam(nguoiDung.Id, selectedItemContent);
        }

        private void FQuanLyDoanhThu_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTiLeDoanhThuTheoNam(nguoiDung.Id, "2024");
            LoadDoanhThuTheoNam(nguoiDung.Id, "2024");
            LoadSoLuongSanPhamDaBan(nguoiDung.Id, "2024");
            LoadTiLeSoLuongDaBanTheoNam(nguoiDung.Id, "2024");
            LoadSoLuongKhachHangTheoNam(nguoiDung.Id, "2024");
            LoadTiLeSoLuongKhachHangTheoNam(nguoiDung.Id, "2024");
        }

        private void cboNam_Loaded(object sender, RoutedEventArgs e)
        {
            int namHienTai = DateTime.Now.Year;
            int namTruoc = namHienTai - 1;
            int namTruocTruoc = namTruoc - 1;
            List<string> nam = new List<string>()
            {
                $"{namHienTai}",$"{namTruoc}",$"{namTruocTruoc}",
            };
            foreach (var x in nam)
            {
                cboNam.Items.Add(x);
            }
        }
    }
}

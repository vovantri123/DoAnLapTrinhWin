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
using LiveCharts.Wpf.Charts.Base;
using TraoDoiDo.Models;
using TraoDoiDo.Database;


namespace TraoDoiDo.Views.QuanLy
{
    /// <summary>
    /// Interaction logic for QuanLyDoanhThuNguoiDung.xaml
    /// </summary>
    public partial class QuanLyDoanhThuNguoiDung : Window
    {
        SanPhamDao sanPhamDao = new SanPhamDao();
        NguoiDung nguoiDung = new NguoiDung();
        List<string> dsNhan = new List<string>(12)
        {
                    "1","2","3","4","5","6","7","8","9","10","11","12",
        };
        int countLoad = 0;
        public QuanLyDoanhThuNguoiDung()
        {
            InitializeComponent();
        }
        public QuanLyDoanhThuNguoiDung(NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;

        }
        #region Hàm load đồ thị
        private void LoadDoThi(string idNguoi, string nam)
        {
            List<int> dsCotDoanhThu = Enumerable.Repeat(0, 12).ToList();
            List<int> dsCotSoLuongDaBan = Enumerable.Repeat(0, 12).ToList();
            List<int> dsCotSoLuongKH = Enumerable.Repeat(0, 12).ToList();
            int id = Convert.ToInt32(idNguoi);
            List<SanPham> dsDoanhThuSanPham = sanPhamDao.LoadThongSoSanPhamDeThongKeTheoNam(idNguoi, nam);
            foreach (var dong in dsDoanhThuSanPham)
            {
                DateTime t = DateTime.ParseExact(dong.NgayMua, "d/M/yyyy", null);
                int thang = t.Month;
                dsCotDoanhThu[thang - 1] += Convert.ToInt32(dong.GiaBan);
                dsCotSoLuongDaBan[thang - 1] += Convert.ToInt32(dong.SoLuongDaBan);
            }
            for (int i = 1; i <= 12; i++)
            {
                int soLuongKH = Convert.ToInt32(sanPhamDao.TinhTongKhachHangTheoNam(idNguoi, nam, i.ToString()));
                dsCotSoLuongKH[i-1] +=soLuongKH;

            }

            HamVeDoThiCot(dsCotDoanhThu, chart_TongDoanhThuTheoSanPham, "Doanh thu", "Tháng", "Doanh thu");
            HamVeDoThiTron(dsCotDoanhThu, chart_TiLePhanTramDoanhThuTheoSanPham);
            HamVeDoThiCot(dsCotSoLuongDaBan, chart_SoLuongSanPhamDaBan, "Số lượng đã bán", "Tháng", "Số lượng");
            HamVeDoThiTron(dsCotSoLuongDaBan, chart_TiLePhanTramSoLuongSanPham);
            HamVeDoThiCot(dsCotSoLuongKH, chart_SoLuongKhachHang, "Số lượng khách hàng", "Tháng", "Số lượng");
            HamVeDoThiTron(dsCotSoLuongKH, chart_TiLePhanTramSoLuongKhachHang);

            txtbDoanhThuCaoNhat.Text = Convert.ToDecimal(dsCotDoanhThu.Sum()).ToString("#,##0");
            txtbTongSoLuongSanPhamDaBan.Text = Convert.ToDecimal(dsCotSoLuongDaBan.Sum()).ToString("#,##0");
            txtbTongSoLuongKhachHang.Text = Convert.ToDecimal(dsCotSoLuongKH.Sum()).ToString("#,##0");

        }
        #endregion
        private void cboNam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ComboBox comboBox = sender as ComboBox;

            string selectedItemContent = comboBox.SelectedItem.ToString().Trim();
            LoadDoThi(nguoiDung.Id.ToString(), selectedItemContent);
        }

        private void FQuanLyDoanhThu_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDoThi(nguoiDung.Id.ToString(), "2024");
            countLoad = 1;
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
        private void HamVeDoThiTron(List<int> dsCot, Chart doThi)
        {
            if (countLoad > 0)
            {
                doThi.Series.Clear();

            }
            SeriesCollection TiLePhanTramDoanhThuTheoSanPham_SC = new SeriesCollection();

            // Tạo các Slice (phần chia) cho PieChart từ dữ liệu
            for (int i = 0; i < dsNhan.Count; i++)
            {
                TiLePhanTramDoanhThuTheoSanPham_SC.Add(new PieSeries
                {
                    Title = dsNhan[i], // Tên sản phẩm
                    Values = new ChartValues<int> { dsCot[i] } // Doanh thu tương ứng với sản phẩm

                });
            }

            doThi.Series = TiLePhanTramDoanhThuTheoSanPham_SC;

        }
        private void HamVeDoThiCot(List<int> dsCot, Chart doThi, string tieuDe, string X, string Y)
        {
            if (countLoad > 0)
            {
                doThi.Series.Clear();
                doThi.AxisX.Clear();
                doThi.AxisY.Clear();
            }
            SeriesCollection DoanhThuTheoSanPham_SC = new SeriesCollection
                    {
                         new ColumnSeries
                         {
                             Title = $"{tieuDe}",
                             Values = new ChartValues<int> (dsCot)
                         }
                    };


            // Đặt dữ liệu vào Chart
            doThi.Series = DoanhThuTheoSanPham_SC;

            var xAxis = new LiveCharts.Wpf.Axis
            {
                Title = $"{X}",
                FontSize = 9.5,
                Labels = dsNhan.ToArray(),
                Separator = LiveCharts.Wpf.DefaultAxes.CleanSeparator
            };
            doThi.AxisX.Add(xAxis);

            var yAxis = new LiveCharts.Wpf.Axis
            {
                Title = $"{Y}",
                FontSize = 9.5,
                LabelFormatter = value => value.ToString("#,##0") // Định dạng label
            };
            doThi.AxisY.Add(yAxis);

        }
    }
}

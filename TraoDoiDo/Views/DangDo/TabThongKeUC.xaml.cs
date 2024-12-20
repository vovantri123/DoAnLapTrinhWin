﻿using LiveCharts.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TraoDoiDo.Database;
using TraoDoiDo.Models;

namespace TraoDoiDo.Views.DangDo
{
    /// <summary>
    /// Interaction logic for TabThongKe.xaml
    /// </summary>
    public partial class TabThongKeUC : UserControl
    {
        List<SanPham> dsSanPham;

        SanPham sanPham;
        NguoiDung nguoiDung;
        MoTaHangHoa moTaHangHoa;

        SanPhamDao sanPhamDao = new SanPhamDao();
        MoTaHangHoaDao moTaDao = new MoTaHangHoaDao();
        QuanLyDonHangDao quanLyDonHangDao = new QuanLyDonHangDao();
        TrangThaiDonHangDao trangThaiHangDao = new TrangThaiDonHangDao();
        DanhGiaNguoiDangDao danhGiaNguoiDungDao = new DanhGiaNguoiDangDao();

        public TabThongKeUC()
        {
            InitializeComponent();
        }

        public TabThongKeUC(NguoiDung nguoi)
        {
            InitializeComponent();
            nguoiDung = nguoi;
            ThongKe_Load();
        }

        private void ThongKe_Load()
        {
            LoadTongDoanhThu();
            LoadTongSoLuongSanPhamDaBan();
            LoadTongKhachHang();

            LoadDoanhThuTheoSanPham();
            LoadTiLePhanTramDoanhThuTheoSanPham();
            LoadSoLuongSanPhamDaBan();

            LoadDanhGiaNguoiMua();
        }

        private void LoadDanhGiaNguoiMua()
        {
            try
            {
                int soLuong1Sao = 0;
                int soLuong2Sao = 0;
                int soLuong3Sao = 0;
                int soLuong4Sao = 0;
                int soLuong5Sao = 0;
                List<DanhGiaNguoiDang> dsSoLuotDanhGiaTheoTungSoSao = danhGiaNguoiDungDao.DemSoLuotDanhGiaTheoTungSoSao(nguoiDung.Id);
                foreach (var dong in dsSoLuotDanhGiaTheoTungSoSao)
                {
                    int soSao = Convert.ToInt32(dong.SoSao);
                    int soLuongDanhGia = Convert.ToInt32(dong.SoLuotDanhGia);
                    if (soSao == 1)
                        soLuong1Sao = soLuongDanhGia;
                    else if (soSao == 2)
                        soLuong2Sao = soLuongDanhGia;
                    else if (soSao == 3)
                        soLuong3Sao = soLuongDanhGia;
                    else if (soSao == 4)
                        soLuong4Sao = soLuongDanhGia;
                    else if (soSao == 5)
                        soLuong5Sao = soLuongDanhGia;
                }

                int tongSoLuotDanhGia = soLuong1Sao + soLuong2Sao + soLuong3Sao + soLuong4Sao + soLuong5Sao;
                txtbSoLuotDanhGia.Text = tongSoLuotDanhGia.ToString();

                if (tongSoLuotDanhGia == 0)
                    tongSoLuotDanhGia = 1;
                ratingBar_SoSao.Value = (double)(soLuong1Sao * 1 + soLuong2Sao * 2 + soLuong3Sao * 3 + soLuong4Sao * 4 + soLuong5Sao * 5) / tongSoLuotDanhGia;

                txtbSoSaoTrungBinh.Text = ratingBar_SoSao.Value.ToString("0.##");


                progressBar1Sao.Value = ((double)soLuong1Sao / tongSoLuotDanhGia) * 100;
                progressBar2Sao.Value = ((double)soLuong2Sao / tongSoLuotDanhGia) * 100;
                progressBar3Sao.Value = ((double)soLuong3Sao / tongSoLuotDanhGia) * 100;
                progressBar4Sao.Value = ((double)soLuong4Sao / tongSoLuotDanhGia) * 100;
                progressBar5Sao.Value = ((double)soLuong5Sao / tongSoLuotDanhGia) * 100;

                txtbSoLuong1Sao.Text = soLuong1Sao.ToString();
                txtbSoLuong2Sao.Text = soLuong2Sao.ToString();
                txtbSoLuong3Sao.Text = soLuong3Sao.ToString();
                txtbSoLuong4Sao.Text = soLuong4Sao.ToString();
                txtbSoLuong5Sao.Text = soLuong5Sao.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadSoLuongSanPhamDaBan()
        {
            try
            {
                List<string> dsNhan = new List<string>();
                List<int> dsCotSoLuongDaBan = new List<int>();
                List<int> dsCotSoLuongTong = new List<int>();
                List<SanPham> dsSLDaBan = sanPhamDao.LoadThongSoSanPhamDeThongKe(nguoiDung.Id);

                foreach (var dong in dsSLDaBan)
                {
                    string ten = dong.Ten;
                    int soLuongDaban = Convert.ToInt32(dong.SoLuongDaBan);
                    int soLuongTong = Convert.ToInt32(dong.SoLuong);

                    dsNhan.Add(ten);
                    dsCotSoLuongDaBan.Add(soLuongDaban);
                    dsCotSoLuongTong.Add(soLuongTong);
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
                     new ColumnSeries
                     {
                         Title = "Số lượng tổng",
                         Values = new ChartValues<int>(dsCotSoLuongTong),
                         Fill = Brushes.Teal, // Màu của cột số lượng tổng
                         ScalesYAt = 0
                     }
                };

                // Đặt dữ liệu vào Chart
                chart_SoLuongSanPhamDaBan.Series = DoanhThuTheoSanPham_SC;

                var xAxis = new LiveCharts.Wpf.Axis
                {
                    Title = "Tên sản phẩm",
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadTiLePhanTramDoanhThuTheoSanPham()
        {
            try
            {
                List<string> dsNhan = new List<string>();
                List<int> dsCotDoanhThu = new List<int>();
                List<SanPham> dsTiLeDoanhThu = sanPhamDao.LoadThongSoSanPhamDeThongKe(nguoiDung.Id);

                foreach (var dong in dsTiLeDoanhThu)
                {
                    string ten = dong.Ten;
                    int soLuongDaban = Convert.ToInt32(dong.SoLuongDaBan);
                    int giaBan = Convert.ToInt32(dong.GiaBan);
                    int doanhThu = soLuongDaban * giaBan;
                    dsNhan.Add(ten);
                    dsCotDoanhThu.Add(doanhThu);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDoanhThuTheoSanPham()
        {
            try
            {
                List<string> dsNhan = new List<string>();
                List<int> dsCotDoanhThu = new List<int>();
                List<SanPham> dsDoanhThuSanPham = sanPhamDao.LoadThongSoSanPhamDeThongKe(nguoiDung.Id);

                foreach (var dong in dsDoanhThuSanPham)
                {
                    string ten = dong.Ten;
                    int soLuongDaban = Convert.ToInt32(dong.SoLuongDaBan);
                    int giaBan = Convert.ToInt32(dong.GiaBan);
                    int doanhThu = soLuongDaban * giaBan;

                    dsNhan.Add(ten);
                    dsCotDoanhThu.Add(doanhThu);
                }
                SeriesCollection DoanhThuTheoSanPham_SC = new SeriesCollection
                {
                     new ColumnSeries
                     {
                         Title = "Doanh thu",
                         Values = new ChartValues<int> (dsCotDoanhThu)
                     }
                };

                chart_TongDoanhThuTheoSanPham.Series = DoanhThuTheoSanPham_SC;

                var xAxis = new LiveCharts.Wpf.Axis
                {
                    Title = "Tên sản phẩm",
                    FontSize = 9.5,
                    Labels = dsNhan.ToArray(),
                    Separator = LiveCharts.Wpf.DefaultAxes.CleanSeparator
                };
                chart_TongDoanhThuTheoSanPham.AxisX.Add(xAxis);

                var yAxis = new LiveCharts.Wpf.Axis
                {
                    Title = "Doanh thu",
                    FontSize = 9.5,
                    LabelFormatter = value => value.ToString("#,##0,##0")
                };
                chart_TongDoanhThuTheoSanPham.AxisY.Add(yAxis);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadTongDoanhThu()
        {
            try
            {
                int tongDoanhThu = 0;
                List<SanPham> dsTongDoanhThu = sanPhamDao.LoadThongSoSanPhamDeThongKe(nguoiDung.Id);
                foreach (var dong in dsTongDoanhThu)
                {
                    int soLuongDaBan = Convert.ToInt32(dong.SoLuongDaBan);
                    int giaBan = Convert.ToInt32(dong.GiaBan);
                    tongDoanhThu += soLuongDaBan * giaBan;
                }
                txtbTongDoanhThu.Text = Convert.ToDecimal(tongDoanhThu).ToString("#,##0");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadTongSoLuongSanPhamDaBan()
        {
            try
            {
                int tongSLSanPhamDaBan = 0;
                List<SanPham> dsTongSLDaBan = sanPhamDao.LoadThongSoSanPhamDeThongKe(nguoiDung.Id);

                foreach (var dong in dsTongSLDaBan)
                {
                    tongSLSanPhamDaBan += Convert.ToInt32(dong.SoLuongDaBan);
                }
                txtbTongSoLuongSanPhamDaBan.Text = tongSLSanPhamDaBan.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadTongKhachHang()
        {
            try
            {
                txtbTongSoLuongKhachHang.Text = "0";
                string tongKhachHang = sanPhamDao.TinhTongKhachHang(nguoiDung.Id);
                if (!string.IsNullOrEmpty(tongKhachHang))
                    txtbTongSoLuongKhachHang.Text = tongKhachHang;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnThongTinChiTietDanhGia_Click(object sender, RoutedEventArgs e)
        {
            ThongTinNguoiDang f = new ThongTinNguoiDang(nguoiDung.Id);
            f.txtbTieuDe.Text = "Đánh giá của khách hàng";
            f.Show();
        }
    }
}

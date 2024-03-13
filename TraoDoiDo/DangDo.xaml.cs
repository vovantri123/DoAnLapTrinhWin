using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using LiveCharts.Defaults;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using static TraoDoiDo.MuaDo;

namespace TraoDoiDo
{

    public partial class DangDo : Page
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public class SP
        {
            public string TenSanPham { get; set; }
            public int SoLuongDaBan { get; set; }
            public int TongSoLuongBanDau { get; set; }
            public int TongTien { get; set; }
        }
        // Khai báo danh sách sản phẩm
        List<Product> tab2 = new List<Product>();

        // Property để sử dụng làm DataContext cho DataGrid
        public List<Product> UnapprovedLeaveRequests
        {
            get { return tab2; }
        }
        public DangDo()
        {
            InitializeComponent();
            // Khởi tạo dữ liệu mẫu
            List<SP> sanPhams = new List<SP>
            {
                new SP { TenSanPham = "Sản phẩm A", SoLuongDaBan = 10, TongSoLuongBanDau = 20, TongTien=10000},
                new SP { TenSanPham = "Sản phẩm B", SoLuongDaBan = 12, TongSoLuongBanDau = 18,TongTien=20000 },
                new SP { TenSanPham = "Sản phẩm C", SoLuongDaBan = 3, TongSoLuongBanDau = 10,TongTien=14000 },
                new SP { TenSanPham = "Sản phẩm D", SoLuongDaBan = 7, TongSoLuongBanDau = 14,TongTien=7000 }
            };

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Số lượng đã bán",
                    Values = new ChartValues<int>(sanPhams.Select(sp => sp.SoLuongDaBan))
                },
                new ColumnSeries
                {
                    Title = "Tổng số lượng ban đầu",
                    Values = new ChartValues<int>(sanPhams.Select(sp => sp.TongSoLuongBanDau))
                }
            };

            Labels = sanPhams.Select(sp => sp.TenSanPham).ToArray();

            Formatter = value => value.ToString("N");

            // Gán dữ liệu cho biểu đồ
            DataContext = this;


            //TRÒN

            SeriesCollection pieSeries = new SeriesCollection();

            foreach (var sp in sanPhams)
            {
                pieSeries.Add(new PieSeries
                {
                    Title = sp.TenSanPham,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(sp.TongTien) }
                });
            }

            // Gán SeriesCollection cho biểu đồ tròn
            pieChart.Series = pieSeries;



           

        }


        
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Anh { get; set; }

            public string Type { get; set; }
            public int Quantity { get; set; }
            public int DaBan { get; set; }
            public double Price { get; set; }
            public string Promotion { get; set; }

            public double ShippingFee { get; set; }
            public string SoSao { get; set; }
            public string TrangThai { get; set; }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Product 1",Anh= "/HinhCuaToi/Lenovo.png" ,Type = "Type 1", Quantity = 10, DaBan=0, Price = 100, Promotion = "10%", ShippingFee = 5 , SoSao="5", TrangThai="Đã được duyệt"});
            products.Add(new Product { Id = 2, Name = "Product 2", Anh = "/HinhCuaToi/Lenovo.png", Type = "Type 2", Quantity = 15, DaBan = 0, Price = 150, Promotion = "20%", ShippingFee = 7, SoSao = "0", TrangThai = "Chờ duyệt" });
            products.Add(new Product { Id = 3, Name = "Product 3", Anh = "/HinhCuaToi/Lenovo.png", Type = "Type 3", Quantity = 12, DaBan = 0, Price = 120, Promotion = "50%", ShippingFee = 9, SoSao = "0", TrangThai = "Chờ duyệt" });

            lsvList.ItemsSource = products;





            //Tab QLy Đơn hàng
            List<SPTabQuanLyDonHang> sp = new List<SPTabQuanLyDonHang>();
            sp.Add(new SPTabQuanLyDonHang { Id = 1, Name = "Product 1", Anh = "/HinhCuaToi/Lenovo.png", Quantity = "20", Price = "1.0000", ShippingFee = "10.000", TongTien = "200.000" });
            lsvQuanLyDonHang.ItemsSource = sp;
        }


        private void btnDangDo_Click(object sender, RoutedEventArgs e)
        {
            DangDo_Dang f = new DangDo_Dang();
            f.ShowDialog();
        }
        private void btnSuaDo_Click(object sender, RoutedEventArgs e)
        {
            DangDo_Dang f = new DangDo_Dang();
            f.btnDang.Content = "Sửa";
            f.ShowDialog();
        }
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bạn có chắc là muốn xóa sản phầm này?","Thông báo",MessageBoxButton.OKCancel, MessageBoxImage.Warning);
        }



        //Tab QL đơn hàng
        public class SPTabQuanLyDonHang
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Anh { get; set; }
            public string Quantity { get; set; }
            public string Price { get; set; }
            public string ShippingFee { get; set; }
            public string TongTien { get; set; }
            public int Ngay { get; set; }
        }

        private void btnDiaChiGuiHang_Click(object sender, RoutedEventArgs e)
        {
            DiaChi f = new DiaChi(); 
            f.cboHinhThucThanhToan.IsEnabled = false;
            f.txtHoTen.IsReadOnly = true;
            f.txtDiaChi.IsReadOnly = true;
            f.txtSoDienThoai.IsReadOnly = true;
            f.txtEmail.IsReadOnly = true;

            f.btnXacNhanThanhToan.Visibility = Visibility.Collapsed;
            f.txtbTieuDe.Text = "Địa chỉ khách hàng";

            f.cboHinhThucThanhToan.Text = "Chuyển khoản";
            f.txtHoTen.Text = "Võ Văn Tri";
            f.txtSoDienThoai.Text = "0326123123";
            f.txtEmail.Text = "tri@gmail.com";
            f.txtDiaChi.Text = "Số 1 VVN";



            f.ShowDialog();
        }
    }

}

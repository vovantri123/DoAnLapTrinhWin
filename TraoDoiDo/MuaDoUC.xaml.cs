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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TraoDoiDo.Models;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for MuaDo.xaml
    /// </summary>
    public partial class MuaDoUC : UserControl
    {

        

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        private SanPhamUC[] DanhSachSanPham = new SanPhamUC[2];

        public MuaDoUC()
        {
            InitializeComponent();
            Loaded += LoadSanPhamlenWpnlHienThi;
        }

        private void LoadSanPhamlenWpnlHienThi(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                string sqlStr = $@"
                    SELECT IdSanPham, Ten, LinkAnhBia,   GiaGoc, GiaBan, NoiBan 
                    FROM SanPham
                ";

                SqlCommand command = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = command.ExecuteReader();
                int i = 0;

                while (reader.Read()) // để while cho zui chứ đọc có 1 dòng duy nhất là hết r
                {
                    DanhSachSanPham[i] = new SanPhamUC(); // Khởi tạo mỗi phần tử của mảng (KHÔNG CÓ LÀ LỖI)

                    DanhSachSanPham[i].txtbIdSanPham.Text = reader.GetString(0);
                    DanhSachSanPham[i].txtbTen.Text = reader.GetString(1);

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri("pack://application:,,,/" + reader.GetString(2)); 
                    bitmap.EndInit();
                    // Gán BitmapImage tới Source của Image control
                    DanhSachSanPham[i].imgSP.Source = bitmap;

                    DanhSachSanPham[i].txtbGiaGoc.Text = reader.GetString(3);
                    DanhSachSanPham[i].txtbGiaBan.Text = reader.GetString(4);
                    DanhSachSanPham[i].txtbNoiBan.Text = reader.GetString(5);

                    //SanPham sanPham = new SanPham(id, name, imageUrl); 
                    //lsvQuanLySanPham.Items.Add(sanPham);
                    DanhSachSanPham[i].Margin = new Thickness(8);
                    wpnlHienThi.Children.Add(DanhSachSanPham[i]);
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Anh { get; set; }
            public string Gia { get; set; }
            public string PhiShip { get; set; }

            public int Quantity { get; set; }
        }

        public class SPTabTrangThaiDonHang
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

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //Tab giỏ hàng
            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Product 1",Anh="/HinhCuaToi/Lenovo.png" ,Gia="200.000",PhiShip="10.000",Quantity = 10 });
            products.Add(new Product { Id = 2, Name = "Product 2", Anh = "/HinhCuaToi/Lenovo.png" , Gia = "150.000", PhiShip = "12.000",Quantity = 15 });
            products.Add(new Product { Id = 2, Name = "Product 2", Anh = "/HinhCuaToi/Lenovo.png" , Gia = "150.000", PhiShip = "12.000",Quantity = 15 });
            products.Add(new Product { Id = 2, Name = "Product 2", Anh = "/HinhCuaToi/Lenovo.png" , Gia = "150.000", PhiShip = "12.000",Quantity = 15 });
            products.Add(new Product { Id = 2, Name = "Product 2", Anh = "/HinhCuaToi/Lenovo.png" , Gia = "150.000", PhiShip = "12.000",Quantity = 15 });
            products.Add(new Product { Id = 2, Name = "Product 2", Anh = "/HinhCuaToi/Lenovo.png" , Gia = "150.000", PhiShip = "12.000",Quantity = 15 });
            products.Add(new Product { Id = 2, Name = "Product 2", Anh = "/HinhCuaToi/Lenovo.png" , Gia = "150.000", PhiShip = "12.000",Quantity = 15 });
            products.Add(new Product { Id = 2, Name = "Product 2", Anh = "/HinhCuaToi/Lenovo.png" , Gia = "150.000", PhiShip = "12.000",Quantity = 15 });
            products.Add(new Product { Id = 2, Name = "Product 2", Anh = "/HinhCuaToi/Lenovo.png" , Gia = "150.000", PhiShip = "12.000",Quantity = 15 });
            products.Add(new Product { Id = 2, Name = "Product 2", Anh = "/HinhCuaToi/Lenovo.png" , Gia = "150.000", PhiShip = "12.000",Quantity = 15 });
            products.Add(new Product { Id = 2, Name = "Product 2", Anh = "/HinhCuaToi/Lenovo.png" , Gia = "150.000", PhiShip = "12.000",Quantity = 15 });
            products.Add(new Product { Id = 2, Name = "Product 2", Anh = "/HinhCuaToi/Lenovo.png" , Gia = "150.000", PhiShip = "12.000",Quantity = 15 });

            lsvList.ItemsSource = products;


            //Tab trạng thái đon hàng
            List<SPTabTrangThaiDonHang> sp = new List<SPTabTrangThaiDonHang>();
            sp.Add(new SPTabTrangThaiDonHang { Id = 1, Name = "Product 1", Anh = "/HinhCuaToi/Lenovo.png", Quantity = "20", Price = "1.0000", ShippingFee = "10.000", TongTien= "200.000"  });
            lsvChoNguoiBanXacNhan.ItemsSource = sp;
            lsvChoNhanHang.ItemsSource = sp;
            lsvDaNhan.ItemsSource = sp;
        
        }

        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            DiaChi f = new DiaChi();
            f.ShowDialog();
        }


        private void SelectAllCheckBox_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem CheckBox đã được chọn hay không
            if (sender is CheckBox selectAllCheckBox && selectAllCheckBox.IsChecked.HasValue)
            {
                // Lặp qua mỗi mục trong ListView để đặt trạng thái chọn tương ứng
                foreach (var item in lsvList.Items)
                {
                    // Lấy ListViewItem từ mỗi mục
                    ListViewItem listViewItem = lsvList.ItemContainerGenerator.ContainerFromItem(item) as ListViewItem;
                    if (listViewItem != null)
                    {
                        // Lấy CheckBox từ CellTemplate của mỗi mục
                        CheckBox itemCheckBox = FindVisualChild<CheckBox>(listViewItem);
                        if (itemCheckBox != null)
                        {
                            // Đặt trạng thái của CheckBox theo trạng thái của CheckBox chọn tất cả
                            itemCheckBox.IsChecked = selectAllCheckBox.IsChecked;
                        }
                    }
                }
            }
        }
        // Phương thức hỗ trợ để tìm kiếm một đối tượng theo kiểu trong một VisualTree
        private T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        //Tab trạng thái đơn hàng
        private void btnHuyDatHang_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bạn có chắc là muốn hủy đặt hàng 0_o\nĐơn hàng mà bạn hủy sẽ được hoàn tiền", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
        }
        private void btnDaNhanHang_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bạn có chắc là đã nhận được hàng 0_o", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
        } 
    }
}

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

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for MuaDo.xaml
    /// </summary>
    public partial class MuaDoUC : UserControl
    {

        private void themDeTestForm()
        {
            //UCSanPham uc = new UCSanPham();
            //uc.Width = 215; // Thiết lập chiều rộng mong muốn
            //uc.Height = 350; // Thiết lập chiều cao mong muốn
            //uc.Margin = new Thickness(8);


            //// Tạo một BitmapImage
            //BitmapImage bitmap = new BitmapImage();
            //bitmap.BeginInit();
            //bitmap.UriSource = new Uri(""); // Thay thế path_to_your_image_folder với đường dẫn thực sự đến thư mục chứa hình ảnh của bạn
            //bitmap.EndInit();

            //// Gán BitmapImage tới Source của Image control
            //uc.imgSP.Source = bitmap;


            //wpnlHienThi.Children.Add(uc);
        }



        public MuaDoUC()
        {
            string[] Links = new string[10];
            Links[0] = "pack://application:,,,/HinhCuaToi/Lenovo.png";
            Links[1] = "pack://application:,,,/HinhCuaToi/MayAnhNikon.jpg";
            Links[2] = "pack://application:,,,/HinhCuaToi/tiviThung.jpg";
            Links[3] = "pack://application:,,,/HinhCuaToi/SacDuPhong.jpg";
            Links[4] = "pack://application:,,,/HinhCuaToi/TaiNgheOladance.jpg";
            Links[5] = "pack://application:,,,/HinhCuaToi/routerWifi.jpg";
            Links[6] = "pack://application:,,,/HinhCuaToi/vietcombank.png";
            Links[7] = "pack://application:,,,/HinhCuaToi/LoaPinoer.jpg";
            Links[8] = "pack://application:,,,/HinhCuaToi/ThungMayPC.jpg";
            InitializeComponent();
            for (int i = 0; i <3; i++)
            {
                for (int j=0;j<8;j++)
                {
                    UCSanPham uc = new UCSanPham(); 
                    uc.Margin = new Thickness(8);


                    // Tạo một BitmapImage
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(Links[j]); // Thay thế path_to_your_image_folder với đường dẫn thực sự đến thư mục chứa hình ảnh của bạn
                    bitmap.EndInit();

                    // Gán BitmapImage tới Source của Image control
                    uc.imgSP.Source = bitmap;


                    wpnlHienThi.Children.Add(uc);
                }    
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
        private void btnDanhGia_Click(object sender, RoutedEventArgs e)
        {
            DanhGia f = new DanhGia();
            f.ShowDialog();
        }
    }
}

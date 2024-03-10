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
    public partial class MuaDo : Page
    {

        private void themDeTestForm()
        {
            UCSanPham uc = new UCSanPham();
            uc.Width = 220; // Thiết lập chiều rộng mong muốn
            uc.Height = 335; // Thiết lập chiều cao mong muốn
            uc.Margin = new Thickness(5);

            wpnlHienThi.Children.Add(uc);
        }



        public MuaDo()
        {
            InitializeComponent();
            for (int i = 0; i <18;i++)
            {
                themDeTestForm();
            }
        }
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Gia { get; set; }
            public string PhiShip { get; set; }

            public int Quantity { get; set; }
        }
        

       

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Product 1", Gia="200.000",PhiShip="10.000",Quantity = 10 });
            products.Add(new Product { Id = 2, Name = "Product 2", Gia = "150.000", PhiShip = "12.000",Quantity = 15 });


            lsvList.ItemsSource = products;
        }

        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            HoaDon f = new HoaDon();
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
    }
}

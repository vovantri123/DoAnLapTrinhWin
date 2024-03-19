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

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for ThongTinChiTietSanPham.xaml
    /// </summary>
    public partial class ThongTinChiTietSanPham : Window
    {
        //Test thong tin chi tiet sp (Begin)
        public class ListViewItem
        {
            public string Anh { get; set; } // Assuming Anh is a string representing image source
            public string Name { get; set; }
        }
        //Test thong tin chi tiet sp (End)










        private List<string> imagePaths = new List<string>
        {
            "HinhCuaToi/IPadGen6_1.jpg",
            "HinhCuaToi/IPadGen6_2.jpg",
            "HinhCuaToi/IPadGen6_3.jpg",
            // Add more image paths as needed
        };

        private int currentIndex = 0;
        public ObservableCollection<ListViewItem> Items { get; set; }

        public ThongTinChiTietSanPham()
        {

            InitializeComponent();

            if (imagePaths.Count > 0)
            {
                DisplayImage();
            }



            // Initialize your collection of items
            Items = new ObservableCollection<ListViewItem>();

            // Add some sample data
            Items.Add(new ListViewItem { Anh = "HinhCuaToi/IPadGen6_1.jpg", Name = "Hỏng góc trên bên trái\n\nPhần còn lại của iPad vẫn hoạt động bình thường." });
            Items.Add(new ListViewItem { Anh = "HinhCuaToi/IPadGen6_2.jpg", Name = "Trầy màn hình mức độ nhẹ, vẫn nhìn tốt\n\nMàn hình vẫn rõ nét, không có điểm chết hoặc vết xước lớn.." });
            Items.Add(new ListViewItem { Anh = "HinhCuaToi/IPadGen6_3.jpg", Name = "Gọn nhẹ, dễ mang theo. Chiếc iPad này là sự lựa chọn hoàn hảo cho các chuyến đi, từ cuộc họp gặp gỡ công việc đến những chuyến du lịch khám phá thế giới\n\nVới kích thước nhỏ gọn và trọng lượng nhẹ, chiếc iPad này không chỉ dễ dàng để mang theo trong túi xách hay ba lô mà còn không gây trở ngại cho bạn khi di chuyển. Bạn có thể dễ dàng sử dụng nó trên máy bay, tàu hỏa, hoặc thậm chí trong các không gian hẹp.\n\nDù bạn đang trên đường đi hay đang tận hưởng một buổi họp công việc ở một quán cà phê, iPad này sẽ giúp bạn duy trì sự linh hoạt và hiệu suất cao. Hãy mang theo nó và khám phá thế giới một cách dễ dàng và thuận tiện!" }); 

            // Set the DataContext of your ListView to the collection of items
            lsvThongTinChiTietSP.ItemsSource = Items;
        }

        private void DisplayImage()
        {
            // Load and display the current image
            string imagePath = imagePaths[currentIndex];
            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
            imgAnhSP.Source = bitmapImage;
        }


        private void btnAnhTruoc_Click(object sender, EventArgs e)
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

        private void btnAnhSau_Click(object sender, RoutedEventArgs e)
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


        private void btnThemVaoGioHang_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thêm vào giỏ hàng thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnTang_Click(object sender, RoutedEventArgs e)
        {
            int n = Convert.ToInt32(txtbSoLuongHienTai.Text);
            n += 1;
            txtbSoLuongHienTai.Text = n.ToString();


        }

        private void btnGiam_Click(object sender, RoutedEventArgs e)
        {
            int n = Convert.ToInt32(txtbSoLuongHienTai.Text);
            if (n-1 >= 0)
            {
                n -= 1;
            }   
            txtbSoLuongHienTai.Text = n.ToString();
        }
    }
}

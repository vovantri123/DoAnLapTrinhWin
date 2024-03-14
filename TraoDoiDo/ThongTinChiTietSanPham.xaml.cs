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
using System.Windows.Threading;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for ThongTinChiTietSanPham.xaml
    /// </summary>
    public partial class ThongTinChiTietSanPham : Window
    {
        private List<string> imagePaths = new List<string>
        {
            "HinhCuaToi/IPadGen6_1.jpg",
            "HinhCuaToi/IPadGen6_2.jpg",
            "HinhCuaToi/IPadGen6_3.jpg",
            // Add more image paths as needed
        };

        private int currentIndex = 0;
        private DispatcherTimer timer;
        public ThongTinChiTietSanPham()
        {
            InitializeComponent();

            if (imagePaths.Count > 0)
            {
                // Khởi động timer cho slideshow
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(2); // Thay đổi khoảng thời gian theo ý muốn
                timer.Tick += Timer_Tick;
                timer.Start();

                // Hiển thị ảnh đầu tiên
                DisplayImage();
            }
        }

        private void DisplayImage()
        {
            // Load and display the current image
            string imagePath = imagePaths[currentIndex];
            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
            imgAnhSP.Source = bitmapImage;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Move to the next image
            currentIndex = (currentIndex + 1) % imagePaths.Count;
            DisplayImage();
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
    }
}

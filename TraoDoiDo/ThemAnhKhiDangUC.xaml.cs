using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
    /// Interaction logic for ThemAnhKhiDang.xaml
    /// </summary>
    public partial class ThemAnhKhiDangUC : UserControl
    {
        public ThemAnhKhiDangUC()
        {
            InitializeComponent();
        }

        private void btnChonAnh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFileName = openFileDialog.FileName;
                imgAnhSP.Source = new BitmapImage(new Uri(selectedFileName)); 
                txtbTenFileAnh.Text = System.IO.Path.GetFileName(selectedFileName); // Lưu tên file
                txtbDuongDanAnh.Text = selectedFileName;

                // Gọi hàm để lưu ảnh vào thư mục "HinhCuaToi"
                //LuuAnhVaoThuMuc(selectedFileName);
               
            }
        }
        private void LuuAnhVaoThuMuc(string duongDanAnh)
        {
            try
            {
                // Kiểm tra xem đường dẫn ảnh có tồn tại không
                if (!System.IO.File.Exists(duongDanAnh))
                {
                    MessageBox.Show("Không tìm thấy tệp ảnh.");
                    return;
                }

                string thuMucHinhCuaToi = XuLyAnh.layDuongDanToiHinhSanPham();

                // Kiểm tra xem thư mục có tồn tại không, nếu không thì tạo mới
                if (!System.IO.Directory.Exists(thuMucHinhCuaToi))
                {
                    System.IO.Directory.CreateDirectory(thuMucHinhCuaToi);
                }

                // Lấy tên tệp ảnh từ đường dẫn
                string tenFile = System.IO.Path.GetFileName(duongDanAnh);

                // Tạo đường dẫn mới cho tệp ảnh trong thư mục "HinhCuaToi"
                string duongDanMoi = System.IO.Path.Combine(thuMucHinhCuaToi, tenFile);

                // Kiểm tra xem tệp ảnh đã tồn tại trong thư mục chưa
                if (System.IO.File.Exists(duongDanMoi))
                {
                    MessageBox.Show("Tệp ảnh đã tồn tại trong thư mục HinhSanPham.");
                    return;
                }

                // Sao chép tệp ảnh vào thư mục "HinhCuaToi"
                System.IO.File.Copy(duongDanAnh, duongDanMoi, true);

                MessageBox.Show("Ảnh đã được lưu vào thư mục HinhSanPham.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu ảnh: " + ex.Message);
            }
        }

        private void btnXoaAnh_Click(object sender, RoutedEventArgs e)
        {
            imgAnhSP.Source = null;
        }
    }
}

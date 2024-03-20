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
using System.Data.SqlClient;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for ThongTinChiTietSanPham.xaml
    /// </summary>
    public partial class ThongTinChiTietSanPham : Window
    {










        private List<string> danhSachAnh = new List<string>
        {
            //Rỗng ban đầu
        };

        private int currentIndex = 0;
        public ObservableCollection<ListViewItem> Items { get; set; }









        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public string idSanPham ="1";
        private void LoadThongTinSanPham(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sqlStr = $@"
                    SELECT Ten, Loai, SoLuong, SoLuongDaBan, GiaGoc, GiaBan, PhiShip, NoiBan, XuatXu, NgayMua, PhanTramMoi, MoTaChung 
                    FROM SanPham
                    WHERE Id = '{idSanPham}'
                ";

                SqlCommand command = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // để while cho zui chứ đọc có 1 dòng duy nhất là hết r
                {
                    txtbTen.Text = reader.GetString(0);
                    txtbLoai.Text = reader.GetString(1); 

                    string soLuong = reader.GetString(2);
                    string soLuongDaBan = reader.GetString(3);
                    txtbSoLuongConLai.Text = (Convert.ToInt32(soLuong) - Convert.ToInt32(soLuongDaBan)).ToString();


                    txtbGiaGoc.Text = reader.GetString(4);
                    txtbGiaBan.Text = reader.GetString(5);
                    txtbPhiShip.Text = reader.GetString(6);
                    txtbNoiBan.Text = reader.GetString(7);
                    txtbXuatXu.Text = reader.GetString(8);
                    txtbNgayMua.Text = reader.GetString(9);
                    txtbPhanTramConMoi.Text = reader.GetString(10);
                    txtbMoTaChung.Text = reader.GetString(11);

                    
                   
                    //SanPham sanPham = new SanPham(id, name, imageUrl); 
                    //lsvQuanLySanPham.Items.Add(sanPham);
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
        private void LoadAnhVaMoTa(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                string sqlStr = @"
                    SELECT SanPham.LinkAnhBia, MoTaAnhSanPham.LinkAnhMinhHoa, MoTaAnhSanPham.MoTa 
                    FROM SanPham INNER JOIN MoTaAnhSanPham 
                    ON SanPham.LinkAnhBia = MoTaAnhSanPham.LinkAnhBia
                ";

                SqlCommand command = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string linkAnhBia = reader.GetString(0);
                    string linkAnhMinhHoa = reader.GetString(1);
                    string moTa = reader.GetString(2);
                    
                    danhSachAnh.Add(linkAnhMinhHoa);
                    lsvThongTinChiTietSP.Items.Add(new {LinkAnhMinhHoa = linkAnhMinhHoa, MoTa = moTa });

                    //SanPham sanPham = new SanPham(id, name, imageUrl); 
                    //lsvQuanLySanPham.Items.Add(sanPham);
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

        public ThongTinChiTietSanPham()
        {

            InitializeComponent();
            Loaded += LoadAnhVaMoTa;
            Loaded += LoadThongTinSanPham;
            Loaded += btnAnhSau_Click;



            if (danhSachAnh.Count > 0)
            {
                DisplayImage();
            }





           
        }

        private void DisplayImage()
        {
            // Load and display the current image
            string imagePath = danhSachAnh[currentIndex];
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
                currentIndex = danhSachAnh.Count - 1;
            }

            DisplayImage();
        }

        private void btnAnhSau_Click(object sender, RoutedEventArgs e)
        {
            // Move to the next image
            currentIndex++;

            // Check if we have reached the end of the list
            if (currentIndex >= danhSachAnh.Count)
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

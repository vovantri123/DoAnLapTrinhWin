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
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Channels;
using TraoDoiDo.ViewModels;
namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for ThongTinChiTietSanPham.xaml
    /// </summary>
    public partial class ThongTinChiTietSanPham : Window
    {
        public int idNguoiMua = 2;

        public int idNguoiDang = 1;
        public string idSanPham ="1";
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        
        private List<string> danhSachAnh = new List<string>
        {
            //Rỗng ban đầu
        };

        private int currentIndex = -1;
        public ObservableCollection<ListViewItem> Items { get; set; }



        public ThongTinChiTietSanPham()
        {

            InitializeComponent();
            Loaded += LoadAnhVaMoTa;
            Loaded += LoadThongTinSanPham;
            Loaded += btnAnhSau_Click;

             

        }

        private void LoadThongTinSanPham(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sqlStr = $@"
                    SELECT Ten, Loai, SoLuong, SoLuongDaBan, GiaGoc, GiaBan, PhiShip, NoiBan, XuatXu, NgayMua, PhanTramMoi, MoTaChung 
                    FROM SanPham
                    WHERE IdSanPham = '{idSanPham}'
                ";

                SqlCommand command = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // để while cho zui chứ đọc có 1 dòng duy nhất (do dữ liệu mỗi dòng là duy nhất)
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
                string sqlStr = $@"
                    SELECT SanPham.LinkAnhBia, MoTaAnhSanPham.LinkAnhMinhHoa, MoTaAnhSanPham.MoTa 
                    FROM SanPham INNER JOIN MoTaAnhSanPham 
                    ON SanPham.IdSanPham = MoTaAnhSanPham.IdSanPham
                    WHERE SanPham.IdSanPham = '{idSanPham}'
                ";

                SqlCommand command = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string linkAnhBia = reader.GetString(0); 
                    string moTa = reader.GetString(2);
                    
                     
                    string linkAnhMinhHoa = XuLyAnh.layDuongDanDayDuToiFileAnh(reader.GetString(1));
                    danhSachAnh.Add(linkAnhMinhHoa); //Lấy đường dẫn để bỏ vào hình bên trên

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

        
        private void ThongTinNguoiDang_Click(object sender, RoutedEventArgs e)
        {
            ThongTinNguoiDang f = new ThongTinNguoiDang(idNguoiDang); 
            f.Show();
        }


        private void DisplayImage()
        {
            // Load and display the current image
            string imagePath = danhSachAnh[currentIndex];
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imagePath);
            bitmapImage.EndInit();

            imgAnhSP.Source = bitmapImage;
        }


        private void btnAnhTruoc_Click(object sender, RoutedEventArgs e)
        {
            if (danhSachAnh.Count > 0)
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
        }

        private void btnAnhSau_Click(object sender, RoutedEventArgs e)
        {
            if (danhSachAnh.Count > 0)
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
        }


        private void btnThemVaoGioHang_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                string sqlStr = $@"
                    INSERT INTO GioHang (IdNguoiMua,IdSanPham, SoLuongMua)  
                    VALUES ('{idNguoiMua}', '{idSanPham}','{txtbSoLuongHienTai.Text}')
                ";
                SqlCommand command = new SqlCommand(sqlStr, conn);
                int rowsAffected = command.ExecuteNonQuery();
                if(rowsAffected > 0) 
                    MessageBox.Show("Thêm vào giỏ hàng thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                this.Close();
            }
        }

        private void btnTang_Click(object sender, RoutedEventArgs e)
        {
            int n = Convert.ToInt32(txtbSoLuongHienTai.Text);
            if (n + 1 <= Convert.ToInt32(txtbSoLuongConLai.Text))
            {
                n += 1; 
            } 
                
            txtbSoLuongHienTai.Text = n.ToString();


        }

        private void btnGiam_Click(object sender, RoutedEventArgs e)
        {
            int n = Convert.ToInt32(txtbSoLuongHienTai.Text);
            if (n-1 > 0)
            {
                n -= 1;
            }   
            txtbSoLuongHienTai.Text = n.ToString();
        }
    }
}

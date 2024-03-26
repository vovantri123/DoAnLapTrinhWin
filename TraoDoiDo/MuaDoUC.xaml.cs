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
        private SanPhamUC[] DanhSachSanPham = new SanPhamUC[100];
        private int idNguoi = 2;

        public MuaDoUC()
        {
            InitializeComponent();
            Loaded += MuaSam_Load; // TAB1
            Loaded += GioHang_Load; //TAB2
            Loaded += TrangThaiDonHang_Load; //TAB3
        }

        #region TAB1 MUA SẮM
        private void MuaSam_Load(object sender, RoutedEventArgs e)
        {
            LoadSanPhamlenWpnlHienThi();
        }
        private void LoadSanPhamlenWpnlHienThi()
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



                    string tenFileAnh = reader.GetString(2);
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    string duongDanhAnh = XuLyAnh.layDuongDanDayDuToiFileAnh(tenFileAnh);
                    bitmap.UriSource = new Uri(duongDanhAnh); 
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
        #endregion




        #region TAB2 GIỎ HÀNG


        private void GioHang_Load(object sender, RoutedEventArgs e)
        {
            LsvGioHang_Load();
        }

        
        private void LsvGioHang_Load()
        {
            try
            {
                conn.Open();
                string sqlStr = $@"
                    SELECT Ten, LinkAnhBia, GiaBan, PhiShip, SoLuongMua, SoLuong, SoLuongDaBan 
                    FROM GioHang 
                    INNER JOIN NguoiDung ON GioHang.IdNguoiDung = NguoiDung.IdNguoiDung
                    INNER JOIN SanPham ON GioHang.IdSanPham = SanPham.IdSanPham
                    WHERE NguoiDung.IdNguoiDung = '{idNguoi}'

                ";

                SqlCommand command = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = command.ExecuteReader();
                lsvGioHang.Items.Clear();
                int soTT = 0;
                while (reader.Read())
                {
                    soTT++; 
                    string tenSP = reader.GetString(0); 
                    string tenFileAnh = reader.GetString(1);
                    string linkAnhBia = XuLyAnh.layDuongDanDayDuToiFileAnh(tenFileAnh);



                    string giaBan = reader.GetString(2);
                    string phiShip = reader.GetString(3);
                    string soLuongMua = reader.GetString(4);

                    int soLuong = Convert.ToInt32(reader.GetString(5)); //Tổng
                    int soLuongDaBan = Convert.ToInt32(reader.GetString(6));
                    string trangThai = "";
                    if (soLuong == soLuongDaBan)
                        trangThai = "Hết hàng";
                    else
                        trangThai = "Còn hàng";


                    lsvGioHang.Items.Add(new { STT = soTT, TenSP = tenSP, LinkAnhBia = linkAnhBia, Gia = giaBan, PhiShip = phiShip, SoLuongMua = soLuongMua, TrangThaiConHayHet = trangThai });

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
                foreach (var item in lsvGioHang.Items)
                {
                    // Lấy ListViewItem từ mỗi mục
                    ListViewItem listViewItem = lsvGioHang.ItemContainerGenerator.ContainerFromItem(item) as ListViewItem;
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

        #endregion






        #region TAB3 TRẠNG THÁI ĐƠN HÀNG
        
        private void TrangThaiDonHang_Load(object sender, RoutedEventArgs e)
        { 
            LoadLsvTrongTabTrangThaiDonHang("lsvChoNguoiBanXacNhan", "Chờ xác nhận");
            LoadLsvTrongTabTrangThaiDonHang("lsvChoGiaoHang", "Chờ giao hàng");
            LoadLsvTrongTabTrangThaiDonHang("lsvDaNhan", "Đã nhận"); 
        }
        private void LoadLsvTrongTabTrangThaiDonHang(string tenLsv, string trangthai)
        {
            try
            {
                conn.Open();
                string sqlStr = $@"
                    SELECT SanPham.IdSanPham,SanPham.Ten,SanPham.LinkAnhBia, TrangThaiDonHang.SoLuongMua, SanPham.GiaBan, SanPham.PhiShip, TrangThaiDonHang.TongThanhToan, TrangThaiDonHang.Ngay
                    FROM TrangThaiDonHang
                    INNER JOIN NguoiDung ON TrangThaiDonHang.IdNguoiDung = NguoiDung.IdNguoiDung
                    INNER JOIN SanPham ON TrangThaiDonHang.IdSanPham= SanPham.IdSanPham
                    WHERE NguoiDung.IdNguoiDung = {idNguoi} and TrangThaiDonHang.TrangThai = N'{trangthai}'
                ";

                SqlCommand command = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = command.ExecuteReader();

                if (tenLsv == "lsvChoNguoiBanXacNhan")
                    lsvChoNguoiBanXacNhan.Items.Clear();
                else if (tenLsv == "lsvChoGiaoHang")
                    lsvChoGiaoHang.Items.Clear();
                else if (tenLsv == "lsvDaNhan")
                    lsvDaNhan.Items.Clear();

                while (reader.Read())
                {
                    string idSP = reader.GetString(0);
                    string tenSP = reader.GetString(1);
                    string tenFileAnh = reader.GetString(2);
                    string linkAnhBia = XuLyAnh.layDuongDanDayDuToiFileAnh(tenFileAnh);

                    string soLuongMua = reader.GetString(3);
                    string giaBan = reader.GetString(4);



                    string phiShip = reader.GetString(5);
                    string tongThanhToan = reader.GetString(6);
                    string ngay = reader.GetString(7);



                    if (tenLsv == "lsvChoNguoiBanXacNhan") 
                        lsvChoNguoiBanXacNhan.Items.Add(new { IdSP = idSP, TenSP = tenSP, LinkAnhBia = linkAnhBia, Gia = giaBan, PhiShip = phiShip, SoLuongMua = soLuongMua, TongThanhToan = tongThanhToan, Ngay = ngay });
                    else if (tenLsv == "lsvChoGiaoHang") 
                        lsvChoGiaoHang.Items.Add(new { IdSP = idSP, TenSP = tenSP, LinkAnhBia = linkAnhBia, Gia = giaBan, PhiShip = phiShip, SoLuongMua = soLuongMua, TongThanhToan = tongThanhToan, Ngay = ngay });
                    else if (tenLsv == "lsvDaNhan")
                        lsvDaNhan.Items.Add(new { IdSP = idSP, TenSP = tenSP, LinkAnhBia = linkAnhBia, Gia = giaBan, PhiShip = phiShip, SoLuongMua = soLuongMua, TongThanhToan = tongThanhToan, Ngay = ngay });


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
       
        private void btnDanhGia_Click(object sender, RoutedEventArgs e)
        {
            DanhGia f = new DanhGia();
            f.ShowDialog();
        }
        private void btnHuyDatHang_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bạn có chắc là muốn hủy đặt hàng 0_o\nĐơn hàng mà bạn hủy sẽ được hoàn tiền", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
        }
        private void btnDaNhanHang_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bạn có chắc là đã nhận được hàng 0_o", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
        }
        #endregion
    }
}

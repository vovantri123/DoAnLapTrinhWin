using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using TraoDoiDo.Database;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for QuanLy.xaml
    /// </summary>
    public partial class QuanLyUC : UserControl
    {
        VoucherDao voucherDao = new VoucherDao();
        NguoiDungVoucherDao ndvcDao = new NguoiDungVoucherDao();


        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Anh { get; set; }
            public string Type { get; set; }
            public int Quantity { get; set; }
            public int DaBan { get; set; }
            public decimal GiaGoc { get; set; }
            public decimal GiaBan { get; set; } 
            public decimal ShippingFee { get; set; }
            public int SoSao { get; set; } 
        }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public QuanLyUC()
        {
            InitializeComponent();
            DataContext = this; // Đặt DataContext của trang là chính trang đó

            // Khởi tạo danh sách sản phẩm
            Products = new ObservableCollection<Product>();
            Products.Add(new Product { Id = 1, Name = "Sản phẩm 1", Anh = "/HinhCuaToi/Lenovo.png", Type = "Type 1", Quantity = 10, DaBan = 5, GiaGoc = 100000, GiaBan = 20000, ShippingFee = 5000, SoSao = 4, });
            Products.Add(new Product { Id = 2, Name = "Sản phẩm 2", Anh = "/HinhCuaToi/Lenovo.png", Type = "Type 2", Quantity = 20, DaBan = 10, GiaGoc = 200000, GiaBan = 12000, ShippingFee = 10000, SoSao = 3 });

            // Gán danh sách sản phẩm vào ItemsSource của ListView
            lsvQuanLySanPham.ItemsSource = Products;

            Users = new ObservableCollection<User>();
            // Thêm dữ liệu mẫu vào Users (có thể thay thế bằng dữ liệu từ cơ sở dữ liệu hoặc nguồn dữ liệu khác)
            Users.Add(new User { UserId = "1", FullName = "John Doe",  Identification = "123456789", Gender = "Male", PhoneNumber = "1234567890", DateOfBirth = "16/10/2004", Address = "123 Street, City", Email = "john@example.com", Promotion = "VIP", ShippingFee = 10.5 });
            Users.Add(new User { UserId = "2", FullName = "Jane Doe", Identification = "987654321", Gender = "Female", PhoneNumber = "0987654321", DateOfBirth = "23/1/2004", Address = "456 Avenue, Town", Email = "jane@example.com", Promotion = "Regular", ShippingFee = 8.75 });
            // Đặt nguồn dữ liệu cho ListView
            lsvQuanLyNguoiDung.ItemsSource = Users;

            Loaded += QuanLyVoucher_Load;
        }


        #region TAB1 MUA SẮM
        private void QuanLyVoucher_Load(object sender, RoutedEventArgs e)
        {
            LoadDanhSachVoucer();
        }

        private void LoadDanhSachVoucer()
        { 
            try
            {
                List<Voucher> dsVoucher = voucherDao.LoadVoucher();  
                lsvQLVoucher.ItemsSource = dsVoucher;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void lsvQLVoucher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (lsvQLVoucher.SelectedItem != null)
            {
                // Lấy dữ liệu của dòng được chọn
                Voucher dongDuocChon = lsvQLVoucher.SelectedItem as Voucher; // Thay YourDataModel bằng kiểu dữ liệu thực tế của bạn

                if (dongDuocChon != null)
                {
                    txtbIdVoucher.Text = dongDuocChon.IdVoucher;
                    txtbTenVoucher.Text = dongDuocChon.TenVoucher;
                    txtbGiaTri.Text = dongDuocChon.GiaTri;
                    dtpNgayBatDau.SelectedDate = DateTime.Parse(dongDuocChon.NgayBatDau);
                    dtpNgayKetThuc.SelectedDate = DateTime.Parse(dongDuocChon.NgayKetThuc);
                    ucTangGiamSoLuotSuDungToiDa.txtbSoLuong.Text = dongDuocChon.SoLuotSuDungToiDa;
                    ucTangGiamSoLuotDaSuDung.txtbSoLuong.Text = dongDuocChon.SoLuotDaSuDung;
                }
            }
        }
        private void btnDangVoucher_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng ?", "Xác nhận đăng", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                try
                {
                    voucherDao.Them(new Voucher(txtbIdVoucher.Text, txtbTenVoucher.Text, txtbGiaTri.Text, ucTangGiamSoLuotSuDungToiDa.txtbSoLuong.Text, ucTangGiamSoLuotDaSuDung.txtbSoLuong.Text, dtpNgayBatDau.Text, dtpNgayKetThuc.Text));

                    // Load lại tab QL Voucher
                    QuanLyVoucher_Load(sender, e);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra khi sửa sản phẩm: " + ex.Message);
                }
        }
        private void btnSuaVoucher_Click(object sender, RoutedEventArgs e)
        { 
            if (MessageBox.Show("Bạn có chắc chắn muốn sửa mục đã chọn?", "Xác nhận sửa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                try
                {  
                    voucherDao.Sua(new Voucher(txtbIdVoucher.Text, txtbTenVoucher.Text, txtbGiaTri.Text, ucTangGiamSoLuotSuDungToiDa.txtbSoLuong.Text, ucTangGiamSoLuotDaSuDung.txtbSoLuong.Text, dtpNgayBatDau.Text, dtpNgayKetThuc.Text));  

                    // Load lại tab QL Voucher
                    QuanLyVoucher_Load(sender, e);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra khi sửa sản phẩm: " + ex.Message);
                } 
        }
         
        private void btnXoaVoucher_Click(object sender, RoutedEventArgs e) // truy vấn id trên lsv sẽ hiệu quả hơn thay vì lấy id từ textblock , từ đó ta có thể đặt thuộc tính isReadOnly thành True
        {
            // Lấy button được click
            Button btn = sender as Button; 
            // Lấy ListViewItem chứa button
            ListViewItem item = FindAncestor<ListViewItem>(btn);

            if (item != null)
            {
                // Lấy dữ liệu của ListViewItem
                dynamic dataItem = item.DataContext;

                if (dataItem != null)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa mục đã chọn?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        { 
                            string idVoucher = dataItem.IdVoucher;
                            // Xóa dữ liệu từ bảng SanPham
                            ndvcDao.XoaTheoIdVoucher(idVoucher);
                            voucherDao.XoaVoucherTheoIdVoucher(idVoucher);
                            // Load lại tab QL Voucher
                            QuanLyVoucher_Load(sender, e);


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xảy ra khi xóa sản phẩm: " + ex.Message);
                        }
                           
                    }
                }
            }
            else
            {
                MessageBox.Show("Không thể xác định dòng chứa nút 'Xóa'.");
            }
        }

        // Hàm trợ giúp để tìm thành phần cha của một kiểu cụ thể
        public static T FindAncestor<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);

            if (parent == null)
                return null;

            var parentT = parent as T;
            return parentT ?? FindAncestor<T>(parent);
        }

        #endregion


        //Tab Quản lý người dùng

        public class User
        {
            public string UserId { get; set; }
            public string FullName { get; set; }
            public string Identification { get; set; }
            public string Gender { get; set; }
            public string PhoneNumber { get; set; }
            public string DateOfBirth { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
            public string Promotion { get; set; }
            public double ShippingFee { get; set; }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            /*DangKy f = new DangKy();
            f.txtbTieuDe.Text = "Thông tin người dùng";
            f.btnDangKy.Content = "Cập nhật";
            f.ShowDialog();*/
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?","Thông báo",MessageBoxButton.OKCancel,MessageBoxImage.Question);
        }


        private void btnDuyet_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nếu chưa duyệt thì chuyển sang đã duyệt\nNếu đã duyệt rồi, thì khi ấn nút này nó báo là sp đã được duyệt(hoặc vô hiệu hóa cái nút được thì càng tốt)");
        }

        
    }
}

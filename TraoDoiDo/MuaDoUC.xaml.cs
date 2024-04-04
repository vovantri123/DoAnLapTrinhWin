using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TraoDoiDo.Models;
using TraoDoiDo.ViewModels;
using TraoDoiDo.Database;
using System.Xml.Linq;
namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for MuaDo.xaml
    /// </summary>
    public partial class MuaDoUC : UserControl
    {


        private int soLuongSP = 0;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        private SanPhamUC[] DanhSachSanPham = new SanPhamUC[100];
        KhachHang ngDung = new KhachHang();
        SanPhamDao sanPhamDao = new SanPhamDao();

        public MuaDoUC()
        {
            InitializeComponent();
            Loaded += MuaSam_Load; // TAB1
            //Loaded += GioHang_Load; //TAB2
            //Loaded += TrangThaiDonHang_Load; //TAB3
        } 
        public MuaDoUC(KhachHang kh)
        {
            InitializeComponent();
            Loaded += MuaSam_Load; // TAB1
           // Loaded += GioHang_Load; //TAB2
            //Loaded += TrangThaiDonHang_Load; //TAB3
            ngDung = kh;
        }

        #region TAB1 MUA SẮM
        private void MuaSam_Load(object sender, RoutedEventArgs e)
        {
            LoadSanPhamlenWpnlHienThi();
            SapXepGiamDanTheoSoLuotXem();
            //SapXeoTheoYeuThich();
        }
        private void txbTimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbTimKiem.Text.Trim() != "")
            {
                wpnlHienThi.Children.Clear();
                for (int i = 0; i < soLuongSP; i++)
                {
                    string tenSP = DanhSachSanPham[i].txtbTen.Text.ToLower();
                    string timKiem = txbTimKiem.Text.Trim().ToLower();
                    if (tenSP.Contains(timKiem))
                    {
                        wpnlHienThi.Children.Add(DanhSachSanPham[i]);
                    }
                }
            }
            else
            {
                wpnlHienThi.Children.Clear();
                for (int i = 0; i < soLuongSP; i++)
                {
                    wpnlHienThi.Children.Add(DanhSachSanPham[i]);
                }
            }
        }

        private void SapXeoTheoYeuThich()
        {
            LoadSanPhamlenWpnlHienThi(); //Cái nói chung cái gì dính tới yêu thích thì cứ load lại 1 cái, mấy cái lọc với tìm kiếm không cần là do tính năng ẩn hiện cái nút của bên UC có sẵn r :)))
            wpnlHienThi.Children.Clear();
            for (int i = 0; i < soLuongSP; i++)
                if (DanhSachSanPham[i].yeuThich == 1)
                {
                    wpnlHienThi.Children.Add(DanhSachSanPham[i]);
                }
            for (int i = 0; i < soLuongSP; i++)
                if (DanhSachSanPham[i].yeuThich == 0)
                {
                    wpnlHienThi.Children.Add(DanhSachSanPham[i]);
                }
        }

        private void cboSapXepTheoLoai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedItem != null)
            {
                string selectedItemContent = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();
                if (selectedItemContent == "Tất cả")
                {
                    wpnlHienThi.Children.Clear();
                    for (int i = 0; i < soLuongSP; i++)
                    {
                        wpnlHienThi.Children.Add(DanhSachSanPham[i]);
                    }
                }
                else
                {
                    wpnlHienThi.Children.Clear();
                    for (int i = 0; i < soLuongSP; i++)
                    {
                        if (DanhSachSanPham[i].txtbLoai.Text.Contains(selectedItemContent))
                        {
                            wpnlHienThi.Children.Add(DanhSachSanPham[i]);
                        }
                    }
                }
            }
        }


        private void cboSapXepTheoYeuThich_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedItem != null)
            {
                string selectedItemContent = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();
                if (selectedItemContent == "Yêu thích")
                {
                    SapXeoTheoYeuThich();
                }
                else
                {
                    SapXepGiamDanTheoSoLuotXem();
                }
            }
        }
        private void LoadSanPhamlenWpnlHienThi()
        {
            soLuongSP = 0;
            try
            {
                conn.Open();
                List<List<string>> listSanPham = new List<List<string>>();
                listSanPham = sanPhamDao.LoadSanPham(ngDung.Id);

                foreach(var list in listSanPham)
                {
                    int yeuThich = 0;
                    if (!string.IsNullOrEmpty(list[8])) //Neu nguoi mua co trong bang yeu thich (tức đang yêu thich một sản phẩm nào đó)
                    {
                        yeuThich = 1;
                    }

                    DanhSachSanPham[soLuongSP] = new SanPhamUC(yeuThich); // Khởi tạo mỗi phần tử của mảng (KHÔNG CÓ LÀ LỖI)

                    DanhSachSanPham[soLuongSP].txtbIdSanPham.Text = list[0].ToString();
                    DanhSachSanPham[soLuongSP].txtbTen.Text = list[1];

                    string tenFileAnh = list[2];
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    string duongDanhAnh = XuLyAnh.layDuongDanDayDuToiFileAnh(tenFileAnh);
                    bitmap.UriSource = new Uri(duongDanhAnh);
                    bitmap.EndInit();
                    // Gán BitmapImage tới Source của Image control
                    DanhSachSanPham[soLuongSP].imgSP.Source = bitmap;

                    DanhSachSanPham[soLuongSP].txtbGiaGoc.Text = list[3];
                    DanhSachSanPham[soLuongSP].txtbGiaBan.Text = list[4];
                    DanhSachSanPham[soLuongSP].txtbNoiBan.Text = list[5];
                    DanhSachSanPham[soLuongSP].txtbSoLuotXem.Text = list[6];
                    DanhSachSanPham[soLuongSP].idNguoiDang = list[7].ToString();
                    DanhSachSanPham[soLuongSP].txtbLoai.Text = list[9];

                    //SanPham sanPham = new SanPham(id, name, imageUrl); 
                    //lsvQuanLySanPham.Items.Add(sanPham);
                    DanhSachSanPham[soLuongSP].Margin = new Thickness(8);
                    DanhSachSanPham[soLuongSP].idNguoiMua = ngDung.Id;
                    wpnlHienThi.Children.Add(DanhSachSanPham[soLuongSP]);
                    soLuongSP++;
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
        private void SapXepGiamDanTheoSoLuotXem()
        {
            for (int i = 0; i < soLuongSP - 1; i++)
                for (int j = i + 1; j < soLuongSP; j++)
                    if (Convert.ToInt32(DanhSachSanPham[i].txtbSoLuotXem.Text) < Convert.ToInt32(DanhSachSanPham[j].txtbSoLuotXem.Text))
                    {
                        int yeuThich = 0;
                        SanPhamUC spTam = new SanPhamUC(yeuThich);
                        spTam = DanhSachSanPham[i];
                        DanhSachSanPham[i] = DanhSachSanPham[j];
                        DanhSachSanPham[j] = spTam;
                    }
            wpnlHienThi.Children.Clear();
            for (int i = 0; i < soLuongSP; i++)
            {
                wpnlHienThi.Children.Add(DanhSachSanPham[i]);
            }
        }
        #endregion



        #region TAB2 GIỎ HÀNG


        private void GioHang_Load(object sender, RoutedEventArgs e)
        {
            LsvGioHang_Load(sender, e);
        }


        private void LsvGioHang_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                string sqlStr = $@"
                    SELECT GioHang.IdSanPham, Ten, LinkAnhBia, GiaBan, PhiShip, SoLuongMua, SoLuong, SoLuongDaBan 
                    FROM GioHang 
                    INNER JOIN NguoiDung ON GioHang.IdNguoiMua = NguoiDung.IdNguoiDung
                    INNER JOIN SanPham ON GioHang.IdSanPham = SanPham.IdSanPham
                    WHERE NguoiDung.IdNguoiDung = '{ngDung.Id}'

                ";

                SqlCommand command = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = command.ExecuteReader();
                lsvGioHang.Items.Clear();
                while (reader.Read())
                {
                    string idSP = reader.GetString(0);
                    string tenSP = reader.GetString(1);
                    string tenFileAnh = reader.GetString(2);
                    string linkAnhBia = XuLyAnh.layDuongDanDayDuToiFileAnh(tenFileAnh);



                    string giaBan = reader.GetString(3);
                    string phiShip = reader.GetString(4);
                    string soLuongMua = reader.GetString(5);

                    int soLuong = Convert.ToInt32(reader.GetString(6)); // số lượng Tổng
                    int soLuongDaBan = Convert.ToInt32(reader.GetString(7));
                    string trangThai = "";
                    if (soLuongDaBan >= soLuong)
                        trangThai = "Hết hàng";
                    else
                        trangThai = "Còn hàng";


                    lsvGioHang.Items.Add(new { IdSP = idSP, TenSP = tenSP, LinkAnhBia = linkAnhBia, Gia = giaBan, PhiShip = phiShip, SoLuongMua = soLuongMua, TrangThaiConHayHet = trangThai });

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

        private void btnXoaKhoiGioHang_Click(object sender, RoutedEventArgs e)
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
                            conn.Open();
                            string sqlDelete = $@"DELETE FROM GioHang WHERE IdNguoiMua={ngDung.Id} AND IdSanPham = {dataItem.IdSP} ";
                            SqlCommand cmdDelete = new SqlCommand(sqlDelete, conn);
                            cmdDelete.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xảy ra khi xóa sản phẩm: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                            GioHang_Load(sender, e);
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

        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            DiaChi f = new DiaChi();
            f.ShowDialog();
        }

        private void ChonTatCaCacDong_Click(object sender, RoutedEventArgs e)
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
            TinhTienCuaNhungDongDuocChon(sender, e);
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


        private void TinhTienCuaNhungDongDuocChon(object sender, RoutedEventArgs e)
        {
            int tongTienhang = 0;
            int tongTienShip = 0;


            foreach (var dongDuocChon in lsvGioHang.SelectedItems)
            {
                dynamic item = dongDuocChon;
                int gia = Convert.ToInt32(item.Gia);
                int phiShip = Convert.ToInt32(item.PhiShip);
                int soLuongMua = Convert.ToInt32(item.SoLuongMua);

                tongTienhang += gia * soLuongMua;
                tongTienShip += phiShip;
            }

            txtbTongTienHang.Text = tongTienhang.ToString();
            txtbTongTienShip.Text = tongTienShip.ToString();
            txtbTongThanhToan.Text = (tongTienhang + tongTienShip).ToString();
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
                    INNER JOIN NguoiDung ON TrangThaiDonHang.IdNguoiMua = NguoiDung.IdNguoiDung
                    INNER JOIN SanPham ON TrangThaiDonHang.IdSanPham= SanPham.IdSanPham
                    WHERE NguoiDung.IdNguoiDung = {ngDung.Id} and TrangThaiDonHang.TrangThai = N'{trangthai}'
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
        private void btnHuyDatHang_Click(object sender, RoutedEventArgs e)
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
                    if (MessageBox.Show("Bạn có chắc là muốn hủy đặt hàng 0_o\nĐơn hàng mà bạn hủy sẽ được hoàn tiền", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            conn.Open();

                            // Xóa dữ liệu từ bảng TrangThaiDongHang
                            string sqlDelete = $"DELETE FROM TrangThaiDonHang WHERE IdSanPham = {dataItem.IdSP} AND IdNguoiMua = {ngDung.Id}";
                            SqlCommand cmdDelete = new SqlCommand(sqlDelete, conn);
                            cmdDelete.ExecuteNonQuery();


                            // Xóa dữ liệu  khỏi bảng QuanLyDonHang 
                            sqlDelete = $"DELETE FROM QuanLyDonHang WHERE IdSanPham = {dataItem.IdSP} AND IdNguoiMua = {ngDung.Id}";
                            cmdDelete = new SqlCommand(sqlDelete, conn);
                            cmdDelete.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xảy ra khi xóa: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                            TrangThaiDonHang_Load(sender, e);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không thể xác định dòng chứa nút 'Xóa'.");
            }
        }


        private void btnDaNhanHang_Click(object sender, RoutedEventArgs e)
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
                    if (MessageBox.Show("Bạn có chắc là đã nhận được hàng 0_o", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            conn.Open();

                            string sqlStr = $@"
                                UPDATE TrangThaiDonHang 
                                SET TrangThai = N'Đã nhận'
                                WHERE IdSanPham = {dataItem.IdSP} AND IdNguoiMua = {ngDung.Id}
                            ";
                            SqlCommand command = new SqlCommand(sqlStr, conn);
                            command.ExecuteNonQuery();

                            sqlStr = $@" 
                                UPDATE QuanLyDonHang 
                                SET TrangThai = N'Đã giao'
                                WHERE IdSanPham = {dataItem.IdSP} AND IdNguoiMua = {ngDung.Id}
                            ";
                            command = new SqlCommand(sqlStr, conn);
                            command.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xảy ra: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                            TrangThaiDonHang_Load(sender, e);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không thể xác định dòng chứa nút .");
            }
        }

        private void btnDanhGia_Click(object sender, RoutedEventArgs e)
        {
            DanhGia f = new DanhGia();
            f.idNguoiMua = ngDung.Id;


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

                    try
                    {
                        conn.Open();

                        string sqlStr = $@"
                            SELECT IdNguoiDang, HoTenNguoiDung 
                            FROM SanPham
                            INNER JOIN NguoiDung ON SanPham.IdSanPham = NguoiDung.IdNguoiDung
                            WHERE IdSanPham = {dataItem.IdSP}
                        ";
                        SqlCommand command = new SqlCommand(sqlStr, conn);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            f.idNguoiDang = reader.GetInt32(0).ToString();
                            f.txtbTenNguoiDang.Text = reader.GetString(1);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xảy ra: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                        TrangThaiDonHang_Load(sender, e);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không thể xác định dòng chứa nút .");
            }

            f.ShowDialog();
        }



        private void btnTraHang_Click(object sender, RoutedEventArgs e)
        {
            ucLyDoTraHang.idNguoiMua = ngDung.Id;

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
                    ucLyDoTraHang.idSP = dataItem.IdSP;
                    ucLyDoTraHang.DrawerClosed += (btnSender, args) =>
                    {

                        LoadLsvTrongTabTrangThaiDonHang("lsvChoGiaoHang", "Chờ giao hàng");
                    };
                }
            }
            else
            {
                MessageBox.Show("Không thể xác định dòng chứa nút 'Xóa'.");
            }
        }


        #endregion

    }
}

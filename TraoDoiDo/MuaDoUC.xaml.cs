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
        GioHangDao gioHangDao = new GioHangDao();
        TrangThaiDonHangDao trangThaiDonHangDao = new TrangThaiDonHangDao();
        QuanLyDonHangDao quanLyDonHangDao = new QuanLyDonHangDao();
        List<List<string>> listSp = new List<List<string>>();
        public MuaDoUC()
        {
            InitializeComponent();
            Loaded += MuaSam_Load; // TAB1
            Loaded += GioHang_Load; //TAB2
            Loaded += TrangThaiDonHang_Load; //TAB3
        } 
        public MuaDoUC(KhachHang kh)
        {
            InitializeComponent();
            Loaded += MuaSam_Load; // TAB1
            Loaded += GioHang_Load; //TAB2
            Loaded += TrangThaiDonHang_Load; //TAB3
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
                    DanhSachSanPham[soLuongSP].idNguoiMua = ngDung.Id;
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
                List<List<string>> listSanPham = new List<List<string>>();
                listSanPham = gioHangDao.timThongTinSanPham(ngDung.Id);
                lsvGioHang.Items.Clear();
                foreach(var list in listSanPham)
                {
                    string tenFileAnh =list[2];
                    string linkAnhBia = XuLyAnh.layDuongDanDayDuToiFileAnh(tenFileAnh);

                    int soLuong = Convert.ToInt32(list[6]); // số lượng Tổng
                    int soLuongDaBan = Convert.ToInt32(list[7]);
                    string trangThai = "";
                    
                    if (soLuongDaBan >= soLuong)
                        trangThai = "Hết hàng";
                    else
                        trangThai = "Còn hàng";
                    SanPham sanPham = new SanPham(list[0], ngDung.Id, list[1], linkAnhBia, null, list[6], list[7], null, list[3], list[4], trangThai, null, null, null, null, null, null);
                    lsvGioHang.Items.Add(new { IdSP = sanPham.Id, TenSP = sanPham.Ten, LinkAnhBia = linkAnhBia, Gia = sanPham.GiaBan, PhiShip = sanPham.PhiShip, SoLuongMua = list[5], TrangThaiConHayHet = trangThai });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                            GioHang gioHang = new GioHang(ngDung.Id, dataItem.IdSP,dataItem.SoLuongMua);
                            gioHangDao.Xoa(gioHang);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xảy ra khi xóa sản phẩm: " + ex.Message);
                        }
                        finally
                        {
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
            DiaChi f = new DiaChi(ngDung,listSp);
            f.tongThanhToan = txtbTongThanhToan.Text;
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
            List<string> listID = new List<string>();
            string[] mang = new string[6]; 
            foreach (var dongDuocChon in lsvGioHang.SelectedItems)
            {
                dynamic item = dongDuocChon;
                int gia = Convert.ToInt32(item.Gia);
                int phiShip = Convert.ToInt32(item.PhiShip);
                int soLuongMua = Convert.ToInt32(item.SoLuongMua);
                string idSP = item.IdSP;
                tongTienhang += gia * soLuongMua;
                tongTienShip += phiShip;
                mang[0] = ngDung.Id;
                mang[1] = item.IdSP;
                mang[2] = soLuongMua.ToString();
                mang[3] = (tongTienhang + tongTienShip).ToString();
                mang[4] = DateTime.Now.ToString();
                mang[5] = "Chờ xác nhận";
                listID.AddRange(mang);
                listSp.Add(listID);
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
                //Load Form TrangThaiDonHang
                List<List<string>> listTrangThaiDon = new List<List<string>>();
                TrangThaiDonHang trangThaiDonHang = new TrangThaiDonHang(ngDung.Id,null,null,null,null,trangthai);
                // Sử dụng list<string> truy xuất list[0] thay cho getString
                listTrangThaiDon = trangThaiDonHangDao.LoadTrangThaiDonHang(trangThaiDonHang);

                if (tenLsv == "lsvChoNguoiBanXacNhan")
                    lsvChoNguoiBanXacNhan.Items.Clear();
                else if (tenLsv == "lsvChoGiaoHang")
                    lsvChoGiaoHang.Items.Clear();
                else if (tenLsv == "lsvDaNhan")
                    lsvDaNhan.Items.Clear();

                foreach(var list in listTrangThaiDon)
                {
                    string tenFileAnh = list[2];
                    string linkAnhBia = XuLyAnh.layDuongDanDayDuToiFileAnh(tenFileAnh);

                    if (tenLsv == "lsvChoNguoiBanXacNhan")
                        lsvChoNguoiBanXacNhan.Items.Add(new { IdSP = list[0], TenSP = list[1], LinkAnhBia = linkAnhBia, Gia = list[4], PhiShip = list[5], SoLuongMua = list[3], TongThanhToan = list[6], Ngay = list[7] });
                    else if (tenLsv == "lsvChoGiaoHang")
                        lsvChoGiaoHang.Items.Add(new { IdSP = list[0], TenSP = list[1], LinkAnhBia = linkAnhBia, Gia = list[4], PhiShip = list[5], SoLuongMua = list[3], TongThanhToan = list[6], Ngay = list[7] });
                    else if (tenLsv == "lsvDaNhan")
                        lsvDaNhan.Items.Add(new { IdSP = list[0], TenSP = list[1], LinkAnhBia = linkAnhBia, Gia = list[4], PhiShip = list[5], SoLuongMua = list[3], TongThanhToan = list[6], Ngay = list[7] });
                    //SanPham sanPham = new SanPham(id, name, imageUrl); 
                    //lsvQuanLySanPham.Items.Add(sanPham);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                            // Xóa dữ liệu từ bảng TrangThaiDongHang
                            TrangThaiDonHang trangThaiDonHang = new TrangThaiDonHang(ngDung.Id,dataItem.IdSP,dataItem.SoLuongMua,dataItem.TongThanhToan,dataItem.Ngay,null);
                            trangThaiDonHangDao.Xoa(trangThaiDonHang);

                            // Xóa dữ liệu  khỏi bảng QuanLyDonHang 
                            QuanLyDonHang quanLyDonHang = new QuanLyDonHang(null, null, ngDung.Id, dataItem.IdSP, null, null);
                            quanLyDonHangDao.Xoa(quanLyDonHang);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xảy ra khi xóa: " + ex.Message);
                        }
                        finally
                        {
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
                            TrangThaiDonHang trangThaiDonHang = new TrangThaiDonHang(ngDung.Id,dataItem.IdSP,dataItem.SoLuongMua,dataItem.TongThanhToan,dataItem.Ngay,"Đã nhận");
                            trangThaiDonHangDao.CapNhat(trangThaiDonHang);

                            QuanLyDonHang quanLyDonHang = new QuanLyDonHang(null,null,ngDung.Id,dataItem.IdSP,"Đã giao",null);
                            quanLyDonHangDao.CapNhat(quanLyDonHang);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xảy ra: " + ex.Message);
                        }
                        finally
                        {
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
                        List<string> listSanPham = new List<string>();
                        listSanPham = sanPhamDao.timKiemIdNguoiDang(dataItem.IdSP);
                        f.idNguoiDang = listSanPham[0].ToString();
                        f.txtbTenNguoiDang.Text = listSanPham[1];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xảy ra: " + ex.Message);
                    }
                    finally
                    {
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

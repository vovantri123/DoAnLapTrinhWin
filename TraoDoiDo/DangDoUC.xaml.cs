using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using LiveCharts.Defaults;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Data.SqlClient;
using TraoDoiDo.Models;
using System.Data;
using System.Windows.Media;
using System.ComponentModel.Design;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;

namespace TraoDoiDo
{

    public partial class DangDoUC : UserControl
    {
        public int idNguoiDang = 1;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public DangDoUC()
        {
            InitializeComponent();
            Loaded += QuanLySanPham_Load;
            Loaded += QuanLyDonHang_Load;

        }
        #region TAB1 QUẢN LÝ SẢN PHẨM
        private void QuanLySanPham_Load(object sender, RoutedEventArgs e) //Form load của Tab1
        {
            HienThi_QuanLySanPham();
        }
        private void txbTiemKiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                conn.Open();
                string sqlStr = $@"
                    SELECT IdSanPham, Ten, LinkAnhBia, Loai, SoLuong, SoLuongDaBan, GiaGoc, GiaBan, PhiShip
                    FROM SanPham
                    WHERE Ten LIKE N'{txbTimKiem.Text.Trim()}%'
                ";

                SqlCommand command = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = command.ExecuteReader();
                lsvQuanLySanPham.Items.Clear();
                while (reader.Read())
                {
                    string id = reader.GetString(0);
                    string name = reader.GetString(1);

                    string tenFileAnh = reader.GetString(2);
                    string linkAnhBia = XuLyAnh.layDuongDanDayDuToiFileAnh(tenFileAnh);

                    string loai = reader.GetString(3);
                    string soLuong = reader.GetString(4);
                    string soLuongDaBan = reader.GetString(5);
                    string giaGoc = reader.GetString(6);
                    string giaBan = reader.GetString(7);
                    string phiShip = reader.GetString(8);


                    lsvQuanLySanPham.Items.Add(new { Id = id, Ten = name, LinkAnh = linkAnhBia, Loai = loai, SoLuong = soLuong, SoLuongDaBan = soLuongDaBan, GiaGoc = giaGoc, GiaBan = giaBan, PhiShip = phiShip});

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

        private void HienThi_QuanLySanPham()
        {

            try
            {
                conn.Open();
                string sqlStr = $@"
                    SELECT IdSanPham, Ten, LinkAnhBia, Loai, SoLuong, SoLuongDaBan, GiaGoc, GiaBan, PhiShip, TrangThai 
                    FROM SanPham
                    WHERE IdNguoiDang = {idNguoiDang}
                ";

                SqlCommand command = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = command.ExecuteReader();
                lsvQuanLySanPham.Items.Clear();
                while (reader.Read())
                {
                    string id = reader.GetString(0);
                    string name = reader.GetString(1); 

                    string tenFileAnh = reader.GetString(2);
                    string linkAnhBia = XuLyAnh.layDuongDanDayDuToiFileAnh(tenFileAnh);

                    string loai = reader.GetString(3);
                    string soLuong = reader.GetString(4);
                    string soLuongDaBan = reader.GetString(5);
                    string giaGoc = reader.GetString(6);
                    string giaBan = reader.GetString(7);
                    string phiShip = reader.GetString(8);
                    string trangThai = reader.GetString(9);

                    
                    lsvQuanLySanPham.Items.Add(new { Id = id, Ten = name, LinkAnh = linkAnhBia, Loai = loai, SoLuong = soLuong, SoLuongDaBan = soLuongDaBan, GiaGoc = giaGoc, GiaBan = giaBan, PhiShip = phiShip, TrangThai = trangThai });

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

        private void btnXoa_Click(object sender, RoutedEventArgs e)
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

                            // Xóa dữ liệu từ bảng SanPham
                            string sqlDelete = $"DELETE FROM SanPham WHERE IdSanPham = {dataItem.Id}";
                            SqlCommand cmdDelete = new SqlCommand(sqlDelete, conn);
                            cmdDelete.ExecuteNonQuery();

                            // Xóa dữ liệu từ lsvQuanLySanPham
                            lsvQuanLySanPham.Items.Remove(dataItem);

                            // Xóa dữ liệu  khỏi bảng MoTaAnhSanPham
                            sqlDelete = $"DELETE FROM MoTaAnhSanPham WHERE IdSanPham = {dataItem.Id}";
                            cmdDelete = new SqlCommand(sqlDelete, conn);
                            cmdDelete.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xảy ra khi xóa sản phẩm: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
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
 

        private int timIdMaxTrongBangSanPham()
        {
            int idMax = 0;
            try
            {
                conn.Open();
                string sqlStr = "SELECT MAX(CONVERT(BIGINT, IdSanPham)) FROM SanPham;";

                SqlCommand command = new SqlCommand(sqlStr, conn);
                object result = command.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    int maxId = Convert.ToInt32(result);

                    idMax = maxId;
                }
                // Không có dữ liệu trong bảng thì return 0
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return idMax;
        }

        private void btnThemSanPhamMoi_Click(object sender, RoutedEventArgs e)
        {
            DangDo_Dang f = new DangDo_Dang(); 

             
            f.txtbIdSanPham.Text = (timIdMaxTrongBangSanPham()+1).ToString(); //Truy vấn để lấy ra id max :v

            // DƯỚI ĐÂY LÀ CÁCH Load lại lsvQuanLySanPham sau khi (thêm sản phẩm, và đóng cái DangDo_Dang)
            f.Closed += (s, ev) =>
            {
                HienThi_QuanLySanPham();
            };
            f.Show();

        }

        private void btnSuaDo_Click(object sender, RoutedEventArgs e)
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
                    DangDo_Sua f = new DangDo_Sua();
                    f.txtbIdSanPham.Text = dataItem.Id;


                    //Đổ dữ liệu qua form sửa_BEGIN
                    try
                    {
                        conn.Open();


                        //Đổ thông tin lên
                        string sqlStr = $@"SELECT * FROM SanPham WHERE IdSanPham = '{dataItem.Id}'";
                         
                        SqlCommand command = new SqlCommand(sqlStr, conn);
                        SqlDataReader reader = command.ExecuteReader(); 
                        while (reader.Read()) //While true cho dui chứ nó đọc có 1 dòng là nghỉ à (tại dữ liệu với sqlStr là duy nhất 1 dòng thôi)
                        {
                            //Cách 2 truyền tên cột thay vì index
                            f.txtbTen.Text = reader.GetString(reader.GetOrdinal("Ten"));
                            f.txtbLoai.Text = reader.GetString(reader.GetOrdinal("Loai"));
                            f.cboSoLuong.Text = reader.GetString(reader.GetOrdinal("SoLuong"));
                            f.cboSoLuongDaBan.Text = reader.GetString(reader.GetOrdinal("SoLuongDaBan"));
                            f.txtbGiaGoc.Text = reader.GetString(reader.GetOrdinal("GiaGoc"));
                            f.txtbGiaBan.Text = reader.GetString(reader.GetOrdinal("GiaBan"));
                            f.txtbPhiShip.Text = reader.GetString(reader.GetOrdinal("PhiShip"));
                            f.txtbNoiBan.Text = reader.GetString(reader.GetOrdinal("NoiBan"));
                            f.txtbXuatXu.Text = reader.GetString(reader.GetOrdinal("XuatXu"));
                            f.txtbNgayMua.Text = reader.GetString(reader.GetOrdinal("NgayMua"));
                            f.txtbPhanTramMoi.Text = reader.GetString(reader.GetOrdinal("PhanTramMoi"));
                            f.txtbMoTaChung.Text = reader.GetString(reader.GetOrdinal("MoTaChung")); 
                             
                        }
                        reader.Close(); // AI bảo là nếu chỉ dùng reader 1 lần thôi thì không cần đóng
                                        // DƯỚI ĐÂY LÀ CÁCH Load lại lsvQuanLySanPham sau  khi (sửa sản phẩm và đóng cái DangDo_Sua)
                        

                        //Đổ ảnh và mô tả lên
                        sqlStr = $@"
                            SELECT MoTaAnhSanPham.LinkAnhMinhHoa, MoTaAnhSanPham.MoTa 
                            FROM SanPham INNER JOIN MoTaAnhSanPham 
                            ON SanPham.IdSanPham = MoTaAnhSanPham.IdSanPham
                            WHERE SanPham.IdSanPham = '{dataItem.Id}'
                        ";
                        command = new SqlCommand(sqlStr, conn);
                        reader = command.ExecuteReader();   
                        while (reader.Read())
                        {
                            f.DanhSachAnhVaMoTa[f.soLuongAnh] = new ThemAnhKhiDangUC();

                            string tenFileAnh = reader.GetString(0);
                            f.DanhSachAnhVaMoTa[f.soLuongAnh].txtbTenFileAnh.Text = tenFileAnh;

                            string duongDanAnh = XuLyAnh.layDuongDanDayDuToiFileAnh(tenFileAnh);
                            f.DanhSachAnhVaMoTa[f.soLuongAnh].txtbDuongDanAnh.Text = duongDanAnh;
                            f.DanhSachAnhVaMoTa[f.soLuongAnh].imgAnhSP.Source = new BitmapImage(new Uri(duongDanAnh));
                            
                            string moTa = reader.GetString(1);
                            f.DanhSachAnhVaMoTa[f.soLuongAnh].txtbMoTa.Text = moTa; 

                            f.wpnlChuaAnh.Children.Add(f.DanhSachAnhVaMoTa[f.soLuongAnh]);
                            f.soLuongAnh++;
                        } 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                        f.Closed += (s, ev) =>
                        {
                            HienThi_QuanLySanPham();
                        };
                        f.Show();
                    } 
                    //Đổ dữ liệu qua form sửa_END

                    
                }
            }
        }


        #endregion


        #region TAB2 QUẢN LÝ ĐƠN HÀNG
        private void QuanLyDonHang_Load(object sender, RoutedEventArgs e)
        { 
            LoadLsvTrongTabQuanLyDonHang("lsvChoDongGoi", "Chờ đóng gói");
            LoadLsvTrongTabQuanLyDonHang("lsvDangGiao", "Đang giao");
            LoadLsvTrongTabQuanLyDonHang("lsvDaGiao", "Đã giao");
            LoadLsvTrongTabQuanLyDonHang("lsvDonHangBiHoanTra", "Bị hoàn trả");
        }
        private void LoadLsvTrongTabQuanLyDonHang(string tenLsv, string trangthai)
        {
            try
            {
                conn.Open();
                string sqlStr = $@"
                    SELECT SanPham.IdSanPham, SanPham.Ten, SanPham.LinkAnhBia, TrangThaiDonHang.SoLuongMua, SanPham.GiaBan, SanPham.PhiShip, TrangThaiDonHang.TongThanhToan, QuanLyDonHang.LyDoTraHang, QuanLyDonHang.IdNguoiMua
                    FROM QuanLyDonHang
                    INNER JOIN NguoiDung ON QuanLyDonHang.IdNguoiMua = NguoiDung.IdNguoiDung
                    INNER JOIN SanPham ON QuanLyDonHang.IdSanPham= SanPham.IdSanPham
                    INNER JOIN TrangThaiDonHang ON QuanLyDonHang.IdNguoiMua = TrangThaiDonHang.IdNguoiMua and  QuanLyDonHang.IdSanPham = TrangThaiDonHang.IdSanPham
                    WHERE QuanLyDonHang.IdNguoiDang = {idNguoiDang} and QuanLyDonHang.TrangThai=N'{trangthai}'
                ";

                SqlCommand command = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = command.ExecuteReader();

                if (tenLsv == "lsvChoDongGoi")
                    lsvChoDongGoi.Items.Clear();
                else if (tenLsv == "lsvDangGiao")
                    lsvDangGiao.Items.Clear();
                else if (tenLsv == "lsvDaGiao")
                    lsvDaGiao.Items.Clear();
                else if (tenLsv == "lsvDonHangBiHoanTra")
                    lsvDonHangBiHoanTra.Items.Clear();

                while (reader.Read())
                { 
                    string idSP = reader.GetString(0);
                    string tenSP = reader.GetString(1);
                    string tenFileAnh = reader.GetString(2);
                    string linkAnhBia = XuLyAnh.layDuongDanDayDuToiFileAnh(tenFileAnh);

                    string soLuongMua = reader.GetString(3);
                    string giaBan = reader.GetString(4);



                    string phiShip = reader.GetString(5);
                    string tongTien = reader.GetString(6);
                    string idNguoiMua = reader.GetInt32(8).ToString(); 
                    



                    if (tenLsv == "lsvChoDongGoi")
                        lsvChoDongGoi.Items.Add(new { IdSP = idSP, IdNguoiMua = idNguoiMua, TenSP = tenSP, LinkAnhBia = linkAnhBia, SoLuongMua = soLuongMua, Gia = giaBan, PhiShip = phiShip, TongTien = tongTien});
                    else if (tenLsv == "lsvDangGiao")
                        lsvDangGiao.Items.Add(new { IdSP = idSP, IdNguoiMua = idNguoiMua, TenSP = tenSP, LinkAnhBia = linkAnhBia, SoLuongMua = soLuongMua, Gia = giaBan, PhiShip = phiShip, TongTien = tongTien });
                    else if (tenLsv == "lsvDaGiao")
                        lsvDaGiao.Items.Add(new { IdSP = idSP, IdNguoiMua = idNguoiMua, TenSP = tenSP, LinkAnhBia = linkAnhBia, SoLuongMua = soLuongMua, Gia = giaBan, PhiShip = phiShip, TongTien = tongTien});
                    else if (tenLsv == "lsvDonHangBiHoanTra")
                    {
                        string lyDoTraHang = reader.GetString(7);
                        lsvDonHangBiHoanTra.Items.Add(new { IdSP = idSP, IdNguoiMua = idNguoiMua, TenSP = tenSP, LinkAnhBia = linkAnhBia, SoLuongMua = soLuongMua, Gia = giaBan, PhiShip = phiShip,  TongTien = tongTien, LyDoTraHang = lyDoTraHang });
                    }    
                        

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

        
        private void btnDiaChiGuiHang_Click(object sender, RoutedEventArgs e)
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
                    DiaChi f = new DiaChi(Convert.ToInt32(dataItem.IdNguoiMua)); 

                     
                    try
                    {
                        conn.Open();

                         
                        string sqlStr = $@" 
                            SELECT distinct HoTenNguoiDung, SdtNguoiDung, EmailNguoiDung, DiaChiNguoiDung
                            FROM TrangThaiDonHang
                            INNER JOIN NguoiDung ON TrangThaiDonHang.IdNguoiMua = NguoiDung.IdNguoiDung
                            WHERE TrangThaiDonHang.IdNguoiMua={dataItem.IdNguoiMua} AND TrangThaiDonHang.IdSanPham = {dataItem.IdSP}
                        ";

                        SqlCommand command = new SqlCommand(sqlStr, conn);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read()) 
                        {  
                            f.txtbTieuDe.Text = "Địa chỉ khách hàng";
                            f.txtHoTen.Text = reader.GetString(0);
                            f.txtSoDienThoai.Text = reader.GetString(1);
                            f.txtEmail.Text = reader.GetString(2);
                            f.txtDiaChi.Text = reader.GetString(3);
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();

                        f.cboHinhThucThanhToan.IsEnabled = false;
                        f.txtHoTen.IsReadOnly = true;
                        f.txtDiaChi.IsReadOnly = true;
                        f.txtSoDienThoai.IsReadOnly = true;
                        f.txtEmail.IsReadOnly = true;

                        f.btnXacNhanThanhToan.Visibility = Visibility.Collapsed;
                        
                        

                        f.Show();
                    } 


                }
            }
           
            
        }
        private void btnGuiHang_Click(object sender, RoutedEventArgs e)
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
                    int idNguoiMua = Convert.ToInt32(dataItem.IdNguoiMua);
                    string idSanPham = dataItem.IdSP;
                    DiaChi f = new DiaChi(idNguoiMua);


                    try
                    {
                        conn.Open();
                        

                        
                        string sqlStr = $@"UPDATE QuanLyDonHang 
                        SET TrangThai = N'Đang giao'   
                        WHERE IdNguoiMua = {idNguoiMua} AND IdSanPham = {idSanPham}";


                        SqlCommand command = new SqlCommand(sqlStr, conn); 
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Đơn hàng đã được chuyển giao cho shipper");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                        QuanLyDonHang_Load(sender,e);
                    }


                }
            }
            
        }


        #endregion

    }
}


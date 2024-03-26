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

namespace TraoDoiDo
{

    public partial class DangDoUC : UserControl
    {
        private int idNguoiDang = 2;
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

        private void HienThi_QuanLySanPham()
        {

            try
            {
                conn.Open();
                string sqlStr = "SELECT IdSanPham, Ten, LinkAnhBia, Loai, SoLuong, SoLuongDaBan, GiaGoc, GiaBan, PhiShip, TrangThai FROM SanPham";

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
            //Truy vấn để lấy ra id max :v

            f.txtbIdSanPham.Text = (timIdMaxTrongBangSanPham()+1).ToString();

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
                    // DƯỚI ĐÂY LÀ CÁCH Load lại lsvQuanLySanPham sau  khi (sửa sản phẩm và đóng cái DangDo_Sua)
                    f.Closed += (s, ev) =>
                    {
                        HienThi_QuanLySanPham();
                    };
                    f.Show();
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
                    SELECT SanPham.IdSanPham,SanPham.Ten,SanPham.LinkAnhBia, SanPham.GiaBan, SanPham.PhiShip, TrangThaiDonHang.TongThanhToan, DonHang.TrangThai, DonHang.LyDoTraHang
                    FROM DonHang
                    INNER JOIN NguoiDung ON DonHang.IdNguoiMua = NguoiDung.IdNguoiDung
                    INNER JOIN SanPham ON DonHang.IdSanPham= SanPham.IdSanPham
                    INNER JOIN TrangThaiDonHang ON DonHang.IdNguoiMua = TrangThaiDonHang.IdNguoiDung and  DonHang.IdSanPham = TrangThaiDonHang.IdSanPham
                    WHERE DonHang.IdNguoiDang = {idNguoiDang} and DonHang.TrangThai=N'{trangthai}'
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
                    



                    if (tenLsv == "lsvChoDongGoi")
                        lsvChoDongGoi.Items.Add(new { IdSP = idSP, TenSP = tenSP, LinkAnhBia = linkAnhBia, Gia = giaBan, PhiShip = phiShip, SoLuongMua = soLuongMua, TongTien = tongTien});
                    else if (tenLsv == "lsvDangGiao")
                        lsvDangGiao.Items.Add(new { IdSP = idSP, TenSP = tenSP, LinkAnhBia = linkAnhBia, Gia = giaBan, PhiShip = phiShip, SoLuongMua = soLuongMua, TongTien = tongTien });
                    else if (tenLsv == "lsvDaGiao")
                        lsvDaGiao.Items.Add(new { IdSP = idSP, TenSP = tenSP, LinkAnhBia = linkAnhBia, Gia = giaBan, PhiShip = phiShip, SoLuongMua = soLuongMua, TongTien = tongTien});
                    else if (tenLsv == "lsvDonHangBiHoanTra")
                    {
                        string lyDoTraHang = reader.GetString(7);
                        lsvDonHangBiHoanTra.Items.Add(new { IdSP = idSP, TenSP = tenSP, LinkAnhBia = linkAnhBia, Gia = giaBan, PhiShip = phiShip, SoLuongMua = soLuongMua, TongTien = tongTien, LyDoTraHang = lyDoTraHang });
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
            DiaChi f = new DiaChi();
            f.cboHinhThucThanhToan.IsEnabled = false;
            f.txtHoTen.IsReadOnly = true;
            f.txtDiaChi.IsReadOnly = true;
            f.txtSoDienThoai.IsReadOnly = true;
            f.txtEmail.IsReadOnly = true;

            f.btnXacNhanThanhToan.Visibility = Visibility.Collapsed;
            f.txtbTieuDe.Text = "Địa chỉ khách hàng";

            f.cboHinhThucThanhToan.Text = "Chuyển khoản";
            f.txtHoTen.Text = "Võ Văn Tri";
            f.txtSoDienThoai.Text = "0326123123";
            f.txtEmail.Text = "tri@gmail.com";
            f.txtDiaChi.Text = "Số 1 VVN";

            f.Show();
        }


        #endregion

    }
}


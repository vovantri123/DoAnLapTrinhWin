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

namespace TraoDoiDo
{

    public partial class DangDoUC : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public DangDoUC()
        {
            InitializeComponent();
            Loaded += DangDoUC_Loaded;

        }

        private void DangDoUC_Loaded(object sender, RoutedEventArgs e) //Giống firm load
        {
            //QUAN LY SAN PHAM
            HienThi_QuanLySanPham();
        }


        private void HienThi_QuanLySanPham()
        {
            try
            {
                conn.Open();
                string sqlStr = "SELECT Id, Ten, LinkAnhBia, Loai, SoLuong, SoLuongDaBan, GiaGoc, GiaBan, PhiShip, TrangThai FROM SanPham";

                SqlCommand command = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string id = reader.GetString(0);
                    string name = reader.GetString(1);
                    string linkAnh = reader.GetString(2);
                    string loai = reader.GetString(3);
                    string soLuong = reader.GetString(4);
                    string soLuongDaBan = reader.GetString(5);
                    string giaGoc = reader.GetString(6);
                    string giaBan = reader.GetString(7);
                    string phiShip = reader.GetString(8);
                    string trangThai = reader.GetString(9);

                    lsvQuanLySanPham.Items.Add(new { Id = id, Ten = name, LinkAnh = linkAnh, Loai = loai, SoLuong = soLuong, SoLuongDaBan = soLuongDaBan, GiaGoc = giaGoc, GiaBan = giaBan, PhiShip = phiShip, TrangThai = trangThai });

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


        // Dưới đây khoan hả sửa

        private void btnDangDo_Click(object sender, RoutedEventArgs e)
        {
            DangDo_Dang f = new DangDo_Dang();
            f.Show();
        }
        private void btnSuaDo_Click(object sender, RoutedEventArgs e)
        {
            DangDo_Dang f = new DangDo_Dang();
            f.btnDang.Content = "Sửa";
            f.Show();
        }
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bạn có chắc là muốn xóa sản phầm này?","Thông báo",MessageBoxButton.OKCancel, MessageBoxImage.Warning);
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
    }

}

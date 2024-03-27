﻿using System;
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
using System.Windows.Shapes;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for DiaChiNhanHang.xaml
    /// </summary>
    public partial class DiaChi : Window
    {

        public int idNguoiMua = 0; 
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public DiaChi(int idNguoiMua)
        {
            this.idNguoiMua=idNguoiMua;
            InitializeComponent();
            LoadThongTinNguoiMua(); 
        } 
        private void LoadThongTinNguoiMua()
        {
            try
            {
                conn.Open();
                string sqlStr = $@"
                    SELECT HoTenNguoiDung, SdtNguoiDung, EmailNguoiDung,DiaChiNguoiDung
                    FROM NguoiDung
                    WHERE IdNguoiDung = {idNguoiMua}
                ";
                SqlCommand command = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    //txtHoTen.Text = reader["HoTenNguoiDung"].ToString(); 
                    txtHoTen.Text = reader.GetString(0);
                    txtSoDienThoai.Text = reader.GetString(1);
                    txtEmail.Text = reader.GetString(2);
                    txtDiaChi.Text = reader.GetString(3);
                }    


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void btnXacNhanThanhToan_Click_1(object sender, RoutedEventArgs e)
        {

            capNhatThongTinCaNhan();
            MessageBox.Show("Đã thanh toán thành công\nĐơn hàng đang chờ người bán xác nhận\n(Nhớ trừ tiền dô tài khoản)", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void capNhatThongTinCaNhan()
        {
            try
            {
                conn.Open();
                string sqlStr = $@"
                    UPDATE NguoiDung
                    
                    SET HoTenNguoiDung = N'{txtHoTen.Text}', 
                        SdtNguoiDung='{txtSoDienThoai.Text}', 
                        EmailNguoiDung='{txtEmail.Text}',
                        DiaChiNguoiDung = N'{txtDiaChi.Text}'
                    WHERE IdNguoiDung = {idNguoiMua}
                ";
                SqlCommand command = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //txtHoTen.Text = reader["HoTenNguoiDung"].ToString(); 
                    txtHoTen.Text = reader.GetString(0);
                    txtSoDienThoai.Text = reader.GetString(1);
                    txtEmail.Text = reader.GetString(2);
                    txtDiaChi.Text = reader.GetString(3);
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for UCSanPham.xaml
    /// </summary>
    public partial class SanPhamUC : UserControl
    {
        public string idNguoiDang;
        public string idNguoiMua;
        private string tenNguoiDang;
        private string soLuotDanhGia;
        public int yeuThich = 0;

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        SanPham sanPham = new SanPham();
        public SanPhamUC(int yeuThich)
        {
            this.yeuThich = yeuThich;
            InitializeComponent();
            if (yeuThich == 0)
            {
                btnThemVaoYeuThich.Visibility = Visibility.Visible;
                btnBoYeuThich.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnThemVaoYeuThich.Visibility = Visibility.Collapsed;
                btnBoYeuThich.Visibility = Visibility.Visible;
            }
            
        }
        private void FSanPhamUC_Loaded(object sender, RoutedEventArgs e)
        {
            //sanPham = new SanPham(txtbIdSanPham.Text,idNguoiMua,txtbTen.Text,imgSP.Source.ToString(),txtbLoai.Text,null,null,txtbGiaGoc.Text,txtbGiaBan.Text,null,null,txtbNoiBan.Text,null,null,null,null,txtbSoLuotXem.Text);

        }
        private void timTenVaSoLuotDanhGiaNguoiDang()
        {
            try
            {
                conn.Open();
                string sqlStr = $@"
                    SELECT HoTenNguoiDung, COUNT(NhanXet) as SLNhanXet
                    FROM NguoiDung
                    INNER JOIN DanhGiaNguoiDang ON NguoiDung.IdNguoiDung = DanhGiaNguoiDang.IdNguoiDang
                    GROUP BY IdNguoiDung,HoTenNguoiDung
                    HAVING IdNguoiDung= {idNguoiDang}
                ";

                SqlCommand command = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tenNguoiDang = reader.GetString(0);
                    soLuotDanhGia = reader.GetInt32(1).ToString();

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

        private void tangSoLuotXemThem1()
        {
            int soLuotXem = 0;
            string idSanPham = txtbIdSanPham.Text;
            try
            {
                conn.Open();
                //B1 Lấy số lượt xem từ bảng SanPham
                string sqlStr = $@"SELECT SoLuotXem FROM SanPham WHERE IdSanPham = {idSanPham} ";
                SqlCommand command = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    soLuotXem = Convert.ToInt32(reader.GetString(0));
                }
                reader.Close();


                //B2 Cập nhật số lượt xem
                sqlStr = $@"
                UPDATE SanPham 
                SET SoLuotXem = '{(soLuotXem + 1)}' 
                WHERE IdSanPham = {idSanPham}
                ";
                command = new SqlCommand(sqlStr, conn);
                command.ExecuteNonQuery();
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




        private void btnThongTinChiTietSanPham_Click(object sender, MouseButtonEventArgs e)
        {
            timTenVaSoLuotDanhGiaNguoiDang();
            tangSoLuotXemThem1();
            sanPham = new SanPham(txtbIdSanPham.Text, idNguoiMua, txtbTen.Text, null, txtbLoai.Text, null, null, txtbGiaGoc.Text, txtbGiaBan.Text, null, null, txtbNoiBan.Text,null,null,null,null,txtbSoLuotXem.Text);
            ThongTinChiTietSanPham f = new ThongTinChiTietSanPham(sanPham);
            f.idNguoiDang = idNguoiDang;
            f.txtbTenNguoiDang.Text = tenNguoiDang;
            f.txtbSoLuotDanhGia.Text = soLuotDanhGia;
            f.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            f.idSanPham = txtbIdSanPham.Text;
            f.ShowDialog();
        }

        private void btnThemVaoYeuThich_Click(object sender, RoutedEventArgs e)
        {
            btnThemVaoYeuThich.Visibility = Visibility.Collapsed;
            btnBoYeuThich.Visibility = Visibility.Visible;
            try
            {
                conn.Open();


                // Câu lệnh SQL INSERT
                string sqlStr = $@"INSERT INTO DanhMucYeuThich (IdNguoiMua,IdSanPham) 
                   VALUES ('{idNguoiMua}', '{txtbIdSanPham.Text}')";

                SqlCommand command = new SqlCommand(sqlStr, conn);
                int rowsAffected = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void btnBoYeuThich_Click(object sender, RoutedEventArgs e)
        {
            btnBoYeuThich.Visibility = Visibility.Collapsed;
            btnThemVaoYeuThich.Visibility = Visibility.Visible;
            try
            {
                conn.Open();

                // Câu lệnh SQL INSERT
                string sqlStr = $@" DELETE FROM DanhMucYeuThich 
                WHERE IdNguoiMua = '{idNguoiMua}' AND IdSanPham = '{txtbIdSanPham.Text}'";

                SqlCommand command = new SqlCommand(sqlStr, conn);
                int rowsAffected = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        
    }
}

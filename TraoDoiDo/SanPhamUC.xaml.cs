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

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for UCSanPham.xaml
    /// </summary>
    public partial class SanPhamUC : UserControl
    {
        public int idNguoiDang = 0; 

        private string tenNguoiDang;
        private string soLuotDanhGia;
        public int yeuThich = 0;

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
 
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
        private void timTenVaSoLuotDahGiaNguoiDang()
        {
            try
            {
                conn.Open();
                string sqlStr = $@"
                    SELECT HoTenNguoiDung, COUNT(NhanXet) as SLNhanXet
                    FROM NguoiDung
                    INNER JOIN DanhGiaNguoiDang ON NguoiDung.IdNguoiDung = DanhGiaNguoiDang.IdNguoiDang
                    GROUP BY IdNguoiDung,HoTenNguoiDung
                    HAVING IdNguoiDung={idNguoiDang}
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
            int soLuotXem=0;
            string idSanPham = txtbIdSanPham.Text;
            try
            {
                conn.Open();
                //B1 Lấy số lượt xem từ bảng SanPham
                string sqlStr = $@"SELECT SoLuotXem FROM SanPham WHERE IdSanPham ={idSanPham}";
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
                SET SoLuotXem = '{(soLuotXem+1)}' 
                WHERE IdSanPham = '{idSanPham}'
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
            timTenVaSoLuotDahGiaNguoiDang();
            tangSoLuotXemThem1();

            ThongTinChiTietSanPham f = new ThongTinChiTietSanPham();
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
        }

        private void btnBoYeuThich_Click(object sender, RoutedEventArgs e)
        {
            btnBoYeuThich.Visibility = Visibility.Collapsed;
            btnThemVaoYeuThich.Visibility = Visibility.Visible;
        }
    }
}

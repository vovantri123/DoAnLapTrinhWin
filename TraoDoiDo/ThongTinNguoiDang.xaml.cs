using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ThongTinNguoiDang.xaml
    /// </summary>
    /// 
     
    public partial class ThongTinNguoiDang : Window
    { 
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr); 
        public ThongTinNguoiDang(int idNguoiDang)// K dùng constructor mà dùng public int id=1 toàn cục thì sẽ bị fail, do contrustor chạy trước khi gán
        {
            InitializeComponent();
            LoadThongTinNguoiDang(idNguoiDang);
            LoadDSDanhGia(idNguoiDang); 
        }

        private void LoadThongTinNguoiDang(int idNguoiDang)
        {
            try
            {
                conn.Open();
                string sqlStr = $@" 
                SELECT distinct HoTenNguoiDung, SdtNguoiDung, EmailNguoiDung, DiaChiNguoiDung
                FROM DanhGiaNguoiDang
                INNER JOIN NguoiDung ON DanhGiaNguoiDang.IdNguoiDang = NguoiDung.IdNguoiDung 
                WHERE DanhGiaNguoiDang.IdNguoiDang =  {idNguoiDang}

                ";

                SqlCommand command = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = command.ExecuteReader();
                itemsControlDSDanhGia.Items.Clear();
                while (reader.Read())
                {
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

        private void LoadDSDanhGia(int idNguoiDang)
        {
            try
            {
                conn.Open();
                string sqlStr = $@" 
                SELECT NguoiDung.HoTenNguoiDung, DanhGiaNguoiDang.SoSao, DanhGiaNguoiDang.NhanXet 
                FROM DanhGiaNguoiDang
                INNER JOIN NguoiDung ON DanhGiaNguoiDang.IdNguoiMua = NguoiDung.IdNguoiDung 
                WHERE DanhGiaNguoiDang.IdNguoiDang = {idNguoiDang}

                ";

                SqlCommand command = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = command.ExecuteReader();
                itemsControlDSDanhGia.Items.Clear();
                while (reader.Read())
                {
                    string ten = reader.GetString(0);
                    string soSao = reader.GetString(1);

                    string nhanXet = reader.GetString(2);
                   


                    itemsControlDSDanhGia.Items.Add(new {Ten = ten, SoSao = soSao, NhanXet = nhanXet}); 
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

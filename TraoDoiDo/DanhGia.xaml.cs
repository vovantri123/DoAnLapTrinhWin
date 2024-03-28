using System;
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
    /// Interaction logic for DanhGia.xaml
    /// </summary>
    public partial class DanhGia : Window
    {
        public int idNguoiDang=0;
        public int idNguoiMua=0;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public DanhGia()
        {
            InitializeComponent();
        }

        private void btnGuiDanhGia_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();

                string sqlStr = $@" DELETE DanhGiaNguoiDang 
                                     WHERE IdNguoiDang = {idNguoiDang} AND IdNguoiMua = {idNguoiMua}";
                SqlCommand command = new SqlCommand(sqlStr, conn);
                command.ExecuteNonQuery();


                sqlStr = $@" INSERT INTO DanhGiaNguoiDang (IdNguoiDang, IdNguoiMua ,SoSao, NhanXet)  
                                        VALUES ({idNguoiDang}, {idNguoiMua}, N'{ratingBarSoSao.Value}', N'{txtbDanhGia.Text}')";
                command = new SqlCommand(sqlStr, conn);
                command.ExecuteNonQuery();


                MessageBox.Show("Cảm ơn bạn đã gửi đánh giá\nChúc bạn một ngày vui :)", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                this.Close();
            }
        }
    }
}

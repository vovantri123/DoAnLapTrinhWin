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
using TraoDoiDo.Database;
using TraoDoiDo.Models;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for DanhGia.xaml
    /// </summary>
    public partial class DanhGia : Window
    {
        public string idNguoiDang;
        public string idNguoiMua;
        DanhGiaNguoiDangDao danhGiaNguoiDungDao = new DanhGiaNguoiDangDao();

        public DanhGia()
        {
            InitializeComponent();
        }

        public DanhGia(string idNguoiMua, string idNguoiDang)
        {
            InitializeComponent();
            this.idNguoiMua = idNguoiMua;
            this.idNguoiDang = idNguoiDang;
        }

        private void btnGuiDanhGia_Click(object sender, RoutedEventArgs e)
        { 
            DanhGiaNguoiDang danhGiaNguoiDung = new DanhGiaNguoiDang(idNguoiDang, null, idNguoiMua, null,ratingBarSoSao.Value.ToString(), txtbDanhGia.Text, null, null);
            try
            {
                danhGiaNguoiDungDao.Xoa(danhGiaNguoiDung);
                danhGiaNguoiDungDao.Them(danhGiaNguoiDung);
                MessageBox.Show("Cảm ơn bạn đã gửi đánh giá\nChúc bạn một ngày thật vui vẻ", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            } 
        }
    }
}

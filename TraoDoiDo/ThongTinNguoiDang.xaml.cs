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
using TraoDoiDo.Database;
using TraoDoiDo.ViewModels;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for ThongTinNguoiDang.xaml
    /// </summary>
    /// 
     
    public partial class ThongTinNguoiDang : Window
    { 
        DanhGiaNguoiDungDao danhGiaNguoiDungDao = new DanhGiaNguoiDungDao();
        public ThongTinNguoiDang(string idNguoiDang)// K dùng constructor mà dùng public int id=1 toàn cục thì sẽ bị fail, do contrustor chạy trước khi gán
        {
            InitializeComponent();
            LoadThongTinNguoiDang(idNguoiDang);
            LoadDSDanhGia(idNguoiDang); 
        }

        private void LoadThongTinNguoiDang(string idNguoiDang)
        {
            try
            {
                List<List<string>> listThongTinNguoiDang = danhGiaNguoiDungDao.LoadThongTinNguoiDang(idNguoiDang);
                itemsControlDSDanhGia.Items.Clear();
                foreach(var list in listThongTinNguoiDang)
                {
                    txtHoTen.Text = list[0];
                    txtSoDienThoai.Text = list[1];
                    txtEmail.Text = list[2];
                    txtDiaChi.Text = list[3];
                    imgNguoiDang.Source = new BitmapImage(new Uri(XuLyAnh.layDuongDanDayDuToiFileAnhDaiDien(list[4])));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDSDanhGia(string idNguoiDang)
        {
            try
            {
                List<List<string>> listDanhSachDanhGia = danhGiaNguoiDungDao.LoadDanhSachDanhGia(idNguoiDang);
                itemsControlDSDanhGia.Items.Clear();
                foreach(var list in listDanhSachDanhGia)
                {
                    itemsControlDSDanhGia.Items.Add(new {Ten = list[0], SoSao = list[1], NhanXet = list[2], LinkAnhDaiDienNguoiDanhGia = XuLyAnh.layDuongDanDayDuToiFileAnhDaiDien(list[3])}); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

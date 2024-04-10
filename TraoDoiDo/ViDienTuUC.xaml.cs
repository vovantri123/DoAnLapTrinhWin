using MaterialDesignThemes.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TraoDoiDo.Database;
using TraoDoiDo.Models;
using TraoDoiDo.ViewModels;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for ViDienTuUC.xaml
    /// </summary>
    public partial class ViDienTuUC : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        KhachHang nguoiDung = new KhachHang();
        KhacHangDao nguoiDungDao = new KhacHangDao();
        GiaoDich gd;
        GiaoDichDao gdDao = new GiaoDichDao();
        List<string> listTienNap = new List<string>();
        List<string> listTienRut = new List<string>();
        List<List<string>> listGiaoDich = new List<List<string>>();
        public ViDienTuUC()
        {
            InitializeComponent();
        }
        public ViDienTuUC(KhachHang kh)
        {
            InitializeComponent();
            nguoiDung = kh;
            imageHinhDaiDien.Source = new BitmapImage(new Uri(XuLyAnh.layDuongDanDayDuToiFileAnhDaiDien(kh.Anh)));
        }

        private void btnNapTien_Click(object sender, RoutedEventArgs e)
        {
            NapRutTien w = new NapRutTien(nguoiDung);
            w.Show();
        }

        private void btnRutTien_Click(object sender, RoutedEventArgs e)
        {
            NapRutTien w = new NapRutTien(nguoiDung);
            w.txtbTieuDe.Text = "Rút tiền";
            w.txtbTu.Text = "Rút tiền từ";
            w.txtbDen.Text = "Đến ngân hàng";
            w.Show();
        }

        private void UcViDienTU_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                HienThi_GiaoDich();
                string t = nguoiDungDao.TimKiemTienBangId(nguoiDung.Id);
                lblSoDu.Text = t;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void HienThi_GiaoDich()
        {
            try
            {
                listGiaoDich = gdDao.TimKiemGiaoDichBangId(nguoiDung.Id);
                foreach(var list in listGiaoDich)
                {
                    gd = new GiaoDich(list[0], nguoiDung.Id, list[1], list[2], list[3], list[4], list[5]);
                    lsvLichSuGiaoDich.Items.Add(new { Id = gd.Id, Type = gd.LoaiGiaoDich, Money = gd.SoTien, Initial = gd.TuNguonTien, End = gd.DenNguonTien, Date = gd.NgayGiaoDich });
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

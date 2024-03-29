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

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for ViDienTuUC.xaml
    /// </summary>
    public partial class ViDienTuUC : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        KhachHang nguoiDung = new KhachHang();
        GiaoDich gd;
        GiaoDichDao gdDao = new GiaoDichDao();
        List<string> listTienNap = new List<string>();
        List<string> listTienRut = new List<string>();
        public ViDienTuUC()
        {
            InitializeComponent();
        }
        public ViDienTuUC(KhachHang kh)
        {
            InitializeComponent();
            nguoiDung = kh;
            //Loaded += UcViDienTU_Loaded;
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
                string t = tinhTongTien();
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
                conn.Open();
                string sqlStr = $"SELECT IdGiaoDich, loaiGiaoDich,soTien,tuNguonGiaoDich,denNguonGiaoDich,ngayGiaoDich FROM GiaoDich WHERE IdNguoiDung='{nguoiDung.Id}'";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    gd = new GiaoDich(reader.GetInt32(0).ToString(), nguoiDung.Id, reader.GetString(1).ToString(), reader.GetString(2).ToString(), reader.GetString(3).ToString(), reader.GetString(4).ToString(), reader.GetString(5).ToString());
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
        public string tinhTongTien()
        {
            listTienNap = gdDao.TinhTienNguoiDung(gd, "Nạp tiền");
            double tongTienNap = tinhTong(listTienNap);
            listTienRut = gdDao.TinhTienNguoiDung(gd, "Rút tiền");
            double tongTienRut = tinhTong(listTienRut);
            double tongTien = tongTienNap - tongTienRut;
            return tongTien.ToString();
        }
        public double tinhTong(List<string> list)
        {
            double tongTien = 0;
            foreach (string t in list)
            {
                tongTien += Convert.ToDouble(t);
            }
            return tongTien;
        }

    }
}

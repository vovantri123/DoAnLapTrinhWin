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
using static TraoDoiDo.VoucherUC;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for ViDienTuUC.xaml
    /// </summary>
    public partial class ViDienTuUC : UserControl
    { 
        NguoiDung nguoiDung;

        NguoiDungDao nguoiDungDao = new NguoiDungDao(); 
        GiaoDichDao gdDao = new GiaoDichDao(); 
        public ViDienTuUC()
        {
            InitializeComponent();
        }
        public ViDienTuUC(NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
            imageHinhDaiDien.Source = new BitmapImage(new Uri(XuLyAnh.layDuongDanDayDuToiFileAnhDaiDien(nguoiDung.Anh)));
            Loaded += UcViDienTU_Loaded;
        }

        #region Từ con gọi cha 
        public class ThamSoThayDoi : EventArgs
        {
            public string SoTienMoi { get; set; } 
        }
         
        public event EventHandler<ThamSoThayDoi> SuKienGoiChaKhiTienNguoiDungThayDoi;
         
        #endregion

        private void UcViDienTU_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                HienThi_GiaoDich();
                string t = nguoiDungDao.TimKiemTienBangId(nguoiDung.Id);
                decimal tien = Convert.ToDecimal(t);
                txtbSoDu.Text = DinhDangTien(tien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnNapTien_Click(object sender, RoutedEventArgs e)
        {
            NapRutTien f = new NapRutTien(nguoiDung); 

            f.Closed += (s, ev) =>
            {
                UcViDienTU_Loaded(sender, e);
                SuKienGoiChaKhiTienNguoiDungThayDoi?.Invoke(this, new ThamSoThayDoi
                {
                    SoTienMoi = txtbSoDu.Text
                });
            };
            f.ShowDialog();
        }

        private void btnRutTien_Click(object sender, RoutedEventArgs e)
        {
            NapRutTien f = new NapRutTien(nguoiDung);
            f.txtbTieuDe.Text = "Rút tiền";
            f.txtbTu.Text = "Rút tiền từ";
            f.txtbDen.Text = "Đến ngân hàng";

            f.Closed += (s, ev) =>
            {
                UcViDienTU_Loaded(sender, e);
                SuKienGoiChaKhiTienNguoiDungThayDoi?.Invoke(this, new ThamSoThayDoi
                {
                    SoTienMoi = txtbSoDu.Text
                });
            };
            f.ShowDialog(); 
        }
         
        private void HienThi_GiaoDich()
        {
            try
            {
                List<GiaoDich> dsGiaoDich = gdDao.LoadDSGiaoDichTheoIdNguoiDung(nguoiDung.Id);
                foreach(var dong in dsGiaoDich)
                    lsvLichSuGiaoDich.Items.Add(new { Id = dong.Id, Type = dong.LoaiGiaoDich, Money = dong.SoTien, Initial = dong.TuNguonTien, End = dong.DenNguonTien, Date = dong.NgayGiaoDich });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private static string DinhDangTien(decimal t)
        {
            return t.ToString("#,0");
        }
        

    }
}

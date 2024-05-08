using System;
using System.Collections.Generic;
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
using TraoDoiDo.ViewModels;
namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for NapTien.xaml
    /// </summary>
    public partial class NapRutTien : Window
    {
        public double soTienNap = 0;
        public double soTienRut = 0;
        public string nguonTienDen = "";
        public string nguonTienTu = "";
        public string thoiGianGiaoDich = "";

        NguoiDung ngDung = new NguoiDung();
        
        NguoiDungDao ngDungDao = new NguoiDungDao();

        public NapRutTien()
        {
            InitializeComponent();
        }
        
        public NapRutTien(NguoiDung ngDung)
        {
            InitializeComponent();
            this.DataContext = this;
            this.ngDung = ngDung;
        }

        private void FNapRutTien_Loaded(object sender, RoutedEventArgs e)
        {
            if (txtbTieuDe.Text == "Nạp tiền")
            {
                btnRutTien.Visibility = Visibility.Hidden;
                btnNapTien.Visibility = Visibility.Visible;
            }
            else
            {
                btnRutTien.Visibility = Visibility.Visible;
                btnNapTien.Visibility = Visibility.Hidden;
            }
        }

        private void btnNapTien_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
                soTienNap = tinhTien();
                nguonTienTu = chonNguonTien();
                nguonTienDen = "Ví điện tử";
                thoiGianGiaoDich = DateTime.Now.ToString();
                if (GiaoDich.KiemTraHopLe(soTienNap, nguonTienTu))
                {
                    double soTienNguoiDung = Convert.ToDouble(ngDungDao.TimKiemTienBangId(ngDung.Id));
                    double soTienSauNap = soTienNguoiDung + soTienNap;

                    GiaoDich giaoDich = new GiaoDich(null, ngDung.Id, txtbTieuDe.Text, soTienNap.ToString(), nguonTienTu, nguonTienDen, thoiGianGiaoDich);
                    GiaoDichDao giaoDichDao = new GiaoDichDao();
                    giaoDichDao.CapNhatSoTien(soTienSauNap.ToString(), ngDung.Id);
                    giaoDichDao.Them(giaoDich);

                    MessageBox.Show("Nạp tiền thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }  
        }

        private void btnRutTien_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
                soTienRut = tinhTien();
                nguonTienTu = "Ví điện tử";
                nguonTienDen = chonNguonTien();
                thoiGianGiaoDich = DateTime.Now.ToString();
                if (GiaoDich.KiemTraHopLe(soTienRut, nguonTienDen))
                {
                    double soTienNguoiDung = Convert.ToDouble(ngDungDao.TimKiemTienBangId(ngDung.Id));
                    double soTienSauRut = soTienNguoiDung - soTienRut;

                    GiaoDich giaoDich = new GiaoDich(null, ngDung.Id, txtbTieuDe.Text, soTienRut.ToString(), nguonTienTu, nguonTienDen, thoiGianGiaoDich);
                    GiaoDichDao giaoDichDao = new GiaoDichDao();
                    giaoDichDao.CapNhatSoTien(soTienSauRut.ToString(), ngDung.Id);
                    giaoDichDao.Them(giaoDich);

                    MessageBox.Show("Rút tiền thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                         
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);
            } 
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rbtn = (RadioButton)sender;
            txtGiaTien.Text = rbtn.Content.ToString();
        }
          
        public double tinhTien()
        {
            double soTien = 0;  
            soTien += Convert.ToDouble(txtGiaTien.Text.Replace(",", "")); 
            return soTien;
        }
        public string chonNguonTien()
        {
            string nguonTien = "";
            if (rbtnBIDV.IsChecked == true)
                nguonTien = "BIDV";
            if (rbtnSacombank.IsChecked == true)
                nguonTien = "Sacombank";
            if (rbtnACB.IsChecked == true)
                nguonTien = "ACB";
            if (rbtnTPBank.IsChecked == true)
                nguonTien = "TPBank";
            if (rbtnTechcombank.IsChecked == true)
                nguonTien = "Techcombank";
            if (rbtnViettin.IsChecked == true)
                nguonTien = "Viettin Bank";
            if (rbtnVietcombank.IsChecked == true)
                nguonTien = "Vietcombank";
            if (rbtnVIB.IsChecked == true)
                nguonTien = "VIB Bank";
            if (rbtnVPBank.IsChecked == true)
                nguonTien = "VPBank"; 
            if (rbtnAgribank.IsChecked == true)
                nguonTien = "Agribank";
            if (rbtnBaoViet.IsChecked == true)
                nguonTien = "BAOVIET Bank";
            if (rbtnVietA.IsChecked == true)
                nguonTien = "VietA";
            return nguonTien;
        }
    }
}

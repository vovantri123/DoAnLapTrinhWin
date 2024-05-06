using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using TraoDoiDo.Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TraoDoiDo.Views.QuanLy
{
    /// <summary>
    /// Interaction logic for TabQuanLyNguoiDungUC.xaml
    /// </summary>
    public partial class TabQuanLyNguoiDungUC : UserControl
    {
        TaiKhoanDao tkDao = new TaiKhoanDao();
        NguoiDungDao nguoiDungDao = new NguoiDungDao();
        NguoiDungDao ngDungDao = new NguoiDungDao();
        List<NguoiDung> listNguoiDung = new List<NguoiDung>();
        List<NguoiDung> dsNguoiDung = new List<NguoiDung>();
        DanhGiaNguoiDangDao danhGiaDao = new DanhGiaNguoiDangDao();
        NguoiDung nguoiDung;
        public TabQuanLyNguoiDungUC()
        {
            InitializeComponent();
        }
        public TabQuanLyNguoiDungUC(NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
            Loaded += FQuanLyNguoiDung_Loaded;
        }
        private void HienThi_QuanLyNguoiDung()
        {
            try
            {
                lsvQuanLyNguoiDung.Items.Clear();
                dsNguoiDung = ngDungDao.LoadNguoiDung();
                foreach (var nguoiDung in dsNguoiDung)
                {

                    listNguoiDung.Add(nguoiDung);
                    lsvQuanLyNguoiDung.Items.Add(new { UserId = nguoiDung.Id, FullName = nguoiDung.HoTen, Identification = nguoiDung.Cmnd, Gender = nguoiDung.GioiTinh, PhoneNumber = nguoiDung.Sdt, DateOfBirth = nguoiDung.NgaySinh, Address = nguoiDung.DiaChi, Email = nguoiDung.Email });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Tab Quản lý người dùng


        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            
            ListViewItem item = HoTroTimPhanTu.FindAncestor<ListViewItem>(btn);

            if (item != null)
            {
                dynamic dataItem = item.DataContext;
                int index = lsvQuanLyNguoiDung.Items.IndexOf(dataItem);
                ThongTinNguoiDang f = new ThongTinNguoiDang(listNguoiDung[index].Id);
                f.Show();
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ListViewItem item = HoTroTimPhanTu.FindAncestor<ListViewItem>(btn);
            if (item != null)
            {
                dynamic dataItem = item.DataContext;
                if (dataItem != null)
                {
                    if (MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            ngDungDao.Xoa(dataItem.Id);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xảy ra khi xóa người dùng: " + ex.Message);
                        }
                        try
                        {
                            tkDao.Xoa(dataItem.Id);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xảy ra khi xóa người dùng: " + ex.Message);
                        }
                    }
                }
            }

        }
        private void btnXemDoanhThu_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ListViewItem item = HoTroTimPhanTu.FindAncestor<ListViewItem>(btn);
            if (item != null)
            {
                dynamic dataItem = item.DataContext;
                if (dataItem != null)
                {
                    
                    NguoiDung ngDung = new NguoiDung(dataItem.UserId,dataItem.FullName,dataItem.Gender,dataItem.DateOfBirth,dataItem.Identification,dataItem.Email,dataItem.PhoneNumber,dataItem.Address,null,null,null);
                    QuanLyDoanhThuNguoiDung f = new QuanLyDoanhThuNguoiDung(ngDung);
                    f.Show();
                    
                }
            }

        }


        


       
        private void HienThiNguoiDangUyTien(string soSaoDau, string soSaoCuoi)
        {
            List<DanhGiaNguoiDang> dsDanhGiaSoSao = danhGiaDao.TinhTrungBinhSoSao(soSaoDau, soSaoCuoi);
            foreach (var danhGia in dsDanhGiaSoSao)
            {
                NguoiDung nguoiDung = danhGiaDao.LoadThongTinNguoiDang(danhGia.IdNguoiDang);
                lsvQuanLyNguoiDung.Items.Add(new { UserId = nguoiDung.Id, FullName = nguoiDung.HoTen, Identification = nguoiDung.Cmnd, Gender = nguoiDung.GioiTinh, PhoneNumber = nguoiDung.Sdt, DateOfBirth = nguoiDung.NgaySinh, Address = nguoiDung.DiaChi, SoSao=danhGia.SoSao,Email = nguoiDung.Email });
            }
        }


        private void cbNgayMua_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbSoSao_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            try
            {
                lsvQuanLyNguoiDung.Items.Clear();
                string selectedItemContent = (comboBox.SelectedItem as ComboBoxItem).Content.ToString().Trim();
                if (string.Equals(selectedItemContent, "Tất cả"))
                    HienThi_QuanLyNguoiDung();
                else if (string.Equals(selectedItemContent, "Số sao từ 0 đến 2"))
                    HienThiNguoiDangUyTien("0", "2");
                else
                {
                    HienThiNguoiDangUyTien("3", "5");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txbTimKiemNguoiDung_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                lsvQuanLyNguoiDung.Items.Clear();
                if (string.IsNullOrEmpty(txbTimKiemNguoiDung.Text))
                    HienThi_QuanLyNguoiDung();
                else
                {
                    NguoiDung nguoiDung = ngDungDao.TimKiemBangId(txbTimKiemNguoiDung.Text.Trim());
                    if(nguoiDung!=null)
                        lsvQuanLyNguoiDung.Items.Add(new { UserId = nguoiDung.Id, FullName = nguoiDung.HoTen, Identification = nguoiDung.Cmnd, Gender = nguoiDung.GioiTinh, PhoneNumber = nguoiDung.Sdt, DateOfBirth = nguoiDung.NgaySinh, Address = nguoiDung.DiaChi, Email = nguoiDung.Email });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FQuanLyNguoiDung_Loaded(object sender, RoutedEventArgs e)
        {
            HienThi_QuanLyNguoiDung();
        }
    }
}

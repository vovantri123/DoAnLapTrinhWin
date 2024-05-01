﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TraoDoiDo.Database;
using TraoDoiDo.Models;
using TraoDoiDo.ViewModels;

namespace TraoDoiDo.Views.MuaDo
{
    /// <summary>
    /// Interaction logic for TabMuaSamUC.xaml
    /// </summary>
    public partial class TabMuaSamUC : UserControl
    {
        private int soLuongSP = 0;
        private SanPhamUC[] DanhSachSanPham = new SanPhamUC[100];
        List<TrangThaiDonHang> dsSanPhamDeThanhToan = new List<TrangThaiDonHang>();

        NguoiDung ngMua;

        SanPhamDao sanPhamDao = new SanPhamDao();
        GioHangDao gioHangDao = new GioHangDao();
        NguoiDungDao ngDungDao = new NguoiDungDao();
        TrangThaiDonHangDao trangThaiDonHangDao = new TrangThaiDonHangDao();
        QuanLyDonHangDao quanLyDonHangDao = new QuanLyDonHangDao();
        VoucherDao voucherDao = new VoucherDao();
        public TabMuaSamUC()
        {
            InitializeComponent();
        }
        public TabMuaSamUC(NguoiDung ngMua)
        {
            InitializeComponent();
            this.ngMua = ngMua;
            Loaded += MuaSam_Load;
        }

        private void MuaSam_Load(object sender, RoutedEventArgs e)
        {
            LoadDanhSachSanPham();  
            SapXepTheoGanDay();
        }

        private void LoadDanhSachSanPham() //Load dữ liệu lên cái mảng DangSachSanPham
        {
            soLuongSP = 0;
            try
            {
                List<SanPham> dsSanPham = sanPhamDao.LoadSanPham(ngMua.Id);

                foreach (var dong in dsSanPham)
                {
                    int yeuThich = 0;

                    if (!string.IsNullOrEmpty(dong.IdNguoiMua)) // Id người mua này của bảng yêu thích ,Neu nguoi mua co trong bang yeu thich (tức đang yêu thich một sản phẩm nào đó)
                    {
                        yeuThich = 1;
                    }

                    DanhSachSanPham[soLuongSP] = new SanPhamUC(yeuThich, ngMua.Id); // Khởi tạo mỗi phần tử của mảng (KHÔNG CÓ LÀ LỖI)

                    DanhSachSanPham[soLuongSP].txtbIdSanPham.Text = dong.Id;
                    DanhSachSanPham[soLuongSP].txtbTen.Text = dong.Ten;

                    string tenFileAnh = dong.LinkAnh;
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    string duongDanhAnh = XuLyAnh.layDuongDanDayDuToiFileAnhSanPham(tenFileAnh);
                    bitmap.UriSource = new Uri(duongDanhAnh);
                    bitmap.EndInit();
                    DanhSachSanPham[soLuongSP].imgSP.Source = bitmap;

                    DanhSachSanPham[soLuongSP].txtbGiaGoc.Text = dong.GiaGoc;
                    DanhSachSanPham[soLuongSP].txtbGiaBan.Text = dong.GiaBan;
                    DanhSachSanPham[soLuongSP].txtbNoiBan.Text = dong.NoiBan;
                    DanhSachSanPham[soLuongSP].txtbSoLuotXem.Text = dong.LuotXem;
                    DanhSachSanPham[soLuongSP].idNguoiDang = dong.IdNguoiDang;
                    DanhSachSanPham[soLuongSP].txtbLoai.Text = dong.Loai;

                    soLuongSP++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
          
        private void cboSapXep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedItem != null)
            {
                string mucDuocChon = (comboBox.SelectedItem as ComboBoxItem).Content.ToString(); 
                
                if (mucDuocChon == "Giá tăng dần")
                    SapXepTheoGiaTangDan();
                else if (mucDuocChon == "Giá giảm dần")
                    SapXepTheoGiaGiamDan();
                else if (mucDuocChon == "Lượt xem tăng dần")
                    SapXepTangDanTheoSoLuotXem();
                else if (mucDuocChon == "Lượt xem giảm dần")
                    SapXepGiamDanTheoSoLuotXem();
                else if (mucDuocChon == "Yêu thích của tôi")
                    SapXeoTheoYeuThich();
                else //"Tất cả"
                    SapXepTheoGanDay();
            }
        }

        private void LoadToanBoDanhSachSanPhamLenWpnlHienThi()
        {
            for (int i = 0; i < soLuongSP; i++)
                wpnlHienThi.Children.Add(DanhSachSanPham[i]);
        }

        private void HoanDoi(ref SanPhamUC sp1, ref SanPhamUC sp2)
        {
            SanPhamUC spTam = sp1;
            sp1 = sp2;
            sp2 = spTam;
        }

        private void SapXepTheoGiaTangDan()
        {
            wpnlHienThi.Children.Clear();
            for (int i = 0; i < soLuongSP - 1; i++)
                for (int j = i + 1; j < soLuongSP; j++)
                    if (Convert.ToInt32(DanhSachSanPham[i].txtbGiaBan.Text) > Convert.ToInt32(DanhSachSanPham[j].txtbGiaBan.Text))
                        HoanDoi(ref DanhSachSanPham[i], ref DanhSachSanPham[j]);

            LoadToanBoDanhSachSanPhamLenWpnlHienThi();
        }

        private void SapXepTheoGiaGiamDan()
        { 
            wpnlHienThi.Children.Clear();
            for (int i = 0; i < soLuongSP - 1; i++)
                for (int j = i + 1; j < soLuongSP; j++)
                    if (Convert.ToInt32(DanhSachSanPham[i].txtbGiaBan.Text) < Convert.ToInt32(DanhSachSanPham[j].txtbGiaBan.Text))
                        HoanDoi(ref DanhSachSanPham[i], ref DanhSachSanPham[j]);

            LoadToanBoDanhSachSanPhamLenWpnlHienThi();
        } 
        
        private void SapXepGiamDanTheoSoLuotXem()
        { 
            wpnlHienThi.Children.Clear();
            for (int i = 0; i < soLuongSP - 1; i++)
                for (int j = i + 1; j < soLuongSP; j++)
                    if (Convert.ToInt32(DanhSachSanPham[i].txtbSoLuotXem.Text) < Convert.ToInt32(DanhSachSanPham[j].txtbSoLuotXem.Text))
                        HoanDoi(ref DanhSachSanPham[i], ref DanhSachSanPham[j]);

            LoadToanBoDanhSachSanPhamLenWpnlHienThi();
        }

        private void SapXepTangDanTheoSoLuotXem()
        { 
            wpnlHienThi.Children.Clear();
            for (int i = 0; i < soLuongSP - 1; i++)
                for (int j = i + 1; j < soLuongSP; j++)
                    if (Convert.ToInt32(DanhSachSanPham[i].txtbSoLuotXem.Text) > Convert.ToInt32(DanhSachSanPham[j].txtbSoLuotXem.Text))
                        HoanDoi(ref DanhSachSanPham[i], ref DanhSachSanPham[j]);

            LoadToanBoDanhSachSanPhamLenWpnlHienThi();
        }

        private void SapXeoTheoYeuThich()
        {
            wpnlHienThi.Children.Clear();
            for (int i = 0; i < soLuongSP; i++)
                if (DanhSachSanPham[i].yeuThich == 1)
                    wpnlHienThi.Children.Add(DanhSachSanPham[i]);
            for (int i = 0; i < soLuongSP; i++)
                if (DanhSachSanPham[i].yeuThich == 0)
                    wpnlHienThi.Children.Add(DanhSachSanPham[i]);
        }

        private void SapXepTheoGanDay()
        {
            try
            {
                wpnlHienThi.Children.Clear();
                string tuKhoaSanPhamDangQuanTam = ngDungDao.TimKiemTuKhoaSanPhamDangQuanTamGanDay(ngMua.Id).Trim().ToLower();
                for (int i = 0; i < soLuongSP; i++)
                    if (DanhSachSanPham[i].txtbTen.Text.Trim().ToLower().Contains(tuKhoaSanPhamDangQuanTam))
                        wpnlHienThi.Children.Add(DanhSachSanPham[i]);

                for (int i = 0; i < soLuongSP; i++)
                    if (!DanhSachSanPham[i].txtbTen.Text.Trim().ToLower().Contains(tuKhoaSanPhamDangQuanTam))
                        wpnlHienThi.Children.Add(DanhSachSanPham[i]);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXacNhanTimKiem_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                wpnlHienThi.Children.Clear();
                if (txbTimKiem.Text.Trim() != "")
                {
                    wpnlHienThi.Children.Clear();
                    for (int i = 0; i < soLuongSP; i++)
                    {
                        string tenSP = DanhSachSanPham[i].txtbTen.Text.Trim().ToLower();
                        string timKiem = txbTimKiem.Text.Trim().ToLower();
                        if (tenSP.Contains(timKiem))
                            wpnlHienThi.Children.Add(DanhSachSanPham[i]);
                        ngDungDao.CapNhatTuKhoaSanPhamDangQuanTam(ngMua, timKiem);
                    } 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void txbTimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {  
            if (txbTimKiem.Text.Trim() == "")
            {
                wpnlHienThi.Children.Clear();
                SapXepTheoGanDay();
            } 
        }
         
        private void cboLocTheoLoai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedItem != null)
            {
                string selectedItemContent = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();
                if (selectedItemContent == "Tất cả")
                    SapXepTheoGanDay();
                else
                {
                    wpnlHienThi.Children.Clear();
                    for (int i = 0; i < soLuongSP; i++)
                        if (DanhSachSanPham[i].txtbLoai.Text.Contains(selectedItemContent))
                            wpnlHienThi.Children.Add(DanhSachSanPham[i]);
                }
            }
        } 
    }
}
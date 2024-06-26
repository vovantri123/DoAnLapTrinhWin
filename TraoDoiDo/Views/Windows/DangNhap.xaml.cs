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
using System.Windows.Shapes;
using TraoDoiDo.Database;
using TraoDoiDo.Models;
using TraoDoiDo.ViewModels;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    { 
        NguoiDungDao nguoiDao = new NguoiDungDao();

        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            TaiKhoan taiKhoan = new TaiKhoan(txtTenDangNhap.Text, txtMatKhau.Password.ToString(), null); 
            NguoiDung nguoi = nguoiDao.TimKiemNguoiBangTenDangNhap(taiKhoan.TenDangNhap, taiKhoan.MatKhau); // Tuy trả về thông tin người dùng nhưng thiếu cái (idNguoi, TaiKhoan ; tiền)
             
            if (nguoi == null)
            {
                MessageBox.Show("Tài khoản sai! Vui lòng đăng nhập lại");
                return;
            }
            else
            {
                this.Hide();
                MainWindow f = new MainWindow(nguoi);
                f.ShowDialog();
            }
        }

        private void btnDangKy_Click(object sender, RoutedEventArgs e)
        {
            DangKy dangKy = new DangKy();
            dangKy.ShowDialog();
        }

        private void txtbQuenMatKhau_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            QuenMatKhau quenMK = new QuenMatKhau();
            quenMK.ShowDialog();
        }

        private void btnDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for QuanLy.xaml
    /// </summary>
    public partial class QuanLyUC : UserControl
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Anh { get; set; }
            public string Type { get; set; }
            public int Quantity { get; set; }
            public int DaBan { get; set; }
            public decimal Price { get; set; }
            public string Promotion { get; set; }
            public decimal ShippingFee { get; set; }
            public int SoSao { get; set; }
            public string TrangThai { get; set; } //0 là chưa duyệt, còn 1 là đã duyệt
        }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public QuanLyUC()
        {
            InitializeComponent();
            DataContext = this; // Đặt DataContext của trang là chính trang đó

            // Khởi tạo danh sách sản phẩm
            Products = new ObservableCollection<Product>();
            Products.Add(new Product { Id = 1, Name = "Sản phẩm 1", Anh = "/HinhCuaToi/Lenovo.png", Type = "Type 1", Quantity = 10, DaBan = 5, Price = 100000, Promotion = "10%", ShippingFee = 5000, SoSao = 4, TrangThai = "0" });
            Products.Add(new Product { Id = 2, Name = "Sản phẩm 2", Anh = "/HinhCuaToi/Lenovo.png", Type = "Type 2", Quantity = 20, DaBan = 10, Price = 200000, Promotion = "20%", ShippingFee = 10000, SoSao = 3, TrangThai = "1" });

            // Gán danh sách sản phẩm vào ItemsSource của ListView
            lsvQuanLySanPham.ItemsSource = Products;

            Users = new ObservableCollection<User>();
            // Thêm dữ liệu mẫu vào Users (có thể thay thế bằng dữ liệu từ cơ sở dữ liệu hoặc nguồn dữ liệu khác)
            Users.Add(new User { UserId = "1", FullName = "John Doe",  Identification = "123456789", Gender = "Male", PhoneNumber = "1234567890", DateOfBirth = "16/10/2004", Address = "123 Street, City", Email = "john@example.com", Promotion = "VIP", ShippingFee = 10.5 });
            Users.Add(new User { UserId = "2", FullName = "Jane Doe", Identification = "987654321", Gender = "Female", PhoneNumber = "0987654321", DateOfBirth = "23/1/2004", Address = "456 Avenue, Town", Email = "jane@example.com", Promotion = "Regular", ShippingFee = 8.75 });
            // Đặt nguồn dữ liệu cho ListView
            lsvQuanLyNguoiDung.ItemsSource = Users;

        }


        //Tab Quản lý người dùng

        public class User
        {
            public string UserId { get; set; }
            public string FullName { get; set; }
            public string Identification { get; set; }
            public string Gender { get; set; }
            public string PhoneNumber { get; set; }
            public string DateOfBirth { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
            public string Promotion { get; set; }
            public double ShippingFee { get; set; }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DangKy f = new DangKy();
            f.txtbTieuDe.Text = "Thông tin người dùng";
            f.btnDangKy.Content = "Cập nhật";
            f.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?","Thông báo",MessageBoxButton.OKCancel,MessageBoxImage.Question);
        }


    }
}
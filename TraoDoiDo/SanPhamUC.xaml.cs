﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for UCSanPham.xaml
    /// </summary>
    public partial class SanPhamUC : UserControl
    {
        public SanPhamUC()
        {
            InitializeComponent();
        }

        private void btnThongTin_Click(object sender, RoutedEventArgs e)
        {
            ThongTinChiTietSanPham f = new ThongTinChiTietSanPham();
            f.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            f.idSanPham = txtbIdSanPham.Text;
            f.ShowDialog();
        }
    }
}

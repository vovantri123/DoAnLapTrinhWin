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
using TraoDoiDo.ViewModels;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        ThongTinKhachHangViewModel ttkh = new ThongTinKhachHangViewModel();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            NguoiDung f = new NguoiDung();
            f.Show();
        }

        private void btnDangKy_Click(object sender, RoutedEventArgs e)
        {
            DangKy dangKy = new DangKy(ttkh);
            dangKy.Show();
        }

        private void btnQuenMatKhau_Click(object sender, RoutedEventArgs e)
        {

        }
        private void txtQuenMatKhau_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            QuenMatKhau quenMK = new QuenMatKhau();
            quenMK.Show();
        }
    }
}

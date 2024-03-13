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

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for ThongTinChiTietSanPham.xaml
    /// </summary>
    public partial class ThongTinChiTietSanPham : Window
    {
        public ThongTinChiTietSanPham()
        {
            InitializeComponent();
        }

        private void btnThemVaoGioHang_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thêm vào giỏ hàng thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

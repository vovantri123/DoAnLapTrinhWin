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
    /// Interaction logic for DiaChiNhanHang.xaml
    /// </summary>
    public partial class DiaChi : Window
    {
        public DiaChi()
        {
            InitializeComponent();
        }

        private void btnXacNhanThanhToan_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Đã thanh toán thành công\nĐơn hàng đang chờ người bán xác nhận", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

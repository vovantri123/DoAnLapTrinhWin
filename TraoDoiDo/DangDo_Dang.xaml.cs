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
    /// Interaction logic for DangDo_Dang.xaml
    /// </summary>
    public partial class DangDo_Dang : Window
    {
        public DangDo_Dang()
        {
            InitializeComponent();
        }

        private void btnDang_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Đăng thành công\nĐơn hàng đang chờ Admin duyệt", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

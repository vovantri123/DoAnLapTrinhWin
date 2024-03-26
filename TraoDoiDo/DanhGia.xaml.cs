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
    /// Interaction logic for DanhGia.xaml
    /// </summary>
    public partial class DanhGia : Window
    {
        public DanhGia()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cảm ơn bạn đã gửi đánh giá\nChúc bạn một ngày vui :)", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
        }
    }
}

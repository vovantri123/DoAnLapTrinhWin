using MaterialDesignThemes.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for ViDienTuUC.xaml
    /// </summary>
    public partial class ViDienTuUC : UserControl
    {
        public ViDienTuUC()
        {
            InitializeComponent();
        }

        private void btnNapTien_Click(object sender, RoutedEventArgs e)
        {
            NapRutTien w = new NapRutTien();
            w.Show();
        }

        private void btnRutTien_Click(object sender, RoutedEventArgs e)
        {
            NapRutTien w = new NapRutTien();
            w.txtbTieuDe.Text = "Rút tiền";
            w.txtbTu.Text = "Rút tiền từ"; 
            w.txtbDen.Text = "Đến ngân hàng";
            w.Show();
        }
    }
}

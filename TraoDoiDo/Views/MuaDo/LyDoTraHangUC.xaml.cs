using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using TraoDoiDo.Utilities;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for LyDoTraHangUC.xaml
    /// </summary>
    public partial class LyDoTraHangUC : UserControl
    {
        public string idNguoiMua;
        public string idSP;
        public event EventHandler DrawerClosed;
         
        TrangThaiDonHangDao trangThaiDonHangDao = new TrangThaiDonHangDao();
        QuanLyDonHangDao quanLyDonHangDao = new QuanLyDonHangDao();

        public LyDoTraHangUC()
        {
            InitializeComponent();
        }

        private void btnXacNhanTraHang_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
                TrangThaiDonHang trangThaiDonHang = new TrangThaiDonHang(idNguoiMua,idSP,null,null,null,"Đã trả hàng",null, null, null, null);
                trangThaiDonHangDao.CapNhat(trangThaiDonHang);
                QuanLyDonHang quanLyDonHang = new QuanLyDonHang(null, null, idNguoiMua, idSP, "Bị hoàn trả", timLyDoDuocChon());
                quanLyDonHangDao.CapNhatTraHang(quanLyDonHang); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xảy ra khi trả sản phẩm:\n" + ex.Message);
            }
             
            btnXacNhanTraHang.IsEnabled = false; 
            // Tìm DrawerHost gần nhất
            DependencyObject cha = VisualTreeHelper.GetParent(this);
            while (!(cha is DrawerHost))
            {
                cha = VisualTreeHelper.GetParent(cha);
            }

            // Ẩn DrawerHost 
            DrawerHost drawerHost = cha as DrawerHost;
            if (drawerHost != null)
            {
                drawerHost.IsBottomDrawerOpen = false;
                OnDrawerClosed(EventArgs.Empty);
            } 
        }

        protected virtual void OnDrawerClosed(EventArgs e)
        {
            DrawerClosed?.Invoke(this, e);
        }

        private string timLyDoDuocChon()
        {
            // Duyệt qua từng Border trong Grid
            foreach (var border in GridLyDo.Children)
            {
                if (border is Border)
                {
                    var radioButton = HoTroTimPhanTu.FindVisualChild<RadioButton>(border as Border);
                    if (radioButton != null && radioButton.IsChecked == true)
                    { 
                        return radioButton.Content.ToString(); 
                    }
                }
            }
            return "";
        } 
    }
}

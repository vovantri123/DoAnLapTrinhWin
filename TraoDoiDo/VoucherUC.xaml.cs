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

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for Voucher.xaml
    /// </summary>
    public partial class VoucherUC : UserControl
    {
        


        private string idNguoiMua;
        private SqlConnection conn;
        NguoiDungVoucherDao ndvcDao = new NguoiDungVoucherDao();
        public VoucherUC()
        { }
        public VoucherUC(string idNguoiMua, string nhanHayDung)
        { 
            conn = new SqlConnection(Properties.Settings.Default.connStr);
            this.idNguoiMua = idNguoiMua; 
            InitializeComponent();
            if (nhanHayDung.ToLower() == "nhận")
            {
                btnDungVoucher.Visibility = Visibility.Collapsed; 
            }    
            else
            { 
                btnNhanVoucher.Visibility= Visibility.Collapsed;
            }    
        }
        #region TỪ UC con truyền ngược lên UC cha
        // Tạo lớp hoặc cặp tham số mới để đại diện cho cả hai giá trị
        public class TextBlockChangedEventArgs : EventArgs
        {
            public string GiaTriMoi { get; set; }
            public string IdMoi { get; set; }
        }

        // Sự kiện được phát ra khi TextBlock thay đổi
        public event EventHandler<TextBlockChangedEventArgs> TextBlockChanged;

        private void btnDungVoucher_Click(object sender, RoutedEventArgs e)
        {
            // Lấy giá trị từ TextBox và gửi đến form cha
            TextBlockChanged?.Invoke(this, new TextBlockChangedEventArgs
            {
                GiaTriMoi = txtbGiaTri.Text,
                IdMoi = txtbIdVoucher.Text
            });
        }
        #endregion


        private void btnNhanVoucher_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("IDnguoimua" + idNguoiMua + "\nIDVoucher" + txtbIdVoucher.Text); 
            NguoiDungVoucher ndvc = new NguoiDungVoucher(txtbIdVoucher.Text, idNguoiMua);
            ndvcDao.Them(ndvc);  
        }

       
    }
}

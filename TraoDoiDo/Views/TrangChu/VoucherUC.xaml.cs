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
        
        NguoiDungVoucherDao ndvcDao = new NguoiDungVoucherDao();

        public VoucherUC()
        {
            InitializeComponent();
        }

        public VoucherUC(string idNguoiMua)
        {
            InitializeComponent(); 
            this.idNguoiMua = idNguoiMua;  
        }

        #region Từ con gọi cha
        // Tạo lớp hoặc cặp tham số mới để đại diện cho cả hai giá trị
        public class ThamSoThayDoi : EventArgs
        {
            public string GiaTriMoi { get; set; }
            public string IdMoi { get; set; }
        }

        // Sự kiện cho phép thay đổi giá trị textBlock của cha (kèm theo gọi hàm của cha)
        public event EventHandler<ThamSoThayDoi> SuKienGoiChaKhiClickVaoDungVoucher;

        private void btnDungVoucher_Click(object sender, RoutedEventArgs e)
        {
            // Lấy giá trị từ textblock bên voucher và gửi đến form cha là TabGioHangUC
            SuKienGoiChaKhiClickVaoDungVoucher?.Invoke(this, new ThamSoThayDoi
            {
                GiaTriMoi = txtbGiaTri.Text,
                IdMoi = txtbIdVoucher.Text
            });
        }
        #endregion
         
        private void btnNhanVoucher_Click(object sender, RoutedEventArgs e)
        {
            NguoiDungVoucher ndvc = new NguoiDungVoucher(txtbIdVoucher.Text, idNguoiMua);
            ndvcDao.Xoa(ndvc);
            ndvcDao.Them(ndvc);
            MessageBox.Show("Bạn đã nhận được voucher");
        } 
    }
}

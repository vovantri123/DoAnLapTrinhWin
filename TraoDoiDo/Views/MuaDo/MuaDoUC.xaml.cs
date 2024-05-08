using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TraoDoiDo.Models;
using TraoDoiDo.ViewModels;
using TraoDoiDo.Database;
using System.Xml.Linq;
using TraoDoiDo.Views.DangDo;
using TraoDoiDo.Views.MuaDo;
using TraoDoiDo.Views.Windows;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for MuaDo.xaml
    /// </summary>
    public partial class MuaDoUC : UserControl
    {  

        public MuaDoUC()
        {
            InitializeComponent();  
        } 

        public MuaDoUC(NguoiDung nguoi)
        {
            InitializeComponent();   
            txbTienNguoiDung.Text = nguoi.Tien;

            ccTabMuaSam.Content = new TabMuaSamUC(nguoi);


            TabGioHangUC gh = new TabGioHangUC(nguoi);
            gh.SuKien_TabGioHang_GoiChaKhiTienNguoiDungThayDoi += MuaDoUC_TabGioHangGoi;
            ccTabGioHang.Content = gh;

            TabTrangThaiDonHangUC tt = new TabTrangThaiDonHangUC(nguoi);
            tt.SuKien_TabTrangThaiDonHang_GoiChaKhiTienNguoiDungThayDoi += MuaDoUC_TabTrangThaiGoi;
            ccTabTrangThaiDonHang.Content = tt;
        }

        private void MuaDoUC_TabGioHangGoi(object sender, TabGioHangUC.ThamSoThayDoi e)
        {
            txbTienNguoiDung.Text = e.SoTienMoi;
        }

        private void MuaDoUC_TabTrangThaiGoi(object sender, TabTrangThaiDonHangUC.ThamSoThayDoi e)
        {
            txbTienNguoiDung.Text = e.SoTienMoi;
        }

        #region Từ MuaDoUC gọi cha là MainWindow 
        public class ThamSoThayDoi : EventArgs
        {
            public string SoTienMoi { get; set; }
        }

        public event EventHandler<ThamSoThayDoi> SuKienGoiChaKhiTienNguoiDungThayDoi;

        private void txbTienNguoiDung_TextChanged(object sender, TextChangedEventArgs e)
        {
            SuKienGoiChaKhiTienNguoiDungThayDoi?.Invoke(this, new ThamSoThayDoi
            {
                SoTienMoi = txbTienNguoiDung.Text
            });
        }
        #endregion


    }
}

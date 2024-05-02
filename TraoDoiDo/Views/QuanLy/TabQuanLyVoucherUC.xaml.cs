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
using TraoDoiDo.Database;
using TraoDoiDo.Models;
using TraoDoiDo.Utilities;

namespace TraoDoiDo.Views.QuanLy
{
    /// <summary>
    /// Interaction logic for TabQuanLyVoucherUC.xaml
    /// </summary>
    public partial class TabQuanLyVoucherUC : UserControl
    {
        VoucherDao voucherDao = new VoucherDao();
        NguoiDungVoucherDao ndvcDao = new NguoiDungVoucherDao();
        NguoiDung nguoiDung;
        public TabQuanLyVoucherUC()
        {
            InitializeComponent();
        }public TabQuanLyVoucherUC(NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
            Loaded += FQuanLyVoucher_Loaded;
        }
        

        private void LoadDanhSachVoucer()
        {
            try
            {
                List<Voucher> dsVoucher = voucherDao.LoadVoucher();
                lsvQLVoucher.ItemsSource = dsVoucher;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void lsvQLVoucher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (lsvQLVoucher.SelectedItem != null)
            {
                // Lấy dữ liệu của dòng được chọn
                Voucher dongDuocChon = lsvQLVoucher.SelectedItem as Voucher; // Thay YourDataModel bằng kiểu dữ liệu thực tế của bạn

                if (dongDuocChon != null)
                {
                    txtbIdVoucher.Text = dongDuocChon.IdVoucher;
                    txtbTenVoucher.Text = dongDuocChon.TenVoucher;
                    txtbGiaTri.Text = dongDuocChon.GiaTri;
                    dtpNgayBatDau.SelectedDate = DateTime.Parse(dongDuocChon.NgayBatDau);
                    dtpNgayKetThuc.SelectedDate = DateTime.Parse(dongDuocChon.NgayKetThuc);
                    ucTangGiamSoLuotSuDungToiDa.txtbSoLuong.Text = dongDuocChon.SoLuotSuDungToiDa;
                    ucTangGiamSoLuotDaSuDung.txtbSoLuong.Text = dongDuocChon.SoLuotDaSuDung;
                }
            }
        }
        private void btnDangVoucher_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng ?", "Xác nhận đăng", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Voucher voucher = new Voucher("1", txtbTenVoucher.Text, txtbGiaTri.Text, ucTangGiamSoLuotSuDungToiDa.txtbSoLuong.Text, ucTangGiamSoLuotDaSuDung.txtbSoLuong.Text, dtpNgayBatDau.Text, dtpNgayKetThuc.Text);
                if (voucher.kiemTraCacTextBox())
                {
                    try
                    {
                        voucherDao.Them(voucher);

                        // Load lại tab QL Voucher
                        FQuanLyVoucher_Loaded(sender, e);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xảy ra khi đăng sản phẩm: " + ex.Message);
                    }
                }

            }
        }
        private void btnSuaVoucher_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn sửa mục đã chọn?", "Xác nhận sửa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Voucher voucher = new Voucher(txtbIdVoucher.Text, txtbTenVoucher.Text, txtbGiaTri.Text, ucTangGiamSoLuotSuDungToiDa.txtbSoLuong.Text, ucTangGiamSoLuotDaSuDung.txtbSoLuong.Text, dtpNgayBatDau.Text, dtpNgayKetThuc.Text);
                if (voucher.kiemTraCacTextBox())
                {
                    try
                    {
                        voucherDao.Sua(voucher);

                        // Load lại tab QL Voucher
                        FQuanLyVoucher_Loaded(sender, e);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xảy ra khi đăng sản phẩm: " + ex.Message);
                    }
                }
            }
        }

        private void btnXoaVoucher_Click(object sender, RoutedEventArgs e) // truy vấn id trên lsv sẽ hiệu quả hơn thay vì lấy id từ textblock , từ đó ta có thể đặt thuộc tính isReadOnly thành True
        {
            // Lấy button được click
            Button btn = sender as Button;
            // Lấy ListViewItem chứa button
            
            ListViewItem item = HoTroTimPhanTu.FindAncestor<ListViewItem>(btn);

            if (item != null)
            {
                // Lấy dữ liệu của ListViewItem
                dynamic dataItem = item.DataContext;

                if (dataItem != null)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa mục đã chọn?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            string idVoucher = dataItem.IdVoucher;
                            // Xóa dữ liệu từ bảng SanPham
                            ndvcDao.XoaTheoIdVoucher(idVoucher);
                            voucherDao.XoaVoucherTheoIdVoucher(idVoucher);
                            // Load lại tab QL Voucher
                            FQuanLyVoucher_Loaded(sender, e);


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xảy ra khi xóa sản phẩm: " + ex.Message);
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Không thể xác định dòng chứa nút 'Xóa'.");
            }
        }

        private void FQuanLyVoucher_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDanhSachVoucer();   
        }
    }
}

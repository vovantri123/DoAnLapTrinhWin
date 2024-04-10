using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TraoDoiDo.Database;
using TraoDoiDo.Models;
using TraoDoiDo.ViewModels;

namespace TraoDoiDo
{

    public partial class DangDoUC : UserControl
    {

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        KhachHang nguoiDung = new KhachHang();
        List<List<string>> listSanPham = new List<List<string>>();
        SanPhamDao sanPhamDao = new SanPhamDao();
        MoTaHangHoaDao moTaDao = new MoTaHangHoaDao();
        QuanLyDonHangDao quanLyDao = new QuanLyDonHangDao();
        TrangThaiDonHangDao trangThaiHangDao = new TrangThaiDonHangDao();
        DanhGiaNguoiDungDao danhGiaNguoiDungDao = new DanhGiaNguoiDungDao();

        public DangDoUC()
        {
            InitializeComponent();
            Loaded += QuanLySanPham_Load;
            Loaded += QuanLyDonHang_Load;
            Loaded += ThongKe_Load;
        }

        public DangDoUC(KhachHang kh)
        {
            InitializeComponent();
            Loaded += QuanLySanPham_Load;
            Loaded += QuanLyDonHang_Load;
            Loaded += ThongKe_Load;
            nguoiDung = kh;
        }
        #region TAB1 QUẢN LÝ SẢN PHẨM
        private void QuanLySanPham_Load(object sender, RoutedEventArgs e) //Form load của Tab1
        {
            HienThi_QuanLySanPham();
        }
        private void txbTiemKiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                lsvQuanLySanPham.Items.Clear();
                List<List<string>> listSP = new List<List<string>>();
                if (txbTimKiem.Text == null)
                    HienThi_QuanLySanPham();
                listSP = sanPhamDao.timKiemBangTen(txbTimKiem.Text.Trim(), nguoiDung.Id);
                foreach (var list in listSP)
                {
                    SanPham sanPham = new SanPham(list[0], nguoiDung.Id, list[1], list[2], list[3], list[4], list[5], list[6], list[7], list[8], list[9], null, null, null, null, null,"0");
                    string tenAnh = XuLyAnh.layDuongDanDayDuToiFileAnh(sanPham.LinkAnh);
                    lsvQuanLySanPham.Items.Add(new { Id = sanPham.Id.ToString(), Ten = sanPham.Ten.ToString(), LinkAnh = tenAnh, Loai = sanPham.Loai.ToString(), SoLuong = sanPham.SoLuong.ToString(), SoLuongDaBan = sanPham.SoLuongDaBan.ToString(), GiaGoc = sanPham.GiaGoc.ToString(), GiaBan = sanPham.GiaBan.ToString(), PhiShip = sanPham.PhiShip.ToString() });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cbLocLoai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
           
            try
            {
                lsvQuanLySanPham.Items.Clear();
                List<List<string>> listSP = new List<List<string>>();
                string selectedItemContent = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();
                if (string.Equals(selectedItemContent, "Tất cả"))
                    HienThi_QuanLySanPham();
                else
                {
                    listSP = sanPhamDao.timKiemBangLoai(selectedItemContent, nguoiDung.Id);
                    foreach (var list in listSP)
                    {
                        SanPham sanPham = new SanPham(list[0], nguoiDung.Id, list[1], list[2], list[3], list[4], list[5], list[6], list[7], list[8], list[9], null, null, null, null, null,"0");
                        string tenAnh = XuLyAnh.layDuongDanDayDuToiFileAnh(sanPham.LinkAnh);
                        lsvQuanLySanPham.Items.Add(new { Id = sanPham.Id.ToString(), Ten = sanPham.Ten.ToString(), LinkAnh = tenAnh, Loai = sanPham.Loai.ToString(), SoLuong = sanPham.SoLuong.ToString(), SoLuongDaBan = sanPham.SoLuongDaBan.ToString(), GiaGoc = sanPham.GiaGoc.ToString(), GiaBan = sanPham.GiaBan.ToString(), PhiShip = sanPham.PhiShip.ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       
        
        private void HienThi_QuanLySanPham()
        {

            lsvQuanLySanPham.Items.Clear();
            listSanPham = sanPhamDao.timKiemBangId(nguoiDung.Id.ToString());
            foreach (var list in listSanPham)
            {

                SanPham sanPham = new SanPham(list[0], nguoiDung.Id, list[1], list[2], list[3], list[4], list[5], list[6], list[7], list[8], list[9], null, null, null, null, null,"0");
                string tenAnh = XuLyAnh.layDuongDanDayDuToiFileAnh(sanPham.LinkAnh);
                lsvQuanLySanPham.Items.Add(new { Id = sanPham.Id.ToString(), Ten = sanPham.Ten.ToString(), LinkAnh = tenAnh, Loai = sanPham.Loai.ToString(), SoLuong = sanPham.SoLuong.ToString(), SoLuongDaBan = sanPham.SoLuongDaBan.ToString(), GiaGoc = sanPham.GiaGoc.ToString(), GiaBan = sanPham.GiaBan.ToString(), PhiShip = sanPham.PhiShip.ToString() });
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            // Lấy button được click
            Button btn = sender as Button;
            bool xoaSp = false;
            bool xoaMt = false;
            // Lấy ListViewItem chứa button
            ListViewItem item = FindAncestor<ListViewItem>(btn);

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
                            // Xóa dữ liệu từ bảng SanPham
                            sanPhamDao.Xoa(dataItem);
                            // Xóa dữ liệu từ lsvQuanLySanPham
                            lsvQuanLySanPham.Items.Remove(dataItem);
                            xoaSp = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xảy ra khi xóa sản phẩm: " + ex.Message);
                        }
                        try
                        {
                            // Xóa dữ liệu  khỏi bảng MoTaAnhSanPham
                            moTaDao.Xoa(dataItem);
                            xoaMt = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xảy ra khi xóa sản phẩm: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                        if (xoaSp && xoaMt)
                            MessageBox.Show("Xóa thành công");
                    }
                }
            }
            else
            {
                MessageBox.Show("Không thể xác định dòng chứa nút 'Xóa'.");
            }
        }

        // Hàm trợ giúp để tìm thành phần cha của một kiểu cụ thể
        public static T FindAncestor<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);

            if (parent == null)
                return null;

            var parentT = parent as T;
            return parentT ?? FindAncestor<T>(parent);
        }
        private int timIdMaxTrongBangSanPham()
        {
            List<string> list = new List<string>();
            list = sanPhamDao.timKiemId();
            int max = 0;
            for (int i = 0; i < list.Count; i++)
            {
                int value = Convert.ToInt32(list[i]);
                if (value > max)
                {
                    max = value;
                }
            }
            return max;
        }
        private void btnThemSanPhamMoi_Click(object sender, RoutedEventArgs e)
        {
            DangDo_Dang f = new DangDo_Dang(nguoiDung);

            f.txtbIdSanPham.Text = (timIdMaxTrongBangSanPham() + 1).ToString();

            // DƯỚI ĐÂY LÀ CÁCH Load lại lsvQuanLySanPham sau khi (thêm sản phẩm, và đóng cái DangDo_Dang)
            f.Closed += (s, ev) =>
            {
                HienThi_QuanLySanPham();
            };
            f.Show();

        }

        private void btnSuaDo_Click(object sender, RoutedEventArgs e)
        {
            // Lấy button được click
            Button btn = sender as Button;
            
            // Lấy ListViewItem chứa button
            ListViewItem item = FindAncestor<ListViewItem>(btn);

            if (item != null)
            {
                // Lấy dữ liệu của ListViewItem
                dynamic dataItem = item.DataContext;
                DangDo_Sua f = new DangDo_Sua();
                if (dataItem != null)
                {
                    //Đổ dữ liệu qua form sửa_BEGIN
                    try
                    {
                        //Đổ thông tin lên

                        List<string> listSanPham = new List<string>();
                        listSanPham = sanPhamDao.timKiemToanBoBangId(dataItem.Id);
                        SanPham sanPham = new SanPham(listSanPham[0], listSanPham[1], listSanPham[2], listSanPham[3],listSanPham[4], listSanPham[5], listSanPham[6], listSanPham[7], listSanPham[8], listSanPham[9], listSanPham[10], listSanPham[11], listSanPham[12], listSanPham[13], listSanPham[15], listSanPham[14], listSanPham[16]);
                        f = new DangDo_Sua(sanPham);
                        List<List<string>> moTaList = new List<List<string>>();
                        moTaList = moTaDao.TimKiemBangId(dataItem.Id);

                        //Đổ ảnh và mô tả lên
                        foreach(var list in  moTaList)
                        {
                                f.DanhSachAnhVaMoTa[f.soLuongAnh] = new ThemAnhKhiDangUC();

                                string tenFileAnh = list[0].ToString();
                                f.DanhSachAnhVaMoTa[f.soLuongAnh].txtbTenFileAnh.Text = tenFileAnh;

                                string duongDanAnh = XuLyAnh.layDuongDanDayDuToiFileAnh(tenFileAnh);
                                f.DanhSachAnhVaMoTa[f.soLuongAnh].txtbDuongDanAnh.Text = duongDanAnh;
                                f.DanhSachAnhVaMoTa[f.soLuongAnh].imgAnhSP.Source = new BitmapImage(new Uri(duongDanAnh));

                                string moTa = list[1].ToString();
                                f.DanhSachAnhVaMoTa[f.soLuongAnh].txtbMoTa.Text = moTa;

                                f.wpnlChuaAnh.Children.Add(f.DanhSachAnhVaMoTa[f.soLuongAnh]);
                                f.soLuongAnh++;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        f.Closed += (s, ev) =>
                        {
                            HienThi_QuanLySanPham();
                        };
                        f.Show();
                    }
                    //Đổ dữ liệu qua form sửa_END
                }
            }
        }


        #endregion


        #region TAB2 QUẢN LÝ ĐƠN HÀNG
        private void QuanLyDonHang_Load(object sender, RoutedEventArgs e)
        {
            LoadLsvTrongTabQuanLyDonHang("lsvChoDongGoi", "Chờ đóng gói");
            LoadLsvTrongTabQuanLyDonHang("lsvDangGiao", "Đang giao");
            LoadLsvTrongTabQuanLyDonHang("lsvDaGiao", "Đã giao");
            LoadLsvTrongTabQuanLyDonHang("lsvDonHangBiHoanTra", "Bị hoàn trả");
        }
        private void LoadLsvTrongTabQuanLyDonHang(string tenLsv, string trangthai)
        {
            try
            {
                List<List<string>> listQuanLy = new List<List<string>>();
                listQuanLy = quanLyDao.TimKiemTheoIdNguoiDang(nguoiDung.Id, trangthai);
                if (tenLsv == "lsvChoDongGoi")
                    lsvChoDongGoi.Items.Clear();
                else if (tenLsv == "lsvDangGiao")
                    lsvDangGiao.Items.Clear();
                else if (tenLsv == "lsvDaGiao")
                    lsvDaGiao.Items.Clear();
                else if (tenLsv == "lsvDonHangBiHoanTra")
                    lsvDonHangBiHoanTra.Items.Clear();

                foreach(var list in listQuanLy)
                {
                    string tenFileAnh = list[2];
                    string linkAnhBia = XuLyAnh.layDuongDanDayDuToiFileAnh(tenFileAnh);

                    if (tenLsv == "lsvChoDongGoi")
                        lsvChoDongGoi.Items.Add(new { IdSP = list[0], IdNguoiMua = list[8], TenSP = list[1], LinkAnhBia = linkAnhBia, SoLuongMua = list[3], Gia = list[4], PhiShip = list[5], TongTien = list[6] });
                    else if (tenLsv == "lsvDangGiao")
                        lsvDangGiao.Items.Add(new { IdSP = list[0], IdNguoiMua = list[8], TenSP = list[1], LinkAnhBia = linkAnhBia, SoLuongMua = list[3], Gia = list[4], PhiShip = list[5], TongTien = list[6] });
                    else if (tenLsv == "lsvDaGiao")
                        lsvDaGiao.Items.Add(new { IdSP = list[0], IdNguoiMua = list[8], TenSP = list[1], LinkAnhBia = linkAnhBia, SoLuongMua = list[3], Gia = list[4], PhiShip = list[5], TongTien = list[6] });
                    else if (tenLsv == "lsvDonHangBiHoanTra")
                    {
                        lsvDonHangBiHoanTra.Items.Add(new { IdSP = list[0], IdNguoiMua = list[8], TenSP = list[1], LinkAnhBia = linkAnhBia, SoLuongMua = list[3], Gia = list[4], PhiShip = list[5], TongTien = list[6], LyDoTraHang = list[7] });
                    }
                    //SanPham sanPham = new SanPham(id, name, imageUrl); 
                    //lsvQuanLySanPham.Items.Add(sanPham);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnDiaChiGuiHang_Click(object sender, RoutedEventArgs e)
        {
            // Lấy button được click
            Button btn = sender as Button;

            // Lấy ListViewItem chứa button
            ListViewItem item = FindAncestor<ListViewItem>(btn);

            if (item != null)
            {
                // Lấy dữ liệu của ListViewItem
                dynamic dataItem = item.DataContext;

                if (dataItem != null)
                {
                    DiaChi f = new DiaChi();
                    try
                    {
                        List<List<string>> listMoTa = new List<List<string>>();
                        listMoTa = trangThaiHangDao.TimKiemTheoId(dataItem.IdNguoiMua, dataItem.IdSP);
                        f.txtbTieuDe.Text = "Địa chỉ khách hàng";
                        foreach (var list in  listMoTa)
                        {
                            KhachHang kh = new KhachHang(dataItem.IdNguoiMua, list[0], null, null, null, list[2], list[1], list[3],null,null,null);
                            f = new DiaChi(kh);
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                        f.cboHinhThucThanhToan.IsEnabled = false;
                        f.txtHoTen.IsReadOnly = true;
                        f.txtDiaChi.IsReadOnly = true;
                        f.txtSoDienThoai.IsReadOnly = true;
                        f.txtEmail.IsReadOnly = true;
                        f.btnXacNhanThanhToan.Visibility = Visibility.Collapsed;
                        f.Show();
                    }


                }
            }


        }
        private void btnGuiHang_Click(object sender, RoutedEventArgs e)
        {
            // Lấy button được click
            Button btn = sender as Button;

            // Lấy ListViewItem chứa button
            ListViewItem item = FindAncestor<ListViewItem>(btn);

            if (item != null)
            {
                // Lấy dữ liệu của ListViewItem
                dynamic dataItem = item.DataContext;


                if (dataItem != null)
                {
                    //DiaChi f = new DiaChi(idNguoiMua);
                    try
                    {
                        QuanLyDonHang quanLy = new QuanLyDonHang(null,null,dataItem.IdNguoiMua,dataItem.IdSP,"Đang giao",null);
                        quanLyDao.CapNhat(quanLy);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        QuanLyDonHang_Load(sender, e);
                    }


                }
            }

        }


        #endregion

        #region TAB3 TỔNG QUAN VÀ THỐNG KÊ
        private void ThongKe_Load(object sender, RoutedEventArgs e)
        {
            LoadTongKhachHang();
            LoadTongSoLuongSanPhamDaBan();
            LoadTongDoanhThu();

            LoadDoanhThuTheoSanPham();
            LoadTiLePhanTramDoanhThuTheoSanPham();
            LoadSoLuongSanPhamDaBan();

            LoadDanhGiaNguoiMua();
        }

        private void LoadDanhGiaNguoiMua()
        {
            try
            {
                int soLuong1Sao = 0;
                int soLuong2Sao = 0;
                int soLuong3Sao = 0;
                int soLuong4Sao = 0;
                int soLuong5Sao = 0;
                List<List<string>> listSoSao = danhGiaNguoiDungDao.TinhSoSao(nguoiDung.Id);
                foreach(var list in listSoSao)
                {
                    int soSao = Convert.ToInt32(list[0].ToString());
                    int soLuongDanhGia = Convert.ToInt32(list[1]);
                    switch (soSao)
                    {
                        case 1:
                            soLuong1Sao = soLuongDanhGia;
                            break;
                        case 2:
                            soLuong2Sao = soLuongDanhGia;
                            break;
                        case 3:
                            soLuong3Sao = soLuongDanhGia;
                            break;
                        case 4:
                            soLuong4Sao = soLuongDanhGia;
                            break;
                        case 5:
                            soLuong5Sao = soLuongDanhGia;
                            break;
                    }
                }

                int tongSoLuotDanhGia = soLuong1Sao + soLuong2Sao + soLuong3Sao + soLuong4Sao + soLuong5Sao;
                txtbSoLuotDanhGia.Text = tongSoLuotDanhGia.ToString();

                ratingBar_SoSao.Value = (soLuong1Sao * 1 + soLuong2Sao * 2 + soLuong3Sao * 3 + soLuong4Sao * 4 + soLuong5Sao * 5) / tongSoLuotDanhGia;
                txtbSoSaoTrungBinh.Text = ratingBar_SoSao.Value.ToString("0.0");


                progressBar1Sao.Value = ((double)soLuong1Sao / tongSoLuotDanhGia) * 100;
                progressBar2Sao.Value = ((double)soLuong2Sao / tongSoLuotDanhGia) * 100;
                progressBar3Sao.Value = ((double)soLuong3Sao / tongSoLuotDanhGia) * 100;
                progressBar4Sao.Value = ((double)soLuong4Sao / tongSoLuotDanhGia) * 100;
                progressBar5Sao.Value = ((double)soLuong5Sao / tongSoLuotDanhGia) * 100;

                txtbSoLuong1Sao.Text = soLuong1Sao.ToString();
                txtbSoLuong2Sao.Text = soLuong2Sao.ToString();
                txtbSoLuong3Sao.Text = soLuong3Sao.ToString();
                txtbSoLuong4Sao.Text = soLuong4Sao.ToString();
                txtbSoLuong5Sao.Text = soLuong5Sao.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadSoLuongSanPhamDaBan()
        {
            try
            {
                List<string> dsNhan = new List<string>();
                List<int> dsSoLuongDaBan = new List<int>();
                List<int> dsSoLuongTong = new List<int>();
                List<List<string>> listSLDaBan = sanPhamDao.tinhSoLuongSPDaBan(nguoiDung.Id);
               
                foreach(var list in listSLDaBan)
                {
                    string ten = list[0];
                    int soLuongDaban = Convert.ToInt32(list[1]);
                    int soLuongTong = Convert.ToInt32(list[2]);

                    dsNhan.Add(ten);
                    dsSoLuongDaBan.Add(soLuongDaban);
                    dsSoLuongTong.Add(soLuongTong);
                }

                // Tạo 2 cột cạnh nhau
                SeriesCollection DoanhThuTheoSanPham_SC = new SeriesCollection
                {
                     new ColumnSeries
                     {
                         Title = "Số lượng đã bán",
                         Values = new ChartValues<int>(dsSoLuongDaBan),

                         Fill = Brushes.LightSkyBlue, // Màu của cột số lượng đã bán
                         ScalesYAt = 0 // Đặt cột này ở trục Y thứ nhất

                     },
                     new ColumnSeries
                     {
                         Title = "Số lượng tổng",
                         Values = new ChartValues<int>(dsSoLuongTong),
                         Fill = Brushes.Teal, // Màu của cột số lượng tổng
                         ScalesYAt = 0 // Đặt cột này ở trục Y thứ hai
                     }
                };

                // Đặt dữ liệu vào Chart
                chart_SoLuongSanPhamDaBan.Series = DoanhThuTheoSanPham_SC;

                var xAxis = new LiveCharts.Wpf.Axis
                {
                    Title = "Tên sản phẩm",
                    Labels = dsNhan.ToArray(),
                    FontSize = 9.5,
                    Separator = LiveCharts.Wpf.DefaultAxes.CleanSeparator

                };
                chart_SoLuongSanPhamDaBan.AxisX.Add(xAxis);

                var yAxis = new LiveCharts.Wpf.Axis
                {
                    Title = "Số lượng",
                    FontSize = 9.5,
                    LabelFormatter = value => value.ToString("#,##0") // Định dạng label cho trục Y thứ nhất
                };
                chart_SoLuongSanPhamDaBan.AxisY.Add(yAxis);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadTiLePhanTramDoanhThuTheoSanPham()
        {
            try
            {
                List<string> dsNhan = new List<string>();
                List<int> dsDoanhThu = new List<int>();
                List<List<string>> listTiLeDoanhThu = sanPhamDao.tinhDoanhThuTheoSanPham(nguoiDung.Id);
                
                foreach(var list in listTiLeDoanhThu)
                {
                    string ten = list[0];
                    int soLuongDaban = Convert.ToInt32(list[1]);
                    int giaBan = Convert.ToInt32(list[2]);
                    int doanhThu = soLuongDaban * giaBan;
                    dsNhan.Add(ten);
                    dsDoanhThu.Add(doanhThu);
                }

                // Tạo SeriesCollection cho biểu đồ PieChart
                SeriesCollection TiLePhanTramDoanhThuTheoSanPham_SC = new SeriesCollection();

                // Tạo các Slice (phần chia) cho PieChart từ dữ liệu
                for (int i = 0; i < dsNhan.Count; i++)
                {
                    TiLePhanTramDoanhThuTheoSanPham_SC.Add(new PieSeries
                    {
                        Title = dsNhan[i], // Tên sản phẩm
                        Values = new ChartValues<int> { dsDoanhThu[i] } // Doanh thu tương ứng với sản phẩm

                    });
                }

                // Đặt dữ liệu vào PieChart
                chart_TiLePhanTramDoanhThuTheoSanPham.Series = TiLePhanTramDoanhThuTheoSanPham_SC;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void LoadDoanhThuTheoSanPham()
        {
            try
            {
                List<string> dsNhan = new List<string>();
                List<int> dsDoanhThu = new List<int>();
                List<List<string>> listDoanhThu = sanPhamDao.tinhDoanhThuTheoSanPham(nguoiDung.Id);

                foreach(var list in listDoanhThu)
                {
                    string ten = list[0];
                    int soLuongDaban = Convert.ToInt32(list[1]);
                    int giaBan = Convert.ToInt32(list[2]);
                    int doanhThu = soLuongDaban * giaBan;

                    dsNhan.Add(ten);
                    dsDoanhThu.Add(doanhThu);
                }
                SeriesCollection DoanhThuTheoSanPham_SC = new SeriesCollection
                {
                     new ColumnSeries
                     {
                         Title = "Doanh thu",
                         Values = new ChartValues<int> (dsDoanhThu)
                     }
                };


                // Đặt dữ liệu vào Chart
                chart_TongDoanhThuTheoSanPham.Series = DoanhThuTheoSanPham_SC;

                var xAxis = new LiveCharts.Wpf.Axis
                {
                    Title = "Tên sản phẩm",
                    FontSize = 9.5,
                    Labels = dsNhan.ToArray(),
                    Separator = LiveCharts.Wpf.DefaultAxes.CleanSeparator
                };
                chart_TongDoanhThuTheoSanPham.AxisX.Add(xAxis);

                var yAxis = new LiveCharts.Wpf.Axis
                {
                    Title = "Doanh thu",
                    FontSize = 9.5,
                    LabelFormatter = value => value.ToString("#,##0,##0") // Định dạng label
                };
                chart_TongDoanhThuTheoSanPham.AxisY.Add(yAxis);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadTongDoanhThu()
        {
            try
            {
                int tongDoanhThu = 0;
                List<List<string>> listTongDoanhThu = sanPhamDao.tinhDoanhThu(nguoiDung.Id);
                foreach(var list in listTongDoanhThu)
                {
                    int soLuongDaBan = Convert.ToInt32(list[0]);
                    int giaBan = Convert.ToInt32(list[1]);
                    tongDoanhThu += soLuongDaBan * giaBan;
                }
                txtbTongDoanhThu.Text = tongDoanhThu.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadTongSoLuongSanPhamDaBan()
        {
            try
            {
                int tongSanPhamDaBan = 0;
                List<List<string>> listTongSLDaBan = sanPhamDao.tinhTongSLDaBan(nguoiDung.Id);

                foreach(var list in listTongSLDaBan)
                {
                    tongSanPhamDaBan += Convert.ToInt32(list[1]);
                }
                txtbTongSoLuongSanPhamDaBan.Text = tongSanPhamDaBan.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadTongKhachHang()
        {
            try
            {
                List<List<string>> listTongKhachHang = trangThaiHangDao.tinhTongKhachHang(nguoiDung.Id);
                
                foreach(var list in listTongKhachHang)
                {
                    txtbTongSoLuongKhachHang.Text = list[1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnThongTinChiTietDanhGia_Click(object sender, RoutedEventArgs e)
        {
            ThongTinNguoiDang f = new ThongTinNguoiDang(nguoiDung.Id);
            f.txtbTieuDe.Text = "Đánh giá của khách hàng";
            f.Show();
        }

        #endregion

        #region LOAD TabItem
        private void tabItemQuanLySP_Loaded(object sender, RoutedEventArgs e)
        {
            //HienThi_QuanLySanPham();
            Loaded += QuanLySanPham_Load;
        }
        private void tabItemQuanLyDonHang_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded += QuanLyDonHang_Load;
        }
        private void tabItemThongKe_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded += ThongKe_Load;
        }

        #endregion


    }
}


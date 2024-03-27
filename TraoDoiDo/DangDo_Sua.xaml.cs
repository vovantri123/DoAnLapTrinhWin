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
using System.Windows.Shapes;

namespace TraoDoiDo
{
    /// <summary>
    /// Interaction logic for DangDo_Sua.xaml
    /// </summary>
    public partial class DangDo_Sua : Window
    {
        public int soLuongAnh = 0; 
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public ThemAnhKhiDangUC[] DanhSachAnhVaMoTa = new ThemAnhKhiDangUC[100]; //Khi dùng thì phải khai báo là DanhSachAnhVaMoTa[i] = new ThemAnhKhiDangUC();

        public DangDo_Sua()
        {
            InitializeComponent(); 
        }
        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            suaAnhVaMoTaTrongCSDL(); //Phải để cái này ở trên cái dưới
            suaThongTinSanPhamTrongCSDL();
        }
        private void suaAnhVaMoTaTrongCSDL()
        {
            try
            {
                conn.Open();
                 
                string id = txtbIdSanPham.Text;
                
                // Xóa dữ liệu cũ khỏi bảng MoTaAnhSanPham
                string sqlDelete = $"DELETE FROM MoTaAnhSanPham WHERE IdSanPham = {id}";
                SqlCommand cmdDelete = new SqlCommand(sqlDelete, conn);
                cmdDelete.ExecuteNonQuery();
                //Cập  nhật dữ liệu mới
                for (int i = 0; i < soLuongAnh; i++)
                {

                    if (DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text != null && !string.IsNullOrEmpty(DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text.Trim()) && DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text!= "no_image.jpg")
                    {
                        string idAnhMinhHoa = (i + 1).ToString();
                        string tenFileAnh = DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text;


                        string moTa = DanhSachAnhVaMoTa[i].txtbMoTa.Text;

                        string sqlStr = $@" INSERT INTO MoTaAnhSanPham (IdSanPham, IdAnhMinhHoa ,LinkAnhMinhHoa, MoTa)  
                                        VALUES ('{id}', '{idAnhMinhHoa}','{tenFileAnh}', N'{moTa}')";


                        SqlCommand command = new SqlCommand(sqlStr, conn);
                        int rowsAffected = command.ExecuteNonQuery();

                        string noiLuAnh = DanhSachAnhVaMoTa[i].txtbDuongDanAnh.Text;
                        LuuAnhVaoThuMuc(noiLuAnh);


                        if (rowsAffected <= 0)
                        {
                            MessageBox.Show($"Không thể sửa ảnh số {soLuongAnh + 1} và mô tả của ảnh này trong cơ sở dữ liệu.");
                        }
                    }
                    else
                        continue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }
        private void suaThongTinSanPhamTrongCSDL()
        {
            try
            {
                conn.Open();

                // Dữ liệu cần chèn
                string id = txtbIdSanPham.Text;
                string ten = txtbTen.Text;

                string tenFileAnh = "no_image.jpg";
                for (int i = 0; i < soLuongAnh; i++)
                    if (DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text != null && !string.IsNullOrEmpty(DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text.Trim()) && DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text != "no_image.jpg")
                    {
                        tenFileAnh = DanhSachAnhVaMoTa[i].txtbTenFileAnh.Text;
                        break;
                    }

                string loai = txtbLoai.Text;
                string soLuong = cboSoLuong.Text;
                string soLuongDaBan = cboSoLuongDaBan.Text;
                string giaGoc = txtbGiaGoc.Text;
                string giaBan = txtbGiaBan.Text;
                string phiShip = txtbPhiShip.Text;
                string trangThai = "Đã duyệt";
                string noiBan = txtbNoiBan.Text;
                string xuatXu = txtbXuatXu.Text;
                string ngayMua = txtbNgayMua.Text;
                string phanTramMoi = txtbPhanTramMoi.Text;
                string moTaChung = txtbMoTaChung.Text;
                
                // Câu lệnh SQL UPDATE
                string sqlStr = $@"UPDATE SanPham 
                  SET Ten = N'{ten}', 
                      LinkAnhBia = '{tenFileAnh}', 
                      Loai = N'{loai}', 
                      SoLuong = '{soLuong}', 
                      SoLuongDaBan = '{soLuongDaBan}', 
                      GiaGoc = '{giaGoc}', 
                      GiaBan = '{giaBan}', 
                      PhiShip = '{phiShip}', 
                      TrangThai = N'{trangThai}', 
                      NoiBan = N'{noiBan}', 
                      XuatXu = N'{xuatXu}', 
                      NgayMua = '{ngayMua}', 
                      PhanTramMoi = '{phanTramMoi}', 
                      MoTaChung = N'{moTaChung}' 
                  WHERE IdSanPham = '{id}'";


                SqlCommand command = new SqlCommand(sqlStr, conn);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thông tin sản phẩm đã được sửa");
                }
                else
                {
                    MessageBox.Show("Thông tin sản phẩm sửa thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void btnThemAnh_Click(object sender, RoutedEventArgs e)
        { 
            DanhSachAnhVaMoTa[soLuongAnh] = new ThemAnhKhiDangUC();
            wpnlChuaAnh.Children.Add(DanhSachAnhVaMoTa[soLuongAnh]);
            soLuongAnh++;
        }
        

        private void LuuAnhVaoThuMuc(string duongDanAnh)
        {
            try
            {
                // Kiểm tra xem đường dẫn ảnh có tồn tại không
                if (!System.IO.File.Exists(duongDanAnh))
                {
                    MessageBox.Show("Không tìm thấy tệp ảnh.");
                    return;
                }

                string thuMucHinhCuaToi = XuLyAnh.layDuongDanToiHinhSanPham();

                // Kiểm tra xem thư mục có tồn tại không, nếu không thì tạo mới
                if (!System.IO.Directory.Exists(thuMucHinhCuaToi))
                {
                    System.IO.Directory.CreateDirectory(thuMucHinhCuaToi);
                }

                // Lấy tên tệp ảnh từ đường dẫn
                string tenFile = System.IO.Path.GetFileName(duongDanAnh);

                // Tạo đường dẫn mới cho tệp ảnh trong thư mục "HinhCuaToi"
                string duongDanMoi = System.IO.Path.Combine(thuMucHinhCuaToi, tenFile);

                // Kiểm tra xem tệp ảnh đã tồn tại trong thư mục chưa
                if (System.IO.File.Exists(duongDanMoi))
                {
                    MessageBox.Show("Tệp ảnh đã tồn tại trong thư mục HinhSanPham.");
                    return;
                }

                // Sao chép tệp ảnh vào thư mục "HinhCuaToi"
                System.IO.File.Copy(duongDanAnh, duongDanMoi, true);

                MessageBox.Show("Ảnh đã được lưu vào thư mục HinhSanPham.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu ảnh: " + ex.Message);
            }
        }
    }
}


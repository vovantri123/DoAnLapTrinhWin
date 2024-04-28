using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using TraoDoiDo.Models; 

namespace TraoDoiDo.Database
{
    public class NguoiDungDao : ThuocTinhDao
    {
        List<NguoiDung> dsNguoi;
        List<string> dongKetQua;
        List<List<string>> bangKetQua;

        public void Them(NguoiDung user)
        {
            string sqlStr = $"INSERT INTO {nguoiDungHeader} ({nguoiDungTen},{nguoiDungGioiTinh},{nguoiDungNgaySinh},{nguoiDungSdt},{nguoiDungCMND},{nguoiDungDiaChi},{nguoiDungEmail},{nguoiDungAnh})"
                            + $"VALUES (N'{user.HoTen}',N'{user.GioiTinh}','{user.NgaySinh}','{user.Sdt}','{user.Cmnd}',N'{user.DiaChi}','{user.Email}','{user.Anh}')";
            dbConnection.ThucThi(sqlStr);
        }
        public void Xoa(string id)
        {
            string sqlStr = $"DELETE FROM {nguoiDungHeader} WHERE {nguoiDungID}='{id}'";
            dbConnection.ThucThi(sqlStr);
        }
        public void CapNhat(NguoiDung user)
        {
            string sqlStr = $"UPDATE {nguoiDungHeader} SET " +
                $"{nguoiDungTen}=N'{user.HoTen}', {nguoiDungGioiTinh}=N'{user.GioiTinh}', {nguoiDungNgaySinh}='{Convert.ToString(user.NgaySinh)}'," +
                $"{nguoiDungCMND} = '{user.Cmnd}', {nguoiDungEmail} = '{user.Email}',{nguoiDungSdt} = '{user.Sdt}'," +
                $"{nguoiDungDiaChi} = '{user.DiaChi}', {nguoiDungAnh} = '{user.Anh}' WHERE {nguoiDungID}='{user.Id}'";
            dbConnection.ThucThi(sqlStr);
        }
        public void CapNhatDiaChi(NguoiDung user)
        {
            string sqlStr = $@"
                    UPDATE {nguoiDungHeader}
                    SET {nguoiDungTen} = N'{user.HoTen}', 
                        {nguoiDungSdt}= '{user.Sdt}', 
                        {nguoiDungEmail}= '{user.Email}',
                        {nguoiDungDiaChi} = N'{user.DiaChi}'
                    WHERE {nguoiDungID} = '{user.Id}' ";
            dbConnection.ThucThi(sqlStr);
        }
        

        public NguoiDung TimKiemThongTinTheoIdNguoi(string idNguoi)
        {
            string sqlStr = $@"SELECT {nguoiDungTen},{nguoiDungSdt},{nguoiDungEmail},{nguoiDungDiaChi},{nguoiDungAnh}
                            FROM {nguoiDungHeader} 
                            WHERE {nguoiDungID} = '{idNguoi}' ";
            dongKetQua = dbConnection.LayDanhSach<string>(sqlStr);

            return new NguoiDung(idNguoi, dongKetQua[0], null, null, null, dongKetQua[2], dongKetQua[1], dongKetQua[3], dongKetQua[4], null, null);
        }
         

        public string TimKiemLinkAnh(string id)
        {
            string sqlStr = $@"SELECT {nguoiDungAnh} FROM {nguoiDungHeader} WHERE {nguoiDungID} = '{id}' ";
            return dbConnection.LayMotDoiTuong(sqlStr, $"{nguoiDungAnh}");
        }

        public NguoiDung TimKiemBangTenDangNhap(string tenDangNhap, string matKhau)
        {
            string sqlStr = $@"SELECT {nguoiDungTen},{nguoiDungCMND},{nguoiDungGioiTinh},{nguoiDungSdt},{nguoiDungNgaySinh},{nguoiDungDiaChi},{nguoiDungEmail},{nguoiDungAnh}, {nguoiDungTien}, {taiKhoanTenDangNhap}, {taiKhoanMatKhau}, {nguoiDungHeader}.{nguoiDungID} 
                               FROM {nguoiDungHeader}
                               INNER JOIN {taiKhoanHeader} ON {nguoiDungHeader}.{nguoiDungID} = {taiKhoanHeader}.{taiKhoanIdNguoiDung}
                               WHERE {taiKhoanTenDangNhap}='{tenDangNhap}' AND {taiKhoanMatKhau}='{matKhau}'";
            dongKetQua = dbConnection.LayDanhSach<string>(sqlStr);
            return new NguoiDung(dongKetQua[11], dongKetQua[0], dongKetQua[2], dongKetQua[4], dongKetQua[1], dongKetQua[6], dongKetQua[3], dongKetQua[5], dongKetQua[7], new TaiKhoan(dongKetQua[9], dongKetQua[10], dongKetQua[11]), dongKetQua[8]);
        }

        public string TimKiemTienBangId(string id)
        {
            string sqlStr = $@"SELECT {nguoiDungTien} FROM {nguoiDungHeader} WHERE {nguoiDungID} = '{id}' ";
            return dbConnection.LayMotDoiTuong(sqlStr, $"{nguoiDungTien}");
        }

        public string TimKiemMatKhauBangEmail(string email)
        {
            string sqlStr = $"SELECT {taiKhoanMatKhau} FROM {taiKhoanHeader} INNER JOIN {nguoiDungHeader} ON {taiKhoanHeader}.{taiKhoanIdNguoiDung} = {nguoiDungHeader}.{nguoiDungID} WHERE {nguoiDungHeader}.{nguoiDungEmail}='{email}'";
            return dbConnection.LayMotDoiTuong(sqlStr, $"{taiKhoanMatKhau}");
        }
        public string TimKiemMatKhauBangSdt(string sdt)
        {
            string sqlStr = $"SELECT {taiKhoanMatKhau} FROM {taiKhoanHeader} INNER JOIN {nguoiDungHeader} ON {taiKhoanHeader}.{taiKhoanIdNguoiDung} = {nguoiDungHeader}.{nguoiDungID} WHERE {nguoiDungHeader}.{nguoiDungSdt}='{sdt}'";
            return dbConnection.LayMotDoiTuong(sqlStr, $"{taiKhoanMatKhau}");
        }
        public List<NguoiDung> LoadDSThongTinNguoi() //Nếu cần thêm thông tin thì cứ thêm cột, và sửa cái null (khá là ok và nó k ảnh hưởng hàm khác)
        {
            string sqlStr = $@" SELECT {nguoiDungID},{nguoiDungTen}, {nguoiDungDiaChi}, {nguoiDungAnh}
                        FROM {nguoiDungHeader} ";
                        
            dsNguoi = new List<NguoiDung>();
            bangKetQua = dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr);
            foreach (var dong in bangKetQua)
                dsNguoi.Add(new NguoiDung(dong[0], dong[1], null, null, null, null, null, dong[2], dong[3], null, null));
            return dsNguoi;
        }
        public List<NguoiDung> LoadDanhSachNguoiHayMuaNhat() //Lấy hết, giảm dần từ trên xuống,
        {
            //MessageBox.Show(idNguoiMua + "nè 123");
            string sqlStr = $@"
                        SELECT {trangThaiIdNguoiMua}, {nguoiDungTen}, {nguoiDungDiaChi}, {nguoiDungAnh}, COUNT({trangThaiTrangThai}) AS SoSanPhamDaMua
                        FROM {trangThaiHeader}
                        INNER JOIN {nguoiDungHeader} ON {trangThaiIdNguoiMua} = {nguoiDungID}
                        WHERE {trangThaiTrangThai} = N'Đã nhận'  
                        GROUP BY {trangThaiIdNguoiMua}, {nguoiDungTen}, {nguoiDungDiaChi}, {nguoiDungAnh}
                        ORDER BY SoSanPhamDaMua DESC 
";
            dsNguoi = new List<NguoiDung>();
            bangKetQua = dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr);
            foreach (var dong in bangKetQua) 
                dsNguoi.Add(new NguoiDung(dong[0], dong[1], dong[2], dong[3], dong[4])); 

            //MessageBox.Show(dbConnection.LayMotDoiTuong(sqlStr, $"{nguoiDungAnh}") + "123");
            return dsNguoi;
        }
        
    }
}

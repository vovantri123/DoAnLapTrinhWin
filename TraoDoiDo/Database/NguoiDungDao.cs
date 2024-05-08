using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            string sqlStr = $@"
                INSERT INTO {nguoiDungHeader} ({nguoiDungID},{nguoiDungTen},{nguoiDungGioiTinh},{nguoiDungNgaySinh},{nguoiDungSdt},{nguoiDungCMND},{nguoiDungDiaChi},{nguoiDungEmail},{nguoiDungAnh},{nguoiDungTien})
                VALUES ({user.Id},N'{user.HoTen}',N'{user.GioiTinh}','{user.NgaySinh}','{user.Sdt}','{user.Cmnd}',N'{user.DiaChi}','{user.Email}','{user.Anh}','{user.Tien}')
            ";
            dbConnection.ThucThi(sqlStr);
        }

        public void Xoa(string id)
        {
            string sqlStr = $@"
                DELETE FROM {nguoiDungHeader} 
                WHERE {nguoiDungID}='{id}'
            ";
            dbConnection.ThucThi(sqlStr);
        }

        public void CapNhat(NguoiDung user)
        {
            string sqlStr = $@"
                UPDATE {nguoiDungHeader} 
                SET {nguoiDungTen}=N'{user.HoTen}', 
                    {nguoiDungGioiTinh}=N'{user.GioiTinh}', 
                    {nguoiDungNgaySinh}='{Convert.ToString(user.NgaySinh)}', 
                    {nguoiDungCMND} = '{user.Cmnd}', 
                    {nguoiDungEmail} = '{user.Email}',
                    {nguoiDungSdt} = '{user.Sdt}',
                    {nguoiDungDiaChi} = N'{user.DiaChi}', 
                    {nguoiDungAnh} = '{user.Anh}' 
                WHERE {nguoiDungID}='{user.Id}'
            ";
            dbConnection.ThucThi(sqlStr);
        }
         
        public NguoiDung TimNguoiBangIdNguoi(string idNguoi)
        {
            string sqlStr = $@"
                SELECT {nguoiDungHeader}.{nguoiDungID},{nguoiDungTen},{nguoiDungCMND},{nguoiDungGioiTinh},{nguoiDungNgaySinh},{nguoiDungSdt},{nguoiDungEmail},{nguoiDungDiaChi},{nguoiDungAnh},{taiKhoanHeader}.{taiKhoanTenDangNhap},{taiKhoanHeader}.{taiKhoanMatKhau},{nguoiDungTien}
                FROM {nguoiDungHeader} 
                INNER JOIN {taiKhoanHeader} ON {nguoiDungHeader}.{nguoiDungID} = {taiKhoanHeader}.{taiKhoanIdNguoiDung}
                WHERE {nguoiDungHeader}.{nguoiDungID} = '{idNguoi}' 
            ";
            dongKetQua = dbConnection.LayMotDongDuLieu<string>(sqlStr);
            if(dongKetQua!=null)
                return new NguoiDung(dongKetQua[0], dongKetQua[1], dongKetQua[3], dongKetQua[4], dongKetQua[2], dongKetQua[6], dongKetQua[5], dongKetQua[7], dongKetQua[8], new TaiKhoan(dongKetQua[9], dongKetQua[10], dongKetQua[0]), dongKetQua[11]);
            return null;
        }

        public List<NguoiDung> LoadNguoiDung()
        {
            string sqlStr = $@"
                SELECT {nguoiDungID},{nguoiDungTen},{nguoiDungCMND},{nguoiDungGioiTinh},{nguoiDungNgaySinh},{nguoiDungSdt},{nguoiDungEmail},{nguoiDungDiaChi}
                FROM {nguoiDungHeader} 
            ";
            dsNguoi = new List<NguoiDung>();
            bangKetQua = dbConnection.LayNhieuDongDuLieu<string>(sqlStr);
            foreach (var dong in bangKetQua) 
                dsNguoi.Add(new NguoiDung(dong[0], dong[1], dong[3], dong[4], dong[2], dong[6], dong[5], dong[7], null, null, null)); 

            return dsNguoi;
        }

        public string TimKiemTenAnhDaiDienTheoIdNguoi(string id)
        {
            string sqlStr = $@"
                SELECT {nguoiDungAnh} 
                FROM {nguoiDungHeader} 
                WHERE {nguoiDungID} = '{id}' 
            ";
            return dbConnection.LayMotGiaTri(sqlStr, $"{nguoiDungAnh}");
        }

        public NguoiDung TimKiemNguoiBangTenDangNhap(string tenDangNhap, string matKhau)
        {
            string sqlStr = $@"
                SELECT {nguoiDungTen},{nguoiDungCMND},{nguoiDungGioiTinh},{nguoiDungSdt},{nguoiDungNgaySinh},{nguoiDungDiaChi},{nguoiDungEmail},{nguoiDungAnh}, {nguoiDungTien}, {taiKhoanTenDangNhap}, {taiKhoanMatKhau}, {nguoiDungHeader}.{nguoiDungID} 
                FROM {nguoiDungHeader}
                INNER JOIN {taiKhoanHeader} ON {nguoiDungHeader}.{nguoiDungID} = {taiKhoanHeader}.{taiKhoanIdNguoiDung}
                WHERE {taiKhoanTenDangNhap}= '{tenDangNhap}' AND {taiKhoanMatKhau}= '{matKhau}' 
            ";
            dongKetQua = dbConnection.LayMotDongDuLieu<string>(sqlStr);
            if (dongKetQua != null)
                return new NguoiDung(dongKetQua[11], dongKetQua[0], dongKetQua[2], dongKetQua[4], dongKetQua[1], dongKetQua[6], dongKetQua[3], dongKetQua[5], dongKetQua[7], new TaiKhoan(dongKetQua[9], dongKetQua[10], dongKetQua[11]), dongKetQua[8]);
            return null;
        }

        public string TimKiemTienBangId(string id)
        {
            string sqlStr = $@"
                SELECT {nguoiDungTien} 
                FROM {nguoiDungHeader} 
                WHERE {nguoiDungID} = '{id}' 
            ";
            return dbConnection.LayMotGiaTri(sqlStr, $"{nguoiDungTien}");
        }
         
        public string TimKiemMatKhauBangEmail(string email)
        {
            string sqlStr = $@"
                SELECT {taiKhoanMatKhau} 
                FROM {taiKhoanHeader} 
                INNER JOIN {nguoiDungHeader} ON {taiKhoanHeader}.{taiKhoanIdNguoiDung} = {nguoiDungHeader}.{nguoiDungID} 
                WHERE {nguoiDungHeader}.{nguoiDungEmail}='{email}'
            ";
            return dbConnection.LayMotGiaTri(sqlStr, $"{taiKhoanMatKhau}");
        }

        public string TimKiemMatKhauBangSdt(string sdt)
        {
            string sqlStr = $@"
                SELECT {taiKhoanMatKhau} 
                FROM {taiKhoanHeader} 
                INNER JOIN {nguoiDungHeader} ON {taiKhoanHeader}.{taiKhoanIdNguoiDung} = {nguoiDungHeader}.{nguoiDungID} 
                WHERE {nguoiDungHeader}.{nguoiDungSdt}='{sdt}'
            ";
            return dbConnection.LayMotGiaTri(sqlStr, $"{taiKhoanMatKhau}");
        }

        public NguoiDung timKiemNguoiDangTheoIdSP(string idSP)
        {
            string sqlStr = $@"
                SELECT {sanPhamIdNguoiDang}, {nguoiDungTen} 
                FROM {sanPhamHeader}
                INNER JOIN {nguoiDungHeader} ON {sanPhamHeader}.{sanPhamIdNguoiDang} = {nguoiDungHeader}.{nguoiDungID}
                WHERE {sanPhamID} = '{idSP}' 
            ";
            dongKetQua = dbConnection.LayMotDongDuLieu<string>(sqlStr);
            if (dongKetQua != null)
                return new NguoiDung(dongKetQua[0], dongKetQua[1], null, null, null, null, null, null, null, null, null);
            return null;
        } 
         
        public List<NguoiDung> LoadDanhSachNguoiHayMuaNhat() //Lấy hết, giảm dần từ trên xuống
        {
            string sqlStr = $@"
                        SELECT {trangThaiIdNguoiMua}, {nguoiDungTen}, {nguoiDungDiaChi}, {nguoiDungAnh}, COUNT({trangThaiTrangThai}) AS SoSanPhamDaMua
                        FROM {trangThaiHeader}
                        INNER JOIN {nguoiDungHeader} ON {trangThaiIdNguoiMua} = {nguoiDungID}
                        WHERE {trangThaiTrangThai} = N'Đã nhận'  
                        GROUP BY {trangThaiIdNguoiMua}, {nguoiDungTen}, {nguoiDungDiaChi}, {nguoiDungAnh}
                        ORDER BY SoSanPhamDaMua DESC 
            ";
            dsNguoi = new List<NguoiDung>();
            bangKetQua = dbConnection.LayNhieuDongDuLieu<string>(sqlStr);
            foreach (var dong in bangKetQua)
                dsNguoi.Add(new NguoiDung(dong[0], dong[1], dong[2], dong[3], dong[4]));

            return dsNguoi;
        }

        public NguoiDung TimThongTinNguoiMuaDeGuihang(string idNguoiMua, string idSanPham)
        {
            string sqlStr = $@" 
                SELECT distinct {nguoiDungTen}, {nguoiDungSdt}, {nguoiDungEmail}, {nguoiDungDiaChi} 
                FROM {trangThaiHeader}
                INNER JOIN {nguoiDungHeader} ON {trangThaiHeader}.{trangThaiIdNguoiMua} = {nguoiDungHeader}.{nguoiDungID}
                WHERE {trangThaiHeader}.{trangThaiIdNguoiMua} = '{idNguoiMua}' AND {trangThaiHeader}.{trangThaiIdSanPham} = '{idSanPham}' 
            ";
            dongKetQua = dbConnection.LayMotDongDuLieu<string>(sqlStr);

            return new NguoiDung(idNguoiMua, dongKetQua[0], null, null, null, dongKetQua[2], dongKetQua[1], dongKetQua[3], null, null, null);
        }

        public string TimKiemTuKhoaSanPhamDangQuanTamGanDay(string idNguoiMua)
        {
            string sqlStr = $@"
                SELECT {nguoiDungTuKhoaSanPhamDangQuanTam} 
                FROM {nguoiDungHeader} 
                WHERE {nguoiDungID} = '{idNguoiMua}' 
            ";
            return dbConnection.LayMotGiaTri(sqlStr, $"{nguoiDungTuKhoaSanPhamDangQuanTam}");
        }

        public void CapNhatTuKhoaSanPhamDangQuanTam(NguoiDung nguoiMua, string tuKhoa)
        {
            string sqlStr = $@"
                UPDATE {nguoiDungHeader}
                SET {nguoiDungTuKhoaSanPhamDangQuanTam} = N'{tuKhoa}'  
                WHERE {nguoiDungID} = '{nguoiMua.Id}' 
            ";
            dbConnection.ThucThi(sqlStr);
        }

        public void CongThemVaoSoTienHienTai(string idNguoiMua, string soTienCongThem)
        {
            string sqlStr = $@"
                UPDATE {nguoiDungHeader} 
                SET {nguoiDungTien} = CONVERT(FLOAT,{nguoiDungTien}) + CONVERT(FLOAT,{soTienCongThem})
                WHERE {nguoiDungID}='{idNguoiMua}'
            ";
            dbConnection.ThucThi(sqlStr);
        }
        public int timKiemIdMax()
        {
            string sqlStr = $@"
                SELECT MAX({nguoiDungID}) AS IdMax 
                FROM {nguoiDungHeader}
            ";
            return Convert.ToInt32(dbConnection.LayMotGiaTri(sqlStr, "IdMax"));
        }
    }
}

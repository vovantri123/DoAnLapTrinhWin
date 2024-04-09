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
    public class KhacHangDao : ThuocTinhDao
    {
        public void Them(KhachHang user)
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
        public void CapNhat(KhachHang user)
        {
            string sqlStr = $"UPDATE {nguoiDungHeader} SET " +
                $"{nguoiDungTen}=N'{user.HoTen}', {nguoiDungGioiTinh}=N'{user.GioiTinh}', {nguoiDungNgaySinh}='{Convert.ToString(user.NgaySinh)}'," +
                $"{nguoiDungCMND} = '{user.Cmnd}', {nguoiDungEmail} = '{user.Email}',{nguoiDungSdt} = '{user.Sdt}'," +
                $"{nguoiDungDiaChi} = '{user.DiaChi}', {nguoiDungAnh} = '{user.Anh}' WHERE {nguoiDungID}='{user.Id}'";
            dbConnection.ThucThi(sqlStr);
        }
        public void CapNhatDiaChi(KhachHang user)
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
        public List<string> TimKiemTheoIdNguoi(KhachHang user)
        {
            string sqlStr = $@"SELECT {nguoiDungTen},{nguoiDungSdt},{nguoiDungEmail},{nguoiDungDiaChi} FROM {nguoiDungHeader} WHERE {nguoiDungID} = '{user.Id}' ";
            return dbConnection.LayDanhSach<string>(sqlStr);
        }

        public string TimKiemBangId(string id)
        {
            string sqlStr = $"SELECT * FROM {nguoiDungHeader} WHERE {nguoiDungID}='{id}'";
            return (string)dbConnection.LayMotDoiTuong(sqlStr, $"{nguoiDungID}");
        }
        public List<string> TimKiemBangTenDangNhap(string name)
        {
            string sqlStr = $"SELECT {nguoiDungTen},{nguoiDungCMND},{nguoiDungGioiTinh},{nguoiDungSdt},{nguoiDungNgaySinh},{nguoiDungDiaChi},{nguoiDungEmail},{nguoiDungAnh} FROM {nguoiDungHeader}" +
                $" INNER JOIN {taiKhoanHeader} ON {nguoiDungHeader}.{nguoiDungID} = {taiKhoanHeader}.{taiKhoanIdNguoiDung}" +
                $" WHERE {taiKhoanHeader}.{taiKhoanTenDangNhap}='{name}'";
            return dbConnection.LayDanhSach<string>(sqlStr);
        }

        public string TimKiemBangEmail(string email)
        {
            string sqlStr = $"SELECT {taiKhoanMatKhau} FROM {taiKhoanHeader} INNER JOIN {nguoiDungHeader} ON {taiKhoanHeader}.{taiKhoanIdNguoiDung} = {nguoiDungHeader}.{nguoiDungID} WHERE {nguoiDungHeader}.{nguoiDungEmail}='{email}'";
            return dbConnection.LayMotDoiTuong(sqlStr, $"{taiKhoanMatKhau}");
        }
        public string TimKiemBangSdt(string sdt)
        {
            string sqlStr = $"SELECT {taiKhoanMatKhau} FROM {taiKhoanHeader} INNER JOIN {nguoiDungHeader} ON {taiKhoanHeader}.{taiKhoanIdNguoiDung} = {nguoiDungHeader}.{nguoiDungID} WHERE {nguoiDungHeader}.{nguoiDungSdt}='{sdt}'";
            return dbConnection.LayMotDoiTuong(sqlStr, $"{taiKhoanMatKhau}");
        }
    }
}

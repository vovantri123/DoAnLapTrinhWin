using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TraoDoiDo.Models;

namespace TraoDoiDo.Database
{
    public class GiaoDichDao : ThuocTinhDao
    {
        public void Them(GiaoDich gd)
        {
            string sqlStr = $"INSERT INTO {giaoDichHeader} ({taiKhoanIdNguoiDung}, {giaoDichLoai},{giaoDichSoTien},{giaoDichTuNguon},{giaoDichDenNguon},{giaoDichNgay})"
                            + $"VALUES ('{gd.IdNguoiDung}',N'{gd.LoaiGiaoDich}','{gd.SoTien}',N'{gd.TuNguonTien}',N'{gd.DenNguonTien}','{gd.NgayGiaoDich}')";
            dbConnection.ThucThi(sqlStr);
        }
        public List<string> TinhTienNguoiDung(GiaoDich gd, string loai)
        {
            string sqlStr = $"SELECT * FROM {giaoDichHeader} WHERE {giaoDichLoai}=N'{loai}' AND {nguoiDungID}='{gd.IdNguoiDung}'";
            List<string> t = dbConnection.LayDanhSachMotDoiTuong(sqlStr, $"{giaoDichSoTien}");
            return t;
        }

        public void NapTienVaoTaiKhoan(string id, string tien)
        {
            string sqlStr = $"UPDATE {nguoiDungHeader} SET {nguoiDungTien}='{tien}' WHERE {nguoiDungID}='{id}'";
            dbConnection.ThucThi(sqlStr);
        }

        public List<List<string>> TimKiemGiaoDichBangId(string idNguoiDung)
        {
            string sqlStr = $"SELECT {giaoDichID}, {giaoDichLoai},{giaoDichSoTien},{giaoDichTuNguon},{giaoDichDenNguon},{giaoDichNgay} FROM {giaoDichHeader} WHERE {nguoiDungID}= '{idNguoiDung}' ";
            return dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr);
        }
    }
}

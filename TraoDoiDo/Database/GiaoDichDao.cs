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
            string sqlStr = $"SELECT {giaoDichSoTien} FROM {giaoDichHeader} WHERE {giaoDichLoai}='{loai}' AND {nguoiDungID}='{gd.IdNguoiDung}'";
            return dbConnection.LayDanhSach<string>(sqlStr);
        }
    }
}

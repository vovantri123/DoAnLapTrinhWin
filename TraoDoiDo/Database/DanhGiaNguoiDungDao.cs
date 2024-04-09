using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraoDoiDo.Models;

namespace TraoDoiDo.Database
{
    public class DanhGiaNguoiDungDao:ThuocTinhDao
    {
        public List<string> timTenNguoiDangVaNhanXet(string idNguoi)
        {
            string sqlStr = $@"
                    SELECT {nguoiDungTen}, COUNT({danhGiaNhanXet}) as SLNhanXet
                    FROM {nguoiDungHeader}
                    INNER JOIN {danhGiaHeader} ON {nguoiDungHeader}.{nguoiDungID} = {danhGiaHeader}.{quanLyIdNguoiDang}
                    GROUP BY {nguoiDungID},{nguoiDungTen}
                    HAVING {nguoiDungID} = '{idNguoi}' ";
            return dbConnection.LayDanhSach<string>(sqlStr);
        }
        public void Xoa(DanhGiaNguoiDung danhGiaNguoiDung)
        {
            string sqlStr = $@" DELETE {danhGiaHeader} WHERE {sanPhamIdNguoiDang} = {danhGiaNguoiDung.IdNguoiDang} AND {danhGiaIdNguoiMua} = {danhGiaNguoiDung.IdNguoiMua}";
            dbConnection.ThucThi(sqlStr);
        }
        public void Them(DanhGiaNguoiDung danhGiaNguoiDung)
        {
            string sqlStr = $@" INSERT INTO {danhGiaHeader} ({sanPhamIdNguoiDang}, {danhGiaIdNguoiMua} ,{danhGiaSoSao}, {danhGiaNhanXet})  
                                        VALUES ({danhGiaNguoiDung.IdNguoiDang}, {danhGiaNguoiDung.IdNguoiMua}, N'{danhGiaNguoiDung.SoSao}', N'{danhGiaNguoiDung.NhanXet}')";
            dbConnection.ThucThi(sqlStr);
        }
    }
}

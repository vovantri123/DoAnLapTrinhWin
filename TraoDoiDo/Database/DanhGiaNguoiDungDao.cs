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
        public List<List<string>> TinhSoSao(string idNguoiDang)
        {
            string sqlStr = $@"
            SELECT {danhGiaSoSao}, COUNT({danhGiaIdNguoiMua}) 
            FROM {danhGiaHeader}
            WHERE {sanPhamIdNguoiDang}= '{idNguoiDang}'
            GROUP BY {danhGiaSoSao} ";
            return dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr);
        }
        public List<List<string>> LoadThongTinNguoiDang(string idNguoiDang)
        {
            string sqlStr = $@" 
                SELECT distinct {nguoiDungTen}, {nguoiDungSdt}, {nguoiDungEmail}, {nguoiDungDiaChi}, {nguoiDungHeader}.{nguoiDungAnh} 
                FROM {danhGiaHeader}
                INNER JOIN {nguoiDungHeader} ON {danhGiaHeader}.{sanPhamIdNguoiDang} = {nguoiDungHeader}.{nguoiDungID} 
                WHERE {danhGiaHeader}.{sanPhamIdNguoiDang} =  '{idNguoiDang}'
                ";
            return dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr);
        }
        public List<List<string>> LoadDanhSachDanhGia(string idNguoiDang)
        {
            string sqlStr = $@" 
                SELECT {nguoiDungHeader}.{nguoiDungTen}, {danhGiaHeader}.{danhGiaSoSao}, {danhGiaHeader}.{danhGiaNhanXet}, {nguoiDungHeader}.{nguoiDungAnh} 
                FROM {danhGiaHeader}
                INNER JOIN {nguoiDungHeader} ON {danhGiaHeader}.{danhGiaIdNguoiMua} = {nguoiDungHeader}.{nguoiDungID} 
                WHERE {danhGiaHeader}.{sanPhamIdNguoiDang} = '{idNguoiDang}' ";
            return dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr); 
        }
    }
}

using MaterialDesignThemes.Wpf;
using System.Windows.Controls.Primitives;
using System.Collections.Generic;
using TraoDoiDo.Models;
namespace TraoDoiDo.Database
{
    public class MoTaHangHoaDao : ThuocTinhDao
    {
        public void Them(MoTaHangHoa moTa)
        {
            string sqlStr = $@" INSERT INTO {moTaSanPhamHeader} ({sanPhamID}, {moTaSanPhamIdAnh} ,{moTaSanPhamLinkAnh}, {moTaSanPhamMoTa})  
                                        VALUES ('{moTa.IddSanPham}', '{moTa.IdAnhMinhHoa}','{moTa.LinkAnh}', N'{moTa.MoTa}')";
            dbConnection.ThucThi(sqlStr);
        }
        public void Xoa(MoTaHangHoa moTa)
        {
            string sqlStr = $"DELETE FROM {moTaSanPhamHeader} WHERE {sanPhamID} = '{moTa.IddSanPham}' ";
            dbConnection.ThucThi(sqlStr);
        }

        public List<List<string>> TimKiemBangId(string id)
        {
            string sqlStr = $"SELECT {moTaSanPhamHeader}.{moTaSanPhamLinkAnh}, {moTaSanPhamHeader}.{moTaSanPhamMoTa} FROM {sanPhamHeader} INNER JOIN {moTaSanPhamHeader}"+
                       $" ON {sanPhamHeader}.{sanPhamID} = {moTaSanPhamHeader}.{sanPhamID} WHERE {sanPhamHeader}.{sanPhamID} = '{id}' ";
            return dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr);
        }
    }
}

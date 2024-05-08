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
            string sqlStr = $@" 
                INSERT INTO {moTaSanPhamHeader} ({sanPhamID}, {moTaSanPhamIdAnh} ,{moTaSanPhamLinkAnh}, {moTaSanPhamMoTa})   
                VALUES ('{moTa.IddSanPham}', '{moTa.IdAnhMinhHoa}','{moTa.LinkAnh}', N'{moTa.MoTa}')
            ";
            dbConnection.ThucThi(sqlStr);
        }

        public void Xoa(string idSanPham)
        {
            string sqlStr = $@"
                DELETE FROM {moTaSanPhamHeader} 
                WHERE {sanPhamID} = '{idSanPham}' 
            ";
            dbConnection.ThucThi(sqlStr);
        }

        public List<MoTaHangHoa> TimKiemDanhSachAnhVaMoTaBangId(string idSanPham)
        {
            string sqlStr = $@"
                SELECT {moTaSanPhamHeader}.{moTaSanPhamLinkAnh}, {moTaSanPhamHeader}.{moTaSanPhamMoTa} 
                FROM {sanPhamHeader} 
                INNER JOIN {moTaSanPhamHeader} ON {sanPhamHeader}.{sanPhamID} = {moTaSanPhamHeader}.{sanPhamID} 
                WHERE {sanPhamHeader}.{sanPhamID} = '{idSanPham}' 
            "; 
            List<MoTaHangHoa> dsMoTaHangHoa = new List<MoTaHangHoa>();
            List<List<string>> bangKetQua = dbConnection.LayNhieuDongDuLieu<string>(sqlStr);

            foreach (var dong in bangKetQua) 
                dsMoTaHangHoa.Add(new MoTaHangHoa(null, null, dong[0], dong[1])); 
            return dsMoTaHangHoa;
        } 
    }
}

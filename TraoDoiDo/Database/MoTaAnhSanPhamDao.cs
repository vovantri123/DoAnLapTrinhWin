using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraoDoiDo.Models;

namespace TraoDoiDo.Database
{
    public class MoTaAnhSanPhamDao:ThuocTinhDao
    {
        List<MoTaAnhSanPham> dsMoTaAnhSanPham;
        List<List<string>> bangKetQua;

        public void Them(MoTaAnhSanPham moTaAnhSp)
        { 
            string sqlStr = $" INSERT INTO {moTaSanPhamHeader} ({sanPhamID}, {moTaSanPhamIdAnh} ,{moTaSanPhamLinkAnh}, {moTaSanPhamMoTa}) "+  
                            $" VALUES ('{moTaAnhSp.IdSanPham}', '{moTaAnhSp.IdAnhMinhHoa}','{moTaAnhSp.LinkAnhMinhHoa}', N'{moTaAnhSp.MoTa}') ";
            dbConnection.ThucThi(sqlStr);
        }

        public void Xoa(MoTaAnhSanPham moTaAnhSp)
        {
            string sqlStr = $"DELETE FROM {moTaSanPhamHeader} WHERE {sanPhamID} = {moTaAnhSp.IdSanPham}";
            dbConnection.ThucThi(sqlStr);
        }

        public List<MoTaAnhSanPham> LoadAnhVaMoTa(SanPham sp)
        {
            string sqlStr = $@"
                        SELECT {sanPhamHeader}.{sanPhamAnh}, {moTaSanPhamHeader}.{moTaSanPhamLinkAnh}, {moTaSanPhamHeader}.{moTaSanPhamMoTa} 
                        FROM {sanPhamHeader} INNER JOIN {moTaSanPhamHeader} 
                        ON {sanPhamHeader}.{sanPhamID} = {moTaSanPhamHeader}.{sanPhamID}
                        WHERE {sanPhamHeader}.{sanPhamID} = '{sp.Id}'
                    ";
            dsMoTaAnhSanPham = new List<MoTaAnhSanPham>();
            bangKetQua = dbConnection.LayNhieuDongDuLieu<string>(sqlStr);
            foreach (var dong in bangKetQua)
                dsMoTaAnhSanPham.Add(new MoTaAnhSanPham(null, null, dong[0], dong[1], dong[2]));
            return dsMoTaAnhSanPham;
        }

    }
}

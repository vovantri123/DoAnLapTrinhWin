using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraoDoiDo.Models;

namespace TraoDoiDo.Database
{
    public class DanhMucYeuThichDao:ThuocTinhDao
    {
        public void Them(DanhMucYeuThich danhMuc)
        {
            string sqlStr = $@"
                INSERT INTO {danhMucHeader} ({danhMucIdNguoiMua},{danhMucIdSanPham})  
                VALUES ('{danhMuc.IdNguoiMua}', '{danhMuc.IdSanPham}')
            ";
            dbConnection.ThucThi(sqlStr);
        }

        public void Xoa(DanhMucYeuThich danhMuc)
        {
            string sqlStr = $@" 
                DELETE FROM {danhMucHeader} 
                WHERE {danhMucIdNguoiMua} = '{danhMuc.IdNguoiMua}' AND {danhMucIdSanPham} = '{danhMuc.IdSanPham}'
            ";
            dbConnection.ThucThi(sqlStr);
        }
    }
}

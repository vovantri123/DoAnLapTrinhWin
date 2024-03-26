using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraoDoiDo
{
    public class XuLyAnh
    {
        public static string layDuongDanToiHinhSanPham()
        {
            string thuMucHienTai = AppDomain.CurrentDomain.BaseDirectory; // Debug
            string thuMucLui1 = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(thuMucHienTai)); //Bin
            string thuMucLui2 = System.IO.Path.GetDirectoryName(thuMucLui1); //TraoDoiDo
            string thuMucHinhSanPham = System.IO.Path.Combine(thuMucLui2, "MyResources", "Hinh", "HinhSanPham");
            return thuMucHinhSanPham;
        }
        public static string layDuongDanDayDuToiFileAnh(string tenFileAnh)
        {
            string thuMucHinhSanPham = layDuongDanToiHinhSanPham();
            return System.IO.Path.Combine(thuMucHinhSanPham, tenFileAnh);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TraoDoiDo.Database
{
    public abstract class ThuocTinhDao
    {
        protected const string taiKhoanHeader = "TaiKhoan";
        public const string taiKhoanTenDangNhap = "TenDangNhap";
        public const string taiKhoanMatKhau = "MatKhau";
        public const string taiKhoanIdNguoiDung = "IdNguoiDung";

        protected const string nguoiDungHeader = "KhachHang";
        public const string nguoiDungID = "IdNguoiDung";
        public const string nguoiDungTen = "HoTenNguoiDung";
        public const string nguoiDungGioiTinh = "GioiTinhNguoiDung";
        public const string nguoiDungNgaySinh = "NgaySinhNguoiDung";
        public const string nguoiDungCMND = "CMNDNguoiDung";
        public const string nguoiDungEmail = "EmailNguoiDung";
        public const string nguoiDungSdt = "SdtNguoiDung";
        public const string nguoiDungDiaChi = "DiaChiNguoiDung";
        public const string nguoiDungAnh = "AnhNguoiDung";

        protected DbConnection dbConnection = new DbConnection();
    }
}

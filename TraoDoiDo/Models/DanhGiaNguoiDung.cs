using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraoDoiDo.Models
{
    public class DanhGiaNguoiDung
    {
        private string idNguoiDang;
        private string idNguoiMua;
        private string soSao;
        private string nhanXet;
        public DanhGiaNguoiDung() { }
        public DanhGiaNguoiDung(string idNguoiDang, string idNguoiMua, string soSao, string nhanXet)
        {
            this.IdNguoiDang = idNguoiDang;
            this.IdNguoiMua = idNguoiMua;
            this.SoSao = soSao;
            this.NhanXet = nhanXet;
        }

        public string IdNguoiDang { get => idNguoiDang; set => idNguoiDang = value; }
        public string IdNguoiMua { get => idNguoiMua; set => idNguoiMua = value; }
        public string SoSao { get => soSao; set => soSao = value; }
        public string NhanXet { get => nhanXet; set => nhanXet = value; }
    }
}

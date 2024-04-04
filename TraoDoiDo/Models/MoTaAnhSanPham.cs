using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraoDoiDo.Models
{
    public class MoTaAnhSanPham
    {
        private string idSanPham ="";
        private string idAnhMinhHoa = "";
        private string linkAnhMinhHoa = "";
        private string moTa = "";
        public MoTaAnhSanPham() { }
        public MoTaAnhSanPham(string idSanPham, string idAnhMinhHoa, string linkAnhMinhHoa, string moTa)
        {
            this.IdSanPham = idSanPham;
            this.IdAnhMinhHoa = idAnhMinhHoa;
            this.LinkAnhMinhHoa = linkAnhMinhHoa;
            this.moTa = moTa;
        }

        public string IdSanPham { get => idSanPham; set => idSanPham = value; }
        public string IdAnhMinhHoa { get => idAnhMinhHoa; set => idAnhMinhHoa = value; }
        public string LinkAnhMinhHoa { get => linkAnhMinhHoa; set => linkAnhMinhHoa = value; }
        public string MoTa { get => moTa; set => moTa = value; }
    }
}

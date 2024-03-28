using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraoDoiDo.Models
{
    public class MoTaHangHoa
    {
        private string id = "";
        private string ten = "";
        private List<string> anh = new List<string>();
        private List<string> moTa = new List<string>();

        public string Id { get => id; set => id = value; }
        public string Ten { get => ten; set => ten = value; }
        public List<string> Anh { get => anh; set => anh = value; }
        public List<string> MoTa { get => moTa; set => moTa = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUYEN_TAP_SO_4
{
    class VaccineVN : Vaccine
    {
        private string quocGia;

        public string QuocGia { get { return quocGia; } set { quocGia = value; } }

        public VaccineVN() : base() { }

        public VaccineVN(string maVC, string tenVC, float thoiGianTacDung, string ngayHetHan, string quocGia)
            : base(maVC, tenVC, thoiGianTacDung, ngayHetHan)
        {
            this.quocGia = quocGia;
        }

        public override void InThongTin()
        {
            base.InThongTin();
            Console.WriteLine("Quốc gia: " + quocGia);
        }
    }
}

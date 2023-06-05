using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_NAMFPT
{
    class CayAnQua : Cay
    {
        private int SoQua;

        public CayAnQua() : base()
        {
            SoQua = 0;
        }

        public CayAnQua(int id, string loaiCay, string ten, double chieuCao, int soQua) : base(id, loaiCay, ten, chieuCao)
        {
            SoQua = soQua;
        }

        public new void InThongTin()
        {
            base.InThongTin();
            Console.WriteLine($"SoQua: {SoQua}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUYEN_TAP_SO_3
{
    class BanhTrungThu : BanhKeo
    {
        private string nhanBanh;

        public BanhTrungThu(int code, string tenBK, string tenHangSX, int soLuong, double gia, bool trangThai, string nhanBanh)
            : base(code, tenBK, tenHangSX, soLuong, gia, trangThai)
        {
            this.nhanBanh = nhanBanh;
        }

        public string NhanBanh { get { return nhanBanh; } set { nhanBanh = value; } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUYEN_TAP_SO_3
{
    class BanhKeo
    {
        private int code;
        private string tenBK;
        private string tenHangSX;
        private int soLuong;
        private double gia;
        private bool trangThai;

        public BanhKeo(int code, string tenBK, string tenHangSX, int soLuong, double gia, bool trangThai)
        {
            this.code = code;
            this.tenBK = tenBK;
            this.tenHangSX = tenHangSX;
            this.soLuong = soLuong;
            this.gia = gia;
            this.trangThai = trangThai;
        }

        public int Code { get { return code; } set { code = value; } }
        public string TenBK { get { return tenBK; } set { tenBK = value; } }
        public string TenHangSX { get { return tenHangSX; } set { tenHangSX = value; } }
        public int SoLuong { get { return soLuong; } set { soLuong = value; } }
        public double Gia { get { return gia; } set { gia = value; } }
        public bool TrangThai { get { return trangThai; } set { trangThai = value; } }

        public void InThongTin()
        {
            Console.WriteLine($"Mã: {code}");
            Console.WriteLine($"Tên: {tenBK}");
            Console.WriteLine($"Hãng SX: {tenHangSX}");
            Console.WriteLine($"Số lượng: {soLuong}");
            Console.WriteLine($"Giá: {gia}");
            Console.WriteLine($"Trạng thái: {(trangThai ? "Còn hạn" : "Hết hạn")}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUYEN_TAP_SO_4
{
    class Vaccine
    {
        private string maVC;
        private string tenVC;
        private float thoiGianTacDung;
        private string ngayHetHan;

        public string MaVC { get { return maVC; } set { maVC = value; } }
        public string TenVC { get { return tenVC; } set { tenVC = value; } }
        public float ThoiGianTacDung { get { return thoiGianTacDung; } set { thoiGianTacDung = value; } }
        public string NgayHetHan { get { return ngayHetHan; } set { ngayHetHan = value; } }

        public Vaccine() { }

        public Vaccine(string maVC, string tenVC, float thoiGianTacDung, string ngayHetHan)
        {
            this.maVC = maVC;
            this.tenVC = tenVC;
            this.thoiGianTacDung = thoiGianTacDung;
            this.ngayHetHan = ngayHetHan;
        }

        public virtual void InThongTin()
        {
            Console.WriteLine("Mã vaccine: " + maVC);
            Console.WriteLine("Tên vaccine: " + tenVC);
            Console.WriteLine("Thời gian tác dụng: " + thoiGianTacDung + " tháng");
            Console.WriteLine("Ngày hết hạn: " + ngayHetHan);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_VIETSENS
{
    [Serializable]
    public class SinhVien
    {
        public DateTime ThoiGian { get; set; }
        public string MaSinhVien { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DoiTuong { get; set; }
        public double? DiemToan { get; set; }
        public double? DiemVan { get; set; }
        public double? DiemAnh { get; set; }
        public string GhiChu { get; set; }
        public bool IsSelected { get; set; }
        public bool Selected { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_VIETSENS
{
    class ServicesSinhVien
    {
        private List<SinhVien> listSinhVien = new List<SinhVien>();
        public ServicesSinhVien()
        {
            listSinhVien = new List<SinhVien>();
        }

        public string addSinhVien(SinhVien sinhVien)
        {
            if (sinhVien == null) return "Thêm thất bại";
            listSinhVien.Add(sinhVien);
            return "Thêm thành công";
        }

        public SinhVien findSinhVienByMaSinhVien(int MaSinhVien)
        {
            throw new NotImplementedException();
        }

        public List<SinhVien> getlstSinhVien()
        {
            throw new NotImplementedException();
        }

        public string removeSinhVien(int MaSinhVien)
        {
            throw new NotImplementedException();
        }

        public string updateSinhVien(SinhVien sinhVien)
        {
            throw new NotImplementedException();
        }
    }
}

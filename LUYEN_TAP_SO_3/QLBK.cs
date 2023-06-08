using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUYEN_TAP_SO_3
{
    class QLBK
    {
        private List<BanhKeo> danhSachBanhKeo;

        public QLBK()
        {
            danhSachBanhKeo = new List<BanhKeo>();
        }

        public void NhapDanhSachBanhKeo()
        {
            string tiepTuc;
            do
            {
                Console.WriteLine("Nhập thông tin bánh kẹo:");
                Console.Write("Mã: ");
                int code = int.Parse(Console.ReadLine());
                Console.Write("Tên: ");
                string tenBK = Console.ReadLine();
                Console.Write("Hãng SX: ");
                string tenHangSX = Console.ReadLine();
                Console.Write("Số lượng: ");
                int soLuong = int.Parse(Console.ReadLine());
                Console.Write("Giá: ");
                double gia = double.Parse(Console.ReadLine());
                Console.Write("Trạng thái (1- Còn hạn, 0- Hết hạn): ");
                bool trangThai = int.Parse(Console.ReadLine()) == 1;

                BanhKeo banhKeo = new BanhKeo(code, tenBK, tenHangSX, soLuong, gia, trangThai);
                danhSachBanhKeo.Add(banhKeo);

                Console.Write("Tiếp tục nhập (Y/N)? ");
                tiepTuc = Console.ReadLine();
            } while (tiepTuc.ToUpper() == "Y");
        }

        public void XuatDanhSachBanhKeo()
        {
            foreach (BanhKeo banhKeo in danhSachBanhKeo)
            {
                banhKeo.InThongTin();
                Console.WriteLine();
            }
        }

        public void XuatDanhSachBanhKeoConHanSuDung()
        {
            foreach (BanhKeo banhKeo in danhSachBanhKeo)
            {
                if (banhKeo.TrangThai)
                {
                    banhKeo.InThongTin();
                    Console.WriteLine();
                }
            }
        }

        public void SapXepGiamDanTheoSoLuong()
        {
            danhSachBanhKeo.Sort((a, b) => b.SoLuong.CompareTo(a.SoLuong));
        }

        public void SapXepTangDanTheoTenHangSX()
        {
            danhSachBanhKeo.Sort((a, b) => a.TenHangSX.CompareTo(b.TenHangSX));
        }

        public void TimKiemTheoCode(int code)
        {
            bool timThay = false;
            foreach (BanhKeo banhKeo in danhSachBanhKeo)
            {
                if (banhKeo.Code == code)
                {
                    banhKeo.InThongTin();
                    timThay = true;
                    break;
                }
            }
            if (!timThay)
            {
                Console.WriteLine("Không tìm thấy bánh kẹo có mã này.");
            }
        }

        public void XuatDanhSachBanhKeoBatDauBangC()
        {
            foreach (BanhKeo banhKeo in danhSachBanhKeo)
            {
                if (banhKeo.TenBK.StartsWith("C"))
                {
                    banhKeo.InThongTin();
                    Console.WriteLine();
                }
            }
        }

        public void XoaBanhKeoTheoCode(int code)
        {
            BanhKeo banhKeoTimThay = null;
            foreach (BanhKeo banhKeo in danhSachBanhKeo)
            {
                if (banhKeo.Code == code)
                {
                    banhKeoTimThay = banhKeo;
                    break;
                }
            }
            if (banhKeoTimThay != null)
            {
                danhSachBanhKeo.Remove(banhKeoTimThay);
                Console.WriteLine("Đã xóa bánh kẹo có mã {0}", code);
            }
            else
            {
                Console.WriteLine("Không tìm thấy bánh kẹo có mã này.");
            }
        }

        public void XuatDanhSachBanhKeoCoSoLuongLonHonHoacBang50()
        {
            foreach (BanhKeo banhKeo in danhSachBanhKeo)
            {
                if (banhKeo.SoLuong >= 50)
                {
                    banhKeo.InThongTin();
                    Console.WriteLine();
                }
            }
        }

        public void CapNhatTrangThaiBanhKeoTheoCode(int code)
        {
            bool timThay = false;
            foreach (BanhKeo banhKeo in danhSachBanhKeo)
            {
                if (banhKeo.Code == code)
                {
                    banhKeo.TrangThai = !banhKeo.TrangThai;
                    timThay = true;
                    Console.WriteLine("Đã cập nhật trạng thái của bánh kẹo có mã {0}", code);
                    break;
                }
            }
            if (!timThay)
            {
                Console.WriteLine("Không tìm thấy bánh kẹo có mã này.");
            }
        }

        public BanhKeo TimBanhKeoGiaLonNhat()
        {
            BanhKeo banhKeoGiaLonNhat = danhSachBanhKeo[0];
            foreach (BanhKeo banhKeo in danhSachBanhKeo)
            {
                if (banhKeo.Gia > banhKeoGiaLonNhat.Gia)
                {
                    banhKeoGiaLonNhat = banhKeo;
                }
            }
            return banhKeoGiaLonNhat;
        }
    }
}

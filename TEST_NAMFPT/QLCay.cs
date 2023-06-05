using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_NAMFPT
{
    class QLCay
    {
        private List<Cay> danhSachCay;

        public QLCay()
        {
            danhSachCay = new List<Cay>();
        }

        public void NhapDanhSachCay()
        {
            do
            {
                Console.WriteLine("Nhap thong tin cay:");
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("LoaiCay: ");
                string loaiCay = Console.ReadLine();
                Console.Write("Ten: ");
                string ten = Console.ReadLine();
                Console.Write("ChieuCao: ");
                double chieuCao = double.Parse(Console.ReadLine());

                Cay cay = new Cay(id, loaiCay, ten, chieuCao);
                danhSachCay.Add(cay);

                Console.Write("Ban co muon tiep tuc nhap khong? (Y/N): ");
            } while (Console.ReadLine().ToUpper() == "Y");
        }

        public void XuatDanhSachCay()
        {
            foreach (Cay cay in danhSachCay)
            {
                cay.InThongTin();
            }
        }

        public void XuatCayBatDauBangD()
        {
            foreach (Cay cay in danhSachCay)
            {
                //if (cay.GetTen().StartsWith("D"))
                //{
                //    cay.InThongTin();
                //}
            }
        }

        public void XuatCayChieuCaoTren5Met()
        {
            foreach (Cay cay in danhSachCay)
            {
                if (cay.GetChieuCao() > 5)
                {
                    cay.InThongTin();
                }
            }
        }

        public void XoaCayTheoID(int id)
        {
            for (int i = 0; i < danhSachCay.Count; i++)
            {
                if (danhSachCay[i].GetID() == id)
                {
                    danhSachCay.RemoveAt(i);
                    Console.WriteLine("Da xoa cay co ID: " + id);
                    return;
                }
            }

            Console.WriteLine("Khong tim thay cay co ID: " + id);
        }

        public void SapXepGiamDanTheoID()
        {
            danhSachCay.Sort((cay1, cay2) => cay2.GetID().CompareTo(cay1.GetID()));
            Console.WriteLine("Danh sach da sap xep giam dan theo ID:");
            XuatDanhSachCay();
        }

        public void SapXepTangDanTheoChieuCao()
        {
            danhSachCay.Sort((cay1, cay2) => cay1.GetChieuCao().CompareTo(cay2.GetChieuCao()));
            Console.WriteLine("Danh sach da sap xep tang dan theo chieu cao:");
            XuatDanhSachCay();
        }
    }
}

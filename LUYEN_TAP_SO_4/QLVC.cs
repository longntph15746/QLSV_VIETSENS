using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUYEN_TAP_SO_4
{
    class QLVC
    {
        private List<Vaccine> danhSachVaccine;

        public QLVC()
        {
            danhSachVaccine = new List<Vaccine>();
        }

        public void NhapDanhSachVaccine()
        {
            string tiepTuc;
            do
            {
                Console.WriteLine("Nhập thông tin vaccine:");
                Console.Write("Mã vaccine: ");
                string maVC = Console.ReadLine();
                Console.Write("Tên vaccine: ");
                string tenVC = Console.ReadLine();
                Console.Write("Thời gian tác dụng (tháng): ");
                float thoiGianTacDung = float.Parse(Console.ReadLine());
                Console.Write("Ngày hết hạn: ");
                string ngayHetHan = Console.ReadLine();

                Console.WriteLine("Loại vaccine (1. Vaccine VN, 2. Vaccine khác): ");
                int loaiVaccine = int.Parse(Console.ReadLine());
                if (loaiVaccine == 1)
                {
                    Console.Write("Quốc gia: ");
                    string quocGia = Console.ReadLine();
                    VaccineVN vaccineVN = new VaccineVN(maVC, tenVC, thoiGianTacDung, ngayHetHan, quocGia);
                    danhSachVaccine.Add(vaccineVN);
                }
                else
                {
                    Vaccine vaccine = new Vaccine(maVC, tenVC, thoiGianTacDung, ngayHetHan);
                    danhSachVaccine.Add(vaccine);
                }

                Console.Write("Tiếp tục nhập (y/n)? ");
                tiepTuc = Console.ReadLine();
            } while (tiepTuc.ToLower() == "y");
        }

        public void XuatDanhSachVaccine()
        {
            if (danhSachVaccine.Count == 0)
            {
                Console.WriteLine("Danh sách vaccine rỗng.");
            }
            else
            {
                Console.WriteLine("Danh sách vaccine:");
                foreach (var vaccine in danhSachVaccine)
                {
                    vaccine.InThongTin();
                    Console.WriteLine("--------------------");
                }
            }
        }

        public void XuatDanhSachVaDemVaccineCoThoiGianTacDungLonHon6Thang()
        {
            int dem = 0;
            Console.WriteLine("Danh sách vaccine có thời gian tác dụng lớn hơn hoặc bằng 6 tháng:");
            foreach (var vaccine in danhSachVaccine)
            {
                if (vaccine.ThoiGianTacDung >= 6)
                {
                    vaccine.InThongTin();
                    Console.WriteLine("--------------------");
                    dem++;
                }
            }
            Console.WriteLine("Tổng số vaccine có thời gian tác dụng lớn hơn hoặc bằng 6 tháng: " + dem);
        }

        public void SapXepGiamDanTheoThoiGianTacDung()
        {
            danhSachVaccine.Sort((x, y) => y.ThoiGianTacDung.CompareTo(x.ThoiGianTacDung));
            Console.WriteLine("Đã sắp xếp danh sách vaccine giảm dần theo thời gian tác dụng.");
        }

        public void XuatDanhSachVaccineCoMaChuaVN()
        {
            Console.WriteLine("Danh sách vaccine có mã chứa 'VN':");
            foreach (var vaccine in danhSachVaccine)
            {
                if (vaccine.MaVC.Contains("VN"))
                {
                    vaccine.InThongTin();
                    Console.WriteLine("--------------------");
                }
            }
        }

        public void TimViTriVaccineCoThoiGianTacDungNhoNhat()
        {
            if (danhSachVaccine.Count == 0)
            {
                Console.WriteLine("Danh sách vaccine rỗng.");
            }
            else
            {
                int viTriMin = 0;
                float thoiGianTacDungMin = danhSachVaccine[0].ThoiGianTacDung;
                for (int i = 1; i < danhSachVaccine.Count; i++)
                {
                    if (danhSachVaccine[i].ThoiGianTacDung < thoiGianTacDungMin)
                    {
                        thoiGianTacDungMin = danhSachVaccine[i].ThoiGianTacDung;
                        viTriMin = i;
                    }
                }
                Console.WriteLine("Vaccine có thời gian tác dụng nhỏ nhất:");
                danhSachVaccine[viTriMin].InThongTin();
            }
        }

        public void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("\n----- MENU -----");
                Console.WriteLine("1. Nhập danh sách vaccine");
                Console.WriteLine("2. Xuất danh sách vaccine");
                Console.WriteLine("3. Xuất danh sách và đếm các vaccine có thời gian tác dụng >= 6 tháng");
                Console.WriteLine("4. Sắp xếp giảm dần theo thời gian tác dụng");
                Console.WriteLine("5. Xuất danh sách vaccine có mã chứa 'VN'");
                Console.WriteLine("6. Tìm vị trí vaccine có thời gian tác dụng nhỏ nhất và in thông tin");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        NhapDanhSachVaccine();
                        break;
                    case 2:
                        XuatDanhSachVaccine();
                        break;
                    case 3:
                        XuatDanhSachVaDemVaccineCoThoiGianTacDungLonHon6Thang();
                        break;
                    case 4:
                        SapXepGiamDanTheoThoiGianTacDung();
                        break;
                    case 5:
                        XuatDanhSachVaccineCoMaChuaVN();
                        break;
                    case 6:
                        TimViTriVaccineCoThoiGianTacDungNhoNhat();
                        break;
                    case 0:
                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Chức năng không hợp lệ.");
                        break;
                }

            } while (choice != 0);
        }
    }
}

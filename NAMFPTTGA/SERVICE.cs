using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAMFPTTGA
{
    class SERVICE
    {
        private List<SanPham> danhSachSanPham;

        public SERVICE()
        {
            danhSachSanPham = new List<SanPham>();
        }

        public void NhapDanhSachSanPham()
        {
            do
            {
                Console.WriteLine("Nhap thong tin san pham:");
                Console.Write("Ten: ");
                string ten = Console.ReadLine();
                Console.Write("Gia: ");
                double gia;
                while (!double.TryParse(Console.ReadLine(), out gia))
                {
                    Console.WriteLine("Gia phai la mot so. Vui long nhap lai.");
                }
                Console.Write("So Luong: ");
                int soLuong;
                while (!int.TryParse(Console.ReadLine(), out soLuong))
                {
                    Console.WriteLine("So luong phai la mot so nguyen. Vui long nhap lai.");
                }

                SanPham sanPham = new SanPham(ten, gia, soLuong);
                danhSachSanPham.Add(sanPham);

                Console.Write("Ban co muon tiep tuc nhap khong? (Y/N): ");
            } while (Console.ReadLine().ToUpper() == "Y");
        }

        public void XuatDanhSachSanPham()
        {
            foreach (SanPham sanPham in danhSachSanPham)
            {
                sanPham.InThongTin();
            }
        }

        public void LuuFileDanhSachSanPham()
        {
            Console.Write("Nhap duong dan file: ");
            string filePath = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (SanPham sanPham in danhSachSanPham)
                    {
                        writer.WriteLine($"{sanPham.GetID()},{sanPham.Ten},{sanPham.Gia},{sanPham.SoLuong}");
                    }
                }
                Console.WriteLine("Luu file thanh cong!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }
        }

        public void DocFileDanhSachSanPham()
        {
            Console.Write("Nhap duong dan file: ");
            string filePath = Console.ReadLine();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 4)
                        {
                            Guid id;
                            if (Guid.TryParse(parts[0], out id))
                            {
                                string ten = parts[1];
                                double gia;
                                if (double.TryParse(parts[2], out gia))
                                {
                                    int soLuong;
                                    if (int.TryParse(parts[3], out soLuong))
                                    {
                                        SanPham sanPham = new SanPham(ten, gia, soLuong);
                                        danhSachSanPham.Add(sanPham);
                                    }
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("Doc file thanh cong!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }
        }

        public void TimSanPhamTheoTen(string keyword)
        {
            var results = danhSachSanPham.Where(sp => sp.Ten.ToLower().Contains(keyword.ToLower())).ToList();

            Console.WriteLine("Ket qua tim kiem:");
            foreach (SanPham sanPham in results)
            {
                sanPham.InThongTin();
            }
        }

        public void TimSanPhamGiaCaoNhat()
        {
            var sanPhamGiaCaoNhat = danhSachSanPham.OrderByDescending(sp => sp.Gia).FirstOrDefault();

            if (sanPhamGiaCaoNhat != null)
            {
                Console.WriteLine("San pham co gia cao nhat:");
                sanPhamGiaCaoNhat.InThongTin();
            }
        }
    }
}

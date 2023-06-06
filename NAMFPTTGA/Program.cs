using System;
namespace NAMFPTTGA
{
    class Program
    {


       
        static void Main(string[] args)
        {
            SERVICE service = new SERVICE();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Nhap danh sach doi tuong");
                Console.WriteLine("2. Xuat danh sach doi tuong");
                Console.WriteLine("3. Luu File danh sach doi tuong");
                Console.WriteLine("4. Doc File danh sach doi tuong");
                Console.WriteLine("5. Tim san pham theo ten");
                Console.WriteLine("6. Tim san pham co gia cao nhat");
                Console.WriteLine("0. Thoat");

                Console.Write("Chon chuc nang: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        service.NhapDanhSachSanPham();
                        break;
                    case 2:
                        service.XuatDanhSachSanPham();
                        break;
                    case 3:
                        service.LuuFileDanhSachSanPham();
                        break;
                    case 4:
                        service.DocFileDanhSachSanPham();
                        break;
                    case 5:
                        Console.Write("Nhap tu khoa tim kiem: ");
                        string keyword = Console.ReadLine();
                        service.TimSanPhamTheoTen(keyword);
                        break;
                    case 6:
                        service.TimSanPhamGiaCaoNhat();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }
            }
        }
    }
}

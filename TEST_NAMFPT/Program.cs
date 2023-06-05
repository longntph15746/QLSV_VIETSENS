using System;

namespace TEST_NAMFPT
{
    class Program
    {
        static void Main(string[] args)
        {
            QLCay qlCay = new QLCay();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Nhap danh sach doi tuong");
                Console.WriteLine("2. Xuat danh sach doi tuong");
                Console.WriteLine("3. Xuat danh sach cac cay co ten bat dau bang chu D");
                Console.WriteLine("4. Xuat danh sach cac cay co chieu cao tren 5 met");
                Console.WriteLine("5. Xoa doi tuong theo ID");
                Console.WriteLine("6. Sap xep danh sach doi tuong giam dan theo ID");
                Console.WriteLine("7. Sap xep danh sach doi tuong tang dan theo chieu cao");
                Console.WriteLine("0. Thoat");

                Console.Write("Chon chuc nang: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        qlCay.NhapDanhSachCay();
                        break;
                    case 2:
                        qlCay.XuatDanhSachCay();
                        break;
                    case 3:
                        qlCay.XuatCayBatDauBangD();
                        break;
                    case 4:
                        qlCay.XuatCayChieuCaoTren5Met();
                        break;
                    case 5:
                        Console.Write("Nhap ID cay can xoa: ");
                        int id = int.Parse(Console.ReadLine());
                        qlCay.XoaCayTheoID(id);
                        break;
                    case 6:
                        qlCay.SapXepGiamDanTheoID();
                        break;
                    case 7:
                        qlCay.SapXepTangDanTheoChieuCao();
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

using System;
using System;
using System.Collections.Generic;
namespace NamFPT
{
    public class Class1
    {


        class Cay
        {
            private int ID;
            private string LoaiCay;
            private string Ten;
            private double chieuCao;

            public Cay()
            {
                ID = 0;
                LoaiCay = "";
                Ten = "";
                chieuCao = 0;
            }

            public Cay(int id, string loaiCay, string ten, double chieuCao)
            {
                ID = id;
                LoaiCay = loaiCay;
                Ten = ten;
                this.chieuCao = chieuCao;
            }

            public int GetID()
            {
                return ID;
            }

            public void InThongTin()
            {
                Console.WriteLine($"ID: {ID}, LoaiCay: {LoaiCay}, Ten: {Ten}, chieuCao: {chieuCao}");
            }
        }

        class CayAnQua : Cay
        {
            private int SoQua;

            public CayAnQua() : base()
            {
                SoQua = 0;
            }

            public CayAnQua(int id, string loaiCay, string ten, double chieuCao, int soQua) : base(id, loaiCay, ten, chieuCao)
            {
                SoQua = soQua;
            }

            public new void InThongTin()
            {
                base.InThongTin();
                Console.WriteLine($"SoQua: {SoQua}");
            }
        }

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
                    if (cay.GetTen().StartsWith("D"))
                    {
                        cay.InThongTin();
                    }
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
}

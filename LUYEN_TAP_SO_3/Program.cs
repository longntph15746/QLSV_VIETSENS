using System;
using System.Text;

namespace LUYEN_TAP_SO_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            QLBK qlbk = new QLBK();
            int choice;

            do
            {
                Console.WriteLine("\n------------------");
                Console.WriteLine("MENU:");
                Console.WriteLine("1. Nhập danh sách đối tượng");
                Console.WriteLine("2. Xuất danh sách đối tượng");
                Console.WriteLine("3. Xuất danh sách các bánh kẹo còn hạn sử dụng");
                Console.WriteLine("4. Sắp xếp giảm dần theo số lượng");
                Console.WriteLine("5. Sắp xếp tăng dần theo tên hãng SX");
                Console.WriteLine("6. Tìm kiếm bánh kẹo theo mã");
                Console.WriteLine("7. Xuất danh sách bánh kẹo có tên bắt đầu bằng chữ 'C'");
                Console.WriteLine("8. Xóa bánh kẹo theo mã");
                Console.WriteLine("9. Xuất danh sách các bánh kẹo có số lượng >= 50");
                Console.WriteLine("10. Cập nhật trạng thái của bánh kẹo theo mã");
                Console.WriteLine("11. Tìm bánh kẹo có giá lớn nhất");
                Console.WriteLine("0. Thoát");
                Console.Write("Nhập lựa chọn: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        qlbk.NhapDanhSachBanhKeo();
                        break;
                    case 2:
                        qlbk.XuatDanhSachBanhKeo();
                        break;
                    case 3:
                        qlbk.XuatDanhSachBanhKeoConHanSuDung();
                        break;
                    case 4:
                        qlbk.SapXepGiamDanTheoSoLuong();
                        Console.WriteLine("Đã sắp xếp giảm dần theo số lượng.");
                        break;
                    case 5:
                        qlbk.SapXepTangDanTheoTenHangSX();
                        Console.WriteLine("Đã sắp xếp tăng dần theo tên hãng SX.");
                        break;
                    case 6:
                        Console.Write("Nhập mã bánh kẹo cần tìm: ");
                        int code = int.Parse(Console.ReadLine());
                        qlbk.TimKiemTheoCode(code);
                        break;
                    case 7:
                        qlbk.XuatDanhSachBanhKeoBatDauBangC();
                        break;
                    case 8:
                        Console.Write("Nhập mã bánh kẹo cần xóa: ");
                        int codeXoa = int.Parse(Console.ReadLine());
                        qlbk.XoaBanhKeoTheoCode(codeXoa);
                        break;
                    case 9:
                        qlbk.XuatDanhSachBanhKeoCoSoLuongLonHonHoacBang50();
                        break;
                    case 10:
                        Console.Write("Nhập mã bánh kẹo cần cập nhật trạng thái: ");
                        int codeCapNhat = int.Parse(Console.ReadLine());
                        qlbk.CapNhatTrangThaiBanhKeoTheoCode(codeCapNhat);
                        break;
                    case 11:
                        BanhKeo banhKeoGiaLonNhat = qlbk.TimBanhKeoGiaLonNhat();
                        Console.WriteLine("Bánh kẹo có giá lớn nhất:");
                        banhKeoGiaLonNhat.InThongTin();
                        break;
                    case 0:
                        Console.WriteLine("Đã thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }

            } while (choice != 0);
        }
    }
}

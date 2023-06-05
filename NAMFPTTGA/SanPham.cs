using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAMFPTTGA
{
    class SanPham
    {
        private Guid id;
        private string ten;
        private double gia;
        private int soLuong;

        public SanPham()
        {
            id = Guid.NewGuid();
            ten = "";
            gia = 0;
            soLuong = 0;
        }

        public SanPham(string ten, double gia, int soLuong)
        {
            id = Guid.NewGuid();
            this.ten = ten;
            this.gia = gia;
            this.soLuong = soLuong;
        }

        public Guid GetID()
        {
            return id;
        }

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        public double Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        public void InThongTin()
        {
            Console.WriteLine($"ID: {id}, Ten: {ten}, Gia: {gia}, SoLuong: {soLuong}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_NAMFPT
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

        internal object GetTen()
        {
            throw new NotImplementedException();
        }

        internal int GetChieuCao()
        {
            throw new NotImplementedException();
        }
    }

}

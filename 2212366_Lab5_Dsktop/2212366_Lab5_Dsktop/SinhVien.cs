using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2212366_Lab5_Dsktop
{
    internal class SinhVien

    {
        public string MSSV { get; set; }

        public string HoTen { get; set; }

        public int Tuoi { get; set; }

        public double Diem { get; set; }

        public bool TonGiao { get; set; }

        public SinhVien()
        {
            
        }

        public SinhVien(string ms, string ten, int tuoi, double diem, bool tongiao)
        {
            this.MSSV = ms;
            this.HoTen = ten;
            this.Tuoi = tuoi;
            this.Diem = diem;
            this.TonGiao = tongiao; 
        }

    }
}

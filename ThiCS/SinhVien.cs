using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiCS
{
    class SinhVien
    {
        private string _MSSV;
        private string _HoTen;
        private string _LopSH;
        private bool _GioiTinh;
        private DateTime _NgaySinh;
        private double _DiemTB;
        private bool _Anh;
        private bool _HocBa;
        private bool _CCNN;
        public string MSSV { get => _MSSV; set => _MSSV = value; }
        public string HoTen { get => _HoTen; set => _HoTen = value; }
        public string LopSH { get => _LopSH; set => _LopSH = value; }
        public bool GioiTinh { get => _GioiTinh; set => _GioiTinh = value; }
        public DateTime NgaySinh { get => _NgaySinh; set => _NgaySinh = value; }
        public double DiemTB { get => _DiemTB; set => _DiemTB = value; }
        public bool Anh { get => _Anh; set => _Anh = value; }
        public bool HocBa { get => _HocBa; set => _HocBa = value; }
        public bool CCNN { get => _CCNN; set => _CCNN = value; }
    }
}

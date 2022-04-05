using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiCS
{
    class QuanLySV
    {
        public List<SinhVien> GetAllSV()
        {
            List<SinhVien> data = new List<SinhVien>();
            foreach(DataRow i in DuLieuSV.Instance.DataSV.Rows)
            {
                data.Add(GetSVByDataRow(i));
            }
            return data;
        }
        public SinhVien GetSVByDataRow(DataRow i)
        {
            SinhVien sv = new SinhVien();
            sv.MSSV = i["MSSV"].ToString();
            sv.HoTen = i["Ho ten"].ToString();
            sv.LopSH = i["Lop SH"].ToString();
            sv.GioiTinh = Convert.ToBoolean(i["Gioi tinh"].ToString());
            sv.NgaySinh = Convert.ToDateTime(i["Ngay sinh"].ToString());
            sv.DiemTB = Convert.ToDouble(i["Diem trung binh"].ToString());
            sv.Anh = Convert.ToBoolean(i["Anh"].ToString());
            sv.HocBa = Convert.ToBoolean(i["Hoc ba"].ToString());
            sv.CCNN = Convert.ToBoolean(i["CC Ngoai ngu"].ToString());
            return sv;
        }
        public SinhVien GetSVByMSSV(string mssv)
        {
            SinhVien sv = new SinhVien();
            foreach(SinhVien i in GetAllSV())
            {
                if(i.MSSV == mssv)
                {
                    sv = i;
                    break;
                }
            }
            return sv;
        }
        public List<SinhVien> GetDSSV(string LSH, string search) // => Chức năng Show thì search = "", Chức năng Search thì search = 1 chuỗi
        {
            List<SinhVien> data = new List<SinhVien>();
            if(search == "") // => Chức năng Show
            {
                if (LSH == "All") data = GetAllSV(); // => cbbLopSH.SelectedItem = "All"
                else
                {
                    // => cbbLopSH.SelectedItem != "All"
                    foreach (SinhVien i in GetAllSV())
                    {
                        if (i.LopSH == LSH) data.Add(i); 
                    }
                }
            }
            else // => Chức năng Search (theo Họ tên SV)
            {
                if (LSH == "All")
                {
                    foreach(SinhVien i in GetAllSV())
                    {
                        if (i.HoTen.Contains(search)) data.Add(i);
                    }
                }
                else
                {
                    foreach (SinhVien i in GetAllSV())
                    {
                        if (i.LopSH == LSH && i.HoTen.Contains(search)) data.Add(i);
                    }
                }
            }
            return data;
        }
        public List<string> GetLopSH()
        {
            List<string> data = new List<string>();
            foreach(SinhVien i in GetAllSV())
            {
                data.Add(i.LopSH);
            }
            return data;
        }
        public void Execute(SinhVien s, string str)
        {
            if (str == null) DuLieuSV.Instance.AddSV(s);
            else DuLieuSV.Instance.UpdateSV(s);
        }
        public List<SinhVien> GetSVDTG(List<string> data)
        {
            List<SinhVien> LiSV = new List<SinhVien>();
            foreach(string i in data)
            {
                foreach(SinhVien j in GetAllSV())
                {
                    if (j.MSSV == i) LiSV.Add(j);
                }
            }
            return LiSV;
        }
        public List<SinhVien> Sort(List<string> data, string sort)
        {
            List<SinhVien> ListSort = GetSVDTG(data);
            if(sort.Equals("Diem trung binh")) ListSort.Sort(delegate (SinhVien sv1, SinhVien sv2) { return sv1.DiemTB.CompareTo(sv2.DiemTB); });
            else if(sort.Equals("Ho ten")) ListSort.Sort(delegate (SinhVien sv1, SinhVien sv2) { return sv1.HoTen.CompareTo(sv2.HoTen); });
            else if(sort.Equals("Ngay sinh")) ListSort.Sort(delegate (SinhVien sv1, SinhVien sv2) { return sv1.NgaySinh.CompareTo(sv2.NgaySinh); });
            return ListSort;
        }
    }
}

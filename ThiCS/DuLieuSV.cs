using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiCS
{
    class DuLieuSV
    {
        private static DuLieuSV _Instance;
        public static DuLieuSV Instance
        {
            get
            {
                if (_Instance == null) _Instance = new DuLieuSV();
                return _Instance;
            }
            private set { }
        }
        public DataTable DataSV;
        private DuLieuSV()
        {
            this.DataSV = new DataTable();
            this.DataSV.Columns.AddRange(new DataColumn[]{ 
                new DataColumn() {ColumnName = "MSSV", DataType = typeof(string)},
                new DataColumn() {ColumnName = "Ho ten", DataType = typeof(string)},
                new DataColumn() {ColumnName = "Lop SH", DataType = typeof(string)},
                new DataColumn() {ColumnName = "Gioi tinh", DataType = typeof(bool)},
                new DataColumn() {ColumnName = "Ngay sinh", DataType = typeof(DateTime)},
                new DataColumn() {ColumnName = "Diem trung binh", DataType = typeof(string)},
                new DataColumn() {ColumnName = "Anh", DataType = typeof(bool)},
                new DataColumn() {ColumnName = "Hoc ba", DataType = typeof(bool)},
                new DataColumn() {ColumnName = "CC Ngoai ngu", DataType = typeof(bool)}
            });
            this.DataSV.Rows.Add("101", "Tran Van A", "20T", true, new DateTime(2002, 12, 1), 9.0, true, true, true);
            this.DataSV.Rows.Add("102", "Nguyen Van B", "19T", true, new DateTime(2001, 2, 1), 8.0, false, false, true);
            this.DataSV.Rows.Add("103", "Le Thi C", "21T", false, new DateTime(2003, 1, 1), 7.5, true, false, true);
            this.DataSV.Rows.Add("104", "Nguyen Van D", "18T", true, new DateTime(1999, 3, 30), 6.0, true, true, false);
            this.DataSV.Rows.Add("105", "Le Van C", "20T", true, new DateTime(2002, 7, 2), 8.5, true, false, false);
            this.DataSV.Rows.Add("106", "Nguyen Thi H", "19T", false, new DateTime(2001, 4, 7), 7.0, true, true, false);
        }
        QuanLySV QL = new QuanLySV();
        public void AddSV(SinhVien sv)
        {
            bool t = true;
            foreach(SinhVien i in QL.GetAllSV())
            {
                if(i.MSSV == sv.MSSV)
                {
                    t = false;
                    break;
                }
            }
            if(t) this.DataSV.Rows.Add(sv.MSSV, sv.HoTen, sv.LopSH, sv.GioiTinh, sv.NgaySinh, sv.DiemTB, sv.Anh, sv.HocBa, sv.CCNN);
        }
        public void UpdateSV(SinhVien sv)
        {
            int index = 0;
            for(int i = 0; i < QL.GetAllSV().Count; i++)
            {
                if (QL.GetAllSV()[i].MSSV == sv.MSSV) index = i;
            }
            this.DataSV.Rows[index].SetField("Ho ten", sv.HoTen);
            this.DataSV.Rows[index].SetField("Lop SH", sv.LopSH);
            this.DataSV.Rows[index].SetField("Ngay sinh", sv.NgaySinh);
            this.DataSV.Rows[index].SetField("Gioi tinh", sv.GioiTinh);
            this.DataSV.Rows[index].SetField("Diem trung binh", sv.DiemTB);
            this.DataSV.Rows[index].SetField("Anh", sv.Anh);
            this.DataSV.Rows[index].SetField("Hoc ba", sv.HocBa);
            this.DataSV.Rows[index].SetField("CC Ngoai ngu", sv.CCNN);
        }
        public void DeleteDSSV(List<string> MSs)
        {
            foreach (string i in MSs)
            {
                for (int j = 0; j < this.DataSV.Rows.Count; j++)
                {
                    if (this.DataSV.Rows[j]["MSSV"].ToString() == i)
                    {
                        this.DataSV.Rows[j].Delete();
                        break;
                    }
                }
            }
            this.DataSV.AcceptChanges();
        }
    }
}

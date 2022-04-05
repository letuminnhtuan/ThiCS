using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiCS
{
    public partial class Detail : Form
    {
        public delegate void Del(string str1, string str2);
        QuanLySV QL = new QuanLySV();
        public Del d;
        private string MSSV { get; set; }
        public Detail(string mssv)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            foreach (string i in QL.GetLopSH().Distinct())
            {
                this.cbbLSH.Items.Add(i);
            }
            this.MSSV = mssv;
            SetGUI();
        }
        private void SetGUI()
        {
            if(this.MSSV != null)
            {
                this.txtMSSV.Text = QL.GetSVByMSSV(this.MSSV).MSSV;
                this.txtMSSV.Enabled = false;
                this.txtHoTen.Text = QL.GetSVByMSSV(this.MSSV).HoTen;
                this.cbbLSH.SelectedItem = QL.GetSVByMSSV(this.MSSV).LopSH;
                if (QL.GetSVByMSSV(this.MSSV).GioiTinh) this.radioMale.Checked = true;
                else this.radioFemale.Checked = true;
                this.dateTimePicker1.Value = QL.GetSVByMSSV(this.MSSV).NgaySinh;
                this.txtDiemTB.Text = QL.GetSVByMSSV(this.MSSV).DiemTB + "";
                this.checkAnh.Checked = QL.GetSVByMSSV(this.MSSV).Anh;
                this.checkHB.Checked = QL.GetSVByMSSV(this.MSSV).HocBa;
                this.checkCCNN.Checked = QL.GetSVByMSSV(this.MSSV).CCNN;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien sv = new SinhVien
                {
                    MSSV = this.txtMSSV.Text,
                    HoTen = this.txtHoTen.Text,
                    LopSH = this.cbbLSH.SelectedItem.ToString(),
                    GioiTinh = this.radioMale.Checked,
                    NgaySinh = this.dateTimePicker1.Value,
                    DiemTB = Convert.ToDouble(this.txtDiemTB.Text),
                    Anh = this.checkAnh.Checked,
                    HocBa = this.checkHB.Checked,
                    CCNN = this.checkCCNN.Checked
                };
                QL.Execute(sv, this.MSSV);
                d("All", "");
                this.Dispose();
            } catch(Exception ex)
            {
                MessageBox.Show("Không để trống thông tin sinh viên!");
            }
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

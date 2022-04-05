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
    public partial class Main : Form
    {
        QuanLySV QL = new QuanLySV();
        public Main()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            Create_CBB();
        }
        private void Create_CBB()
        {
            this.cbbLSH.Items.Add("All");
            foreach (string i in QL.GetLopSH().Distinct())
            {
                this.cbbLSH.Items.Add(i);
            }
            this.cbbLSH.SelectedItem = "All";
        }
        public void Show_Data(string str1, string str2)
        {
            this.dataSV.DataSource = QL.GetDSSV(str1, str2);
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            string LSH = this.cbbLSH.SelectedItem.ToString();
            string Search = this.txtSearch.Text;
            Show_Data(LSH, Search);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string LSH = this.cbbLSH.SelectedItem.ToString();
            string Search = this.txtSearch.Text;
            Show_Data(LSH, Search);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Detail form = new Detail(null);
            form.d = new Detail.Del(Show_Data);
            form.Show();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(this.dataSV.SelectedRows.Count == 1)
            {
                string mssv = this.dataSV.SelectedRows[0].Cells["MSSV"].Value.ToString();
                Detail form = new Detail(mssv);
                form.d = new Detail.Del(Show_Data);
                form.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataSV.SelectedRows.Count >= 1)
            {
                List<string> data = new List<string>();
                foreach (DataGridViewRow i in this.dataSV.SelectedRows)
                {
                    data.Add(i.Cells["MSSV"].Value.ToString());
                }
                DuLieuSV.Instance.DeleteDSSV(data);
                Show_Data(this.cbbLSH.Text, this.txtSearch.Text);
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            List<string> data = new List<string>();
            foreach (DataGridViewRow i in this.dataSV.Rows)
            {
                data.Add(i.Cells["MSSV"].Value.ToString());
            }
            this.dataSV.DataSource = QL.Sort(data, this.cbbSort.Text);
        }
    }
}

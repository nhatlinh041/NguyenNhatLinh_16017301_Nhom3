using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace de_tai_5
{
    public partial class lvDoc_gia : Form
    {
        DataClasses1DataContext a = new DataClasses1DataContext();
        Danh_sach_doc_gia ds = new Danh_sach_doc_gia();
        ListViewItem lvi=null;
        int kiemtra = 0;
        public lvDoc_gia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvDoc_gia_Load(object sender, EventArgs e)
        {
            cleardata();
            napdulieu();
            enable_control(false);
            load_list_docgia();
        }
        public void cleardata()
        {
            tbDia_chi.Clear();
            tbHo_ten_doc_gia.Clear();
            tbMa_doc_gia.Clear();
            rbtNam.Checked = rbtNu.Checked = false;
        }
        public void enable_control(bool e)
        {
             tbHo_ten_doc_gia.Enabled = tbDia_chi.Enabled = groupBox2.Enabled = e;
            btLuu.Enabled = btHuy.Enabled=e;
            btThem.Enabled = btSua.Enabled = btXoa.Enabled = !e;
            lv_ds_doc_gia.Enabled = !e;
        }
        public void addlistview_docgia(Docgia b)
        {
        
            lvi = lv_ds_doc_gia.Items.Add(b.Madocgia);
            lvi.SubItems.Add(b.Tendocgia);
            lvi.SubItems.Add(b.Gioitinh == true ? "Nu" : "Nam");
            lvi.SubItems.Add(b.Diachi);
        }
        public void load_list_docgia()
        {
            for (int i = lv_ds_doc_gia.Items.Count - 1; i >=0 ; i--)
            {
                lv_ds_doc_gia.Items.RemoveAt(i);
            }

            for (int i = 0; i < ds.count(); i++)
            {
                addlistview_docgia(ds[i]);

            }
        }
        public void napdulieu()
        {
            var query = from docgia in a.DOCGIAs
                        orderby docgia.MADOCGIA ascending
                        select docgia;
            foreach(var b in query)
            {
                Docgia c = new Docgia(b.MADOCGIA.ToString(), b.HOTEN.ToString(), Convert.ToBoolean( b.GIOITINH), b.DIACHI.ToString());
                ds.add(c);
            }

        }
        private void lvDoc_gia_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Do you really want to close?", "Quan ly thu vien",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void lv_ds_doc_gia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lv_ds_doc_gia.SelectedItems.Count>0)
            {
                lvi = lv_ds_doc_gia.SelectedItems[0];
                loadata(ds.search_docgia(lvi.Text));
                lvi = null;
            }
        }

        private void loadata(Docgia b)
        {
            tbMa_doc_gia.Text = b.Madocgia;
            tbHo_ten_doc_gia.Text = b.Tendocgia;
            rbtNam.Checked = b.Gioitinh == true ? false :  true;
            rbtNu.Checked = b.Gioitinh == false ? false : true;
            tbDia_chi.Text = b.Diachi;
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (tbMa_doc_gia.Text != "")
            {
                
                lvi = lv_ds_doc_gia.SelectedItems[0];
                DOCGIA b = a.DOCGIAs.Where(s => s.MADOCGIA == lvi.Text).Single();
                var pm_xoa = from pm in a.PHIEUMUONs
                           where pm.MADOCGIA == lvi.Text
                           select pm;
                var ctpm_xoa = from ctpm in a.CTPMs
                               join pm in a.PHIEUMUONs on ctpm.MAPHIEUMUON equals pm.MAPHIEUMUON
                               where pm.MADOCGIA == lvi.Text
                               select ctpm;
                var pt_xoa = from pt in a.PHIEUTRAs
                             join bb in a.PHIEUMUONs on pt.MAPHIEUMUON equals bb.MAPHIEUMUON
                             where bb.MADOCGIA == lvi.Text
                             select pt;
                foreach (var tmp_pm in pm_xoa)
                {
                    a.PHIEUMUONs.DeleteOnSubmit(tmp_pm);
                    a.SubmitChanges();
                }
                foreach (var tmp_pm1 in ctpm_xoa)
                {
                    a.CTPMs.DeleteOnSubmit(tmp_pm1);
                    a.SubmitChanges();
                }
                foreach (var tmp_pm1 in pt_xoa)
                {
                    a.PHIEUTRAs.DeleteOnSubmit(tmp_pm1);
                    a.SubmitChanges();
                }
                a.DOCGIAs.DeleteOnSubmit(b);
                a.SubmitChanges();
                ds.delete(ds.search_docgia(lvi.Text).Madocgia);
                load_list_docgia();
                cleardata();
                lvi = null;
            }
            else
                MessageBox.Show("Chua chon doc gia");
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if(tbMa_doc_gia.Text!="")
            {
                enable_control(true);
                kiemtra = 0;
            }
            else
            {
                MessageBox.Show("Chua chon doc gia");
            }
            
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            kiemtra = 1;
            cleardata();
            enable_control(true);
            int i = Convert.ToInt32(ds[ds.count() - 1].Madocgia.Remove(0, 2)) + 1;
            string tmp = "DG";
            if ((Convert.ToInt32(i) + 1) <= 10)
                tmp += "0";
            tmp += i.ToString();
            tbMa_doc_gia.Text = tmp;
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
            enable_control(false);
            cleardata();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if(tbHo_ten_doc_gia.Text.Length==0||Char.IsNumber(tbHo_ten_doc_gia.Text[tbHo_ten_doc_gia.Text.Length-1])
                ||(rbtNam.Checked==false&&rbtNu.Checked==false)
                ||tbDia_chi.Text.Length==0)
            {
                if(tbHo_ten_doc_gia.Text.Length == 0 || Char.IsNumber(tbHo_ten_doc_gia.Text[tbHo_ten_doc_gia.Text.Length - 1]))
                {

                    this.errorProvider1.SetError(tbHo_ten_doc_gia, "Ho ten khong duoc de trong va khong bao gom so");
                }
                if((rbtNam.Checked == false && rbtNu.Checked == false))
                {

                    this.errorProvider1.SetError(rbtNam, "Phai chon gioi tinh");
                }
                if(tbDia_chi.Text.Length == 0)
                {

                    this.errorProvider1.SetError(tbDia_chi, "Phai dien dia chi");
                }
            }
            else
            {

                this.errorProvider1.Clear();
                Docgia tmp = new Docgia(tbMa_doc_gia.Text, tbHo_ten_doc_gia.Text, rbtNam.Checked == true ? false : true, tbDia_chi.Text);
                DOCGIA tmp1 = new DOCGIA();
                tmp1.MADOCGIA = tbMa_doc_gia.Text;
                tmp1.HOTEN = tbHo_ten_doc_gia.Text;
                tmp1.GIOITINH = rbtNam.Checked == true ? 0 : 1;
                tmp1.DIACHI = tbDia_chi.Text;
                if (kiemtra == 0)
                {
                    lvi = lv_ds_doc_gia.SelectedItems[0];
                    ds.delete(ds.search_docgia(lvi.Text).Madocgia);
                    cleardata();
                    DOCGIA b = a.DOCGIAs.Where(s => s.MADOCGIA == lvi.Text).Single();
                    a.DOCGIAs.DeleteOnSubmit(b);
                    a.DOCGIAs.InsertOnSubmit(tmp1);
                    a.SubmitChanges();
                    ds.add(tmp);

                    load_list_docgia();
                    MessageBox.Show("Sua thanh cong");

                }
                if (kiemtra == 1)
                {
                    a.DOCGIAs.InsertOnSubmit(tmp1);
                    a.SubmitChanges();
                    ds.add(tmp);
                    load_list_docgia();
                    MessageBox.Show("Them thanh cong");
                }
                enable_control(false);
            }
            
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

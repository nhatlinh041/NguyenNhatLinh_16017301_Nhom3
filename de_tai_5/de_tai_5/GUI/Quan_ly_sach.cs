using System;
using System.Collections;
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
    public partial class Form1 : Form
    {
        Quan_ly_muon_tra form_muontra;
        lvDoc_gia form_docgia;
        DataClasses1DataContext data = new DataClasses1DataContext();
        DanhsachSach danh_sach_sach = new DanhsachSach();
        ListViewItem lvi;
        int pos = 0;
        int kiem_tra = 0;
        public Form1()
        {
            InitializeComponent();
        }


        /**********************************************************************
        /**Description: Mo, dong cac text box, button
        /**Params : bool e
        /**Write by: Nguyen Nhat Linh 
        /**Create date: 10/4/2018
        **********************************************************************/
        private void enableControl(bool e)
        {
            tbSo_luong.Enabled = tbTac_gia.Enabled = tb_Ten_sach.Enabled = e;
            cbLoai.Enabled = btHuy.Enabled=btLuu.Enabled = e;
            btQuan_ly_doc_gia.Enabled = btQuan_ly_muon_tra.Enabled  = btXoa.Enabled = !e;
            btThem.Enabled = btXoa.Enabled = btCap_Nhat.Enabled = lvDanh_sach_sach.Enabled =lbLoai_sach.Enabled= !e;
            btQuan_ly_doc_gia.Enabled = btQuan_ly_muon_tra.Enabled  = !e;
        }


        /**********************************************************************
        /**Description: Form load
        /**Params : 
        /**Write by: Nguyen Nhat Linh 
        /**Create date: 10/4/2018
        **********************************************************************/
        private void Form1_Load(object sender, EventArgs e)
        {
            Nap_du_lieu_sach();
            enableControl(false);
        }

        /**********************************************************************
        /**Description: Them sach vao lvDanh_sach_sach
        /**Params : Sach a
        /**Write by: Nguyen Nhat Linh 
        /**Create date: 10/4/2018
        **********************************************************************/
        private void add_listview(Sach a)
        {
            ListViewItem lvi = lvDanh_sach_sach.Items.Add(a.Masach);
            lvi.SubItems.Add(a.Tensach.ToString());
            lvi.SubItems.Add(a.Loai);
            lvi.SubItems.Add(a.Tentacgia);
            lvi.SubItems.Add(a.Soluong.ToString());
        }

        /**********************************************************************
        /**Description: Load data tu database len form
        /**Params : 
        /**Write by: Nguyen Nhat Linh 
        /**Create date: 10/4/2018
        **********************************************************************/
        public void Nap_du_lieu_sach()
        {
            var query= from a in data.SACHes
                       select a;
            foreach (SACH c in query)
            {
                Sach b = new Sach(c.MASACH.ToString(), c.TENSACH.ToString(), c.LOAI.ToString(),c.TENTACGIA,c.SOLUONG);
                b.Loai = b.Loai.Replace(" ", "");
                danh_sach_sach.add(b);
            }
        }

        /**********************************************************************
        /**Description: Mo khoa cac text box khi da chon sach de cap nhat
        /**Params : 
        /**Write by: Nguyen Nhat Linh 
        /**Create date: 10/4/2018
        **********************************************************************/
        private void btCap_Nhat_Click(object sender, EventArgs e)
        {
            if (tbMa_sach.Text != "")
            {
                enableControl(true);
                kiem_tra = 0;
            }
            else
                MessageBox.Show("Chua chon sach de cap nhat");
            
        }

        /**********************************************************************
        /**Description: Mo form_docgia
        /**Params : bool e
        /**Write by: Nguyen Nhat Linh 
        /**Create date: 10/4/2018
        **********************************************************************/
        private void button7_Click(object sender, EventArgs e)
        {
            form_docgia = new lvDoc_gia(); ;
            form_docgia.ShowDialog();

        }

        /**********************************************************************
        /**Description: Thay doi lvDanh_sach_sach theo loai
        /**Params : bool e
        /**Write by: Nguyen Nhat Linh 
        /**Create date: 10/4/2018
        **********************************************************************/
        public void lbLoai_sach_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_list_danh_sach_sach();
        }

        /**********************************************************************
        /**Description: load du lieu len lvDanh_sach_sach
        /**Params : bool e
        /**Write by: Nguyen Nhat Linh 
        /**Create date: 10/4/2018
        **********************************************************************/
        public void load_list_danh_sach_sach()
        {
            cleardata();
            for(int i= lvDanh_sach_sach.Items.Count-1; i>=0 ;i--)
            {
                lvDanh_sach_sach.Items.RemoveAt(i);
            }
            int a = Convert.ToInt32(lbLoai_sach.SelectedIndex);
            string b="";
            b = loai_sach(a);
            for (int i = 0; i < danh_sach_sach.count(); i++)
            { 
                if (b==danh_sach_sach[i].Loai)
                {
                    add_listview(danh_sach_sach[i]);                    
                }
                    
            }
            cleardata();
            cbLoai.Text = "";
        }

        /**********************************************************************
        /**Description: Xac dinh loai sach
        /**Params : int a
        /**Write by: Nguyen Nhat Linh 
        /**Create date: 10/4/2018
        **********************************************************************/
        public string loai_sach(int a)
        {
            string b = "";
            switch (a)
            {
                case 0:
                    b = "SGK";
                    break;
                case 1:
                    b = "SBT";
                    break;
                case 2:
                    b = "kinhte";
                    break;
                case 3:
                    b = "tinhoc";
                    break;
                case 4:
                    b = "chinhtri";
                    break;
            }
            
            return b;
        }

        /**********************************************************************
        /**Description: Thay doi khi click vao item trong lvDanh_sach_sach
        /**Params : bool e
        /**Write by: Nguyen Nhat Linh 
        /**Create date: 10/4/2018
        **********************************************************************/
        private void lvDanh_sach_sach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvDanh_sach_sach.SelectedItems.Count>0)
            {
                lvi = lvDanh_sach_sach.SelectedItems[0];
                string tmp = lvi.Text;
                load_data(danh_sach_sach.search(tmp));
            }
        }

        /**********************************************************************
        /**Description: Load data len cac text box
        /**Params : Sach a
        /**Write by: Nguyen Nhat Linh 
        /**Create date: 10/4/2018
        **********************************************************************/
        public void load_data(Sach a)
        {
            tbMa_sach.Text = a.Masach;
            tb_Ten_sach.Text = a.Tensach;
            cbLoai.Text =a.Loai;
            tbTac_gia.Text = a.Tentacgia;
            tbSo_luong.Text = a.Soluong.ToString();
        }

        /**********************************************************************
        /**Description: Xoa cac du lieu trong text box
        /**Params :
        /**Write by: Nguyen Nhat Linh 
        /**Create date: 10/4/2018
        **********************************************************************/
        public void cleardata()
        {
            tbMa_sach.Clear();
            tbSo_luong.Clear();
            tbTac_gia.Clear();
            tb_Ten_sach.Clear();
            cbLoai.Text ="" ;
        }

        /**********************************************************************
        /**Description: Huy cac du lieu da viet trong cac text box
        /**Params :
        /**Write by: Nguyen Nhat Linh 
        /**Create date: 10/4/2018
        **********************************************************************/
        private void btHuy_Click(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
            cleardata();
            enableControl(false);
            lvDanh_sach_sach.Select();
        }

        /**********************************************************************
        /**Description: Luu du lieu thay doi xuong database, cap nhat du lieu
        /**Params : 
        /**Write by: Nguyen Nhat Linh 
        /**Create date: 10/4/2018
        **********************************************************************/
        private void btLuu_Click(object sender, EventArgs e)
        {
            if ( tbTac_gia.Text.Length==0 
                || Char.IsNumber(tbTac_gia.Text[tbTac_gia.Text.Length - 1]) 
                || !Char.IsNumber(tbSo_luong.Text[tbSo_luong.Text.Length - 1])
                ||tb_Ten_sach.Text.Length==0|| Convert.ToInt32(tbSo_luong.Text)<0
                ||tbSo_luong.Text==""||cbLoai.Text=="")
            {
                if ( tbTac_gia.Text.Length == 0||Char.IsNumber(tbTac_gia.Text[tbTac_gia.Text.Length - 1]))
                {
                    errorProvider1.SetError(tbTac_gia, "Ten tac gia khong co so");
                }
                if (cbLoai.Text.Length ==0 )
                {
                    errorProvider1.SetError(cbLoai, "Loai khong duoc de trong");
                }
                if ( tbSo_luong.Text.Length == 0||!Char.IsNumber(tbSo_luong.Text[tbSo_luong.Text.Length - 1]) || Convert.ToInt32(tbSo_luong.Text) <= 0 )
                {
                   
                    errorProvider1.SetError(tbSo_luong, "So luong la so nguyen duong");
                }
                if (tb_Ten_sach.Text.Length == 0)
                {
                    errorProvider1.SetError(tb_Ten_sach, "Ten sach khong duoc de trong");
                }
            }
            else
            {
                this.errorProvider1.Clear();
                Sach tmp = new Sach(tbMa_sach.Text, tb_Ten_sach.Text, cbLoai.Text, tbTac_gia.Text, Convert.ToInt32(tbSo_luong.Text));
                SACH tmp1 = new SACH();

                tmp1.MASACH = tbMa_sach.Text;
                tmp1.TENSACH = tb_Ten_sach.Text;
                tmp1.LOAI = cbLoai.Text;
                tmp1.TENTACGIA = tbTac_gia.Text;
                tmp1.SOLUONG = Convert.ToInt32(tbSo_luong.Text);
                if (kiem_tra == 0)
                {
                    SACH tmp2 = data.SACHes.Where(s => s.MASACH == lvi.Text).Single();
                    lvi = lvDanh_sach_sach.SelectedItems[0];
                    danh_sach_sach.delete(danh_sach_sach.search(lvi.Text).Masach);
                    data.SACHes.DeleteOnSubmit(tmp2);
                    data.SACHes.InsertOnSubmit(tmp1);
                    data.SubmitChanges();
                    MessageBox.Show("Sua thanh cong");
                    enableControl(false);
                    //data.SACHes.InsertOnSubmit(tmp1);
                    danh_sach_sach.add(tmp);
                    load_list_danh_sach_sach();
                }

                if (kiem_tra == 1)
                {
                    MessageBox.Show("Them thanh cong");
                    data.SACHes.InsertOnSubmit(tmp1);
                    data.SubmitChanges();
                    enableControl(false);
                    danh_sach_sach.add(tmp);
                    load_list_danh_sach_sach();
                }
                lvi = null;
            }
            
        }

        /**********************************************************************
        /**Description: Mo khoa khi cac text box de nhap khi click button them
        /**Params : 
        /**Write by: Nguyen Nhat Linh 
        /**Create date: 10/4/2018
        **********************************************************************/
        private void btThem_Click(object sender, EventArgs e)
        {
            enableControl(true);
            cleardata();
            lbLoai_sach.Enabled = false;
            cbLoai.Text = "";
            kiem_tra = 1;
            lvDanh_sach_sach.SelectedItems.Clear() ;

        }

        /**********************************************************************
        /**Description: Xoa sach khi click button xoa
        /**Params : 
        /**Write by: Nguyen Nhat Linh 
        /**Create date: 10/4/2018
        **********************************************************************/
        private void btXoa_Click(object sender, EventArgs e)
        {
            if(lvi!=null)
            {
                lvi = lvDanh_sach_sach.SelectedItems[0];
                SACH a = data.SACHes.Where(s => s.MASACH == lvi.Text).Single();
                var ctpm = from pm in data.CTPMs
                           
                           where pm.MASACH == lvi.Text
                           select pm;
                var pm_xoa = from bb in data.PHIEUMUONs
                           join pm in data.CTPMs  on bb.MAPHIEUMUON equals pm.MAPHIEUMUON
                           where pm.MASACH == lvi.Text
                           select bb;
                var pt_xoa = from pt in data.PHIEUTRAs
                             join bb in data.PHIEUMUONs on pt.MAPHIEUMUON equals bb.MAPHIEUMUON
                             join pm in data.CTPMs on bb.MAPHIEUMUON equals pm.MAPHIEUMUON
                             where pm.MASACH == lvi.Text
                             select pt;
                foreach (var tmp_pm in ctpm)
                {
                    data.CTPMs.DeleteOnSubmit(tmp_pm);
                    data.SubmitChanges();
                }
                foreach (var tmp_pm1 in pm_xoa)
                {
                    data.PHIEUMUONs.DeleteOnSubmit(tmp_pm1);
                    data.SubmitChanges();
                }
                foreach (var tmp_pm1 in pt_xoa)
                {
                    data.PHIEUTRAs.DeleteOnSubmit(tmp_pm1);
                    data.SubmitChanges();
                }
                data.SACHes.DeleteOnSubmit(a);
                data.SubmitChanges();
                string tmp = lvi.Text;
                danh_sach_sach.delete(danh_sach_sach.search(tmp).Masach);
                load_list_danh_sach_sach();
                lvi = null;
                MessageBox.Show("Xoa thanh cong");
            }
            else
            {
                MessageBox.Show("Chua chon sach de xoa");
            }
            
        }

        /**********************************************************************
        /**Description: Mo form Quan_ly_muon_tra khi click
        /**Params : 
        /**Write by: Nguyen Nhat Linh 
        /**Create date: 10/4/2018
        **********************************************************************/
        private void btQuan_ly_muon_tra_Click(object sender, EventArgs e)
        {
            form_muontra = new Quan_ly_muon_tra();
            form_muontra.ShowDialog();
        }

        private void cbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvDanh_sach_sach.SelectedItems.Count==0)
            {
                switch (cbLoai.Text)
                {
                    case "SGK":
                        tbMa_sach.Text = "GK";
                        break;
                    case "SBT":
                        tbMa_sach.Text = "BT";
                        break;
                    case "kinhte":
                        tbMa_sach.Text = "KT";
                        break;
                    case "tinhoc":
                        tbMa_sach.Text = "TH";
                        break;
                    case "chinhtri":
                        tbMa_sach.Text = "CT";
                        break;
                }
                var query = from a in data.SACHes
                            orderby a.MASACH descending
                            where a.LOAI == cbLoai.Text
                            select a;
                string b = "";
                foreach (var cc in query)
                {
                    b = cc.MASACH;
                    break;
                }
                int i = Convert.ToInt32(b.Remove(0, 2)) + 1;
                string tmp = tbMa_sach.Text;
                if ((Convert.ToInt32(i) + 1) <= 10)
                    tmp += "0";
                tmp += i.ToString();
                tbMa_sach.Text = tmp;
            }
            

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Ban thuc su muon thoat?", "Quan ly thu vien",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void tbTac_gia_TextChanged(object sender, EventArgs e)
        {

        }

        private void btTim_kiem_Click(object sender, EventArgs e)
        {

        }
    }
}

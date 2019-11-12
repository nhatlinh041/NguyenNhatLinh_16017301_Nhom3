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
    public partial class Quan_ly_muon_tra : Form
    {
        Form1 form1 = new Form1();
        DataClasses1DataContext a = new DataClasses1DataContext();
        Danh_sach_phieu_muon ds_PM = new Danh_sach_phieu_muon();
        Danhsachphieutra ds_PT = new Danhsachphieutra();
        List<DateTime> Ngay_tra = new List<DateTime>();
        ListViewItem lvi = null;
        int vitri = -1;
        public Quan_ly_muon_tra()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvDanhsach_sach.Items.Clear();
            add_lvSach();
        }
        
        private void add_lvSach()
        {
            if(cbLoai.SelectedItem!=null)
            {
                var b = a.SACHes.Where(x => x.LOAI == cbLoai.SelectedItem.ToString());
                List<string> tt = new List<string>();

                for (int i = lvDanhsach_sach.Items.Count - 1; i >= 0; i--)
                {
                    lvDanhsach_sach.Items[i].Remove();
                }
                if (b != null)
                {
                    foreach (var i1 in b)
                    {
                        int dem = 0;
                        lvi = lvDanhsach_sach.Items.Add(i1.TENSACH);
                        for (int i = 0; i < ds_PM.count(); i++)
                        {
                            if (ds_PM[i].Ma_sach_1 == i1.MASACH)
                                dem++;
                            if (ds_PM[i].Ma_sach_2 == i1.MASACH)
                                dem++;
                        }
                        int sl = a.SACHes.Where(x => x.MASACH == i1.MASACH).Single().SOLUONG;
                        
                        lvi.SubItems.Add((sl - dem).ToString());
                        lvi.SubItems.Add(sl.ToString());

                    }
                }
            }
            
            
            //

        }
        private void Quan_ly_muon_tra_Load(object sender, EventArgs e)
        {
            nap_du_lieu_PM();
            nap_du_lieu_PT();
            loadlistPM();
            loadlistPT();
            load_loai_sach();
            enableControlMuon(true);
            enableControlTra(true);
        }

        private void nap_du_lieu_PM()
        {
            for (int i = ds_PM.count()-1; i >=0; i--)
            {
                ds_PM.removeat(i);
            }
            var query = from PM in a.PHIEUMUONs
                        join CTPM in a.CTPMs on PM.MAPHIEUMUON equals CTPM.MAPHIEUMUON
                        join DG in a.DOCGIAs on PM.MADOCGIA equals DG.MADOCGIA
                        orderby PM.MAPHIEUMUON ascending
                        select new
                        {
                            MaPM = PM.MAPHIEUMUON,
                            MaDG = PM.MADOCGIA,
                            Ngaymuon = PM.NGAYMUON,
                            NgayHentra = PM.NGAYHENTRA,
                            ma_sach = CTPM.MASACH,                                       
                        };
            var c = query.Except(from PM in a.PHIEUMUONs
                                    join PT in a.PHIEUTRAs on PM.MAPHIEUMUON equals PT.MAPHIEUMUON
                                    join CTPM in a.CTPMs on PM.MAPHIEUMUON equals CTPM.MAPHIEUMUON
                                    join DG in a.DOCGIAs on PM.MADOCGIA equals DG.MADOCGIA
                                    orderby PM.MAPHIEUMUON ascending
                                   select new
                                   {
                                       MaPM = PM.MAPHIEUMUON,
                                       MaDG = PM.MADOCGIA,
                                       Ngaymuon = PM.NGAYMUON,
                                       NgayHentra = PM.NGAYHENTRA,
                                       ma_sach = CTPM.MASACH,
                                   });
            foreach (var tmp in c)
            {
                phieu_muon a = new phieu_muon(tmp.MaPM, tmp.MaDG, tmp.Ngaymuon, tmp.NgayHentra,tmp.ma_sach ,"" );
                ds_PM.add(a);
            }
            for (int i = 0; i < ds_PM.count()-1; i++)
            {
                if(ds_PM[i].Ma_phieu_muon.Equals(ds_PM[i+1].Ma_phieu_muon))
                {
                    ds_PM[i].Ma_sach_2 = ds_PM[+1].Ma_sach_1;
                    ds_PM.removeat(i + 1);
                }
            }                   
        }

        private void nap_du_lieu_PT()
        {
            for (int i = ds_PT.count()-1; i >=0 ; i--)
            {
                ds_PT.removeat(i);
            }
            var c = (from PM in a.PHIEUMUONs
                                 join PT in a.PHIEUTRAs on PM.MAPHIEUMUON equals PT.MAPHIEUMUON
                                 join CTPM in a.CTPMs on PM.MAPHIEUMUON equals CTPM.MAPHIEUMUON
                                 join DG in a.DOCGIAs on PM.MADOCGIA equals DG.MADOCGIA
                                 orderby PM.MAPHIEUMUON ascending
                                 select new
                                 {
                                     MaPM = PM.MAPHIEUMUON,
                                     MaDG = PM.MADOCGIA,
                                     Ngaymuon = PM.NGAYMUON,
                                     NgayHentra = PM.NGAYHENTRA,
                                     NgayTra=PT.NGAYTRA,
                                     ma_sach = CTPM.MASACH,
                                 });
            foreach (var tmp in c)
            {
                Phieutra a = new Phieutra(tmp.MaPM, tmp.MaDG, tmp.Ngaymuon, tmp.NgayHentra,tmp.NgayTra, tmp.ma_sach, "");
                ds_PT.add(a);
                
            }
            for (int i = 0; i < ds_PT.count() - 1; i++)
            {
                if (ds_PT[i].Ma_phieu_muon.Equals(ds_PT[i + 1].Ma_phieu_muon))
                {
                    ds_PT[i].Ma_sach_2 = ds_PT[i+1].Ma_sach_1;
                    ds_PT.removeat(i + 1);
                }
            }
        }

        private void load_loai_sach()
        {
            var qu1 = from c in a.SACHes
                      orderby c.LOAI ascending
                      select new
                      {
                          b = c.LOAI
                      };           
            foreach (var cc in qu1)
                cbLoai.Items.Add(cc.b.ToString());
            
            
            for (int i = 0; i < cbLoai.Items.Count -1; i++)
            {
                if (cbLoai.Items[i].Equals(cbLoai.Items[i + 1]))
                {
                    cbLoai.Items.RemoveAt(i + 1);
                    i--;
                }                                  
            }
            
        }
        private void enableControlMuon(bool a)
        {
            tbMa_sach_1.Enabled=tbTen_sach_1.Enabled=tbMa_sach_2.Enabled = !a;
            tbTen_sach_2.Enabled = !a;
            lvDanhsach_sach.Enabled=lvPM.Enabled = a;

        }
        private void enableControlTra(bool a)
        {
            tbTen_DG_tra.Enabled = tb_MDG_tra.Enabled = tbTen_sachtra1.Enabled = !a;
            tbTen_sachtra2.Enabled=tbMa_sach_tra1.Enabled=tbMa_sach_tra2.Enabled = !a;
            lvDanhsach_sach.Enabled = lvPM.Enabled = a;
            tbNgay_muon.Enabled = tbNgay_hen_tra.Enabled = tbNgay_tra.Enabled = !a;

        }
        private void loadlistPM()
        {
            for (int i = lvPM.Items.Count-1; i >=0; i--)
            {
                lvPM.Items.RemoveAt(i);
            }
            for (int i = 0; i < ds_PM.count(); i++)
            {
                addlistviewPM(ds_PM[i]);

            }
        }
        private void loadlistPT()
        {
            for (int i = lvlDs_tra.Items.Count - 1; i >= 0; i--)
            {
                lvlDs_tra.Items.RemoveAt(i);
            }
            for (int i = 0; i < ds_PT.count(); i++)
            {
                addlistviewPT(ds_PT[i]);

            }
        }
        private void addlistviewPM(phieu_muon a)
        {
            lvi = lvPM.Items.Add(a.Ma_doc_gia);
            lvi.SubItems.Add(a.Ma_phieu_muon);
            lvi.SubItems.Add(a.Ngay_muon.ToShortDateString());
            lvi.SubItems.Add(a.Ngay_hen_tra.ToShortDateString());
            lvi.SubItems.Add(a.Ma_sach_1);
            lvi.SubItems.Add(a.Ma_sach_2);
        }
        private void addlistviewPT(Phieutra a)
        {
            lvi = lvlDs_tra.Items.Add(a.Ma_doc_gia);
            lvi.SubItems.Add(a.Ma_phieu_muon);
            lvi.SubItems.Add(a.Ngay_muon.ToShortDateString());
            lvi.SubItems.Add(a.Ngay_hen_tra.ToShortDateString());
            lvi.SubItems.Add(a.Ngay_tra.ToShortDateString());
            lvi.SubItems.Add(a.Ma_sach_1);
            lvi.SubItems.Add(a.Ma_sach_2);
        }
        private void btQuay_lai_Click(object sender, EventArgs e)
        {
            form1.Visible = true;
            this.Visible = false;
        }



        private void lvDanhsach_sach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDanhsach_sach.SelectedItems.Count>0)
            {
                if(lvDanhsach_sach.SelectedItems[0].SubItems[1].Text!="0")
                {
                    if (tbMa_sach_1.Text == "" || tbMa_sach_2.Text == "")
                    {
                        if (tbMa_sach_1.Text == "" || (tbMa_sach_1.Text == "" && tbMa_sach_2.Text == ""))
                        {
                            lvi = lvDanhsach_sach.SelectedItems[0];
                            tbTen_sach_1.Text = lvi.Text;
                            SACH tmp3 = a.SACHes.Where(s => s.TENSACH == lvi.Text).Single();
                            tbMa_sach_1.Text = tmp3.MASACH;

                        }
                        else if (tbMa_sach_2.Text == "")
                        {
                            lvi = lvDanhsach_sach.SelectedItems[0];
                            tbTen_sach_2.Text = lvi.Text;
                            SACH tmp = a.SACHes.Where(x => x.TENSACH == lvi.Text).Single();
                            tbMa_sach_2.Text = tmp.MASACH;
                        }

                    }
                    else
                        MessageBox.Show("Chi duoc muon  toi da 2 quyen");
                }
                else
                    MessageBox.Show("Da het sach nay");

            }
            
            lvi = null;
        }

        private void btTim_doc_gia_Click(object sender, EventArgs e)
        {
            bool aa = false;
            var b = from c in a.DOCGIAs
                    select c;
            foreach (var i in b)
                if (i.MADOCGIA == tbtim_Ma_doc_gia.Text)
                    aa = true;

            if (aa == false)
                MessageBox.Show("Ma doc gia khong ton tai");
            else
            {
                aa = false;
                for (int i = 0; i < ds_PM.count(); i++)
                {
                    if (tbtim_Ma_doc_gia.Text == ds_PM[i].Ma_doc_gia)
                        aa = true;
                }
                if (aa == false)
                {
                    DOCGIA c = a.DOCGIAs.Where(x => x.MADOCGIA == tbtim_Ma_doc_gia.Text).Single();
                    tbMa_doc_gia.Text = c.MADOCGIA;
                    tbTen_doc_gia.Text = c.HOTEN;
                }
                else
                    MessageBox.Show("Doc gia dang muon sach");
            }

        }
        public void cleardata()
        {
            tbtim_Ma_doc_gia.Clear();
            tbTen_doc_gia.Clear();
            tbMa_doc_gia.Clear();
            tbMa_sach_1.Clear();
            tbMa_sach_2.Clear();
            tbTen_sach_1.Clear();
            tbTen_sach_2.Clear();

        }
        private void btXoa_1_Click(object sender, EventArgs e)
        {
            tbMa_sach_1.Clear();
            add_lvSach();
            tbTen_sach_1.Clear();
            
        }

        private void btXoa_2_Click(object sender, EventArgs e)
        {
            tbMa_sach_2.Clear();
            tbTen_sach_2.Clear();
            add_lvSach();
        }

        private void btMuon_Click(object sender, EventArgs e)
        {
           
            
            string ngay_hen = dtpkNgay_hen_tra.Value.Date.ToShortDateString();
            DateTime ngayhen = Convert.ToDateTime(ngay_hen);
            TimeSpan limit = ngayhen - DateTime.Now;
            if (DateTime.Now>ngayhen)
            {
                
                this.errorProvider1.SetError(dtpkNgay_hen_tra, "Ngay hen tra phai sau ngay cho muon.");
            }
            else
            {
                if(limit.Days>60)
                {
                    this.errorProvider1.SetError(dtpkNgay_hen_tra, "Ngay muon toi da la 60 ngay");
                }
                else
                {
                    this.errorProvider1.Clear();
                    if (tbMa_doc_gia.Text != "")
                    {

                        var c = from b in a.PHIEUMUONs
                                orderby b.MAPHIEUMUON descending
                                select b;
                        string t = "";
                        foreach (var tmp1 in c)
                        {
                            t = tmp1.MAPHIEUMUON;
                            break;
                        }
                        t = t.Remove(0, 2);
                        if (tbMa_sach_1.Text != "" || tbMa_sach_2.Text != "")
                        {
                            DateTime mm = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                            string tmp = "PM";
                            if ((Convert.ToInt32(t) + 1) < 10)
                                tmp += "0";
                            phieu_muon PM = new phieu_muon(tmp + (Convert.ToInt32(t) + 1).ToString(),
                                tbMa_doc_gia.Text, mm,
                                ngayhen, tbMa_sach_1.Text, tbMa_sach_2.Text);
                            ds_PM.add(PM);
                            loadlistPM();
                            add_lvSach();
                            MessageBox.Show("Cho muon thanh cong");
                            PHIEUMUON PMmoi = new PHIEUMUON();
                            PMmoi.MAPHIEUMUON = tmp + (Convert.ToInt32(t) + 1).ToString();
                            PMmoi.MADOCGIA = tbtim_Ma_doc_gia.Text;
                            PMmoi.NGAYHENTRA = ngayhen;
                            PMmoi.NGAYMUON = mm;
                            a.PHIEUMUONs.InsertOnSubmit(PMmoi);
                            CTPM ctpm_moi1 = new CTPM();
                            CTPM ctpm_moi2 = new CTPM();
                            ctpm_moi1.MAPHIEUMUON = tmp + (Convert.ToInt32(t) + 1).ToString();
                            ctpm_moi2.MAPHIEUMUON = tmp + (Convert.ToInt32(t) + 1).ToString();
                            if (PM.Ma_sach_1 != "")
                            {
                                ctpm_moi1.MASACH = PM.Ma_sach_1;
                                a.CTPMs.InsertOnSubmit(ctpm_moi1);
                                a.SubmitChanges();
                            }
                            if (PM.Ma_sach_2 != "")
                            {
                                ctpm_moi2.MASACH = PM.Ma_sach_2;
                                a.CTPMs.InsertOnSubmit(ctpm_moi2);
                                a.SubmitChanges();
                            }

                            loadlistPM(); cleardata();
                        }
                        else
                            MessageBox.Show("Chua chon sach");

                    }
                    else
                        MessageBox.Show("Chua nhap ma doc gia");
                }
                
            }
            
            


        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nap_du_lieu_PM();
            nap_du_lieu_PT();
            lvDanhsach_sach.Items.Clear();
            loadlistPM();
            add_lvSach();
            enableControlMuon(true);
            enableControlTra(true);
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            string kt = "";
            clearTrasach();
            bool aa = false;
            var b = from c in a.DOCGIAs
                    select c;
            foreach (var i in b)
                if (i.MADOCGIA == tbTim_Madocgia_tra.Text)
                    aa = true;
            
            if (aa == false)
                MessageBox.Show("Ma doc gia khong ton tai");
            else
            {
                clearTrasach();
                aa = false;
                for (int i = 0; i < ds_PM.count(); i++)
                {
                    if (tbTim_Madocgia_tra.Text == ds_PM[i].Ma_doc_gia)
                    {
                        aa = true;
                    }
                        
                }
                if (aa == true)
                {
                    for (int i = 0; i < ds_PM.count(); i++)
                    {
                        
                        if(tbTim_Madocgia_tra.Text==ds_PM[i].Ma_doc_gia)
                        {
                            tbNgay_muon.Text = ds_PM[i].Ngay_muon.ToString("dd/MM/yyyy");
                            tbNgay_hen_tra.Text = ds_PM[i].Ngay_hen_tra.ToString("dd/MM/yyyy");
                            tbNgay_tra.Text = DateTime.Now.ToString("dd/MM/yyyy");
                            tb_MDG_tra.Text = ds_PM[i].Ma_doc_gia;
                            tbTen_DG_tra.Text = a.DOCGIAs.Where(x=>x.MADOCGIA== tbTim_Madocgia_tra.Text).Single().HOTEN;
                            tbMa_sach_tra1.Text = ds_PM[i].Ma_sach_1;
                            tbMa_sach_tra2.Text = ds_PM[i].Ma_sach_2;
                            if(tbMa_sach_tra1.Text!="")
                                tbTen_sachtra1.Text = a.SACHes.Where(x => x.MASACH == ds_PM[i].Ma_sach_1).Single().TENSACH;
                            if (tbMa_sach_tra2.Text != "")
                            {
                                tbTen_sachtra2.Text = a.SACHes.Where(x => x.MASACH == ds_PM[i].Ma_sach_2).Single().TENSACH;
                                break;
                            }                                  
                        }
                    }
                    
                    if (tb_MDG_tra.Text == "")
                        MessageBox.Show("Doc gia chua muon sach");
                }
                else
                {

                         MessageBox.Show("Doc gia chua muon sach\nasdasd");

                }
                    
            }

        }
        private void clearTrasach()
        {
            tb_MDG_tra.Clear();
            tbTen_DG_tra.Clear();
            tbMa_sach_tra1.Clear();
            tbMa_sach_tra2.Clear();
            tbTen_sachtra1.Clear();
            tbTen_sachtra2.Clear();
        }

        private void btTra_sach_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ds_PM.count(); i++)
            {
                if(tb_MDG_tra.Text==ds_PM[i].Ma_doc_gia)
                {
                    Phieutra b = new Phieutra(ds_PM[i].Ma_phieu_muon, ds_PM[i].Ma_doc_gia, ds_PM[i].Ngay_muon,
                        ds_PM[i].Ngay_hen_tra, DateTime.Now, ds_PM[i].Ma_sach_1, ds_PM[i].Ma_sach_2);
                    ds_PT.add(b);
                    PHIEUTRA pt = new PHIEUTRA();
                    pt.MAPHIEUMUON = ds_PM[i].Ma_phieu_muon;
                    pt.NGAYTRA = DateTime.Now;
                    a.PHIEUTRAs.InsertOnSubmit(pt);
                    a.SubmitChanges();
                    TimeSpan TG = b.Ngay_tra - b.Ngay_hen_tra;
                    if (TG.Days > 30)
                        MessageBox.Show("Tra qua han 1 thang\nTien phat: 20000VND");
                    break;
                }
            }
            
            loadlistPT();
            add_lvSach();
        }

        private void btIn_DSDG_qua_han_Click(object sender, EventArgs e)
        {
            DG_qua_han a = new DG_qua_han();
            a.ShowDialog();
        }

        private void btThoat_trasach_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Quan_ly_muon_tra_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Do you really want to close?", "Quan ly thu vien",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}

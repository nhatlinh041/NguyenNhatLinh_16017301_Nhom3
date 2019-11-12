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
    public partial class DG_qua_han : Form
    {
        public DG_qua_han()
        {
            InitializeComponent();
        }

        private void DG_qua_han_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext a = new DataClasses1DataContext();
          //  dataGridViewJobs.DataSource = db.jobs.Select(p => p.closeDate <= DateTime.Now);
            var query = from PM in a.PHIEUMUONs
                        join CTPM in a.CTPMs on PM.MAPHIEUMUON equals CTPM.MAPHIEUMUON
                        join DG in a.DOCGIAs on PM.MADOCGIA equals DG.MADOCGIA
                        orderby PM.MAPHIEUMUON ascending
                        where PM.NGAYHENTRA<DateTime.Now
                        select new
                        {
                            Madocgia = PM.MADOCGIA,
                            Tendocgia = DG.HOTEN,
                            gioitinh = DG.GIOITINH,
                            Diachi = DG.DIACHI,
                            Ngaymuon = PM.NGAYMUON,
                            NgayHentra = PM.NGAYHENTRA,
                            Hientai = DateTime.Now
                        };
            var c = query.Except(from PM in a.PHIEUMUONs
                                 join PT in a.PHIEUTRAs on PM.MAPHIEUMUON equals PT.MAPHIEUMUON
                                 join CTPM in a.CTPMs on PM.MAPHIEUMUON equals CTPM.MAPHIEUMUON
                                 join DG in a.DOCGIAs on PM.MADOCGIA equals DG.MADOCGIA
                                 where PM.NGAYHENTRA < DateTime.Now
                                 orderby PM.MAPHIEUMUON ascending
                                 select new
                                 {
                                     Madocgia = PM.MADOCGIA,
                                     Tendocgia = DG.HOTEN,
                                     gioitinh = DG.GIOITINH,
                                     Diachi = DG.DIACHI,
                                     Ngaymuon = PM.NGAYMUON,
                                     NgayHentra = PM.NGAYHENTRA,
                                     Hientai = DateTime.Now
                                 });
            dataGridView2.DataSource = c;
        }
    }
}

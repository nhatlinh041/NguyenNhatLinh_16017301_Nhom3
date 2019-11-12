using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de_tai_5
{
    class Phieutra : phieu_muon
    {
        DateTime ngay_tra;

        public Phieutra(string ma_phieu_muon, string ma_doc_gia, DateTime ngay_muon, DateTime ngay_hen_tra,DateTime ngay_tra, string ma_sach_1, string ma_sach_2) 
            : base(ma_phieu_muon, ma_doc_gia, ngay_muon, ngay_hen_tra, ma_sach_1, ma_sach_2)
        {
            Ngay_tra = ngay_tra;
        }

        public DateTime Ngay_tra
        {
            get
            {
                return ngay_tra;
            }

            set
            {
                ngay_tra = value;
            }
        }
    }
}

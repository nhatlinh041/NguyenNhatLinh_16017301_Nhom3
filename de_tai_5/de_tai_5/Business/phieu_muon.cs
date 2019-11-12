using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de_tai_5
{
    public class phieu_muon
    {
        string ma_phieu_muon;
        string ma_doc_gia;
        DateTime ngay_muon;
        DateTime ngay_hen_tra;
        string ma_sach_1;
        string ma_sach_2;

        public string Ma_phieu_muon
        {
            get
            {
                return ma_phieu_muon;
            }

            set
            {
                ma_phieu_muon = value;
            }
        }

        public DateTime Ngay_muon
        {
            get
            {
                return ngay_muon;
            }

            set
            {
                ngay_muon = value;
            }
        }



        public string Ma_doc_gia
        {
            get
            {
                return ma_doc_gia;
            }

            set
            {
                ma_doc_gia = value;
            }
        }

        public string Ma_sach_1
        {
            get
            {
                return ma_sach_1;
            }

            set
            {
                ma_sach_1 = value;
            }
        }

        public string Ma_sach_2
        {
            get
            {
                return ma_sach_2;
            }

            set
            {
                this.ma_sach_2 = value;
            }
        }

        public DateTime Ngay_hen_tra
        {
            get
            {
                return ngay_hen_tra;
            }

            set
            {
                ngay_hen_tra = value;
            }
        }

        public phieu_muon(string ma_phieu_muon,string ma_doc_gia, DateTime ngay_muon,
            DateTime ngay_hen_tra,string ma_sach_1,string ma_sach_2)
        {
            Ma_phieu_muon = ma_phieu_muon;
            Ma_doc_gia = ma_doc_gia;
            Ngay_muon = ngay_muon;
            Ngay_hen_tra = ngay_hen_tra;
            Ma_sach_1 = ma_sach_1;
            Ma_sach_2 = ma_sach_2;
            
        }
    }
}

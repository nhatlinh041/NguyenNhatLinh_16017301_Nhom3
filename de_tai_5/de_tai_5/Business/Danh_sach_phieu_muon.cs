using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de_tai_5
{
    class Danh_sach_phieu_muon
    {
        private List<phieu_muon> ds;

        public Danh_sach_phieu_muon()
        {
            ds = new List<phieu_muon>();
        }

        public phieu_muon this[int i]
        {
            get
            {
                if (i >= 0 && i < ds.Count)
                    return ds[i];
                return null;
            }
            set
            {
                if (i >= 0 && i < ds.Count)
                    ds[i] = value;
            }
        }

        public void add(phieu_muon a)
        {
            ds.Add(a);
        }
        public int count()
        {
            return ds.Count();
        }
        public phieu_muon search(string a)
        {
            for (int i = 0; i < ds.Count(); i++)
            {
                if (ds[i].Ma_phieu_muon.Equals(a))
                {
                    return ds[i];
                }

            }
            return null;
        }
        public void delete(string a)
        {
            for (int i = 0; i < ds.Count(); i++)
            {
                if (ds[i].Ma_phieu_muon.Equals(a))
                {
                    ds.Remove(ds[i]);
                }

            }
        }
        public void removeat(int a)
        {
            for (int i = 0; i < ds.Count(); i++)
            {
                if (i == a)
                    ds.Remove(ds[i]);
            }
        }
    }
}

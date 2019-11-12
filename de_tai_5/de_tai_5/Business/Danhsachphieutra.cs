using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de_tai_5
{
    class Danhsachphieutra
    {
        private List<Phieutra> ds;

        public Danhsachphieutra()
        {
            ds = new List<Phieutra>();
        }

        public Phieutra this[int i]
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

        public void add(Phieutra a)
        {
            ds.Add(a);
        }
        public int count()
        {
            return ds.Count();
        }
        public Phieutra search(string a)
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

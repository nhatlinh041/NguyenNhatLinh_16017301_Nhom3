using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace de_tai_5
{
    
    class DanhsachSach
    {
        private List<Sach> ds;


        public  DanhsachSach()
        {
            ds = new List<Sach>();
        }

        public Sach this[int i]
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

        public void add(Sach a)
        {
            ds.Add(a);
        }
        public int count()
        {
            return ds.Count();
        }
        public  Sach search(string a)
        {
            for(int i=0;i<ds.Count();i++)
            {
                if (ds[i].Masach.Equals(a))
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
                if (ds[i].Masach.Equals(a))
                {
                    ds.Remove(ds[i]);
                }

            }
        }

    }

}

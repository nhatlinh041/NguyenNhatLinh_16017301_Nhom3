using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de_tai_5
{
    public class Danh_sach_doc_gia
    {
        private List<Docgia> ds;
        public Danh_sach_doc_gia()
        {
            ds = new List<Docgia>();
        }

        public Docgia this[int i]
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

        public void add(Docgia a)
        {
            ds.Add(a);
        }

        public int count()
        {
            return ds.Count();
        }

        public Docgia search_docgia(string a)
        {
            foreach(Docgia b in ds)
            {
                if (b.Madocgia == a)
                    return b;
            }
            return null;
        }

        public void delete(string a)
        {
            for(int i=0;i<ds.Count();i++)
            {
                if (ds[i].Madocgia == a)
                    ds.Remove(ds[i]);

            }
        }
    }
}

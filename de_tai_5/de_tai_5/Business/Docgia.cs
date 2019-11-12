using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de_tai_5
{
    public class Docgia
    {
        string madocgia;
        string tendocgia;
        string diachi;
        bool gioitinh;

        public string Madocgia
        {
            get
            {
                return madocgia;
            }

            set
            {
                madocgia = value;
            }
        }

        public string Tendocgia
        {
            get
            {
                return tendocgia;
            }

            set
            {
                tendocgia = value;
            }
        }

        public string Diachi
        {
            get
            {
                return diachi;
            }

            set
            {
                diachi = value;
            }
        }

       

        public bool Gioitinh
        {
            get
            {
                return gioitinh;
            }

            set
            {
                gioitinh = value;
            }
        }
        public Docgia(string madocgia,string tendocgia, bool gioitinh, string diachi)
        {
            Madocgia = madocgia;
            Tendocgia = tendocgia;
            Gioitinh = gioitinh;
            Diachi = diachi;

        }
    }
}

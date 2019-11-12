using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de_tai_5
{

    public class Sach
    {
        private string masach;
        private string tensach;
        private string loai;
        private string tentacgia;
        int soluong;

        public string Masach
        {
            get
            {
                return masach;
            }

            set
            {
                if (value.Trim().Length > 0)
                    masach = value;
                else
                    throw new Exception("Khong duoc bo trong ma sach");
            }
        }

        public string Tensach
        {
            get
            {
                return tensach;
            }

            set
            {
                tensach = value;
            }
        }



        public string Tentacgia
        {
            get
            {
                return tentacgia;
            }

            set
            {
                tentacgia = value;
            }
        }

        public string Loai
        {
            get
            {
                return loai;
            }

            set
            {
                loai = value;
            }
        }

        public int Soluong
        {
            get
            {
                return soluong;
            }

            set
            {
                soluong = value;
            }
        }

        public Sach(string masach,string tensach,string loai,string tentacgia,int soluong)
        {
            Masach = masach;
            Tensach = tensach;
            Loai = loai;
            Tentacgia = tentacgia;
            Soluong = soluong;
        }
    }
}

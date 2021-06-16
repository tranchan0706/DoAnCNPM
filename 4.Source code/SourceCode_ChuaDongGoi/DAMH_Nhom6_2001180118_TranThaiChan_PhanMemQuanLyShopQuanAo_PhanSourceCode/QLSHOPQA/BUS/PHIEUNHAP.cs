using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSHOPQA.BUS
{
    class PHIEUNHAP
    {
        string SOPHIEU, MANV, MANCC;
        int TONGTIEN;
        public string SOPHIEU1
        {
            get { return SOPHIEU; }
            set { SOPHIEU = value; }
        }

        public string MANV1
        {
            get { return MANV; }
            set { MANV = value; }
        }
        public string MANCC1
        {
            get { return MANCC; }
            set { MANCC = value; }
        }
        public int TONGTIEN1
        {
            get { return TONGTIEN; }
            set { TONGTIEN = value; }
        }
        DateTime NGAYNHAP;

        public DateTime NGAYNHAP1
        {
            get { return NGAYNHAP; }
            set { NGAYNHAP = value; }
        }
    }
}

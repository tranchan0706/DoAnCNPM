using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSHOPQA.BUS
{
    class HOADON
    {
        string MAHD, MANV, MAKH;
        int TONGTIEN;
        public string MAHD1
        {
            get { return MAHD; }
            set { MAHD = value; }
        }

        public string MANV1
        {
            get { return MANV; }
            set { MANV = value; }
        }
        public string MAKH1
        {
            get { return MAKH; }
            set { MAKH = value; }
        }
        public int TONGTIEN1
        {
            get { return TONGTIEN; }
            set { TONGTIEN = value; }
        }
        DateTime NGAYLAP;

        public DateTime NGAYLAP1
        {
            get { return NGAYLAP; }
            set { NGAYLAP = value; }
        }
    }
}

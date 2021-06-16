using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSHOPQA.BUS
{
    class NCC
    {
        string _maNCC, _tenNCC, _diaChi, _soDT;

        public string SoDT
        {
            get { return _soDT; }
            set { _soDT = value; }
        }

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }

        public string TenNCC
        {
            get { return _tenNCC; }
            set { _tenNCC = value; }
        }

        public string MaNCC
        {
            get { return _maNCC; }
            set { _maNCC = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSHOPQA.BUS
{
    class NHANVIEN
    {
        string _maNV, _tenNV, _tenTK, _matKhau, _ngaySinh, _diaChi, _soDT, _chucVu;
        int _luong, _phuCap;
        
        public int PhuCap
        {
            get { return _phuCap; }
            set { _phuCap = value; }
        }

        public int Luong
        {
            get { return _luong; }
            set { _luong = value; }
        }

        public string ChucVu
        {
            get { return _chucVu; }
            set { _chucVu = value; }
        }

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

        public string NgaySinh
        {
            get { return _ngaySinh; }
            set { _ngaySinh = value; }
        }

        public string MatKhau
        {
            get { return _matKhau; }
            set { _matKhau = value; }
        }

        public string TenTK
        {
            get { return _tenTK; }
            set { _tenTK = value; }
        }

        public string TenNV
        {
            get { return _tenNV; }
            set { _tenNV = value; }
        }

        public string MaNV
        {
            get { return _maNV; }
            set { _maNV = value; }
        }
    }
}

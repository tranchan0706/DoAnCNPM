using QLSHOPQA.CONNECT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSHOPQA.BUS
{
    class NHANVIENBUS
    {
        connect dbconnect = new connect();
        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select  MANV as [MÃ NV],TENTK as [TÊN TK],TENNV as [TÊN NV],MATKHAU as [Mật Khẩu],NGAYSINH as[Ngày Sinh],DIACHI as[ĐỊA CHỈ],SDT as[SĐT],CHUCVU as[Chức Vụ],LUONG as[Lương],PHUCAP as[Phụ Cấp] from QLTAIKHOAN");
            dbconnect.Closeconnect();
            return table;
        }
        public void InsertNHANVIEN(NHANVIEN NV)
        {
            string insert = "insert into QLTAIKHOAN(MANV,TENNV,TENTK,MATKHAU,NGAYSINH,DIACHI,SDT,CHUCVU,LUONG,PHUCAP) values(";
            insert += "DBO.AUTO_IDNV(),";
            insert += "N'" + NV.TenNV + "',";
            insert += "'" + NV.TenTK + "',";
            insert += "'" + NV.MatKhau + "',";
            insert += "'" + NV.NgaySinh + "',";
            insert += "N'" + NV.DiaChi + "',";
            insert += "'" + NV.SoDT + "',";
            insert += "N'" + NV.ChucVu + "',";
            insert += "" + NV.Luong + ",";
            insert += "" + NV.PhuCap + ")";

            dbconnect.query1(insert);

        }
        public void UpdateNHANVIEN(NHANVIEN NV, string ma)
        {
            string update = "update QLTAIKHOAN set ";
            update += "TENNV=N'" + NV.TenNV + "',";
            update += "TENTK='" + NV.TenTK + "',";
            update += "MATKHAU='" + NV.MatKhau + "',";
            update += "NGAYSINH='" + NV.NgaySinh + "',";
            update += "DIACHI=N'" + NV.DiaChi + "',";
            update += "SDT='" + NV.SoDT + "',";
            update += "CHUCVU=N'" + NV.ChucVu + "',";
            update += "LUONG=" + NV.Luong + ",";
            update += "PHUCAP=" + NV.PhuCap + "";

            update += "where MANV='" + ma + "'";
            dbconnect.query1(update);
        }
        public void UpdateMATKHAU(NHANVIEN NV, string ma)
        {
            string update = "update QLTAIKHOAN set ";
            update += "MATKHAU='" + NV.MatKhau + "' ";
            update += "where MANV='" + ma + "'";
            dbconnect.query1(update);
        }

        public void DeleteNHANVIEN(string ma)
        {
            string delete = "delete from QLTAIKHOAN where MANV='" + ma + "'";
            dbconnect.query1(delete);
        }
    }
}

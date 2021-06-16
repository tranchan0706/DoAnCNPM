using QLSHOPQA.CONNECT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSHOPQA.BUS
{
    class NCCBUS
    {
        connect dbconnect = new connect();
        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select  MANCC as [MÃ NCC],TENCC as [TÊN NCC],DIACHI as[ĐỊA CHỈ],DIENTHOAI as[SĐT] from NHACUNGCAP");
            dbconnect.Closeconnect();
            return table;
        }
        public void themNhaCungCap(NCC ncc)
        {
            string them = "insert into NHACUNGCAP(MANCC,TENCC,DIACHI,DIENTHOAI) values(";
            them += "DBO.AUTO_IDNCC(),";
            them += "N'" + ncc.TenNCC + "',";
            them += "N'" + ncc.DiaChi + "',";
            them += "'" + ncc.SoDT + "')";
            dbconnect.query1(them);
        }
        public void suaNhaCungCap(NCC ncc, string ma)
        {
            string sua = "update NHACUNGCAP set ";
            sua += "TENCC=N'" + ncc.TenNCC + "',";
            sua += "DIACHI=N'" + ncc.DiaChi + "',";
            sua += "DIENTHOAI='" + ncc.SoDT + "' ";
            sua += "where MANCC='" + ma + "'";
            dbconnect.query1(sua);
        }
        public void xoaNhaCungCap(string ma)
        {
            string xoa = "delete from  NHACUNGCAP where MANCC='" + ma + "'";
            dbconnect.query1(xoa);
        }
    }
}

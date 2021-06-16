using QLSHOPQA.CONNECT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSHOPQA.BUS
{
    class SANPHAMBUS
    {
        connect dbconnect = new connect();
        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select  MAHANG as [MÃ HÀNG],TENHANG as [TÊN HÀNG],SIZE as[SIZE],NHASX as[NHÀ SẢN XUẤT],GIABAN as[GIÁ BÁN],SLTON as[SL TỒN],ANH as[ẢNH] from HANGHOA");
            dbconnect.Closeconnect();
            return table;
        }
        public void InsertSANPHAM(SANPHAM SP)
        {
            string insert = "insert into HANGHOA(MAHANG,TENHANG,SIZE,NHASX,GIABAN,SLTON,ANH) values(";
            insert += "DBO.AUTO_IDHH(),";
            insert += "N'" + SP.TENHANG1 + "',";
            insert += "N'" + SP.SIZE1 + "',";
            insert += "N'" + SP.NHASX1 + "',";
            insert += "" + SP.GIABAN1 + ",";
            insert += "" + SP.SLTON1 + ",";
            insert += "N'" + SP.ANH1 + "')";
            dbconnect.query1(insert);

        }
        public void UpdateSANPHAM(SANPHAM SP, string ma)
        {
            string update = "update HANGHOA set ";
            update += "TENHANG=N'" + SP.TENHANG1 + "',";
            update += "SIZE='" + SP.SIZE1 + "',";
            update += "NHASX=N'" + SP.NHASX1 + "',";
            update += "GIABAN=" + SP.GIABAN1 + ", ";
            update += "SLTON=" + SP.SLTON1 + ", ";
            update += "ANH='" + SP.ANH1 + "' ";
            update += "where MAHANG='" + ma + "'";
            dbconnect.query1(update);
        }
        public void DeleteSANPHAM(string ma)
        {
            string delete = "delete from HANGHOA where MAHANG='" + ma + "'";
            dbconnect.query1(delete);
        }
        public DataTable TimKiem(string ten)
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select  MAHANG as [MÃ HÀNG],TENHANG as [TÊN HÀNG],SIZE as[SIZE],NHASX as[NHÀ SẢN XUẤT],GIABAN as[GIÁ BÁN],SLTON as[SL TỒN],ANH as[ẢNH] from HANGHOA where TENHANG  like N'%" + ten + "%'");
            dbconnect.Closeconnect();
            return table;
        }
    }
}

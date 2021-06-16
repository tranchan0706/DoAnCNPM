using QLSHOPQA.CONNECT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSHOPQA.BUS
{
    class CTNHAPHANGBUS
    {
        connect dbconnect = new connect();
        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select  SOPHIEU as [SỐ PHIẾU],MAHANG as [MÃ HÀNG],SOLUONGNHAP as [SỐ LƯỢNG NHẬP],DONGIA as [ĐƠN GIÁ],THANHTIEN as [THÀNH TIỀN] from CTNHAPHANG");
            dbconnect.Closeconnect();
            return table;
        }
        public DataTable loaddataPN(string SOPHIEU)
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select  MAHANG as [MÃ HÀNG],SOLUONGNHAP as [SỐ LƯỢNG NHẬP],DONGIA as [ĐƠN GIÁ],THANHTIEN as [THÀNH TIỀN] from CTNHAPHANG WHERE SOPHIEU='" + SOPHIEU + "'");
            dbconnect.Closeconnect();
            return table;
        }
        public void InsertCTNHAPHANG(CTNHAPHANG CT)
        {
            string insert = "insert into CTNHAPHANG(SOPHIEU,MAHANG,SOLUONGNHAP,DONGIA,THANHTIEN) values(";
            insert += "'" + CT.SOPHIEU1 + "',";
            insert += "'" + CT.MAHANG1 + "',";
            insert += "" + CT.SOLUONGNHAP1 + ",";
            insert += "" + CT.DONGIA1 + ",";
            insert += "" + CT.THANHTIEN1 + ")";
            dbconnect.query1(insert);
        }
        public void DeleteCTNHAPHANG(string ma)
        {
            string delete = "delete from CTNHAPHANG where SOPHIEU='" + ma + "'";
            dbconnect.query1(delete);
        }
    }
}

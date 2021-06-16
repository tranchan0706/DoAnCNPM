using QLSHOPQA.CONNECT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSHOPQA.BUS
{
    class HOADONBUS
    {
        connect dbconnect = new connect();
        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select MAHD as[MÃ HÓA ĐƠN], MANV as[MÃ NV], NGAYLAP as[NGÀY LẬP], TONGTIEN as[TỔNG TIỀN] from HOADON");
            dbconnect.Closeconnect();
            return table;
        }
        public void InsertHOADON(HOADON HD)
        {
            string insert = "insert into HOADON(MAHD,NGAYLAP,TONGTIEN,MANV,MAKH) values(";
            insert += "DBO.AUTO_IDHD(),";
            insert += "GETDATE(),";
            insert += "" + HD.TONGTIEN1 + ",";
            insert += "'" + HD.MANV1 + "',";
            insert += "'" + HD.MAKH1 + "')";
            dbconnect.query1(insert);

        }
        public void DeleteHOADON(string ma)
        {
            string delete = "delete from HOADON where MAHD='" + ma + "'";
            dbconnect.query1(delete);
        }
    }
}

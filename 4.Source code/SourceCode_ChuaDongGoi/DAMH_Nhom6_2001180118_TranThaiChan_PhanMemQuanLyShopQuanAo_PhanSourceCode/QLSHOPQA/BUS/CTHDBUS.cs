using QLSHOPQA.CONNECT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSHOPQA.BUS
{
    class CTHDBUS
    {
        connect dbconnect = new connect();
        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select  MAHD as [MÃ HÓA ĐƠN],MAHANG as [MÃ HÀNG],SOLUONG as [SỐ LƯỢNG],DONGIA as [ĐƠN GIÁ],GIAMGIA as [GIẢM GIÁ],THANHTIEN as [THÀNH TIỀN]from CTHD");
            dbconnect.Closeconnect();
            return table;
        }
        public DataTable loaddataHD(string MAHD)
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select  MAHANG as [MÃ HÀNG],SOLUONG as [SỐ LƯỢNG],DONGIA as [ĐƠN GIÁ],GIAMGIA as [GIẢM GIÁ],THANHTIEN as [THÀNH TIỀN]from CTHD WHERE MAHD='" + MAHD+"'");
            dbconnect.Closeconnect();
            return table;
        }
        public void InsertCTHD(CTHD CT)
        {
            string insert = "insert into CTHD(MAHD,MAHANG,SOLUONG,DONGIA,GIAMGIA,THANHTIEN) values(";
            insert += "'" + CT.MAHD1 + "',";
            insert += "'" + CT.MAHANG1 + "',";
            insert += "" + CT.SOLUONG1 + ",";
            insert += "" + CT.DONGIA1 + ",";
            insert += "" + CT.GIAMGIA1 + ",";
            insert += "" + CT.THANHTIEN1 + ")";
            dbconnect.query1(insert);
        }
        public void DeleteCTHD(string ma)
        {
            string delete = "delete from CTHD where MAHD='" + ma + "'";
            dbconnect.query1(delete);
        }
    }
}

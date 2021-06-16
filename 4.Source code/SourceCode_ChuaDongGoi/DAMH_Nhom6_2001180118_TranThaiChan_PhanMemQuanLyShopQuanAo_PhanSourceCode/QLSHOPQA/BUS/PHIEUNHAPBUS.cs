using QLSHOPQA.CONNECT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSHOPQA.BUS
{
    class PHIEUNHAPBUS
    {
        connect dbconnect = new connect();
        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select SOPHIEU as[MÃ HÓA ĐƠN],NGAYNHAP as[NGÀY NHẬP], MANV as[MÃ NV],MANCC as[MÃ NCC], TONGTIEN as[TỔNG TIỀN] from PHIEUNHAPHANG");
            dbconnect.Closeconnect();
            return table;
        }
        public void InsertPHIEUNHAP(PHIEUNHAP PN)
        {
            string insert = "insert into PHIEUNHAPHANG(SOPHIEU,NGAYNHAP,TONGTIEN,MANV,MANCC) values(";
            insert += "DBO.AUTO_IDPN(),";
            insert += "GETDATE(),";
            insert += "" + PN.TONGTIEN1 + ",";
            insert += "'" + PN.MANV1 + "',";
            insert += "'" + PN.MANCC1 + "')";
            dbconnect.query1(insert);

        }
        public void DeletePHIEUNHAP(string ma)
        {
            string delete = "delete from PHIEUNHAPHANG where SOPHIEU='" + ma + "'";
            dbconnect.query1(delete);
        }
    }
}

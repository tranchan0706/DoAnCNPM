using QLSHOPQA.CONNECT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSHOPQA.BUS
{
    class KHACHHANGBUS
    {
        connect dbconnect = new connect();
        public DataTable getdata()
        {
            dbconnect.Openconnect();
            DataTable table = new DataTable();
            table = dbconnect.returnquery("select  MAKH as [MÃ KHÁCH],TENKH as [TÊN KHÁCH],CMND as[CMND],DIACHI as[ĐỊA CHỈ],SDT as[SĐT],DIEMTL as[ĐIỂM TL],QL as[MÃ NV] from KHACHHANGTT");
            dbconnect.Closeconnect();
            return table;
        }
        public void InsertKHACHHANGTT(KHACHHANG KH)
        {
            string insert = "insert into KHACHHANGTT(MAKH,TENKH,CMND,DIACHI,SDT,DIEMTL,QL) values(";
            insert += "DBO.AUTO_IDKH(),";
            insert += "N'" + KH.TENKH1 + "',";
            insert += "'" + KH.CMND1 + "',";
            insert += "N'" + KH.DIACHI1 + "',";
            insert += "'" + KH.SDT1 + "',";
            insert += "" + KH.DIEMTL1 + ",";
            insert += "'" + KH.QL1 + "')";
            dbconnect.query1(insert);

        }
        public void UpdateKHACHHANGTT(KHACHHANG KH, string ma)
        {
            string update = "update KHACHHANGTT set ";
            update += "TENKH=N'" + KH.TENKH1 + "',";
            update += "CMND='" + KH.CMND1 + "',";
            update += "DIACHI=N'" + KH.DIACHI1 + "',";
            update += "SDT='" + KH.SDT1 + "', ";
            update += "DIEMTL=" + KH.DIEMTL1 + ", ";
            update += "QL='" + KH.QL1 + "' ";
            update += "where MAKH='" + ma + "'";
            dbconnect.query1(update);
        }
        public void UpdateDIEMTL(KHACHHANG KH, string ma)
        {
            string update = "update KHACHHANGTT set ";
            update += "DIEMTL=" + KH.DIEMTL1 + " ";
            update += "where MAKH='" + ma + "'";
            dbconnect.query1(update);
        }

        public void DeleteKHACHHANGTT(string ma)
        {
            string delete = "delete from KHACHHANGTT where MAKH='" + ma + "'";
            dbconnect.query1(delete);
        }
    }
}

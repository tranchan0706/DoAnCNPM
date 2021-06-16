/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     5/16/2021 4:09:03 PM                         */
/*==============================================================*/

create database QL_SHOPQA
go
use QL_SHOPQA
go
if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CTHD') and o.name = 'FK_CTHD_REFERENCE_HANGHOA')
alter table CTHD
   drop constraint FK_CTHD_REFERENCE_HANGHOA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CTHD') and o.name = 'FK_CTHD_REFERENCE_HOADON')
alter table CTHD
   drop constraint FK_CTHD_REFERENCE_HOADON
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CTNHAPHANG') and o.name = 'FK_CTNHAPHA_REFERENCE_HANGHOA')
alter table CTNHAPHANG
   drop constraint FK_CTNHAPHA_REFERENCE_HANGHOA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CTNHAPHANG') and o.name = 'FK_CTNHAPHA_REFERENCE_PHIEUNHA')
alter table CTNHAPHANG
   drop constraint FK_CTNHAPHA_REFERENCE_PHIEUNHA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HOADON') and o.name = 'FK_HOADON_REFERENCE_NVBANHAN')
alter table HOADON
   drop constraint FK_HOADON_REFERENCE_NVBANHAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('KHACHHANGTT') and o.name = 'FK_KHACHHAN_REFERENCE_QUANLY')
alter table KHACHHANGTT
   drop constraint FK_KHACHHAN_REFERENCE_QUANLY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('NVBANHANG') and o.name = 'FK_NVBANHAN_REFERENCE_QLTAIKHO')
alter table NVBANHANG
   drop constraint FK_NVBANHAN_REFERENCE_QLTAIKHO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHIEUNHAPHANG') and o.name = 'FK_PHIEUNHA_REFERENCE_THUKHO')
alter table PHIEUNHAPHANG
   drop constraint FK_PHIEUNHA_REFERENCE_THUKHO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHIEUNHAPHANG') and o.name = 'FK_PHIEUNHA_REFERENCE_NHACUNGC')
alter table PHIEUNHAPHANG
   drop constraint FK_PHIEUNHA_REFERENCE_NHACUNGC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHIEUTHONGKE') and o.name = 'FK_PHIEUTHO_REFERENCE_QUANLY')
alter table PHIEUTHONGKE
   drop constraint FK_PHIEUTHO_REFERENCE_QUANLY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QUANLY') and o.name = 'FK_QUANLY_REFERENCE_QLTAIKHO')
alter table QUANLY
   drop constraint FK_QUANLY_REFERENCE_QLTAIKHO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('THUKHO') and o.name = 'FK_THUKHO_REFERENCE_QLTAIKHO')
alter table THUKHO
   drop constraint FK_THUKHO_REFERENCE_QLTAIKHO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CTHD')
            and   type = 'U')
   drop table CTHD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CTNHAPHANG')
            and   type = 'U')
   drop table CTNHAPHANG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('HANGHOA')
            and   type = 'U')
   drop table HANGHOA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('HOADON')
            and   type = 'U')
   drop table HOADON
go

if exists (select 1
            from  sysobjects
           where  id = object_id('KHACHHANGTT')
            and   type = 'U')
   drop table KHACHHANGTT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NHACUNGCAP')
            and   type = 'U')
   drop table NHACUNGCAP
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PHIEUNHAPHANG')
            and   type = 'U')
   drop table PHIEUNHAPHANG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PHIEUTHONGKE')
            and   type = 'U')
   drop table PHIEUTHONGKE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('QLTAIKHOAN')
            and   type = 'U')
   drop table QLTAIKHOAN
go
/*==============================================================*/
/* Table: CTHD                                                  */
/*==============================================================*/
create table CTHD (
   MAHD                 char(5)             not null,
   MAHANG               char(5)             not null,
   SOLUONG              int                 null,
   DONGIA               int                 null,
   GIAMGIA				int  			    null,
   THANHTIEN            int                 null,
   constraint PK_CTHD primary key nonclustered (MAHD, MAHANG)
)
go

/*==============================================================*/
/* Table: CTNHAPHANG                                            */
/*==============================================================*/
create table CTNHAPHANG (
   SOPHIEU              char(5)             not null,
   MAHANG               char(5)             not null,
   SOLUONGNHAP          int                 null,
   DONGIA               int                 null,
   THANHTIEN            int                 null,
   constraint PK_CTNHAPHANG primary key nonclustered (MAHANG, SOPHIEU)
)
go

/*==============================================================*/
/* Table: HANGHOA                                               */
/*==============================================================*/
CREATE FUNCTION AUTO_IDHH()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MAHANG) FROM HANGHOA) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MAHANG, 3)) FROM HANGHOA
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'HH00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'HH0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table HANGHOA (
   MAHANG               CHAR(5)              PRIMARY KEY CONSTRAINT IDHH DEFAULT DBO.AUTO_IDHH(),
   TENHANG              NVARCHAR(50)         null,
   SIZE                 char(5)              null,
   NHASX                NVARCHAR(50)         null,
   GIABAN               int                  null,
   SLTON                int                  null,
   ANH                  NVARCHAR(200)        null,
   --constraint PK_HANGHOA primary key nonclustered (MAHANG)
)
go

/*==============================================================*/
/* Table: HOADON                                                */
/*==============================================================*/
CREATE FUNCTION AUTO_IDHD()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MAHD) FROM HOADON) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MAHD, 3)) FROM HOADON
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'HD00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'HD0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table HOADON (
   MAHD                 char(5)             PRIMARY KEY CONSTRAINT IDHD DEFAULT DBO.AUTO_IDHD(),
   NGAYLAP              datetime            null,
   TONGTIEN             int                 null,
   MANV                 char(5)             null,
   MAKH                 char(5)             null,
   --constraint PK_HOADON primary key nonclustered (MAHD)
)
GO

/*==============================================================*/
/* Table: KHACHHANGTT                                           */
/*==============================================================*/
CREATE FUNCTION AUTO_IDKH()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MAKH) FROM KHACHHANGTT) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MAKH, 3)) FROM KHACHHANGTT
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'KH00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'KH0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table KHACHHANGTT (
   MAKH                 CHAR(5)             PRIMARY KEY CONSTRAINT IDKH DEFAULT DBO.AUTO_IDKH(),
   TENKH                NVARCHAR(50)        null,
   CMND                 char(20)            null,
   DIACHI               NVARCHAR(50)        null,
   SDT                  char(13)            null,
   DIEMTL               float               null,
   QL                   char(5)             null,
  -- constraint PK_KHACHHANGTT primary key nonclustered (MAKH)
)
GO

/*==============================================================*/
/* Table: NHACUNGCAP                                            */
/*==============================================================*/
CREATE FUNCTION AUTO_IDNCC()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MANCC) FROM NHACUNGCAP) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MANCC, 3)) FROM NHACUNGCAP
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'NC00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'NC0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table NHACUNGCAP (
   MANCC                CHAR(5)             PRIMARY KEY CONSTRAINT IDNCC DEFAULT DBO.AUTO_IDNCC(),
   TENCC                NVARCHAR(50)        null,
   DIACHI               NVARCHAR(50)        null,
   DIENTHOAI            char(13)            null,
   --constraint PK_NHACUNGCAP primary key nonclustered (MANCC)
)
go

/*==============================================================*/
/* Table: PHIEUNHAPHANG                                         */
/*==============================================================*/
CREATE FUNCTION AUTO_IDPN()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(SOPHIEU) FROM PHIEUNHAPHANG) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(SOPHIEU, 3)) FROM PHIEUNHAPHANG
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PN00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PN0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table PHIEUNHAPHANG (
   SOPHIEU              CHAR(5)             PRIMARY KEY CONSTRAINT IDPN DEFAULT DBO.AUTO_IDPN(),
   NGAYNHAP             datetime            null,
   TONGTIEN             int                 null,
   MANV                 char(5)             null,
   MANCC                char(5)             null,
   --constraint PK_PHIEUNHAPHANG primary key nonclustered (SOPHIEU)
)
go

/*==============================================================*/
/* Table: PHIEUTHONGKE                                          */
/*==============================================================*/
create table PHIEUTHONGKE (
   SOPHIEU              char(5)             not null,
   NGAYTHONGKE          datetime            null,
   DOANHTHU             int                 null,
   THU                  int                 null,
   CHI                  int                 null,
   QUANLY               char(5)             null,
   constraint PK_PHIEUTHONGKE primary key nonclustered (SOPHIEU)
)
go

/*==============================================================*/
/* Table: QLTAIKHOAN                                            */
/*==============================================================*/
CREATE FUNCTION AUTO_IDNV()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MANV) FROM QLTAIKHOAN) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MANV, 3)) FROM QLTAIKHOAN
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'NV00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'NV0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table QLTAIKHOAN (
   MANV                 CHAR(5)             PRIMARY KEY CONSTRAINT IDNV DEFAULT DBO.AUTO_IDNV(),
   TENNV                NVARCHAR(50)         null,
   TENTK                char(20)             null,
   MATKHAU              char(20)             null,
   NGAYSINH             date			     null,
   DIACHI               NVARCHAR(50)         null,
   SDT                  char(13)             null,
   CHUCVU               NVARCHAR(50)         null,
   LUONG                int					 null,
   PHUCAP               int                  null,
   --constraint PK_QLTAIKHOAN primary key nonclustered (MANV)
)
go

alter table CTHD
   add constraint FK_CTHD_REFERENCE_HANGHOA foreign key (MAHANG)
      references HANGHOA (MAHANG)
go

alter table CTHD
   add constraint FK_CTHD_REFERENCE_HOADON foreign key (MAHD)
      references HOADON (MAHD)
go

alter table CTNHAPHANG
   add constraint FK_CTNHAPHA_REFERENCE_HANGHOA foreign key (MAHANG)
      references HANGHOA (MAHANG)
go

alter table CTNHAPHANG
   add constraint FK_CTNHAPHA_REFERENCE_PHIEUNHA foreign key (SOPHIEU)
      references PHIEUNHAPHANG (SOPHIEU)
go

alter table HOADON
   add constraint FK_HOADON_REFERENCE_NVBANHAN foreign key (MANV)
      references QLTAIKHOAN (MANV)
go

alter table KHACHHANGTT
   add constraint FK_KHACHHAN_REFERENCE_QLTAIKHOAN foreign key (QL)
      references QLTAIKHOAN (MANV)
go

alter table PHIEUNHAPHANG
   add constraint FK_PHIEUNHA_REFERENCE_THUKHO foreign key (MANV)
      references QLTAIKHOAN (MANV)
go

alter table PHIEUNHAPHANG
   add constraint FK_PHIEUNHA_REFERENCE_NHACUNGC foreign key (MANCC)
      references NHACUNGCAP (MANCC)
go

alter table PHIEUTHONGKE
   add constraint FK_PHIEUTHO_REFERENCE_QUANLY foreign key (QUANLY)
      references QLTAIKHOAN (MANV)
go
-----------------------------------------------------------------------------------
--------------------------------------TRIGGER---------------------------------------------
--1. Trigger cập nhật số lượng hàng trong kho sau khi mua hàng 
CREATE TRIGGER TRIGGER_MUAHANG
ON CTHD
FOR INSERT
AS
	UPDATE HANGHOA
	SET SLTON = HANGHOA.SLTON - (SELECT soluong FROM inserted WHERE MAHANG = HANGHOA.MAHANG)
	FROM HANGHOA 
	JOIN inserted ON HANGHOA.MAHANG = inserted.MAHANG
GO
--2. Trigger cập nhật hàng trong kho sau khi cập nhật mua hàng 
CREATE  TRIGGER TRIGGER_CAPNHATHANG
on CTHD 
FOR update
AS
   UPDATE HANGHOA SET SLTON = HANGHOA.SLTON -
	   (SELECT soluong FROM inserted WHERE MAHANG = HANGHOA.MAHANG) +
	   (SELECT soluong FROM deleted WHERE MAHANG = HANGHOA.MAHANG)
   FROM HANGHOA 
   JOIN deleted ON HANGHOA.MAHANG = deleted.MAHANG

GO
--3. Trigger cập nhật hàng trong kho sau khi hủy mua hàng
create TRIGGER trigger_HUYHANG
ON CTHD
FOR DELETE 
AS
	UPDATE HANGHOA
	SET SLTON = HANGHOA.SLTON + (SELECT soluong FROM deleted WHERE MAHANG = HANGHOA.MAHANG)
	FROM HANGHOA 
	JOIN deleted ON HANGHOA.MAHANG = deleted.MAHANG
GO
--4. Trigger cập nhật số lượng hàng trong kho sau khi nhập hàng 
CREATE TRIGGER TRIGGER_NHAPHANG
ON CTNHAPHANG
FOR INSERT
AS
	UPDATE HANGHOA
	SET SLTON = HANGHOA.SLTON + (SELECT SOLUONGNHAP FROM inserted WHERE MAHANG = HANGHOA.MAHANG)
	FROM HANGHOA 
	JOIN inserted ON HANGHOA.MAHANG = inserted.MAHANG
GO
--3. Trigger cập nhật hàng trong kho sau khi trả hàng nhập hàng
CREATE TRIGGER trigger_TRAHANG
ON CTNHAPHANG
FOR DELETE 
AS
	UPDATE HANGHOA
	SET SLTON = HANGHOA.SLTON - (SELECT SOLUONGNHAP FROM deleted WHERE MAHANG = HANGHOA.MAHANG)
	FROM HANGHOA 
	JOIN deleted ON HANGHOA.MAHANG = deleted.MAHANG
GO
----------------------------------------------------------------------------------------------
----------------------------------------PROCEDURE---------------------------------------------
CREATE PROC sp_KiemTraDangNhap(@tk char(10),@mk char(20))
AS
	BEGIN
	--KIỂM TRA TÀI KHOẢN
		IF EXISTS (SELECT 1 FROM DBO.QLTAIKHOAN WHERE DBO.QLTAIKHOAN.TENTK = @tk and DBO.QLTAIKHOAN.MATKHAU=@mk)
		BEGIN
		RETURN 1;-- TÀI KHOẢN TỒN TẠI
		END
			RETURN 0;--TÀI KHOẢN KHÔNG TỒN TẠI
	END
go
CREATE PROC sp_KiemTraChucVu(@ma char(10))
AS
	BEGIN
	--KIỂM TRA TÀI KHOẢN
		IF EXISTS (SELECT 1 FROM DBO.QLTAIKHOAN WHERE DBO.QLTAIKHOAN.MANV = @ma AND DBO.QLTAIKHOAN.CHUCVU = N'QUẢN LÝ')
		BEGIN
		RETURN 1;-- TÀI KHOẢN QUẢN LÝ
		END
		IF EXISTS (SELECT 2 FROM DBO.QLTAIKHOAN WHERE DBO.QLTAIKHOAN.MANV = @ma AND DBO.QLTAIKHOAN.CHUCVU = N'THỦ KHO')
		BEGIN
		RETURN 2;-- TÀI KHOẢN THỦ KHO
		END
			RETURN 0;--TÀI KHOẢN NHÂN VIÊN
	END
go
create proc sp_TimChucVu
@tk nvarchar(20),@mk nvarchar(20),@chucvu nvarchar(20) output
as
   select DBO.QLTAIKHOAN.CHUCVU as N'CHỨC VỤ' from DBO.QLTAIKHOAN where @mk=MATKHAU AND @tk=TENTK
go
--declare @chucvu nvarchar(20)
--exec sp_TimChucVu 'CHAN','123',@chucvu output
GO
CREATE PROC sp_KiemTraMAKH (@mahd char(10))
AS
	BEGIN
		IF EXISTS (SELECT 1 FROM DBO.HOADON WHERE DBO.HOADON.MAHD = @mahd AND DBO.HOADON.MAKH like 'KH%')
		BEGIN
		RETURN 1;-- KHÁCH HÀNG THÂN THIẾT
		END
			RETURN 0;-- KHÁCH VÃNG LAI
	END
GO
CREATE PROC sp_KiemTraDIEMTL (@MAKH char(10))
AS
	BEGIN
		IF (SELECT DBO.KHACHHANGTT.DIEMTL FROM DBO.KHACHHANGTT WHERE DBO.KHACHHANGTT.MAKH=@MAKH)>50
		BEGIN
			UPDATE DBO.KHACHHANGTT
			SET DBO.KHACHHANGTT.DIEMTL = 0
			WHERE DBO.KHACHHANGTT.MAKH=@MAKH
		END
	END
go
----------------------------------------------------------------------------------------------
----------------------------------------INSERT INTO-------------------------------------------
SET DATEFORMAT DMY
GO
INSERT INTO HANGHOA
VALUES
(DBO.AUTO_IDHH(),N'ÁO THUN TAY NGẮN TRƠN','L',N'LACOSTE',165000,1075,N'aosomi1.jpg'),
(DBO.AUTO_IDHH(),N'ÁO THUN TAY NGẮN HỌA TIẾT','XL',N'GUCCI',200000,895,N'aosomi2.jpg'),
(DBO.AUTO_IDHH(),N'ÁO THUN TAY NGẮN CỔ TRỤ','M',N'TOMMY',250000,756,N'aosomi3.jpg'),
(DBO.AUTO_IDHH(),N'ÁO THUN TAY NGẮN IN HÌNH','L',N'ADIDAS',150000,1025,N'aosomi4.jpg'),
(DBO.AUTO_IDHH(),N'ÁO THUN TAY DÀI TRƠN','M',N'NIKE',180000,550,N'aosomi5.jpg');
GO
INSERT INTO QLTAIKHOAN
VALUES
(dbo.AUTO_IDNV(),N'TRẦN THÁI CHÂN','CHAN','123','07/06/2000',N'TÂN PHÚ','05905034636',N'QUẢN LÝ',10000000,500000),
(dbo.AUTO_IDNV(),N'LÊ MINH NHỰT','NHUT','123','01/10/2000',N'GÒ VẤP','023115646546',N'THỦ KHO',7000000,200000),
(dbo.AUTO_IDNV(),N'NGUYỄN THÀNH NHÂN','NHAN','123','25/02/2000',N'TÂN BÌNH','003216556621',N'NHÂN VIÊN',5000000,200000),
(dbo.AUTO_IDNV(),N'TRƯƠNG CÔNG HẬU','HAU','123','12/01/2000',N'TÂN PHÚ','01654654151',N'THỦ KHO',7000000,200000),
(dbo.AUTO_IDNV(),N'NGUYỄN CỬU TRÍ','TRI','123','1/12/2000',N'BÌNH CHÁNH','04654654654',N'NHÂN VIÊN',5000000,200000);
GO
INSERT INTO KHACHHANGTT(MAKH,TENKH,CMND,DIACHI,SDT,DIEMTL,QL)
VALUES
(DBO.AUTO_IDKH(),N'TRẦN THÁI CHÂN','321724774',N'TÂN PHÚ','05905034636',5,'NV003'),
(DBO.AUTO_IDKH(),N'LÊ MINH NHỰT','321868787',N'TÂN BÌNH','02542453543',2,'NV005'),
(DBO.AUTO_IDKH(),N'TRƯƠNG CÔNG HẬU','321656456',N'GÒ VẤP','08678454533',8,'NV001'),
(DBO.AUTO_IDKH(),N'NGUYỄN CỬU TRÍ','321365345',N'BÌNH CHÁNH','0424552542',4,'NV005');
GO
INSERT INTO NHACUNGCAP(MANCC,TENCC,DIACHI,DIENTHOAI)
values(DBO.AUTO_IDNCC(),N'CÔNG TY MAY THÀNH CÔNG',N'TÂY NINH','0326326353'),
(DBO.AUTO_IDNCC(),N'Công Ty Hansae Việt Nam',N'CỦ CHI, TP.HCM','0961555639'),
(DBO.AUTO_IDNCC(),N'Công Ty May Mặc Chiến Lược Xanh',N'TÂN BÌNH, TP.HCM','0326325001'),
(DBO.AUTO_IDNCC(),N'Công Ty Thời Trang Duy Phát',N'HOÀNG MAI, HÀ NỘI','0326254193')
GO
INSERT INTO HOADON(MAHD,NGAYLAP,TONGTIEN,MANV,MAKH)
VALUES
(DBO.AUTO_IDHD(),'25/12/2020',939000,'NV001','KH005'),
(DBO.AUTO_IDHD(),'4/6/2020',165000,'NV001','KH001'),
(DBO.AUTO_IDHD(),'2/10/2020',2374000,'NV003',''),
(DBO.AUTO_IDHD(),'25/4/2021',275000,'NV005',''),
(DBO.AUTO_IDHD(),'14/5/2021',330000,'NV005','KH003'),
(DBO.AUTO_IDHD(),'2/9/2020',440000,'NV003','KH005'),
(DBO.AUTO_IDHD(),'31/5/2021',1499000,'NV001','KH003'),
(DBO.AUTO_IDHD(),'14/2/2021',1100000,'NV003',''),
(DBO.AUTO_IDHD(),'14/2/2020',543000,'NV003','KH002'),
(DBO.AUTO_IDHD(),'15/5/2020',165000,'NV001','KH004'),
(DBO.AUTO_IDHD(),'16/4/2021',396000,'NV005','');
GO
INSERT INTO CTHD(MAHD,MAHANG,SOLUONG,DONGIA,GIAMGIA,THANHTIEN)
VALUES
('HD001','HH001',3,181000,0,543000);
INSERT INTO CTHD(MAHD,MAHANG,SOLUONG,DONGIA,GIAMGIA,THANHTIEN)
VALUES
('HD001','HH005',2,198000,0,396000);
INSERT INTO CTHD(MAHD,MAHANG,SOLUONG,DONGIA,GIAMGIA,THANHTIEN)
VALUES
('HD002','HH004',1,165000,0,165000);
INSERT INTO CTHD(MAHD,MAHANG,SOLUONG,DONGIA,GIAMGIA,THANHTIEN)
VALUES
('HD003','HH001',4,181000,0,724000);
INSERT INTO CTHD(MAHD,MAHANG,SOLUONG,DONGIA,GIAMGIA,THANHTIEN)
VALUES
('HD003','HH002',3,220000,0,660000);
INSERT INTO CTHD(MAHD,MAHANG,SOLUONG,DONGIA,GIAMGIA,THANHTIEN)
VALUES
('HD003','HH005',5,198000,0,990000);
INSERT INTO CTHD(MAHD,MAHANG,SOLUONG,DONGIA,GIAMGIA,THANHTIEN)
VALUES
('HD004','HH003',1,275000,0,275000);
INSERT INTO CTHD(MAHD,MAHANG,SOLUONG,DONGIA,GIAMGIA,THANHTIEN)
VALUES
('HD005','HH004',2,165000,0,330000);
INSERT INTO CTHD(MAHD,MAHANG,SOLUONG,DONGIA,GIAMGIA,THANHTIEN)
VALUES
('HD006','HH002',2,220000,0,440000);
INSERT INTO CTHD(MAHD,MAHANG,SOLUONG,DONGIA,GIAMGIA,THANHTIEN)
VALUES
('HD007','HH005',3,198000,0,594000);
INSERT INTO CTHD(MAHD,MAHANG,SOLUONG,DONGIA,GIAMGIA,THANHTIEN)
VALUES
('HD007','HH001',5,181000,0,905000);
INSERT INTO CTHD(MAHD,MAHANG,SOLUONG,DONGIA,GIAMGIA,THANHTIEN)
VALUES
('HD008','HH003',4,275000,0,1100000);
INSERT INTO CTHD(MAHD,MAHANG,SOLUONG,DONGIA,GIAMGIA,THANHTIEN)
VALUES
('HD009','HH001',3,181000,0,543000);
INSERT INTO CTHD(MAHD,MAHANG,SOLUONG,DONGIA,GIAMGIA,THANHTIEN)
VALUES
('HD010','HH004',1,165000,0,165000);
INSERT INTO CTHD(MAHD,MAHANG,SOLUONG,DONGIA,GIAMGIA,THANHTIEN)
VALUES
('HD011','HH005',2,198000,0,396000);
-------------------------------------------------------------------------------------------
----------------------------------------SELECT---------------------------------------------
--XEM MÃ HD TẠO TỰ ĐỘNG
	--declare @ma nvarchar(20)
	--exec @ma= DBO.AUTO_IDHD
	--select @ma

--THỐNG KÊ DOANH THU HÀNG HÓA BÁN ĐƯỢC
--	select MAHANG, TENHANG,'SL BAN'=(select sum(CTHD.SOLUONG) from CTHD where MAHANG=HH.MAHANG),
--		   'TONG TIEN'=(select sum(CTHD.THANHTIEN) from CTHD where MAHANG=HH.MAHANG)
--	from HANGHOA HH
--	WHERE MAHANG IN (SELECT MAHANG FROM CTHD C JOIN HOADON H ON C.MAHD=H.MAHD WHERE MONTH(ngaylap)=5 and YEAR(ngaylap)=2021)

--THỐNG KÊ DOANH THU THEO QUÝ
--	GO
--	declare @QUY int
--	SET @QUY = 2;
--	select MAHANG, TENHANG,'SL BAN'=(select sum(CTHD.SOLUONG) from CTHD where MAHANG=HH.MAHANG),
--		'TONG TIEN'=(select sum(CTHD.THANHTIEN) from CTHD where MAHANG=HH.MAHANG)
--	from HANGHOA HH
--	WHERE (MAHANG IN (SELECT MAHANG FROM CTHD C JOIN HOADON H ON C.MAHD=H.MAHD WHERE (MONTH(ngaylap) between 1 and 3)and YEAR(ngaylap)=2021) AND @QUY=1)--QUÝ 1
--	or (MAHANG IN (SELECT MAHANG FROM CTHD C JOIN HOADON H ON C.MAHD=H.MAHD WHERE (MONTH(ngaylap) between 4 and 6)and YEAR(ngaylap)=2021)AND @QUY =2)--QUÝ 2
--	or (MAHANG IN (SELECT MAHANG FROM CTHD C JOIN HOADON H ON C.MAHD=H.MAHD WHERE (MONTH(ngaylap) between 7 and 9)and YEAR(ngaylap)=2021)AND @QUY =3)--QUÝ 3
--	or (MAHANG IN (SELECT MAHANG FROM CTHD C JOIN HOADON H ON C.MAHD=H.MAHD WHERE (MONTH(ngaylap) between 10 and 12)and YEAR(ngaylap)=2021)AND @QUY =4)--QUÝ 4

--THỐNG KÊ DOANH THU THEO NHÂN VIÊN
--	select T.MANV,TENNV,'TONG TIEN'=(select sum(H.TONGTIEN) from HOADON H where MANV=T.MANV)
--	from QLTAIKHOAN T
--	WHERE T.MANV IN (SELECT MANV FROM HOADON WHERE MONTH(ngaylap)=5 and YEAR(ngaylap)=2021)

-- IN HÓA ĐƠN
	--select distinct C.MAHD,HH.MAHANG,HH.TENHANG,HD.MAKH,C.SOLUONG,C.THANHTIEN 
	--from HOADON HD join CTHD C on C.MAHD=HD.MAHD 
	--			  JOIN HANGHOA HH ON HH.MAHANG = C.MAHANG
	--where C.MAHD='HD001'
-----------------------------------------------------------------------
	--SELECT Anh,SUM(dh.Soluong) 
	--FROM (HANGHOA as nv INNER JOIN CTHD as dh ON nv.Mahang = dh.Mahang) 
	--INNER JOIN HOADON as ct ON ct.MaHD=dh.MaHD 
	--GROUP BY Anh having SUM(dh.Soluong) >= all
	--	(SELECT SUM(h.Soluong) 
	--	FROM (HANGHOA as v INNER JOIN CTHD as h ON v.Mahang = h.Mahang) 
	--	INNER JOIN HOADON as t ON t.MaHD=h.MaHD 
	--	GROUP BY Anh)

	--SELECT SUM(dh.Soluong) 
	--FROM (HANGHOA as nv INNER JOIN CTHD as dh ON nv.Mahang = dh.Mahang) 
	--INNER JOIN HOADON as ct ON ct.MaHD=dh.MaHD 
	--GROUP BY Anh having SUM(dh.Soluong) >= all
	--	(SELECT SUM(h.Soluong) FROM (HANGHOA as v INNER JOIN CTHD as h ON v.Mahang = h.Mahang) 
	--	INNER JOIN HOADON as t ON t.MaHD=h.MaHD 
	--	GROUP BY Anh)

	--select MONTH(NGAYLAP),sum(Soluong) 
	--from HOADON,CTHD 
	--where HOADON.MaHD = CTHD.MaHD 
	--group by MONTH(NGAYLAP)

	--select MONTH(NGAYLAP),COUNT(HOADON.MaHD),COUNT(Mahang),sum(Soluong),SUM(Tongtien) 
	--from HOADON,CTHD 
	--where HOADON.MaHD = CTHD.MaHD 
	--group by MONTH(NGAYLAP)
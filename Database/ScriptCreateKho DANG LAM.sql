CREATE DATABASE QuanLyKho
GO

USE DVDLibrary

USE QuanLyKho
GO

CREATE TABLE users
(
	taikhoan nvarchar(32) PRIMARY KEY NOT NULL,
	matkhau nvarchar(32)
)
GO

INSERT INTO users VALUES ('admin', 'admin')

CREATE TABLE DVT
(
	id int PRIMARY KEY,
	Tendvt nvarchar(20)
)
GO

CREATE TABLE NhaCungCap
(
	Mancc int PRIMARY KEY,
	Tenncc nvarchar(100),
	Diachincc nvarchar(100),
	Sdtncc nvarchar(20),
	Emailncc nvarchar(100),
)
GO

CREATE TABLE KhachHang
(
	Makh nvarchar(20) PRIMARY KEY,
	Tenkh nvarchar(100),
	Diachikh nvarchar(100),
	Sdtkh nvarchar(20),
	Emailkh nvarchar(100),	
)
GO

CREATE TABLE HangHoa
(
	Mahh nvarchar(128) NOT NULL PRIMARY KEY,
	Tenhh nvarchar(100),
	idDVT int NOT NULL,
	Mancc int NOT NULL,
	Soluonghh float DEFAULT 0,
	FOREIGN KEY (idDVT) REFERENCES DVT(id),
	FOREIGN KEY (Mancc) REFERENCES NhaCungCap(Mancc)
)
GO

SELECT * FROM HangHoa

ALTER TABLE HangHoa
ADD Giaxuat float DEFAULT 0

CREATE TABLE PhieuNhapKho
(
	Sttpnk nvarchar(50) NOT NULL PRIMARY KEY,
	Datepnk Datetime
)
GO

ALTER TABLE PhieuNhapKho
ADD Tongtien float

CREATE TABLE ChiTietPhieuNhap
(
	Sttpnk nvarchar(50) NOT NULL,
	Mahh nvarchar(128) NOT NULL,
	Soluongnhap float,
	Gianhap float DEFAULT 0,
	FOREIGN KEY (Mahh) REFERENCES HangHoa(Mahh),
	FOREIGN KEY (Sttpnk) REFERENCES PhieuNhapKho(Sttpnk),
)
GO
ALTER TABLE ChiTietPhieuNhap
ADD PRIMARY KEY (Sttpnk, Mahh);


ALTER TABLE ChiTietPhieuNhap
ADD Thanhtien float

CREATE TABLE PhieuXuatKho
(
	Sttpxk nvarchar(50) NOT NULL PRIMARY KEY,
	Datepxk Datetime,
	Makh int NOT NULL,
	FOREIGN KEY (Makh) REFERENCES KhachHang(Makh)
)
GO
ALTER TABLE PhieuXuatKho
ADD Makh nvarchar(20)

ALTER TABLE PhieuXuatKho
ADD Tongtienpxk float

ALTER TABLE PhieuXuatKho
DROP COLUMN Makh;

ALTER TABLE PhieuXuatKho
ADD FOREIGN KEY (Makh) REFERENCES KhachHang(Makh);


CREATE TABLE ChiTietPhieuXuat
(
	Sttpxk nvarchar(50) PRIMARY KEY NOT NULL,
	Mahh nvarchar(128) PRIMARY KEY NOT NULL,
	Soluongxuat float,
	Giaxuat FLOAT DEFAULT 0,
	FOREIGN KEY (Mahh) REFERENCES HangHoa(Mahh),
	FOREIGN KEY (Sttpxk) REFERENCES PhieuXuatKho(Sttpxk),
)
GO

ALTER TABLE ChiTietPhieuXuat
ADD Thanhtien float

ALTER TABLE ChiTietPhieuXuat
ADD PRIMARY KEY (Sttpxk, Mahh)
GO
-----------------------------------------------

----INSERT SOME VALUES----

EXEC sp_themNCC 1,N'CÔNG TY ABC', N'Ninh Kiều, Cần Thơ', '02923123123', 'abcfood@abcfood.com'
EXEC sp_themNCC 2,N'CÔNG TY TIN HỌC DEF', N'Cái Răng, Cần Thơ', '02923568789', 'def@def.com'
EXEC sp_themNCC 3,N'CÔNG TY AUS', N'Ninh Kiều, Cần Thơ', '02923789548', 'aus@aus.net'
EXEC sp_themNCC 4,N'CÔNG TY GIGA', N'Ninh Kiều, Cần Thơ', '02923257659', 'giga@giga.org'
EXEC sp_themNCC 5,N'CÔNG TY NGA NGUYỄN', N'Ninh Kiều, Cần Thơ', '0962676738', 'nganguyen@gmail.com'

----------------------------------------------
----INSERT SOME VALUES----

SET IDENTITY_INSERT DVT OFF
EXEC sp_themdvt 1,N'Bao'
EXEC sp_themdvt 2,N'Cái'
EXEC sp_themdvt 3,N'Kg'
EXEC sp_themdvt 4,N'Lít'
EXEC sp_themdvt 5,N'Thùng'
EXEC sp_themdvt 6,N'Bộ'
EXEC sp_themdvt 7,N'Túi'

select * from DVT
-----------------------------------------------
----INSERT SOME VALUES----

-----------------------------------------------
EXEC sp_themHangHoa 'MH001', 'Màn hình Dell 27 inch', 2, 1, 10
EXEC sp_themHangHoa 'MH002', 'Tai nghe AirPod', 2, 3, 2
EXEC sp_themHangHoa 'MH003', N'Chuột DareU', 2, 4, 3
EXEC sp_themHangHoa 'MH004', 'Mainboard ATX', 2, 5, 5
EXEC sp_themHangHoa 'MH005', 'Màn hình Samsung 24 inch', 2, 1, 4
-----------------------------------------------
INSERT INTO PhieuNhapKho(Sttpnk, Datepnk) VALUES ('PNK01', '20201115')
INSERT INTO PhieuNhapKho(Sttpnk, Datepnk) VALUES ('PNK02', '20201114')
INSERT INTO PhieuNhapKho(Sttpnk, Datepnk) VALUES ('PNK03', '20201114')
INSERT INTO PhieuNhapKho(Sttpnk, Datepnk) VALUES ('PNK04', '20201113')
INSERT INTO PhieuNhapKho(Sttpnk, Datepnk) VALUES ('PNK05', '20201112')

SELECT * FROM PhieuNhapKho
-----------------------------------------------
INSERT INTO ChiTietPhieuNhap(sttpnk, Mahh, Soluongnhap, Gianhap) VALUES ('PNK01', 'MH001', 10, 3000000)
INSERT INTO ChiTietPhieuNhap(sttpnk, Mahh, Soluongnhap, Gianhap) VALUES ('PNK02', 'MH002', 2, 1750000)
INSERT INTO ChiTietPhieuNhap(sttpnk, Mahh, Soluongnhap, Gianhap) VALUES ('PNK03', 'MH003', 3, 250000)
INSERT INTO ChiTietPhieuNhap(sttpnk, Mahh, Soluongnhap, Gianhap) VALUES ('PNK04', 'MH004', 5, 2200000)
INSERT INTO ChiTietPhieuNhap(sttpnk, Mahh, Soluongnhap, Gianhap) VALUES ('PNK05', 'MH005', 4, 2700000)
INSERT INTO ChiTietPhieuNhap(sttpnk, Mahh, Soluongnhap, Gianhap) VALUES ('PNK05', 'MH006', 1, 1000000)
INSERT INTO ChiTietPhieuNhap(sttpnk, Mahh, Soluongnhap, Gianhap) VALUES ('PNK05', 'MH007', 1, 50000)
---
select * from ChiTietPhieuNhap
-----------------------------------------------
INSERT INTO KhachHang(Makh,Tenkh, Diachikh, Sdtkh, Emailkh) VALUES (1,N'CÔNG TY TNHH ANH DUY', N'Nhật Tảo, Cái Răng, Cần Thơ', '0962676767', 'tranthienanh@tranthienanh.com')
SELECT * FROM KhachHang
-----------------------------------------------
INSERT INTO PhieuXuatKho(Sttpxk, Datepxk, Makh, Tongtienpxk) VALUES ('PXK001', '20201116', 1, 35000000)
DELETE FROM PhieuXuatKho
SELECT * FROM PhieuXuatKho
-----------------------------------------------
INSERT INTO ChiTietPhieuXuat(Sttpxk, Mahh, Soluongxuat, Giaxuat, Thanhtien) VALUES ('PXK001', 'MH001', 10, 3500000,35000000)
SELECT * FROM ChiTietPhieuXuat
-----------------------------------------------
---VIẾT THÊM TRIGGER TỰ TĂNG - GIẢM SỐ LƯỢNG HIỆN CÓ TRONG KHO !!!


---STORED PROCEDURE----
---THÊM NHÀ CUNG CẤP---

CREATE PROCEDURE sp_themNCC(@macc int,
							@tenncc nvarchar(100),
							@diachi nvarchar(100), 
							@sdtncc nvarchar(20),
							@email nvarchar(100))
AS
	INSERT INTO NhaCungCap(Mancc,Tenncc,Diachincc,Sdtncc,Emailncc) VALUES (@macc,@tenncc,@diachi, @sdtncc,@email)

---CẬP NHẬT NHÀ CUNG CẤP---
CREATE PROCEDURE sp_updateNCC(@macc int,
							@tenncc nvarchar(100),
							@diachi nvarchar(100), 
							@sdtncc nvarchar(20),
							@email nvarchar(100))
AS
	UPDATE NhaCungCap SET Tenncc=@tenncc, Diachincc=@diachi, Sdtncc=@sdtncc, Emailncc=@email WHERE Mancc=@macc
---TÌM TÊN NHÀ CUNG CẤP---
CREATE PROCEDURE sp_getTenNCC(@tenncc nvarchar(100))
AS
	SELECT * FROM NhaCungCap WHERE Tenncc like '%'+@tenncc+'%'

---THÊM ĐƠN VỊ TÍNH---

CREATE PROCEDURE sp_themdvt(@id int,
							@tendvtinh nvarchar(20))
AS
	INSERT INTO DVT(id,tendvt) VALUES (@id, @tendvtinh)

---CẬP NHẬT ĐƠN VỊ TÍNH---

CREATE PROCEDURE sp_updateDvt(@id int,
							@tendvtinh nvarchar(20))
AS
	UPDATE DVT SET Tendvt = @tendvtinh WHERE id = @id

---LẤY TÊN ĐƠN VỊ TÍNH---
CREATE PROCEDURE sp_getTenDVT
@tendvtinh nvarchar(20)
AS
SELECT id, Tendvt from DVT where Tendvt like '%'+@tendvtinh+'%'

---THÊM HÀNG HÓA---

CREATE PROCEDURE sp_themHangHoa(@mahang nvarchar(128),
								@tenhang nvarchar(100),
								@madvt int,
								@macungcap int
								)
AS
	INSERT INTO HangHoa(Mahh, Tenhh, idDVT, Mancc) VALUES (@mahang, @tenhang, @madvt, @macungcap)
---CẬP NHẬT HÀNG HÓA---
CREATE PROCEDURE sp_updateHangHoa(@mahang nvarchar(128),
								@tenhang nvarchar(100),
								@madvt int,
								@macungcap int)
AS
	UPDATE HangHoa SET Tenhh=@tenhang,idDVT = @madvt,Mancc=@macungcap WHERE Mahh=@mahang

--TÌM TÊN HÀNG HÓA---
CREATE PROCEDURE sp_getTenHangHoa(@tenhang nvarchar(100))
AS
	SELECT Mahh, Tenhh, idDVT, B.Tendvt, A.Mancc, C.Tenncc, Soluonghh FROM HangHoa AS A, DVT AS B, NhaCungCap AS C WHERE A.idDVT = B.id AND A.Mancc = C.Mancc AND Tenhh like '%'+@tenhang+'%'

--TÌM MÃ HÀNG HÓA---
CREATE PROCEDURE sp_getMaHangHoa(@mahang nvarchar(100))
AS
	SELECT Mahh, Tenhh, idDVT, B.Tendvt, A.Mancc, C.Tenncc, Soluonghh FROM HangHoa AS A, DVT AS B, NhaCungCap AS C WHERE A.idDVT = B.id AND A.Mancc = C.Mancc AND Mahh like '%'+@mahang+'%'

---THÊM KHÁCH HÀNG---
CREATE PROCEDURE sp_themKH(@makh int,
						   @Ten nvarchar(100),
						   @diaChi nvarchar(100),
						   @sdt nvarchar(100),
						   @Email nvarchar(100))
AS
	INSERT INTO KhachHang(Makh, Tenkh, Diachikh, Sdtkh, Emailkh) VALUES (@makh, @Ten, @diaChi, @sdt, @Email)


---CẬP NHẬT KHÁCH HÀNG---

CREATE PROCEDURE sp_updateKH(@makh int,
						   @Ten nvarchar(100),
						   @diaChi nvarchar(100),
						   @sdt nvarchar(100),
						   @Email nvarchar(100))
AS
	UPDATE KhachHang SET Tenkh = @Ten, Diachikh = @diaChi, Sdtkh = @sdt, Emailkh = @Email WHERE Makh = @makh

---LẤY TÊN KHÁCH HÀNG---
CREATE PROCEDURE sp_getTenKH(@Ten nvarchar(100))
AS
	SELECT Makh, Tenkh, Diachikh, Sdtkh, Emailkh FROM KhachHang WHERE Tenkh like '%'+@Ten+'%'

---XÓA PHIẾU NHẬP KHO---

  CREATE PROCEDURE sp_xoaPNK(@sttpn nvarchar(50))
  AS
	DELETE FROM ChiTietPhieuNhap WHERE Sttpnk = @sttpn
	DELETE FROM [PhieuNhapKho] WHERE Sttpnk = @sttpn


---THÊM PHIẾU XUẤT KHO---

CREATE PROCEDURE sp_themPXK(@mapxk nvarchar(50),
						   @ngayxuat datetime,
						   @makh nvarchar(20),
						   @Tong float)
AS
	INSERT INTO PhieuXuatKho(Sttpxk, Datepxk, Makh, Tongtienpxk) VALUES (@mapxk, @ngayxuat, @makh, @Tong)

EXEC sp_themPXK 'PXK002', '20210101', 'KH001', 3750000
---XÓA PHIẾU XUẤT KHO---

  CREATE PROCEDURE sp_xoaPXK(@sttpx nvarchar(50))
  AS
	DELETE FROM ChiTietPhieuXuat WHERE Sttpxk = @sttpx
	DELETE FROM ChiTietPhieuXuat WHERE Sttpxk = @sttpx


---TRIGGER LẤY GIÁ NHẬP CAO NHẤT CỦA 1 MẶT HÀNG + THÊM 10% ĐỂ THÀNH GIÁ XUẤT---

CREATE TRIGGER ChiTietPhieuNhap_Insert
ON dbo.ChiTietPhieuNhap
FOR INSERT
AS
BEGIN
	declare @gianhap float;
	declare @giaban float;
	SELECT @gianhap = inserted.Gianhap from inserted;
	SELECT @giaban = dbo.HangHoa.Giaxuat from inserted, dbo.HangHoa
	WHERE inserted.Mahh = dbo.HangHoa.mahh
	if(@gianhap > @giaban)
	begin
			UPDATE dbo.HangHoa SET Giaxuat = (@gianhap * 1.1)
			FROM dbo.HangHoa, inserted
			WHERE inserted.Mahh = DBO.HangHoa.Mahh
	end;
END;

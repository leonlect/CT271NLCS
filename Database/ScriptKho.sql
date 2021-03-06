USE [QuanLyKho]
GO
/****** Object:  StoredProcedure [dbo].[sp_xoaPXK]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_xoaPXK]
GO
/****** Object:  StoredProcedure [dbo].[sp_xoaPNK]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_xoaPNK]
GO
/****** Object:  StoredProcedure [dbo].[sp_updateNCC]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_updateNCC]
GO
/****** Object:  StoredProcedure [dbo].[sp_updateKH]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_updateKH]
GO
/****** Object:  StoredProcedure [dbo].[sp_updateHangHoa]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_updateHangHoa]
GO
/****** Object:  StoredProcedure [dbo].[sp_updateDvt]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_updateDvt]
GO
/****** Object:  StoredProcedure [dbo].[sp_themPXK]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_themPXK]
GO
/****** Object:  StoredProcedure [dbo].[sp_themPNK]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_themPNK]
GO
/****** Object:  StoredProcedure [dbo].[sp_themNCC]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_themNCC]
GO
/****** Object:  StoredProcedure [dbo].[sp_themKH]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_themKH]
GO
/****** Object:  StoredProcedure [dbo].[sp_themHangHoa]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_themHangHoa]
GO
/****** Object:  StoredProcedure [dbo].[sp_themdvt]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_themdvt]
GO
/****** Object:  StoredProcedure [dbo].[sp_getTenNCC]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_getTenNCC]
GO
/****** Object:  StoredProcedure [dbo].[sp_getTenKH]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_getTenKH]
GO
/****** Object:  StoredProcedure [dbo].[sp_getTenHangHoa]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_getTenHangHoa]
GO
/****** Object:  StoredProcedure [dbo].[sp_getTenDVT]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_getTenDVT]
GO
/****** Object:  StoredProcedure [dbo].[sp_getPXKbyDate]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_getPXKbyDate]
GO
/****** Object:  StoredProcedure [dbo].[sp_getPNKbyDate]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_getPNKbyDate]
GO
/****** Object:  StoredProcedure [dbo].[sp_getNXT]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_getNXT]
GO
/****** Object:  StoredProcedure [dbo].[sp_getMaHangHoa]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[sp_getMaHangHoa]
GO
/****** Object:  StoredProcedure [dbo].[getAllSLuongXuat]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[getAllSLuongXuat]
GO
/****** Object:  StoredProcedure [dbo].[getAllSLuongNhap]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP PROCEDURE [dbo].[getAllSLuongNhap]
GO
ALTER TABLE [dbo].[PhieuXuatKho] DROP CONSTRAINT [FK__PhieuXuatK__Makh__3D2915A8]
GO
ALTER TABLE [dbo].[HangHoa] DROP CONSTRAINT [FK__HangHoa__Mancc__182C9B23]
GO
ALTER TABLE [dbo].[HangHoa] DROP CONSTRAINT [FK__HangHoa__idDVT__173876EA]
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat] DROP CONSTRAINT [FK__ChiTietPhi__Mahh__24927208]
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat] DROP CONSTRAINT [FK__ChiTietPh__Sttpx__25869641]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] DROP CONSTRAINT [FK__ChiTietPhi__Mahh__1CF15040]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] DROP CONSTRAINT [FK__ChiTietPh__Sttpn__1DE57479]
GO
/****** Object:  Table [dbo].[users]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP TABLE [dbo].[users]
GO
/****** Object:  Table [dbo].[PhieuXuatKho]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP TABLE [dbo].[PhieuXuatKho]
GO
/****** Object:  Table [dbo].[PhieuNhapKho]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP TABLE [dbo].[PhieuNhapKho]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP TABLE [dbo].[NhaCungCap]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP TABLE [dbo].[KhachHang]
GO
/****** Object:  Table [dbo].[HangHoa]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP TABLE [dbo].[HangHoa]
GO
/****** Object:  Table [dbo].[DVT]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP TABLE [dbo].[DVT]
GO
/****** Object:  Table [dbo].[ChiTietPhieuXuat]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP TABLE [dbo].[ChiTietPhieuXuat]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 3/1/2021 1:52:37 PM ******/
DROP TABLE [dbo].[ChiTietPhieuNhap]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 3/1/2021 1:52:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[Sttpnk] [nvarchar](50) NOT NULL,
	[Mahh] [nvarchar](128) NOT NULL,
	[Soluongnhap] [float] NULL,
	[Gianhap] [float] NULL DEFAULT ((0)),
	[Thanhtien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Sttpnk] ASC,
	[Mahh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietPhieuXuat]    Script Date: 3/1/2021 1:52:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuXuat](
	[Sttpxk] [nvarchar](50) NOT NULL,
	[Mahh] [nvarchar](128) NOT NULL,
	[Soluongxuat] [float] NULL,
	[Giaxuat] [float] NULL DEFAULT ((0)),
	[Thanhtien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Sttpxk] ASC,
	[Mahh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DVT]    Script Date: 3/1/2021 1:52:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVT](
	[id] [int] NOT NULL,
	[Tendvt] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HangHoa]    Script Date: 3/1/2021 1:52:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangHoa](
	[Mahh] [nvarchar](128) NOT NULL,
	[Tenhh] [nvarchar](100) NULL,
	[idDVT] [int] NOT NULL,
	[Mancc] [int] NOT NULL,
	[Soluonghh] [float] NULL DEFAULT ((0)),
	[Giaxuat] [float] NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[Mahh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 3/1/2021 1:52:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[Makh] [nvarchar](20) NOT NULL,
	[Tenkh] [nvarchar](100) NULL,
	[Diachikh] [nvarchar](100) NULL,
	[Sdtkh] [nvarchar](20) NULL,
	[Emailkh] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Makh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 3/1/2021 1:52:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[Mancc] [int] NOT NULL,
	[Tenncc] [nvarchar](100) NULL,
	[Diachincc] [nvarchar](100) NULL,
	[Sdtncc] [nvarchar](20) NULL,
	[Emailncc] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Mancc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuNhapKho]    Script Date: 3/1/2021 1:52:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhapKho](
	[Sttpnk] [nvarchar](50) NOT NULL,
	[Datepnk] [datetime] NULL,
	[Tongtien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Sttpnk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuXuatKho]    Script Date: 3/1/2021 1:52:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuXuatKho](
	[Sttpxk] [nvarchar](50) NOT NULL,
	[Datepxk] [datetime] NULL,
	[Makh] [nvarchar](20) NULL,
	[Tongtienpxk] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Sttpxk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[users]    Script Date: 3/1/2021 1:52:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[taikhoan] [nvarchar](32) NOT NULL,
	[matkhau] [nvarchar](32) NULL,
PRIMARY KEY CLUSTERED 
(
	[taikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ChiTietPhieuNhap] ([Sttpnk], [Mahh], [Soluongnhap], [Gianhap], [Thanhtien]) VALUES (N'PNK001', N'MH001', 10, 2500000, 25000000)
INSERT [dbo].[ChiTietPhieuNhap] ([Sttpnk], [Mahh], [Soluongnhap], [Gianhap], [Thanhtien]) VALUES (N'PNK002', N'MH002', 5, 500000, 2500000)
INSERT [dbo].[ChiTietPhieuNhap] ([Sttpnk], [Mahh], [Soluongnhap], [Gianhap], [Thanhtien]) VALUES (N'PNK002', N'MH003', 10, 150000, 1500000)
INSERT [dbo].[ChiTietPhieuNhap] ([Sttpnk], [Mahh], [Soluongnhap], [Gianhap], [Thanhtien]) VALUES (N'PNK003', N'MH004', 15, 3500000, 52500000)
INSERT [dbo].[ChiTietPhieuNhap] ([Sttpnk], [Mahh], [Soluongnhap], [Gianhap], [Thanhtien]) VALUES (N'PNK003', N'MH005', 15, 1200000, 18000000)
INSERT [dbo].[ChiTietPhieuNhap] ([Sttpnk], [Mahh], [Soluongnhap], [Gianhap], [Thanhtien]) VALUES (N'PNK004', N'MH001', 3, 2500000, 7500000)
INSERT [dbo].[ChiTietPhieuNhap] ([Sttpnk], [Mahh], [Soluongnhap], [Gianhap], [Thanhtien]) VALUES (N'PNK004', N'MH002', 10, 500000, 5000000)
INSERT [dbo].[ChiTietPhieuNhap] ([Sttpnk], [Mahh], [Soluongnhap], [Gianhap], [Thanhtien]) VALUES (N'PNK004', N'MH003', 8, 150000, 1200000)
INSERT [dbo].[ChiTietPhieuNhap] ([Sttpnk], [Mahh], [Soluongnhap], [Gianhap], [Thanhtien]) VALUES (N'PNK004', N'MH005', 2, 1200000, 2400000)
INSERT [dbo].[ChiTietPhieuXuat] ([Sttpxk], [Mahh], [Soluongxuat], [Giaxuat], [Thanhtien]) VALUES (N'PXK001', N'MH001', 3, 2750000, 8250000)
INSERT [dbo].[ChiTietPhieuXuat] ([Sttpxk], [Mahh], [Soluongxuat], [Giaxuat], [Thanhtien]) VALUES (N'PXK001', N'MH002', 2, 550000, 1100000)
INSERT [dbo].[ChiTietPhieuXuat] ([Sttpxk], [Mahh], [Soluongxuat], [Giaxuat], [Thanhtien]) VALUES (N'PXK001', N'MH004', 3, 3850000, 11550000)
INSERT [dbo].[ChiTietPhieuXuat] ([Sttpxk], [Mahh], [Soluongxuat], [Giaxuat], [Thanhtien]) VALUES (N'PXK001', N'MH005', 2, 1320000, 2640000)
INSERT [dbo].[ChiTietPhieuXuat] ([Sttpxk], [Mahh], [Soluongxuat], [Giaxuat], [Thanhtien]) VALUES (N'PXK002', N'MH001', 2, 2750000, 5500000)
INSERT [dbo].[ChiTietPhieuXuat] ([Sttpxk], [Mahh], [Soluongxuat], [Giaxuat], [Thanhtien]) VALUES (N'PXK002', N'MH003', 2, 165000, 330000)
INSERT [dbo].[ChiTietPhieuXuat] ([Sttpxk], [Mahh], [Soluongxuat], [Giaxuat], [Thanhtien]) VALUES (N'PXK002', N'MH004', 2, 3850000, 7700000)
INSERT [dbo].[ChiTietPhieuXuat] ([Sttpxk], [Mahh], [Soluongxuat], [Giaxuat], [Thanhtien]) VALUES (N'PXK003', N'MH001', 3, 2750000, 8250000)
INSERT [dbo].[ChiTietPhieuXuat] ([Sttpxk], [Mahh], [Soluongxuat], [Giaxuat], [Thanhtien]) VALUES (N'PXK003', N'MH003', 2, 165000, 330000)
INSERT [dbo].[ChiTietPhieuXuat] ([Sttpxk], [Mahh], [Soluongxuat], [Giaxuat], [Thanhtien]) VALUES (N'PXK003', N'MH004', 2, 3850000, 7700000)
INSERT [dbo].[ChiTietPhieuXuat] ([Sttpxk], [Mahh], [Soluongxuat], [Giaxuat], [Thanhtien]) VALUES (N'PXK003', N'MH005', 2, 1320000, 2640000)
INSERT [dbo].[ChiTietPhieuXuat] ([Sttpxk], [Mahh], [Soluongxuat], [Giaxuat], [Thanhtien]) VALUES (N'PXK004', N'MH003', 2, 165000, 330000)
INSERT [dbo].[ChiTietPhieuXuat] ([Sttpxk], [Mahh], [Soluongxuat], [Giaxuat], [Thanhtien]) VALUES (N'PXK004', N'MH004', 3, 3850000, 11550000)
INSERT [dbo].[ChiTietPhieuXuat] ([Sttpxk], [Mahh], [Soluongxuat], [Giaxuat], [Thanhtien]) VALUES (N'PXK005', N'MH002', 3, 550000, 1650000)
INSERT [dbo].[ChiTietPhieuXuat] ([Sttpxk], [Mahh], [Soluongxuat], [Giaxuat], [Thanhtien]) VALUES (N'PXK005', N'MH004', 2, 3850000, 7700000)
INSERT [dbo].[DVT] ([id], [Tendvt]) VALUES (1, N'Bộ')
INSERT [dbo].[DVT] ([id], [Tendvt]) VALUES (2, N'Cái')
INSERT [dbo].[DVT] ([id], [Tendvt]) VALUES (3, N'Block')
INSERT [dbo].[DVT] ([id], [Tendvt]) VALUES (4, N'Hộp')
INSERT [dbo].[DVT] ([id], [Tendvt]) VALUES (5, N'Thùng')
INSERT [dbo].[DVT] ([id], [Tendvt]) VALUES (6, N'Chai')
INSERT [dbo].[DVT] ([id], [Tendvt]) VALUES (7, N'Gói')
INSERT [dbo].[HangHoa] ([Mahh], [Tenhh], [idDVT], [Mancc], [Soluonghh], [Giaxuat]) VALUES (N'MH001', N'Mainboard', 2, 2, 5, 2750000)
INSERT [dbo].[HangHoa] ([Mahh], [Tenhh], [idDVT], [Mancc], [Soluonghh], [Giaxuat]) VALUES (N'MH002', N'Chuột', 2, 1, 10, 550000)
INSERT [dbo].[HangHoa] ([Mahh], [Tenhh], [idDVT], [Mancc], [Soluonghh], [Giaxuat]) VALUES (N'MH003', N'Bàn phím', 2, 3, 12, 165000)
INSERT [dbo].[HangHoa] ([Mahh], [Tenhh], [idDVT], [Mancc], [Soluonghh], [Giaxuat]) VALUES (N'MH004', N'Màn hình', 2, 4, 3, 3850000.0000000005)
INSERT [dbo].[HangHoa] ([Mahh], [Tenhh], [idDVT], [Mancc], [Soluonghh], [Giaxuat]) VALUES (N'MH005', N'Nguồn', 1, 2, 13, 1320000)
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Diachikh], [Sdtkh], [Emailkh]) VALUES (N'KH001', N'DỊCH VỤ KẾ TOÁN ANH-TIÊN', N'Nhật Tảo, Cái Răng', N'0962676767', N'codebreakerct@gmail.com')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Diachikh], [Sdtkh], [Emailkh]) VALUES (N'KH002', N'CÔNG TY TIN HỌC ABC', N'Cần Thơ', N'0900000000', N'abc@abc.com')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Diachikh], [Sdtkh], [Emailkh]) VALUES (N'KH003', N'CÔNG TY TNHH DEF', N'Cần Thơ', N'0909000999', N'def@def.com')
INSERT [dbo].[NhaCungCap] ([Mancc], [Tenncc], [Diachincc], [Sdtncc], [Emailncc]) VALUES (1, N'CÔNG TY ABCDEF', N'Ninh Kiều, Cần Thơ', N'02923123123', N'abcfood@abcfood.com')
INSERT [dbo].[NhaCungCap] ([Mancc], [Tenncc], [Diachincc], [Sdtncc], [Emailncc]) VALUES (2, N'CÔNG TY TIN HỌC DEF', N'Cái Răng, Cần Thơ', N'02923568789', N'def@def.com')
INSERT [dbo].[NhaCungCap] ([Mancc], [Tenncc], [Diachincc], [Sdtncc], [Emailncc]) VALUES (3, N'CÔNG TY AUS', N'Ninh Kiều, Cần Thơ', N'02923789548', N'aus@aus.net')
INSERT [dbo].[NhaCungCap] ([Mancc], [Tenncc], [Diachincc], [Sdtncc], [Emailncc]) VALUES (4, N'CÔNG TY GIGA', N'Ninh Kiều, Cần Thơ', N'02923257659', N'giga@giga.org')
INSERT [dbo].[PhieuNhapKho] ([Sttpnk], [Datepnk], [Tongtien]) VALUES (N'PNK001', CAST(N'2020-10-08 00:00:00.000' AS DateTime), 25000000)
INSERT [dbo].[PhieuNhapKho] ([Sttpnk], [Datepnk], [Tongtien]) VALUES (N'PNK002', CAST(N'2020-10-10 00:00:00.000' AS DateTime), 4000000)
INSERT [dbo].[PhieuNhapKho] ([Sttpnk], [Datepnk], [Tongtien]) VALUES (N'PNK003', CAST(N'2020-11-11 00:00:00.000' AS DateTime), 70500000)
INSERT [dbo].[PhieuNhapKho] ([Sttpnk], [Datepnk], [Tongtien]) VALUES (N'PNK004', CAST(N'2021-01-03 00:00:00.000' AS DateTime), 16100000)
INSERT [dbo].[PhieuXuatKho] ([Sttpxk], [Datepxk], [Makh], [Tongtienpxk]) VALUES (N'PXK001', CAST(N'2020-10-16 00:00:00.000' AS DateTime), N'KH001', 23540000)
INSERT [dbo].[PhieuXuatKho] ([Sttpxk], [Datepxk], [Makh], [Tongtienpxk]) VALUES (N'PXK002', CAST(N'2021-01-03 00:00:00.000' AS DateTime), N'KH002', 13530000)
INSERT [dbo].[PhieuXuatKho] ([Sttpxk], [Datepxk], [Makh], [Tongtienpxk]) VALUES (N'PXK003', CAST(N'2020-10-02 00:00:00.000' AS DateTime), N'KH003', 18920000)
INSERT [dbo].[PhieuXuatKho] ([Sttpxk], [Datepxk], [Makh], [Tongtienpxk]) VALUES (N'PXK004', CAST(N'2021-01-03 00:00:00.000' AS DateTime), N'KH002', 11880000)
INSERT [dbo].[PhieuXuatKho] ([Sttpxk], [Datepxk], [Makh], [Tongtienpxk]) VALUES (N'PXK005', CAST(N'2020-11-19 00:00:00.000' AS DateTime), N'KH001', 9350000)
INSERT [dbo].[users] ([taikhoan], [matkhau]) VALUES (N'admin', N'admin')
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD FOREIGN KEY([Sttpnk])
REFERENCES [dbo].[PhieuNhapKho] ([Sttpnk])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD FOREIGN KEY([Mahh])
REFERENCES [dbo].[HangHoa] ([Mahh])
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat]  WITH CHECK ADD FOREIGN KEY([Sttpxk])
REFERENCES [dbo].[PhieuXuatKho] ([Sttpxk])
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat]  WITH CHECK ADD FOREIGN KEY([Mahh])
REFERENCES [dbo].[HangHoa] ([Mahh])
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD FOREIGN KEY([idDVT])
REFERENCES [dbo].[DVT] ([id])
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD FOREIGN KEY([Mancc])
REFERENCES [dbo].[NhaCungCap] ([Mancc])
GO
ALTER TABLE [dbo].[PhieuXuatKho]  WITH CHECK ADD FOREIGN KEY([Makh])
REFERENCES [dbo].[KhachHang] ([Makh])
GO
/****** Object:  StoredProcedure [dbo].[getAllSLuongNhap]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getAllSLuongNhap](@tungay datetime,@denngay datetime)
AS
	SELECT A.Mahh, B.Tenhh, SUM(Soluongnhap) AS Nhap
	FROM ChiTietPhieuNhap AS A, HangHoa AS B, PhieuNhapKho AS C
	WHERE A.Mahh = B.Mahh AND A.Sttpnk = C.Sttpnk AND (Datepnk BETWEEN @tungay AND @denngay)
	GROUP BY A.Mahh, B.Tenhh
GO
/****** Object:  StoredProcedure [dbo].[getAllSLuongXuat]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getAllSLuongXuat](@tungay datetime,@denngay datetime)
AS
	SELECT A.Mahh, B.Tenhh, SUM(Soluongxuat) AS Xuat
	FROM ChiTietPhieuXuat AS A, HangHoa AS B, PhieuXuatKho AS C
	WHERE A.Mahh = B.Mahh AND A.Sttpxk = C.Sttpxk AND (Datepxk BETWEEN @tungay AND @denngay)
	GROUP BY A.Mahh, B.Tenhh
GO
/****** Object:  StoredProcedure [dbo].[sp_getMaHangHoa]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getMaHangHoa](@mahang nvarchar(100))
AS
	SELECT Mahh, Tenhh, idDVT, B.Tendvt, A.Mancc, C.Tenncc, Soluonghh FROM HangHoa AS A, DVT AS B, NhaCungCap AS C WHERE A.idDVT = B.id AND A.Mancc = C.Mancc AND Mahh like '%'+@mahang+'%'
GO
/****** Object:  StoredProcedure [dbo].[sp_getNXT]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getNXT]
AS
BEGIN
		begin
		SELECT a.Mahh, SUM(Soluongnhap) AS TongNhap into vnhap
		FROM ChiTietPhieuNhap AS a
		GROUP BY a.Mahh
		end

		begin	
		SELECT a.Mahh, SUM(Soluongxuat) AS TongXuat into vxuat
		FROM ChiTietPhieuXuat AS a
		GROUP BY a.Mahh
		end

		begin
		SELECT a.Mahh AS [Mã hàng], c.Tenhh AS [Tên hàng]  ,a.TongNhap AS [Nhập], b.TongXuat AS [Xuất], c.Soluonghh AS [Tồn] into vton
		FROM vnhap as a, vxuat as b, HangHoa as c
		WHERE a.Mahh = c.Mahh and a.Mahh = b.Mahh
		end
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_getPNKbyDate]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getPNKbyDate](@tungay datetime,
								   @denngay datetime)
AS
	SELECT * FROM PhieuNhapKho WHERE Datepnk BETWEEN @tungay AND @denngay
GO
/****** Object:  StoredProcedure [dbo].[sp_getPXKbyDate]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getPXKbyDate](@tungay datetime,
								   @denngay datetime)
AS
	SELECT * FROM PhieuXuatKho WHERE Datepxk BETWEEN @tungay AND @denngay
GO
/****** Object:  StoredProcedure [dbo].[sp_getTenDVT]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getTenDVT]
@tendvtinh nvarchar(20)
AS
SELECT id, Tendvt from DVT where Tendvt like '%'+@tendvtinh+'%'
GO
/****** Object:  StoredProcedure [dbo].[sp_getTenHangHoa]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getTenHangHoa](@tenhang nvarchar(100))
AS
	SELECT Mahh, Tenhh, idDVT, B.Tendvt, A.Mancc, C.Tenncc, Soluonghh FROM HangHoa AS A, DVT AS B, NhaCungCap AS C WHERE A.idDVT = B.id AND A.Mancc = C.Mancc AND Tenhh like '%'+@tenhang+'%'
GO
/****** Object:  StoredProcedure [dbo].[sp_getTenKH]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getTenKH](@Ten nvarchar(100))
AS
	SELECT Makh, Tenkh, Diachikh, Sdtkh, Emailkh FROM KhachHang WHERE Tenkh like '%'+@Ten+'%'
GO
/****** Object:  StoredProcedure [dbo].[sp_getTenNCC]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getTenNCC](@tenncc nvarchar(100))
AS
	SELECT * FROM NhaCungCap WHERE Tenncc like '%'+@tenncc+'%'
GO
/****** Object:  StoredProcedure [dbo].[sp_themdvt]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_themdvt](@id int,
							@tendvtinh nvarchar(20))
AS
	INSERT INTO DVT(id,tendvt) VALUES (@id, @tendvtinh)

GO
/****** Object:  StoredProcedure [dbo].[sp_themHangHoa]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_themHangHoa](@mahang nvarchar(128),
								@tenhang nvarchar(100),
								@madvt int,
								@macungcap int
								)
AS
	INSERT INTO HangHoa(Mahh, Tenhh, idDVT, Mancc) VALUES (@mahang, @tenhang, @madvt, @macungcap)
GO
/****** Object:  StoredProcedure [dbo].[sp_themKH]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_themKH](@makh nvarchar(20),
						   @Ten nvarchar(100),
						   @diaChi nvarchar(100),
						   @sdt nvarchar(100),
						   @Email nvarchar(100))
AS
	INSERT INTO KhachHang(Makh, Tenkh, Diachikh, Sdtkh, Emailkh) VALUES (@makh, @Ten, @diaChi, @sdt, @Email)
GO
/****** Object:  StoredProcedure [dbo].[sp_themNCC]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_themNCC](@macc int,
							@tenncc nvarchar(100),
							@diachi nvarchar(100), 
							@sdtncc nvarchar(20),
							@email nvarchar(100))
AS
	INSERT INTO NhaCungCap(Mancc,Tenncc,Diachincc,Sdtncc,Emailncc) VALUES (@macc,@tenncc,@diachi, @sdtncc,@email)
GO
/****** Object:  StoredProcedure [dbo].[sp_themPNK]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_themPNK](@mapnk nvarchar(50),
						   @ngaynhap datetime,
						   @Tong float)
AS
	INSERT INTO PhieuNhapKho(Sttpnk, Datepnk, Tongtien) VALUES (@mapnk, @ngaynhap, @Tong)
GO
/****** Object:  StoredProcedure [dbo].[sp_themPXK]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_themPXK](@mapxk nvarchar(50),
						   @ngayxuat datetime,
						   @makh nvarchar(20),
						   @Tong float)
AS
	INSERT INTO PhieuXuatKho(Sttpxk, Datepxk, Makh, Tongtienpxk) VALUES (@mapxk, @ngayxuat, @makh, @Tong)
GO
/****** Object:  StoredProcedure [dbo].[sp_updateDvt]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_updateDvt](@id int,
							@tendvtinh nvarchar(20))
AS
	UPDATE DVT SET Tendvt = @tendvtinh WHERE id = @id
GO
/****** Object:  StoredProcedure [dbo].[sp_updateHangHoa]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_updateHangHoa](@mahang nvarchar(128),
								@tenhang nvarchar(100),
								@madvt int,
								@macungcap int)
AS
	UPDATE HangHoa SET Tenhh=@tenhang,idDVT = @madvt,Mancc=@macungcap WHERE Mahh=@mahang
GO
/****** Object:  StoredProcedure [dbo].[sp_updateKH]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_updateKH](@makh nvarchar(20),
						   @Ten nvarchar(100),
						   @diaChi nvarchar(100),
						   @sdt nvarchar(100),
						   @Email nvarchar(100))
AS
	UPDATE KhachHang SET Tenkh = @Ten, Diachikh = @diaChi, Sdtkh = @sdt, Emailkh = @Email WHERE Makh = @makh
GO
/****** Object:  StoredProcedure [dbo].[sp_updateNCC]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_updateNCC](@macc int,
							@tenncc nvarchar(100),
							@diachi nvarchar(100), 
							@sdtncc nvarchar(20),
							@email nvarchar(100))
AS
	UPDATE NhaCungCap SET Tenncc=@tenncc, Diachincc=@diachi, Sdtncc=@sdtncc, Emailncc=@email WHERE Mancc=@macc
GO
/****** Object:  StoredProcedure [dbo].[sp_xoaPNK]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[sp_xoaPNK](@sttpn nvarchar(50))
  AS
	DELETE FROM ChiTietPhieuNhap WHERE Sttpnk = @sttpn
	DELETE FROM [PhieuNhapKho] WHERE Sttpnk = @sttpn
GO
/****** Object:  StoredProcedure [dbo].[sp_xoaPXK]    Script Date: 3/1/2021 1:52:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  CREATE PROCEDURE [dbo].[sp_xoaPXK](@sttpx nvarchar(50))
  AS
	DELETE FROM ChiTietPhieuXuat WHERE Sttpxk = @sttpx
	DELETE FROM ChiTietPhieuXuat WHERE Sttpxk = @sttpx
GO

USE [TraoDoiDo]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 3/20/2024 7:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[IdNguoiDung] [varchar](100) NULL,
	[HoTenNguoiDung] [varchar](100) NULL,
	[GioiTinhNguoiDung] [varchar](5) NULL,
	[NgaySinhNguoiDung] [varchar](50) NULL,
	[CMNDNguoiDung] [varchar](12) NULL,
	[SdtNguoiDung] [varchar](10) NULL,
	[DiaChiNguoiDung] [varchar](50) NULL,
	[AnhNguoiDung] [varchar](100) NULL,
	[EmailNguoiDung] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 3/20/2024 7:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[IdNguoiDung] [varchar](100) NULL,
	[TenDangNhap] [varchar](100) NULL,
	[MatKhau] [varchar](100) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[KhachHang] ([IdNguoiDung], [HoTenNguoiDung], [GioiTinhNguoiDung], [NgaySinhNguoiDung], [CMNDNguoiDung], [SdtNguoiDung], [DiaChiNguoiDung], [AnhNguoiDung], [EmailNguoiDung]) VALUES (N'', N'', N'', N'3/20/2024 7:36:50 PM', N'', N'', N'', NULL, N'          ')
GO

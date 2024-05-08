USE [TraoDoiDo]
GO
/****** Object:  Table [dbo].[DanhGiaNguoiDang]    Script Date: 8/5/2024 8:33:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGiaNguoiDang](
	[IdNguoiDang] [int] NOT NULL,
	[IdNguoiMua] [int] NOT NULL,
	[SoSao] [int] NULL,
	[NhanXet] [nvarchar](500) NULL,
 CONSTRAINT [PK_DanhGiaNguoiDang] PRIMARY KEY CLUSTERED 
(
	[IdNguoiDang] ASC,
	[IdNguoiMua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMucYeuThich]    Script Date: 8/5/2024 8:33:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucYeuThich](
	[IdNguoiMua] [int] NOT NULL,
	[IdSanPham] [int] NOT NULL,
	[YeuThich
YeuThich] [nvarchar](50) NULL,
 CONSTRAINT [PK_DanhMucYeuThich] PRIMARY KEY CLUSTERED 
(
	[IdNguoiMua] ASC,
	[IdSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiaoDich]    Script Date: 8/5/2024 8:33:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoDich](
	[IdGiaoDich] [int] IDENTITY(1,1) NOT NULL,
	[IdNguoiDung] [int] NOT NULL,
	[LoaiGiaoDich] [nvarchar](20) NULL,
	[SoTien] [nvarchar](200) NULL,
	[TuNguonGiaoDich] [nvarchar](50) NULL,
	[DenNguonGiaoDich] [nvarchar](50) NULL,
	[NgayGiaoDich] [nvarchar](50) NULL,
 CONSTRAINT [PK_GiaoDich] PRIMARY KEY CLUSTERED 
(
	[IdGiaoDich] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 8/5/2024 8:33:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[IdNguoiMua] [int] NOT NULL,
	[IdSanPham] [int] NOT NULL,
	[SoLuongMua] [nvarchar](50) NULL,
 CONSTRAINT [PK_GioHang] PRIMARY KEY CLUSTERED 
(
	[IdNguoiMua] ASC,
	[IdSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoTaAnhSanPham]    Script Date: 8/5/2024 8:33:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoTaAnhSanPham](
	[IdSanPham] [int] NOT NULL,
	[IdAnhMinhHoa] [int] NOT NULL,
	[LinkAnhMinhHoa] [nvarchar](50) NULL,
	[MoTa] [nvarchar](1000) NULL,
 CONSTRAINT [PK_MoTaAnhSanPham] PRIMARY KEY CLUSTERED 
(
	[IdSanPham] ASC,
	[IdAnhMinhHoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 8/5/2024 8:33:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[IdNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[HoTenNguoiDung] [nvarchar](100) NOT NULL,
	[GioiTinhNguoiDung] [nvarchar](5) NULL,
	[NgaySinhNguoiDung] [nvarchar](50) NULL,
	[CMNDNguoiDung] [nvarchar](12) NULL,
	[EmailNguoiDung] [nvarchar](50) NULL,
	[SdtNguoiDung] [nvarchar](11) NOT NULL,
	[DiaChiNguoiDung] [nvarchar](100) NULL,
	[AnhNguoiDung] [nvarchar](200) NULL,
	[TienNguoiDung] [nvarchar](200) NULL,
	[TuKhoaSanPhamDangQuanTam] [nvarchar](50) NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[IdNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDungVoucher]    Script Date: 8/5/2024 8:33:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDungVoucher](
	[IdNguoiDung] [int] NOT NULL,
	[IdVoucher] [int] NOT NULL,
	[Dung] [nvarchar](50) NULL,
 CONSTRAINT [PK_NguoiDungVoucher] PRIMARY KEY CLUSTERED 
(
	[IdNguoiDung] ASC,
	[IdVoucher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyDonHang]    Script Date: 8/5/2024 8:33:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyDonHang](
	[IdDonHang] [int] IDENTITY(1,1) NOT NULL,
	[IdNguoiDang] [int] NULL,
	[IdNguoiMua] [int] NULL,
	[IdSanPham] [int] NULL,
	[TrangThai] [nvarchar](50) NULL,
	[LyDoTraHang] [nvarchar](100) NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[IdDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 8/5/2024 8:33:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[IdSanPham] [int] NOT NULL,
	[IdNguoiDang] [int] NULL,
	[Ten] [nvarchar](50) NULL,
	[LinkAnhBia] [nvarchar](50) NULL,
	[Loai] [nvarchar](50) NULL,
	[SoLuong] [nvarchar](50) NULL,
	[SoLuongDaBan] [nvarchar](50) NULL,
	[GiaGoc] [nvarchar](50) NULL,
	[GiaBan] [nvarchar](50) NULL,
	[PhiShip] [nvarchar](50) NULL,
	[TrangThai] [nvarchar](50) NULL,
	[NoiBan] [nvarchar](50) NULL,
	[XuatXu] [nvarchar](50) NULL,
	[NgayMua] [nvarchar](50) NULL,
	[PhanTramMoi] [nvarchar](50) NULL,
	[MoTaChung] [nvarchar](1500) NULL,
	[SoLuotXem] [nvarchar](50) NULL,
	[NgayDang] [nvarchar](50) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[IdSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 8/5/2024 8:33:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[IdNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[IdNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrangThaiDonHang]    Script Date: 8/5/2024 8:33:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThaiDonHang](
	[IdNguoiMua] [int] NOT NULL,
	[IdSanPham] [int] NOT NULL,
	[SoLuongMua] [nvarchar](50) NULL,
	[TongThanhToan] [nvarchar](50) NULL,
	[Ngay] [nvarchar](50) NULL,
	[TrangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK_TrangThaiDonHang] PRIMARY KEY CLUSTERED 
(
	[IdNguoiMua] ASC,
	[IdSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 8/5/2024 8:33:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher](
	[IdVoucher] [int] IDENTITY(1,1) NOT NULL,
	[TenVoucher] [nvarchar](500) NULL,
	[GiaTri] [nvarchar](200) NULL,
	[SoLuotSuDungToiDa] [nvarchar](50) NULL,
	[SoLuotDaSuDung] [nvarchar](50) NULL,
	[NgayBatDau] [nvarchar](50) NULL,
	[NgayKetThuc] [nvarchar](50) NULL,
 CONSTRAINT [PK_Voucher] PRIMARY KEY CLUSTERED 
(
	[IdVoucher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DanhGiaNguoiDang] ([IdNguoiDang], [IdNguoiMua], [SoSao], [NhanXet]) VALUES (1, 2, 5, N'Người bán có giao hàng chất lượng')
INSERT [dbo].[DanhGiaNguoiDang] ([IdNguoiDang], [IdNguoiMua], [SoSao], [NhanXet]) VALUES (1, 3, 3, N'Người bán rất đẹp trai')
INSERT [dbo].[DanhGiaNguoiDang] ([IdNguoiDang], [IdNguoiMua], [SoSao], [NhanXet]) VALUES (1, 4, 4, N'Shipper thân thiện')
INSERT [dbo].[DanhGiaNguoiDang] ([IdNguoiDang], [IdNguoiMua], [SoSao], [NhanXet]) VALUES (1, 5, 2, N'')
INSERT [dbo].[DanhGiaNguoiDang] ([IdNguoiDang], [IdNguoiMua], [SoSao], [NhanXet]) VALUES (2, 1, 5, N'Tốt')
INSERT [dbo].[DanhGiaNguoiDang] ([IdNguoiDang], [IdNguoiMua], [SoSao], [NhanXet]) VALUES (2, 2, 2, N'xin chào')
INSERT [dbo].[DanhGiaNguoiDang] ([IdNguoiDang], [IdNguoiMua], [SoSao], [NhanXet]) VALUES (2, 3, 4, N'Rất tốt')
INSERT [dbo].[DanhGiaNguoiDang] ([IdNguoiDang], [IdNguoiMua], [SoSao], [NhanXet]) VALUES (3, 1, 5, N'hahha hihi')
INSERT [dbo].[DanhGiaNguoiDang] ([IdNguoiDang], [IdNguoiMua], [SoSao], [NhanXet]) VALUES (3, 2, 5, N'Rất đẹp')
INSERT [dbo].[DanhGiaNguoiDang] ([IdNguoiDang], [IdNguoiMua], [SoSao], [NhanXet]) VALUES (3, 4, 3, N'Giao hàng hơi bất cẩn')
GO
INSERT [dbo].[DanhMucYeuThich] ([IdNguoiMua], [IdSanPham], [YeuThich
YeuThich]) VALUES (1, 2, NULL)
INSERT [dbo].[DanhMucYeuThich] ([IdNguoiMua], [IdSanPham], [YeuThich
YeuThich]) VALUES (1, 3, NULL)
INSERT [dbo].[DanhMucYeuThich] ([IdNguoiMua], [IdSanPham], [YeuThich
YeuThich]) VALUES (1, 6, NULL)
INSERT [dbo].[DanhMucYeuThich] ([IdNguoiMua], [IdSanPham], [YeuThich
YeuThich]) VALUES (1, 7, NULL)
INSERT [dbo].[DanhMucYeuThich] ([IdNguoiMua], [IdSanPham], [YeuThich
YeuThich]) VALUES (1, 8, NULL)
INSERT [dbo].[DanhMucYeuThich] ([IdNguoiMua], [IdSanPham], [YeuThich
YeuThich]) VALUES (2, 1, NULL)
INSERT [dbo].[DanhMucYeuThich] ([IdNguoiMua], [IdSanPham], [YeuThich
YeuThich]) VALUES (2, 2, NULL)
INSERT [dbo].[DanhMucYeuThich] ([IdNguoiMua], [IdSanPham], [YeuThich
YeuThich]) VALUES (2, 3, NULL)
INSERT [dbo].[DanhMucYeuThich] ([IdNguoiMua], [IdSanPham], [YeuThich
YeuThich]) VALUES (2, 5, NULL)
INSERT [dbo].[DanhMucYeuThich] ([IdNguoiMua], [IdSanPham], [YeuThich
YeuThich]) VALUES (2, 7, NULL)
INSERT [dbo].[DanhMucYeuThich] ([IdNguoiMua], [IdSanPham], [YeuThich
YeuThich]) VALUES (2, 8, NULL)
GO
SET IDENTITY_INSERT [dbo].[GiaoDich] ON 

INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1, 1, N'Nạp tiền', N'3000000', N'Ví điện tử', N'Sacombank', N'3/28/2024 7:39:58 AM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (2, 2, N'Nạp tiền', N'2000000', N'Ví điện tử', N'Vietcombank', N'3/27/2024 7:39:58 AM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (3, 1, N'Nạp tiền', N'5000000', N'Ví điện tử', N'BIDV', N'3/28/2024 8:45:43 AM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (4, 1, N'Nạp tiền', N'2000000', N'Ví điện tử', N'BIDV', N'3/28/2024 8:49:15 AM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (5, 1, N'Nạp tiền', N'3000000', N'Ví điện tử', N'VPBank', N'3/28/2024 9:19:52 AM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (6, 1, N'Nạp tiền', N'200000', N'Ví điện tử', N'Sacombank', N'3/28/2024 9:35:24 AM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (7, 1, N'Nạp tiền', N'2000000', N'Ví điện tử', N'Sacombank', N'3/28/2024 11:23:27 AM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (8, 1, N'Rút tiền', N'100000', N'Ví điện tử', N'Vietcombank', N'3/28/2024 11:23:56 AM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (9, 1, N'Nạp tiền', N'100000', N'Ví điện tử', N'BIDV', N'28/3/2024 10:25:50 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (10, 1, N'Nạp tiền', N'200000', N'Ví điện tử', N'Sacombank', N'28/3/2024 10:45:57 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (11, 1, N'Rút tiền', N'200000', N'Sacombank', N'Ví điện tử', N'28/3/2024 10:46:13 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (12, 1, N'Nạp tiền', N'500000', N'Ví điện tử', N'Sacombank', N'28/3/2024 11:13:48 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (13, 1, N'Nạp tiền', N'100000', N'Ví điện tử', N'TPBank', N'10/4/2024 9:06:18 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (14, 1, N'Nạp tiền', N'100000', N'Ví điện tử', N'TPBank', N'10/4/2024 9:07:00 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (15, 1, N'Nạp tiền', N'100000000', N'Ví điện tử', N'Sacombank', N'4/11/2024 8:39:18 AM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (16, 1, N'Nạp tiền', N'5000000', N'Ví điện tử', N'BIDV', N'13/4/2024 11:28:59 AM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (17, 1, N'Nạp tiền', N'100000', N'Sacombank', N'Ví điện tử', N'24/4/2024 6:37:07 AM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1018, 1, N'Rút tiền', N'100000', N'Ví điện tử', N'ACB', N'24/4/2024 6:55:07 AM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1019, 1, N'Nạp tiền', N'100000', N'Vietcombank', N'Ví điện tử', N'24/4/2024 6:56:16 AM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1020, 1, N'Nạp tiền', N'100000', N'Sacombank', N'Ví điện tử', N'1/5/2024 2:53:39 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1021, 1, N'Nạp tiền', N'100000', N'Vietcombank', N'Ví điện tử', N'1/5/2024 2:58:31 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1022, 1, N'Rút tiền', N'100000', N'Ví điện tử', N'Vietcombank', N'1/5/2024 3:01:36 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1023, 1, N'Nạp tiền', N'100000', N'Vietcombank', N'Ví điện tử', N'1/5/2024 3:02:36 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1025, 1, N'Nạp tiền', N'1000000', N'ACB', N'Ví điện tử', N'5/5/2024 10:44:26 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1026, 1, N'Rút tiền', N'0', N'Ví điện tử', N'VPBank', N'5/5/2024 10:47:08 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1027, 1, N'Rút tiền', N'1000000', N'Ví điện tử', N'VIB Bank', N'5/5/2024 10:47:57 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1028, 5, N'Nạp tiền', N'5000000', N'VietA', N'Ví điện tử', N'7/5/2024 9:20:26 AM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1029, 5, N'Nạp tiền', N'5000000', N'BAOVIET Bank', N'Ví điện tử', N'7/5/2024 9:20:32 AM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1030, 1, N'Nạp tiền', N'100000', N'Vietcombank', N'Ví điện tử', N'7/5/2024 9:20:48 AM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1031, 1, N'Nạp tiền', N'1000000', N'Sacombank', N'Ví điện tử', N'7/5/2024 9:05:33 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1032, 1, N'Nạp tiền', N'1000000', N'ACB', N'Ví điện tử', N'7/5/2024 9:05:40 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1033, 1, N'Rút tiền', N'100000', N'Ví điện tử', N'', N'7/5/2024 9:05:47 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1034, 1, N'Rút tiền', N'100000', N'Ví điện tử', N'Techcombank', N'7/5/2024 9:05:49 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1035, 1, N'Nạp tiền', N'1000000', N'Sacombank', N'Ví điện tử', N'7/5/2024 9:06:22 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1036, 1, N'Nạp tiền', N'200000', N'Techcombank', N'Ví điện tử', N'7/5/2024 9:07:13 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1037, 1, N'Nạp tiền', N'100000', N'', N'Ví điện tử', N'7/5/2024 9:10:22 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1038, 1, N'Nạp tiền', N'1000000', N'Vietcombank', N'Ví điện tử', N'7/5/2024 9:40:13 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1039, 1, N'Nạp tiền', N'200000', N'', N'Ví điện tử', N'7/5/2024 9:43:04 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1040, 1, N'Nạp tiền', N'0', N'Sacombank', N'Ví điện tử', N'7/5/2024 9:43:21 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1041, 1, N'Rút tiền', N'200000', N'Ví điện tử', N'BAOVIET Bank', N'7/5/2024 9:59:06 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1042, 1, N'Rút tiền', N'100000', N'Ví điện tử', N'Sacombank', N'7/5/2024 9:59:12 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1043, 1, N'Rút tiền', N'100', N'Ví điện tử', N'Sacombank', N'7/5/2024 9:59:46 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1044, 1, N'Nạp tiền', N'200000', N'Sacombank', N'Ví điện tử', N'7/5/2024 10:30:30 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1045, 1, N'Nạp tiền', N'200000', N'Vietcombank', N'Ví điện tử', N'7/5/2024 10:30:38 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1046, 1, N'Nạp tiền', N'100000', N'Sacombank', N'Ví điện tử', N'7/5/2024 10:31:30 PM')
INSERT [dbo].[GiaoDich] ([IdGiaoDich], [IdNguoiDung], [LoaiGiaoDich], [SoTien], [TuNguonGiaoDich], [DenNguonGiaoDich], [NgayGiaoDich]) VALUES (1047, 1, N'Rút tiền', N'300000', N'Ví điện tử', N'BAOVIET Bank', N'7/5/2024 10:32:15 PM')
SET IDENTITY_INSERT [dbo].[GiaoDich] OFF
GO
INSERT [dbo].[GioHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua]) VALUES (2, 2, N'2')
INSERT [dbo].[GioHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua]) VALUES (2, 3, N'4')
INSERT [dbo].[GioHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua]) VALUES (2, 4, N'1')
INSERT [dbo].[GioHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua]) VALUES (2, 7, N'1')
INSERT [dbo].[GioHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua]) VALUES (2, 8, N'1')
GO
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (1, 1, N'IPadGen6_1.jpg', N'Hỏng góc trên bên trái. Phần còn lại của iPad vẫn hoạt động bình thường. ')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (1, 2, N'IPadGen6_2.jpg', N'Trầy màn hình mức độ nhẹ, vẫn nhìn tốt. Màn hình vẫn rõ nét, không có điểm chết hoặc vết xước lớn.')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (1, 3, N'IPadGen6_3.jpg', N'Gọn nhẹ, dễ mang theo. Chiếc iPad này là sự lựa chọn hoàn hảo cho các chuyến đi, từ cuộc họp gặp gỡ công việc đến những chuyến du lịch khám phá thế giới. Với kích thước nhỏ gọn và trọng lượng nhẹ, chiếc iPad này không chỉ dễ dàng để mang theo trong túi xách hay ba lô mà còn không gây trở ngại cho bạn khi di chuyển. Bạn có thể dễ dàng sử dụng nó trên máy bay, tàu hỏa, hoặc thậm chí trong các không gian hẹp. Dù bạn đang trên đường đi hay đang tận hưởng một buổi họp công việc ở một quán cà phê, iPad này sẽ giúp bạn duy trì sự linh hoạt và hiệu suất cao. Hãy mang theo nó và khám phá thế giới một cách dễ dàng và thuận tiện!')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (2, 1, N'tiviSony27inch_1.jpg', N'Màn hình còn mới')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (2, 2, N'tiviSony27inch_2.jpg', N'Mặt sau nguyên vẹn')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (2, 3, N'tiviSony27inch_3.jpg', N'Tổng thể còn xài được ')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (3, 1, N'Iphone11_2.jpg', N'Hỏng góc trên bên trái. Phần còn lại của iPad vẫn hoạt động bình thường.')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (3, 2, N'Iphone11_1.jpg', N'Trầy màn hình mức độ nhẹ, vẫn nhìn tốt. Màn hình vẫn rõ nét, không có điểm chết hoặc vết xước lớn..')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (3, 3, N'Iphone11_3.jpg', N'Gọn nhẹ, dễ mang theo. Chiếc iPad này là sự lựa chọn hoàn hảo cho các chuyến đi, từ cuộc họp gặp gỡ công việc đến những chuyến du lịch khám phá thế giới. Với kích thước nhỏ gọn và trọng lượng nhẹ, chiếc iPad này không chỉ dễ dàng để mang theo trong túi xách hay ba lô mà còn không gây trở ngại cho bạn khi di chuyển. Bạn có thể dễ dàng sử dụng nó trên máy bay, tàu hỏa, hoặc thậm chí trong các không gian hẹp. Dù bạn đang trên đường đi hay đang tận hưởng một buổi họp công việc ở một quán cà phê, iPad này sẽ giúp bạn duy trì sự linh hoạt và hiệu suất cao. Hãy mang theo nó và khám phá thế giới một cách dễ dàng và thuận tiện!')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (4, 1, N'Screenshot 2024-03-26 202613.png', N'Hỏng góc trên bên trái. Phần còn lại của iPad vẫn hoạt động bình thường.')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (4, 2, N'Screenshot 2024-03-26 202653.png', N'Trầy màn hình mức độ nhẹ, vẫn nhìn tốt. Màn hình vẫn rõ nét, không có điểm chết hoặc vết xước lớn..')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (4, 3, N'Screenshot 2024-03-26 202624.png', N'Gọn nhẹ, dễ mang theo. Chiếc iPad này là sự lựa chọn hoàn hảo cho các chuyến đi, từ cuộc họp gặp gỡ công việc đến những chuyến du lịch khám phá thế giới. Với kích thước nhỏ gọn và trọng lượng nhẹ, chiếc iPad này không chỉ dễ dàng để mang theo trong túi xách hay ba lô mà còn không gây trở ngại cho bạn khi di chuyển. Bạn có thể dễ dàng sử dụng nó trên máy bay, tàu hỏa, hoặc thậm chí trong các không gian hẹp. Dù bạn đang trên đường đi hay đang tận hưởng một buổi họp công việc ở một quán cà phê, iPad này sẽ giúp bạn duy trì sự linh hoạt và hiệu suất cao. Hãy mang theo nó và khám phá thế giới một cách dễ dàng và thuận tiện!')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (5, 1, N'Screenshot 2024-03-26 212138.png', N'Hỏng góc trên bên trái. Phần còn lại của iPad vẫn hoạt động bình thường.')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (5, 2, N'Screenshot 2024-03-26 212412.png', N'Trầy màn hình mức độ nhẹ, vẫn nhìn tốt. Màn hình vẫn rõ nét, không có điểm chết hoặc vết xước lớn..')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (6, 1, N'Screenshot 2024-03-26 212056.png', N'Hỏng góc trên bên trái. Phần còn lại của iPad vẫn hoạt động bình thường.')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (7, 1, N'Screenshot 2024-03-26 212630.png', N'Gọn nhẹ, dễ mang theo. Chiếc iPad này là sự lựa chọn hoàn hảo cho các chuyến đi, từ cuộc họp gặp gỡ công việc đến những chuyến du lịch khám phá thế giới. Với kích thước nhỏ gọn và trọng lượng nhẹ, chiếc iPad này không chỉ dễ dàng để mang theo trong túi xách hay ba lô mà còn không gây trở ngại cho bạn khi di chuyển. Bạn có thể dễ dàng sử dụng nó trên máy bay, tàu hỏa, hoặc thậm chí trong các không gian hẹp. Dù bạn đang trên đường đi hay đang tận hưởng một buổi họp công việc ở một quán cà phê, iPad này sẽ giúp bạn duy trì sự linh hoạt và hiệu suất cao. Hãy mang theo nó và khám phá thế giới một cách dễ dàng và thuận tiện!')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (7, 2, N'Screenshot 2024-03-26 212646.png', N'Mặt sau nguyên vẹn')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (7, 3, N'Screenshot 2024-03-26 212708.png', N'Trầy màn hình mức độ nhẹ, vẫn nhìn tốt. Màn hình vẫn rõ nét, không có điểm chết hoặc vết xước lớn..')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (8, 1, N'Screenshot 2024-03-26 212934.png', N'')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (9, 1, N'IronMan.jpg', N'Mô hình Iron Man phiên bản mới nhất với chi tiết chính xác và sắc nét')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (10, 1, N'AoThunNamAdidas.jpg', N'Áo hơi phai màu')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (11, 1, N'Sapien.jpg', N'Sách vẫn còn mới, nép gấp ở góc hơi nhăn')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (12, 1, N'BoNoiChao.jpg', N'Hơi xước và bay màu')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (13, 1, N'TuGiayDep.jpg', N'Gỗ còn mới, đẹp')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (14, 1, N'TaiNgheBluetooth.jpg', N'Dây còn chơi, đã vệ sinh sạch sẽ')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (15, 1, N'ButBiCaoCap.jpg', N'Mực đẹp, nhựa sáng bóng')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (16, 1, N'DoChoiLego.jpg', N'Sản phẩm còn mới, đẹp')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (17, 1, N'AoSoMiNu.jpg', N'Vải đẹp, mịn')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (18, 1, N'SachDauChanTrenCat.jpg', N'Chữ còn rõ, ít nép nhăn ở góc')
GO
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([IdNguoiDung], [HoTenNguoiDung], [GioiTinhNguoiDung], [NgaySinhNguoiDung], [CMNDNguoiDung], [EmailNguoiDung], [SdtNguoiDung], [DiaChiNguoiDung], [AnhNguoiDung], [TienNguoiDung], [TuKhoaSanPhamDangQuanTam]) VALUES (0, N'Admin', N'Nam', N'01/01/1999', N'123456789123', N'admin@gmail.com', N'0949124321', N'TP HCM', N'Avt1.png', N'10000000', NULL)
INSERT [dbo].[NguoiDung] ([IdNguoiDung], [HoTenNguoiDung], [GioiTinhNguoiDung], [NgaySinhNguoiDung], [CMNDNguoiDung], [EmailNguoiDung], [SdtNguoiDung], [DiaChiNguoiDung], [AnhNguoiDung], [TienNguoiDung], [TuKhoaSanPhamDangQuanTam]) VALUES (1, N'Nguyễn Hoàng Anh Khoa', N'Nam', N'2/1/2004', N'073172381313', N'ak2109@gmail.com', N'0949617948', N'Hà Nội', N'NguyenHoangAnhKhoa.jpg', N'24055900', N'di')
INSERT [dbo].[NguoiDung] ([IdNguoiDung], [HoTenNguoiDung], [GioiTinhNguoiDung], [NgaySinhNguoiDung], [CMNDNguoiDung], [EmailNguoiDung], [SdtNguoiDung], [DiaChiNguoiDung], [AnhNguoiDung], [TienNguoiDung], [TuKhoaSanPhamDangQuanTam]) VALUES (2, N'Nghiêm Vũ Hoàng Long', N'Nam', N'21/9/2004', N'073218931923', N'ak2109@gmail.com', N'0392193128', N'Hà Nội', N'Avt1.png', N'8250000', NULL)
INSERT [dbo].[NguoiDung] ([IdNguoiDung], [HoTenNguoiDung], [GioiTinhNguoiDung], [NgaySinhNguoiDung], [CMNDNguoiDung], [EmailNguoiDung], [SdtNguoiDung], [DiaChiNguoiDung], [AnhNguoiDung], [TienNguoiDung], [TuKhoaSanPhamDangQuanTam]) VALUES (3, N'Võ Văn Trí', N'Nam', N'4/4/2004', N'078423949294', N'vovantri44@gmail.com', N'0982382347', N'Ðồng Tháp', N'Avt2.jpg', N'3250000', NULL)
INSERT [dbo].[NguoiDung] ([IdNguoiDung], [HoTenNguoiDung], [GioiTinhNguoiDung], [NgaySinhNguoiDung], [CMNDNguoiDung], [EmailNguoiDung], [SdtNguoiDung], [DiaChiNguoiDung], [AnhNguoiDung], [TienNguoiDung], [TuKhoaSanPhamDangQuanTam]) VALUES (4, N'Nghiêm Ðại Ngân', N'Nam', N'1/2/2004', N'074932949234', N'daingan2612@gmail.com', N'0397410323', N'TP HCM', N'Avt3.jpg', N'32400000', NULL)
INSERT [dbo].[NguoiDung] ([IdNguoiDung], [HoTenNguoiDung], [GioiTinhNguoiDung], [NgaySinhNguoiDung], [CMNDNguoiDung], [EmailNguoiDung], [SdtNguoiDung], [DiaChiNguoiDung], [AnhNguoiDung], [TienNguoiDung], [TuKhoaSanPhamDangQuanTam]) VALUES (5, N'Phạm Hải Tú', N'Nữ', N'7/3/1995', N'079429349294', N'phamtu221@gmail.com', N'0982374273', N'TP HCM', N'Avt4.jpg', N'1000000', NULL)
INSERT [dbo].[NguoiDung] ([IdNguoiDung], [HoTenNguoiDung], [GioiTinhNguoiDung], [NgaySinhNguoiDung], [CMNDNguoiDung], [EmailNguoiDung], [SdtNguoiDung], [DiaChiNguoiDung], [AnhNguoiDung], [TienNguoiDung], [TuKhoaSanPhamDangQuanTam]) VALUES (6, N'Triiển Chiêu', N'Nữ', N'6/10/2003', N'078439428422', N'HongHaiLan2@gmail.com', N'0943284832', N'TP HCM', N'Avt5.jpg', N'4222000', NULL)
INSERT [dbo].[NguoiDung] ([IdNguoiDung], [HoTenNguoiDung], [GioiTinhNguoiDung], [NgaySinhNguoiDung], [CMNDNguoiDung], [EmailNguoiDung], [SdtNguoiDung], [DiaChiNguoiDung], [AnhNguoiDung], [TienNguoiDung], [TuKhoaSanPhamDangQuanTam]) VALUES (7, N'Đặng Tiến Hoàng', N'Nam', N'11/4/2024', N'123124243423', N'dth@gmail.com', N'0321930932', N'Tây Ninh', N'Avt6.png', N'2330000', NULL)
INSERT [dbo].[NguoiDung] ([IdNguoiDung], [HoTenNguoiDung], [GioiTinhNguoiDung], [NgaySinhNguoiDung], [CMNDNguoiDung], [EmailNguoiDung], [SdtNguoiDung], [DiaChiNguoiDung], [AnhNguoiDung], [TienNguoiDung], [TuKhoaSanPhamDangQuanTam]) VALUES (8, N'Lâm Đình Khoa', N'Nam', N'22/10/1997', N'392183818318', N'kld@gmail.com', N'0932131334', N'Đồng Tháp', N'Khoa.jpg', N'0', NULL)
INSERT [dbo].[NguoiDung] ([IdNguoiDung], [HoTenNguoiDung], [GioiTinhNguoiDung], [NgaySinhNguoiDung], [CMNDNguoiDung], [EmailNguoiDung], [SdtNguoiDung], [DiaChiNguoiDung], [AnhNguoiDung], [TienNguoiDung], [TuKhoaSanPhamDangQuanTam]) VALUES (9, N'Phan Tấn Trung', N'Nam', N'14/07/1989', N'384284923949', N'ttp@gmail.com', N'0392183183', N'Đồng Tháp', N'ThayGiaoBa.jpg', N'0', NULL)
INSERT [dbo].[NguoiDung] ([IdNguoiDung], [HoTenNguoiDung], [GioiTinhNguoiDung], [NgaySinhNguoiDung], [CMNDNguoiDung], [EmailNguoiDung], [SdtNguoiDung], [DiaChiNguoiDung], [AnhNguoiDung], [TienNguoiDung], [TuKhoaSanPhamDangQuanTam]) VALUES (10, N'Linh Ngọc Đàm', N'Nữ', N'16/06/1995', N'073848381884', N'lnd@gmail.com', N'0943294828', N'Hà Nội', N'LND.jpg', N'0', NULL)
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
GO
SET IDENTITY_INSERT [dbo].[QuanLyDonHang] ON 

INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (11, 1, 2, 1, N'Đang giao', NULL)
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (15, 1, 2, 3, N'Đã giao', NULL)
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (3013, 1, 1, 1, N'Đang giao', NULL)
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (3019, 1, 1, 4, N'Đang giao', NULL)
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (3020, 1, 1, 4, N'Đang giao', NULL)
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (4031, 4, 1, 13, N'Chờ đóng gói', N'')
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (4040, 1, 5, 1, N'Đã giao', N'')
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (4049, 2, 1, 5, N'Chờ đóng gói', N'')
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (4050, 4, 1, 12, N'Chờ đóng gói', N'')
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (5050, 3, 1, 10, N'Chờ đóng gói', N'')
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (5052, 2, 1, 2, N'Chờ đóng gói', N'')
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (5058, 3, 1, 9, N'Chờ đóng gói', N'')
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (5062, 5, 1, 17, N'Chờ đóng gói', N'')
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (5063, 3, 1, 11, N'Chờ đóng gói', N'')
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (5065, 2, 1, 3, N'Chờ đóng gói', N'')
SET IDENTITY_INSERT [dbo].[QuanLyDonHang] OFF
GO
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem], [NgayDang]) VALUES (1, 1, N'IPadGen64', N'IPadGen6_1.jpg', N'Đồ điện tử', N'9', N'3', N'12000000', N'9000000', N'20000', N'Đã duyệt', N'Hồ Chí Minh', N'Nhật Bản', N'03/12/2020', N'79', N'iPad 6th Wifi 32GB với nhiều nâng cấp về phần cứng, đặc biệt hơn giá của sản phẩm này được định hình ở phân khúc giá rẻ, sinh viên sẽ là sự lựa chọn “không quá xa tầm tay” người dùng.', N'61', N'1/1/2021')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem], [NgayDang]) VALUES (2, 2, N'TVs Sony KV27FS120 27" Screen CRT TV', N'tiviSony27inch_1.jpg', N'Đồ điện tử', N'2', N'2', N'10700000', N'9000000', N'50000', N'Đã duyệt', N'Hồ Chí Minh', N'Trung Quốc', N'2/2/2022', N'75', N'Mẫu tivi Samsung Micro LED 4K 110 inch MNA110MS1A có công nghệ Quantum Dot tái tạo 100% dải màu sắc chuẩn điện ảnh và Micro LED kích thước cực nhỏ có khả năng thể hiện 3 màu cơ bản (đỏ - lục - lam) để tạo hình ảnh, màu sắc trực tiếp trên màn hình cực lớn 110 inch với độ phân giải 4K.', N'144', N'3/12/2022')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem], [NgayDang]) VALUES (3, 2, N'IPhone 11', N'Iphone11_2.jpg', N'Đồ điện tử', N'3', N'4', N'23000000', N'17000000', N'27000', N'Đã duyệt', N'Đà Lạt', N'Hàn Quốc', N'2/2/2021', N'80', N'Smart Tivi Casper 32 inch 32HG5200 được thiết kế với vóc dáng vô cùng đơn giản, viền tivi mỏng 0,8 mm kết hợp với chân đế hình chữ V úp ngược mang lại tổng thể chiếc tivi trở nên sang trọng. Tivi Casper 32 inch phù hợp trưng bày ở những nơi có không gian nhỏ như: Phòng ngủ, phòng khách nhỏ,...', N'98', N'8/2/2024')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem], [NgayDang]) VALUES (4, 1, N'Mô hình one piece', N'Screenshot 2024-03-26 202613.png', N'Đồ chơi', N'2', N'1', N'420000', N'1000000', N'50000', N'Đã duyệt', N'Tây Ninh', N'Trung Quốc', N'14/07/2022', N'90', N'MÔ HÌNH Monkey D Luffy gear 4 King Fado Myoo CAO CẤP CỠ LỚN có led chiến đấu với Kaido trong anime One piece ', N'27', N'10/8/2024')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem], [NgayDang]) VALUES (5, 2, N'Đồ đi chơi ', N'Screenshot 2024-03-26 212138.png', N'Quần áo', N'15', N'3', N'2500000', N'1900000', N'30000', N'Đã duyệt', N'Hà Nội', N'Mỹ', N'1/12/2012', N'75', N'Áo Polo Nam Thể Thao Promax-S1 Coolmate chất liệu Poly thoáng khí, mát mẻ và nhanh khô. Sản phẩm được thiết kế kiểu dáng Regular fit dáng suông thích hợp sử dụng khi đi làm, đi chơi hoặc mặc ở nhà đều được mà nam giới nên có trong tủ đồ của mình. ', N'352', N'23/3/2024')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem], [NgayDang]) VALUES (6, 2, N'Quần áo nam', N'Screenshot 2024-03-26 212056.png', N'Quần áo', N'12', N'5', N'9999000', N'4999000', N'40000', N'Đã duyệt', N'Lào Cai', N'Việt Nam', N'1/12/2022', N'80', N'Áo Polo Nam Thể Thao Promax-S1 Coolmate chất liệu Poly thoáng khí, mát mẻ và nhanh khô. Sản phẩm được thiết kế kiểu dáng Regular fit dáng suông thích hợp sử dụng khi đi làm, đi chơi hoặc mặc ở nhà đều được mà nam giới nên có trong tủ đồ của mình. ', N'81', N'8/12/2023')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem], [NgayDang]) VALUES (7, 1, N'Harry Potter và hòn đá phù thủy', N'Screenshot 2024-03-26 212630.png', N'Sách', N'2', N'1', N'1200000', N'1100000', N'50000', N'Đã duyệt', N'Đà Nẵng', N'Lào', N'1/1/2024', N'83', N'Khi một lá thư được gởi đến cho cậu bé Harry Potter bình thường và bất hạnh, cậu khám phá ra một bí mật đã được che giấu suốt cả một thập kỉ. Cha mẹ cậu chính là phù thủy và cả hai đã bị lời nguyền của Chúa tể Hắc ám giết hại khi Harry mới chỉ là một đứa trẻ, và bằng cách nào đó, cậu đã giữ được mạng sống của mình. Thoát khỏi những người giám hộ Muggle không thể chịu đựng nổi để nhập học vào trường Hogwarts, một trường đào tạo phù thủy với những bóng ma và phép thuật, Harry tình cờ dấn thân vào một cuộc phiêu lưu đầy gai góc khi cậu phát hiện ra một con chó ba đầu đang canh giữ một căn phòng trên tầng ba. Rồi Harry nghe nói đến một viên đá bị mất tích sở hữu những sức mạnh lạ kì, rất quí giá, vô cùng nguy hiểm, mà cũng có thể là mang cả hai đặc điểm trên.', N'45', N'23/2/2023')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem], [NgayDang]) VALUES (8, 1, N'Máy xay đa năng', N'Screenshot 2024-03-26 212934.png', N'Đồ gia dụng', N'2', N'1', N'290000', N'180000', N'20000', N'Đã duyệt', N'Hồ Chí Minh', N'Nhật Bản', N'01/01/2023', N'86', N'Máy xay sinh tố Vitamix Drink Machine Advance là dòng máy xay chuyên nghiệp công suất lớn dành cho các quán cà phê. Nhờ có chiếc máy xay công nghiệp này mà từng cốc sinh tố đá bào sẽ được làm ra nhanh chóng chỉ trong tích tắc. Công suất lớn kèm 6 lập trình xay tự động và chức năng tự động bật - tắt sẽ giúp bạn chọn ra được chế độ xay chất lượng và phù hợp với yêu cầu để làm ra nhiều món sinh tố đa dạng khác nhau.', N'5', N'13/4/2024')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem], [NgayDang]) VALUES (9, 3, N'Mô hình Iron Man', N'IronMan.jpg', N'Đồ chơi', N'5', N'9', N'5000000', N'4000000', N'20000', N'Đã duyệt', N'Hà Nội', N'Mỹ', N'20/06/2021', N'25', N'Mô hình Iron Man phiên bản mới nhất với chi tiết chính xác và sắc nét, là món quà tuyệt vời cho fan của siêu anh hùng Marvel.', N'10', N'02/05/2024')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem], [NgayDang]) VALUES (10, 3, N'Áo thun nam Adidas', N'AoThunNamAdidas.jpg', N'Quần áo', N'8', N'8', N'300000', N'250000', N'10000', N'Đã duyệt', N'Hồ Chí Minh', N'Trung Quốc', N'12/08/2020', N'50', N'Áo thun nam Adidas với chất liệu cotton cao cấp, thoáng mát và thoải mái, phù hợp cho mọi hoạt động thể thao và hàng ngày.', N'32', N'02/05/2024')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem], [NgayDang]) VALUES (11, 3, N'Sách "Sapiens: Lược sử về loài người"', N'Sapien.jpg', N'Sách', N'7', N'5', N'200000', N'180000', N'20000', N'Đã duyệt', N'Đà Nẵng', N'Mỹ', N'03/04/2022', N'80', N'Sách "Sapiens: Từ người khổng lồ" là một cuốn sách bán chạy toàn cầu, khám phá lịch sử phát triển của loài người từ thời tiền sử đến hiện đại, mang lại cái nhìn sâu sắc về bản chất con người.', N'9', N'02/05/2024')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem], [NgayDang]) VALUES (12, 4, N'Bộ nồi chảo chống dính', N'BoNoiChao.jpg', N'Đồ gia dụng', N'10', N'6', N'600000', N'450000', N'15000', N'Đã duyệt', N'Cần Thơ', N'Việt Nam', N'08/11/2021', N'65', N'Bộ nồi chảo chống dính với công nghệ chống dính hiện đại, giúp bạn nấu ăn dễ dàng và nhanh chóng mà không lo bị dính chất béo.', N'4', N'02/05/2024')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem], [NgayDang]) VALUES (13, 4, N'Tủ giày dép gỗ', N'TuGiayDep.jpg', N'Đồ nội thất', N'4', N'2', N'1500000 ', N'1000000', N'10000', N'Đã duyệt', N'Hải Phòng', N'Việt Nam', N'19/09/2020', N'45', N'Tủ giày dép gỗ phong cách hiện đại, thiết kế thông minh giúp tiết kiệm không gian và tạo điểm nhấn cho không gian nội thất của bạn.', N'9', N'02/05/2024')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem], [NgayDang]) VALUES (14, 4, N'Tai nghe Bluetooth', N'TaiNgheBluetooth.jpg', N'Đồ điện tử', N'3', N'1', N'150000', N'65000', N'5000', N'Đã duyệt', N'Nghệ An', N'Hàn Quốc', N'25/07/2021', N'60', N'Tai nghe Bluetooth không dây với âm thanh chất lượng cao, kết nối ổn định và thiết kế nhỏ gọn, phù hợp cho mọi hoạt động di động.', N'6', N'02/05/2024')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem], [NgayDang]) VALUES (15, 5, N'Bút bi cao cấp', N'ButBiCaoCap.jpg', N'Đồ dùng văn phòng phẩm', N'6', N'4', N'20000', N'10000', N'5000', N'Đã duyệt', N'Hà Giang', N'Trung Quốc', N'10/02/2023', N'80', N'Bút bi cao cấp với mực chất lượng, viết mượt mà và không lem, là dụng cụ tuyệt vời cho công việc và học tập hàng ngày.', N'0', N'02/05/2024')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem], [NgayDang]) VALUES (16, 5, N'Đồ chơi Lego', N'DoChoiLego.jpg', N'Đồ chơi', N'9', N'6', N'700000', N'500000', N'10000', N'Đã duyệt', N'Bình Định', N'Nhật Bản', N'14/05/2022', N'60', N'Đồ chơi Lego với hơn 1000 viên Lego cho phép bạn sáng tạo và xây dựng các công trình độc đáo, giúp phát triển tư duy và khả năng sáng tạo cho trẻ em.', N'4', N'02/05/2024')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem], [NgayDang]) VALUES (17, 5, N'Áo sơ mi nữ', N'AoSoMiNu.jpg', N'Quần áo', N'4', N'6', N'700000', N'500000', N'20000', N'Đã duyệt', N'Khánh Hòa', N'Việt Nam', N'30/09/2020', N'70', N'Áo sơ mi nữ thiết kế dễ thương, phong cách trẻ trung, là item không thể thiếu trong tủ đồ của phái đẹp.', N'3', N'02/05/2024')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem], [NgayDang]) VALUES (18, 6, N'Sách "Dấu chân trên cát"', N'SachDauChanTrenCat.jpg', N'Sách', N'8', N'2', N'180000', N'100000', N'10000', N'Đã duyệt', N'Bà Rịa - Vũng Tàu', N'Mỹ', N'07/04/2021', N'40', N' Sách "Dấu chân trên cát" là một cuốn sách tâm linh sâu sắc, kể về hành trình tìm kiếm ý nghĩa cuộc đời qua những câu chuyện của những người đã trải qua nhiều gian nan và thách thức.', N'1', N'02/05/2024')
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([IdNguoiDung], [TenDangNhap], [MatKhau]) VALUES (0, N'Admin', N'1234')
INSERT [dbo].[TaiKhoan] ([IdNguoiDung], [TenDangNhap], [MatKhau]) VALUES (1, N'User01', N'1234')
INSERT [dbo].[TaiKhoan] ([IdNguoiDung], [TenDangNhap], [MatKhau]) VALUES (2, N'User02', N'1234')
INSERT [dbo].[TaiKhoan] ([IdNguoiDung], [TenDangNhap], [MatKhau]) VALUES (3, N'User03', N'1234')
INSERT [dbo].[TaiKhoan] ([IdNguoiDung], [TenDangNhap], [MatKhau]) VALUES (4, N'User04', N'1234')
INSERT [dbo].[TaiKhoan] ([IdNguoiDung], [TenDangNhap], [MatKhau]) VALUES (5, N'User05', N'1234')
INSERT [dbo].[TaiKhoan] ([IdNguoiDung], [TenDangNhap], [MatKhau]) VALUES (6, N'User06', N'1234')
INSERT [dbo].[TaiKhoan] ([IdNguoiDung], [TenDangNhap], [MatKhau]) VALUES (7, N'User06', N'1234')
INSERT [dbo].[TaiKhoan] ([IdNguoiDung], [TenDangNhap], [MatKhau]) VALUES (8, N'User07', N'1234')
INSERT [dbo].[TaiKhoan] ([IdNguoiDung], [TenDangNhap], [MatKhau]) VALUES (9, N'User08', N'1234')
INSERT [dbo].[TaiKhoan] ([IdNguoiDung], [TenDangNhap], [MatKhau]) VALUES (10, N'User09', N'1234')
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (1, 1, N'1', N'9020000', N'05/05/2024', N'Chờ giao hàng')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (1, 2, N'1', N'9030000', N'07/05/2024', N'Chờ xác nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (1, 3, N'1', N'16997000', N'07/05/2024', N'Chờ xác nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (1, 4, N'4', N'4030000', N'05/05/2024', N'Chờ giao hàng')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (1, 5, N'1', N'1930000', N'07/05/2024', N'Chờ xác nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (1, 9, N'1', N'4000000', N'07/05/2024', N'Chờ xác nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (1, 10, N'1', N'230000', N'07/05/2024', N'Chờ xác nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (1, 11, N'1', N'185000', N'07/05/2024', N'Chờ xác nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (1, 12, N'1', N'465000', N'07/05/2024', N'Chờ xác nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (1, 13, N'1', N'1010000', N'06/05/2024', N'Chờ xác nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (1, 17, N'1', N'520000', N'07/05/2024', N'Chờ xác nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (2, 2, N'2', N'9999', N'2/2/2019', N'Đã trả hàng')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (2, 3, N'3', N'200000', N'4/6/2019', N'Đã nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (3, 1, N'2', N'1231', N'1/1/1', N'Đã nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (3, 2, N'1', N'1231', N'1/1/1', N'Đã nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (3, 3, N'3', N'823947', N'1/1/1', N'Đã nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (3, 4, N'2', N'1231', N'1/1/1', N'Đã nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (5, 1, N'1', N'9000000', N'07/05/2024', N'Đã nhận')
GO
SET IDENTITY_INSERT [dbo].[Voucher] ON 

INSERT [dbo].[Voucher] ([IdVoucher], [TenVoucher], [GiaTri], [SoLuotSuDungToiDa], [SoLuotDaSuDung], [NgayBatDau], [NgayKetThuc]) VALUES (3, N'Voucher ngày 30/4', N'30000', N'50', N'27', N'2/3/2024', N'9/3/2024')
INSERT [dbo].[Voucher] ([IdVoucher], [TenVoucher], [GiaTri], [SoLuotSuDungToiDa], [SoLuotDaSuDung], [NgayBatDau], [NgayKetThuc]) VALUES (4, N'Voucher Lễ tình nhân', N'20000', N'10', N'9', N'27/11/2023', N'15/12/2024')
INSERT [dbo].[Voucher] ([IdVoucher], [TenVoucher], [GiaTri], [SoLuotSuDungToiDa], [SoLuotDaSuDung], [NgayBatDau], [NgayKetThuc]) VALUES (8, N'Voucher Lễ 1/5', N'20000', N'5', N'8', N'16/11/2023', N'15/12/2024')
INSERT [dbo].[Voucher] ([IdVoucher], [TenVoucher], [GiaTri], [SoLuotSuDungToiDa], [SoLuotDaSuDung], [NgayBatDau], [NgayKetThuc]) VALUES (9, N'Miễn Ship', N'15000', N'7', N'4', N'16/11/2023', N'15/12/2024')
INSERT [dbo].[Voucher] ([IdVoucher], [TenVoucher], [GiaTri], [SoLuotSuDungToiDa], [SoLuotDaSuDung], [NgayBatDau], [NgayKetThuc]) VALUES (12, N'Miễn Ship', N'20000', N'7', N'5', N'16/11/2023', N'15/12/2024')
INSERT [dbo].[Voucher] ([IdVoucher], [TenVoucher], [GiaTri], [SoLuotSuDungToiDa], [SoLuotDaSuDung], [NgayBatDau], [NgayKetThuc]) VALUES (13, N'Miễn Ship', N'5000', N'7', N'5', N'16/11/2023', N'15/12/2024')
SET IDENTITY_INSERT [dbo].[Voucher] OFF
GO
ALTER TABLE [dbo].[DanhGiaNguoiDang]  WITH CHECK ADD  CONSTRAINT [FK_DanhGiaNguoiDang_NguoiDung] FOREIGN KEY([IdNguoiDang])
REFERENCES [dbo].[NguoiDung] ([IdNguoiDung])
GO
ALTER TABLE [dbo].[DanhGiaNguoiDang] CHECK CONSTRAINT [FK_DanhGiaNguoiDang_NguoiDung]
GO
ALTER TABLE [dbo].[DanhGiaNguoiDang]  WITH CHECK ADD  CONSTRAINT [FK_DanhGiaNguoiDang_NguoiDung1] FOREIGN KEY([IdNguoiMua])
REFERENCES [dbo].[NguoiDung] ([IdNguoiDung])
GO
ALTER TABLE [dbo].[DanhGiaNguoiDang] CHECK CONSTRAINT [FK_DanhGiaNguoiDang_NguoiDung1]
GO
ALTER TABLE [dbo].[DanhMucYeuThich]  WITH CHECK ADD  CONSTRAINT [FK_DanhMucYeuThich_NguoiDung] FOREIGN KEY([IdNguoiMua])
REFERENCES [dbo].[NguoiDung] ([IdNguoiDung])
GO
ALTER TABLE [dbo].[DanhMucYeuThich] CHECK CONSTRAINT [FK_DanhMucYeuThich_NguoiDung]
GO
ALTER TABLE [dbo].[DanhMucYeuThich]  WITH CHECK ADD  CONSTRAINT [FK_DanhMucYeuThich_SanPham] FOREIGN KEY([IdSanPham])
REFERENCES [dbo].[SanPham] ([IdSanPham])
GO
ALTER TABLE [dbo].[DanhMucYeuThich] CHECK CONSTRAINT [FK_DanhMucYeuThich_SanPham]
GO
ALTER TABLE [dbo].[GiaoDich]  WITH CHECK ADD  CONSTRAINT [FK_GiaoDich_NguoiDung] FOREIGN KEY([IdNguoiDung])
REFERENCES [dbo].[NguoiDung] ([IdNguoiDung])
GO
ALTER TABLE [dbo].[GiaoDich] CHECK CONSTRAINT [FK_GiaoDich_NguoiDung]
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD  CONSTRAINT [FK_GioHang_NguoiDung] FOREIGN KEY([IdNguoiMua])
REFERENCES [dbo].[NguoiDung] ([IdNguoiDung])
GO
ALTER TABLE [dbo].[GioHang] CHECK CONSTRAINT [FK_GioHang_NguoiDung]
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD  CONSTRAINT [FK_GioHang_SanPham] FOREIGN KEY([IdSanPham])
REFERENCES [dbo].[SanPham] ([IdSanPham])
GO
ALTER TABLE [dbo].[GioHang] CHECK CONSTRAINT [FK_GioHang_SanPham]
GO
ALTER TABLE [dbo].[MoTaAnhSanPham]  WITH CHECK ADD  CONSTRAINT [FK_MoTaAnhSanPham_SanPham] FOREIGN KEY([IdSanPham])
REFERENCES [dbo].[SanPham] ([IdSanPham])
GO
ALTER TABLE [dbo].[MoTaAnhSanPham] CHECK CONSTRAINT [FK_MoTaAnhSanPham_SanPham]
GO
ALTER TABLE [dbo].[NguoiDungVoucher]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDungVoucher_NguoiDung] FOREIGN KEY([IdNguoiDung])
REFERENCES [dbo].[NguoiDung] ([IdNguoiDung])
GO
ALTER TABLE [dbo].[NguoiDungVoucher] CHECK CONSTRAINT [FK_NguoiDungVoucher_NguoiDung]
GO
ALTER TABLE [dbo].[NguoiDungVoucher]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDungVoucher_Voucher] FOREIGN KEY([IdVoucher])
REFERENCES [dbo].[Voucher] ([IdVoucher])
GO
ALTER TABLE [dbo].[NguoiDungVoucher] CHECK CONSTRAINT [FK_NguoiDungVoucher_Voucher]
GO
ALTER TABLE [dbo].[QuanLyDonHang]  WITH CHECK ADD  CONSTRAINT [FK_QuanLyDonHang_NguoiDung] FOREIGN KEY([IdNguoiDang])
REFERENCES [dbo].[NguoiDung] ([IdNguoiDung])
GO
ALTER TABLE [dbo].[QuanLyDonHang] CHECK CONSTRAINT [FK_QuanLyDonHang_NguoiDung]
GO
ALTER TABLE [dbo].[QuanLyDonHang]  WITH CHECK ADD  CONSTRAINT [FK_QuanLyDonHang_NguoiDung1] FOREIGN KEY([IdNguoiMua])
REFERENCES [dbo].[NguoiDung] ([IdNguoiDung])
GO
ALTER TABLE [dbo].[QuanLyDonHang] CHECK CONSTRAINT [FK_QuanLyDonHang_NguoiDung1]
GO
ALTER TABLE [dbo].[QuanLyDonHang]  WITH CHECK ADD  CONSTRAINT [FK_QuanLyDonHang_SanPham] FOREIGN KEY([IdSanPham])
REFERENCES [dbo].[SanPham] ([IdSanPham])
GO
ALTER TABLE [dbo].[QuanLyDonHang] CHECK CONSTRAINT [FK_QuanLyDonHang_SanPham]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_NguoiDung] FOREIGN KEY([IdNguoiDang])
REFERENCES [dbo].[NguoiDung] ([IdNguoiDung])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_NguoiDung]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_NguoiDung] FOREIGN KEY([IdNguoiDung])
REFERENCES [dbo].[NguoiDung] ([IdNguoiDung])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_NguoiDung]
GO
ALTER TABLE [dbo].[TrangThaiDonHang]  WITH CHECK ADD  CONSTRAINT [FK_TrangThaiDonHang_NguoiDung] FOREIGN KEY([IdNguoiMua])
REFERENCES [dbo].[NguoiDung] ([IdNguoiDung])
GO
ALTER TABLE [dbo].[TrangThaiDonHang] CHECK CONSTRAINT [FK_TrangThaiDonHang_NguoiDung]
GO
ALTER TABLE [dbo].[TrangThaiDonHang]  WITH CHECK ADD  CONSTRAINT [FK_TrangThaiDonHang_SanPham] FOREIGN KEY([IdSanPham])
REFERENCES [dbo].[SanPham] ([IdSanPham])
GO
ALTER TABLE [dbo].[TrangThaiDonHang] CHECK CONSTRAINT [FK_TrangThaiDonHang_SanPham]
GO

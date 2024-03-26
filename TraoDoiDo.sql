USE [TraoDoiDo]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 26/3/2024 9:25:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[IdDonHang] [int] IDENTITY(1,1) NOT NULL,
	[IdNguoiDang] [int] NULL,
	[IdNguoiMua] [int] NULL,
	[IdSanPham] [nvarchar](50) NULL,
	[TrangThai] [nvarchar](50) NULL,
	[LyDoTraHang] [nvarchar](100) NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[IdDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 26/3/2024 9:25:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[IdNguoiDung] [int] NOT NULL,
	[IdSanPham] [nvarchar](50) NOT NULL,
	[SoLuongMua] [nvarchar](50) NULL,
 CONSTRAINT [PK_GioHang] PRIMARY KEY CLUSTERED 
(
	[IdNguoiDung] ASC,
	[IdSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoTaAnhSanPham]    Script Date: 26/3/2024 9:25:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoTaAnhSanPham](
	[IdSanPham] [nvarchar](50) NOT NULL,
	[IdAnhMinhHoa] [nvarchar](50) NOT NULL,
	[LinkAnhMinhHoa] [nvarchar](50) NULL,
	[MoTa] [nvarchar](1000) NULL,
 CONSTRAINT [PK_MoTaAnhSanPham] PRIMARY KEY CLUSTERED 
(
	[IdSanPham] ASC,
	[IdAnhMinhHoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 26/3/2024 9:25:15 AM ******/
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
	[SdtNguoiDung] [nvarchar](11) NULL,
	[DiaChiNguoiDung] [nvarchar](100) NULL,
	[AnhNguoiDung] [nvarchar](200) NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[IdNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 26/3/2024 9:25:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[IdSanPham] [nvarchar](50) NOT NULL,
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
	[MoTaChung] [nvarchar](500) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[IdSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 26/3/2024 9:25:15 AM ******/
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
/****** Object:  Table [dbo].[TrangThaiDonHang]    Script Date: 26/3/2024 9:25:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThaiDonHang](
	[IdNguoiDung] [int] NOT NULL,
	[IdSanPham] [nvarchar](50) NOT NULL,
	[SoLuongMua] [nvarchar](50) NULL,
	[TongThanhToan] [nvarchar](50) NULL,
	[Ngay] [nvarchar](50) NULL,
	[TrangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK_TrangThaiDonHang] PRIMARY KEY CLUSTERED 
(
	[IdNguoiDung] ASC,
	[IdSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DonHang] ON 

INSERT [dbo].[DonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (1, 2, 1, N'1', N'Chờ đóng gói', NULL)
INSERT [dbo].[DonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (2, 1, 2, N'1', N'Chờ đóng gói', NULL)
INSERT [dbo].[DonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (3, 2, 1, N'2', N'Đang giao', NULL)
INSERT [dbo].[DonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (4, 1, 2, N'2', N'Đang giao', NULL)
INSERT [dbo].[DonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (5, 2, 1, N'3', N'Bị hoàn trả ', N'Khác với mô tả')
INSERT [dbo].[DonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (6, 1, 2, N'3', N'Đã giao', NULL)
SET IDENTITY_INSERT [dbo].[DonHang] OFF
GO
INSERT [dbo].[GioHang] ([IdNguoiDung], [IdSanPham], [SoLuongMua]) VALUES (1, N'1', N'2')
INSERT [dbo].[GioHang] ([IdNguoiDung], [IdSanPham], [SoLuongMua]) VALUES (2, N'1', N'1')
INSERT [dbo].[GioHang] ([IdNguoiDung], [IdSanPham], [SoLuongMua]) VALUES (2, N'3', N'3')
GO
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'1', N'1', N'IPadGen6_1.jpg', N'Hỏng góc trên bên trái\n\nPhần còn lại của iPad vẫn hoạt động bình thường.')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'1', N'2', N'IPadGen6_2.jpg', N'Trầy màn hình mức độ nhẹ, vẫn nhìn tốt\n\nMàn hình vẫn rõ nét, không có điểm chết hoặc vết xước lớn..')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'1', N'3', N'IPadGen6_3.jpg', N'Gọn nhẹ, dễ mang theo. Chiếc iPad này là sự lựa chọn hoàn hảo cho các chuyến đi, từ cuộc họp gặp gỡ công việc đến những chuyến du lịch khám phá thế giới\n\nVới kích thước nhỏ gọn và trọng lượng nhẹ, chiếc iPad này không chỉ dễ dàng để mang theo trong túi xách hay ba lô mà còn không gây trở ngại cho bạn khi di chuyển. Bạn có thể dễ dàng sử dụng nó trên máy bay, tàu hỏa, hoặc thậm chí trong các không gian hẹp.\n\nDù bạn đang trên đường đi hay đang tận hưởng một buổi họp công việc ở một quán cà phê, iPad này sẽ giúp bạn duy trì sự linh hoạt và hiệu suất cao. Hãy mang theo nó và khám phá thế giới một cách dễ dàng và thuận tiện!')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'2', N'1', N'tiviSony27inch_1.jpg', N'Màn hình còn mới')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'2', N'2', N'tiviSony27inch_2.jpg', N'Mặt sau nguyên vẹn')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'2', N'3', N'tiviSony27inch_3.jpg', N'Tổng thể còn xài được ')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'3', N'1', N'Screenshot 2024-03-24 210650.png', N'số 1')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'3', N'2', N'Screenshot 2024-03-25 191513.png', N'số 2')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'3', N'3', N'Iphone11_1.jpg', N'số 3')
GO
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([IdNguoiDung], [HoTenNguoiDung], [GioiTinhNguoiDung], [NgaySinhNguoiDung], [CMNDNguoiDung], [EmailNguoiDung], [SdtNguoiDung], [DiaChiNguoiDung], [AnhNguoiDung]) VALUES (1, N'Nguy?n Hoàng Anh Khoa', N'Nam', N'9/21/2004', N'073172381313', N'ak2109@gmail.com', N'0931288318', N'TPHCM', NULL)
INSERT [dbo].[NguoiDung] ([IdNguoiDung], [HoTenNguoiDung], [GioiTinhNguoiDung], [NgaySinhNguoiDung], [CMNDNguoiDung], [EmailNguoiDung], [SdtNguoiDung], [DiaChiNguoiDung], [AnhNguoiDung]) VALUES (2, N'Nguy?n Hoàng Anh Khoa', N'Nam', N'9/21/2004', N'073218931923', N'ak2109@gmail.com', N'0392193128', N'TPHCM', NULL)
INSERT [dbo].[NguoiDung] ([IdNguoiDung], [HoTenNguoiDung], [GioiTinhNguoiDung], [NgaySinhNguoiDung], [CMNDNguoiDung], [EmailNguoiDung], [SdtNguoiDung], [DiaChiNguoiDung], [AnhNguoiDung]) VALUES (3, N'Võ Van Trí', N'Nam', N'4/4/2004', N'078423949294', N'vovantri44@gmail.com', N'0982382347', N'Ð?ng Tháp', NULL)
INSERT [dbo].[NguoiDung] ([IdNguoiDung], [HoTenNguoiDung], [GioiTinhNguoiDung], [NgaySinhNguoiDung], [CMNDNguoiDung], [EmailNguoiDung], [SdtNguoiDung], [DiaChiNguoiDung], [AnhNguoiDung]) VALUES (4, N'Nghiêm Ð?i Ngân', N'Nam', N'1/2/2004', N'074932949234', N'daingan2612@gmail.com', N'0397410323', N'TPHCM', NULL)
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
GO
INSERT [dbo].[SanPham] ([IdSanPham], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung]) VALUES (N'1', N'IPadGen6', N'IPadGen6_1.jpg', N'Tablet', N'5', N'1', N'2.000.000', N'1.800.000', N'20.000', N'Chờ duyệt', N'Hồ Chí Minh', N'Nhật Bản', N'12/3/2020', N'80%', N'Smart Tivi Casper 32 inch 32HG5200 được thiết kế với vóc dáng vô cùng đơn giản, viền tivi mỏng 0,8 mm kết hợp với chân đế hình chữ V úp ngược mang lại tổng thể chiếc tivi trở nên sang trọng. Tivi Casper 32 inch phù hợp trưng bày ở những nơi có không gian nhỏ như: Phòng ngủ, phòng khách nhỏ,...')
INSERT [dbo].[SanPham] ([IdSanPham], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung]) VALUES (N'2', N'TVs Sony KV27FS120 27" Screen CRT TV', N'tiviSony27inch_1.jpg', N'Tivi', N'2', N'0', N'10.781.000', N'9.000.000', N'50.000', N'Đã duyệt', N'Hồ Chí Minh', N'Trung Quốc', N'2/2/2022', N'75%', N'Mẫu tivi Samsung Micro LED 4K 110 inch MNA110MS1A có công nghệ Quantum Dot tái tạo 100% dải màu sắc chuẩn điện ảnh và Micro LED kích thước cực nhỏ có khả năng thể hiện 3 màu cơ bản (đỏ - lục - lam) để tạo hình ảnh, màu sắc trực tiếp trên màn hình cực lớn 110 inch với độ phân giải 4K.')
INSERT [dbo].[SanPham] ([IdSanPham], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung]) VALUES (N'3', N'sieu nhan', N'Screenshot 2024-03-24 210650.png', N'phim', N'13', N'123', N'1231', N'23123', N'123', N'Đã duyệt', N'21', N'3213', N'1231', N'23123', N'123')
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([IdNguoiDung], [TenDangNhap], [MatKhau]) VALUES (1, N'User01', N'1234')
INSERT [dbo].[TaiKhoan] ([IdNguoiDung], [TenDangNhap], [MatKhau]) VALUES (2, N'User02', N'12345')
INSERT [dbo].[TaiKhoan] ([IdNguoiDung], [TenDangNhap], [MatKhau]) VALUES (3, N'User03', N'12345')
INSERT [dbo].[TaiKhoan] ([IdNguoiDung], [TenDangNhap], [MatKhau]) VALUES (4, N'User04', N'223344')
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiDung], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (1, N'1', N'2', N'2.000.000', N'27/12/2023', N'Chờ xác nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiDung], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (1, N'2', N'1', N'1.000.000', N'8/1/2024', N'Chờ giao hàng')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiDung], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (1, N'3', N'3', N'1.000.000', N'1/1/2024', N'Đã nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiDung], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (2, N'1', N'2', N'2.000.000', N'4/4/2024', N'Chờ xác nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiDung], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (2, N'2', N'1', N'1.200.000', N'3/3/2024', N'Chờ giao hàng')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiDung], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (2, N'3', N'3', N'200.000', N'4/6/2019', N'Đã nhận')
GO

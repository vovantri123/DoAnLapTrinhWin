USE [TraoDoiDo]
GO
/****** Object:  Table [dbo].[DanhGiaNguoiDang]    Script Date: 28/3/2024 10:08:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGiaNguoiDang](
	[IdNguoiDang] [int] NOT NULL,
	[IdNguoiMua] [int] NOT NULL,
	[SoSao] [nvarchar](50) NULL,
	[NhanXet] [nvarchar](500) NULL,
 CONSTRAINT [PK_DanhGiaNguoiDang] PRIMARY KEY CLUSTERED 
(
	[IdNguoiDang] ASC,
	[IdNguoiMua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 28/3/2024 10:08:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[IdNguoiMua] [int] NOT NULL,
	[IdSanPham] [nvarchar](50) NOT NULL,
	[SoLuongMua] [nvarchar](50) NULL,
 CONSTRAINT [PK_GioHang] PRIMARY KEY CLUSTERED 
(
	[IdNguoiMua] ASC,
	[IdSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoTaAnhSanPham]    Script Date: 28/3/2024 10:08:05 AM ******/
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
/****** Object:  Table [dbo].[QuanLyDonHang]    Script Date: 28/3/2024 10:08:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyDonHang](
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
/****** Object:  Table [dbo].[SanPham]    Script Date: 28/3/2024 10:08:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[IdSanPham] [nvarchar](50) NOT NULL,
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
	[MoTaChung] [nvarchar](500) NULL,
	[SoLuotXem] [nvarchar](50) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[IdSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrangThaiDonHang]    Script Date: 28/3/2024 10:08:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThaiDonHang](
	[IdNguoiMua] [int] NOT NULL,
	[IdSanPham] [nvarchar](50) NOT NULL,
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
INSERT [dbo].[DanhGiaNguoiDang] ([IdNguoiDang], [IdNguoiMua], [SoSao], [NhanXet]) VALUES (1, 2, N'5', N'Người bán có giao hàng chất lượng')
INSERT [dbo].[DanhGiaNguoiDang] ([IdNguoiDang], [IdNguoiMua], [SoSao], [NhanXet]) VALUES (1, 3, N'3', N'Người bán rất đẹp trai')
INSERT [dbo].[DanhGiaNguoiDang] ([IdNguoiDang], [IdNguoiMua], [SoSao], [NhanXet]) VALUES (1, 4, N'4', N'Shipper thân thiện')
INSERT [dbo].[DanhGiaNguoiDang] ([IdNguoiDang], [IdNguoiMua], [SoSao], [NhanXet]) VALUES (2, 1, N'5', N'Tốt')
INSERT [dbo].[DanhGiaNguoiDang] ([IdNguoiDang], [IdNguoiMua], [SoSao], [NhanXet]) VALUES (2, 2, N'2', N'xin chào')
INSERT [dbo].[DanhGiaNguoiDang] ([IdNguoiDang], [IdNguoiMua], [SoSao], [NhanXet]) VALUES (2, 3, N'4', N'Rất tốt')
GO
INSERT [dbo].[GioHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua]) VALUES (1, N'1', N'1')
INSERT [dbo].[GioHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua]) VALUES (1, N'3', N'2')
INSERT [dbo].[GioHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua]) VALUES (2, N'1', N'1')
INSERT [dbo].[GioHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua]) VALUES (2, N'2', N'2')
INSERT [dbo].[GioHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua]) VALUES (2, N'3', N'4')
INSERT [dbo].[GioHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua]) VALUES (2, N'4', N'1')
GO
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'1', N'1', N'IPadGen6_1.jpg', N'Hỏng góc trên bên trái\n\nPhần còn lại của iPad vẫn hoạt động bình thường.')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'1', N'2', N'IPadGen6_2.jpg', N'Trầy màn hình mức độ nhẹ, vẫn nhìn tốt\n\nMàn hình vẫn rõ nét, không có điểm chết hoặc vết xước lớn..')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'1', N'3', N'IPadGen6_3.jpg', N'Gọn nhẹ, dễ mang theo. Chiếc iPad này là sự lựa chọn hoàn hảo cho các chuyến đi, từ cuộc họp gặp gỡ công việc đến những chuyến du lịch khám phá thế giới\n\nVới kích thước nhỏ gọn và trọng lượng nhẹ, chiếc iPad này không chỉ dễ dàng để mang theo trong túi xách hay ba lô mà còn không gây trở ngại cho bạn khi di chuyển. Bạn có thể dễ dàng sử dụng nó trên máy bay, tàu hỏa, hoặc thậm chí trong các không gian hẹp.\n\nDù bạn đang trên đường đi hay đang tận hưởng một buổi họp công việc ở một quán cà phê, iPad này sẽ giúp bạn duy trì sự linh hoạt và hiệu suất cao. Hãy mang theo nó và khám phá thế giới một cách dễ dàng và thuận tiện!')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'2', N'1', N'tiviSony27inch_1.jpg', N'Màn hình còn mới')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'2', N'2', N'tiviSony27inch_2.jpg', N'Mặt sau nguyên vẹn')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'2', N'3', N'tiviSony27inch_3.jpg', N'Tổng thể còn xài được ')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'3', N'1', N'Iphone11_2.jpg', N'')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'3', N'2', N'Iphone11_1.jpg', N'ádadsads')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'3', N'3', N'Iphone11_3.jpg', N'')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'4', N'1', N'Screenshot 2024-03-26 202613.png', N'ảnh số 1 ')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'4', N'2', N'Screenshot 2024-03-26 202653.png', N'ảnh số 2')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'4', N'3', N'Screenshot 2024-03-26 202624.png', N'ảnh số 3')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'5', N'1', N'Screenshot 2024-03-26 212138.png', N'1')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'5', N'2', N'Screenshot 2024-03-26 212412.png', N'2')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'6', N'1', N'Screenshot 2024-03-26 212056.png', N'123123')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'7', N'1', N'Screenshot 2024-03-26 212630.png', N'số 1')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'7', N'2', N'Screenshot 2024-03-26 212646.png', N'2')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'7', N'3', N'Screenshot 2024-03-26 212708.png', N'số 3')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'8', N'1', N'Screenshot 2024-03-26 212934.png', N'1')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'8', N'2', N'Screenshot 2024-03-26 212905.png', N'23')
INSERT [dbo].[MoTaAnhSanPham] ([IdSanPham], [IdAnhMinhHoa], [LinkAnhMinhHoa], [MoTa]) VALUES (N'8', N'3', N'Screenshot 2024-03-26 212925.png', N'1124124')
GO
SET IDENTITY_INSERT [dbo].[QuanLyDonHang] ON 

INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (1, 2, 1, N'1', N'Chờ đóng gói', NULL)
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (11, 1, 2, N'1', N'Đang giao', NULL)
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (12, 2, 1, N'2', N'Đang giao', NULL)
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (13, 1, 2, N'2', N'Đang giao', NULL)
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (14, 2, 1, N'3', N'Bị hoàn trả', N'Khác với mô tả')
INSERT [dbo].[QuanLyDonHang] ([IdDonHang], [IdNguoiDang], [IdNguoiMua], [IdSanPham], [TrangThai], [LyDoTraHang]) VALUES (15, 1, 2, N'3', N'Đã giao', NULL)
SET IDENTITY_INSERT [dbo].[QuanLyDonHang] OFF
GO
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem]) VALUES (N'1', 1, N'IPadGen6', N'IPadGen6_1.jpg', N'Tablet', N'5', N'1', N'2000000', N'1800000', N'20000', N'Chờ duyệt', N'Hồ Chí Minh', N'Nhật Bản', N'12/3/2020', N'80%', N'Smart Tivi Casper 32 inch 32HG5200 được thiết kế với vóc dáng vô cùng đơn giản, viền tivi mỏng 0,8 mm kết hợp với chân đế hình chữ V úp ngược mang lại tổng thể chiếc tivi trở nên sang trọng. Tivi Casper 32 inch phù hợp trưng bày ở những nơi có không gian nhỏ như: Phòng ngủ, phòng khách nhỏ,...', N'22')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem]) VALUES (N'2', 2, N'TVs Sony KV27FS120 27" Screen CRT TV', N'tiviSony27inch_1.jpg', N'Tivi', N'2', N'0', N'10700000', N'9000000', N'50000', N'Đã duyệt', N'Hồ Chí Minh', N'Trung Quốc', N'2/2/2022', N'75%', N'Mẫu tivi Samsung Micro LED 4K 110 inch MNA110MS1A có công nghệ Quantum Dot tái tạo 100% dải màu sắc chuẩn điện ảnh và Micro LED kích thước cực nhỏ có khả năng thể hiện 3 màu cơ bản (đỏ - lục - lam) để tạo hình ảnh, màu sắc trực tiếp trên màn hình cực lớn 110 inch với độ phân giải 4K.', N'31')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem]) VALUES (N'3', 2, N'IPhone 13', N'Iphone11_2.jpg', N'phim', N'3', N'2', N'120000', N'23123', N'27000', N'Đã duyệt', N'Đà Lạt', N'3213', N'2/2/2021', N'23123', N'Smart Tivi Casper 32 inch 32HG5200 được thiết kế với vóc dáng vô cùng đơn giản, viền tivi mỏng 0,8 mm kết hợp với chân đế hình chữ V úp ngược mang lại tổng thể chiếc tivi trở nên sang trọng. Tivi Casper 32 inch phù hợp trưng bày ở những nơi có không gian nhỏ như: Phòng ngủ, phòng khách nhỏ,...', N'19')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem]) VALUES (N'4', 1, N'Mô hình one piece', N'Screenshot 2024-03-26 202613.png', N'Đồ chơi', N'2', N'1', N'420000', N'1000000', N'50000', N'Đã duyệt', N'Tây Ninh', N'China', N'23/3/2004', N'90%', N'MÔ HÌNH Monkey D Luffy gear 4 King Fado Myoo CAO CẤP CỠ LỚN có led chiến đấu với Kaido trong anime One piece ', N'132')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem]) VALUES (N'5', 2, N'Đồ đi chơi ', N'Screenshot 2024-03-26 212138.png', N'123123', N'15', N'3', N'2500000', N'1900000', N'30000', N'Đã duyệt', N'Hà Nội', N'12', N'3123', N'123123', N'Smart Tivi Casper 32 inch 32HG5200 được thiết kế với vóc dáng vô cùng đơn giản, viền tivi mỏng 0,8 mm kết hợp với chân đế hình chữ V úp ngược mang lại tổng thể chiếc tivi trở nên sang trọng. Tivi Casper 32 inch phù hợp trưng bày ở những nơi có không gian nhỏ như: Phòng ngủ, phòng khách nhỏ,...', N'49')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem]) VALUES (N'6', 2, N'Quần áo nam', N'Screenshot 2024-03-26 212056.png', N'123123', N'12', N'5', N'9999000', N'4999000', N'40000', N'Đã duyệt', N'Lào Cai', N'3123', N'123123', N'123', N'Smart Tivi Casper 32 inch 32HG5200 được thiết kế với vóc dáng vô cùng đơn giản, viền tivi mỏng 0,8 mm kết hợp với chân đế hình chữ V úp ngược mang lại tổng thể chiếc tivi trở nên sang trọng. Tivi Casper 32 inch phù hợp trưng bày ở những nơi có không gian nhỏ như: Phòng ngủ, phòng khách nhỏ,...', N'18')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem]) VALUES (N'7', 1, N'Harry Potter và hòn đá phù thủy', N'Screenshot 2024-03-26 212630.png', N'Sách', N'2', N'1', N'1200000', N'1100000', N'50000', N'Đã duyệt', N'Đà Nẵng', N'637', N'4', N'734', N'Smart Tivi Casper 32 inch 32HG5200 được thiết kế với vóc dáng vô cùng đơn giản, viền tivi mỏng 0,8 mm kết hợp với chân đế hình chữ V úp ngược mang lại tổng thể chiếc tivi trở nên sang trọng. Tivi Casper 32 inch phù hợp trưng bày ở những nơi có không gian nhỏ như: Phòng ngủ, phòng khách nhỏ,...', N'20')
INSERT [dbo].[SanPham] ([IdSanPham], [IdNguoiDang], [Ten], [LinkAnhBia], [Loai], [SoLuong], [SoLuongDaBan], [GiaGoc], [GiaBan], [PhiShip], [TrangThai], [NoiBan], [XuatXu], [NgayMua], [PhanTramMoi], [MoTaChung], [SoLuotXem]) VALUES (N'8', 2, N'máy xay sinh tố', N'Screenshot 2024-03-26 212934.png', N'Đồ nội thất', N'4', N'2', N'2700000', N'2000000', N'20000', N'Đã duyệt', N'Quảng Ngãi', N'213', N'123', N'1231', N'Smart Tivi Casper 32 inch 32HG5200 được thiết kế với vóc dáng vô cùng đơn giản, viền tivi mỏng 0,8 mm kết hợp với chân đế hình chữ V úp ngược mang lại tổng thể chiếc tivi trở nên sang trọng. Tivi Casper 32 inch phù hợp trưng bày ở những nơi có không gian nhỏ như: Phòng ngủ, phòng khách nhỏ,...', N'54')
GO
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (1, N'1', N'2', N'2000000', N'27/12/2023', N'Chờ xác nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (1, N'2', N'1', N'100000', N'1/1/2042', N'Chờ giao hàng')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (1, N'3', N'3', N'1200000', N'1/1/2024', N'Đã nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (2, N'1', N'2', N'187000', N'1/1/2023', N'Chờ xác nhận')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (2, N'2', N'2', N'9999', N'2/2/2019', N'Chờ giao hàng')
INSERT [dbo].[TrangThaiDonHang] ([IdNguoiMua], [IdSanPham], [SoLuongMua], [TongThanhToan], [Ngay], [TrangThai]) VALUES (2, N'3', N'3', N'200000', N'4/6/2019', N'Đã nhận')
GO

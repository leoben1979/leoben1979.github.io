# 專案使用說明
嘉裕蘋果手機旗艦店

1.將資料夾COPY到您的專案資料夾下
2.建立專案資料庫。
使用Microsoft SQL Server Management Studio ,新增查詢,將下面的SQL程式碼複制並貼到新增查詢的視窗,執行SQL程式碼
3.Visual Studio 開啟專案。執行專案。


## 資料庫

- sql 程式碼

  USE [JiaYu]
GO
/****** Object:  Table [dbo].[Batch]    Script Date: 2021/7/6 上午 11:27:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Batch](
	[batch_id] [varchar](50) NOT NULL,
	[pro_id] [varchar](50) NOT NULL,
	[b_date] [date] NOT NULL,
	[price] [int] NOT NULL,
 CONSTRAINT [PK_Batch] PRIMARY KEY CLUSTERED 
(
	[batch_id] ASC,
	[pro_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 2021/7/6 上午 11:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[rowid] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [varchar](50) NULL,
	[pro_id] [varchar](50) NULL,
	[pname] [nvarchar](100) NULL,
	[qty] [int] NULL,
	[create_time] [datetime] NULL,
	[spec] [nvarchar](200) NULL,
	[lot_no] [nvarchar](50) NULL,
	[price] [int] NULL,
	[amount] [int] NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[rowid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2021/7/6 上午 11:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[cate_id] [varchar](10) NOT NULL,
	[super_id] [varchar](10) NULL,
	[ca_name] [nvarchar](100) NOT NULL,
	[sort_no] [int] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[cate_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ColorList]    Script Date: 2021/7/6 上午 11:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColorList](
	[color_no] [int] IDENTITY(1,1) NOT NULL,
	[color_name] [nvarchar](30) NULL,
 CONSTRAINT [PK_ColorList] PRIMARY KEY CLUSTERED 
(
	[color_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ColorRelation]    Script Date: 2021/7/6 上午 11:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColorRelation](
	[color_no] [int] NOT NULL,
	[pro_id] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ColorRelation] PRIMARY KEY CLUSTERED 
(
	[color_no] ASC,
	[pro_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryList]    Script Date: 2021/7/6 上午 11:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryList](
	[user_id] [varchar](50) NOT NULL,
	[address_no] [int] NOT NULL,
	[del_name] [nvarchar](100) NOT NULL,
	[del_tel] [varchar](30) NOT NULL,
	[del_address] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_DeliveryList] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC,
	[address_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manage]    Script Date: 2021/7/6 上午 11:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manage](
	[user_id] [nvarchar](50) NOT NULL,
	[passwd] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[verify] [bit] NOT NULL,
	[m_name] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Manage] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 2021/7/6 上午 11:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[user_id] [varchar](50) NOT NULL,
	[passwd] [varchar](100) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[verify] [bit] NOT NULL,
	[reg_date] [datetime] NOT NULL,
	[id_number] [varchar](10) NOT NULL,
	[m_name] [nvarchar](100) NOT NULL,
	[sex] [varchar](20) NOT NULL,
	[birthday] [date] NOT NULL,
	[telephone] [varchar](30) NOT NULL,
	[cellphone] [varchar](30) NOT NULL,
	[address] [nvarchar](100) NOT NULL,
	[remark] [nvarchar](255) NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2021/7/6 上午 11:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[rowid] [int] IDENTITY(1,1) NOT NULL,
	[order_no] [nvarchar](50) NULL,
	[order_date] [datetime] NULL,
	[order_status] [nvarchar](50) NULL,
	[user_no] [nvarchar](50) NULL,
	[payment_no] [nvarchar](50) NULL,
	[shipping_no] [nvarchar](50) NULL,
	[receive_name] [nvarchar](50) NULL,
	[receive_email] [nvarchar](50) NULL,
	[receive_address] [nvarchar](250) NULL,
	[amounts] [int] NULL,
	[taxs] [int] NULL,
	[totals] [int] NULL,
	[remark] [nvarchar](250) NULL,
	[order_guid] [nvarchar](50) NULL,
	[order_closed] [int] NULL,
	[order_validate] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[rowid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdersDetail]    Script Date: 2021/7/6 上午 11:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersDetail](
	[rowid] [int] IDENTITY(1,1) NOT NULL,
	[order_no] [nvarchar](50) NULL,
	[vendor_no] [nvarchar](50) NULL,
	[category_name] [nvarchar](50) NULL,
	[product_no] [nvarchar](50) NULL,
	[product_name] [nvarchar](250) NULL,
	[product_spec] [nvarchar](250) NULL,
	[price] [int] NULL,
	[qty] [int] NULL,
	[amount] [int] NULL,
	[remark] [nvarchar](250) NULL,
 CONSTRAINT [PK_OrdersDetail] PRIMARY KEY CLUSTERED 
(
	[rowid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 2021/7/6 上午 11:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[rowid] [int] IDENTITY(1,1) NOT NULL,
	[mno] [nvarchar](50) NULL,
	[mname] [nvarchar](50) NULL,
	[remark] [nvarchar](250) NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[rowid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Photo]    Script Date: 2021/7/6 上午 11:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photo](
	[rowid] [int] IDENTITY(1,1) NOT NULL,
	[pro_id] [varchar](50) NULL,
	[filename] [varchar](250) NULL,
 CONSTRAINT [PK_Photo_1] PRIMARY KEY CLUSTERED 
(
	[rowid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2021/7/6 上午 11:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[pro_id] [varchar](50) NOT NULL,
	[pname] [nvarchar](100) NOT NULL,
	[categoryid] [varchar](10) NULL,
	[ven_id] [varchar](50) NOT NULL,
	[Is_top] [bit] NULL,
	[Is_hot] [bit] NULL,
	[is_sales] [bit] NULL,
	[price_sale] [int] NOT NULL,
	[memory] [varchar](10) NULL,
	[color] [int] NULL,
	[spec] [nvarchar](250) NULL,
	[Browse_time] [int] NOT NULL,
	[remark] [ntext] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[pro_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 2021/7/6 上午 11:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[pur_id] [varchar](50) NOT NULL,
	[pro_id] [varchar](50) NOT NULL,
	[pur_date] [date] NOT NULL,
 CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED 
(
	[pur_id] ASC,
	[pro_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shippings]    Script Date: 2021/7/6 上午 11:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shippings](
	[rowid] [int] IDENTITY(1,1) NOT NULL,
	[mno] [nvarchar](50) NULL,
	[mname] [nvarchar](50) NULL,
	[remark] [nvarchar](250) NULL,
 CONSTRAINT [PK_Shippings] PRIMARY KEY CLUSTERED 
(
	[rowid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 2021/7/6 上午 11:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[rowid] [int] IDENTITY(1,1) NOT NULL,
	[mno] [nvarchar](50) NULL,
	[mname] [nvarchar](50) NULL,
	[remark] [nvarchar](250) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[rowid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vender]    Script Date: 2021/7/6 上午 11:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vender](
	[ven_id] [varchar](50) NOT NULL,
	[ven_name] [nvarchar](150) NULL,
	[tax_id_number] [varchar](20) NOT NULL,
	[ven_sort_name] [nvarchar](100) NULL,
	[address] [varchar](150) NOT NULL,
	[tel] [varchar](50) NOT NULL,
	[contact_person] [nvarchar](50) NULL,
	[email] [varchar](100) NULL,
 CONSTRAINT [PK_Vender] PRIMARY KEY CLUSTERED 
(
	[ven_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Category] ([cate_id], [super_id], [ca_name], [sort_no]) VALUES (N'A', NULL, N'Mac', 1)
INSERT [dbo].[Category] ([cate_id], [super_id], [ca_name], [sort_no]) VALUES (N'A01', N'A', N'MacBook Air', 1)
INSERT [dbo].[Category] ([cate_id], [super_id], [ca_name], [sort_no]) VALUES (N'A02', N'A', N'MacBook Pro', 2)
INSERT [dbo].[Category] ([cate_id], [super_id], [ca_name], [sort_no]) VALUES (N'A03', N'A', N'iMac', 3)
INSERT [dbo].[Category] ([cate_id], [super_id], [ca_name], [sort_no]) VALUES (N'B', NULL, N'iPad', 2)
INSERT [dbo].[Category] ([cate_id], [super_id], [ca_name], [sort_no]) VALUES (N'B01', N'B', N'iPad Air', 1)
INSERT [dbo].[Category] ([cate_id], [super_id], [ca_name], [sort_no]) VALUES (N'B02', N'B', N'iPad Pro', 2)
INSERT [dbo].[Category] ([cate_id], [super_id], [ca_name], [sort_no]) VALUES (N'B03', N'B', N'iPad mini', 3)
INSERT [dbo].[Category] ([cate_id], [super_id], [ca_name], [sort_no]) VALUES (N'B04', N'B', N'iPad', 4)
INSERT [dbo].[Category] ([cate_id], [super_id], [ca_name], [sort_no]) VALUES (N'C', NULL, N'iPhone', 3)
INSERT [dbo].[Category] ([cate_id], [super_id], [ca_name], [sort_no]) VALUES (N'C01', N'C', N'iPhone 12 Pro', 1)
INSERT [dbo].[Category] ([cate_id], [super_id], [ca_name], [sort_no]) VALUES (N'C02', N'C', N'iPhone 12', 2)
INSERT [dbo].[Category] ([cate_id], [super_id], [ca_name], [sort_no]) VALUES (N'C03', N'C', N'iPhone SE', 5)
INSERT [dbo].[Category] ([cate_id], [super_id], [ca_name], [sort_no]) VALUES (N'C04', N'C', N'iPhone 11', 4)
GO
SET IDENTITY_INSERT [dbo].[ColorList] ON 

INSERT [dbo].[ColorList] ([color_no], [color_name]) VALUES (1, N'銀色')
INSERT [dbo].[ColorList] ([color_no], [color_name]) VALUES (2, N'金色')
INSERT [dbo].[ColorList] ([color_no], [color_name]) VALUES (3, N'白色')
INSERT [dbo].[ColorList] ([color_no], [color_name]) VALUES (4, N'太空灰')
INSERT [dbo].[ColorList] ([color_no], [color_name]) VALUES (5, N'黑色')
INSERT [dbo].[ColorList] ([color_no], [color_name]) VALUES (6, N'太平洋藍')
INSERT [dbo].[ColorList] ([color_no], [color_name]) VALUES (7, N'香檳黃')
INSERT [dbo].[ColorList] ([color_no], [color_name]) VALUES (8, N'紅色')
SET IDENTITY_INSERT [dbo].[ColorList] OFF
GO
INSERT [dbo].[ColorRelation] ([color_no], [pro_id]) VALUES (1, N'Pro202106240001')
INSERT [dbo].[ColorRelation] ([color_no], [pro_id]) VALUES (1, N'Pro202106240003')
INSERT [dbo].[ColorRelation] ([color_no], [pro_id]) VALUES (1, N'Pro202106240004')
INSERT [dbo].[ColorRelation] ([color_no], [pro_id]) VALUES (1, N'Pro202106240005')
INSERT [dbo].[ColorRelation] ([color_no], [pro_id]) VALUES (2, N'Pro202106240003')
INSERT [dbo].[ColorRelation] ([color_no], [pro_id]) VALUES (2, N'Pro202106240004')
INSERT [dbo].[ColorRelation] ([color_no], [pro_id]) VALUES (3, N'Pro202106240005')
INSERT [dbo].[ColorRelation] ([color_no], [pro_id]) VALUES (4, N'Pro202106240001')
INSERT [dbo].[ColorRelation] ([color_no], [pro_id]) VALUES (4, N'Pro202106240002')
INSERT [dbo].[ColorRelation] ([color_no], [pro_id]) VALUES (4, N'Pro202106240004')
INSERT [dbo].[ColorRelation] ([color_no], [pro_id]) VALUES (4, N'Pro202106240005')
INSERT [dbo].[ColorRelation] ([color_no], [pro_id]) VALUES (5, N'Pro202106240003')
INSERT [dbo].[ColorRelation] ([color_no], [pro_id]) VALUES (6, N'Pro202106240002')
INSERT [dbo].[ColorRelation] ([color_no], [pro_id]) VALUES (8, N'Pro202106240002')
GO
INSERT [dbo].[Manage] ([user_id], [passwd], [email], [verify], [m_name]) VALUES (N'admin', N'jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=', N'momahjong@gmail.com', 1, N'管理員                                                                                                 ')
GO
INSERT [dbo].[Member] ([user_id], [passwd], [email], [verify], [reg_date], [id_number], [m_name], [sex], [birthday], [telephone], [cellphone], [address], [remark]) VALUES (N'a001', N'BXhBiNvOvYBmlrhHq3reVG2LyUcn2Q3Mhn8P7EJkwFU=', N'ab123@gamil.com', 1, CAST(N'2021-05-05T09:10:11.000' AS DateTime), N'A12233444', N'阿强伯公2', N'M', CAST(N'1919-01-04' AS Date), N'123456334', N'123456334', N'台北市忠孝路4', N'')
INSERT [dbo].[Member] ([user_id], [passwd], [email], [verify], [reg_date], [id_number], [m_name], [sex], [birthday], [telephone], [cellphone], [address], [remark]) VALUES (N'a004', N'BXhBiNvOvYBmlrhHq3reVG2LyUcn2Q3Mhn8P7EJkwFU=', N'ac@gmail.com', 0, CAST(N'2021-05-16T17:51:07.933' AS DateTime), N'A123456789', N'ASDL', N'F', CAST(N'2021-05-14' AS Date), N'02-54', N'0988777666', N'桃園市平鎮市', N'')
INSERT [dbo].[Member] ([user_id], [passwd], [email], [verify], [reg_date], [id_number], [m_name], [sex], [birthday], [telephone], [cellphone], [address], [remark]) VALUES (N'a005', N'1u2RpFfpsNdFjFKwEtVTuOEaDVnEOgTtEvO1L46AY4Y=', N'acc11@gmail.com', 1, CAST(N'2021-05-21T00:26:06.113' AS DateTime), N'A012345678', N'jason', N'M', CAST(N'1974-07-01' AS Date), N'03-54', N'03-54', N'桃園市平鎮市234', N'')
INSERT [dbo].[Member] ([user_id], [passwd], [email], [verify], [reg_date], [id_number], [m_name], [sex], [birthday], [telephone], [cellphone], [address], [remark]) VALUES (N'a006', N'j6nxL7jDoiPJKIDSS1lLuczNMa+9nYRS+0TB40FvT2c=', N'acc1@gmail.com', 1, CAST(N'2021-05-24T01:30:17.907' AS DateTime), N'A1234', N'阿强1', N'F', CAST(N'2021-05-25' AS Date), N'1234563', N'1234563', N'桃園市平鎮市234', NULL)
INSERT [dbo].[Member] ([user_id], [passwd], [email], [verify], [reg_date], [id_number], [m_name], [sex], [birthday], [telephone], [cellphone], [address], [remark]) VALUES (N'a007', N'BZG1nBvdms0oR6IC3dAsPxT5taBJpXB8MnnB6Wd0XtQ=', N'acc1109@gmail.com', 1, CAST(N'2021-05-24T01:38:28.320' AS DateTime), N'A123456889', N'阿强1', N'M', CAST(N'2021-05-12' AS Date), N'02-54711234', N'12345633', N'桃園市平鎮市234', N'')
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([rowid], [order_no], [order_date], [order_status], [user_no], [payment_no], [shipping_no], [receive_name], [receive_email], [receive_address], [amounts], [taxs], [totals], [remark], [order_guid], [order_closed], [order_validate]) VALUES (7, N'00000007', CAST(N'2021-06-29T20:15:53.937' AS DateTime), N'CP', N'a001', N'01', N'01', N'張先生', N'momahjong@gmail.com', N'桃園市楊梅區秀才路851號', NULL, NULL, 41868, N'', N'DD8B5469-EFAC-4043-B331-1', 0, 0)
INSERT [dbo].[Orders] ([rowid], [order_no], [order_date], [order_status], [user_no], [payment_no], [shipping_no], [receive_name], [receive_email], [receive_address], [amounts], [taxs], [totals], [remark], [order_guid], [order_closed], [order_validate]) VALUES (8, N'00000008', CAST(N'2021-06-29T20:22:50.467' AS DateTime), N'PN', N'a001', N'01', N'01', N'張先生', N'momahjong@gmail.com', N'桃園市楊梅區秀才路851號', NULL, NULL, 1251, N'', N'B117688B-013E-42A4-877F-2', 0, 0)
INSERT [dbo].[Orders] ([rowid], [order_no], [order_date], [order_status], [user_no], [payment_no], [shipping_no], [receive_name], [receive_email], [receive_address], [amounts], [taxs], [totals], [remark], [order_guid], [order_closed], [order_validate]) VALUES (9, N'00000009', CAST(N'2021-06-29T06:18:11.000' AS DateTime), N'CP', N'a001', N'01', N'01', N'黃大牛', N'momahjong@gmail.com', N'桃園市中壢區', NULL, NULL, 2345, NULL, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[OrdersDetail] ON 

INSERT [dbo].[OrdersDetail] ([rowid], [order_no], [vendor_no], [category_name], [product_no], [product_name], [product_spec], [price], [qty], [amount], [remark]) VALUES (29, N'00000007', NULL, NULL, N'Pro202106240003', N'MacBook Air 13.3吋', N'MacBook Air 13.3吋,8GB,銀色', 29355, 1, 29355, N'')
INSERT [dbo].[OrdersDetail] ([rowid], [order_no], [vendor_no], [category_name], [product_no], [product_name], [product_spec], [price], [qty], [amount], [remark]) VALUES (30, N'00000007', NULL, NULL, N'Pro202106240004', N'ipd', N'ipd,64G,金色', 12513, 1, 12513, N'')
INSERT [dbo].[OrdersDetail] ([rowid], [order_no], [vendor_no], [category_name], [product_no], [product_name], [product_spec], [price], [qty], [amount], [remark]) VALUES (31, N'00000008', NULL, NULL, N'Pro202106240004', N'ipd', N'ipd,64G,金色', 1251, 1, 1251, N'')
INSERT [dbo].[OrdersDetail] ([rowid], [order_no], [vendor_no], [category_name], [product_no], [product_name], [product_spec], [price], [qty], [amount], [remark]) VALUES (32, N'00000009', NULL, NULL, N'Pro202106240004', N'ipd', N'ipd,64G,紅色', 2345, 1, 2345, NULL)
SET IDENTITY_INSERT [dbo].[OrdersDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([rowid], [mno], [mname], [remark]) VALUES (1, N'01', N'信用卡一次付清', NULL)
INSERT [dbo].[Payments] ([rowid], [mno], [mname], [remark]) VALUES (2, N'02', N'ATM轉帳', NULL)
INSERT [dbo].[Payments] ([rowid], [mno], [mname], [remark]) VALUES (1005, N'03', N'信用卡分3期', NULL)
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
SET IDENTITY_INSERT [dbo].[Photo] ON 

INSERT [dbo].[Photo] ([rowid], [pro_id], [filename]) VALUES (39, N'Pro202106240001', N'Pro202106240001-01.PNG')
INSERT [dbo].[Photo] ([rowid], [pro_id], [filename]) VALUES (40, N'Pro202106240001', N'Pro202106240001-02.PNG')
INSERT [dbo].[Photo] ([rowid], [pro_id], [filename]) VALUES (41, N'Pro202106240001', N'Pro202106240001-03.PNG')
INSERT [dbo].[Photo] ([rowid], [pro_id], [filename]) VALUES (42, N'Pro202106240001', N'Pro202106240001-04.PNG')
INSERT [dbo].[Photo] ([rowid], [pro_id], [filename]) VALUES (43, N'Pro202106240001', N'Pro202106240001-05.PNG')
INSERT [dbo].[Photo] ([rowid], [pro_id], [filename]) VALUES (44, N'Pro202106240002', N'Pro202106240002-01.PNG')
INSERT [dbo].[Photo] ([rowid], [pro_id], [filename]) VALUES (45, N'Pro202106240002', N'Pro202106240002-02.jpg')
INSERT [dbo].[Photo] ([rowid], [pro_id], [filename]) VALUES (46, N'Pro202106240002', N'Pro202106240002-03.jpg')
INSERT [dbo].[Photo] ([rowid], [pro_id], [filename]) VALUES (47, N'Pro202106240003', N'Pro202106240003-01.PNG')
INSERT [dbo].[Photo] ([rowid], [pro_id], [filename]) VALUES (48, N'Pro202106240003', N'Pro202106240003-02.PNG')
INSERT [dbo].[Photo] ([rowid], [pro_id], [filename]) VALUES (49, N'Pro202106240003', N'Pro202106240003-03.jpg')
INSERT [dbo].[Photo] ([rowid], [pro_id], [filename]) VALUES (50, N'Pro202106240004', N'Pro202106240004-01.PNG')
INSERT [dbo].[Photo] ([rowid], [pro_id], [filename]) VALUES (51, N'Pro202106240004', N'Pro202106240004-02.PNG')
INSERT [dbo].[Photo] ([rowid], [pro_id], [filename]) VALUES (52, N'Pro202106240005', N'Pro202106240005-01.png')
INSERT [dbo].[Photo] ([rowid], [pro_id], [filename]) VALUES (53, N'Pro202106240005', N'Pro202106240005-02.png')
INSERT [dbo].[Photo] ([rowid], [pro_id], [filename]) VALUES (55, N'Pro202106240005', N'Pro202106240005-1624523108.png')
SET IDENTITY_INSERT [dbo].[Photo] OFF
GO
INSERT [dbo].[Product] ([pro_id], [pname], [categoryid], [ven_id], [Is_top], [Is_hot], [is_sales], [price_sale], [memory], [color], [spec], [Browse_time], [remark]) VALUES (N'Pro202106240001', N'iMac', N'A03', N'V01', 0, 1, 0, 33900, N'256GB SSD', NULL, N'2.3GHz 雙核心第七代 Intel Core i5 處理器，Turbo Boost 可達 3.6GHz 8GB 2133MHz DDR4 記憶體 256GB SSD 儲存裝置 Intel Iris Plus Graphics 640 巧控滑鼠 2 巧控鍵盤 - 繁體中文 (倉頡及注音)', 100, N'鍵盤
含數字鍵盤的巧控鍵盤現已推出。
巧控鍵盤 - 繁體中文 (倉頡及注音)
預先安裝的軟體
Final Cut Pro')
INSERT [dbo].[Product] ([pro_id], [pname], [categoryid], [ven_id], [Is_top], [Is_hot], [is_sales], [price_sale], [memory], [color], [spec], [Browse_time], [remark]) VALUES (N'Pro202106240002', N'Mac Book Air 15吋', N'A01', N'V01', 0, 1, 0, 32355, N'8GB', NULL, N'Apple M1 晶片配備 8 核心 CPU、8 核心 GPU • 16 核心神經網路引擎 • 8GB 統一記憶體 • 512GB SSD 儲存裝置 • 具備原彩顯示的 Retina 顯示器 • 巧控鍵盤 • Touch ID • 力度觸控板 • 兩個 Thunderbolt / USB 4 埠', 47, N'另備有金色、太空灰色與銀色可供選擇')
INSERT [dbo].[Product] ([pro_id], [pname], [categoryid], [ven_id], [Is_top], [Is_hot], [is_sales], [price_sale], [memory], [color], [spec], [Browse_time], [remark]) VALUES (N'Pro202106240003', N'MacBook Air 13.3吋', N'A01', N'V01', 0, 1, 0, 29355, N'8GB', NULL, N'MacBook Air 8G/256G13.3 吋 LED 背光顯示器Apple M1 晶片8 核心 CPU 配備 4 個效能核心與 4 個節能核心7 核心 GPU, 8 核心 GPU16 核心神經網路引擎8GB 統一記憶體256GB SSD', 10, N'外觀
金色、銀色、太空灰色

電池與電源1
最長可達 15 小時無線上網時間
最長可達 18 小時 Apple TV app 電影播放時間
內建 49.9 瓦特小時鋰聚合物電池
30W USB-C 電源轉接器

充電與擴充
兩個 Thunderbolt / USB 4 埠，可支援：

充電
DisplayPort
Thunderbolt 3 (最快可達 40Gb/s)
USB 3.1 Gen 2 (最快可達 10Gb/s)')
INSERT [dbo].[Product] ([pro_id], [pname], [categoryid], [ven_id], [Is_top], [Is_hot], [is_sales], [price_sale], [memory], [color], [spec], [Browse_time], [remark]) VALUES (N'Pro202106240004', N'ipd', N'B03', N'V01', 0, 0, 0, 1251, N'64G', NULL, N'重量不到500g 精巧好攜帶A12仿生晶片效能強大主鏡頭8MP 後鏡頭7MP64 位元架構的 A12 仿生晶片神經網路引擎嵌入式 M12 協同處理器', 0, N'電源與電池
所有機型
內建 19.1 瓦特小時可充電鋰聚合物電池
Wi？Fi 無線上網、觀賞影片或聆聽音樂最長可達 10 小時
透過電源轉接器或電腦 USB 連接埠充電
Wi？Fi + 行動網路機型
使用行動數據網路上網最長可達 9 小時

作業系統 iOS 12')
INSERT [dbo].[Product] ([pro_id], [pname], [categoryid], [ven_id], [Is_top], [Is_hot], [is_sales], [price_sale], [memory], [color], [spec], [Browse_time], [remark]) VALUES (N'Pro202106240005', N'IPHONE 234', N'A01', N'V01', 0, 1, 0, 234567, N'256G', NULL, N'ffffgg', 12, N'rrrrr')
GO
SET IDENTITY_INSERT [dbo].[Shippings] ON 

INSERT [dbo].[Shippings] ([rowid], [mno], [mname], [remark]) VALUES (1, N'01', N'超商取貨', NULL)
INSERT [dbo].[Shippings] ([rowid], [mno], [mname], [remark]) VALUES (2, N'02', N'物流配送', NULL)
SET IDENTITY_INSERT [dbo].[Shippings] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([rowid], [mno], [mname], [remark]) VALUES (1, N'ON', N'已下單未付款', N'已下單')
INSERT [dbo].[Status] ([rowid], [mno], [mname], [remark]) VALUES (2, N'PP', N'已付款處理中', N'處理中')
INSERT [dbo].[Status] ([rowid], [mno], [mname], [remark]) VALUES (3, N'DS', N'已出貨未到店', N'已出貨')
INSERT [dbo].[Status] ([rowid], [mno], [mname], [remark]) VALUES (4, N'SR', N'已到店未領取', N'未領取')
INSERT [dbo].[Status] ([rowid], [mno], [mname], [remark]) VALUES (5, N'PN', N'未付款處理中', N'處理中')
INSERT [dbo].[Status] ([rowid], [mno], [mname], [remark]) VALUES (6, N'CP', N'已領取已付款', N'已領取')
INSERT [dbo].[Status] ([rowid], [mno], [mname], [remark]) VALUES (7, N'OP', N'已下單已付款', N'已下單')
INSERT [dbo].[Status] ([rowid], [mno], [mname], [remark]) VALUES (8, N'DU', N'已出貨未到府', N'已出貨')
INSERT [dbo].[Status] ([rowid], [mno], [mname], [remark]) VALUES (9, N'HD', N'訂單保留', N'保留中')
INSERT [dbo].[Status] ([rowid], [mno], [mname], [remark]) VALUES (10, N'OR', N'取消訂單', N'取消訂單')
INSERT [dbo].[Status] ([rowid], [mno], [mname], [remark]) VALUES (11, N'RT', N'已退貨', N'已退貨')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
ALTER TABLE [dbo].[Batch] ADD  CONSTRAINT [DF_Batch_b_date]  DEFAULT (getdate()) FOR [b_date]
GO
ALTER TABLE [dbo].[Batch] ADD  CONSTRAINT [DF_Batch_price]  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[Carts] ADD  CONSTRAINT [DF_Carts_qty]  DEFAULT ((0)) FOR [qty]
GO
ALTER TABLE [dbo].[Manage] ADD  CONSTRAINT [DF_Manage_active]  DEFAULT ((0)) FOR [verify]
GO
ALTER TABLE [dbo].[Member] ADD  CONSTRAINT [DF_Member_sex]  DEFAULT ('M') FOR [sex]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_order_closed]  DEFAULT ((0)) FOR [order_closed]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_order_validate]  DEFAULT ((0)) FOR [order_validate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Is_top]  DEFAULT ((0)) FOR [Is_top]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Is_hot]  DEFAULT ((0)) FOR [Is_hot]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_is_sales]  DEFAULT ((0)) FOR [is_sales]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_price_sale]  DEFAULT ((0)) FOR [price_sale]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Browse_time]  DEFAULT ((0)) FOR [Browse_time]
GO
ALTER TABLE [dbo].[Purchase] ADD  CONSTRAINT [DF_Purchase_pur_date]  DEFAULT (getdate()) FOR [pur_date]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Batch', @level2type=N'COLUMN',@level2name=N'batch_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Batch', @level2type=N'COLUMN',@level2name=N'pro_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Batch', @level2type=N'COLUMN',@level2name=N'b_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'進貨價格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Batch', @level2type=N'COLUMN',@level2name=N'price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批號資料檔' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Batch'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品分類編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'cate_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上層分類的編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'super_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品分類名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'ca_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'sort_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品分類' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ColorList', @level2type=N'COLUMN',@level2name=N'color_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顏色名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ColorList', @level2type=N'COLUMN',@level2name=N'color_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顏色基本資料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ColorList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顏色編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ColorRelation', @level2type=N'COLUMN',@level2name=N'color_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ColorRelation', @level2type=N'COLUMN',@level2name=N'pro_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品與顏色屬性' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ColorRelation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'會員帳號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DeliveryList', @level2type=N'COLUMN',@level2name=N'user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'寄送地址編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DeliveryList', @level2type=N'COLUMN',@level2name=N'address_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收件人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DeliveryList', @level2type=N'COLUMN',@level2name=N'del_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收件人電話' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DeliveryList', @level2type=N'COLUMN',@level2name=N'del_tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收件地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DeliveryList', @level2type=N'COLUMN',@level2name=N'del_address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'會員寄送地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DeliveryList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1.管理者帳號
2.編碼原則:西元年月日+流水號3碼
3.例:20210102001
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Manage', @level2type=N'COLUMN',@level2name=N'user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Manage', @level2type=N'COLUMN',@level2name=N'passwd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'電子郵件信箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Manage', @level2type=N'COLUMN',@level2name=N'email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帳號啟用/停用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Manage', @level2type=N'COLUMN',@level2name=N'verify'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理者帳號資料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Manage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'會員帳號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'passwd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'電子郵件信箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'己通過郵件驗証' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'verify'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'註冊時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'reg_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份證號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'id_number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'm_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性別。M:男性,F:女性' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'birthday'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'電話' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'telephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'行動電話' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'cellphone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'聯絡地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'會員基本資料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'相片編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Photo', @level2type=N'COLUMN',@level2name=N'rowid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Photo', @level2type=N'COLUMN',@level2name=N'pro_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'相片檔案名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Photo', @level2type=N'COLUMN',@level2name=N'filename'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品相片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Photo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'pro_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'pname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品分類代號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'categoryid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'廠商代號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'ven_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'置頂顯示' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'Is_top'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'熱銷商品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'Is_hot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否上架販售' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'is_sales'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'售價' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'price_sale'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'記憶體容量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'memory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顏色編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'color'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品規格/詳細內容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'spec'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'瀏灠次數' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'Browse_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'備註' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品基本資料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'進貨單編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Purchase', @level2type=N'COLUMN',@level2name=N'pur_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Purchase', @level2type=N'COLUMN',@level2name=N'pro_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'進貨日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Purchase', @level2type=N'COLUMN',@level2name=N'pur_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品進貨單' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Purchase'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1.編號
2.編碼原則:VEN+西元年月日+流水號3碼
3.例:20210403001
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vender', @level2type=N'COLUMN',@level2name=N'ven_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'廠商名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vender', @level2type=N'COLUMN',@level2name=N'ven_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'統一編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vender', @level2type=N'COLUMN',@level2name=N'tax_id_number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'簡稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vender', @level2type=N'COLUMN',@level2name=N'ven_sort_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vender', @level2type=N'COLUMN',@level2name=N'address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'電話' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vender', @level2type=N'COLUMN',@level2name=N'tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'聯絡人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vender', @level2type=N'COLUMN',@level2name=N'contact_person'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'聯絡人電子郵件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vender', @level2type=N'COLUMN',@level2name=N'email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'廠商基本資料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vender'
GO


- sql 帳密
帳號:sa
密碼:1qaz@wsx

## 簡單操作說明

## 帳密

- 測試帳密

  使用者: a001
  密碼: a001

- 管理者帳密
  
  使用者: admin
  密碼: admin

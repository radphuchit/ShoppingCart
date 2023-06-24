USE [Learning]
GO
/****** Object:  Table [dbo].[Stocks]    Script Date: 6/24/2023 5:51:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stocks](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[PricePerUnit] [float] NOT NULL,
	[StockQty] [int] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Stocks] ON 
GO
INSERT [dbo].[Stocks] ([ProductId], [ProductName], [PricePerUnit], [StockQty]) VALUES (1, N'T-Shirt', 10, 7)
GO
INSERT [dbo].[Stocks] ([ProductId], [ProductName], [PricePerUnit], [StockQty]) VALUES (2, N'Cap', 15, 9)
GO
INSERT [dbo].[Stocks] ([ProductId], [ProductName], [PricePerUnit], [StockQty]) VALUES (3, N'Shoe', 100, 3)
GO
SET IDENTITY_INSERT [dbo].[Stocks] OFF
GO

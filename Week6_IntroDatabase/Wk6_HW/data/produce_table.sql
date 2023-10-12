USE [PROG260FA23]
GO
/****** Object:  Table [dbo].[Produce]    Script Date: 10/12/2023 6:07:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produce](
	[Name] [nvarchar](50) NOT NULL,
	[Location] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
	[UoM] [nchar](10) NOT NULL,
	[Sell_by_Date] [datetime2](7) NOT NULL
) ON [PRIMARY]
GO

USE [PROG260FA23]
GO
/****** Object:  Table [dbo].[Produce]    Script Date: 10/19/2023 3:11:16 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Produce]') AND type in (N'U'))
DROP TABLE [dbo].[Produce]
GO
/****** Object:  Table [dbo].[Produce]    Script Date: 10/19/2023 3:11:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produce](
	[Name] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
	[Price] [money] NULL,
	[UoM] [nchar](10) NULL,
	[Sell_by_Date] [datetime2](7) NULL
) ON [PRIMARY]
GO

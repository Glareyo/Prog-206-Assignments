USE [PROG260FA23]
GO
/****** Object:  Table [dbo].[Characters]    Script Date: 10/19/2023 6:07:41 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Characters]') AND type in (N'U'))
DROP TABLE [dbo].[Characters]
GO
/****** Object:  Table [dbo].[Characters]    Script Date: 10/19/2023 6:07:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Characters](
	[Character] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Map_Location] [nvarchar](50) NULL,
	[Original_charachter] [bit] NULL,
	[Sword_Fighter] [bit] NULL,
	[Magic_User] [bit] NULL
) ON [PRIMARY]
GO

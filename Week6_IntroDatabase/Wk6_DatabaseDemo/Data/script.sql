USE [PROG260FA23]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 10/12/2023 5:38:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Game]') AND type in (N'U'))
DROP TABLE [dbo].[Game]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 10/12/2023 5:38:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Publisher] [nvarchar](50) NOT NULL,
	[Release_Date] [datetime2](7) NULL,
	[Sold] [int] NULL,
	[Rating] [float] NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Game] ON 

INSERT [dbo].[Game] ([ID], [Name], [Publisher], [Release_Date], [Sold], [Rating]) VALUES (1, N'The Secret of Monkey Island', N'Lucasfilm Games', CAST(N'1990-10-01T00:00:00.0000000' AS DateTime2), 0, 94)
INSERT [dbo].[Game] ([ID], [Name], [Publisher], [Release_Date], [Sold], [Rating]) VALUES (2, N'The Secret of Monkey Island', N'Lucasfilm Games', CAST(N'1990-10-01T00:00:00.0000000' AS DateTime2), 0, 94)
INSERT [dbo].[Game] ([ID], [Name], [Publisher], [Release_Date], [Sold], [Rating]) VALUES (4, N'The Secret of Monkey Island', N'Lucasfilm Games', CAST(N'1990-10-01T00:00:00.0000000' AS DateTime2), NULL, 94)
INSERT [dbo].[Game] ([ID], [Name], [Publisher], [Release_Date], [Sold], [Rating]) VALUES (5, N'The Secret of Monkey Island', N'Lucasfilm Games', CAST(N'1990-10-01T00:00:00.0000000' AS DateTime2), NULL, 94)
SET IDENTITY_INSERT [dbo].[Game] OFF
GO

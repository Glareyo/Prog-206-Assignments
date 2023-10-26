USE [PROG260FA23]
GO
ALTER TABLE [dbo].[Types] DROP CONSTRAINT [FK_Types_Types]
GO
/****** Object:  Table [dbo].[Types]    Script Date: 10/25/2023 3:59:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Types]') AND type in (N'U'))
DROP TABLE [dbo].[Types]
GO
/****** Object:  Table [dbo].[Characters]    Script Date: 10/25/2023 3:59:03 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Characters]') AND type in (N'U'))
DROP TABLE [dbo].[Characters]
GO
/****** Object:  Table [dbo].[Characters]    Script Date: 10/25/2023 3:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Characters](
	[Character] [nvarchar](50) NOT NULL,
	[Type] [int] NULL,
	[Map_Location] [int] NULL,
	[Original_charachter] [bit] NULL,
	[Sword_Fighter] [bit] NULL,
	[Magic_User] [bit] NULL,
 CONSTRAINT [PK_Characters] PRIMARY KEY CLUSTERED 
(
	[Character] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Types]    Script Date: 10/25/2023 3:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types](
	[TypeID] [int] NOT NULL,
	[TypeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Types] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Characters] ([Character], [Type], [Map_Location], [Original_charachter], [Sword_Fighter], [Magic_User]) VALUES (N'Boybrush Threepwood', 2, 0, 0, 0, 0)
INSERT [dbo].[Characters] ([Character], [Type], [Map_Location], [Original_charachter], [Sword_Fighter], [Magic_User]) VALUES (N'Captain LeChuck', 9, 5, 1, 1, 1)
INSERT [dbo].[Characters] ([Character], [Type], [Map_Location], [Original_charachter], [Sword_Fighter], [Magic_User]) VALUES (N'Captain Madison', 5, 1, 0, 1, 0)
INSERT [dbo].[Characters] ([Character], [Type], [Map_Location], [Original_charachter], [Sword_Fighter], [Magic_User]) VALUES (N'Carla', 5, 1, 1, 1, 0)
INSERT [dbo].[Characters] ([Character], [Type], [Map_Location], [Original_charachter], [Sword_Fighter], [Magic_User]) VALUES (N'Elain Marley', 8, 4, 1, 1, 0)
INSERT [dbo].[Characters] ([Character], [Type], [Map_Location], [Original_charachter], [Sword_Fighter], [Magic_User]) VALUES (N'Flambe', 11, 5, 0, 0, 1)
INSERT [dbo].[Characters] ([Character], [Type], [Map_Location], [Original_charachter], [Sword_Fighter], [Magic_User]) VALUES (N'Guybrush Threepwood', 7, 0, 1, 0, 0)
INSERT [dbo].[Characters] ([Character], [Type], [Map_Location], [Original_charachter], [Sword_Fighter], [Magic_User]) VALUES (N'Herman Toothrot', 0, 2, 0, 0, 0)
INSERT [dbo].[Characters] ([Character], [Type], [Map_Location], [Original_charachter], [Sword_Fighter], [Magic_User]) VALUES (N'Iron Rose', 9, 5, 0, 1, 0)
INSERT [dbo].[Characters] ([Character], [Type], [Map_Location], [Original_charachter], [Sword_Fighter], [Magic_User]) VALUES (N'Judge Planke', 6, 3, 0, 0, 0)
INSERT [dbo].[Characters] ([Character], [Type], [Map_Location], [Original_charachter], [Sword_Fighter], [Magic_User]) VALUES (N'Locke Smith', 2, 1, 0, 0, 0)
INSERT [dbo].[Characters] ([Character], [Type], [Map_Location], [Original_charachter], [Sword_Fighter], [Magic_User]) VALUES (N'Murray', 1, 0, 1, 0, 0)
INSERT [dbo].[Characters] ([Character], [Type], [Map_Location], [Original_charachter], [Sword_Fighter], [Magic_User]) VALUES (N'Ned', 2, 0, 1, 0, 0)
INSERT [dbo].[Characters] ([Character], [Type], [Map_Location], [Original_charachter], [Sword_Fighter], [Magic_User]) VALUES (N'Otis', 4, 1, 1, 1, 0)
INSERT [dbo].[Characters] ([Character], [Type], [Map_Location], [Original_charachter], [Sword_Fighter], [Magic_User]) VALUES (N'Putra', 10, 5, 0, 0, 0)
INSERT [dbo].[Characters] ([Character], [Type], [Map_Location], [Original_charachter], [Sword_Fighter], [Magic_User]) VALUES (N'Voodoo Lady', 1, 1, 1, 0, 1)
GO
INSERT [dbo].[Types] ([TypeID], [TypeName]) VALUES (1, N'Ghost')
INSERT [dbo].[Types] ([TypeID], [TypeName]) VALUES (2, N'Human')
INSERT [dbo].[Types] ([TypeID], [TypeName]) VALUES (3, N'Melee Island')
INSERT [dbo].[Types] ([TypeID], [TypeName]) VALUES (4, N'Inmate')
INSERT [dbo].[Types] ([TypeID], [TypeName]) VALUES (5, N'Pirate')
INSERT [dbo].[Types] ([TypeID], [TypeName]) VALUES (6, N'NPC')
INSERT [dbo].[Types] ([TypeID], [TypeName]) VALUES (7, N'Mighty Pirate')
INSERT [dbo].[Types] ([TypeID], [TypeName]) VALUES (8, N'Politician')
INSERT [dbo].[Types] ([TypeID], [TypeName]) VALUES (9, N'Ghost Pirate')
INSERT [dbo].[Types] ([TypeID], [TypeName]) VALUES (10, N'Ghost Cook')
INSERT [dbo].[Types] ([TypeID], [TypeName]) VALUES (11, N'Fire Ghost')
GO
ALTER TABLE [dbo].[Types]  WITH CHECK ADD  CONSTRAINT [FK_Types_Types] FOREIGN KEY([TypeID])
REFERENCES [dbo].[Types] ([TypeID])
GO
ALTER TABLE [dbo].[Types] CHECK CONSTRAINT [FK_Types_Types]
GO

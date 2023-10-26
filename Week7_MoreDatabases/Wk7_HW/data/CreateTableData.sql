delete from dbo.Types	
delete from dbo.Locations

/*Insert Locations*/
INSERT INTO [dbo].[Locations] ([LocationID],[Location]) VALUES ('1','Melee Island')
INSERT INTO [dbo].[Locations] ([LocationID],[Location]) VALUES ('2','Terror Island')
INSERT INTO [dbo].[Locations] ([LocationID],[Location]) VALUES ('3','"Brrrmuda"')
INSERT INTO [dbo].[Locations] ([LocationID],[Location]) VALUES ('4','Scurvy Island')
INSERT INTO [dbo].[Locations] ([LocationID],[Location]) VALUES ('5','LeChuck''s Ship')

/*Insert Types*/
INSERT INTO [dbo].[Types] ([TypeID],[Type]) VALUES ('1','Ghost')
INSERT INTO [dbo].[Types] ([TypeID],[Type]) VALUES ('2','Human')
INSERT INTO [dbo].[Types] ([TypeID],[Type]) VALUES ('3','Melee Island')
INSERT INTO [dbo].[Types] ([TypeID],[Type]) VALUES ('4','Inmate')
INSERT INTO [dbo].[Types] ([TypeID],[Type]) VALUES ('5','Pirate')
INSERT INTO [dbo].[Types] ([TypeID],[Type]) VALUES ('6','NPC')
INSERT INTO [dbo].[Types] ([TypeID],[Type]) VALUES ('7','Mighty Pirate')
INSERT INTO [dbo].[Types] ([TypeID],[Type]) VALUES ('8','Politician')
INSERT INTO [dbo].[Types] ([TypeID],[Type]) VALUES ('9','Ghost Pirate')
INSERT INTO [dbo].[Types] ([TypeID],[Type]) VALUES ('10','Ghost Cook')
INSERT INTO [dbo].[Types] ([TypeID],[Type]) VALUES ('11','Fire Ghost')

select * from dbo.Types
select * from dbo.Locations


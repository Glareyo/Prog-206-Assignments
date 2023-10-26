select * from dbo.Characters
select * from dbo.Locations
select * from dbo.Types

select Characters.Character,Types.Type,Locations.Location,Characters.Original_charachter,Characters.Sword_Fighter,Characters.Magic_User
From Characters
Inner Join Locations
ON Characters.Map_Location = Locations.LocationID
Inner Join Types
ON Characters.Type = Types.TypeID
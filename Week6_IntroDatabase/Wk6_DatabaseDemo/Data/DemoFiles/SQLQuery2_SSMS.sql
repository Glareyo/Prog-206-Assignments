--Comment
--Names / target attributes must be the same case and spelling.

-- Selects everything in the game table
-- Method 1
-- select * from Game
-- Method 2
select * from PROG260FA23.dbo.Game --Names / target attributes must be the same case and spelling.

-- Selects a specific selection
select top 2 * from Game


--targets a specific instance that has the ID of 2
-- where ID = 2

--Updates all the attributes of the target name in each instance.
-- update Game Set Sold = 9999
-- where Sold = 25000

--Deletes a specific instance at the target location
-- delete from PROG260FA23.dbo.Game
-- where ID = 3
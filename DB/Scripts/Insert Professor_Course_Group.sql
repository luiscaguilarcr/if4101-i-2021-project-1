USE [IF4101_2021_SPA]

DECLARE @Professor_Id int, 
		@Course_Id int, 
		@Group_Id int, 
		@Creation_User nvarchar(50), 
		@Update_User nvarchar(50);

SET @Professor_Id = 3;
SET @Course_Id = 4;
SET @Group_Id = 2;
SET @Creation_User = 'Superadmin';
SET @Update_User = 'Superadmin';

INSERT INTO [dbo].[Professor_Course_Group] ([Professor_Id], [Course_Id], [Gorup_Id], [Creation_User], [Update_User])
VALUES (@Professor_Id, @Course_Id, @Group_Id, @Creation_User, @Update_User)

SELECT P.[Name] AS 'Name', G.Code AS 'Group', C.[Name] AS 'Course' 
FROM [Professor_Course_Group] PCG, [dbo].[Professor] p, [dbo].[Group] G, [dbo].[Course] C
WHERE PCG.Course_Id = C.Id
AND PCG.Gorup_Id = G.Id
AND PCG.Professor_Id = P.Id
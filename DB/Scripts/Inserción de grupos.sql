DECLARE @Code nvarchar(3), 
		@Course_Id int, 
		@Creation_User nvarchar(50), 
		@Update_User nvarchar(50);


SET @Code = '061';
SET @Course_Id = 13;
SET @Creation_User = 'Superadmin';
SET @Update_User = 'Superadmin';

INSERT INTO [dbo].[Group] ([Code], [Course_Id], [Creation_User], [Update_User])
VALUES (@Code, @Course_Id, @Creation_User, @Update_User)

SELECT C.[Id] AS 'Id', C.[Name] AS 'Name', G.[Code]  AS 'Code' FROM [Group] G, [Course] C
WHERE G.Course_Id = C.Id
ORDER BY C.[Id]
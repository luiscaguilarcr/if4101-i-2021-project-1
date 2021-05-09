DECLARE @Code nvarchar(6), 
		@Name nvarchar(100),
		@Email nvarchar(100),
		@Password nvarchar(30), 
		@Creation_User nvarchar(50), 
		@Update_User nvarchar(50);

SET @Code = 'B54355';
SET @Name = 'MARINA UGARTE REGUEIRO';
SET @Email = 'mariana.ugarte@ucr.ac.cr';
SET @Password = '4YlLG574ZSK5q';
SET @Creation_User = 'Superadmin';
SET @Update_User = 'Superadmin';

INSERT INTO [dbo].[Student] ([Code], [Name], [Email], [Password], [Creation_User], [Update_User])
VALUES (@Code, @Name, @Email, @Password, @Creation_User, @Update_User)

SELECT * FROM [Student]

DECLARE @Code nvarchar(6), 
		@Name nvarchar(100),
		@Email nvarchar(100), 
		@Password nvarchar(30),
		@AcademicDegree_Id int,
		@Creation_User nvarchar(50), 
		@Update_User nvarchar(50);


SET @Code = 'admin';
SET @Name = 'JOSE LOIS CURIEL MORAT';
SET @Email = 'joselois.morat@ucr.ac.cr';
SET @Password = 'admin';
SET @AcademicDegree_Id = 2;
SET @Creation_User = 'Superadmin';
SET @Update_User = 'Superadmin';

INSERT INTO [dbo].[Professor] ([Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_User], [Update_User])
VALUES (@Code, @Name, @Email, @Password, @AcademicDegree_Id, @Creation_User, @Update_User)

SELECT * FROM [Professor]

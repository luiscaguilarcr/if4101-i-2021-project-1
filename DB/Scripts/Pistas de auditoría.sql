USE [IF4101_2021_SPA]

--COURSE
ALTER TABLE  [dbo].[Course] ADD Creation_Date date
ALTER TABLE  [dbo].[Course] ADD Creation_User nvarchar(50)
ALTER TABLE  [dbo].[Course] ADD Update_Date date
ALTER TABLE  [dbo].[Course] ADD Update_User nvarchar(50)

ALTER TABLE [dbo].[Course] 
ADD CONSTRAINT DF_Creation_Date_Course DEFAULT GETDATE() FOR Creation_Date
ALTER TABLE [dbo].[Course] 
ADD CONSTRAINT DF_Creation_User_Course DEFAULT  'DBA' FOR Creation_User
ALTER TABLE [dbo].[Course] 
ADD CONSTRAINT DF_Update_Date_Course DEFAULT GETDATE() FOR Update_Date
ALTER TABLE [dbo].[Course] 
ADD CONSTRAINT DF_Update_User_Course DEFAULT 'DBA' FOR Update_User

--STUDENT
ALTER TABLE  [dbo].[Student] ADD Creation_Date date
ALTER TABLE  [dbo].[Student] ADD Creation_User nvarchar(50)
ALTER TABLE  [dbo].[Student] ADD Update_Date date
ALTER TABLE  [dbo].[Student] ADD Update_User nvarchar(50)

ALTER TABLE [dbo].[Student] 
ADD CONSTRAINT DF_Creation_Date_Student DEFAULT GETDATE() FOR Creation_Date
ALTER TABLE [dbo].[Student] 
ADD CONSTRAINT DF_Creation_User_Student DEFAULT 'DBA' FOR Creation_User
ALTER TABLE [dbo].[Student] 
ADD CONSTRAINT DF_Update_Date_Student DEFAULT GETDATE() FOR Update_Date
ALTER TABLE [dbo].[Student] 
ADD CONSTRAINT DF_Update_User_Student DEFAULT 'DBA' FOR Update_User


--GROUP
ALTER TABLE  [dbo].[Group] ADD Creation_Date date
ALTER TABLE  [dbo].[Group] ADD Creation_User nvarchar(50)
ALTER TABLE  [dbo].[Group] ADD Update_Date date
ALTER TABLE  [dbo].[Group] ADD Update_User nvarchar(50)

ALTER TABLE [dbo].[Group] 
ADD CONSTRAINT DF_Creation_Date_Group DEFAULT GETDATE() FOR Creation_Date
ALTER TABLE [dbo].[Group] 
ADD CONSTRAINT DF_Creation_User_Group DEFAULT 'DBA' FOR Creation_User
ALTER TABLE [dbo].[Group] 
ADD CONSTRAINT DF_Update_Date_Group DEFAULT GETDATE() FOR Update_Date
ALTER TABLE [dbo].[Group] 
ADD CONSTRAINT DF_Update_User_Group DEFAULT 'DBA' FOR Update_User

--PROFESSOR
ALTER TABLE  [dbo].[Professor] ADD Creation_Date date
ALTER TABLE  [dbo].[Professor] ADD Creation_User nvarchar(50)
ALTER TABLE  [dbo].[Professor] ADD Update_Date date
ALTER TABLE  [dbo].[Professor] ADD Update_User nvarchar(50)

ALTER TABLE [dbo].[Professor] 
ADD CONSTRAINT DF_Creation_Date_Professor DEFAULT GETDATE() FOR Creation_Date
ALTER TABLE [dbo].[Professor] 
ADD CONSTRAINT DF_Creation_User_Professor DEFAULT 'DBA' FOR Creation_User
ALTER TABLE [dbo].[Professor] 
ADD CONSTRAINT DF_Update_Date_Professor DEFAULT GETDATE() FOR Update_Date
ALTER TABLE [dbo].[Professor] 
ADD CONSTRAINT DF_Update_User_Professor DEFAULT 'DBA' FOR Update_User

--PROFESSOR_GROUP_COURSE
ALTER TABLE  [dbo].[Professor_Course_Group] ADD Creation_Date date
ALTER TABLE  [dbo].[Professor_Course_Group] ADD Creation_User nvarchar(50)
ALTER TABLE  [dbo].[Professor_Course_Group] ADD Update_Date date
ALTER TABLE  [dbo].[Professor_Course_Group] ADD Update_User nvarchar(50)

ALTER TABLE [dbo].[Professor_Course_Group] 
ADD CONSTRAINT DF_Creation_Date_Professor_Course_Group DEFAULT GETDATE() FOR Creation_Date
ALTER TABLE [dbo].[Professor_Course_Group] 
ADD CONSTRAINT DF_Creation_User_Professor_Course_Group DEFAULT 'DBA' FOR Creation_User
ALTER TABLE [dbo].[Professor_Course_Group] 
ADD CONSTRAINT DF_Update_Date_Professor_Course_Group DEFAULT GETDATE() FOR Update_Date
ALTER TABLE [dbo].[Professor_Course_Group] 
ADD CONSTRAINT DF_Update_User_Professor_Course_Group DEFAULT 'DBA' FOR Update_User


--SUDENT_COURSE_GROUP
ALTER TABLE  [dbo].[Student_Course_Group] ADD Creation_Date date
ALTER TABLE  [dbo].[Student_Course_Group] ADD Creation_User nvarchar(50)
ALTER TABLE  [dbo].[Student_Course_Group] ADD Update_Date date
ALTER TABLE  [dbo].[Student_Course_Group] ADD Update_User nvarchar(50)

ALTER TABLE [dbo].[Student_Course_Group] 
ADD CONSTRAINT DF_Creation_Date_Student_Course_Group DEFAULT GETDATE() FOR Creation_Date
ALTER TABLE [dbo].[Student_Course_Group] 
ADD CONSTRAINT DF_Creation_User_Student_Course_Group DEFAULT 'DBA' FOR Creation_User
ALTER TABLE [dbo].[Student_Course_Group] 
ADD CONSTRAINT DF_Update_Date_Student_Course_Group DEFAULT GETDATE() FOR Update_Date
ALTER TABLE [dbo].[Student_Course_Group] 
ADD CONSTRAINT DF_Update_User_Student_Course_Group DEFAULT 'DBA' FOR Update_User


--ACADEMICDEGREE
ALTER TABLE  [dbo].[AcademicDegree] ADD Creation_Date date
ALTER TABLE  [dbo].[AcademicDegree] ADD Creation_User nvarchar(50)
ALTER TABLE  [dbo].[AcademicDegree] ADD Update_Date date
ALTER TABLE  [dbo].[AcademicDegree] ADD Update_User nvarchar(50)

ALTER TABLE [dbo].[AcademicDegree] 
ADD CONSTRAINT DF_Creation_Date_AcademicDegree DEFAULT GETDATE() FOR Creation_Date
ALTER TABLE [dbo].[AcademicDegree] 
ADD CONSTRAINT DF_Creation_User_AcademicDegree DEFAULT 'DBA' FOR Creation_User
ALTER TABLE [dbo].[AcademicDegree] 
ADD CONSTRAINT DF_Update_Date_AcademicDegree DEFAULT GETDATE() FOR Update_Date
ALTER TABLE [dbo].[AcademicDegree] 
ADD CONSTRAINT DF_Update_User_AcademicDegree DEFAULT 'DBA' FOR Update_User

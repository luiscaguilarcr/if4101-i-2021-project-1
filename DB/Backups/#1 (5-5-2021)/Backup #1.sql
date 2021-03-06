USE [master]
GO
/****** Object:  Database [IF4101_2021_SPA]    Script Date: 5/5/2021 23:14:43 ******/
CREATE DATABASE [IF4101_2021_SPA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IF4101_2021_SPA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\IF4101_2021_SPA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'IF4101_2021_SPA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\IF4101_2021_SPA_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [IF4101_2021_SPA] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IF4101_2021_SPA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IF4101_2021_SPA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET ARITHABORT OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IF4101_2021_SPA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IF4101_2021_SPA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IF4101_2021_SPA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IF4101_2021_SPA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [IF4101_2021_SPA] SET  MULTI_USER 
GO
ALTER DATABASE [IF4101_2021_SPA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IF4101_2021_SPA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IF4101_2021_SPA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IF4101_2021_SPA] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [IF4101_2021_SPA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [IF4101_2021_SPA] SET QUERY_STORE = OFF
GO
USE [IF4101_2021_SPA]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [IF4101_2021_SPA]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 5/5/2021 23:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](6) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Credits] [int] NOT NULL,
	[Semester] [int] NOT NULL,
	[Creation_Date] [date] NULL,
	[Creation_User] [nvarchar](50) NULL,
	[Update_Date] [date] NULL,
	[Update_User] [nvarchar](50) NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 5/5/2021 23:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](3) NOT NULL,
	[Course_Id] [int] NOT NULL,
	[Creation_Date] [date] NULL,
	[Creation_User] [nvarchar](50) NULL,
	[Update_Date] [date] NULL,
	[Update_User] [nvarchar](50) NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professor]    Script Date: 5/5/2021 23:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nchar](6) NOT NULL,
	[Name] [nchar](100) NOT NULL,
	[Email] [nchar](100) NOT NULL,
	[AcademicDegree_Id] [int] NOT NULL,
	[Creation_Date] [date] NULL,
	[Creation_User] [nvarchar](50) NULL,
	[Update_Date] [date] NULL,
	[Update_User] [nvarchar](50) NULL,
 CONSTRAINT [PK_Professor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professor_Course_Group]    Script Date: 5/5/2021 23:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor_Course_Group](
	[Professor_Id] [int] NOT NULL,
	[Course_Id] [int] NOT NULL,
	[Gorup_Id] [int] NOT NULL,
	[Creation_Date] [date] NULL,
	[Creation_User] [nvarchar](50) NULL,
	[Update_Date] [date] NULL,
	[Update_User] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/5/2021 23:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](6) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Date_Birth] [date] NOT NULL,
	[Sex] [nvarchar](13) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[Creation_Date] [date] NULL,
	[Creation_User] [nvarchar](50) NULL,
	[Update_Date] [date] NULL,
	[Update_User] [nvarchar](50) NULL,
 CONSTRAINT [PK_Student_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Course_Group]    Script Date: 5/5/2021 23:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Course_Group](
	[Student_Id] [int] NOT NULL,
	[Course_Id] [int] NOT NULL,
	[Group_Id] [int] NOT NULL,
	[Creation_Date] [date] NULL,
	[Creation_User] [nvarchar](50) NULL,
	[Update_Date] [date] NULL,
	[Update_User] [nvarchar](50) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Creation_Date_Course]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Creation_User_Course]  DEFAULT (getdate()) FOR [Creation_User]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Update_Date_Course]  DEFAULT ('DBA') FOR [Update_Date]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Update_User_Course]  DEFAULT ('DBA') FOR [Update_User]
GO
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Creation_Date_Group]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Creation_User_Group]  DEFAULT (getdate()) FOR [Creation_User]
GO
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Update_Date_Group]  DEFAULT ('DBA') FOR [Update_Date]
GO
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Update_User_Group]  DEFAULT ('DBA') FOR [Update_User]
GO
ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [DF_Creation_Date_Professor]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [DF_Creation_User_Professor]  DEFAULT (getdate()) FOR [Creation_User]
GO
ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [DF_Update_Date_Professor]  DEFAULT ('DBA') FOR [Update_Date]
GO
ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [DF_Update_User_Professor]  DEFAULT ('DBA') FOR [Update_User]
GO
ALTER TABLE [dbo].[Professor_Course_Group] ADD  CONSTRAINT [DF_Creation_Date_Professor_Course_Group]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Professor_Course_Group] ADD  CONSTRAINT [DF_Creation_User_Professor_Course_Group]  DEFAULT (getdate()) FOR [Creation_User]
GO
ALTER TABLE [dbo].[Professor_Course_Group] ADD  CONSTRAINT [DF_Update_Date_Professor_Course_Group]  DEFAULT ('DBA') FOR [Update_Date]
GO
ALTER TABLE [dbo].[Professor_Course_Group] ADD  CONSTRAINT [DF_Update_User_Professor_Course_Group]  DEFAULT ('DBA') FOR [Update_User]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Creation_Date_Student]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Creation_User_Student]  DEFAULT (getdate()) FOR [Creation_User]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Update_Date_Student]  DEFAULT ('DBA') FOR [Update_Date]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Update_User_Student]  DEFAULT ('DBA') FOR [Update_User]
GO
ALTER TABLE [dbo].[Student_Course_Group] ADD  CONSTRAINT [DF_Creation_Date_Student_Course_Group]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Student_Course_Group] ADD  CONSTRAINT [DF_Creation_User_Student_Course_Group]  DEFAULT (getdate()) FOR [Creation_User]
GO
ALTER TABLE [dbo].[Student_Course_Group] ADD  CONSTRAINT [DF_Update_Date_Student_Course_Group]  DEFAULT ('DBA') FOR [Update_Date]
GO
ALTER TABLE [dbo].[Student_Course_Group] ADD  CONSTRAINT [DF_Update_User_Student_Course_Group]  DEFAULT ('DBA') FOR [Update_User]
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_Course] FOREIGN KEY([Course_Id])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_Course]
GO
ALTER TABLE [dbo].[Professor_Course_Group]  WITH CHECK ADD  CONSTRAINT [FK_Professor_Course_Course] FOREIGN KEY([Course_Id])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[Professor_Course_Group] CHECK CONSTRAINT [FK_Professor_Course_Course]
GO
ALTER TABLE [dbo].[Professor_Course_Group]  WITH CHECK ADD  CONSTRAINT [FK_Professor_Course_Group_Group] FOREIGN KEY([Gorup_Id])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[Professor_Course_Group] CHECK CONSTRAINT [FK_Professor_Course_Group_Group]
GO
ALTER TABLE [dbo].[Professor_Course_Group]  WITH CHECK ADD  CONSTRAINT [FK_Professor_Course_Professor] FOREIGN KEY([Professor_Id])
REFERENCES [dbo].[Professor] ([Id])
GO
ALTER TABLE [dbo].[Professor_Course_Group] CHECK CONSTRAINT [FK_Professor_Course_Professor]
GO
ALTER TABLE [dbo].[Student_Course_Group]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course_Group_Course] FOREIGN KEY([Course_Id])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[Student_Course_Group] CHECK CONSTRAINT [FK_Student_Course_Group_Course]
GO
ALTER TABLE [dbo].[Student_Course_Group]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course_Group_Group] FOREIGN KEY([Group_Id])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[Student_Course_Group] CHECK CONSTRAINT [FK_Student_Course_Group_Group]
GO
ALTER TABLE [dbo].[Student_Course_Group]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course_Group_Student] FOREIGN KEY([Student_Id])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[Student_Course_Group] CHECK CONSTRAINT [FK_Student_Course_Group_Student]
GO
USE [master]
GO
ALTER DATABASE [IF4101_2021_SPA] SET  READ_WRITE 
GO

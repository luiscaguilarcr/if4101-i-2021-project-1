USE [master]
GO
/****** Object:  Database [IF4101_2021_SPA]    Script Date: 9/5/2021 01:19:04 ******/
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
/****** Object:  Table [dbo].[AcademicDegree]    Script Date: 9/5/2021 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcademicDegree](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Degree] [nvarchar](6) NOT NULL,
	[Creation_Date] [date] NOT NULL,
	[Creation_User] [nvarchar](50) NOT NULL,
	[Update_Date] [date] NOT NULL,
	[Update_User] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AcademicDegree] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 9/5/2021 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](6) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Credits] [int] NOT NULL,
	[Semester] [nvarchar](3) NOT NULL,
	[Year] [int] NOT NULL,
	[Creation_Date] [datetime] NOT NULL,
	[Creation_User] [nvarchar](50) NOT NULL,
	[Update_Date] [datetime] NOT NULL,
	[Update_User] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 9/5/2021 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](3) NOT NULL,
	[Course_Id] [int] NOT NULL,
	[Creation_Date] [datetime] NOT NULL,
	[Creation_User] [nvarchar](50) NOT NULL,
	[Update_Date] [datetime] NOT NULL,
	[Update_User] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professor]    Script Date: 9/5/2021 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nchar](6) NOT NULL,
	[Name] [nchar](100) NOT NULL,
	[Email] [nchar](100) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[AcademicDegree_Id] [int] NOT NULL,
	[Creation_Date] [datetime] NOT NULL,
	[Creation_User] [nvarchar](50) NOT NULL,
	[Update_Date] [datetime] NOT NULL,
	[Update_User] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Professor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professor_Course_Group]    Script Date: 9/5/2021 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor_Course_Group](
	[Professor_Id] [int] NOT NULL,
	[Course_Id] [int] NOT NULL,
	[Gorup_Id] [int] NOT NULL,
	[Creation_Date] [datetime] NOT NULL,
	[Creation_User] [nvarchar](50) NOT NULL,
	[Update_Date] [datetime] NOT NULL,
	[Update_User] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 9/5/2021 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](6) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[Creation_Date] [datetime] NOT NULL,
	[Creation_User] [nvarchar](50) NOT NULL,
	[Update_Date] [datetime] NOT NULL,
	[Update_User] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Student_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Course_Group]    Script Date: 9/5/2021 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Course_Group](
	[Student_Id] [int] NOT NULL,
	[Course_Id] [int] NOT NULL,
	[Group_Id] [int] NOT NULL,
	[Creation_Date] [datetime] NOT NULL,
	[Creation_User] [nvarchar](50) NOT NULL,
	[Update_Date] [datetime] NOT NULL,
	[Update_User] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (3, N'IF4101', N'LENGUAJES PARA APLICACIONES COMERCIALES', 4, N'I', 2021, CAST(N'2021-05-08T23:20:43.550' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:20:43.550' AS DateTime), N'Superadmin')
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (4, N'IF1300', N'INTRODUCCIÓN A LA COMPUTACIÓN E INFORMÁTICA', 4, N'I', 2021, CAST(N'2021-05-08T23:31:49.617' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:31:49.617' AS DateTime), N'Superadmin')
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (5, N'IF1400', N'LÓGICA PARA INFORMÁTICOS', 2, N'I', 2021, CAST(N'2021-05-08T23:32:11.703' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:32:11.703' AS DateTime), N'Superadmin')
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (6, N'IF2000', N'PROGRAMACIÓN I', 4, N'I', 2021, CAST(N'2021-05-08T23:32:57.960' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:32:57.960' AS DateTime), N'Superadmin')
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (7, N'IF3000', N'PROGRAMACIÓN II', 4, N'II', 2021, CAST(N'2021-05-08T23:35:07.497' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:35:07.497' AS DateTime), N'Superadmin')
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (8, N'IF3001', N'ALGORITMOS Y ESTRUCTURAS DE DATOS', 4, N'I', 2021, CAST(N'2021-05-08T23:35:26.120' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:35:26.120' AS DateTime), N'Superadmin')
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (9, N'IF3100', N'INTRODUCCIÓN A SISTEMAS DE INFORMACIÓN', 3, N'I', 2021, CAST(N'2021-05-08T23:35:49.323' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:35:49.323' AS DateTime), N'Superadmin')
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (10, N'IF4000', N'ARQUITECTURA DE COMPUTADORES', 3, N'II', 2021, CAST(N'2021-05-08T23:36:14.293' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:36:14.293' AS DateTime), N'Superadmin')
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (11, N'IF4001', N'SISTEMAS OPERATIVOS', 4, N'II', 2021, CAST(N'2021-05-08T23:36:40.810' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:36:40.810' AS DateTime), N'Superadmin')
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (12, N'IF4100', N'FUNDAMENTOS DE BASES DE DATOS', 4, N'II', 2021, CAST(N'2021-05-08T23:38:30.810' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:38:30.810' AS DateTime), N'Superadmin')
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (13, N'IF5200', N'FUNDAMENTOS DE LAS ORGANIZACIONES', 3, N'II', 2021, CAST(N'2021-05-08T23:38:53.233' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:38:53.233' AS DateTime), N'Superadmin')
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (1, N'021', 3, CAST(N'2021-05-08T23:44:01.757' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:44:01.757' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (2, N'061', 3, CAST(N'2021-05-08T23:46:26.557' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:46:26.557' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (3, N'061', 4, CAST(N'2021-05-08T23:46:50.010' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:46:50.010' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (4, N'021', 4, CAST(N'2021-05-08T23:47:11.057' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:47:11.057' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (5, N'021', 5, CAST(N'2021-05-08T23:47:23.790' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:47:23.790' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (6, N'061', 5, CAST(N'2021-05-08T23:47:27.993' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:47:27.993' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (7, N'021', 6, CAST(N'2021-05-08T23:47:34.727' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:47:34.727' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (9, N'061', 6, CAST(N'2021-05-08T23:49:35.277' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:49:35.277' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (10, N'021', 7, CAST(N'2021-05-08T23:49:52.323' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:49:52.323' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (11, N'061', 7, CAST(N'2021-05-08T23:49:57.200' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:49:57.200' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (12, N'021', 8, CAST(N'2021-05-08T23:50:07.387' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:50:07.387' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (13, N'061', 8, CAST(N'2021-05-08T23:50:11.870' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:50:11.870' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (14, N'021', 9, CAST(N'2021-05-08T23:50:28.467' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:50:28.467' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (15, N'061', 9, CAST(N'2021-05-08T23:50:34.013' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:50:34.013' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (16, N'021', 10, CAST(N'2021-05-08T23:50:39.233' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:50:39.233' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (17, N'061', 10, CAST(N'2021-05-08T23:50:42.233' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:50:42.233' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (18, N'021', 11, CAST(N'2021-05-08T23:51:44.890' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:51:44.890' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (19, N'061', 11, CAST(N'2021-05-08T23:51:48.250' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:51:48.250' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (20, N'021', 12, CAST(N'2021-05-08T23:51:55.190' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:51:55.190' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (21, N'061', 12, CAST(N'2021-05-08T23:51:57.500' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:51:57.500' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (22, N'021', 13, CAST(N'2021-05-08T23:52:03.300' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:52:03.300' AS DateTime), N'Superadmin')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (23, N'061', 13, CAST(N'2021-05-08T23:52:06.750' AS DateTime), N'Superadmin', CAST(N'2021-05-08T23:52:06.750' AS DateTime), N'Superadmin')
SET IDENTITY_INSERT [dbo].[Group] OFF
GO
SET IDENTITY_INSERT [dbo].[Professor] ON 

INSERT [dbo].[Professor] ([Id], [Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (1, N'442424', N'MANUEL CHAMORRO MAYORAL                                                                             ', N'manuel.chamorro@ucr.ac.cr                                                                           ', N'PiWYSPi2V85RR', 2, CAST(N'2021-05-09T00:13:11.673' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:13:11.673' AS DateTime), N'Superadmin')
INSERT [dbo].[Professor] ([Id], [Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (2, N'487945', N'DOMINGO ZAMBRANA VIÑA                                                                               ', N'domingo.zambrana@ucr.ac.cr                                                                          ', N'gwahSTODnVXqy', 1, CAST(N'2021-05-09T00:13:50.173' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:13:50.173' AS DateTime), N'Superadmin')
INSERT [dbo].[Professor] ([Id], [Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (3, N'431232', N'VICTOR MANUEL MURIEL SALDAÑA                                                                        ', N'victormanuel.muriel@ucr.ac.cr                                                                       ', N'Ubjj3KS3J8ani', 3, CAST(N'2021-05-09T00:14:17.237' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:14:17.237' AS DateTime), N'Superadmin')
INSERT [dbo].[Professor] ([Id], [Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (4, N'499472', N'GABRIEL FERNANDEZ MALAGON                                                                           ', N'gabriel.fernandez@ucr.ac.cr                                                                         ', N'pLBsZeceLHf3N', 3, CAST(N'2021-05-09T00:15:15.643' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:15:15.643' AS DateTime), N'Superadmin')
INSERT [dbo].[Professor] ([Id], [Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (5, N'455373', N'LUCIA SOLIS RISCO                                                                                   ', N'lucia.solis@ucr.ac.cr                                                                               ', N'd2fimYx8fmqhd', 1, CAST(N'2021-05-09T00:15:42.783' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:15:42.783' AS DateTime), N'Superadmin')
INSERT [dbo].[Professor] ([Id], [Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (6, N'435346', N'LORENA ALCAIDE ROSELL                                                                               ', N'lorena.alcaide@ucr.ac.cr                                                                            ', N'Q5AeMYtfAC96x', 1, CAST(N'2021-05-09T00:16:22.443' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:16:22.443' AS DateTime), N'Superadmin')
INSERT [dbo].[Professor] ([Id], [Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (7, N'432124', N'GONZALO TOME GUTIERREZ                                                                              ', N'gonzalo.tome@ucr.ac.cr                                                                              ', N'vfmbXm6VLFa3J', 2, CAST(N'2021-05-09T00:17:16.023' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:17:16.023' AS DateTime), N'Superadmin')
INSERT [dbo].[Professor] ([Id], [Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (8, N'496434', N'MARIA JOSE LOIS CURIEL                                                                              ', N'mariajose.lois@ucr.ac.cr                                                                            ', N'4jOaF43btc9CQ', 2, CAST(N'2021-05-09T00:19:27.103' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:19:27.103' AS DateTime), N'Superadmin')
SET IDENTITY_INSERT [dbo].[Professor] OFF
GO
INSERT [dbo].[Professor_Course_Group] ([Professor_Id], [Course_Id], [Gorup_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (1, 3, 1, CAST(N'2021-05-09T00:46:44.137' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:46:44.137' AS DateTime), N'Superadmin')
INSERT [dbo].[Professor_Course_Group] ([Professor_Id], [Course_Id], [Gorup_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (1, 3, 2, CAST(N'2021-05-09T00:50:32.170' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:50:32.170' AS DateTime), N'Superadmin')
INSERT [dbo].[Professor_Course_Group] ([Professor_Id], [Course_Id], [Gorup_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (2, 4, 1, CAST(N'2021-05-09T00:50:45.373' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:50:45.373' AS DateTime), N'Superadmin')
INSERT [dbo].[Professor_Course_Group] ([Professor_Id], [Course_Id], [Gorup_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (3, 4, 2, CAST(N'2021-05-09T00:51:03.063' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:51:03.063' AS DateTime), N'Superadmin')
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (1, N'B88372', N'BEATRIZ POLANCO CLAVIJO', N'beatriz.polanco@ucr.ac.cr', N'wLOKfr!Uhfwc', CAST(N'2021-05-09T00:27:23.397' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:27:23.397' AS DateTime), N'Superadmin')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (2, N'B33422', N'INMACULADA PLATA VICO', N'inmaculada.plata@ucr.ac.cr', N'90n5#Z253X1t', CAST(N'2021-05-09T00:29:16.777' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:29:16.777' AS DateTime), N'Superadmin')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (3, N'B83716', N'IVAN REYES PINO', N'ivan.reyes@ucr.ac.cr', N'VRgr7yhqCk', CAST(N'2021-05-09T00:30:04.247' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:30:04.247' AS DateTime), N'Superadmin')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (4, N'B34231', N'JOSE IGNACIO GAMARRA RICO', N'jodeignacio.gamarra@ucr.ac.cr', N'K5xHFpwLepaND', CAST(N'2021-05-09T00:31:17.673' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:31:17.673' AS DateTime), N'Superadmin')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (5, N'B17421', N'FELIX MONZO ZAPATERO', N'felix.monzo@ucr.ac.cr', N'NbvMKk7GATZLM', CAST(N'2021-05-09T00:31:55.517' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:31:55.517' AS DateTime), N'Superadmin')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (6, N'B53221', N'JUANA VIVAS QUIÑONES', N'juana.vivas@ucr.ac.cr', N'bE1nQkNmYyGem', CAST(N'2021-05-09T00:32:39.317' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:32:39.317' AS DateTime), N'Superadmin')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (7, N'B54355', N'MARINA UGARTE REGUEIRO', N'mariana.ugarte@ucr.ac.cr', N'4YlLG574ZSK5q', CAST(N'2021-05-09T00:33:09.847' AS DateTime), N'Superadmin', CAST(N'2021-05-09T00:33:09.847' AS DateTime), N'Superadmin')
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
ALTER TABLE [dbo].[AcademicDegree] ADD  CONSTRAINT [DF_Creation_Date_AcademicDegree]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[AcademicDegree] ADD  CONSTRAINT [DF_Creation_User_AcademicDegree]  DEFAULT ('DBA') FOR [Creation_User]
GO
ALTER TABLE [dbo].[AcademicDegree] ADD  CONSTRAINT [DF_Update_Date_AcademicDegree]  DEFAULT (getdate()) FOR [Update_Date]
GO
ALTER TABLE [dbo].[AcademicDegree] ADD  CONSTRAINT [DF_Update_User_AcademicDegree]  DEFAULT ('DBA') FOR [Update_User]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Creation_Date_Course]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Creation_User_Course]  DEFAULT (getdate()) FOR [Creation_User]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Update_Date_Course]  DEFAULT (getdate()) FOR [Update_Date]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Update_User_Course]  DEFAULT ('DBA') FOR [Update_User]
GO
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Creation_Date_Group]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Creation_User_Group]  DEFAULT (getdate()) FOR [Creation_User]
GO
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Update_Date_Group]  DEFAULT (getdate()) FOR [Update_Date]
GO
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Update_User_Group]  DEFAULT ('DBA') FOR [Update_User]
GO
ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [DF_Creation_Date_Professor]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [DF_Creation_User_Professor]  DEFAULT (getdate()) FOR [Creation_User]
GO
ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [DF_Update_Date_Professor]  DEFAULT (getdate()) FOR [Update_Date]
GO
ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [DF_Update_User_Professor]  DEFAULT ('DBA') FOR [Update_User]
GO
ALTER TABLE [dbo].[Professor_Course_Group] ADD  CONSTRAINT [DF_Creation_Date_Professor_Course_Group]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Professor_Course_Group] ADD  CONSTRAINT [DF_Creation_User_Professor_Course_Group]  DEFAULT (getdate()) FOR [Creation_User]
GO
ALTER TABLE [dbo].[Professor_Course_Group] ADD  CONSTRAINT [DF_Update_Date_Professor_Course_Group]  DEFAULT (getdate()) FOR [Update_Date]
GO
ALTER TABLE [dbo].[Professor_Course_Group] ADD  CONSTRAINT [DF_Update_User_Professor_Course_Group]  DEFAULT ('DBA') FOR [Update_User]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Creation_Date_Student]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Creation_User_Student]  DEFAULT (getdate()) FOR [Creation_User]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Update_Date_Student]  DEFAULT (getdate()) FOR [Update_Date]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Update_User_Student]  DEFAULT ('DBA') FOR [Update_User]
GO
ALTER TABLE [dbo].[Student_Course_Group] ADD  CONSTRAINT [DF_Creation_Date_Student_Course_Group]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Student_Course_Group] ADD  CONSTRAINT [DF_Creation_User_Student_Course_Group]  DEFAULT (getdate()) FOR [Creation_User]
GO
ALTER TABLE [dbo].[Student_Course_Group] ADD  CONSTRAINT [DF_Update_Date_Student_Course_Group]  DEFAULT (getdate()) FOR [Update_Date]
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

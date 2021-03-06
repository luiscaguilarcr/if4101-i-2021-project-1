USE [master]
GO
/****** Object:  Database [IF4101_2021_SPA]    Script Date: 27/5/2021 04:52:46 ******/
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
/****** Object:  Table [dbo].[Admin]    Script Date: 27/5/2021 04:52:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](6) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[AcademicDegree_Id] [int] NOT NULL,
	[Creation_Date] [date] NOT NULL,
	[Creation_User] [nvarchar](50) NOT NULL,
	[Update_Date] [date] NOT NULL,
	[Update_User] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointment_Attendance]    Script Date: 27/5/2021 04:52:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment_Attendance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Attendance_Id] [int] NOT NULL,
	[Start_Date_Hour] [date] NOT NULL,
	[End_Date_Hour] [date] NOT NULL,
	[Student_Id] [int] NOT NULL,
	[Professor_Id] [int] NOT NULL,
	[Group_Id] [int] NOT NULL,
	[Course_Id] [int] NOT NULL,
 CONSTRAINT [PK_Appointment_Attendance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attendance_Professor_Course_Group]    Script Date: 27/5/2021 04:52:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance_Professor_Course_Group](
	[Attendance_Schedule_Id] [int] NOT NULL,
	[Group_Id] [int] NOT NULL,
	[Professor_Id] [int] NOT NULL,
	[Course_Id] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Attendance_Professor_Course_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttendanceSchedule]    Script Date: 27/5/2021 04:52:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttendanceSchedule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Start_Date_Hour] [int] NOT NULL,
	[End_Date_Hour] [int] NOT NULL,
 CONSTRAINT [PK_AttendanceSchedule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 27/5/2021 04:52:46 ******/
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
/****** Object:  Table [dbo].[Group]    Script Date: 27/5/2021 04:52:46 ******/
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
/****** Object:  Table [dbo].[Message]    Script Date: 27/5/2021 04:52:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Id] [int] NOT NULL,
	[Text] [nvarchar](200) NOT NULL,
	[Creation_Date] [date] NOT NULL,
	[Creation_User] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professor]    Script Date: 27/5/2021 04:52:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](6) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
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
/****** Object:  Table [dbo].[Professor_Course_Group]    Script Date: 27/5/2021 04:52:46 ******/
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
/****** Object:  Table [dbo].[Student]    Script Date: 27/5/2021 04:52:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](6) NOT NULL,
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
/****** Object:  Table [dbo].[Student_Course_Group]    Script Date: 27/5/2021 04:52:46 ******/
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
/****** Object:  Table [dbo].[TemporalAppointment_Attendance]    Script Date: 27/5/2021 04:52:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TemporalAppointment_Attendance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Attendance_Id] [int] NOT NULL,
	[Start_Date_Hour] [date] NOT NULL,
	[End_Date_Hour] [date] NOT NULL,
	[Student_Id] [int] NOT NULL,
	[Professor_Id] [int] NOT NULL,
	[Group_Id] [int] NOT NULL,
	[Course_Id] [int] NOT NULL,
 CONSTRAINT [PK_TemporalAppointment_Attendance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TemporalStudent]    Script Date: 27/5/2021 04:52:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TemporalStudent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](6) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Temporal_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([Id], [Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (1, N'admin', N'JOSE LOIS CURIEL MORAT                                                                              ', N'joselois.morat@ucr.ac.cr                                                                            ', N'admin', 2, CAST(N'2021-05-24' AS Date), N'Superadmin', CAST(N'2021-05-24' AS Date), N'Superadmin')
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (7, N'IF3000', N'PROGRAMACIÓN II', 4, N'II', 2021, CAST(N'2021-05-08T23:35:07.497' AS DateTime), N'DBA', CAST(N'2021-05-08T23:35:07.497' AS DateTime), N'DBA')
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (8, N'IF3001', N'ALGORITMOS Y ESTRUCTURAS DE DATOS', 4, N'I', 2021, CAST(N'2021-05-08T23:35:26.120' AS DateTime), N'DBA', CAST(N'2021-05-08T23:35:26.120' AS DateTime), N'DBA')
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (9, N'IF3100', N'INTRODUCCIÓN A SISTEMAS DE INFORMACIÓN', 3, N'I', 2021, CAST(N'2021-05-08T23:35:49.323' AS DateTime), N'DBA', CAST(N'2021-05-08T23:35:49.323' AS DateTime), N'DBA')
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (10, N'IF4000', N'ARQUITECTURA DE COMPUTADORES', 3, N'II', 2021, CAST(N'2021-05-08T23:36:14.293' AS DateTime), N'DBA', CAST(N'2021-05-08T23:36:14.293' AS DateTime), N'DBA')
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (11, N'IF4001', N'SISTEMAS OPERATIVOS', 4, N'II', 2021, CAST(N'2021-05-08T23:36:40.810' AS DateTime), N'DBA', CAST(N'2021-05-08T23:36:40.810' AS DateTime), N'DBA')
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (12, N'IF4100', N'FUNDAMENTOS DE BASES DE DATOS', 4, N'II', 2021, CAST(N'2021-05-08T23:38:30.810' AS DateTime), N'DBA', CAST(N'2021-05-08T23:38:30.810' AS DateTime), N'DBA')
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (13, N'IF5200', N'FUNDAMENTOS DE LAS ORGANIZACIONES', 3, N'II', 2021, CAST(N'2021-05-08T23:38:53.233' AS DateTime), N'DBA', CAST(N'2021-05-08T23:38:53.233' AS DateTime), N'DBA')
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (45, N'B782', N'Logica', 2, N'1', 1, CAST(N'2021-05-26T18:32:22.343' AS DateTime), N'DBA', CAST(N'2021-05-26T18:32:22.343' AS DateTime), N'DBA')
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credits], [Semester], [Year], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (46, N'IF2002', N'Introduccion a los sistemas', 4, N'3', 2, CAST(N'2021-05-26T20:00:14.117' AS DateTime), N'DBA', CAST(N'2021-05-26T20:00:14.117' AS DateTime), N'DBA')
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (10, N'021', 7, CAST(N'2021-05-08T23:49:52.323' AS DateTime), N'DBA', CAST(N'2021-05-08T23:49:52.323' AS DateTime), N'DBA')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (11, N'061', 7, CAST(N'2021-05-08T23:49:57.200' AS DateTime), N'DBA', CAST(N'2021-05-08T23:49:57.200' AS DateTime), N'DBA')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (12, N'021', 8, CAST(N'2021-05-08T23:50:07.387' AS DateTime), N'DBA', CAST(N'2021-05-08T23:50:07.387' AS DateTime), N'DBA')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (13, N'061', 8, CAST(N'2021-05-08T23:50:11.870' AS DateTime), N'DBA', CAST(N'2021-05-08T23:50:11.870' AS DateTime), N'DBA')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (14, N'021', 9, CAST(N'2021-05-08T23:50:28.467' AS DateTime), N'DBA', CAST(N'2021-05-08T23:50:28.467' AS DateTime), N'DBA')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (15, N'061', 9, CAST(N'2021-05-08T23:50:34.013' AS DateTime), N'DBA', CAST(N'2021-05-08T23:50:34.013' AS DateTime), N'DBA')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (16, N'021', 10, CAST(N'2021-05-08T23:50:39.233' AS DateTime), N'DBA', CAST(N'2021-05-08T23:50:39.233' AS DateTime), N'DBA')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (17, N'061', 10, CAST(N'2021-05-08T23:50:42.233' AS DateTime), N'DBA', CAST(N'2021-05-08T23:50:42.233' AS DateTime), N'DBA')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (18, N'021', 11, CAST(N'2021-05-08T23:51:44.890' AS DateTime), N'DBA', CAST(N'2021-05-08T23:51:44.890' AS DateTime), N'DBA')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (19, N'061', 11, CAST(N'2021-05-08T23:51:48.250' AS DateTime), N'DBA', CAST(N'2021-05-08T23:51:48.250' AS DateTime), N'DBA')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (20, N'021', 12, CAST(N'2021-05-08T23:51:55.190' AS DateTime), N'DBA', CAST(N'2021-05-08T23:51:55.190' AS DateTime), N'DBA')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (21, N'061', 12, CAST(N'2021-05-08T23:51:57.500' AS DateTime), N'DBA', CAST(N'2021-05-08T23:51:57.500' AS DateTime), N'DBA')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (22, N'021', 13, CAST(N'2021-05-08T23:52:03.300' AS DateTime), N'DBA', CAST(N'2021-05-08T23:52:03.300' AS DateTime), N'DBA')
INSERT [dbo].[Group] ([Id], [Code], [Course_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (23, N'061', 13, CAST(N'2021-05-08T23:52:06.750' AS DateTime), N'DBA', CAST(N'2021-05-08T23:52:06.750' AS DateTime), N'DBA')
SET IDENTITY_INSERT [dbo].[Group] OFF
GO
SET IDENTITY_INSERT [dbo].[Professor] ON 

INSERT [dbo].[Professor] ([Id], [Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (1, N'442424', N'MANUEL CHAMORRO MAYORAL                                                                             ', N'manuel.chamorro@ucr.ac.cr                                                                           ', N'PiWYSPi2V85RR', 2, CAST(N'2021-05-09T00:13:11.673' AS DateTime), N'DBA', CAST(N'2021-05-09T00:13:11.673' AS DateTime), N'DBA')
INSERT [dbo].[Professor] ([Id], [Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (2, N'487945', N'DOMINGO ZAMBRANA VIÑA                                                                               ', N'domingo.zambrana@ucr.ac.cr                                                                          ', N'gwahSTODnVXqy', 1, CAST(N'2021-05-09T00:13:50.173' AS DateTime), N'DBA', CAST(N'2021-05-09T00:13:50.173' AS DateTime), N'DBA')
INSERT [dbo].[Professor] ([Id], [Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (3, N'431232', N'VICTOR MANUEL MURIEL SAL                                                                     ', N'victormanuel.muriel@ucr.ac.cr                                                                       ', N'Ubjj3KS3J8ani', 0, CAST(N'2021-05-09T00:14:17.237' AS DateTime), N'DBA', CAST(N'2021-05-09T00:14:17.237' AS DateTime), N'431232')
INSERT [dbo].[Professor] ([Id], [Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (4, N'499472', N'GABRIEL FERNANDEZ MALAGON                                                                           ', N'gabriel.fernandez@ucr.ac.cr                                                                         ', N'pLBsZeceLHf3N', 3, CAST(N'2021-05-09T00:15:15.643' AS DateTime), N'DBA', CAST(N'2021-05-09T00:15:15.643' AS DateTime), N'DBA')
INSERT [dbo].[Professor] ([Id], [Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (7, N'432124', N'GONZALO TOME GUTIERREZ                                                                              ', N'gonzalo.tome@ucr.ac.cr                                                                              ', N'vfmbXm6VLFa3J', 2, CAST(N'2021-05-09T00:17:16.023' AS DateTime), N'DBA', CAST(N'2021-05-09T00:17:16.023' AS DateTime), N'DBA')
INSERT [dbo].[Professor] ([Id], [Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (15, N'GH8796', N'Gabriela Araya', N'racheltindelaraya@gmail.com', N'hodhc785', 2, CAST(N'2021-05-26T19:36:53.363' AS DateTime), N'DBA', CAST(N'2021-05-26T19:36:53.363' AS DateTime), N'DBA')
INSERT [dbo].[Professor] ([Id], [Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (16, N'B91882', N'Luis', N'luis11@hotmail.es', N'bIULtQ9f6x6l', 1, CAST(N'2021-05-27T02:27:13.783' AS DateTime), N'DBA', CAST(N'2021-05-27T02:27:13.783' AS DateTime), N'DBA')
INSERT [dbo].[Professor] ([Id], [Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (17, N'1', N'P', N'2', N'1', 1, CAST(N'2021-05-27T02:30:41.333' AS DateTime), N'DBA', CAST(N'2021-05-27T02:30:41.333' AS DateTime), N'DBA')
INSERT [dbo].[Professor] ([Id], [Code], [Name], [Email], [Password], [AcademicDegree_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (18, N'2', N'1', N'1', N'', 2, CAST(N'2021-05-27T02:30:52.320' AS DateTime), N'DBA', CAST(N'2021-05-27T02:30:52.320' AS DateTime), N'DBA')
SET IDENTITY_INSERT [dbo].[Professor] OFF
GO
INSERT [dbo].[Professor_Course_Group] ([Professor_Id], [Course_Id], [Gorup_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (1, 3, 1, CAST(N'2021-05-09T00:46:44.137' AS DateTime), N'DBA', CAST(N'2021-05-09T00:46:44.137' AS DateTime), N'DBA')
INSERT [dbo].[Professor_Course_Group] ([Professor_Id], [Course_Id], [Gorup_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (1, 3, 2, CAST(N'2021-05-09T00:50:32.170' AS DateTime), N'DBA', CAST(N'2021-05-09T00:50:32.170' AS DateTime), N'DBA')
INSERT [dbo].[Professor_Course_Group] ([Professor_Id], [Course_Id], [Gorup_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (2, 4, 1, CAST(N'2021-05-09T00:50:45.373' AS DateTime), N'DBA', CAST(N'2021-05-09T00:50:45.373' AS DateTime), N'DBA')
INSERT [dbo].[Professor_Course_Group] ([Professor_Id], [Course_Id], [Gorup_Id], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (3, 4, 2, CAST(N'2021-05-09T00:51:03.063' AS DateTime), N'DBA', CAST(N'2021-05-09T00:51:03.063' AS DateTime), N'DBA')
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (5, N'B17421', N'FELIX MONZA ZAPATERO', N'felix.monzo@ucr.ac.cr', N'NbvMKk7GATZLM', CAST(N'2021-05-09T00:31:55.517' AS DateTime), N'DBA', CAST(N'2021-05-09T00:31:55.517' AS DateTime), N'B17421')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (7, N'B54355', N'MARINA UGARTE REGUEIRO', N'mariana.ugarte@ucr.ac.cr', N'4YlLG574ZSK5q', CAST(N'2021-05-09T00:33:09.847' AS DateTime), N'DBA', CAST(N'2021-05-09T00:33:09.847' AS DateTime), N'DBA')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (44, N'B98295', N'jesus', N'jesus@hotmail.com', N'hola', CAST(N'2021-05-24T10:54:15.660' AS DateTime), N'DBA', CAST(N'2021-05-24T10:54:15.660' AS DateTime), N'DBA')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (48, N'B39093', N'Luis', N'luis11@hotmail.es', N'1234', CAST(N'2021-05-24T20:46:53.877' AS DateTime), N'DBA', CAST(N'2021-05-24T20:46:53.877' AS DateTime), N'DBA')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (49, N'B39093', N'Luis', N'luis11@hotmail.es', N'1234', CAST(N'2021-05-24T21:49:30.180' AS DateTime), N'DBA', CAST(N'2021-05-24T21:49:30.180' AS DateTime), N'DBA')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (50, N'B39093', N'Luis', N'luis11@hotmail.es', N'1234', CAST(N'2021-05-24T22:03:54.643' AS DateTime), N'DBA', CAST(N'2021-05-24T22:03:54.643' AS DateTime), N'DBA')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (51, N'B39093', N'Luis', N'luis11@hotmail.es', N'1234', CAST(N'2021-05-24T22:05:43.877' AS DateTime), N'DBA', CAST(N'2021-05-24T22:05:43.877' AS DateTime), N'DBA')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (52, N'B39093', N'Luis', N'luis11@hotmail.es', N'1234', CAST(N'2021-05-24T22:07:04.573' AS DateTime), N'DBA', CAST(N'2021-05-24T22:07:04.573' AS DateTime), N'DBA')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (53, N'B39093', N'Luis', N'luis11@hotmail.es', N'1234', CAST(N'2021-05-24T22:10:00.327' AS DateTime), N'DBA', CAST(N'2021-05-24T22:10:00.327' AS DateTime), N'DBA')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (55, N'b98295', N'jesus ', N'jesusvase@hotmail.com', N'chuz', CAST(N'2021-05-25T00:06:32.437' AS DateTime), N'DBA', CAST(N'2021-05-25T00:06:32.437' AS DateTime), N'DBA')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (58, N'B90127', N'Luis', N'luis90101045@gmail.com', N'1234', CAST(N'2021-05-26T18:39:41.393' AS DateTime), N'DBA', CAST(N'2021-05-26T18:39:41.393' AS DateTime), N'DBA')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (63, N'b98296', N'jesus', N'jesus', N'a', CAST(N'2021-05-26T18:40:11.737' AS DateTime), N'DBA', CAST(N'2021-05-26T18:40:11.737' AS DateTime), N'DBA')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (64, N'323232', N'e', N'e', N'e', CAST(N'2021-05-26T18:40:57.263' AS DateTime), N'DBA', CAST(N'2021-05-26T18:40:57.263' AS DateTime), N'DBA')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (67, N'dff', N'a', N'a', N'a', CAST(N'2021-05-26T19:02:25.470' AS DateTime), N'DBA', CAST(N'2021-05-26T19:02:25.470' AS DateTime), N'DBA')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (68, N'155151', N'a', N'abffbfbfbfbf@hotmail.com', N'a', CAST(N'2021-05-26T19:04:14.800' AS DateTime), N'DBA', CAST(N'2021-05-26T19:04:14.800' AS DateTime), N'DBA')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (69, N'323232', N'e', N'e', N'e', CAST(N'2021-05-26T19:04:22.743' AS DateTime), N'DBA', CAST(N'2021-05-26T19:04:22.743' AS DateTime), N'DBA')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (70, N'dff', N'a', N'a', N'a', CAST(N'2021-05-26T19:04:31.353' AS DateTime), N'DBA', CAST(N'2021-05-26T19:04:31.353' AS DateTime), N'DBA')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (72, N'323232', N'e', N'e', N'e', CAST(N'2021-05-26T19:04:52.717' AS DateTime), N'DBA', CAST(N'2021-05-26T19:04:52.717' AS DateTime), N'DBA')
INSERT [dbo].[Student] ([Id], [Code], [Name], [Email], [Password], [Creation_Date], [Creation_User], [Update_Date], [Update_User]) VALUES (73, N'B97821', N'Rachell Tindel', N'racheltindelaraya@gmail.com', N'hola9845745', CAST(N'2021-05-26T19:08:01.643' AS DateTime), N'DBA', CAST(N'2021-05-26T19:08:01.643' AS DateTime), N'DBA')
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[TemporalStudent] ON 

INSERT [dbo].[TemporalStudent] ([Id], [Code], [Name], [Email], [Password]) VALUES (50, N'B94022', N'Erick Chavarria ', N'erick@gmail.com', N'gdjchgjw5')
INSERT [dbo].[TemporalStudent] ([Id], [Code], [Name], [Email], [Password]) VALUES (51, N'B92044', N'Erick Chavarria', N'manito2033.ec@gmail.com', N'jkvkjnfhv')
INSERT [dbo].[TemporalStudent] ([Id], [Code], [Name], [Email], [Password]) VALUES (52, N'B64943', N'Alejandro Araya', N'manito2033.ec@gmail.com', N'vbgtrg')
INSERT [dbo].[TemporalStudent] ([Id], [Code], [Name], [Email], [Password]) VALUES (53, N'B87465', N'Fernando G', N'manito2033.ec@gmail.com', N'fvgtergv')
SET IDENTITY_INSERT [dbo].[TemporalStudent] OFF
GO
ALTER TABLE [dbo].[Admin] ADD  CONSTRAINT [DF_Creation_Date_Admin]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Admin] ADD  CONSTRAINT [DF_Creation_User_Admin]  DEFAULT ('DBA') FOR [Creation_User]
GO
ALTER TABLE [dbo].[Admin] ADD  CONSTRAINT [DF_Update_Date_Admin]  DEFAULT (getdate()) FOR [Update_Date]
GO
ALTER TABLE [dbo].[Admin] ADD  CONSTRAINT [DF_Update_User_Admin]  DEFAULT ('DBA') FOR [Update_User]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Creation_Date_Course]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Creation_User_Course]  DEFAULT ('DBA') FOR [Creation_User]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Update_Date_Course]  DEFAULT (getdate()) FOR [Update_Date]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Update_User_Course]  DEFAULT ('DBA') FOR [Update_User]
GO
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Creation_Date_Group]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Creation_User_Group]  DEFAULT ('DBA') FOR [Creation_User]
GO
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Update_Date_Group]  DEFAULT (getdate()) FOR [Update_Date]
GO
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Update_User_Group]  DEFAULT ('DBA') FOR [Update_User]
GO
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Creation_Date_Message]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Creation_User_Message]  DEFAULT ('DBA') FOR [Creation_User]
GO
ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [DF_Creation_Date_Professor]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [DF_Creation_User_Professor]  DEFAULT ('DBA') FOR [Creation_User]
GO
ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [DF_Update_Date_Professor]  DEFAULT (getdate()) FOR [Update_Date]
GO
ALTER TABLE [dbo].[Professor] ADD  CONSTRAINT [DF_Update_User_Professor]  DEFAULT ('DBA') FOR [Update_User]
GO
ALTER TABLE [dbo].[Professor_Course_Group] ADD  CONSTRAINT [DF_Creation_Date_Professor_Course_Group]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Professor_Course_Group] ADD  CONSTRAINT [DF_Creation_User_Professor_Course_Group]  DEFAULT ('DBA') FOR [Creation_User]
GO
ALTER TABLE [dbo].[Professor_Course_Group] ADD  CONSTRAINT [DF_Update_Date_Professor_Course_Group]  DEFAULT (getdate()) FOR [Update_Date]
GO
ALTER TABLE [dbo].[Professor_Course_Group] ADD  CONSTRAINT [DF_Update_User_Professor_Course_Group]  DEFAULT ('DBA') FOR [Update_User]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Creation_Date_Student]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Creation_User_Student]  DEFAULT ('DBA') FOR [Creation_User]
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
ALTER TABLE [dbo].[Professor_Course_Group]  WITH CHECK ADD  CONSTRAINT [FK_Professor_Course_Group_Professor] FOREIGN KEY([Professor_Id])
REFERENCES [dbo].[Professor] ([Id])
GO
ALTER TABLE [dbo].[Professor_Course_Group] CHECK CONSTRAINT [FK_Professor_Course_Group_Professor]
GO
USE [master]
GO
ALTER DATABASE [IF4101_2021_SPA] SET  READ_WRITE 
GO

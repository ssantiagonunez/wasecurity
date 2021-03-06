USE [master]
GO
/****** Object:  Database [wasecurity]    Script Date: 3/24/2019 9:59:27 PM ******/
CREATE DATABASE [wasecurity]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'wasecurity', FILENAME = N'P:\Programs\SQL SERVER 2017 EXPRESS EDITION\MSSQL14.SQLEXPRESS\MSSQL\DATA\wasecurity.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'wasecurity_log', FILENAME = N'P:\Programs\SQL SERVER 2017 EXPRESS EDITION\MSSQL14.SQLEXPRESS\MSSQL\DATA\wasecurity_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [wasecurity] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [wasecurity].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [wasecurity] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [wasecurity] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [wasecurity] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [wasecurity] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [wasecurity] SET ARITHABORT OFF 
GO
ALTER DATABASE [wasecurity] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [wasecurity] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [wasecurity] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [wasecurity] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [wasecurity] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [wasecurity] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [wasecurity] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [wasecurity] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [wasecurity] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [wasecurity] SET  DISABLE_BROKER 
GO
ALTER DATABASE [wasecurity] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [wasecurity] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [wasecurity] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [wasecurity] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [wasecurity] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [wasecurity] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [wasecurity] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [wasecurity] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [wasecurity] SET  MULTI_USER 
GO
ALTER DATABASE [wasecurity] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [wasecurity] SET DB_CHAINING OFF 
GO
ALTER DATABASE [wasecurity] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [wasecurity] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [wasecurity] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [wasecurity] SET QUERY_STORE = OFF
GO
USE [wasecurity]
GO
/****** Object:  Table [dbo].[Apartment]    Script Date: 3/24/2019 9:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartment](
	[apartmentID] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Apartment] PRIMARY KEY CLUSTERED 
(
	[apartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 3/24/2019 9:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[personID] [smallint] IDENTITY(1,1) NOT NULL,
	[personName] [varchar](20) NOT NULL,
	[personSecondName] [varchar](20) NULL,
	[personLastName] [varchar](50) NOT NULL,
	[apartmentID] [varchar](10) NOT NULL,
	[plateNumber] [varchar](6) NOT NULL,
	[personType] [varchar](20) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[personID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/24/2019 9:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userid] [int] NOT NULL,
	[userpassword] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 3/24/2019 9:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[plateNumber] [varchar](6) NOT NULL,
	[manufacturer] [varchar](20) NOT NULL,
	[model] [varchar](20) NOT NULL,
	[color] [varchar](20) NOT NULL,
	[apartmentID] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[plateNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VisitsRecord]    Script Date: 3/24/2019 9:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitsRecord](
	[visitRecordID] [smallint] IDENTITY(1,1) NOT NULL,
	[personID] [smallint] NOT NULL,
	[recorddate] [datetime] NOT NULL,
 CONSTRAINT [PK_VisitsRecord] PRIMARY KEY CLUSTERED 
(
	[visitRecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Apartment] ([apartmentID]) VALUES (N'515A')
INSERT [dbo].[Apartment] ([apartmentID]) VALUES (N'515B')
INSERT [dbo].[Apartment] ([apartmentID]) VALUES (N'515Z')
INSERT [dbo].[Apartment] ([apartmentID]) VALUES (N'789G')
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([personID], [personName], [personSecondName], [personLastName], [apartmentID], [plateNumber], [personType]) VALUES (201, N'William', NULL, N'Nunez Rodriguez', N'515B', N'NMB123', N'Resident')
INSERT [dbo].[Person] ([personID], [personName], [personSecondName], [personLastName], [apartmentID], [plateNumber], [personType]) VALUES (202, N'Juan', N'Pueblo', N'Mejias', N'515B', N'NMB123', N'Visitor')
INSERT [dbo].[Person] ([personID], [personName], [personSecondName], [personLastName], [apartmentID], [plateNumber], [personType]) VALUES (203, N'Pedro', N'Pica', N'Piedras', N'515B', N'NMB123', N'Visitor')
INSERT [dbo].[Person] ([personID], [personName], [personSecondName], [personLastName], [apartmentID], [plateNumber], [personType]) VALUES (219, N'dasdasd', N'asdadsa', N'dasasdaas asdasda', N'515A', N'NMB123', N'Resident')
SET IDENTITY_INSERT [dbo].[Person] OFF
INSERT [dbo].[Users] ([userid], [userpassword]) VALUES (601, N'8927bd748f26a7258a01e318a7e1e7585458a228')
INSERT [dbo].[Vehicle] ([plateNumber], [manufacturer], [model], [color], [apartmentID]) VALUES (N'ABC123', N'Jeep', N'xyz', N'Rojo', N'789G')
INSERT [dbo].[Vehicle] ([plateNumber], [manufacturer], [model], [color], [apartmentID]) VALUES (N'NMB123', N'Mitsubishi', N'Camry', N'Rosa', N'515B')
INSERT [dbo].[Vehicle] ([plateNumber], [manufacturer], [model], [color], [apartmentID]) VALUES (N'QWE258', N'Mitsubishi', N'Galant', N'Azul', N'515B')
INSERT [dbo].[Vehicle] ([plateNumber], [manufacturer], [model], [color], [apartmentID]) VALUES (N'ZXC123', N'Toyota', N'Corolla', N'Red', N'515B')
SET IDENTITY_INSERT [dbo].[VisitsRecord] ON 

INSERT [dbo].[VisitsRecord] ([visitRecordID], [personID], [recorddate]) VALUES (401, 202, CAST(N'2019-03-16T00:00:00.000' AS DateTime))
INSERT [dbo].[VisitsRecord] ([visitRecordID], [personID], [recorddate]) VALUES (402, 202, CAST(N'2019-03-19T15:55:47.157' AS DateTime))
INSERT [dbo].[VisitsRecord] ([visitRecordID], [personID], [recorddate]) VALUES (403, 203, CAST(N'2019-03-19T15:55:58.097' AS DateTime))
INSERT [dbo].[VisitsRecord] ([visitRecordID], [personID], [recorddate]) VALUES (404, 202, CAST(N'2019-03-24T21:07:11.423' AS DateTime))
INSERT [dbo].[VisitsRecord] ([visitRecordID], [personID], [recorddate]) VALUES (405, 202, CAST(N'2019-03-24T21:53:22.770' AS DateTime))
SET IDENTITY_INSERT [dbo].[VisitsRecord] OFF
USE [master]
GO
ALTER DATABASE [wasecurity] SET  READ_WRITE 
GO

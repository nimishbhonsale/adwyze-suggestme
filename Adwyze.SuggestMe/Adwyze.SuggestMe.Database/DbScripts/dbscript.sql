USE [master]
GO

/****** Object:  Database [suggestme]    Script Date: 10/07/2014 12:44:13 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'suggestme')
DROP DATABASE [suggestme]
GO

USE [master]
GO

/****** Object:  Database [suggestme]    Script Date: 10/07/2014 12:44:13 ******/
CREATE DATABASE [suggestme] ON  PRIMARY 
( NAME = N'suggestme', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\suggestme.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'suggestme_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\suggestme_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [suggestme] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [suggestme].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [suggestme] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [suggestme] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [suggestme] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [suggestme] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [suggestme] SET ARITHABORT OFF 
GO

ALTER DATABASE [suggestme] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [suggestme] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [suggestme] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [suggestme] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [suggestme] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [suggestme] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [suggestme] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [suggestme] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [suggestme] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [suggestme] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [suggestme] SET  DISABLE_BROKER 
GO

ALTER DATABASE [suggestme] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [suggestme] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [suggestme] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [suggestme] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [suggestme] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [suggestme] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [suggestme] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [suggestme] SET  READ_WRITE 
GO

ALTER DATABASE [suggestme] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [suggestme] SET  MULTI_USER 
GO

ALTER DATABASE [suggestme] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [suggestme] SET DB_CHAINING OFF 
GO


USE [suggestme]
GO

/****** Object:  Table [dbo].[Profile]    Script Date: 10/07/2014 12:49:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Profile]') AND type in (N'U'))
DROP TABLE [dbo].[Profile]
GO

USE [suggestme]
GO

/****** Object:  Table [dbo].[Profile]    Script Date: 10/07/2014 12:49:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Profile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](100) NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


USE [suggestme]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_History_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[SearchHistory]'))
ALTER TABLE [dbo].[SearchHistory] DROP CONSTRAINT [FK_History_User]
GO

USE [suggestme]
GO

/****** Object:  Table [dbo].[SearchHistory]    Script Date: 10/07/2014 12:50:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchHistory]') AND type in (N'U'))
DROP TABLE [dbo].[SearchHistory]
GO

USE [suggestme]
GO

/****** Object:  Table [dbo].[SearchHistory]    Script Date: 10/07/2014 12:50:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SearchHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Keyword] [nvarchar](100) NULL,
	[UserId] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_History] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SearchHistory]  WITH CHECK ADD  CONSTRAINT [FK_History_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Profile] ([Id])
GO

ALTER TABLE [dbo].[SearchHistory] CHECK CONSTRAINT [FK_History_User]
GO



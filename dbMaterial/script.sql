USE [master]
GO
/****** Object:  Database [CarryOn]    Script Date: 14/09/2017 13:00:23 ******/
CREATE DATABASE [CarryOn]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarryOn', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS12\MSSQL\DATA\CarryOn.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CarryOn_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS12\MSSQL\DATA\CarryOn_log.ldf' , SIZE = 2304KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CarryOn] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarryOn].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarryOn] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarryOn] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarryOn] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarryOn] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarryOn] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarryOn] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarryOn] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarryOn] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarryOn] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarryOn] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarryOn] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarryOn] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarryOn] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarryOn] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarryOn] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarryOn] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarryOn] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarryOn] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarryOn] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarryOn] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarryOn] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarryOn] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarryOn] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarryOn] SET  MULTI_USER 
GO
ALTER DATABASE [CarryOn] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarryOn] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarryOn] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarryOn] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CarryOn]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 14/09/2017 13:00:24 ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [IIS APPPOOL\ASP.NET v4.0]    Script Date: 14/09/2017 13:00:24 ******/
CREATE USER [IIS APPPOOL\ASP.NET v4.0] FOR LOGIN [IIS APPPOOL\ASP.NET v4.0] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_datareader] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\ASP.NET v4.0]
GO
ALTER ROLE [db_datareader] ADD MEMBER [IIS APPPOOL\ASP.NET v4.0]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [IIS APPPOOL\ASP.NET v4.0]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressID] [uniqueidentifier] NOT NULL,
	[Type] [int] NOT NULL,
	[County] [varchar](15) NULL,
	[Country] [varchar](20) NULL,
	[District] [varchar](25) NULL,
	[HouseName] [varchar](100) NULL,
	[CreationDate] [datetime] NULL,
	[HouseNumber] [varchar](5) NULL,
	[PostCode] [varchar](9) NULL,
	[Street1] [varchar](100) NULL,
	[Street2] [varchar](100) NULL,
	[Town] [varchar](25) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CO_TOKEN]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CO_TOKEN](
	[TOKEN] [varchar](255) NOT NULL,
	[DATA_CREAZIONE] [datetime2](3) NOT NULL,
	[DATA_ULTIMO_UTILIZZO] [datetime2](3) NOT NULL,
	[DATA_SCADENZA] [datetime2](3) NULL,
	[USERNAME] [varchar](20) NOT NULL,
 CONSTRAINT [PK_CO_TOKEN] PRIMARY KEY CLUSTERED 
(
	[TOKEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CO01UT]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CO01UT](
	[ID] [uniqueidentifier] NOT NULL,
	[UTEN] [varchar](20) NOT NULL,
	[TIPU] [varchar](1) NULL,
	[PASS] [varchar](20) NULL,
	[PWGG] [smallint] NULL,
	[PWSC] [datetime2](3) NULL,
	[NOME] [varchar](100) NULL,
	[LANG] [varchar](3) NULL,
	[EMAI] [varchar](255) NULL,
	[TELE] [varchar](50) NULL,
	[FAXN] [varchar](50) NULL,
	[UFFI] [varchar](100) NULL,
	[RIF1] [varchar](100) NULL,
	[RIF2] [varchar](100) NULL,
	[TELE2] [varchar](100) NULL,
	[ADR_ID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_MIR01UT_test] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReqGoodTransfer]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReqGoodTransfer](
	[Id] [uniqueidentifier] NOT NULL,
	[AddressFrom] [uniqueidentifier] NULL,
	[AddreessDest] [uniqueidentifier] NULL,
	[DateTransportFixed] [datetime] NULL,
	[DateTransportType] [int] NOT NULL,
	[DateTransportInfo] [nvarchar](50) NULL,
	[RequestState] [int] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[VolRequired] [nvarchar](50) NULL,
 CONSTRAINT [PK_ReqGoodTransfer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TransportAv]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportAv](
	[Id] [uniqueidentifier] NOT NULL,
	[AddressFrom] [uniqueidentifier] NULL,
	[AddreessDest] [uniqueidentifier] NULL,
	[DateTransportFixed] [datetime] NULL,
	[DateTransportType] [int] NOT NULL,
	[DateTransportInfo] [nvarchar](50) NULL,
	[RequestState] [int] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[VolAvailable] [nvarchar](50) NULL,
 CONSTRAINT [PK_TransportAv] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TransportOptions]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportOptions](
	[TransportId] [uniqueidentifier] NOT NULL,
	[OptKey] [nchar](15) NOT NULL,
	[OptValue] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[TransportId] ASC,
	[OptKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [dbo].[CO_VW_USER_TOKEN]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[CO_VW_USER_TOKEN]
AS
SELECT dbo.CO01UT.*, dbo.CO_TOKEN.*
FROM     dbo.CO01UT 
INNER JOIN dbo.CO_TOKEN ON dbo.CO01UT.UTEN = dbo.CO_TOKEN.USERNAME



GO
/****** Object:  View [dbo].[ReqGoodTransferWithAddresses]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[ReqGoodTransferWithAddresses]
AS
SELECT TOP (1000) rgt.Id, rgt.AddressFrom, rgt.AddreessDest, rgt.DateTransportFixed, rgt.DateTransportType, rgt.DateTransportInfo, rgt.RequestState, 
				  rgt.VolRequired AS VolRequired, af.Type AS FromType, 
                  af.County AS FromCounty, af.Country AS FromCountry, af.District AS FromDistrict, af.HouseName AS FromHouseName, af.CreationDate AS FromCreationDate, 
                  af.HouseNumber AS FromHouseNumber, af.PostCode AS FromPostCode, af.Street1 AS FromStreet1, af.Street2 AS FromStreet2, af.Town AS FromTown, 
                  ad.Type AS DestType, ad.County AS DestCounty, ad.Country AS DestCountry, ad.District AS DestDistrict, ad.HouseName AS DestHouseName, 
                  ad.CreationDate AS DestCreationDate, ad.HouseNumber AS DestHouseNumber, ad.PostCode AS DestPostCode, ad.Street1 AS DestStreet1, ad.Street2 AS DestStreet2, 
                  ad.Town AS DestTown, au.Type AS UserType, 
                  au.County AS UserCounty, au.Country AS UserCountry, au.District AS UserDistrict, au.HouseName AS UserHouseName, au.CreationDate AS UserCreationDate, 
                  au.HouseNumber AS UserHouseNumber, au.PostCode AS UserPostCode, au.Street1 AS UserStreet1, au.Street2 AS UserStreet2, au.Town AS UserTown, 
				  ut.ID AS UserId, ut.NOME AS UserName, ut.EMAI AS UserEmail, ut.TELE AS UserTELE, ut.TELE2 AS UserTEL2, ut.LANG AS UserLang
FROM dbo.ReqGoodTransfer AS rgt INNER JOIN
                  dbo.Addresses AS af ON af.AddressID = rgt.AddressFrom INNER JOIN
                  dbo.Addresses AS ad ON ad.AddressID = rgt.AddreessDest INNER JOIN
                  dbo.CO01UT AS ut ON ut.ID = rgt.UserId INNER JOIN
                  dbo.Addresses AS au ON au.AddressID = ut.ADR_ID




GO
/****** Object:  View [dbo].[TransportAvWithAddresses]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[TransportAvWithAddresses]
AS
SELECT TOP (1000) tav.Id, tav.AddressFrom, tav.AddreessDest, tav.DateTransportFixed, tav.DateTransportType, tav.DateTransportInfo, tav.RequestState, 
				  tav.VolAvailable AS VolAvailable, af.Type AS FromType, 
                  af.County AS FromCounty, af.Country AS FromCountry, af.District AS FromDistrict, af.HouseName AS FromHouseName, af.CreationDate AS FromCreationDate, 
                  af.HouseNumber AS FromHouseNumber, af.PostCode AS FromPostCode, af.Street1 AS FromStreet1, af.Street2 AS FromStreet2, af.Town AS FromTown, 
                  ad.Type AS DestType, ad.County AS DestCounty, ad.Country AS DestCountry, ad.District AS DestDistrict, ad.HouseName AS DestHouseName, 
                  ad.CreationDate AS DestCreationDate, ad.HouseNumber AS DestHouseNumber, ad.PostCode AS DestPostCode, ad.Street1 AS DestStreet1, ad.Street2 AS DestStreet2, 
                  ad.Town AS DestTown, au.Type AS UserType, 
                  au.County AS UserCounty, au.Country AS UserCountry, au.District AS UserDistrict, au.HouseName AS UserHouseName, au.CreationDate AS UserCreationDate, 
                  au.HouseNumber AS UserHouseNumber, au.PostCode AS UserPostCode, au.Street1 AS UserStreet1, au.Street2 AS UserStreet2, au.Town AS UserTown, 
				  ut.ID AS UserId, ut.NOME AS UserName, ut.EMAI AS UserEmail, ut.TELE AS UserTELE, ut.TELE2 AS UserTEL2, ut.LANG AS UserLang
FROM dbo.TransportAv AS tav INNER JOIN
                  dbo.Addresses AS af ON af.AddressID = tav.AddressFrom INNER JOIN
                  dbo.Addresses AS ad ON ad.AddressID = tav.AddreessDest INNER JOIN
                  dbo.CO01UT AS ut ON ut.ID = tav.UserId INNER JOIN
                  dbo.Addresses AS au ON au.AddressID = ut.ADR_ID





GO
INSERT [dbo].[Addresses] ([AddressID], [Type], [County], [Country], [District], [HouseName], [CreationDate], [HouseNumber], [PostCode], [Street1], [Street2], [Town]) VALUES (N'46d26fb9-6643-4e97-a10d-8f8e0a51ad3c', 0, N'Milano', N'Italia', N'Milano', N'', NULL, N'2', N'20103', N'Via Cardinale', N'', N'Milano')
INSERT [dbo].[Addresses] ([AddressID], [Type], [County], [Country], [District], [HouseName], [CreationDate], [HouseNumber], [PostCode], [Street1], [Street2], [Town]) VALUES (N'd56c8abe-d3f7-44bd-8087-1f2c8fde36c1', 0, N'Pesaro', N'Italia', N'Pesaro', N'', NULL, N'43', N'43105', N'Via Giadi', N'testTo', N'Budrio')
INSERT [dbo].[Addresses] ([AddressID], [Type], [County], [Country], [District], [HouseName], [CreationDate], [HouseNumber], [PostCode], [Street1], [Street2], [Town]) VALUES (N'89f03eca-6922-4148-9e03-956754ee13d7', 0, N'TestUser', N'TestUser', N'TestUser', N'TestUser', NULL, N'5', N'TestUser', N'TestUser', N'TestUser', N'TestUser')
INSERT [dbo].[CO01UT] ([ID], [UTEN], [TIPU], [PASS], [PWGG], [PWSC], [NOME], [LANG], [EMAI], [TELE], [FAXN], [UFFI], [RIF1], [RIF2], [TELE2], [ADR_ID]) VALUES (N'202fe2cc-216c-4e69-a423-006785156dbe', N'test', NULL, N'ÏÞÈÏ', NULL, NULL, NULL, NULL, N'mario.fornaroli@yahoo.it', NULL, NULL, NULL, NULL, NULL, NULL, N'89f03eca-6922-4148-9e03-956754ee13d7')
INSERT [dbo].[ReqGoodTransfer] ([Id], [AddressFrom], [AddreessDest], [DateTransportFixed], [DateTransportType], [DateTransportInfo], [RequestState], [UserId], [VolRequired]) VALUES (N'd67cf6fb-7469-448c-9d4e-00ad01efb8da', N'46d26fb9-6643-4e97-a10d-8f8e0a51ad3c', N'd56c8abe-d3f7-44bd-8087-1f2c8fde36c1', NULL, 1, N'Prima possibile', 0, N'202fe2cc-216c-4e69-a423-006785156dbe', N'10')
INSERT [dbo].[TransportAv] ([Id], [AddressFrom], [AddreessDest], [DateTransportFixed], [DateTransportType], [DateTransportInfo], [RequestState], [UserId], [VolAvailable]) VALUES (N'b502df28-6994-469e-8e5c-b07f2ee21cbf', N'46d26fb9-6643-4e97-a10d-8f8e0a51ad3c', N'd56c8abe-d3f7-44bd-8087-1f2c8fde36c1', NULL, 1, N'Prima possibile', 0, N'202fe2cc-216c-4e69-a423-006785156dbe', N'10')
/****** Object:  Index [PK_Adresses]    Script Date: 14/09/2017 13:00:24 ******/
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [PK_Adresses] PRIMARY KEY NONCLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CO01UT]  WITH NOCHECK ADD  CONSTRAINT [FK_CO01UT_Addresses] FOREIGN KEY([ADR_ID])
REFERENCES [dbo].[Addresses] ([AddressID])
GO
ALTER TABLE [dbo].[CO01UT] CHECK CONSTRAINT [FK_CO01UT_Addresses]
GO
ALTER TABLE [dbo].[ReqGoodTransfer]  WITH CHECK ADD  CONSTRAINT [FK_ReqGoodTransfer_Addresses] FOREIGN KEY([AddressFrom])
REFERENCES [dbo].[Addresses] ([AddressID])
GO
ALTER TABLE [dbo].[ReqGoodTransfer] CHECK CONSTRAINT [FK_ReqGoodTransfer_Addresses]
GO
ALTER TABLE [dbo].[ReqGoodTransfer]  WITH CHECK ADD  CONSTRAINT [FK_ReqGoodTransfer_Addresses1] FOREIGN KEY([AddreessDest])
REFERENCES [dbo].[Addresses] ([AddressID])
GO
ALTER TABLE [dbo].[ReqGoodTransfer] CHECK CONSTRAINT [FK_ReqGoodTransfer_Addresses1]
GO
ALTER TABLE [dbo].[ReqGoodTransfer]  WITH CHECK ADD  CONSTRAINT [FK_ReqGoodTransfer_CO01UT] FOREIGN KEY([UserId])
REFERENCES [dbo].[CO01UT] ([ID])
GO
ALTER TABLE [dbo].[ReqGoodTransfer] CHECK CONSTRAINT [FK_ReqGoodTransfer_CO01UT]
GO
ALTER TABLE [dbo].[TransportAv]  WITH CHECK ADD  CONSTRAINT [FK_TransportAv_Addresses] FOREIGN KEY([AddressFrom])
REFERENCES [dbo].[Addresses] ([AddressID])
GO
ALTER TABLE [dbo].[TransportAv] CHECK CONSTRAINT [FK_TransportAv_Addresses]
GO
ALTER TABLE [dbo].[TransportAv]  WITH CHECK ADD  CONSTRAINT [FK_TransportAv_Addresses1] FOREIGN KEY([AddreessDest])
REFERENCES [dbo].[Addresses] ([AddressID])
GO
ALTER TABLE [dbo].[TransportAv] CHECK CONSTRAINT [FK_TransportAv_Addresses1]
GO
ALTER TABLE [dbo].[TransportAv]  WITH CHECK ADD  CONSTRAINT [FK_TransportAv_CO01UT] FOREIGN KEY([UserId])
REFERENCES [dbo].[CO01UT] ([ID])
GO
ALTER TABLE [dbo].[TransportAv] CHECK CONSTRAINT [FK_TransportAv_CO01UT]
GO
/****** Object:  StoredProcedure [dbo].[_DeleteFromAddresses_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_DeleteFromAddresses_ByKeyFields] 
              @AddressID uniqueidentifier
AS

 
 
SET NOCOUNT ON;
DELETE
  FROM dbo.Addresses
 WHERE AddressID = @AddressID


GO
/****** Object:  StoredProcedure [dbo].[_DeleteFromCO_TOKEN_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_DeleteFromCO_TOKEN_ByKeyFields] 
              @TOKEN varchar(255)
AS

 
 
SET NOCOUNT ON;
DELETE
  FROM dbo.CO_TOKEN
 WHERE TOKEN = @TOKEN


GO
/****** Object:  StoredProcedure [dbo].[_DeleteFromCO01UT_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_DeleteFromCO01UT_ByKeyFields] 
              @ID uniqueidentifier
AS

 
 
SET NOCOUNT ON;
DELETE
  FROM dbo.CO01UT
 WHERE ID = @ID


GO
/****** Object:  StoredProcedure [dbo].[_DeleteFromReqGoodTransfer_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_DeleteFromReqGoodTransfer_ByKeyFields] 
              @Id uniqueidentifier
AS

 
 
SET NOCOUNT ON;
DELETE
  FROM dbo.ReqGoodTransfer
 WHERE Id = @Id


GO
/****** Object:  StoredProcedure [dbo].[_DeleteFromTransportAv_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_DeleteFromTransportAv_ByKeyFields] 
              @Id uniqueidentifier
AS

 
 
SET NOCOUNT ON;
DELETE
  FROM dbo.TransportAv
 WHERE Id = @Id


GO
/****** Object:  StoredProcedure [dbo].[_DeleteFromTransportOptions_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_DeleteFromTransportOptions_ByKeyFields] 
              @TransportId uniqueidentifier
            , @OptKey nchar(30)
AS

 
 
SET NOCOUNT ON;
DELETE
  FROM dbo.TransportOptions
 WHERE TransportId = @TransportId
   AND OptKey = @OptKey


GO
/****** Object:  StoredProcedure [dbo].[_GetAllFieldsFromAddresses_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_GetAllFieldsFromAddresses_ByKeyFields] 
              @AddressID uniqueidentifier
AS

SET NOCOUNT ON;
SELECT *
  FROM dbo.Addresses
 WHERE AddressID = @AddressID


GO
/****** Object:  StoredProcedure [dbo].[_GetAllFieldsFromAddresses_BySomeEqualFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[_GetAllFieldsFromAddresses_BySomeEqualFields] 
              @AddressID uniqueidentifier  
            , @Type int  
            , @County varchar(15) 
            , @Country varchar(20) 
            , @District varchar(25) 
            , @HouseName varchar(100) 
            , @CreationDate datetime  
            , @HouseNumber varchar(5) 
            , @PostCode varchar(9) 
            , @Street1 varchar(100) 
            , @Street2 varchar(100) 
            , @Town varchar(25) 


AS
--TEMPLATE DA MODIFICARE, NON VALIDO COSI - IT IS ONLY A TEMPLATE, NOT VALID!!!!!!!!!!
SET NOCOUNT ON;
DECLARE @SQL NVARCHAR(MAX)
DECLARE @ParamDefinition NVARCHAR(MAX)

SELECT @SQL = 'SELECT  * FROM dbo.Addresses WHERE 1=1 ' 
if @AddressID is not null set @SQL = @SQL + ' AND AddressID  = @AddressID'
if @Type is not null set @SQL = @SQL + ' AND Type  = @Type'
if @County is not null set @SQL = @SQL + ' AND County  = @County'
if @Country is not null set @SQL = @SQL + ' AND Country  = @Country'
if @District is not null set @SQL = @SQL + ' AND District  = @District'
if @HouseName is not null set @SQL = @SQL + ' AND HouseName  = @HouseName'
if @CreationDate is not null set @SQL = @SQL + ' AND CreationDate  = @CreationDate'
if @HouseNumber is not null set @SQL = @SQL + ' AND HouseNumber  = @HouseNumber'
if @PostCode is not null set @SQL = @SQL + ' AND PostCode  = @PostCode'
if @Street1 is not null set @SQL = @SQL + ' AND Street1  = @Street1'
if @Street2 is not null set @SQL = @SQL + ' AND Street2  = @Street2'
if @Town is not null set @SQL = @SQL + ' AND Town  = @Town'


SET @ParamDefinition = '
              @AddressID uniqueidentifier  
            , @Type int  
            , @County varchar(15) 
            , @Country varchar(20) 
            , @District varchar(25) 
            , @HouseName varchar(100) 
            , @CreationDate datetime  
            , @HouseNumber varchar(5) 
            , @PostCode varchar(9) 
            , @Street1 varchar(100) 
            , @Street2 varchar(100) 
            , @Town varchar(25) 
'
--SELECT @SQL
exec sp_executesql @SQL, @ParamDefinition,
              @AddressID =  @AddressID
            , @Type =  @Type
            , @County =  @County
            , @Country =  @Country
            , @District =  @District
            , @HouseName =  @HouseName
            , @CreationDate =  @CreationDate
            , @HouseNumber =  @HouseNumber
            , @PostCode =  @PostCode
            , @Street1 =  @Street1
            , @Street2 =  @Street2
            , @Town =  @Town



GO
/****** Object:  StoredProcedure [dbo].[_GetAllFieldsFromCO_TOKEN_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_GetAllFieldsFromCO_TOKEN_ByKeyFields] 
              @TOKEN varchar(255)
AS

SET NOCOUNT ON;
SELECT *
  FROM dbo.CO_TOKEN
 WHERE TOKEN = @TOKEN


GO
/****** Object:  StoredProcedure [dbo].[_GetAllFieldsFromCO_TOKEN_BySomeEqualFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[_GetAllFieldsFromCO_TOKEN_BySomeEqualFields] 
              @TOKEN varchar(255) 
            , @DATA_CREAZIONE datetime2(3) 
            , @DATA_ULTIMO_UTILIZZO datetime2(3) 
            , @DATA_SCADENZA datetime2(3) 
            , @USERNAME varchar(20) 


AS
--TEMPLATE DA MODIFICARE, NON VALIDO COSI - IT IS ONLY A TEMPLATE, NOT VALID!!!!!!!!!!
SET NOCOUNT ON;
DECLARE @SQL NVARCHAR(MAX)
DECLARE @ParamDefinition NVARCHAR(MAX)

SELECT @SQL = 'SELECT  * FROM dbo.CO_TOKEN WHERE 1=1 ' 
if @TOKEN is not null set @SQL = @SQL + ' AND TOKEN  = @TOKEN'
if @DATA_CREAZIONE is not null set @SQL = @SQL + ' AND DATA_CREAZIONE  = @DATA_CREAZIONE'
if @DATA_ULTIMO_UTILIZZO is not null set @SQL = @SQL + ' AND DATA_ULTIMO_UTILIZZO  = @DATA_ULTIMO_UTILIZZO'
if @DATA_SCADENZA is not null set @SQL = @SQL + ' AND DATA_SCADENZA  = @DATA_SCADENZA'
if @USERNAME is not null set @SQL = @SQL + ' AND USERNAME  = @USERNAME'


SET @ParamDefinition = '
              @TOKEN varchar(255) 
            , @DATA_CREAZIONE datetime2(3) 
            , @DATA_ULTIMO_UTILIZZO datetime2(3) 
            , @DATA_SCADENZA datetime2(3) 
            , @USERNAME varchar(20) 
'
--SELECT @SQL
exec sp_executesql @SQL, @ParamDefinition,
              @TOKEN =  @TOKEN
            , @DATA_CREAZIONE =  @DATA_CREAZIONE
            , @DATA_ULTIMO_UTILIZZO =  @DATA_ULTIMO_UTILIZZO
            , @DATA_SCADENZA =  @DATA_SCADENZA
            , @USERNAME =  @USERNAME



GO
/****** Object:  StoredProcedure [dbo].[_GetAllFieldsFromCO01UT_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_GetAllFieldsFromCO01UT_ByKeyFields] 
              @ID uniqueidentifier
AS

SET NOCOUNT ON;
SELECT *
  FROM dbo.CO01UT
 WHERE ID = @ID


GO
/****** Object:  StoredProcedure [dbo].[_GetAllFieldsFromCO01UT_BySomeEqualFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[_GetAllFieldsFromCO01UT_BySomeEqualFields] 
              @ID uniqueidentifier  
            , @UTEN varchar(20) 
            , @TIPU varchar(1) 
            , @PASS varchar(20) 
            , @PWGG smallint  
            , @PWSC datetime2(3) 
            , @NOME varchar(100) 
            , @LANG varchar(3) 
            , @EMAI varchar(255) 
            , @TELE varchar(50) 
            , @FAXN varchar(50) 
            , @UFFI varchar(100) 
            , @RIF1 varchar(100) 
            , @RIF2 varchar(100) 
            , @TELE2 varchar(100) 
            , @ADR_ID uniqueidentifier  


AS
--TEMPLATE DA MODIFICARE, NON VALIDO COSI - IT IS ONLY A TEMPLATE, NOT VALID!!!!!!!!!!
SET NOCOUNT ON;
DECLARE @SQL NVARCHAR(MAX)
DECLARE @ParamDefinition NVARCHAR(MAX)

SELECT @SQL = 'SELECT  * FROM dbo.CO01UT WHERE 1=1 ' 
if @ID is not null set @SQL = @SQL + ' AND ID  = @ID'
if @UTEN is not null set @SQL = @SQL + ' AND UTEN  = @UTEN'
if @TIPU is not null set @SQL = @SQL + ' AND TIPU  = @TIPU'
if @PASS is not null set @SQL = @SQL + ' AND PASS  = @PASS'
if @PWGG is not null set @SQL = @SQL + ' AND PWGG  = @PWGG'
if @PWSC is not null set @SQL = @SQL + ' AND PWSC  = @PWSC'
if @NOME is not null set @SQL = @SQL + ' AND NOME  = @NOME'
if @LANG is not null set @SQL = @SQL + ' AND LANG  = @LANG'
if @EMAI is not null set @SQL = @SQL + ' AND EMAI  = @EMAI'
if @TELE is not null set @SQL = @SQL + ' AND TELE  = @TELE'
if @FAXN is not null set @SQL = @SQL + ' AND FAXN  = @FAXN'
if @UFFI is not null set @SQL = @SQL + ' AND UFFI  = @UFFI'
if @RIF1 is not null set @SQL = @SQL + ' AND RIF1  = @RIF1'
if @RIF2 is not null set @SQL = @SQL + ' AND RIF2  = @RIF2'
if @TELE2 is not null set @SQL = @SQL + ' AND TELE2  = @TELE2'
if @ADR_ID is not null set @SQL = @SQL + ' AND ADR_ID  = @ADR_ID'


SET @ParamDefinition = '
              @ID uniqueidentifier  
            , @UTEN varchar(20) 
            , @TIPU varchar(1) 
            , @PASS varchar(20) 
            , @PWGG smallint  
            , @PWSC datetime2(3) 
            , @NOME varchar(100) 
            , @LANG varchar(3) 
            , @EMAI varchar(255) 
            , @TELE varchar(50) 
            , @FAXN varchar(50) 
            , @UFFI varchar(100) 
            , @RIF1 varchar(100) 
            , @RIF2 varchar(100) 
            , @TELE2 varchar(100) 
            , @ADR_ID uniqueidentifier  
'
--SELECT @SQL
exec sp_executesql @SQL, @ParamDefinition,
              @ID =  @ID
            , @UTEN =  @UTEN
            , @TIPU =  @TIPU
            , @PASS =  @PASS
            , @PWGG =  @PWGG
            , @PWSC =  @PWSC
            , @NOME =  @NOME
            , @LANG =  @LANG
            , @EMAI =  @EMAI
            , @TELE =  @TELE
            , @FAXN =  @FAXN
            , @UFFI =  @UFFI
            , @RIF1 =  @RIF1
            , @RIF2 =  @RIF2
            , @TELE2 =  @TELE2
            , @ADR_ID =  @ADR_ID



GO
/****** Object:  StoredProcedure [dbo].[_GetAllFieldsFromReqGoodTransfer_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[_GetAllFieldsFromReqGoodTransfer_ByKeyFields] 
              @Id uniqueidentifier
AS

SET NOCOUNT ON;
SELECT *
  FROM dbo.ReqGoodTransferWithAddresses
  WHERE (@Id IS NULL) OR (Id = @Id)
 --WHERE Id = @Id 




GO
/****** Object:  StoredProcedure [dbo].[_GetAllFieldsFromReqGoodTransfer_BySomeEqualFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[_GetAllFieldsFromReqGoodTransfer_BySomeEqualFields] 
              @Id uniqueidentifier  
            , @AddressFrom uniqueidentifier 
            , @AddreessDest uniqueidentifier 
            , @DateTransportFixed datetime  
            , @DateTransportType int  
            , @DateTransportInfo nvarchar(100) 
            , @RequestState int  
            , @UserId uniqueidentifier 
            , @VolRequired nvarchar(100) 


AS
--TEMPLATE DA MODIFICARE, NON VALIDO COSI - IT IS ONLY A TEMPLATE, NOT VALID!!!!!!!!!!
SET NOCOUNT ON;
DECLARE @SQL NVARCHAR(MAX)
DECLARE @ParamDefinition NVARCHAR(MAX)

SELECT @SQL = 'SELECT  * FROM dbo.ReqGoodTransferWithAddresses WHERE 1=1 ' 
if @Id is not null set @SQL = @SQL + ' AND Id  = @Id'
if @AddressFrom is not null set @SQL = @SQL + ' AND AddressFrom  = @AddressFrom'
if @AddreessDest is not null set @SQL = @SQL + ' AND AddreessDest  = @AddreessDest'
if @DateTransportFixed is not null set @SQL = @SQL + ' AND DateTransportFixed  = @DateTransportFixed'
if @DateTransportType is not null set @SQL = @SQL + ' AND DateTransportType  = @DateTransportType'
if @DateTransportInfo is not null set @SQL = @SQL + ' AND DateTransportInfo  = @DateTransportInfo'
if @RequestState is not null set @SQL = @SQL + ' AND RequestState  = @RequestState'
if @UserId is not null set @SQL = @SQL + ' AND UserId  = @UserId'
if @VolRequired is not null set @SQL = @SQL + ' AND VolRequired  = @VolRequired'


SET @ParamDefinition = '
              @Id uniqueidentifier  
            , @AddressFrom uniqueidentifier
            , @AddreessDest uniqueidentifier 
            , @DateTransportFixed datetime  
            , @DateTransportType int  
            , @DateTransportInfo nvarchar(100) 
            , @RequestState int  
            , @UserId uniqueidentifier 
            , @VolRequired nvarchar(100) 
'
--SELECT @SQL
exec sp_executesql @SQL, @ParamDefinition,
              @Id =  @Id
            , @AddressFrom =  @AddressFrom
            , @AddreessDest =  @AddreessDest
            , @DateTransportFixed =  @DateTransportFixed
            , @DateTransportType =  @DateTransportType
            , @DateTransportInfo =  @DateTransportInfo
            , @RequestState =  @RequestState
            , @UserId =  @UserId
            , @VolRequired =  @VolRequired




GO
/****** Object:  StoredProcedure [dbo].[_GetAllFieldsFromTransportAv_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[_GetAllFieldsFromTransportAv_ByKeyFields] 
              @Id uniqueidentifier
AS

SET NOCOUNT ON;
SELECT *
  FROM dbo.TransportAvWithAddresses
 WHERE (@Id IS NULL) OR (Id = @Id)




GO
/****** Object:  StoredProcedure [dbo].[_GetAllFieldsFromTransportAv_BySomeEqualFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[_GetAllFieldsFromTransportAv_BySomeEqualFields] 
              @Id uniqueidentifier  
            , @AddressFrom uniqueidentifier 
            , @AddreessDest uniqueidentifier 
            , @DateTransportFixed datetime  
            , @DateTransportType int  
            , @DateTransportInfo nvarchar(100) 
            , @RequestState int  
            , @UserId uniqueidentifier 
            , @VolAvailable nvarchar(100) 


AS
--TEMPLATE DA MODIFICARE, NON VALIDO COSI - IT IS ONLY A TEMPLATE, NOT VALID!!!!!!!!!!
SET NOCOUNT ON;
DECLARE @SQL NVARCHAR(MAX)
DECLARE @ParamDefinition NVARCHAR(MAX)

SELECT @SQL = 'SELECT  * FROM dbo.TransportAvWithAddresses WHERE 1=1 ' 
if @Id is not null set @SQL = @SQL + ' AND Id  = @Id'
if @AddressFrom is not null set @SQL = @SQL + ' AND AddressFrom  = @AddressFrom'
if @AddreessDest is not null set @SQL = @SQL + ' AND AddreessDest  = @AddreessDest'
if @DateTransportFixed is not null set @SQL = @SQL + ' AND DateTransportFixed  = @DateTransportFixed'
if @DateTransportType is not null set @SQL = @SQL + ' AND DateTransportType  = @DateTransportType'
if @DateTransportInfo is not null set @SQL = @SQL + ' AND DateTransportInfo  = @DateTransportInfo'
if @RequestState is not null set @SQL = @SQL + ' AND RequestState  = @RequestState'
if @UserId is not null set @SQL = @SQL + ' AND UserId  = @UserId'
if @VolAvailable is not null set @SQL = @SQL + ' AND VolAvailable  = @VolAvailable'


SET @ParamDefinition = '
              @Id uniqueidentifier  
            , @AddressFrom uniqueidentifier
            , @AddreessDest uniqueidentifier 
            , @DateTransportFixed datetime  
            , @DateTransportType int  
            , @DateTransportInfo nvarchar(100) 
            , @RequestState int  
            , @UserId uniqueidentifier 
            , @VolAvailable nvarchar(100) 
'
--SELECT @SQL
exec sp_executesql @SQL, @ParamDefinition,
              @Id =  @Id
            , @AddressFrom =  @AddressFrom
            , @AddreessDest =  @AddreessDest
            , @DateTransportFixed =  @DateTransportFixed
            , @DateTransportType =  @DateTransportType
            , @DateTransportInfo =  @DateTransportInfo
            , @RequestState =  @RequestState
            , @UserId =  @UserId
            , @VolAvailable =  @VolAvailable




GO
/****** Object:  StoredProcedure [dbo].[_GetAllFieldsFromTransportOptions_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_GetAllFieldsFromTransportOptions_ByKeyFields] 
              @TransportId uniqueidentifier
            , @OptKey nchar(30)
AS

SET NOCOUNT ON;
SELECT *
  FROM dbo.TransportOptions
 WHERE TransportId = @TransportId
   AND OptKey = @OptKey


GO
/****** Object:  StoredProcedure [dbo].[_GetAllFieldsFromTransportOptions_BySomeEqualFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[_GetAllFieldsFromTransportOptions_BySomeEqualFields] 
              @TransportId uniqueidentifier  
            , @OptKey nchar(30) 
            , @OptValue nvarchar(MAX) 


AS
--TEMPLATE DA MODIFICARE, NON VALIDO COSI - IT IS ONLY A TEMPLATE, NOT VALID!!!!!!!!!!
SET NOCOUNT ON;
DECLARE @SQL NVARCHAR(MAX)
DECLARE @ParamDefinition NVARCHAR(MAX)

SELECT @SQL = 'SELECT  * FROM dbo.TransportOptions WHERE 1=1 ' 
if @TransportId is not null set @SQL = @SQL + ' AND TransportId  = @TransportId'
if @OptKey is not null set @SQL = @SQL + ' AND OptKey  = @OptKey'
if @OptValue is not null set @SQL = @SQL + ' AND OptValue  = @OptValue'


SET @ParamDefinition = '
              @TransportId uniqueidentifier  
            , @OptKey nvarchar(30) 
            , @OptValue nvarchar(MAX) 
'
--SELECT @SQL
exec sp_executesql @SQL, @ParamDefinition,
              @TransportId =  @TransportId
            , @OptKey =  @OptKey
            , @OptValue =  @OptValue



GO
/****** Object:  StoredProcedure [dbo].[_InsertIntoAddresses]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_InsertIntoAddresses] 
              @AddressID uniqueidentifier
            , @Type int
            , @County varchar(15)
            , @Country varchar(20)
            , @District varchar(25)
            , @HouseName varchar(100)
            , @CreationDate datetime
            , @HouseNumber varchar(5)
            , @PostCode varchar(9)
            , @Street1 varchar(100)
            , @Street2 varchar(100)
            , @Town varchar(25)
AS

SET NOCOUNT ON;
INSERT INTO dbo.Addresses (
                       AddressID
                      ,Type
                      ,County
                      ,Country
                      ,District
                      ,HouseName
                      ,CreationDate
                      ,HouseNumber
                      ,PostCode
                      ,Street1
                      ,Street2
                      ,Town
                      )
               VALUES (
                       @AddressID
                      ,@Type
                      ,@County
                      ,@Country
                      ,@District
                      ,@HouseName
                      ,@CreationDate
                      ,@HouseNumber
                      ,@PostCode
                      ,@Street1
                      ,@Street2
                      ,@Town
                      )


GO
/****** Object:  StoredProcedure [dbo].[_InsertIntoCO_TOKEN]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_InsertIntoCO_TOKEN] 
              @TOKEN varchar(255)
            , @DATA_CREAZIONE datetime2(3) 
            , @DATA_ULTIMO_UTILIZZO datetime2(3) 
            , @DATA_SCADENZA datetime2(3) 
            , @USERNAME varchar(20)
AS

SET NOCOUNT ON;
INSERT INTO dbo.CO_TOKEN (
                      TOKEN
                     ,DATA_CREAZIONE
                     ,DATA_ULTIMO_UTILIZZO
                     ,DATA_SCADENZA
                     ,USERNAME
                     )
              VALUES (
                      @TOKEN
                     ,@DATA_CREAZIONE
                     ,@DATA_ULTIMO_UTILIZZO
                     ,@DATA_SCADENZA
                     ,@USERNAME
                     )


GO
/****** Object:  StoredProcedure [dbo].[_InsertIntoCO01UT]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_InsertIntoCO01UT] 
              @ID uniqueidentifier
            , @UTEN varchar(20)
            , @TIPU varchar(1)
            , @PASS varchar(20)
            , @PWGG smallint
            , @PWSC datetime2(3) 
            , @NOME varchar(100)
            , @LANG varchar(3)
            , @EMAI varchar(255)
            , @TELE varchar(50)
            , @FAXN varchar(50)
            , @UFFI varchar(100)
            , @RIF1 varchar(100)
            , @RIF2 varchar(100)
            , @TELE2 varchar(100)
            , @ADR_ID uniqueidentifier
AS

SET NOCOUNT ON;
INSERT INTO dbo.CO01UT (
                    ID
                   ,UTEN
                   ,TIPU
                   ,PASS
                   ,PWGG
                   ,PWSC
                   ,NOME
                   ,LANG
                   ,EMAI
                   ,TELE
                   ,FAXN
                   ,UFFI
                   ,RIF1
                   ,RIF2
                   ,TELE2
                   ,ADR_ID
                   )
            VALUES (
                    @ID
                   ,@UTEN
                   ,@TIPU
                   ,@PASS
                   ,@PWGG
                   ,@PWSC
                   ,@NOME
                   ,@LANG
                   ,@EMAI
                   ,@TELE
                   ,@FAXN
                   ,@UFFI
                   ,@RIF1
                   ,@RIF2
                   ,@TELE2
                   ,@ADR_ID
                   )


GO
/****** Object:  StoredProcedure [dbo].[_InsertIntoReqGoodTransfer]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_InsertIntoReqGoodTransfer] 
              @Id uniqueidentifier
            , @AddressFrom uniqueidentifier
            , @AddreessDest uniqueidentifier
            , @DateTransportFixed datetime
            , @DateTransportType int
            , @DateTransportInfo nvarchar(100)
            , @RequestState int
            , @UserId uniqueidentifier
            , @VolRequired nvarchar(100)
AS

SET NOCOUNT ON;
INSERT INTO dbo.ReqGoodTransfer (
                             Id
                            ,AddressFrom
                            ,AddreessDest
                            ,DateTransportFixed
                            ,DateTransportType
                            ,DateTransportInfo
                            ,RequestState
                            ,UserId
                            ,VolRequired
                            )
                     VALUES (
                             @Id
                            ,@AddressFrom
                            ,@AddreessDest
                            ,@DateTransportFixed
                            ,@DateTransportType
                            ,@DateTransportInfo
                            ,@RequestState
                            ,@UserId
                            ,@VolRequired
                            )


GO
/****** Object:  StoredProcedure [dbo].[_InsertIntoTransportAv]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_InsertIntoTransportAv] 
              @Id uniqueidentifier
            , @AddressFrom uniqueidentifier
            , @AddreessDest uniqueidentifier
            , @DateTransportFixed datetime
            , @DateTransportType int
            , @DateTransportInfo nvarchar(100)
            , @RequestState int
            , @UserId uniqueidentifier
            , @VolAvailable nvarchar(100)
AS

SET NOCOUNT ON;
INSERT INTO dbo.TransportAv (
                         Id
                        ,AddressFrom
                        ,AddreessDest
                        ,DateTransportFixed
                        ,DateTransportType
                        ,DateTransportInfo
                        ,RequestState
                        ,UserId
                        ,VolAvailable
                        )
                 VALUES (
                         @Id
                        ,@AddressFrom
                        ,@AddreessDest
                        ,@DateTransportFixed
                        ,@DateTransportType
                        ,@DateTransportInfo
                        ,@RequestState
                        ,@UserId
                        ,@VolAvailable
                        )


GO
/****** Object:  StoredProcedure [dbo].[_InsertIntoTransportOptions]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_InsertIntoTransportOptions] 
              @TransportId uniqueidentifier
            , @OptKey nchar(30)
            , @OptValue nvarchar(MAX)
AS

SET NOCOUNT ON;
INSERT INTO dbo.TransportOptions (
                              TransportId
                             ,OptKey
                             ,OptValue
                             )
                      VALUES (
                              @TransportId
                             ,@OptKey
                             ,@OptValue
                             )


GO
/****** Object:  StoredProcedure [dbo].[_UpdateAllFieldsFromAddresses_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_UpdateAllFieldsFromAddresses_ByKeyFields] 
              @AddressID uniqueidentifier 
            , @Type int = NULL
            , @County varchar(15) = NULL
            , @Country varchar(20) = NULL
            , @District varchar(25) = NULL
            , @HouseName varchar(100) = NULL
            , @CreationDate datetime = NULL
            , @HouseNumber varchar(5) = NULL
            , @PostCode varchar(9) = NULL
            , @Street1 varchar(100) = NULL
            , @Street2 varchar(100) = NULL
            , @Town varchar(25) = NULL


AS

DECLARE @SQL nvarchar(MAX)
DECLARE @ParamDefinition NVARCHAR(MAX)
 
select @SQL = 'UPDATE dbo.Addresses SET ' 
 if @Type is  not null set @SQL =  @SQL  + ' Type  = @Type,'
 if @County is  not null set @SQL =  @SQL  + ' County  = @County,'
 if @Country is  not null set @SQL =  @SQL  + ' Country  = @Country,'
 if @District is  not null set @SQL =  @SQL  + ' District  = @District,'
 if @HouseName is  not null set @SQL =  @SQL  + ' HouseName  = @HouseName,'
 if @CreationDate is  not null set @SQL =  @SQL  + ' CreationDate  = @CreationDate,'
 if @HouseNumber is  not null set @SQL =  @SQL  + ' HouseNumber  = @HouseNumber,'
 if @PostCode is  not null set @SQL =  @SQL  + ' PostCode  = @PostCode,'
 if @Street1 is  not null set @SQL =  @SQL  + ' Street1  = @Street1,'
 if @Street2 is  not null set @SQL =  @SQL  + ' Street2  = @Street2,'
 if @Town is  not null set @SQL =  @SQL  + ' Town  = @Town,'
 SET @SQL = @SQL  +  ' WHERE AddressID = @AddressID
'
SELECT @SQL = REPLACE(@SQL, ', WHERE', ' WHERE ')
IF PATINDEX ('%SET  WHERE%', @SQL) > 0 BEGIN SELECT @SQL = 'DECLARE @I INT ' + @SQL ; SELECT @SQL = REPLACE(@SQL, 'SET', 'SET @I = 1 ') END
SET @ParamDefinition = '
              @AddressID uniqueidentifier  
            , @Type int  
            , @County varchar(15) 
            , @Country varchar(20) 
            , @District varchar(25) 
            , @HouseName varchar(100) 
            , @CreationDate datetime  
            , @HouseNumber varchar(5) 
            , @PostCode varchar(9) 
            , @Street1 varchar(100) 
            , @Street2 varchar(100) 
            , @Town varchar(25) 
'
--SELECT @SQL
exec sp_executesql @SQL, @ParamDefinition,
              @AddressID =  @AddressID
            , @Type =  @Type
            , @County =  @County
            , @Country =  @Country
            , @District =  @District
            , @HouseName =  @HouseName
            , @CreationDate =  @CreationDate
            , @HouseNumber =  @HouseNumber
            , @PostCode =  @PostCode
            , @Street1 =  @Street1
            , @Street2 =  @Street2
            , @Town =  @Town


GO
/****** Object:  StoredProcedure [dbo].[_UpdateAllFieldsFromCO_TOKEN_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_UpdateAllFieldsFromCO_TOKEN_ByKeyFields] 
              @TOKEN varchar(255) 
            , @DATA_CREAZIONE datetime2(3) = NULL
            , @DATA_ULTIMO_UTILIZZO datetime2(3) = NULL
            , @DATA_SCADENZA datetime2(3) = NULL
            , @USERNAME varchar(20) = NULL


AS

DECLARE @SQL nvarchar(MAX)
DECLARE @ParamDefinition NVARCHAR(MAX)
 
select @SQL = 'UPDATE dbo.CO_TOKEN SET ' 
 if @DATA_CREAZIONE is  not null set @SQL =  @SQL  + ' DATA_CREAZIONE  = @DATA_CREAZIONE,'
 if @DATA_ULTIMO_UTILIZZO is  not null set @SQL =  @SQL  + ' DATA_ULTIMO_UTILIZZO  = @DATA_ULTIMO_UTILIZZO,'
 if @DATA_SCADENZA is  not null set @SQL =  @SQL  + ' DATA_SCADENZA  = @DATA_SCADENZA,'
 if @USERNAME is  not null set @SQL =  @SQL  + ' USERNAME  = @USERNAME,'
 SET @SQL = @SQL  +  ' WHERE TOKEN = @TOKEN
'
SELECT @SQL = REPLACE(@SQL, ', WHERE', ' WHERE ')
IF PATINDEX ('%SET  WHERE%', @SQL) > 0 BEGIN SELECT @SQL = 'DECLARE @I INT ' + @SQL ; SELECT @SQL = REPLACE(@SQL, 'SET', 'SET @I = 1 ') END
SET @ParamDefinition = '
              @TOKEN varchar(255) 
            , @DATA_CREAZIONE datetime2(3) 
            , @DATA_ULTIMO_UTILIZZO datetime2(3) 
            , @DATA_SCADENZA datetime2(3) 
            , @USERNAME varchar(20) 
'
--SELECT @SQL
exec sp_executesql @SQL, @ParamDefinition,
              @TOKEN =  @TOKEN
            , @DATA_CREAZIONE =  @DATA_CREAZIONE
            , @DATA_ULTIMO_UTILIZZO =  @DATA_ULTIMO_UTILIZZO
            , @DATA_SCADENZA =  @DATA_SCADENZA
            , @USERNAME =  @USERNAME


GO
/****** Object:  StoredProcedure [dbo].[_UpdateAllFieldsFromCO01UT_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_UpdateAllFieldsFromCO01UT_ByKeyFields] 
              @ID uniqueidentifier 
            , @UTEN varchar(20) = NULL
            , @TIPU varchar(1) = NULL
            , @PASS varchar(20) = NULL
            , @PWGG smallint = NULL
            , @PWSC datetime2(3) = NULL
            , @NOME varchar(100) = NULL
            , @LANG varchar(3) = NULL
            , @EMAI varchar(255) = NULL
            , @TELE varchar(50) = NULL
            , @FAXN varchar(50) = NULL
            , @UFFI varchar(100) = NULL
            , @RIF1 varchar(100) = NULL
            , @RIF2 varchar(100) = NULL
            , @TELE2 varchar(100) = NULL
            , @ADR_ID uniqueidentifier = NULL


AS

DECLARE @SQL nvarchar(MAX)
DECLARE @ParamDefinition NVARCHAR(MAX)
 
select @SQL = 'UPDATE dbo.CO01UT SET ' 
 if @UTEN is  not null set @SQL =  @SQL  + ' UTEN  = @UTEN,'
 if @TIPU is  not null set @SQL =  @SQL  + ' TIPU  = @TIPU,'
 if @PASS is  not null set @SQL =  @SQL  + ' PASS  = @PASS,'
 if @PWGG is  not null set @SQL =  @SQL  + ' PWGG  = @PWGG,'
 if @PWSC is  not null set @SQL =  @SQL  + ' PWSC  = @PWSC,'
 if @NOME is  not null set @SQL =  @SQL  + ' NOME  = @NOME,'
 if @LANG is  not null set @SQL =  @SQL  + ' LANG  = @LANG,'
 if @EMAI is  not null set @SQL =  @SQL  + ' EMAI  = @EMAI,'
 if @TELE is  not null set @SQL =  @SQL  + ' TELE  = @TELE,'
 if @FAXN is  not null set @SQL =  @SQL  + ' FAXN  = @FAXN,'
 if @UFFI is  not null set @SQL =  @SQL  + ' UFFI  = @UFFI,'
 if @RIF1 is  not null set @SQL =  @SQL  + ' RIF1  = @RIF1,'
 if @RIF2 is  not null set @SQL =  @SQL  + ' RIF2  = @RIF2,'
 if @TELE2 is  not null set @SQL =  @SQL  + ' TELE2  = @TELE2,'
 if @ADR_ID is  not null set @SQL =  @SQL  + ' ADR_ID  = @ADR_ID,'
 SET @SQL = @SQL  +  ' WHERE ID = @ID
'
SELECT @SQL = REPLACE(@SQL, ', WHERE', ' WHERE ')
IF PATINDEX ('%SET  WHERE%', @SQL) > 0 BEGIN SELECT @SQL = 'DECLARE @I INT ' + @SQL ; SELECT @SQL = REPLACE(@SQL, 'SET', 'SET @I = 1 ') END
SET @ParamDefinition = '
              @ID uniqueidentifier(16)  
            , @UTEN varchar(20) 
            , @TIPU varchar(1) 
            , @PASS varchar(20) 
            , @PWGG smallint  
            , @PWSC datetime2(3) 
            , @NOME varchar(100) 
            , @LANG varchar(3) 
            , @EMAI varchar(255) 
            , @TELE varchar(50) 
            , @FAXN varchar(50) 
            , @UFFI varchar(100) 
            , @RIF1 varchar(100) 
            , @RIF2 varchar(100) 
            , @TELE2 varchar(100) 
            , @ADR_ID uniqueidentifier(16)  
'
--SELECT @SQL
exec sp_executesql @SQL, @ParamDefinition,
              @ID =  @ID
            , @UTEN =  @UTEN
            , @TIPU =  @TIPU
            , @PASS =  @PASS
            , @PWGG =  @PWGG
            , @PWSC =  @PWSC
            , @NOME =  @NOME
            , @LANG =  @LANG
            , @EMAI =  @EMAI
            , @TELE =  @TELE
            , @FAXN =  @FAXN
            , @UFFI =  @UFFI
            , @RIF1 =  @RIF1
            , @RIF2 =  @RIF2
            , @TELE2 =  @TELE2
            , @ADR_ID =  @ADR_ID


GO
/****** Object:  StoredProcedure [dbo].[_UpdateAllFieldsFromReqGoodTransfer_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_UpdateAllFieldsFromReqGoodTransfer_ByKeyFields] 
              @Id uniqueidentifier 
            , @AddressFrom uniqueidentifier = NULL
            , @AddreessDest uniqueidentifier = NULL
            , @DateTransportFixed datetime = NULL
            , @DateTransportType int = NULL
            , @DateTransportInfo nvarchar(100) = NULL
            , @RequestState int = NULL
            , @UserId uniqueidentifier = NULL
            , @VolRequired nvarchar(100) = NULL


AS

DECLARE @SQL nvarchar(MAX)
DECLARE @ParamDefinition NVARCHAR(MAX)
 
select @SQL = 'UPDATE dbo.ReqGoodTransfer SET ' 
 if @AddressFrom is  not null set @SQL =  @SQL  + ' AddressFrom  = @AddressFrom,'
 if @AddreessDest is  not null set @SQL =  @SQL  + ' AddreessDest  = @AddreessDest,'
 if @DateTransportFixed is  not null set @SQL =  @SQL  + ' DateTransportFixed  = @DateTransportFixed,'
 if @DateTransportType is  not null set @SQL =  @SQL  + ' DateTransportType  = @DateTransportType,'
 if @DateTransportInfo is  not null set @SQL =  @SQL  + ' DateTransportInfo  = @DateTransportInfo,'
 if @RequestState is  not null set @SQL =  @SQL  + ' RequestState  = @RequestState,'
 if @UserId is  not null set @SQL =  @SQL  + ' UserId  = @UserId,'
 if @VolRequired is  not null set @SQL =  @SQL  + ' VolRequired  = @VolRequired,'
 SET @SQL = @SQL  +  ' WHERE Id = @Id
'
SELECT @SQL = REPLACE(@SQL, ', WHERE', ' WHERE ')
IF PATINDEX ('%SET  WHERE%', @SQL) > 0 BEGIN SELECT @SQL = 'DECLARE @I INT ' + @SQL ; SELECT @SQL = REPLACE(@SQL, 'SET', 'SET @I = 1 ') END
SET @ParamDefinition = '
              @Id uniqueidentifier(16)  
            , @AddressFrom uniqueidentifier(16)  
            , @AddreessDest uniqueidentifier(16)  
            , @DateTransportFixed datetime  
            , @DateTransportType int  
            , @DateTransportInfo nvarchar(100) 
            , @RequestState int  
            , @UserId uniqueidentifier(16)  
            , @VolRequired nvarchar(100) 
'
--SELECT @SQL
exec sp_executesql @SQL, @ParamDefinition,
              @Id =  @Id
            , @AddressFrom =  @AddressFrom
            , @AddreessDest =  @AddreessDest
            , @DateTransportFixed =  @DateTransportFixed
            , @DateTransportType =  @DateTransportType
            , @DateTransportInfo =  @DateTransportInfo
            , @RequestState =  @RequestState
            , @UserId =  @UserId
            , @VolRequired =  @VolRequired


GO
/****** Object:  StoredProcedure [dbo].[_UpdateAllFieldsFromTransportAv_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_UpdateAllFieldsFromTransportAv_ByKeyFields] 
              @Id uniqueidentifier 
            , @AddressFrom uniqueidentifier = NULL
            , @AddreessDest uniqueidentifier = NULL
            , @DateTransportFixed datetime = NULL
            , @DateTransportType int = NULL
            , @DateTransportInfo nvarchar(100) = NULL
            , @RequestState int = NULL
            , @UserId uniqueidentifier = NULL
            , @VolAvailable nvarchar(100) = NULL


AS

DECLARE @SQL nvarchar(MAX)
DECLARE @ParamDefinition NVARCHAR(MAX)
 
select @SQL = 'UPDATE dbo.TransportAv SET ' 
 if @AddressFrom is  not null set @SQL =  @SQL  + ' AddressFrom  = @AddressFrom,'
 if @AddreessDest is  not null set @SQL =  @SQL  + ' AddreessDest  = @AddreessDest,'
 if @DateTransportFixed is  not null set @SQL =  @SQL  + ' DateTransportFixed  = @DateTransportFixed,'
 if @DateTransportType is  not null set @SQL =  @SQL  + ' DateTransportType  = @DateTransportType,'
 if @DateTransportInfo is  not null set @SQL =  @SQL  + ' DateTransportInfo  = @DateTransportInfo,'
 if @RequestState is  not null set @SQL =  @SQL  + ' RequestState  = @RequestState,'
 if @UserId is  not null set @SQL =  @SQL  + ' UserId  = @UserId,'
 if @VolAvailable is  not null set @SQL =  @SQL  + ' VolAvailable  = @VolAvailable,'
 SET @SQL = @SQL  +  ' WHERE Id = @Id
'
SELECT @SQL = REPLACE(@SQL, ', WHERE', ' WHERE ')
IF PATINDEX ('%SET  WHERE%', @SQL) > 0 BEGIN SELECT @SQL = 'DECLARE @I INT ' + @SQL ; SELECT @SQL = REPLACE(@SQL, 'SET', 'SET @I = 1 ') END
SET @ParamDefinition = '
              @Id uniqueidentifier 
            , @AddressFrom uniqueidentifier  
            , @AddreessDest uniqueidentifier 
            , @DateTransportFixed datetime  
            , @DateTransportType int  
            , @DateTransportInfo nvarchar(100) 
            , @RequestState int  
            , @UserId uniqueidentifier  
            , @VolAvailable nvarchar(100) 
'
--SELECT @SQL
exec sp_executesql @SQL, @ParamDefinition,
              @Id =  @Id
            , @AddressFrom =  @AddressFrom
            , @AddreessDest =  @AddreessDest
            , @DateTransportFixed =  @DateTransportFixed
            , @DateTransportType =  @DateTransportType
            , @DateTransportInfo =  @DateTransportInfo
            , @RequestState =  @RequestState
            , @UserId =  @UserId
            , @VolAvailable =  @VolAvailable


GO
/****** Object:  StoredProcedure [dbo].[_UpdateAllFieldsFromTransportOptions_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[_UpdateAllFieldsFromTransportOptions_ByKeyFields] 
              @TransportId uniqueidentifier 
            , @OptKey nchar(30) 
            , @OptValue nvarchar(MAX) = NULL


AS

DECLARE @SQL nvarchar(MAX)
DECLARE @ParamDefinition NVARCHAR(MAX)
 
select @SQL = 'UPDATE dbo.TransportOptions SET ' 
 if @OptValue is  not null set @SQL =  @SQL  + ' OptValue  = @OptValue,'
 SET @SQL = @SQL  +  ' WHERE TransportId = @TransportId
 AND OptKey = @OptKey
'
SELECT @SQL = REPLACE(@SQL, ', WHERE', ' WHERE ')
IF PATINDEX ('%SET  WHERE%', @SQL) > 0 BEGIN SELECT @SQL = 'DECLARE @I INT ' + @SQL ; SELECT @SQL = REPLACE(@SQL, 'SET', 'SET @I = 1 ') END
SET @ParamDefinition = '
              @TransportId uniqueidentifier(16)  
            , @OptKey nvarchar(30) 
            , @OptValue nvarchar(MAX) 
'
--SELECT @SQL
exec sp_executesql @SQL, @ParamDefinition,
              @TransportId =  @TransportId
            , @OptKey =  @OptKey
            , @OptValue =  @OptValue


GO
/****** Object:  StoredProcedure [dbo].[CO_GetAllFieldsFromCO_VW_USER_TOKEN_ByKeyFields]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CO_GetAllFieldsFromCO_VW_USER_TOKEN_ByKeyFields] 
  @TOKEN varchar(255) 
AS

SET NOCOUNT ON;
SELECT *
  FROM dbo.CO_VW_USER_TOKEN
  WHERE TOKEN = @TOKEN 


GO
/****** Object:  StoredProcedure [dbo].[zUTILS_CreateStoredFromNewTable_fix_injection]    Script Date: 14/09/2017 13:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




create PROC [dbo].[zUTILS_CreateStoredFromNewTable_fix_injection] 
@TableName varchar(256), 
@SchemaName varchar(256) = 'dbo',
@PrefixName varchar(50) = '', 
@LittleBoxDbAndUserPrefix varchar(50) = '',
@user_security_context  varchar(30) =  NULL --'CBI\utCBIAppSQL'
-- = NULL 

AS 

/**************************************************************************************
versione 2.9  Giacomo 15 gennaio 2015: tolgo set nocount on dalle update

modifica 18 ago 2014: la byalleqaulfiled viene creata con un nome diverso, in modo che si capisca che non si deve usare


MODIFICA 26/10/2006 - 12/02/2007 GIACOMO: 
-nuovi campi n/varchar(max), xml
-default NULL
-script parametrico che elimina la riga se il valore passato è NULL
-parametri SP ordinati secondo l'ordinamento delle colonne
-update dei soli campi di interesse
-gestione di IDENTITY per le insert
-gestione di MONEY con CAST(20,4) 
-gestione date con CONVERT(varchar(20), 113)


modifica giacomo 26 marzo 2009:
eliminati apici su sp di inserimento	

modifica giacomo 26 ago 2009
-gestione schema tabella	

nuova versione aprile 2010
-SQL DINAMICO USA SP_EXECUTESQL PARAMETRICO	
-@user_security_context , se NULL non usa il security context, 
altrimenti usa il nome dell'USER passato
-parametro @TOP ed @EOS , su @EOS filtro con la funzione dbo.patch_injection_EOS

modifica settembre 2010
--eliminato il parametro EOS, ingestibile
--tolto = NULL dai parametri della byallfields
--tolto TOP

modifica 29 dic 2010
-aggiunti nuovi tipi di dato SQL 2008 (date, datetime2)
-FINALMENTE messe nuove tabelle invece delle retrocompatibili SQL 2000

modifica 8 nov 2011
--tolto  execute as da insert e getbykey

modifica 29/5/2012
-- aggiunto if exists drop

modifica 25/02/2013
aggiunto SET NOCOUNT ON;

**************************************************************************************/


declare @ObjId int
select @ObjId = object_id(@SchemaName + '.' + @TableName)



/**************************************************************************************

1-	GET BY KEY FIELDS

**************************************************************************************/
select '0001','0' as column_order_id, 'USE ' +  db_name()
union
select '0002','0' as column_order_id, 'go'
union
select '0003','0' as column_order_id, 'IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'''+ @schemaName + '.' + @PrefixName + '_GetAllFieldsFrom' + @TableName + '_ByKeyFields'+ ''') AND type in (N''P'', N''PC''))
   DROP PROCEDURE ' + @schemaName + '.' + @PrefixName + '_GetAllFieldsFrom' + @TableName + '_ByKeyFields  ' + '
   GO'
union
select '0004','0' as column_order_id, 'CREATE PROC ' + @schemaName + '.' + @PrefixName + '_GetAllFieldsFrom' + @TableName + '_ByKeyFields ' 
union
select '0005',sys.index_columns.column_id as column_order_id,  space(12) + 
CASE sys.index_columns.index_column_id
WHEN '1' THEN ' ' 
ELSE ',' 
END + ' @' + 
sys.columns.name + ' ' + 
sys.types.name + 
CASE 
WHEN sys.types.name IN ('text', 'ntext', 'xml') THEN ''
WHEN sys.types.name = 'varchar' and sys.columns.max_length <> -1 THEN  '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'varchar' and sys.columns.max_length = -1 THEN  '(MAX)' --varchar(MAX)
WHEN sys.types.name = 'char' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'nvarchar' and sys.columns.max_length <> -1 THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'nvarchar' and sys.columns.max_length = -1 THEN '(MAX)' --nvachar(MAX)
WHEN sys.types.name = 'nchar' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'bit' THEN ''
WHEN sys.types.name = 'tinyint' THEN ''
WHEN sys.types.name = 'smallint' THEN ''
WHEN sys.types.name = 'int' THEN ''
WHEN sys.types.name = 'bigint' THEN ''
WHEN sys.types.name = 'smalldatetime' THEN ''
WHEN sys.types.name = 'datetime' THEN ''
WHEN sys.types.name = 'date' THEN ''	
WHEN sys.types.name = 'datetime2' THEN '(' + CONVERT(VARCHAR, sys.columns.scale) + ')'		
WHEN sys.types.name = 'timestamp' THEN '' 
WHEN sys.types.name = 'real' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'money' THEN ''
WHEN sys.types.name = 'float' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'decimal' THEN '(' + CONVERT(VARCHAR, sys.columns.precision) + ',' + CONVERT(VARCHAR, sys.columns.scale) + ')'
WHEN sys.types.name = 'numeric' THEN '(' + CONVERT(VARCHAR, sys.columns.precision) + ',' + CONVERT(VARCHAR, sys.columns.scale) + ')'
WHEN sys.types.name = 'smallmoney' THEN ''
ELSE ''
END 


FROM sys.columns 
inner join sys.indexes on sys.columns.object_id = sys.indexes.object_id
inner join  sys.index_columns 
on sys.index_columns.object_id = sys.columns.object_id 
and sys.index_columns.index_id = sys.indexes.index_id
and sys.index_columns.column_id = sys.columns.column_id 

INNER JOIN sys.types 
ON sys.columns.user_type_id = sys.types.user_type_id

where sys.columns.object_id = @ObjId 
and sys.indexes.is_primary_key = 1								
					

UNION
select '0011','0' as column_order_id,  'AS'
union 
select '0012','0' as column_order_id,  ''

union 



select '0031','0' as column_order_id,  'SET NOCOUNT ON;'
union 
select '0032','0' as column_order_id,  'SELECT *' 
union 
select '0033','0' as column_order_id,  '  FROM ' + @SchemaName + '.'  + @TableName 
union 

select '0034',sys.index_columns.index_column_id as column_order_id,  ' WHERE ' + 
sys.columns.name + ' = @' + 
sys.columns.name 
FROM sys.columns 
inner join sys.indexes on sys.columns.object_id = sys.indexes.object_id
inner join sys.index_columns 
on sys.index_columns.object_id = sys.columns.object_id
and sys.index_columns.column_id = sys.columns.column_id 
and sys.index_columns.index_id = sys.indexes.index_id

INNER JOIN sys.types ON 
sys.columns.user_type_id = sys.types.user_type_id

where sys.columns.object_id = @ObjId 

and sys.indexes.is_primary_key = 1	
and sys.index_columns.index_column_id = 1

union 

select '0035',sys.index_columns.index_column_id as column_order_id,  '   AND ' + 
sys.columns.name + ' = @' + 
sys.columns.name 
FROM sys.columns 
inner join sys.indexes on sys.columns.object_id = sys.indexes.object_id
inner join sys.index_columns 
on sys.index_columns.object_id = sys.columns.object_id 
and sys.index_columns.column_id = sys.columns.column_id 
and sys.index_columns.index_id = sys.indexes.index_id

INNER JOIN sys.types 
ON sys.columns.user_type_id = sys.types.user_type_id

where sys.index_columns.object_id = @ObjId 

and sys.indexes.is_primary_key = 1
and sys.index_columns.index_column_id > 1	

union 

select '0098', '0' as column_order_id,  ''
union 
select '0099', '0' as column_order_id,  'GO'
union 
select '0100','0' as column_order_id,   ''


union 


/**************************************************************************************

2	GET BY ALL EQUAL FIELDS 

**************************************************************************************/


select '1501','0' as column_order_id,  'USE ' +  db_name()
union
select '1502','0' as column_order_id,  'GO'
union
select '1503','0' as column_order_id, 'IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'''+ @schemaName + '.' + @PrefixName + '_NON_USARE_DO_NOT_USEGetAllFieldsFrom' + @TableName + '_BySomeEqualFields'+ ''') AND type in (N''P'', N''PC''))
   DROP PROCEDURE ' + @schemaName + '.' + @PrefixName + '_NON_USARE_DO_NOT_USEGetAllFieldsFrom' + @TableName + '_BySomeEqualFields  ' + '
   GO'
union
select '1504','0' as column_order_id,  'CREATE PROC ' + @schemaName + '.' + @PrefixName + '_NON_USARE_DO_NOT_USEGetAllFieldsFrom' + @TableName + '_BySomeEqualFields ' 
union

select '1505', sys.columns.column_id as column_order_id, space(12) + 
CASE sys.columns.column_id
WHEN '1' THEN ' ' 
ELSE ',' 
END + ' @' + 
CASE 
WHEN sys.types.name = 'char' THEN sys.columns.name + ' char(' + CONVERT(VARCHAR, sys.columns.max_length) + ') '
WHEN sys.types.name = 'nchar' THEN sys.columns.name + ' nchar(' + CONVERT(VARCHAR, sys.columns.max_length) + ') '
WHEN sys.types.name = 'varchar' and sys.columns.max_length <> -1 THEN sys.columns.name + ' varchar(' + CONVERT(VARCHAR, sys.columns.max_length) + ') '
WHEN sys.types.name = 'varchar' and sys.columns.max_length = -1 THEN sys.columns.name + ' varchar(MAX) '

WHEN sys.types.name = 'nvarchar' and sys.columns.max_length <> -1 THEN sys.columns.name + ' nvarchar(' + CONVERT(VARCHAR, sys.columns.max_length) + ') '
WHEN sys.types.name = 'nvarchar' and sys.columns.max_length = -1 THEN sys.columns.name + ' nvarchar(MAX) '

WHEN sys.types.name IN ('text','ntext', 'xml')   THEN sys.columns.name + ' ' + sys.types.name + ' '

WHEN sys.types.name IN ('decimal','numeric')   THEN sys.columns.name + ' ' + sys.types.name + ' ' 
	+  '(' + CONVERT(VARCHAR, sys.columns.precision) + ',' + CONVERT(VARCHAR, sys.columns.scale) + ') '
						

WHEN sys.types.name IN ('tinyint', 'smallint', 'int', 'bigint', 'smalldatetime', 'datetime', 'date',  'timestamp',
'real', 'money', 'smallmoney', 'bit')   
THEN sys.columns.name + ' ' + sys.types.name + '  '


WHEN sys.types.name = 'datetime2' then sys.columns.name + ' datetime2(' + CONVERT(VARCHAR, sys.columns.scale) + ') '	

ELSE sys.columns.name + ' ' + sys.types.name + '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')  '
END 
FROM sys.columns INNER JOIN
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where sys.columns.object_id = @ObjId

--union  --aggiungo il parametro top
--select '1504', '1000' as column_order_id, space(12) + ', @TOP INT  = 10'
--union --aggiungo il parametro @EOS
--select '1504', '1001' as column_order_id, space(12) + ', @EOS VARCHAR(50)   '



UNION

select '1507', '0' as column_order_id, ''
union 
select '1508', '0' as column_order_id, isnull ('WITH EXECUTE AS ''' + @user_security_context + '''', '')
union 	


select '1511', '0' as column_order_id,  'AS'
union 
select '1512', '0' as column_order_id,  '--TEMPLATE DA MODIFICARE, NON VALIDO COSI - IT IS ONLY A TEMPLATE, NOT VALID!!!!!!!!!!'
union 
select '1513', '0' as column_order_id,  'SET NOCOUNT ON;'
UNION


select '1531', '0' as column_order_id,  'DECLARE @SQL NVARCHAR(MAX)'
union 
select '1531', '1' as column_order_id,  'DECLARE @ParamDefinition NVARCHAR(MAX)'

union 
select '1531', '3' as column_order_id,  ''
union


select '1532', '0' as column_order_id,  'SELECT @SQL = ''SELECT  * FROM ' + @schemaName + '.' +  @TableName + ' WHERE 1=1 '' ' 
union 

select '1534', sys.columns.column_id as column_order_id,  'if @' + sys.columns.name + ' is not null set @SQL = @SQL + '' AND ' +  sys.columns.name + '  = @' +  sys.columns.name + ''''

FROM sys.columns INNER JOIN sys.types 
ON sys.columns.user_type_id = sys.types.user_type_id
where sys.columns.object_id = @ObjId


union

select '1534', '1000', ''
--union --patch injection su @EOS
--select '1534', '1001', 'if @EOS is not null set @SQL = @SQL +  ''  ''  + dbo.patch_injection_EOS(@EOS) ' --aggiungo @EOS

union
select '1534', '1002', ''
union


select '1535', '0', 'SET @ParamDefinition = ''' 
union
select '1535', sys.columns.column_id as column_order_id, space(12) + 
CASE sys.columns.column_id
WHEN '1' THEN ' ' 
ELSE ',' 
END + ' @' + 
CASE 
WHEN sys.types.name = 'char' THEN sys.columns.name + ' char(' + CONVERT(VARCHAR, sys.columns.max_length) + ') '
WHEN sys.types.name = 'nchar' THEN sys.columns.name + ' nvarchar(' + CONVERT(VARCHAR, sys.columns.max_length) + ') '
WHEN sys.types.name = 'varchar' and sys.columns.max_length <> -1 THEN sys.columns.name + ' varchar(' + CONVERT(VARCHAR, sys.columns.max_length) + ') '
WHEN sys.types.name = 'varchar' and sys.columns.max_length = -1 THEN sys.columns.name + ' varchar(MAX) '

WHEN sys.types.name = 'nvarchar' and sys.columns.max_length <> -1 THEN sys.columns.name + ' nvarchar(' + CONVERT(VARCHAR, sys.columns.max_length) + ') '
WHEN sys.types.name = 'nvarchar' and sys.columns.max_length = -1 THEN sys.columns.name + ' nvarchar(MAX) '

WHEN sys.types.name IN ('text','ntext', 'xml')   THEN sys.columns.name + ' ' + sys.types.name + ' '

WHEN sys.types.name IN ('decimal','numeric')   THEN sys.columns.name + ' ' + sys.types.name + ' ' 
	+  '(' + CONVERT(VARCHAR, sys.columns.precision) + ',' + CONVERT(VARCHAR, sys.columns.scale) + ') '
						

WHEN sys.types.name IN ('tinyint', 'smallint', 'int', 'bigint', 'smalldatetime', 'datetime', 'date',  'timestamp',
'real', 'money', 'smallmoney', 'bit')   
THEN sys.columns.name + ' ' + sys.types.name + '  '


WHEN sys.types.name = 'datetime2' then sys.columns.name + ' datetime2(' + CONVERT(VARCHAR, sys.columns.scale) + ') '	

ELSE sys.columns.name + ' ' + sys.types.name + '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')  '
END 
FROM sys.columns INNER JOIN
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where sys.columns.object_id = @ObjId





UNION

--SELECT '1535','1000' as column_order_id, space(12) + ', @TOP INT' 
--union
--SELECT '1535','1001' as column_order_id, space(12) + ', @EOS VARCHAR(50)' 
--union
select '1536', '1' as column_order_id, ''''


UNION

SELECT '1537','0' as column_order_id, '--SELECT @SQL' --GUARDO LA SELECT GENERATA  
UNION
SELECT '1538', '0' as column_order_id, 'exec sp_executesql @SQL, @ParamDefinition,' --LANCIO LA SELECT GENERATA  
union

select '1538', sys.columns.column_id as column_order_id, space(12) + 
CASE sys.columns.column_id
	WHEN '1' THEN ' ' 
	ELSE ',' 
END + ' @' +  sys.columns.name  + ' = ' + ' @' +  sys.columns.name
FROM sys.columns 
where object_id = @ObjId


--union
--SELECT '1538', '1000' as column_order_id, space(12) + ', @TOP = @TOP'
--union
--SELECT '1538', '1001' as column_order_id,  space(12) + ', @EOS = @EOS'
 
union


select '1598', '0' as column_order_id, ''
union 
select '1599', '0' as column_order_id, 'GO'
union 

select '1603', '0' as column_order_id,   ''


union 




/**************************************************************************************

3 SP	INSERT 

**************************************************************************************/


select '2001','0' as column_order_id,  'USE ' +  db_name()
union
select '2002', '0' as column_order_id,'go'
union
select '2003','0' as column_order_id, 'IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'''+ @schemaName + '.' + @PrefixName + '_InsertInto' + @TableName + ''') AND type in (N''P'', N''PC''))
   DROP PROCEDURE ' + @schemaName + '.' + @PrefixName + '_InsertInto' + @TableName + '
   GO'
union
select '2004', '0' as column_order_id,'CREATE PROC ' + @schemaName + '.' + @PrefixName + '_InsertInto' + @TableName + ' ' 
union

select '2005', sys.columns.column_id as column_order_id, space(12) + 
CASE 
WHEN sys.columns.column_id = '1' or ( sys.columns.column_id = '2' 
AND (SELECT CAST(S.is_identity AS INT) 
FROM SYS.COLUMNS S WHERE 
S.object_id = @ObjId AND S.COLUMN_ID  = 1 ) = 1)
THEN ' ' 
ELSE ',' 
END + ' @' + 
sys.columns.name + ' ' + 
sys.types.name + 


CASE 
WHEN sys.types.name = 'text' THEN ''
WHEN sys.types.name = 'ntext' THEN ''
WHEN sys.types.name = 'varchar' AND sys.columns.max_length <> -1 THEN  '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'varchar' AND sys.columns.max_length = -1 THEN  '(MAX)'

WHEN sys.types.name = 'char' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'nvarchar' AND sys.columns.max_length <> -1 THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'nvarchar' AND sys.columns.max_length = -1 THEN '(MAX)'

WHEN sys.types.name = 'nchar' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'bit' THEN ''
WHEN sys.types.name = 'tinyint' THEN ''
WHEN sys.types.name = 'smallint' THEN ''
WHEN sys.types.name = 'int' THEN ''
WHEN sys.types.name = 'bigint' THEN ''

WHEN sys.types.name in ('datetime', 'date', 'smalldatetime') THEN ''
WHEN sys.types.name = 'datetime2' then '(' + CONVERT(VARCHAR, sys.columns.scale) + ') '	


WHEN sys.types.name = 'timestamp' THEN '' 
WHEN sys.types.name = 'real' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name in  ('money', 'smallmoney') THEN ''
WHEN sys.types.name = 'float' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name in ('decimal', 'numeric') THEN '(' + CONVERT(VARCHAR, sys.columns.precision) + ',' + CONVERT(VARCHAR, sys.columns.scale) + ')'


ELSE ''

END 
FROM sys.columns INNER JOIN
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where object_id = @ObjId


and sys.columns.is_identity = 0

union

select '2011', '0' as column_order_id, 'AS'
union 
select '2012', '0' as column_order_id, ''

union 


select '2031', '0' as column_order_id, 'SET NOCOUNT ON;'
union 
select '2032', '0' as column_order_id, 'INSERT INTO ' + @SchemaName + '.' + @TableName + ' ('
union 
select '2033', sys.columns.column_id as column_order_id, space(12 + LEN(@TableName) + 1) + 

CASE 
WHEN sys.columns.column_id = '1' or ( sys.columns.column_id = '2' 
AND (SELECT CAST(S.is_identity AS INT) 
FROM SYS.COLUMNS S WHERE 
S.object_id = @ObjId AND S.COLUMN_ID  = 1 ) = 1)
THEN ' ' 
ELSE ',' 
END + 
sys.columns.name 
FROM sys.columns INNER JOIN
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where object_id = @ObjId
and sys.columns.is_identity = 0

union 
select '2034', '0' as column_order_id, space(12 + LEN(@TableName) + 1) + ')'
union 
select '2035', '0' as column_order_id, space(12 + LEN(@TableName) + 1 - 7) + 'VALUES ('
union 
select '2036', sys.columns.column_id as column_order_id, space(12 + LEN(@TableName) + 1) + 

CASE	
WHEN sys.columns.column_id = '1' or ( sys.columns.column_id = '2' 
AND (SELECT CAST(S.is_identity AS INT) 
FROM SYS.COLUMNS S WHERE 
S.object_id = @ObjId AND S.COLUMN_ID  = 1 ) = 1)
THEN ' ' 
ELSE ',' 
END + '@' + 
sys.columns.name 
FROM sys.columns INNER JOIN
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where object_id = @ObjId
and sys.columns.is_identity = 0 
union 
select '2037', '0' as column_order_id, space(12 + LEN(@TableName) + 1) + ')'

union 

select '2098', '0' as column_order_id, ''
union 
select '2099', '0' as column_order_id, 'GO'
union 
select '2100', '0' as column_order_id, ''

union 
select '2103', '0' as column_order_id,   ''



union 

/**************************************************************************************

4	UPDATE BY KEY FIELDS

**************************************************************************************/
select '3001', '0' as column_order_id, 'USE ' +  db_name()
union
select '3002','0' as column_order_id, 'go'
union
select '3003','0' as column_order_id, 'IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'''+ @schemaName + '.' + @PrefixName + '_UpdateAllFieldsFrom' + @TableName + '_ByKeyFields'+ ''') AND type in (N''P'', N''PC''))
   DROP PROCEDURE ' + @schemaName + '.' + @PrefixName + '_UpdateAllFieldsFrom' + @TableName + '_ByKeyFields  ' + '
   GO'
union
select '3004', '0' as column_order_id,'CREATE PROC ' + @schemaName + '.' + @PrefixName + '_UpdateAllFieldsFrom' + @TableName + '_ByKeyFields ' 
union


select '3005', sys.columns.column_id as column_order_id, space(12) + 
CASE sys.columns.column_id

when 1 THEN ' ' 
ELSE ',' 
END + ' @' + 
sys.columns.name + ' ' + 
sys.types.name + 

CASE 
WHEN sys.types.name IN ('text', 'ntext', 'xml') THEN ''
WHEN sys.types.name = 'varchar' and sys.columns.max_length <> -1 THEN  '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'varchar' and sys.columns.max_length = -1 THEN  '(MAX)' --varchar(MAX)
WHEN sys.types.name = 'char' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'nvarchar' and sys.columns.max_length <> -1 THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'nvarchar' and sys.columns.max_length = -1 THEN '(MAX)' --nvachar(MAX)
WHEN sys.types.name = 'nchar' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'bit' THEN ''
WHEN sys.types.name = 'tinyint' THEN ''
WHEN sys.types.name = 'smallint' THEN ''
WHEN sys.types.name = 'int' THEN ''
WHEN sys.types.name = 'bigint' THEN ''
WHEN sys.types.name = 'smalldatetime' THEN ''
WHEN sys.types.name = 'datetime' THEN ''
WHEN sys.types.name = 'date' THEN ''	
WHEN sys.types.name = 'datetime2' THEN '(' + CONVERT(VARCHAR, sys.columns.scale) + ')'		
WHEN sys.types.name = 'timestamp' THEN '' 
WHEN sys.types.name = 'real' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'money' THEN ''
WHEN sys.types.name = 'float' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'decimal' THEN '(' + CONVERT(VARCHAR, sys.columns.precision) + ',' + CONVERT(VARCHAR, sys.columns.scale) + ')'
WHEN sys.types.name = 'numeric' THEN '(' + CONVERT(VARCHAR, sys.columns.precision) + ',' + CONVERT(VARCHAR, sys.columns.scale) + ')'
WHEN sys.types.name = 'smallmoney' THEN ''
ELSE ''
END 			

+ 

CASE   --se sono sulla PK non posso annullare, viceversa si
WHEN	sys.columns.name IN  
(select sys.columns.name FROM sys.columns 
inner join sys.indexes on sys.columns.object_id = sys.indexes.object_id
inner join sys.index_columns 
on sys.index_columns.object_id = sys.columns.object_id 
and sys.index_columns.column_id = sys.columns.column_id 
and sys.index_columns.index_id = indexes.index_id
INNER JOIN 
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where sys.index_columns.object_id = @ObjId

and sys.indexes.is_primary_key = 1	

) 



then ' '

ELSE	' = NULL'

END


FROM sys.columns left join sys.indexes on sys.columns.object_id = sys.indexes.object_id
left join sys.index_columns on sys.columns.object_id = sys.index_columns.object_id
and sys.index_columns.column_id = sys.columns.column_id
inner join sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where sys.columns.object_id = @ObjId

union 
 
select '3007', '0' as column_order_id, ''
union 
select '3008', '0' as column_order_id, isnull ('WITH EXECUTE AS ''' + @user_security_context + '''', '')
 
 
 
 

UNION
select '3011', '0' as column_order_id, 'AS'
union 
select '3012', '0' as column_order_id, ''

union 



--select '3030', '0' as column_order_id, 'SET NOCOUNT ON;'
--union 

select '3031', '0' as column_order_id, 'DECLARE @SQL nvarchar(MAX)'
union 
select '3031', '1' as column_order_id,  'DECLARE @ParamDefinition NVARCHAR(MAX)'
union
select '3031', '2' as column_order_id,  ' '
union


select '3032', '0' as column_order_id, 'select @SQL = ''UPDATE ' + @SchemaName + '.' + @TableName + ' SET '' '    
union 

select '3033', sys.columns.column_id as column_order_id, ' if @' +  sys.columns.name + ' is  not null set @SQL =  @SQL  + '' '   + sys.columns.name + '  = @' +  sys.columns.name + ',''' 
FROM sys.columns INNER JOIN sys.types 
ON sys.columns.user_type_id = sys.types.user_type_id
 where sys.columns.object_id = @ObjId

--non sono nella PK
and sys.columns.name not IN  (
select sys.columns.name FROM sys.columns 
inner join sys.indexes on sys.columns.object_id = sys.indexes.object_id 
inner join 
sys.index_columns 
on sys.index_columns.object_id = sys.columns.object_id 
and sys.index_columns.column_id = sys.columns.column_id 
and sys.index_columns.index_id = sys.indexes.index_id 

INNER JOIN
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where sys.index_columns.object_id = @ObjId 
and sys.indexes.is_primary_key = 1)


union 
select '3035',  sys.index_columns.index_column_id as column_order_id, 
CASE sys.index_columns.index_column_id --prima colonna dell'indice della PK
WHEN '1' THEN  	' SET @SQL = @SQL  +  '' WHERE ' 
ELSE ' AND ' 
END
+ sys.columns.name + ' = @' +  sys.columns.name


FROM sys.columns inner join  sys.indexes on sys.columns.object_id = sys.indexes.object_id 
inner join sys.index_columns 
on sys.index_columns.object_id = sys.columns.object_id 
and sys.index_columns.column_id = sys.columns.column_id 
and sys.index_columns.index_id = sys.indexes.index_id
INNER JOIN
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where sys.index_columns.object_id = @ObjId 
and sys.indexes.is_primary_key = 1

union 


select '3048', '0' as column_order_id, ''''
union

select '3049', '0' as column_order_id, 'SELECT @SQL = REPLACE(@SQL, '', WHERE'', '' WHERE '')'
union
select '3050', '0' as column_order_id, 'IF PATINDEX (''%SET  WHERE%'', @SQL) > 0 BEGIN SELECT @SQL = ''DECLARE @I INT '' + @SQL ; SELECT @SQL = REPLACE(@SQL, ''SET'', ''SET @I = 1 '') END'
union

select '3060', '0', 'SET @ParamDefinition = ''' 
union
select '3060', sys.columns.column_id as column_order_id, space(12) + 
CASE sys.columns.column_id
	WHEN '1' THEN ' ' 
	ELSE ',' 
END + ' @' + 
CASE 
WHEN sys.types.name = 'char' THEN sys.columns.name + ' char(' + CONVERT(VARCHAR, sys.columns.max_length) + ') '
WHEN sys.types.name = 'nchar' THEN sys.columns.name + ' nvarchar(' + CONVERT(VARCHAR, sys.columns.max_length) + ') '
WHEN sys.types.name = 'varchar' and sys.columns.max_length <> -1 THEN sys.columns.name + ' varchar(' + CONVERT(VARCHAR, sys.columns.max_length) + ') '
WHEN sys.types.name = 'varchar' and sys.columns.max_length = -1 THEN sys.columns.name + ' varchar(MAX) '

WHEN sys.types.name = 'nvarchar' and sys.columns.max_length <> -1 THEN sys.columns.name + ' nvarchar(' + CONVERT(VARCHAR, sys.columns.max_length) + ') '
WHEN sys.types.name = 'nvarchar' and sys.columns.max_length = -1 THEN sys.columns.name + ' nvarchar(MAX) '

WHEN sys.types.name IN ('text','ntext', 'xml')   THEN sys.columns.name + ' ' + sys.types.name + ' '

WHEN sys.types.name IN ('decimal','numeric')   THEN sys.columns.name + ' ' + sys.types.name + ' ' 
	+  '(' + CONVERT(VARCHAR, sys.columns.precision) + ',' + CONVERT(VARCHAR, sys.columns.scale) + ') '
						

WHEN sys.types.name IN ('tinyint', 'smallint', 'int', 'bigint', 'smalldatetime', 'datetime', 'date',  'timestamp',
'real', 'money', 'smallmoney', 'bit')   
THEN sys.columns.name + ' ' + sys.types.name + '  '


WHEN sys.types.name = 'datetime2' then sys.columns.name + ' datetime2(' + CONVERT(VARCHAR, sys.columns.scale) + ') '	

ELSE sys.columns.name + ' ' + sys.types.name + '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')  '
END 
FROM sys.columns INNER JOIN
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where sys.columns.object_id = @ObjId

union
select '3061', '0' as column_order_id, ''''
union


select '3065', '0' as column_order_id, '--SELECT @SQL'
union

SELECT '3070', '0' as column_order_id, 'exec sp_executesql @SQL, @ParamDefinition,' --LANCIO LA SELECT GENERATA  
union

select '3070', sys.columns.column_id as column_order_id, space(12) + 
CASE sys.columns.column_id
	WHEN '1' THEN ' ' 
	ELSE ',' 
END + ' @' +  sys.columns.name  + ' = ' + ' @' +  sys.columns.name
FROM sys.columns 
where object_id = @ObjId

union

select '3098',  '0' as column_order_id, ''
union 
select '3099', '0' as column_order_id, 'GO'
union 

select '3103', '0' as column_order_id,   ''


union 
/**************************************************************************************

5	DELETE Stored (based on KEY fields)

**************************************************************************************/
select '4001', '0' as column_order_id, 'USE ' +  db_name()
union
select '4002','0' as column_order_id, 'go'
union
select '4003','0' as column_order_id, 'IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'''+ @schemaName + '.' + @PrefixName + '_DeleteFrom' + @TableName + '_ByKeyFields'+ ''') AND type in (N''P'', N''PC''))
   DROP PROCEDURE ' + @schemaName + '.' + @PrefixName + '_DeleteFrom' + @TableName + '_ByKeyFields  ' + '
   GO'
union
select '4004', '0' as column_order_id,'CREATE PROC ' + @schemaName + '.' + @PrefixName + '_DeleteFrom' + @TableName + '_ByKeyFields ' 
union
select '4005', sys.index_columns.index_column_id as column_order_id, space(12) + 
CASE sys.index_columns.index_column_id
WHEN '1' THEN ' ' 
ELSE ',' 
END + ' @' + 
sys.columns.name + ' ' + 
sys.types.name + 
CASE 
WHEN sys.types.name IN ('text', 'ntext', 'xml') THEN ''
WHEN sys.types.name = 'varchar' and sys.columns.max_length <> -1 THEN  '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'varchar' and sys.columns.max_length = -1 THEN  '(MAX)' --varchar(MAX)
WHEN sys.types.name = 'char' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'nvarchar' and sys.columns.max_length <> -1 THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'nvarchar' and sys.columns.max_length = -1 THEN '(MAX)' --nvachar(MAX)
WHEN sys.types.name = 'nchar' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'bit' THEN ''
WHEN sys.types.name = 'tinyint' THEN ''
WHEN sys.types.name = 'smallint' THEN ''
WHEN sys.types.name = 'int' THEN ''
WHEN sys.types.name = 'bigint' THEN ''
WHEN sys.types.name = 'smalldatetime' THEN ''
WHEN sys.types.name = 'datetime' THEN ''
WHEN sys.types.name = 'date' THEN ''	
WHEN sys.types.name = 'datetime2' THEN '(' + CONVERT(VARCHAR, sys.columns.scale) + ')'		
WHEN sys.types.name = 'timestamp' THEN '' 
WHEN sys.types.name = 'real' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'money' THEN ''
WHEN sys.types.name = 'float' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'decimal' THEN '(' + CONVERT(VARCHAR, sys.columns.precision) + ',' + CONVERT(VARCHAR, sys.columns.scale) + ')'
WHEN sys.types.name = 'numeric' THEN '(' + CONVERT(VARCHAR, sys.columns.precision) + ',' + CONVERT(VARCHAR, sys.columns.scale) + ')'
WHEN sys.types.name = 'smallmoney' THEN ''
ELSE ''
END 
FROM sys.columns inner join sys.indexes on sys.columns.object_id = sys.indexes.object_id 
inner join sys.index_columns 
on sys.index_columns.object_id = sys.columns.object_id 
and sys.index_columns.column_id = sys.columns.column_id 
and sys.index_columns.index_id = sys.indexes.index_id
INNER JOIN sys.types ON sys.columns.user_type_id = sys.types.user_type_id

where sys.index_columns.object_id = @ObjId 
and sys.indexes.is_primary_key = 1

UNION
select '4011', '0' as column_order_id, 'AS'
union 
select '4012', '0' as column_order_id, ''

union 

select '4027', '0' as column_order_id, ' '
union
select '4028', '0' as column_order_id, ' '
union



select '4031', '0' as column_order_id, 'SET NOCOUNT ON;'
union 
select '4032', '0' as column_order_id, 'DELETE' 
union 
select '4033', '0' as column_order_id, '  FROM ' + @schemaname + '.' + @TableName 
union 
select '4034', sys.index_columns.index_column_id as column_order_id, ' WHERE ' + 
sys.columns.name + ' = @' + 
sys.columns.name 
FROM sys.columns 
inner join sys.indexes on sys.columns.object_id = sys.indexes.object_id
inner join sys.index_columns 
on sys.index_columns.object_id = sys.columns.object_id 
and sys.index_columns.column_id = sys.columns.column_id 
and sys.index_columns.index_id = sys.indexes.index_id
INNER JOIN
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where sys.index_columns.object_id = @ObjId 
and sys.indexes.is_primary_key = 1
AND sys.index_columns.index_column_id = 1


union 
select '4035', sys.index_columns.index_column_id as column_order_id, '   AND ' + 
sys.columns.name + ' = @' + 
sys.columns.name 
FROM sys.columns inner join sys.indexes on sys.columns.object_id = sys.indexes.object_id 
inner join  sys.index_columns 
on sys.index_columns.object_id = sys.columns.object_id 
and sys.index_columns.column_id = sys.columns.column_id 
and sys.index_columns.index_id = sys.indexes.index_id

INNER JOIN
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where sys.index_columns.object_id = @ObjId 
and sys.indexes.is_primary_key = 1
AND sys.index_columns.index_column_id > 1

union 

select '4098', '0' as column_order_id, ''
union 
select '4099', '0' as column_order_id, 'GO'
union 

select '4103', '0' as column_order_id,   ''


order by 1,2


/********************************************************************************************************************

-- SP SCATOLINE

**********************************************************************************************************************/



select '0000', '0' as column_order_id, '-- SCATOLINE -- '
union 
select '0000','1' as column_order_id, 'GO' 
union

/**************************************************************************************

1 GET BY KEY FIELDS

**************************************************************************************/
select '0002', '0' as column_order_id,'  '
union
select '0003','0' as column_order_id, 'IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'''+ @schemaName + '.' + @PrefixName + '_GetAllFieldsFrom' + @TableName + '_ByKeyFields'+ ''') AND type in (N''P'', N''PC''))
   DROP PROCEDURE ' + @schemaName + '.' + @PrefixName + '_GetAllFieldsFrom' + @TableName + '_ByKeyFields  ' + '
   GO'
union
select '0004', '0' as column_order_id,'CREATE PROC ' + @schemaName + '.' + @PrefixName + '_GetAllFieldsFrom' + @TableName + '_ByKeyFields ' 
union
select '0005', sys.columns.column_id as column_order_id, space(12) + 
CASE sys.index_columns.index_column_id
WHEN '1' THEN ' ' 
ELSE ',' 
END + ' @' + 
sys.columns.name + ' ' + 
sys.types.name + 
CASE 
WHEN sys.types.name IN ('text', 'ntext', 'xml') THEN ''
WHEN sys.types.name = 'varchar' and sys.columns.max_length <> -1 THEN  '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'varchar' and sys.columns.max_length = -1 THEN  '(MAX)' --varchar(MAX)
WHEN sys.types.name = 'char' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'nvarchar' and sys.columns.max_length <> -1 THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'nvarchar' and sys.columns.max_length = -1 THEN '(MAX)' --nvachar(MAX)
WHEN sys.types.name = 'nchar' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'bit' THEN ''
WHEN sys.types.name = 'tinyint' THEN ''
WHEN sys.types.name = 'smallint' THEN ''
WHEN sys.types.name = 'int' THEN ''
WHEN sys.types.name = 'bigint' THEN ''
WHEN sys.types.name = 'smalldatetime' THEN ''
WHEN sys.types.name = 'datetime' THEN ''
WHEN sys.types.name = 'date' THEN ''	
WHEN sys.types.name = 'datetime2' THEN '(' + CONVERT(VARCHAR, sys.columns.scale) + ')'		
WHEN sys.types.name = 'timestamp' THEN '' 
WHEN sys.types.name = 'real' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'money' THEN ''
WHEN sys.types.name = 'float' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'decimal' THEN '(' + CONVERT(VARCHAR, sys.columns.precision) + ',' + CONVERT(VARCHAR, sys.columns.scale) + ')'
WHEN sys.types.name = 'numeric' THEN '(' + CONVERT(VARCHAR, sys.columns.precision) + ',' + CONVERT(VARCHAR, sys.columns.scale) + ')'
WHEN sys.types.name = 'smallmoney' THEN ''
ELSE ''
END 

FROM sys.columns 
inner join sys.indexes on sys.columns.object_id = sys.indexes.object_id
inner join  sys.index_columns 
on sys.index_columns.object_id = sys.columns.object_id 
and sys.index_columns.index_id = sys.indexes.index_id
and sys.index_columns.column_id = sys.columns.column_id 


INNER JOIN sys.types 
ON sys.columns.user_type_id = sys.types.user_type_id

where sys.columns.object_id = @ObjId 
and sys.indexes.is_primary_key = 1		




UNION

select '0011', '0' as column_order_id, 'AS'
union 
select '0012', '0' as column_order_id, ''

union 


select '0027', '0' as column_order_id, ' '
union
select '0028', '0' as column_order_id, ' '
union

select '0031', '0' as column_order_id, ''
union 
select '0032', '0' as column_order_id,'EXEC ' + @LittleBoxDbAndUserPrefix + '.' + @schemaName + '.' + @PrefixName + '_GetAllFieldsFrom' + @TableName + '_ByKeyFields ' 
union
select '0033', sys.columns.column_id  as column_order_id, space(12) + 
CASE sys.index_columns.index_column_id
WHEN '1' THEN ' ' 
ELSE ',' 
END + ' @' + 
sys.columns.name + ' = @' + sys.columns.name

FROM sys.columns inner join sys.indexes on sys.columns.object_id = sys.indexes.object_id
inner join 	  sys.index_columns 
on sys.index_columns.object_id = sys.columns.object_id 
and sys.index_columns.column_id = sys.columns.column_id 
and sys.index_columns.index_id = sys.indexes.index_id

INNER JOIN
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where sys.columns.object_id = @ObjId 
and sys.indexes.is_primary_key = 1
 
union 

select '0098',  '0' as column_order_id,''
union 
select '0099',  '0' as column_order_id,'GO'
union 
select '0100', '0' as column_order_id, ''


union


/**************************************************************************************

2 GET BY ALL EQUAL FIELDS

**************************************************************************************/

select '1502', '0' as column_order_id,'go'
union
select '1503','0' as column_order_id, 'IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'''+ @schemaName + '.' + @PrefixName + '_NON_USARE_DO_NOT_USEGetAllFieldsFrom' + @TableName + '_BySomeEqualFields'+ ''') AND type in (N''P'', N''PC''))
   DROP PROCEDURE ' + @schemaName + '.' + @PrefixName + '_NON_USARE_DO_NOT_USEGetAllFieldsFrom' + @TableName + '_BySomeEqualFields  ' + '
   GO'
union
select '1504', '0' as column_order_id,'CREATE PROC ' + @schemaName + '.' + @PrefixName + '_NON_USARE_DO_NOT_USEGetAllFieldsFrom' + @TableName + '_BySomeEqualFields ' 
union
select '1505', sys.columns.column_id as column_order_id, space(12) + 
CASE sys.columns.column_id
WHEN '1' THEN ' ' 
ELSE ',' 
END + ' @' + 
CASE 
WHEN sys.types.name = 'char' THEN sys.columns.name + ' char(' + CONVERT(VARCHAR, sys.columns.max_length) + ') '
WHEN sys.types.name = 'nchar' THEN sys.columns.name + ' nvarchar(' + CONVERT(VARCHAR, sys.columns.max_length) + ') '
WHEN sys.types.name = 'varchar' and sys.columns.max_length <> -1 THEN sys.columns.name + ' varchar(' + CONVERT(VARCHAR, sys.columns.max_length) + ') '
WHEN sys.types.name = 'varchar' and sys.columns.max_length = -1 THEN sys.columns.name + ' varchar(MAX) '

WHEN sys.types.name = 'nvarchar' and sys.columns.max_length <> -1 THEN sys.columns.name + ' nvarchar(' + CONVERT(VARCHAR, sys.columns.max_length) + ') '
WHEN sys.types.name = 'nvarchar' and sys.columns.max_length = -1 THEN sys.columns.name + ' nvarchar(MAX) '

WHEN sys.types.name IN ('text','ntext', 'xml')   THEN sys.columns.name + ' ' + sys.types.name + ' '

WHEN sys.types.name IN ('decimal','numeric')   THEN sys.columns.name + ' ' + sys.types.name + ' ' 
	+  '(' + CONVERT(VARCHAR, sys.columns.precision) + ',' + CONVERT(VARCHAR, sys.columns.scale) + ') '
						

WHEN sys.types.name IN ('tinyint', 'smallint', 'int', 'bigint', 'smalldatetime', 'datetime', 'date',  'timestamp',
'real', 'money', 'smallmoney', 'bit')   
THEN sys.columns.name + ' ' + sys.types.name + '  '


WHEN sys.types.name = 'datetime2' then sys.columns.name + ' datetime2(' + CONVERT(VARCHAR, sys.columns.scale) + ') '	

ELSE sys.columns.name + ' ' + sys.types.name + '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')  '

END 
FROM sys.columns INNER JOIN
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where sys.columns.object_id = @ObjId


--union  --aggiungo il parametro top
--select '1504', '1000' as column_order_id, space(12) + ', @TOP INT  = 10'
--union --aggiungo il parametro @EOS
--select '1504', '1001' as column_order_id, space(12) + ', @EOS VARCHAR(MAX)  = NULL'




UNION

select '1511', '0' as column_order_id, 'AS'
union 
select '1512', '0' as column_order_id, ''

union 

select '1527', '0' as column_order_id, ' '
union
select '1528', '0' as column_order_id, ' '
union

select '1531', '0' as column_order_id, ''
union 
select '1532', '0' as column_order_id,'EXEC ' + @LittleBoxDbAndUserPrefix + '.' + @schemaName + '.' + @PrefixName + '_NON_USARE_DO_NOT_USEGetAllFieldsFrom' + @TableName + '_BySomeEqualFields ' 
union
select '1533', sys.columns.column_id as column_order_id,  space(12) + 
CASE sys.columns.column_id
WHEN '1' THEN ' ' 
ELSE ',' 
END +  ' @' + sys.columns.name + ' = @' +  sys.columns.name

FROM sys.columns INNER JOIN
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where sys.columns.object_id = @ObjId

 
 
 
--union  --aggiungo il parametro top
--select '1533', '1000' as column_order_id, space(12) + ', @TOP = @TOP'
--union --aggiungo il parametro @EOS
--select '1533', '1001' as column_order_id, space(12) + ', @EOS = @EOS'




union 

select '1598', '0' as column_order_id, ''
union 
select '1599', '0' as column_order_id, 'GO'
union 
select '1603', '0' as column_order_id,   ''








union
/**************************************************************************************

3 INSERT

**************************************************************************************/
select '3002','0' as column_order_id, 'go'
union
select '2003','0' as column_order_id, 'IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'''+ @schemaName + '.' + @PrefixName + '_InsertInto' + @TableName + ''') AND type in (N''P'', N''PC''))
   DROP PROCEDURE ' + @schemaName + '.' + @PrefixName + '_InsertInto' + @TableName + '
   GO'
union
select '2004', '0' as column_order_id,'CREATE PROC ' + @schemaName + '.' + @PrefixName + '_InsertInto' + @TableName + ' ' 
union
select '2005',sys.columns.column_id as column_order_id,  space(12) + 
CASE 
WHEN sys.columns.column_id = '1' or ( sys.columns.column_id = '2' 
AND (SELECT CAST(S.is_identity AS INT) 
FROM SYS.COLUMNS S WHERE 
S.object_id = @ObjId AND S.COLUMN_ID  = 1 ) = 1)

THEN ' ' 

ELSE ',' 
END + ' @' + 
sys.columns.name + ' ' + 
sys.types.name + 
CASE 
WHEN sys.types.name = 'text' THEN ''
WHEN sys.types.name = 'ntext' THEN ''
WHEN sys.types.name = 'varchar' AND sys.columns.max_length <> -1 THEN  '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'varchar' AND sys.columns.max_length = -1 THEN  '(MAX)'

WHEN sys.types.name = 'char' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'nvarchar' AND sys.columns.max_length <> -1 THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'nvarchar' AND sys.columns.max_length = -1 THEN '(MAX)'

WHEN sys.types.name = 'nchar' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'bit' THEN ''
WHEN sys.types.name = 'tinyint' THEN ''
WHEN sys.types.name = 'smallint' THEN ''
WHEN sys.types.name = 'int' THEN ''
WHEN sys.types.name = 'bigint' THEN ''

WHEN sys.types.name in ('datetime', 'date', 'smalldatetime') THEN ''
WHEN sys.types.name = 'datetime2' then '(' + CONVERT(VARCHAR, sys.columns.scale) + ') '	


WHEN sys.types.name = 'timestamp' THEN '' 
WHEN sys.types.name = 'real' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name in  ('money', 'smallmoney') THEN ''
WHEN sys.types.name = 'float' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name in ('decimal', 'numeric') THEN '(' + CONVERT(VARCHAR, sys.columns.precision) + ',' + CONVERT(VARCHAR, sys.columns.scale) + ')'


ELSE ''
END 

FROM sys.columns INNER JOIN
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where object_id = @ObjId
and sys.columns.is_identity = 0 --gestione delle identity



UNION

select '2011',  '0' as column_order_id, 'AS'
union 
select '2012',  '0' as column_order_id, ''

union 

select '2027', '0' as column_order_id, ' '
union
select '2028', '0' as column_order_id, ' '
union


select '2031',  '0' as column_order_id, ''
union 
select '2032',  '0' as column_order_id,'EXEC ' + @LittleBoxDbAndUserPrefix + '.' + @schemaName + '.' + @PrefixName + '_InsertInto' + @TableName + ' ' 
union
select '2033', sys.columns.column_id as column_order_id, space(12) + 
CASE 
WHEN sys.columns.column_id = '1' or ( sys.columns.column_id = '2' 
AND (SELECT CAST(S.is_identity AS INT) 
FROM SYS.COLUMNS S WHERE 
S.object_id = @ObjId AND S.COLUMN_ID  = 1 ) = 1)

THEN ' ' 
ELSE ',' 
END + ' @' + 
sys.columns.name + ' = @' + sys.columns.name

FROM sys.columns INNER JOIN
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where object_id = @ObjId
and sys.columns.is_identity = 0 --gestione delle identity




union 

select '2098',  '0' as column_order_id, ''
union 
select '2099',  '0' as column_order_id, 'GO'
union 
select '2100',  '0' as column_order_id, ''
union 

select '2103', '0' as column_order_id,   ''



union
/**************************************************************************************

4 UPDATE

**************************************************************************************/
select '3002',  '0' as column_order_id,'go'
union
select '3003','0' as column_order_id, 'IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'''+ @schemaName + '.' + @PrefixName + '_UpdateAllFieldsFrom' + @TableName + '_ByKeyFields'+ ''') AND type in (N''P'', N''PC''))
   DROP PROCEDURE ' + @schemaName + '.' + @PrefixName + '_UpdateAllFieldsFrom' + @TableName + '_ByKeyFields  ' + '
   GO'
union
select '3004',  '0' as column_order_id,'CREATE PROC ' + @schemaName + '.' + @PrefixName + '_UpdateAllFieldsFrom' + @TableName + '_ByKeyFields ' 
union

select '3005', sys.columns.column_id as column_order_id, space(12) + 
CASE sys.columns.column_id
WHEN '1' THEN ' ' 
ELSE ',' 
END + ' @' + 
sys.columns.name + ' ' + 
sys.types.name + 

CASE 
WHEN sys.types.name IN ('text', 'ntext', 'xml') THEN ''
WHEN sys.types.name = 'varchar' and sys.columns.max_length <> -1 THEN  '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'varchar' and sys.columns.max_length = -1 THEN  '(MAX)' --varchar(MAX)
WHEN sys.types.name = 'char' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'nvarchar' and sys.columns.max_length <> -1 THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'nvarchar' and sys.columns.max_length = -1 THEN '(MAX)' --nvachar(MAX)
WHEN sys.types.name = 'nchar' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'bit' THEN ''
WHEN sys.types.name = 'tinyint' THEN ''
WHEN sys.types.name = 'smallint' THEN ''
WHEN sys.types.name = 'int' THEN ''
WHEN sys.types.name = 'bigint' THEN ''
WHEN sys.types.name = 'smalldatetime' THEN ''
WHEN sys.types.name = 'datetime' THEN ''
WHEN sys.types.name = 'date' THEN ''	
WHEN sys.types.name = 'datetime2' THEN '(' + CONVERT(VARCHAR, sys.columns.scale) + ')'		
WHEN sys.types.name = 'timestamp' THEN '' 
WHEN sys.types.name = 'real' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'money' THEN ''
WHEN sys.types.name = 'float' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'decimal' THEN '(' + CONVERT(VARCHAR, sys.columns.precision) + ',' + CONVERT(VARCHAR, sys.columns.scale) + ')'
WHEN sys.types.name = 'numeric' THEN '(' + CONVERT(VARCHAR, sys.columns.precision) + ',' + CONVERT(VARCHAR, sys.columns.scale) + ')'
WHEN sys.types.name = 'smallmoney' THEN ''
ELSE ''
END 			

+ 

CASE   --se sono sulla PK non posso annullare, viceversa si
WHEN	sys.columns.name IN  
(select sys.columns.name FROM sys.columns 
inner join sys.indexes on sys.columns.object_id = sys.indexes.object_id
inner join sys.index_columns 
on sys.index_columns.object_id = sys.columns.object_id 
and sys.index_columns.column_id = sys.columns.column_id 
and sys.index_columns.index_id = sys.indexes.index_id

INNER JOIN 
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where sys.index_columns.object_id = object_id (@schemaname + '.' + @TableName)

and sys.indexes.is_primary_key = 1	

) 



then ' '

ELSE	' = NULL'

END


FROM sys.columns INNER JOIN
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where sys.columns.object_id = @ObjId

union 
 
select '3007', '0' as column_order_id, ''
union 
select '3008', '0' as column_order_id, isnull ('WITH EXECUTE AS ''' + @user_security_context + '''', '')
 
 
 
 

UNION
select '3011', '0' as column_order_id, 'AS'
union 
select '3012', '0' as column_order_id, ''

union 




select '3027', '0' as column_order_id, ' '
union
select '3028', '0' as column_order_id, ' '
union


select '3031',  '0' as column_order_id, ''
union 
select '3032',  '0' as column_order_id,'EXEC ' + @LittleBoxDbAndUserPrefix +  '.' + @schemaName + '.' + @PrefixName + '_UpdateAllFieldsFrom' + @TableName + '_ByKeyFields ' 
union
select '3033',sys.columns.column_id as column_order_id, space(12) + 
		CASE sys.columns.column_id
			WHEN '1' THEN ' ' 
			ELSE ',' 
		END + ' @' + 
		sys.columns.name + ' = @' + sys.columns.name
  FROM sys.columns INNER JOIN
                      sys.types ON sys.columns.user_type_id = sys.types.user_type_id
 where sys.columns.object_id = @ObjId

union 

select '3098', '0' as column_order_id, ''
union 
select '3099', '0' as column_order_id, 'GO'
union 
select '3100', '0' as column_order_id, ''
union 

select '3103', '0' as column_order_id,   ''


union
/**************************************************************************************

5 DELETE BY KEY

**************************************************************************************/
select '4002', '0' as column_order_id,'go'
union
select '4003','0' as column_order_id, 'IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'''+ @schemaName + '.' + @PrefixName + '_DeleteFrom' + @TableName + '_ByKeyFields'+ ''') AND type in (N''P'', N''PC''))
   DROP PROCEDURE ' + @schemaName + '.' + @PrefixName + '_DeleteFrom' + @TableName + '_ByKeyFields  ' + '
   GO'
union
select '4004', '0' as column_order_id,'CREATE PROC ' + @schemaName + '.' + @PrefixName + '_DeleteFrom' + @TableName + '_ByKeyFields ' 
union
select '4005', sys.columns.column_id  as column_order_id, space(12) + 
CASE sys.index_columns.index_column_id
WHEN '1' THEN ' ' 
ELSE ',' 
END + ' @' + 
sys.columns.name + ' ' + 
sys.types.name + 
CASE 
WHEN sys.types.name IN ('text', 'ntext', 'xml') THEN ''
WHEN sys.types.name = 'varchar' and sys.columns.max_length <> -1 THEN  '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'varchar' and sys.columns.max_length = -1 THEN  '(MAX)' --varchar(MAX)
WHEN sys.types.name = 'char' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'nvarchar' and sys.columns.max_length <> -1 THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'nvarchar' and sys.columns.max_length = -1 THEN '(MAX)' --nvachar(MAX)
WHEN sys.types.name = 'nchar' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'bit' THEN ''
WHEN sys.types.name = 'tinyint' THEN ''
WHEN sys.types.name = 'smallint' THEN ''
WHEN sys.types.name = 'int' THEN ''
WHEN sys.types.name = 'bigint' THEN ''
WHEN sys.types.name = 'smalldatetime' THEN ''
WHEN sys.types.name = 'datetime' THEN ''
WHEN sys.types.name = 'date' THEN ''	
WHEN sys.types.name = 'datetime2' THEN '(' + CONVERT(VARCHAR, sys.columns.scale) + ')'		
WHEN sys.types.name = 'timestamp' THEN '' 
WHEN sys.types.name = 'real' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'money' THEN ''
WHEN sys.types.name = 'float' THEN '(' + CONVERT(VARCHAR, sys.columns.max_length) + ')'
WHEN sys.types.name = 'decimal' THEN '(' + CONVERT(VARCHAR, sys.columns.precision) + ',' + CONVERT(VARCHAR, sys.columns.scale) + ')'
WHEN sys.types.name = 'numeric' THEN '(' + CONVERT(VARCHAR, sys.columns.precision) + ',' + CONVERT(VARCHAR, sys.columns.scale) + ')'
WHEN sys.types.name = 'smallmoney' THEN ''
ELSE ''
END 
FROM sys.columns inner join sys.indexes 
on sys.columns.object_id = sys.indexes.object_id
inner join sys.index_columns 
on sys.index_columns.object_id = sys.columns.object_id
and sys.index_columns.column_id = sys.columns.column_id 
and sys.index_columns.index_id = sys.indexes.index_id
 
INNER JOIN
sys.types ON sys.columns.user_type_id = sys.types.user_type_id
where sys.index_columns.object_id = @ObjId 
and sys.indexes.is_primary_key = 1

UNION
select '4011', '0' as column_order_id, 'AS'
union 
select '4012', '0' as column_order_id, ''

union 

--select '4021', '0' as column_order_id, '/**************************************************************************************'
--union 
--select '4022', '0' as column_order_id, space(12) + 'LittleBOX - Delete from table ' + @TableName 
--union 
--select '4023', '0' as column_order_id, space(12) + '(using PRIMARY KEY fields)'
--union 
--select '4024', '0' as column_order_id, '**************************************************************************************/'
--
--union 

select '4027', '0' as column_order_id, ' '
union
select '4028', '0' as column_order_id, ' '
union

select '4031', '0' as column_order_id, ''
union 
select '4032', '0' as column_order_id,'EXEC ' + @LittleBoxDbAndUserPrefix + '.' + @schemaName + '.' + @PrefixName + '_DeleteFrom' + @TableName + '_ByKeyFields ' 
union
select '4033', sys.columns.column_id as column_order_id, space(12) + 
		CASE sys.index_columns.index_column_id
			WHEN '1' THEN ' ' 
			ELSE ',' 
		END + ' @' + 
		sys.columns.name + ' = @' + sys.columns.name
  FROM sys.columns inner join sys.indexes on sys.columns.object_id = sys.indexes.object_id
  inner join 		  sys.index_columns 
  on sys.index_columns.object_id = sys.columns.object_id 
  and sys.index_columns.column_id = sys.columns.column_id 
  and sys.index_columns.index_id = sys.indexes.index_id

			INNER JOIN
                      	sys.types ON sys.columns.user_type_id = sys.types.user_type_id
 where sys.index_columns.object_id = @ObjId 
 and sys.indexes.is_primary_key = 1

union 

select '4098', '0' as column_order_id, ''
union 
select '4099', '0' as column_order_id, 'GO'
union 
select '4100', '0' as column_order_id, ''
--union 
--select '4101', '0' as column_order_id,  'GRANT  EXECUTE  ON [dbo].['+ @PrefixName + '_DeleteFrom' + @TableName + '_ByKeyFields]  TO [Esegui$stored]'
--union
--select '4102', '0' as column_order_id,  'GO'
--union 
--select '4103', '0' as column_order_id,   ''



order by 1,2





































GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[31] 4[30] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "af"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 168
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "rgt"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 168
               Right = 515
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ad"
            Begin Extent = 
               Top = 7
               Left = 563
               Bottom = 168
               Right = 757
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReqGoodTransferWithAddresses'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReqGoodTransferWithAddresses'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[31] 4[30] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "af"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 168
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tav"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 168
               Right = 515
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ad"
            Begin Extent = 
               Top = 7
               Left = 563
               Bottom = 168
               Right = 757
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransportAvWithAddresses'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransportAvWithAddresses'
GO
USE [master]
GO
ALTER DATABASE [CarryOn] SET  READ_WRITE 
GO

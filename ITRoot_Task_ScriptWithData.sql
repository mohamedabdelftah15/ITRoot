USE [master]
GO
/****** Object:  Database [ITRoot_Task_DB]    Script Date: 1/30/2021 1:46:11 PM ******/
CREATE DATABASE [ITRoot_Task_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ITRoot_Task_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\ITRoot_Task_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ITRoot_Task_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\ITRoot_Task_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ITRoot_Task_DB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ITRoot_Task_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ITRoot_Task_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ITRoot_Task_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ITRoot_Task_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ITRoot_Task_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ITRoot_Task_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [ITRoot_Task_DB] SET  MULTI_USER 
GO
ALTER DATABASE [ITRoot_Task_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ITRoot_Task_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ITRoot_Task_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ITRoot_Task_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ITRoot_Task_DB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ITRoot_Task_DB', N'ON'
GO
ALTER DATABASE [ITRoot_Task_DB] SET QUERY_STORE = OFF
GO
USE [ITRoot_Task_DB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [ITRoot_Task_DB]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 1/30/2021 1:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNumber] [nvarchar](50) NOT NULL,
	[Product] [nvarchar](250) NOT NULL,
	[Quantity] [decimal](18, 0) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[UserID] [int] NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](250) NULL,
	[UpdatedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 1/30/2021 1:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](250) NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](250) NULL,
	[UpdatedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/30/2021 1:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](250) NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[ConfirmedEmail] [bit] NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](250) NULL,
	[UpdatedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 1/30/2021 1:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Invoice] ON 

INSERT [dbo].[Invoice] ([ID], [InvoiceNumber], [Product], [Quantity], [Price], [UserID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsDeleted]) VALUES (2, N'bd1b8e50-6f20-46b2-9965-8d27f730a527', N'some', CAST(100 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), 1, N'Mohamed abdelfatah', CAST(N'2021-01-30T13:12:25.613' AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Invoice] ([ID], [InvoiceNumber], [Product], [Quantity], [Price], [UserID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsDeleted]) VALUES (3, N'bd1b8e50-6f20-46b2-9965-8d27f730a527', N'how', CAST(50 AS Decimal(18, 0)), CAST(5000 AS Decimal(18, 0)), 1, N'Mohamed abdelfatah', CAST(N'2021-01-30T13:12:44.433' AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Invoice] ([ID], [InvoiceNumber], [Product], [Quantity], [Price], [UserID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsDeleted]) VALUES (4, N'bd1b8e50-6f20-46b2-9965-8d27f730a527', N'100', CAST(100 AS Decimal(18, 0)), CAST(100000 AS Decimal(18, 0)), 1, N'Mohamed abdelfatah', CAST(N'2021-01-30T13:12:56.437' AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Invoice] ([ID], [InvoiceNumber], [Product], [Quantity], [Price], [UserID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsDeleted]) VALUES (5, N'5ab766de-cdc7-496d-9d4a-b77ee3ac5681', N'Some', CAST(10 AS Decimal(18, 0)), CAST(200 AS Decimal(18, 0)), 29, N'Hassan Abo Ali', CAST(N'2021-01-30T13:16:26.497' AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Invoice] ([ID], [InvoiceNumber], [Product], [Quantity], [Price], [UserID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsDeleted]) VALUES (6, N'5ab766de-cdc7-496d-9d4a-b77ee3ac5681', N'Games', CAST(152 AS Decimal(18, 0)), CAST(122550 AS Decimal(18, 0)), 29, N'Hassan Abo Ali', CAST(N'2021-01-30T13:16:26.507' AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Invoice] ([ID], [InvoiceNumber], [Product], [Quantity], [Price], [UserID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsDeleted]) VALUES (7, N'5ab766de-cdc7-496d-9d4a-b77ee3ac5681', N'Sweet', CAST(100 AS Decimal(18, 0)), CAST(5200000 AS Decimal(18, 0)), 29, N'Hassan Abo Ali', CAST(N'2021-01-30T13:16:26.573' AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Invoice] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [RoleName], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsDeleted]) VALUES (1, N'Admin', N'test', CAST(N'2021-01-27T00:00:00.000' AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Role] ([ID], [RoleName], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsDeleted]) VALUES (2, N'User', N'test', CAST(N'2021-01-27T00:00:00.000' AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [FullName], [UserName], [Password], [Email], [ConfirmedEmail], [Phone], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsDeleted]) VALUES (1, N'Mohamed Abdelftah Sabry', N'Mohamed abdelfatah', N'mmmmmmmmmmmmm', N'mohamed.abd.elftah15@gmail.com', 1, N'0102245442222', N'', CAST(N'2021-01-28T08:46:24.763' AS DateTime), N'', CAST(N'2021-01-28T23:47:53.830' AS DateTime), 0)
INSERT [dbo].[User] ([ID], [FullName], [UserName], [Password], [Email], [ConfirmedEmail], [Phone], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsDeleted]) VALUES (29, N'Hassan Abo Ali', N'Hassan Abo Ali', N'123456789', N'elmagicmohamed15@yahoo.com', 1, N'0102265456', N'Hassan Abo Ali', CAST(N'2021-01-30T13:14:10.097' AS DateTime), N'Hassan Abo Ali', CAST(N'2021-01-30T13:15:03.097' AS DateTime), 0)
INSERT [dbo].[User] ([ID], [FullName], [UserName], [Password], [Email], [ConfirmedEmail], [Phone], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsDeleted]) VALUES (30, N'Hassan Abo Ali', N'Hassan Abo Ali', N'123456789', N'elmagicmohamed15@gmail.com', 0, N'0102265456', N'Mohamed abdelfatah', CAST(N'2021-01-30T13:17:25.027' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (1, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (29, 2)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (30, 2)
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_User]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 1/30/2021 1:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser] @FullName nvarchar(250), @UserName nvarchar(250),@Password nvarchar(100),@Email nvarchar(250),@Phone nvarchar(50),@RoleID int,@CreatedBy nvarchar(250),@CreatedDate datetime
AS
BEGIN
    set nocount on;
    declare @trancount int;
    set @trancount = @@trancount;
BEGIN try
if @trancount = 0
            begin transaction
        else
            save transaction AddUser;


INSERT INTO [ITRoot_Task_DB].[dbo].[User]  (FullName, UserName, Password,Email,ConfirmedEmail,Phone,CreatedBy,CreatedDate,IsDeleted)
VALUES (@FullName, @UserName, @Password,@Email,0,@Phone,@CreatedBy,@CreatedDate,0); 

declare @uid int 
select @uid=ID from [ITRoot_Task_DB].[dbo].[User]where UserName=@UserName or Email=@Email or Phone=@Phone 

INSERT INTO [ITRoot_Task_DB].[dbo].[UserRole]  (UserID,RoleID)
VALUES (@uid, @RoleID); 
lbexit:
        if @trancount = 0
            commit;
END try
BEGIN catch
declare @error int, @message varchar(4000), @xstate int;
        select @error = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
        if @xstate = -1
            rollback;
        if @xstate = 1 and @trancount = 0
            rollback
        if @xstate = 1 and @trancount > 0
            rollback transaction AddUser;

        raiserror ('AddUser: %d: %s', 16, 1, @error, @message) ;
END catch
END


GO
/****** Object:  StoredProcedure [dbo].[CheckLogin]    Script Date: 1/30/2021 1:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckLogin] @UserName nvarchar(250),@Password nvarchar(100),@RoleID int
AS
BEGIN
	select u.*,r.ID as RoleID,r.RoleName from [ITRoot_Task_DB].[dbo].[User] u
	left join [ITRoot_Task_DB].[dbo].[UserRole] ur
	on u.ID=ur.UserID
	left join [ITRoot_Task_DB].[dbo].[Role]r
	on ur.RoleID=r.ID
	where u.UserName=@UserName and u.Password=@Password and u.IsDeleted=0 and r.IsDeleted=0 and r.ID=@RoleID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 1/30/2021 1:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser] @ID int
AS
BEGIN
BEGIN try
	update [ITRoot_Task_DB].[dbo].[User]
	set [dbo].[User].[IsDeleted]=1
	where ID=@ID
END try
BEGIN catch
rollback
END catch
END
GO
/****** Object:  StoredProcedure [dbo].[EditUser]    Script Date: 1/30/2021 1:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[EditUser] @ID int, @FullName nvarchar(250), @UserName nvarchar(250),@Password nvarchar(100),@Email nvarchar(250),@ConfirmedEmail bit,@Phone nvarchar(50),@RoleID int,@UpdatedBy nvarchar(250),@UpdatedDate datetime
AS
BEGIN
BEGIN try
update [ITRoot_Task_DB].[dbo].[User]  
set FullName=@FullName,UserName= @UserName,Password= @Password,Email=@Email,ConfirmedEmail=@ConfirmedEmail,Phone=@Phone,UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate
where ID=@ID
update [ITRoot_Task_DB].[dbo].[UserRole]
set UserID=@ID,RoleID= @RoleID
where UserID=@ID
END try
BEGIN catch
rollback
END catch
END
GO
/****** Object:  StoredProcedure [dbo].[UserList]    Script Date: 1/30/2021 1:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserList]
AS
BEGIN
	select u.*,r.ID as RoleID,r.RoleName from [ITRoot_Task_DB].[dbo].[User] u
	left join [ITRoot_Task_DB].[dbo].[UserRole] ur
	on u.ID=ur.UserID
	left join [ITRoot_Task_DB].[dbo].[Role]r
	on ur.RoleID=r.ID
	where u.IsDeleted=0 and r.IsDeleted=0
END
GO
USE [master]
GO
ALTER DATABASE [ITRoot_Task_DB] SET  READ_WRITE 
GO

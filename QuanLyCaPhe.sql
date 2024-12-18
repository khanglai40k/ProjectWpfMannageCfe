
CREATE TABLE [dbo].[Account](
	[DisplayName] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](1000) NOT NULL,
	[Wage] [nvarchar](100) NULL,
	
	[Position] [nvarchar](100) NULL)

CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateCheckIn] [date] NOT NULL,
	[DateCheckOut] [date] NULL,
	[idTable] [int] NOT NULL,
	[status] [nvarchar](100) NULL)

CREATE TABLE [dbo].[BillInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBill] [int] NOT NULL,
	[idFood] [int] NOT NULL,
	[count] [int] NOT NULL)
	

CREATE TABLE [dbo].[Food](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[idCategory] [int] NOT NULL,
	[price] [float] NOT NULL)

CREATE TABLE [dbo].[FoodCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL )

CREATE TABLE [dbo].[InventoryItems](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[quantity] [int] NOT NULL,
	[isOn] [bit] NOT NULL )
CREATE TABLE [dbo].[Revenue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Time] [datetime] NULL,
	[TotalMoney] [decimal](18, 2) NULL)
CREATE TABLE [dbo].[TableFood](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[status] [nvarchar](100) NOT NULL)
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL )
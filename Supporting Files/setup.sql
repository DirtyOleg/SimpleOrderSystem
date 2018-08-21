USE [master]
GO

CREATE DATABASE [Restaurant]
GO

USE [Restaurant]
GO

GO
CREATE TABLE [dbo].[DishInfo](
	[DId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[DTypeId] [int] NULL,
	[DTitle] [nvarchar](32) NULL,
	[DPrice] [decimal](8, 2) NOT NULL,
	[DShortcut] [nvarchar](8) NULL,
	[DelFlag] [bit] NOT NULL
)
GO

CREATE TABLE [dbo].[DishType](
	[DId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[DTitle] [nvarchar](32) NULL,
	[DelFlag] [bit] NOT NULL
)
GO

CREATE TABLE [dbo].[EmployeeInfo](
	[EId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[EName] [nvarchar](32) NULL,
	[EPwd] [nvarchar](32) NOT NULL,
	[EPosition] [nvarchar](32) NULL,
	[DelFlag] [bit] NOT NULL
)	
GO

CREATE TABLE [dbo].[MemberInfo](
	[MId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[MName] [nvarchar](32) NULL,
	[MPhone] [nvarchar](16) NULL,
	[MBalance] [decimal](8, 2) NOT NULL,
	[MMemType] [int] NOT NULL,
	[DelFlag] [bit] NOT NULL
)
GO

CREATE TABLE [dbo].[Membership](
	[MId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[MName] [nvarchar](32) NULL,
	[MDiscountType] [decimal](8, 2) NOT NULL,
	[DelFlag] [bit] NOT NULL
)
GO


CREATE TABLE [dbo].[OrderDetailInfo](
	[OrderId] [int] NOT NULL,
	[DishType] [int] NOT NULL,
	[Count] [int] NOT NULL,
	CONSTRAINT [PK_OrderDetailInfo] PRIMARY KEY ([OrderId] ASC,[DishType] ASC)
)
GO


CREATE TABLE [dbo].[OrderInfo](
	[OId] [int] IDENTITY(1,1)  PRIMARY KEY NOT NULL,
	[TableId] [int] NOT NULL,
	[ODate] [datetime] NULL,
	[OTotalCost] [decimal](8, 2) NOT NULL,
	[OIsPaid] [bit] NOT NULL,
	[DiscountType] [decimal](8, 2) NULL,
	[MemberId] [int] NULL,
	[EmpId] [int] NULL,
)
GO

CREATE TABLE [dbo].[TableInfo](
	[TId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[TIsFree] [bit] NOT NULL,
	[DelFlag] [bit] NOT NULL
)
GO

SET IDENTITY_INSERT [dbo].[DishInfo] ON
INSERT [dbo].[DishInfo] ([DId], [DTypeId], [DTitle], [DPrice], [DShortcut], [DelFlag]) VALUES (1, 2, N'Renegade Sirloin', CAST(12.49 AS Decimal(5, 2)), N'RS', 0)
INSERT [dbo].[DishInfo] ([DId], [DTypeId], [DTitle], [DPrice], [DShortcut], [DelFlag]) VALUES (2, 2, N'Flat Iron Steak', CAST(14.49 AS Decimal(5, 2)), N'FIS', 0)
INSERT [dbo].[DishInfo] ([DId], [DTypeId], [DTitle], [DPrice], [DShortcut], [DelFlag]) VALUES (3, 2, N'New York Strip', CAST(20.99 AS Decimal(5, 2)), N'NYS', 0)
INSERT [dbo].[DishInfo] ([DId], [DTypeId], [DTitle], [DPrice], [DShortcut], [DelFlag]) VALUES (4, 1, N'Fried Pickles', CAST(3.99 AS Decimal(5, 2)), N'FP', 0)
INSERT [dbo].[DishInfo] ([DId], [DTypeId], [DTitle], [DPrice], [DShortcut], [DelFlag]) VALUES (5, 1, N'Wild West Shrimp', CAST(9.99 AS Decimal(5, 2)), N'WWS', 0)
SET IDENTITY_INSERT [dbo].[DishInfo] OFF

SET IDENTITY_INSERT [dbo].[DishType] ON 
INSERT [dbo].[DishType] ([DId], [DTitle], [DelFlag]) VALUES (1, N'Appetizer', 0)
INSERT [dbo].[DishType] ([DId], [DTitle], [DelFlag]) VALUES (2, N'Legendary Steak', 0)
SET IDENTITY_INSERT [dbo].[DishType] OFF

SET IDENTITY_INSERT [dbo].[EmployeeInfo] ON 
INSERT [dbo].[EmployeeInfo] ([EId], [EName], [EPwd], [EPosition], [DelFlag]) VALUES (1, N'David', N'250cf8b51c773f3f8dc8b4be867a9a02', N'Manager', 0)
INSERT [dbo].[EmployeeInfo] ([EId], [EName], [EPwd], [EPosition], [DelFlag]) VALUES (2, N'Cindy', N'202cb962ac59075b964b07152d234b70', N'Employee', 0)
INSERT [dbo].[EmployeeInfo] ([EId], [EName], [EPwd], [EPosition], [DelFlag]) VALUES (3, N'Jim', N'250cf8b51c773f3f8dc8b4be867a9a02', N'Employee', 0)
INSERT [dbo].[EmployeeInfo] ([EId], [EName], [EPwd], [EPosition], [DelFlag]) VALUES (4, N'John', N'68053af2923e00204c3ca7c6a3150cf7', N'Employee', 0)
INSERT [dbo].[EmployeeInfo] ([EId], [EName], [EPwd], [EPosition], [DelFlag]) VALUES (5, N'Tom', N'202cb962ac59075b964b07152d234b70', N'Employee', 0)
INSERT [dbo].[EmployeeInfo] ([EId], [EName], [EPwd], [EPosition], [DelFlag]) VALUES (6, N'Cindy', N'250cf8b51c773f3f8dc8b4be867a9a02', N'Manager', 0)
SET IDENTITY_INSERT [dbo].[EmployeeInfo] OFF

SET IDENTITY_INSERT [dbo].[MemberInfo] ON 
INSERT [dbo].[MemberInfo] ([MId], [MName], [MPhone], [MBalance], [MMemType], [DelFlag]) VALUES (1, N'James', NULL, CAST(50.01 AS Decimal(5, 2)), 1, 0)
INSERT [dbo].[MemberInfo] ([MId], [MName], [MPhone], [MBalance], [MMemType], [DelFlag]) VALUES (2, N'Micheal', NULL, CAST(10.00 AS Decimal(5, 2)), 3, 0)
INSERT [dbo].[MemberInfo] ([MId], [MName], [MPhone], [MBalance], [MMemType], [DelFlag]) VALUES (3, N'Robert', NULL, CAST(999.99 AS Decimal(5, 2)), 2, 0)
INSERT [dbo].[MemberInfo] ([MId], [MName], [MPhone], [MBalance], [MMemType], [DelFlag]) VALUES (4, N'Maria', NULL, CAST(500.88 AS Decimal(5, 2)), 2, 0)
INSERT [dbo].[MemberInfo] ([MId], [MName], [MPhone], [MBalance], [MMemType], [DelFlag]) VALUES (5, N'David', NULL, CAST(17.52 AS Decimal(5, 2)), 1, 0)
INSERT [dbo].[MemberInfo] ([MId], [MName], [MPhone], [MBalance], [MMemType], [DelFlag]) VALUES (6, N'Mary', NULL, CAST(99.99 AS Decimal(5, 2)), 4, 0)
INSERT [dbo].[MemberInfo] ([MId], [MName], [MPhone], [MBalance], [MMemType], [DelFlag]) VALUES (7, N'Lee', NULL, CAST(199.89 AS Decimal(5, 2)), 3, 0)
SET IDENTITY_INSERT [dbo].[MemberInfo] OFF

SET IDENTITY_INSERT [dbo].[Membership] ON 
INSERT [dbo].[Membership] ([MId], [MName], [MDiscountType], [DelFlag]) VALUES (1, N'Bronze', CAST(0.98 AS Decimal(3, 2)), 0)
INSERT [dbo].[Membership] ([MId], [MName], [MDiscountType], [DelFlag]) VALUES (2, N'Sliver', CAST(0.90 AS Decimal(3, 2)), 0)
INSERT [dbo].[Membership] ([MId], [MName], [MDiscountType], [DelFlag]) VALUES (3, N'Gold', CAST(0.85 AS Decimal(3, 2)), 0)
INSERT [dbo].[Membership] ([MId], [MName], [MDiscountType], [DelFlag]) VALUES (4, N'Platinum', CAST(0.80 AS Decimal(3, 2)), 0)
SET IDENTITY_INSERT [dbo].[Membership] OFF

SET IDENTITY_INSERT [dbo].[TableInfo] ON 
INSERT [dbo].[TableInfo] ([TId], [TIsFree], [DelFlag]) VALUES (1, 1, 0)
INSERT [dbo].[TableInfo] ([TId], [TIsFree], [DelFlag]) VALUES (2, 1, 0)
INSERT [dbo].[TableInfo] ([TId], [TIsFree], [DelFlag]) VALUES (3, 1, 0)
INSERT [dbo].[TableInfo] ([TId], [TIsFree], [DelFlag]) VALUES (4, 1, 0)
INSERT [dbo].[TableInfo] ([TId], [TIsFree], [DelFlag]) VALUES (5, 1, 0)
INSERT [dbo].[TableInfo] ([TId], [TIsFree], [DelFlag]) VALUES (6, 1, 0)
SET IDENTITY_INSERT [dbo].[TableInfo] OFF
GO


ALTER TABLE [dbo].[DishInfo] ADD  CONSTRAINT [DF_DishInfo_DPrice]  DEFAULT ((0)) FOR [DPrice]
GO
ALTER TABLE [dbo].[DishInfo] ADD  CONSTRAINT [DF_DishInfo_DelFlag]  DEFAULT ((0)) FOR [DelFlag]
GO
ALTER TABLE [dbo].[DishType] ADD  CONSTRAINT [DF_DishType_DelFlag]  DEFAULT ((0)) FOR [DelFlag]
GO
ALTER TABLE [dbo].[EmployeeInfo] ADD  CONSTRAINT [DF_Employee_EPosition]  DEFAULT ((0)) FOR [EPosition]
GO
ALTER TABLE [dbo].[EmployeeInfo] ADD  CONSTRAINT [DF_Employee_DelFlag]  DEFAULT ((0)) FOR [DelFlag]
GO
ALTER TABLE [dbo].[MemberInfo] ADD  CONSTRAINT [DF_MemberInfo_MBalance]  DEFAULT ((0)) FOR [MBalance]
GO
ALTER TABLE [dbo].[MemberInfo] ADD  CONSTRAINT [DF_MemberInfo_MMemType]  DEFAULT ((0)) FOR [MMemType]
GO
ALTER TABLE [dbo].[MemberInfo] ADD  CONSTRAINT [DF_MemberInfo_DelFlag]  DEFAULT ((0)) FOR [DelFlag]
GO
ALTER TABLE [dbo].[Membership] ADD  CONSTRAINT [DF_Membership_MDiscountType]  DEFAULT ((1)) FOR [MDiscountType]
GO
ALTER TABLE [dbo].[Membership] ADD  CONSTRAINT [DF_Membership_DelFlag]  DEFAULT ((0)) FOR [DelFlag]
GO
ALTER TABLE [dbo].[OrderDetailInfo] ADD  CONSTRAINT [DF_OrderDetailInfo_Count]  DEFAULT ((1)) FOR [Count]
GO
ALTER TABLE [dbo].[OrderInfo] ADD  CONSTRAINT [DF_OrderInfo_OTotalCost]  DEFAULT ((0)) FOR [OTotalCost]
GO
ALTER TABLE [dbo].[OrderInfo] ADD  CONSTRAINT [DF_OrderInfo_OIsPaid]  DEFAULT ((0)) FOR [OIsPaid]
GO
ALTER TABLE [dbo].[TableInfo] ADD  CONSTRAINT [DF_TableInfo_TIsFree]  DEFAULT ((1)) FOR [TIsFree]
GO
ALTER TABLE [dbo].[TableInfo] ADD  CONSTRAINT [DF_TableInfo_DelFlag]  DEFAULT ((0)) FOR [DelFlag]
GO
ALTER TABLE [dbo].[DishInfo] ADD  CONSTRAINT [FK_DishInfo_DishIType] FOREIGN KEY([DTypeId])
REFERENCES [dbo].[DishType] ([DId])
GO
ALTER TABLE [dbo].[MemberInfo] ADD  CONSTRAINT [FK_MemberInfo_Membership] FOREIGN KEY([MMemType])
REFERENCES [dbo].[Membership] ([MId])
GO
ALTER TABLE [dbo].[OrderDetailInfo] ADD  CONSTRAINT [FK_OrderDetailInfo_DishType] FOREIGN KEY([DishType])
REFERENCES [dbo].[DishType] ([DId])
GO
ALTER TABLE [dbo].[OrderDetailInfo] ADD  CONSTRAINT [FK_OrderDetailInfo_OrderInfo] FOREIGN KEY([OrderId])
REFERENCES [dbo].[OrderInfo] ([OId])
GO
ALTER TABLE [dbo].[OrderInfo]  ADD  CONSTRAINT [FK_OrderInfo_MemberInfo] FOREIGN KEY([MemberId])
REFERENCES [dbo].[MemberInfo] ([MId])
GO
ALTER TABLE [dbo].[OrderInfo]  ADD  CONSTRAINT [FK_OrderInfo_TableInfo] FOREIGN KEY([TableId])
REFERENCES [dbo].[TableInfo] ([TId])
GO


CREATE PROC [dbo].[SetDelFlagTrue]
	@id int,
	@tableName nvarchar(16)
AS
	DECLARE @primaryKeyColumnName nvarchar(16)
	SET @primaryKeyColumnName = (SELECT TOP 1 COLUMN_NAME
	FROM [Restaurant].INFORMATION_SCHEMA.COLUMNS
	WHERE TABLE_NAME=@tableName)

	DECLARE @query nvarchar(128)
	SET @query = 'UPDATE ' + @tableName + ' SET [DelFlag]=''True'' OUTPUT deleted.[EId] WHERE [' + @primaryKeyColumnName + '] = ' + convert(nvarchar(16),@id)
	print @query
	EXEC(@query);

	

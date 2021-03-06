USE [master]
GO

CREATE DATABASE [Restaurant]
GO

USE [Restaurant]
GO

GO
CREATE TABLE [dbo].[Dish](
	[DishId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[DishTypeId] [int] NULL,
	[DishTitle] [nvarchar](32) NULL,
	[DishPrice] [decimal](8, 2) NOT NULL,
	[DishShortcut] [nvarchar](8) NULL,
	[DelFlag] [bit] NOT NULL
)
GO

CREATE TABLE [dbo].[DishType](
	[DishTypeId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[DishTypeName] [nvarchar](32) NULL,
	[DelFlag] [bit] NOT NULL
)
GO

CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[EmployeeName] [nvarchar](32) NULL,
	[EmployeePwd] [nvarchar](32) NOT NULL,
	[EmployeePosition] [nvarchar](32) NULL,
	[DelFlag] [bit] NOT NULL
)	
GO

CREATE TABLE [dbo].[Member](
	[MemberId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[MemberName] [nvarchar](32) NULL,
	[MemberPhone] [nvarchar](16) NULL,
	[MemberBalance] [decimal](8, 2) NOT NULL,
	[MembershipId] [int] NOT NULL,
	[DelFlag] [bit] NOT NULL
)
GO

CREATE TABLE [dbo].[Membership](
	[MembershipId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[MembershipTitle] [nvarchar](32) NULL,
	[DiscountType] [decimal](8, 2) NOT NULL,
	[DelFlag] [bit] NOT NULL
)
GO


CREATE TABLE [dbo].[OrderDetail](
	[OrderSummaryId] [int] NOT NULL,
	[DishId] [int] NOT NULL,
	[Count] [int] NOT NULL,
	CONSTRAINT [PK_OrderDetail] PRIMARY KEY ([OrderSummaryId] ASC,[DishId] ASC)
)
GO


CREATE TABLE [dbo].[OrderSummary](
	[OrderSummaryId] [int] IDENTITY(1,1)  PRIMARY KEY NOT NULL,	
	[Date] [datetime] NULL,
	[TotalCostBeforeDiscount] [decimal](8, 2) NOT NULL,
	[DiscountType] [decimal](8, 2) NULL,
	[TotalCostAfterDiscount] [decimal](8, 2) NOT NULL,	
	[MemberId] [int] NULL,
	[TableId] [int] NOT NULL,
	[EmployeeId] [int] NULL,		
	[IsPaid] [bit] NOT NULL,
)
GO

CREATE TABLE [dbo].[Tables](
	[TableId] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[IsFree] [bit] NOT NULL,
	[DelFlag] [bit] NOT NULL
)
GO

SET IDENTITY_INSERT [dbo].[Dish] ON
INSERT [dbo].[Dish] ([DishId], [DishTypeId], [DishTitle], [DishPrice], [DishShortcut], [DelFlag]) VALUES (1, 2, N'Renegade Sirloin', CAST(12.49 AS Decimal(5, 2)), N'RS', 0)
INSERT [dbo].[Dish] ([DishId], [DishTypeId], [DishTitle], [DishPrice], [DishShortcut], [DelFlag]) VALUES (2, 2, N'Flat Iron Steak', CAST(14.49 AS Decimal(5, 2)), N'FIS', 0)
INSERT [dbo].[Dish] ([DishId], [DishTypeId], [DishTitle], [DishPrice], [DishShortcut], [DelFlag]) VALUES (3, 2, N'New York Strip', CAST(20.99 AS Decimal(5, 2)), N'NYS', 0)
INSERT [dbo].[Dish] ([DishId], [DishTypeId], [DishTitle], [DishPrice], [DishShortcut], [DelFlag]) VALUES (4, 1, N'Fried Pickles', CAST(3.99 AS Decimal(5, 2)), N'FP', 0)
INSERT [dbo].[Dish] ([DishId], [DishTypeId], [DishTitle], [DishPrice], [DishShortcut], [DelFlag]) VALUES (5, 1, N'Wild West Shrimp', CAST(9.99 AS Decimal(5, 2)), N'WWS', 0)
SET IDENTITY_INSERT [dbo].[Dish] OFF

SET IDENTITY_INSERT [dbo].[DishType] ON 
INSERT [dbo].[DishType] ([DishTypeId], [DishTypeName], [DelFlag]) VALUES (1, N'Appetizer', 0)
INSERT [dbo].[DishType] ([DishTypeId], [DishTypeName], [DelFlag]) VALUES (2, N'Legendary Steak', 0)
SET IDENTITY_INSERT [dbo].[DishType] OFF

SET IDENTITY_INSERT [dbo].[Employee] ON 
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeName], [EmployeePwd], [EmployeePosition], [DelFlag]) VALUES (1, N'David', N'250cf8b51c773f3f8dc8b4be867a9a02', N'Manager', 0)
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeName], [EmployeePwd], [EmployeePosition], [DelFlag]) VALUES (2, N'Cindy', N'202cb962ac59075b964b07152d234b70', N'Employee', 0)
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeName], [EmployeePwd], [EmployeePosition], [DelFlag]) VALUES (3, N'Jim', N'250cf8b51c773f3f8dc8b4be867a9a02', N'Employee', 0)
SET IDENTITY_INSERT [dbo].[Employee] OFF

SET IDENTITY_INSERT [dbo].[Member] ON 
INSERT [dbo].[Member] ([MemberId], [MemberName], [MemberPhone], [MemberBalance], [MembershipId], [DelFlag]) VALUES (1, N'James', NULL, CAST(50.01 AS Decimal(5, 2)), 1, 0)
INSERT [dbo].[Member] ([MemberId], [MemberName], [MemberPhone], [MemberBalance], [MembershipId], [DelFlag]) VALUES (2, N'Micheal', NULL, CAST(10.00 AS Decimal(5, 2)), 3, 0)
INSERT [dbo].[Member] ([MemberId], [MemberName], [MemberPhone], [MemberBalance], [MembershipId], [DelFlag]) VALUES (3, N'Robert', NULL, CAST(999.99 AS Decimal(5, 2)), 2, 0)
INSERT [dbo].[Member] ([MemberId], [MemberName], [MemberPhone], [MemberBalance], [MembershipId], [DelFlag]) VALUES (4, N'Maria', NULL, CAST(500.88 AS Decimal(5, 2)), 2, 0)
SET IDENTITY_INSERT [dbo].[Member] OFF

SET IDENTITY_INSERT [dbo].[Membership] ON 
INSERT [dbo].[Membership] ([MembershipId], [MembershipTitle], [DiscountType], [DelFlag]) VALUES (1, N'Bronze', CAST(0.98 AS Decimal(3, 2)), 0)
INSERT [dbo].[Membership] ([MembershipId], [MembershipTitle], [DiscountType], [DelFlag]) VALUES (2, N'Sliver', CAST(0.90 AS Decimal(3, 2)), 0)
INSERT [dbo].[Membership] ([MembershipId], [MembershipTitle], [DiscountType], [DelFlag]) VALUES (3, N'Gold', CAST(0.85 AS Decimal(3, 2)), 0)
INSERT [dbo].[Membership] ([MembershipId], [MembershipTitle], [DiscountType], [DelFlag]) VALUES (4, N'Platinum', CAST(0.80 AS Decimal(3, 2)), 0)
SET IDENTITY_INSERT [dbo].[Membership] OFF

SET IDENTITY_INSERT [dbo].[Tables] ON 
INSERT [dbo].[Tables] ([TableId], [IsFree], [DelFlag]) VALUES (1, 1, 0)
INSERT [dbo].[Tables] ([TableId], [IsFree], [DelFlag]) VALUES (2, 1, 0)
INSERT [dbo].[Tables] ([TableId], [IsFree], [DelFlag]) VALUES (3, 1, 0)
INSERT [dbo].[Tables] ([TableId], [IsFree], [DelFlag]) VALUES (4, 1, 0)
INSERT [dbo].[Tables] ([TableId], [IsFree], [DelFlag]) VALUES (5, 1, 0)
INSERT [dbo].[Tables] ([TableId], [IsFree], [DelFlag]) VALUES (6, 1, 0)
SET IDENTITY_INSERT [dbo].[Tables] OFF
GO


ALTER TABLE [dbo].[Dish] ADD  CONSTRAINT [DF_Dish_DishPrice]  DEFAULT ((0)) FOR [DishPrice]
GO
ALTER TABLE [dbo].[Dish] ADD  CONSTRAINT [DF_Dish_DelFlag]  DEFAULT ((0)) FOR [DelFlag]
GO
ALTER TABLE [dbo].[DishType] ADD  CONSTRAINT [DF_DishType_DelFlag]  DEFAULT ((0)) FOR [DelFlag]
GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_EmployeePosition]  DEFAULT (N'Employee') FOR [EmployeePosition]
GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_DelFlag]  DEFAULT ((0)) FOR [DelFlag]
GO
ALTER TABLE [dbo].[Member] ADD  CONSTRAINT [DF_Member_MemberBalance]  DEFAULT ((0)) FOR [MemberBalance]
GO
ALTER TABLE [dbo].[Member] ADD  CONSTRAINT [DF_Member_MembershipId]  DEFAULT ((1)) FOR [MembershipId]
GO
ALTER TABLE [dbo].[Member] ADD  CONSTRAINT [DF_Member_DelFlag]  DEFAULT ((0)) FOR [DelFlag]
GO
ALTER TABLE [dbo].[Membership] ADD  CONSTRAINT [DF_Membership_DiscountType]  DEFAULT ((1)) FOR [DiscountType]
GO
ALTER TABLE [dbo].[Membership] ADD  CONSTRAINT [DF_Membership_DelFlag]  DEFAULT ((0)) FOR [DelFlag]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  CONSTRAINT [DF_OrderDetail_Count]  DEFAULT ((1)) FOR [Count]
GO
ALTER TABLE [dbo].[OrderSummary] ADD  CONSTRAINT [DF_OrderSummary_TotalCostBeforeDiscount]  DEFAULT ((0)) FOR [TotalCostBeforeDiscount]
GO
ALTER TABLE [dbo].[OrderSummary] ADD  CONSTRAINT [DF_OrderSummary_TotalCostAfterDiscount]  DEFAULT ((0)) FOR [TotalCostAfterDiscount]
GO
ALTER TABLE [dbo].[OrderSummary] ADD  CONSTRAINT [DF_OrderSummary_IsPaid]  DEFAULT ((0)) FOR [IsPaid]
GO
ALTER TABLE [dbo].[Tables] ADD  CONSTRAINT [DF_Table_IsFree]  DEFAULT ((1)) FOR [IsFree]
GO
ALTER TABLE [dbo].[Tables] ADD  CONSTRAINT [DF_Table_DelFlag]  DEFAULT ((0)) FOR [DelFlag]
GO
ALTER TABLE [dbo].[Dish] ADD  CONSTRAINT [FK_Dish_DishType] FOREIGN KEY([DishTypeId])
REFERENCES [dbo].[DishType] ([DishTypeId])
GO
ALTER TABLE [dbo].[Member] ADD  CONSTRAINT [FK_Member_Membership] FOREIGN KEY([MembershipId])
REFERENCES [dbo].[Membership] ([MembershipId])
GO
ALTER TABLE [dbo].[OrderDetail] ADD  CONSTRAINT [FK_OrderDetail_Dish] FOREIGN KEY([DishId])
REFERENCES [dbo].[Dish] ([DishId])
GO
ALTER TABLE [dbo].[OrderDetail] ADD  CONSTRAINT [FK_OrderDetail_OrderSummary] FOREIGN KEY([OrderSummaryId])
REFERENCES [dbo].[OrderSummary] ([OrderSummaryId])
GO
ALTER TABLE [dbo].[OrderSummary]  ADD  CONSTRAINT [FK_OrderSummary_Member] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Member] ([MemberId])
GO
ALTER TABLE [dbo].[OrderSummary]  ADD  CONSTRAINT [FK_OrderSummary_Table] FOREIGN KEY([TableId])
REFERENCES [dbo].[Tables] ([TableId])
GO
ALTER TABLE [dbo].[OrderSummary]  ADD  CONSTRAINT [FK_OrderSummary_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
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
	SET @query = 'UPDATE ' + @tableName + ' SET [DelFlag]=''True'' OUTPUT DELETED.[' + @primaryKeyColumnName + '] WHERE [' + @primaryKeyColumnName + ']=' + convert(nvarchar(16),@id)
	print @query
	EXEC(@query);

	

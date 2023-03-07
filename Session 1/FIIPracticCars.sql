USE [master]
GO
/****** Object:  Database [FIIPracticCars]    Script Date: 2023-03-07 13:58:24 ******/
CREATE DATABASE [FIIPracticCars]
GO

USE [FIIPracticCars]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 2023-03-07 13:58:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Logo] [nvarchar](2000) NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Models]    Script Date: 2023-03-07 13:58:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Models](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[ModelYear] [int] NOT NULL,
	[FuelType] [int] NOT NULL,
	[BrandId] [int] NOT NULL,
 CONSTRAINT [PK_Models] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2023-03-07 13:58:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](230) NOT NULL,
	[PasswordHash] [varchar](32) NOT NULL,
	[BirthDate] [date] NULL,
	[RegistrationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserVehicles]    Script Date: 2023-03-07 13:58:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserVehicles](
	[UserId] [int] NOT NULL,
	[VehicleId] [int] NOT NULL,
 CONSTRAINT [PK_UserVehicles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 2023-03-07 13:58:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VIN] [char](17) NOT NULL,
	[LicensePlate] [varchar](10) NULL,
	[RegistrationDate] [date] NULL,
	[ExteriorColor] [varchar](50) NULL,
	[ModelId] [int] NOT NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 
GO
INSERT [dbo].[Brands] ([Id], [Name], [Logo]) VALUES (1, N'BMW', NULL)
GO
INSERT [dbo].[Brands] ([Id], [Name], [Logo]) VALUES (2, N'Lotus', NULL)
GO
INSERT [dbo].[Brands] ([Id], [Name], [Logo]) VALUES (3, N'Lexus', NULL)
GO
INSERT [dbo].[Brands] ([Id], [Name], [Logo]) VALUES (4, N'Tesla', NULL)
GO
INSERT [dbo].[Brands] ([Id], [Name], [Logo]) VALUES (5, N'Dacia', NULL)
GO
INSERT [dbo].[Brands] ([Id], [Name], [Logo]) VALUES (6, N'VW', NULL)
GO
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Models] ON 
GO
INSERT [dbo].[Models] ([Id], [Name], [ModelYear], [FuelType], [BrandId]) VALUES (1, N'Duster', 2018, 0, 5)
GO
INSERT [dbo].[Models] ([Id], [Name], [ModelYear], [FuelType], [BrandId]) VALUES (2, N'UX', 2021, 3, 3)
GO
INSERT [dbo].[Models] ([Id], [Name], [ModelYear], [FuelType], [BrandId]) VALUES (3, N'Model 3', 2023, 5, 4)
GO
INSERT [dbo].[Models] ([Id], [Name], [ModelYear], [FuelType], [BrandId]) VALUES (4, N'Elise 111S', 2010, 0, 2)
GO
SET IDENTITY_INSERT [dbo].[Models] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [BirthDate], [RegistrationDate]) VALUES (1, N'Antonio', N'Ionescu', N'exempu@yahoo.ro', N'123456', CAST(N'2003-08-10' AS Date), CAST(N'2023-03-04T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
INSERT [dbo].[UserVehicles] ([UserId], [VehicleId]) VALUES (1, 1)
GO
INSERT [dbo].[UserVehicles] ([UserId], [VehicleId]) VALUES (1, 3)
GO
SET IDENTITY_INSERT [dbo].[Vehicles] ON 
GO
INSERT [dbo].[Vehicles] ([ID], [VIN], [LicensePlate], [RegistrationDate], [ExteriorColor], [ModelId]) VALUES (1, N'12345671234567890', N'IS00TST', CAST(N'2011-01-01' AS Date), N'Black', 4)
GO
INSERT [dbo].[Vehicles] ([ID], [VIN], [LicensePlate], [RegistrationDate], [ExteriorColor], [ModelId]) VALUES (2, N'ABCDEF1234567890 ', N'B000ABC', CAST(N'2022-06-01' AS Date), N'Red', 2)
GO
INSERT [dbo].[Vehicles] ([ID], [VIN], [LicensePlate], [RegistrationDate], [ExteriorColor], [ModelId]) VALUES (3, N'UU1H5DA0N4B9722B2', N'IS99DUS', CAST(N'2018-02-03' AS Date), N'Blue Mamaia', 1)
GO
SET IDENTITY_INSERT [dbo].[Vehicles] OFF
GO
ALTER TABLE [dbo].[Models]  WITH CHECK ADD  CONSTRAINT [FK_Models_Brands] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
GO
ALTER TABLE [dbo].[Models] CHECK CONSTRAINT [FK_Models_Brands]
GO
ALTER TABLE [dbo].[UserVehicles]  WITH CHECK ADD  CONSTRAINT [FK_UserVehicles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserVehicles] CHECK CONSTRAINT [FK_UserVehicles_Users]
GO
ALTER TABLE [dbo].[UserVehicles]  WITH CHECK ADD  CONSTRAINT [FK_UserVehicles_Vehicles] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([ID])
GO
ALTER TABLE [dbo].[UserVehicles] CHECK CONSTRAINT [FK_UserVehicles_Vehicles]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_Models] FOREIGN KEY([ModelId])
REFERENCES [dbo].[Models] ([Id])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_Models]
GO
USE [master]
GO
ALTER DATABASE [FIIPracticCars] SET  READ_WRITE 
GO

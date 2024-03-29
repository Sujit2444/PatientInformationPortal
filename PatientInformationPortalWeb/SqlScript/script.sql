USE [master]
GO
/****** Object:  Database [PatientInformationPortalDB]    Script Date: 2/29/2024 1:26:48 PM ******/
CREATE DATABASE [PatientInformationPortalDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PatientInformationPortalDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PatientInformationPortalDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PatientInformationPortalDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PatientInformationPortalDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PatientInformationPortalDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PatientInformationPortalDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PatientInformationPortalDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PatientInformationPortalDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PatientInformationPortalDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PatientInformationPortalDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PatientInformationPortalDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PatientInformationPortalDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PatientInformationPortalDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PatientInformationPortalDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PatientInformationPortalDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PatientInformationPortalDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PatientInformationPortalDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PatientInformationPortalDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PatientInformationPortalDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PatientInformationPortalDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PatientInformationPortalDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PatientInformationPortalDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PatientInformationPortalDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PatientInformationPortalDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PatientInformationPortalDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PatientInformationPortalDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PatientInformationPortalDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [PatientInformationPortalDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PatientInformationPortalDB] SET RECOVERY FULL 
GO
ALTER DATABASE [PatientInformationPortalDB] SET  MULTI_USER 
GO
ALTER DATABASE [PatientInformationPortalDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PatientInformationPortalDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PatientInformationPortalDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PatientInformationPortalDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PatientInformationPortalDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PatientInformationPortalDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PatientInformationPortalDB', N'ON'
GO
ALTER DATABASE [PatientInformationPortalDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [PatientInformationPortalDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PatientInformationPortalDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/29/2024 1:26:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Allergies]    Script Date: 2/29/2024 1:26:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allergies](
	[AllergiesID] [int] IDENTITY(1,1) NOT NULL,
	[AllergiesName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Allergies] PRIMARY KEY CLUSTERED 
(
	[AllergiesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Allergies_Details]    Script Date: 2/29/2024 1:26:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allergies_Details](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[AllergiesID] [int] NOT NULL,
 CONSTRAINT [PK_Allergies_Details] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiseaseInformation]    Script Date: 2/29/2024 1:26:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiseaseInformation](
	[DiseaseID] [int] IDENTITY(1,1) NOT NULL,
	[DiseaseName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DiseaseInformation] PRIMARY KEY CLUSTERED 
(
	[DiseaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NCD_Details]    Script Date: 2/29/2024 1:26:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCD_Details](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[NCDID] [int] NOT NULL,
 CONSTRAINT [PK_NCD_Details] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NCDs]    Script Date: 2/29/2024 1:26:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCDs](
	[NCDID] [int] IDENTITY(1,1) NOT NULL,
	[NCDName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_NCDs] PRIMARY KEY CLUSTERED 
(
	[NCDID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientsInformation]    Script Date: 2/29/2024 1:26:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientsInformation](
	[PatientID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[EpilepsyStatus] [int] NOT NULL,
	[DiseaseID] [int] NOT NULL,
 CONSTRAINT [PK_PatientsInformation] PRIMARY KEY CLUSTERED 
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240226082556_InitialPatientInformationDB', N'8.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240226100359_AddDisseaseIdToPatient', N'8.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240226101701_PopulateDiseaseInformation', N'8.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240226200432_removekeyannotation', N'8.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240226201055_addkeyannotation', N'8.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240227134149_RemoveNullableTypes', N'8.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240227180056_Test', N'8.0.2')
GO
SET IDENTITY_INSERT [dbo].[Allergies] ON 

INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (1, N'Drugs - Penicillin')
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (2, N'Drugs - Others')
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (3, N'Animals')
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (4, N'Food')
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (5, N'Oniments')
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (6, N'Plant')
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (7, N'Sprays')
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (8, N'Others')
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (9, N'No Allergies')
SET IDENTITY_INSERT [dbo].[Allergies] OFF
GO
SET IDENTITY_INSERT [dbo].[Allergies_Details] ON 

INSERT [dbo].[Allergies_Details] ([ID], [PatientID], [AllergiesID]) VALUES (53, 7, 3)
INSERT [dbo].[Allergies_Details] ([ID], [PatientID], [AllergiesID]) VALUES (54, 7, 4)
INSERT [dbo].[Allergies_Details] ([ID], [PatientID], [AllergiesID]) VALUES (55, 15, 6)
INSERT [dbo].[Allergies_Details] ([ID], [PatientID], [AllergiesID]) VALUES (56, 15, 7)
SET IDENTITY_INSERT [dbo].[Allergies_Details] OFF
GO
SET IDENTITY_INSERT [dbo].[DiseaseInformation] ON 

INSERT [dbo].[DiseaseInformation] ([DiseaseID], [DiseaseName]) VALUES (1, N'Hepatitis A')
INSERT [dbo].[DiseaseInformation] ([DiseaseID], [DiseaseName]) VALUES (2, N'Influenza (Flu)')
INSERT [dbo].[DiseaseInformation] ([DiseaseID], [DiseaseName]) VALUES (3, N'COVID-19')
INSERT [dbo].[DiseaseInformation] ([DiseaseID], [DiseaseName]) VALUES (4, N'Common Cold')
SET IDENTITY_INSERT [dbo].[DiseaseInformation] OFF
GO
SET IDENTITY_INSERT [dbo].[NCD_Details] ON 

INSERT [dbo].[NCD_Details] ([ID], [PatientID], [NCDID]) VALUES (50, 7, 3)
INSERT [dbo].[NCD_Details] ([ID], [PatientID], [NCDID]) VALUES (51, 7, 4)
INSERT [dbo].[NCD_Details] ([ID], [PatientID], [NCDID]) VALUES (52, 15, 1)
INSERT [dbo].[NCD_Details] ([ID], [PatientID], [NCDID]) VALUES (53, 15, 5)
SET IDENTITY_INSERT [dbo].[NCD_Details] OFF
GO
SET IDENTITY_INSERT [dbo].[NCDs] ON 

INSERT [dbo].[NCDs] ([NCDID], [NCDName]) VALUES (1, N'Asthma')
INSERT [dbo].[NCDs] ([NCDID], [NCDName]) VALUES (2, N'Cancer')
INSERT [dbo].[NCDs] ([NCDID], [NCDName]) VALUES (3, N'Disorders of ear')
INSERT [dbo].[NCDs] ([NCDID], [NCDName]) VALUES (4, N'Disorders of eye')
INSERT [dbo].[NCDs] ([NCDID], [NCDName]) VALUES (5, N'Mental illness')
INSERT [dbo].[NCDs] ([NCDID], [NCDName]) VALUES (6, N'Our health problems')
SET IDENTITY_INSERT [dbo].[NCDs] OFF
GO
SET IDENTITY_INSERT [dbo].[PatientsInformation] ON 

INSERT [dbo].[PatientsInformation] ([PatientID], [Name], [EpilepsyStatus], [DiseaseID]) VALUES (7, N'test by sujit', 0, 1)
INSERT [dbo].[PatientsInformation] ([PatientID], [Name], [EpilepsyStatus], [DiseaseID]) VALUES (8, N'test by sujit 24', 0, 1)
INSERT [dbo].[PatientsInformation] ([PatientID], [Name], [EpilepsyStatus], [DiseaseID]) VALUES (15, N'Bob', 1, 4)
SET IDENTITY_INSERT [dbo].[PatientsInformation] OFF
GO
/****** Object:  Index [IX_Allergies_Details_AllergiesID]    Script Date: 2/29/2024 1:26:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_Allergies_Details_AllergiesID] ON [dbo].[Allergies_Details]
(
	[AllergiesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Allergies_Details_PatientID]    Script Date: 2/29/2024 1:26:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_Allergies_Details_PatientID] ON [dbo].[Allergies_Details]
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NCD_Details_NCDID]    Script Date: 2/29/2024 1:26:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_NCD_Details_NCDID] ON [dbo].[NCD_Details]
(
	[NCDID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NCD_Details_PatientID]    Script Date: 2/29/2024 1:26:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_NCD_Details_PatientID] ON [dbo].[NCD_Details]
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PatientsInformation_DiseaseID]    Script Date: 2/29/2024 1:26:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_PatientsInformation_DiseaseID] ON [dbo].[PatientsInformation]
(
	[DiseaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Allergies_Details] ADD  DEFAULT ((0)) FOR [AllergiesID]
GO
ALTER TABLE [dbo].[NCD_Details] ADD  DEFAULT ((0)) FOR [NCDID]
GO
ALTER TABLE [dbo].[PatientsInformation] ADD  DEFAULT ((0)) FOR [DiseaseID]
GO
ALTER TABLE [dbo].[Allergies_Details]  WITH CHECK ADD  CONSTRAINT [FK_Allergies_Details_Allergies_AllergiesID] FOREIGN KEY([AllergiesID])
REFERENCES [dbo].[Allergies] ([AllergiesID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Allergies_Details] CHECK CONSTRAINT [FK_Allergies_Details_Allergies_AllergiesID]
GO
ALTER TABLE [dbo].[Allergies_Details]  WITH CHECK ADD  CONSTRAINT [FK_Allergies_Details_PatientsInformation_PatientID] FOREIGN KEY([PatientID])
REFERENCES [dbo].[PatientsInformation] ([PatientID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Allergies_Details] CHECK CONSTRAINT [FK_Allergies_Details_PatientsInformation_PatientID]
GO
ALTER TABLE [dbo].[NCD_Details]  WITH CHECK ADD  CONSTRAINT [FK_NCD_Details_NCDs_NCDID] FOREIGN KEY([NCDID])
REFERENCES [dbo].[NCDs] ([NCDID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NCD_Details] CHECK CONSTRAINT [FK_NCD_Details_NCDs_NCDID]
GO
ALTER TABLE [dbo].[NCD_Details]  WITH CHECK ADD  CONSTRAINT [FK_NCD_Details_PatientsInformation_PatientID] FOREIGN KEY([PatientID])
REFERENCES [dbo].[PatientsInformation] ([PatientID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NCD_Details] CHECK CONSTRAINT [FK_NCD_Details_PatientsInformation_PatientID]
GO
ALTER TABLE [dbo].[PatientsInformation]  WITH CHECK ADD  CONSTRAINT [FK_PatientsInformation_DiseaseInformation_DiseaseID] FOREIGN KEY([DiseaseID])
REFERENCES [dbo].[DiseaseInformation] ([DiseaseID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PatientsInformation] CHECK CONSTRAINT [FK_PatientsInformation_DiseaseInformation_DiseaseID]
GO
USE [master]
GO
ALTER DATABASE [PatientInformationPortalDB] SET  READ_WRITE 
GO

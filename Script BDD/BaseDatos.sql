USE [master]
GO
/****** Object:  Database [Pichincha]    Script Date: 15/01/2023 02:07:20 a. m. ******/
CREATE DATABASE [Pichincha]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Pichincha', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Pichincha.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Pichincha_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Pichincha_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Pichincha] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Pichincha].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Pichincha] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Pichincha] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Pichincha] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Pichincha] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Pichincha] SET ARITHABORT OFF 
GO
ALTER DATABASE [Pichincha] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Pichincha] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Pichincha] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Pichincha] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Pichincha] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Pichincha] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Pichincha] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Pichincha] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Pichincha] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Pichincha] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Pichincha] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Pichincha] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Pichincha] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Pichincha] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Pichincha] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Pichincha] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Pichincha] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Pichincha] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Pichincha] SET  MULTI_USER 
GO
ALTER DATABASE [Pichincha] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Pichincha] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Pichincha] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Pichincha] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Pichincha] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Pichincha] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Pichincha] SET QUERY_STORE = OFF
GO
USE [Pichincha]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 15/01/2023 02:07:20 a. m. ******/
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
/****** Object:  Table [dbo].[Clientes]    Script Date: 15/01/2023 02:07:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Contrasenia] [nvarchar](20) NOT NULL,
	[Activo] [bit] NOT NULL,
	[PersonaId] [int] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 15/01/2023 02:07:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumeroCuenta] [nvarchar](20) NOT NULL,
	[TipoCuenta] [nvarchar](10) NOT NULL,
	[SaldoInicial] [decimal](18, 2) NOT NULL,
	[CupoDiario] [decimal](18, 2) NOT NULL,
	[Activo] [bit] NOT NULL,
	[ClienteId] [int] NOT NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 15/01/2023 02:07:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[TipoMovimiento] [nvarchar](20) NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[Saldo] [decimal](18, 2) NOT NULL,
	[CuentaId] [int] NOT NULL,
 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 15/01/2023 02:07:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Genero] [nvarchar](10) NOT NULL,
	[Edad] [int] NOT NULL,
	[Identificacion] [nvarchar](13) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Telefono] [nvarchar](15) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230114180938_ProcedimientosAlmacenados', N'7.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230115064041_CreacionDB', N'7.0.2')
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([Id], [Contrasenia], [Activo], [PersonaId]) VALUES (1, N'1234', 1, 1)
INSERT [dbo].[Clientes] ([Id], [Contrasenia], [Activo], [PersonaId]) VALUES (2, N'5678', 1, 2)
INSERT [dbo].[Clientes] ([Id], [Contrasenia], [Activo], [PersonaId]) VALUES (3, N'1245', 1, 3)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Cuentas] ON 

INSERT [dbo].[Cuentas] ([Id], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [CupoDiario], [Activo], [ClienteId]) VALUES (1, N'478758', N'Ahorro', CAST(2025.00 AS Decimal(18, 2)), CAST(575.00 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[Cuentas] ([Id], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [CupoDiario], [Activo], [ClienteId]) VALUES (2, N'225487', N'Corriente', CAST(100.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 2)
INSERT [dbo].[Cuentas] ([Id], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [CupoDiario], [Activo], [ClienteId]) VALUES (3, N'495878', N'Ahorros', CAST(150.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 3)
INSERT [dbo].[Cuentas] ([Id], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [CupoDiario], [Activo], [ClienteId]) VALUES (4, N'496825', N'Ahorros', CAST(0.00 AS Decimal(18, 2)), CAST(540.00 AS Decimal(18, 2)), 1, 2)
INSERT [dbo].[Cuentas] ([Id], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [CupoDiario], [Activo], [ClienteId]) VALUES (5, N'585545', N'Corriente', CAST(1000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 1)
SET IDENTITY_INSERT [dbo].[Cuentas] OFF
GO
SET IDENTITY_INSERT [dbo].[Movimientos] ON 

INSERT [dbo].[Movimientos] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [CuentaId]) VALUES (1, CAST(N'2023-01-15T01:56:02.080' AS DateTime), N'DÉBITO', CAST(575.00 AS Decimal(18, 2)), CAST(1425.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Movimientos] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [CuentaId]) VALUES (2, CAST(N'2023-01-15T01:56:26.037' AS DateTime), N'CRÉDITO', CAST(600.00 AS Decimal(18, 2)), CAST(2025.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Movimientos] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [CuentaId]) VALUES (3, CAST(N'2023-01-15T01:56:46.777' AS DateTime), N'CRÉDITO', CAST(150.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[Movimientos] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [CuentaId]) VALUES (4, CAST(N'2023-01-15T01:58:03.280' AS DateTime), N'DÉBITO', CAST(540.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 4)
INSERT [dbo].[Movimientos] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [CuentaId]) VALUES (5, CAST(N'2022-02-10T00:00:00.000' AS DateTime), N'CRÉDITO', CAST(600.00 AS Decimal(18, 2)), CAST(700.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[Movimientos] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [CuentaId]) VALUES (6, CAST(N'2022-02-08T00:00:00.000' AS DateTime), N'DÉBITO', CAST(540.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 4)
SET IDENTITY_INSERT [dbo].[Movimientos] OFF
GO
SET IDENTITY_INSERT [dbo].[Personas] ON 

INSERT [dbo].[Personas] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono], [Activo]) VALUES (1, N'Jose Lema', N'masculino', 32, N'1719633822', N'Otavalo sn y principal', N'098254785', 1)
INSERT [dbo].[Personas] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono], [Activo]) VALUES (2, N'Marianela Montalvo', N'femenino', 32, N'1719633822', N'Amazonas y NNUU', N'097548965', 1)
INSERT [dbo].[Personas] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono], [Activo]) VALUES (3, N'Juan Osorio', N'masculino', 32, N'1719633822', N'13 junio y Equinoccial', N'098874587', 1)
SET IDENTITY_INSERT [dbo].[Personas] OFF
GO
/****** Object:  Index [IX_Clientes_PersonaId]    Script Date: 15/01/2023 02:07:20 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Clientes_PersonaId] ON [dbo].[Clientes]
(
	[PersonaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cuentas_ClienteId]    Script Date: 15/01/2023 02:07:20 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Cuentas_ClienteId] ON [dbo].[Cuentas]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movimientos_CuentaId]    Script Date: 15/01/2023 02:07:20 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Movimientos_CuentaId] ON [dbo].[Movimientos]
(
	[CuentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Personas_PersonaId] FOREIGN KEY([PersonaId])
REFERENCES [dbo].[Personas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Personas_PersonaId]
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_Cuentas_Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [FK_Cuentas_Clientes_ClienteId]
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimientos_Cuentas_CuentaId] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[Cuentas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK_Movimientos_Cuentas_CuentaId]
GO
/****** Object:  StoredProcedure [dbo].[PersonasInsertar]    Script Date: 15/01/2023 02:07:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

                   CREATE PROCEDURE [dbo].[PersonasInsertar]
                   @id int OUTPUT,
                   @nombre nvarchar(100),
                   @genero nvarchar(10),
                   @edad nvarchar(2),
                   @identificacion nvarchar(13),
                   @direccion nvarchar(100),
                   @telefono nvarchar(15),
                   @activo bit
                   AS
                   BEGIN
                   SET NOCOUNT ON;
                   INSERT INTO Personas(nombre, genero, edad, identificacion, direccion, telefono, activo)
                   VALUES(@nombre, @genero, @edad,
                   @identificacion,@direccion, @telefono, @activo)

                   SELECT @id = SCOPE_IDENTITY()
                   END
             
GO
/****** Object:  StoredProcedure [dbo].[PersonasObtenerIds]    Script Date: 15/01/2023 02:07:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

                   CREATE PROCEDURE [dbo].[PersonasObtenerIds]                   
                   AS
                   BEGIN                   
                   SELECT Id

                   FROM Personas                   
                   END
             
GO
/****** Object:  StoredProcedure [dbo].[PersonasObtenerPorId]    Script Date: 15/01/2023 02:07:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

                   CREATE PROCEDURE [dbo].[PersonasObtenerPorId]
                   @id int                  
                   AS
                   BEGIN
                   SET NOCOUNT ON;
                   SELECT id, nombre, genero, edad, identificacion,direccion, telefono, activo
                   FROM Personas
                   WHERE Id = @id;
                   END
             
GO
USE [master]
GO
ALTER DATABASE [Pichincha] SET  READ_WRITE 
GO

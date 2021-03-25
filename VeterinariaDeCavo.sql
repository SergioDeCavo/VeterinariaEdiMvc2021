USE [master]
GO
/****** Object:  Database [VeterinariaDeCavo]    Script Date: 18/03/2021 20:17:23 ******/
CREATE DATABASE [VeterinariaDeCavo]
GO
ALTER DATABASE [VeterinariaDeCavo] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VeterinariaDeCavo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VeterinariaDeCavo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET ARITHABORT OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VeterinariaDeCavo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VeterinariaDeCavo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VeterinariaDeCavo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VeterinariaDeCavo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET RECOVERY FULL 
GO
ALTER DATABASE [VeterinariaDeCavo] SET  MULTI_USER 
GO
ALTER DATABASE [VeterinariaDeCavo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VeterinariaDeCavo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VeterinariaDeCavo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VeterinariaDeCavo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [VeterinariaDeCavo] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Veterinaria', N'ON'
GO
ALTER DATABASE [VeterinariaDeCavo] SET QUERY_STORE = OFF
GO
USE [VeterinariaDeCavo]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[TipoDeDocumentoId] [int] NOT NULL,
	[NumeroDocumento] [nvarchar](10) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[LocalidadId] [int] NOT NULL,
	[ProvinciaId] [int] NOT NULL,
	[TelefonoFijo] [nvarchar](20) NULL,
	[TelefonoMovil] [nvarchar](20) NULL,
	[CorreoElectronico] [nvarchar](150) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[CompraId] [int] IDENTITY(1,1) NOT NULL,
	[FechaCompra] [datetime] NOT NULL,
	[ProveedorId] [int] NOT NULL,
	[DetalleCompra] [nvarchar](50) NOT NULL,
	[Total] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[CompraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drogas]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drogas](
	[DrogaId] [int] IDENTITY(1,1) NOT NULL,
	[NombreDroga] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Drogas] PRIMARY KEY CLUSTERED 
(
	[DrogaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[EmpleadoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[TipoDeDocumentoId] [int] NOT NULL,
	[NumeroDocumento] [nvarchar](10) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[LocalidadId] [int] NOT NULL,
	[ProvinciaId] [int] NOT NULL,
	[TelefonoFijo] [nvarchar](20) NULL,
	[TelefonoMovil] [nvarchar](20) NULL,
	[CorreoElectronico] [nvarchar](150) NULL,
	[TipoDeTareaId] [int] NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[EmpleadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormasFarmaceuticas]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormasFarmaceuticas](
	[FormaFarmaceuticaId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FormasFarmaceuticas] PRIMARY KEY CLUSTERED 
(
	[FormaFarmaceuticaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemCompras]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemCompras](
	[ItemCompra] [int] IDENTITY(1,1) NOT NULL,
	[CompraId] [int] NOT NULL,
	[MedicamentoId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 0) NOT NULL,
	[KardexId] [int] NOT NULL,
	[Total] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemVenta]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemVenta](
	[ItemVentaId] [int] IDENTITY(1,1) NOT NULL,
	[VentaId] [int] NOT NULL,
	[MedicamentoId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioVenta] [decimal](18, 0) NOT NULL,
	[KardexId] [int] NOT NULL,
	[Total] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_ItemVenta] PRIMARY KEY CLUSTERED 
(
	[ItemVentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kardex]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kardex](
	[KardexId] [int] IDENTITY(1,1) NOT NULL,
	[MedicamentoId] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Movimiento] [nvarchar](50) NOT NULL,
	[Entrada] [int] NOT NULL,
	[Salida] [int] NOT NULL,
	[Saldo] [int] NOT NULL,
	[UltimoCosto] [decimal](18, 0) NOT NULL,
	[CostoPromedio] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Kardex] PRIMARY KEY CLUSTERED 
(
	[KardexId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Laboratorios]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Laboratorios](
	[LaboratorioId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Laboratorios] PRIMARY KEY CLUSTERED 
(
	[LaboratorioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidades](
	[LocalidadId] [int] IDENTITY(1,1) NOT NULL,
	[NombreLocalidad] [nvarchar](100) NOT NULL,
	[ProvinciaId] [int] NOT NULL,
 CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED 
(
	[LocalidadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mascotas]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mascotas](
	[MascotaId] [int] IDENTITY(1,1) NOT NULL,
	[TipoDeMascotaId] [int] NOT NULL,
	[RazaId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[FechaDeNacimiento] [date] NULL,
 CONSTRAINT [PK_Mascotas] PRIMARY KEY CLUSTERED 
(
	[MascotaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicamentos]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicamentos](
	[MedicamentoId] [int] IDENTITY(1,1) NOT NULL,
	[NombreComercial] [nvarchar](100) NOT NULL,
	[TipoDeMedicamentoId] [int] NOT NULL,
	[FormaFarmaceuticaId] [int] NOT NULL,
	[LaboratorioId] [int] NOT NULL,
	[PrecioVenta] [decimal](18, 2) NOT NULL,
	[UnidadesEnStock] [int] NOT NULL,
	[NivelDeReposicion] [int] NOT NULL,
	[CantidadesPorUnidad] [nvarchar](50) NOT NULL,
	[Suspendido] [bit] NOT NULL,
 CONSTRAINT [PK_Medicamentos] PRIMARY KEY CLUSTERED 
(
	[MedicamentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[ProveedorId] [int] IDENTITY(1,1) NOT NULL,
	[CUIT] [nvarchar](13) NOT NULL,
	[RazonSocial] [nvarchar](100) NOT NULL,
	[PersonaDeContacto] [nvarchar](100) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[LocalidadId] [int] NOT NULL,
	[ProvinciaId] [int] NOT NULL,
	[TelefonoFijo] [nvarchar](20) NULL,
	[TelefonoMovil] [nvarchar](20) NULL,
	[CorreoElectronico] [nvarchar](150) NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[ProveedorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincias](
	[ProvinciaId] [int] IDENTITY(1,1) NOT NULL,
	[NombreProvincia] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Provincias] PRIMARY KEY CLUSTERED 
(
	[ProvinciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Razas]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Razas](
	[RazaId] [int] IDENTITY(1,1) NOT NULL,
	[TipoDeMascotaId] [int] NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Razas] PRIMARY KEY CLUSTERED 
(
	[RazaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDeDocumento]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDeDocumento](
	[TipoDeDocumentoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_TiposDeDocumento] PRIMARY KEY CLUSTERED 
(
	[TipoDeDocumentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDeMascotas]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDeMascotas](
	[TipoDeMascotaId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TiposDeMascotas] PRIMARY KEY CLUSTERED 
(
	[TipoDeMascotaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDeMedicamentos]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDeMedicamentos](
	[TipoDeMedicamentoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TiposDeMedicamentos] PRIMARY KEY CLUSTERED 
(
	[TipoDeMedicamentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDeServicios]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDeServicios](
	[TipoDeServicioId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_TiposDeServicios] PRIMARY KEY CLUSTERED 
(
	[TipoDeServicioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDeTareas]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDeTareas](
	[TipoDeTareaId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_TiposDeTareas] PRIMARY KEY CLUSTERED 
(
	[TipoDeTareaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 18/03/2021 20:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[VentaId] [int] IDENTITY(1,1) NOT NULL,
	[FechaVenta] [datetime] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[DetalleVenta] [nvarchar](50) NULL,
	[Total] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[VentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (2, N'Sergio', N'de Cavo', 2, N'25101343', N'Arèvalo 3114', 1, 1, N'-', N'2227 411774', N'sergiodecavo@hotmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (8, N'Abel', N'Pintos', 2, N'27.123.453', N'Jujuy 98', 9, 13, N'-', N'-', N'-')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (9, N'Juan', N'Carlos', 2, N'14444444', N'', 1, 1, N'422222', N'15555555', N'miMail@yahoo.com.ar')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (10, N'Bruno Josè', N'Irusta', 2, N'32908156', N'Salta 234', 1, 1, N'2227-431657', N'2227-411556', N'irustajose@hotmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (11, N'Silvia Noemì', N'Gaich', 2, N'35908234', N'Albertini 56', 1, 1, N'-', N'2227-5''09098', N'gaichsilvia@gmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (12, N'Silvano', N'Rodriguez', 2, N'14878934', N'Ensenada 908', 2, 1, N'2227-456909', N'-', N'-')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (13, N'Gabriel Jesùs', N'Main', 2, N'34090890', N'Avellaneda 675', 81, 1, N'221-456734', N'221-501343', N'main@gmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (14, N'Eduardo', N'Gonzales', 2, N'21092567', N'Caseros 67', 122, 1, N'-', N'2229-505989', N'-')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (15, N'Ricardo', N'Soulè', 2, N'18768365', N'Arèvalo 467', 1, 1, N'-', N'2227-498767', N'souleart@hotmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (16, N'Martina', N'Barzola', 2, N'36908765', N'Bragado 67', 3, 1, N'2226-471409', N'2226-479087', N'martibarzola@hotmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (17, N'Ruben', N'Briganti', 2, N'18426145', N'Jujuy 89', 1, 1, N'-', N'2227-471724', N'-')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (18, N'Susana', N'Marino', 2, N'21601653', N'Salgado 345', 1, 1, N'-', N'2227-419823', N'marinosusana@hotmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (19, N'Agustina', N'Mendez', 2, N'40012123', N'Salgado 321', 1, 1, N'-', N'2227-509215', N'mendezagus@hotmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (20, N'Inès', N'Julià', 2, N'23176367', N'Echave 890', 1, 1, N'-', N'2227-410934', N'inesjulia@hotmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (21, N'Silvina', N'Millan', 2, N'24781309', N'Rojas 341', 1, 1, N'-', N'2227-550123', N'millansilvina@hotmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (22, N'Ernesto', N'Savia', 2, N'20731685', N'Ajò 401', 1, 1, N'-', N'2227-501912', N'-')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (23, N'Guillermo', N'Guillenea', 2, N'27190287', N'Junìn 907', 1, 1, N'-', N'2227-509137', N'guille@hotmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (24, N'Hermenegildo', N'Luzuriaga', 2, N'12908187', N'Chacabuco 576', 1, 1, N'-', N'2227-415623', N'-')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (25, N'Salvador', N'Iribarne', 2, N'13013134', N'Salgado 210', 1, 1, N'-', N'2227-417649', N'salvador-iribarme@hotmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (26, N'Miguel', N'D''adario', 2, N'16729109', N'Castelli 309', 1, 1, N'-', N'2227-551523', N'-')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (27, N'Constanza', N'Converti', 2, N'34912610', N'Rauch 23', 1, 1, N'-', N'2227-551890', N'converti-connie@hotmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (28, N'Àgata', N'Laprida', 2, N'29198797', N'Libertad 687', 3, 1, N'-', N'2226-556756', N'-')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (29, N'Miriam', N'Solìs', 2, N'34936624', N'Libertad 390', 1, 1, N'-', N'2227-551287', N'-')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (30, N'Martìn', N'Lòpez', 2, N'32197610', N'Peròn 670', 1, 1, N'-', N'2227-189078', N'lopezmartin@hotmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (31, N'Matìas', N'Silvestre', 2, N'38109761', N'Ajò 701', 1, 1, N'-', N'2227-551234', N'silvestre90@hotmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (32, N'Juliàn', N'Gorostegui', 2, N'40108691', N'Moreno 90', 1, 1, N'-', N'2227-411207', N'gorosteguijul89@hotmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (33, N'Renato', N'Scalise', 2, N'18109308', N'Sarmiento 201', 1, 1, N'2227-431902', N'-', N'-')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (34, N'Yolanda', N'Suarez', 2, N'19170286', N'Belgrano 109', 1, 1, N'-', N'2227-401908', N'yolisuarez@hotmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (35, N'Mirta', N'Benitez', 2, N'18301729', N'Belgrano 21', 1, 1, N'-', N'2227-501980', N'-')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (36, N'Hugo', N'Alvarez', 2, N'17034190', N'Rivadavia 145', 1, 1, N'-', N'2227-501748', N'-')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (37, N'Roberto', N'Gutierrez', 2, N'29809980', N'Sarmiento 457', 16, 1, N'-', N'2145 53456778', N'robertogutierrez80@hotmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (38, N'Russo', N'Cecilio', 2, N'30124526', N'Ajo 546', 1, 1, N'-', N'2227 535678', N'Ceciliorusso@gmail.com')
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (39, N'Martinez', N'Nehuen', 2, N'40109829', N'Alberdi 23', 1, 1, N'-', N'2227 417898', N'nehui99@hotmail.com')
GO
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Compras] ON 
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (13, CAST(N'2019-11-05T21:00:14.687' AS DateTime), 1, N'', CAST(195 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (14, CAST(N'2019-11-05T21:02:14.820' AS DateTime), 1, N'', CAST(169 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (15, CAST(N'2019-11-05T21:39:09.147' AS DateTime), 1, N'', CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (16, CAST(N'2019-11-06T15:40:54.677' AS DateTime), 1, N'', CAST(124 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (17, CAST(N'2019-11-06T15:43:40.400' AS DateTime), 1, N'', CAST(90 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (18, CAST(N'2019-11-08T09:47:46.657' AS DateTime), 1, N'', CAST(455 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (19, CAST(N'2019-12-12T17:56:42.153' AS DateTime), 1, N'', CAST(102 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (20, CAST(N'2019-12-12T18:06:45.377' AS DateTime), 1, N'', CAST(135 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (21, CAST(N'2019-12-12T18:17:14.560' AS DateTime), 1, N'', CAST(45 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (22, CAST(N'2019-12-12T18:19:50.163' AS DateTime), 1, N'', CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (23, CAST(N'2019-12-12T18:48:22.937' AS DateTime), 1, N'', CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (24, CAST(N'2019-12-12T18:50:23.617' AS DateTime), 1, N'', CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (27, CAST(N'2019-12-12T22:53:30.497' AS DateTime), 1, N'', CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (29, CAST(N'2019-12-13T17:41:04.140' AS DateTime), 1, N'', CAST(455 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (30, CAST(N'2019-12-13T17:41:58.957' AS DateTime), 1, N'', CAST(90 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (31, CAST(N'2020-06-02T21:13:12.343' AS DateTime), 10, N'', CAST(1500 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (32, CAST(N'2020-06-02T21:13:58.627' AS DateTime), 13, N'', CAST(4180 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (33, CAST(N'2020-06-02T21:14:23.157' AS DateTime), 14, N'', CAST(2550 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (34, CAST(N'2020-06-02T21:14:56.133' AS DateTime), 8, N'', CAST(8350 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (35, CAST(N'2020-06-02T21:15:23.387' AS DateTime), 7, N'', CAST(3590 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (36, CAST(N'2020-06-02T21:15:51.610' AS DateTime), 10, N'', CAST(2239 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (37, CAST(N'2020-06-02T21:16:24.047' AS DateTime), 13, N'', CAST(1700 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (38, CAST(N'2020-06-02T21:16:45.737' AS DateTime), 10, N'', CAST(2500 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (39, CAST(N'2020-06-02T21:17:22.253' AS DateTime), 11, N'', CAST(2544 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (40, CAST(N'2020-06-02T21:18:10.147' AS DateTime), 11, N'', CAST(1431 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (41, CAST(N'2020-06-02T21:18:51.470' AS DateTime), 7, N'', CAST(1602 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (42, CAST(N'2020-06-02T21:19:11.240' AS DateTime), 13, N'', CAST(200 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (43, CAST(N'2020-06-02T21:19:23.750' AS DateTime), 11, N'', CAST(280 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (44, CAST(N'2020-06-02T21:19:36.877' AS DateTime), 10, N'', CAST(250 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (45, CAST(N'2020-06-02T21:21:18.967' AS DateTime), 14, N'', CAST(500 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (46, CAST(N'2020-06-02T21:21:33.273' AS DateTime), 13, N'', CAST(240 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (47, CAST(N'2020-06-02T21:21:45.830' AS DateTime), 12, N'', CAST(240 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (48, CAST(N'2020-06-02T21:21:57.090' AS DateTime), 13, N'', CAST(1750 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (49, CAST(N'2020-06-02T21:22:10.603' AS DateTime), 12, N'', CAST(2250 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (50, CAST(N'2020-06-02T21:26:21.063' AS DateTime), 14, N'', CAST(1170 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (51, CAST(N'2020-06-02T21:26:36.323' AS DateTime), 9, N'', CAST(900 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (52, CAST(N'2020-06-02T21:26:52.207' AS DateTime), 9, N'', CAST(960 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (53, CAST(N'2020-06-02T21:27:03.820' AS DateTime), 10, N'', CAST(560 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (54, CAST(N'2020-06-02T21:27:25.193' AS DateTime), 8, N'', CAST(2000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (55, CAST(N'2020-06-02T21:27:38.893' AS DateTime), 7, N'', CAST(2150 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (56, CAST(N'2020-06-02T21:27:56.087' AS DateTime), 11, N'', CAST(600 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (57, CAST(N'2020-06-02T21:28:25.800' AS DateTime), 7, N'', CAST(1695 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (58, CAST(N'2020-06-02T21:28:45.557' AS DateTime), 8, N'', CAST(670 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (59, CAST(N'2020-06-02T21:29:49.117' AS DateTime), 1, N'', CAST(1350 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (60, CAST(N'2020-06-02T21:30:16.417' AS DateTime), 9, N'', CAST(2437 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (61, CAST(N'2020-06-02T21:32:18.343' AS DateTime), 9, N'', CAST(600 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (62, CAST(N'2020-06-02T21:32:36.863' AS DateTime), 7, N'', CAST(1500 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (63, CAST(N'2020-06-02T21:32:47.517' AS DateTime), 5, N'', CAST(750 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (64, CAST(N'2020-06-02T21:45:55.273' AS DateTime), 17, N'', CAST(618 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (65, CAST(N'2020-06-02T21:46:28.940' AS DateTime), 15, N'', CAST(480 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (66, CAST(N'2020-06-02T21:46:41.290' AS DateTime), 16, N'', CAST(708 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (67, CAST(N'2020-06-02T21:46:54.533' AS DateTime), 8, N'', CAST(600 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (68, CAST(N'2020-06-02T21:48:49.950' AS DateTime), 17, N'', CAST(927 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (69, CAST(N'2020-06-02T21:49:01.897' AS DateTime), 11, N'', CAST(780 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (70, CAST(N'2020-06-02T21:49:19.293' AS DateTime), 15, N'', CAST(2340 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (71, CAST(N'2020-06-02T21:49:43.840' AS DateTime), 16, N'', CAST(735 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (72, CAST(N'2020-06-02T21:49:55.850' AS DateTime), 16, N'', CAST(1305 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (73, CAST(N'2020-06-02T21:50:13.010' AS DateTime), 15, N'', CAST(2340 AS Decimal(18, 0)))
GO
INSERT [dbo].[Compras] ([CompraId], [FechaCompra], [ProveedorId], [DetalleCompra], [Total]) VALUES (74, CAST(N'2020-06-02T21:50:27.183' AS DateTime), 15, N'', CAST(2340 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[Compras] OFF
GO
SET IDENTITY_INSERT [dbo].[Drogas] ON 
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (5, N'adrenalina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (6, N'Adrenalona')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (39, N'Amargos Tònicos')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (35, N'Aminofilina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (1, N'Amoxilina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (50, N'Arecolina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (59, N'Atropina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (62, N'Benadryl')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (26, N'Benzedrina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (42, N'Benzodioxano')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (8, N'Butanefrina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (56, N'Cafeìna')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (21, N'Clopalen')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (20, N'Clopano')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (11, N'Cobefrine')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (58, N'Coramina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (9, N'Corbasil')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (28, N'Dexedrina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (45, N'Dibenamina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (61, N'Dramanine')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (25, N'Efedrina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (7, N'Epinina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (41, N'Ergotamina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (40, N'Ergotoxina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (57, N'Eserina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (54, N'Esmodil')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (31, N'Esparteìna')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (37, N'Glicerosfosfatos')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (36, N'Glucofilina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (48, N'Hidrastina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (16, N'Hordenina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (34, N'Lecitina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (55, N'Lobelina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (23, N'Matiltuamina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (30, N'Metamfetamina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (13, N'Metasimpatol')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (60, N'Metropina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (4, N'Morfina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (53, N'Muscarina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (52, N'Neocesol')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (10, N'Ortoxima')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (17, N'Paredrina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (27, N'Pervitina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (49, N'Pilocarpina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (44, N'Priscolina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (19, N'Privina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (47, N'Quinina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (29, N'Racephen')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (46, N'Regitina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (38, N'Sales de Calcio')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (51, N'Sales de Potasio')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (12, N'Simpatol')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (32, N'Teofilina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (15, N'Tiramina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (33, N'Tiroxina')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (22, N'Tuamino')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (18, N'Vasoxil')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (43, N'Veratrona')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (14, N'Veritol')
GO
INSERT [dbo].[Drogas] ([DrogaId], [NombreDroga]) VALUES (24, N'Vonedrina')
GO
SET IDENTITY_INSERT [dbo].[Drogas] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleados] ON 
GO
INSERT [dbo].[Empleados] ([EmpleadoId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico], [TipoDeTareaId]) VALUES (1, N'Mario', N'Lopez', 2, N'23908987', N'Ajo 456', 1, 1, N'-', N'2227 414546', N'wewewe@hotmail.com', 3)
GO
INSERT [dbo].[Empleados] ([EmpleadoId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico], [TipoDeTareaId]) VALUES (2, N'Roberto', N'Lejtmann', 2, N'34123467', N'Alberdi 45', 1, 1, N'-', N'2227 505989', N'robertolejtmann@hotmail.com', 1)
GO
INSERT [dbo].[Empleados] ([EmpleadoId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico], [TipoDeTareaId]) VALUES (4, N'Ariel ', N'Martìnez', 2, N'32878909', N'Arèvalo 245', 1, 1, N'2227 431900', N'2227 555676', N'martinezariel@gmail.com', 1)
GO
INSERT [dbo].[Empleados] ([EmpleadoId], [Nombre], [Apellido], [TipoDeDocumentoId], [NumeroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico], [TipoDeTareaId]) VALUES (5, N'Mariano', N'Gimènez', 2, N'33986312', N'Buenos Aires 789', 1, 1, N'-', N'2227 415647', N'gimenezmariano@gmail.com', 1)
GO
SET IDENTITY_INSERT [dbo].[Empleados] OFF
GO
SET IDENTITY_INSERT [dbo].[FormasFarmaceuticas] ON 
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (21, N'Aerosoles')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (4, N'Càpsulas Blandas')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (5, N'Càpsulas Duras')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (19, N'Colirios')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (7, N'Comprimidos')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (12, N'Cremas')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (17, N'Emulsiones')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (14, N'Explastos')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (2, N'Granulados')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (20, N'Inhaladores')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (15, N'Inyectables')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (13, N'Jaleas')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (16, N'Jarabes')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (9, N'Òvulos')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (11, N'Pastas')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (1, N'Polvos')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (10, N'Pomadas')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (8, N'Supositorios')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (18, N'Suspensiones')
GO
INSERT [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId], [Descripcion]) VALUES (6, N'Tabletas')
GO
SET IDENTITY_INSERT [dbo].[FormasFarmaceuticas] OFF
GO
SET IDENTITY_INSERT [dbo].[ItemCompras] ON 
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (3, 13, 9, 3, CAST(65 AS Decimal(18, 0)), 9, CAST(195 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (4, 14, 4, 1, CAST(45 AS Decimal(18, 0)), 10, CAST(45 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (5, 14, 10, 2, CAST(45 AS Decimal(18, 0)), 11, CAST(90 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (6, 14, 11, 1, CAST(34 AS Decimal(18, 0)), 12, CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (7, 15, 11, 1, CAST(34 AS Decimal(18, 0)), 13, CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (8, 16, 10, 2, CAST(45 AS Decimal(18, 0)), 14, CAST(90 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (9, 16, 11, 1, CAST(34 AS Decimal(18, 0)), 15, CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (10, 17, 10, 2, CAST(45 AS Decimal(18, 0)), 16, CAST(90 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (11, 18, 9, 7, CAST(65 AS Decimal(18, 0)), 17, CAST(455 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (12, 19, 11, 3, CAST(34 AS Decimal(18, 0)), 18, CAST(102 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (13, 20, 10, 3, CAST(45 AS Decimal(18, 0)), 19, CAST(135 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (14, 21, 10, 1, CAST(45 AS Decimal(18, 0)), 20, CAST(45 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (15, 22, 11, 1, CAST(34 AS Decimal(18, 0)), 21, CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (16, 23, 11, 1, CAST(34 AS Decimal(18, 0)), 22, CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (17, 24, 11, 1, CAST(34 AS Decimal(18, 0)), 23, CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (18, 27, 11, 1, CAST(34 AS Decimal(18, 0)), 24, CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (19, 29, 9, 7, CAST(65 AS Decimal(18, 0)), 25, CAST(455 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (20, 30, 10, 2, CAST(45 AS Decimal(18, 0)), 26, CAST(90 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (21, 31, 12, 5, CAST(300 AS Decimal(18, 0)), 29, CAST(1500 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (22, 32, 16, 3, CAST(500 AS Decimal(18, 0)), 30, CAST(1500 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (23, 32, 22, 4, CAST(670 AS Decimal(18, 0)), 31, CAST(2680 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (24, 33, 20, 5, CAST(140 AS Decimal(18, 0)), 32, CAST(700 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (25, 33, 17, 1, CAST(350 AS Decimal(18, 0)), 33, CAST(350 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (26, 33, 12, 5, CAST(300 AS Decimal(18, 0)), 34, CAST(1500 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (27, 34, 22, 5, CAST(670 AS Decimal(18, 0)), 35, CAST(3350 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (28, 34, 33, 2, CAST(2500 AS Decimal(18, 0)), 36, CAST(5000 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (29, 35, 41, 4, CAST(460 AS Decimal(18, 0)), 37, CAST(1840 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (30, 35, 17, 5, CAST(350 AS Decimal(18, 0)), 38, CAST(1750 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (31, 36, 4, 3, CAST(45 AS Decimal(18, 0)), 39, CAST(135 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (32, 36, 30, 3, CAST(468 AS Decimal(18, 0)), 40, CAST(1404 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (33, 36, 17, 2, CAST(350 AS Decimal(18, 0)), 41, CAST(700 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (34, 37, 12, 3, CAST(300 AS Decimal(18, 0)), 42, CAST(900 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (35, 37, 42, 2, CAST(400 AS Decimal(18, 0)), 43, CAST(800 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (36, 38, 12, 3, CAST(300 AS Decimal(18, 0)), 44, CAST(900 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (37, 38, 42, 4, CAST(400 AS Decimal(18, 0)), 45, CAST(1600 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (38, 39, 50, 3, CAST(328 AS Decimal(18, 0)), 46, CAST(984 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (39, 39, 46, 4, CAST(390 AS Decimal(18, 0)), 47, CAST(1560 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (40, 40, 48, 3, CAST(168 AS Decimal(18, 0)), 48, CAST(504 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (41, 40, 15, 3, CAST(309 AS Decimal(18, 0)), 49, CAST(927 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (42, 41, 16, 3, CAST(500 AS Decimal(18, 0)), 50, CAST(1500 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (43, 41, 11, 3, CAST(34 AS Decimal(18, 0)), 51, CAST(102 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (44, 42, 13, 1, CAST(200 AS Decimal(18, 0)), 52, CAST(200 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (45, 43, 20, 2, CAST(140 AS Decimal(18, 0)), 53, CAST(280 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (46, 44, 14, 1, CAST(250 AS Decimal(18, 0)), 54, CAST(250 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (62, 58, 22, 1, CAST(670 AS Decimal(18, 0)), 70, CAST(670 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (63, 59, 18, 3, CAST(450 AS Decimal(18, 0)), 71, CAST(1350 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (64, 60, 16, 2, CAST(500 AS Decimal(18, 0)), 72, CAST(1000 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (65, 60, 34, 3, CAST(479 AS Decimal(18, 0)), 73, CAST(1437 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (66, 61, 13, 3, CAST(200 AS Decimal(18, 0)), 74, CAST(600 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (73, 68, 15, 3, CAST(309 AS Decimal(18, 0)), 81, CAST(927 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (74, 69, 19, 1, CAST(240 AS Decimal(18, 0)), 82, CAST(240 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (75, 69, 45, 3, CAST(180 AS Decimal(18, 0)), 83, CAST(540 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (76, 70, 53, 3, CAST(780 AS Decimal(18, 0)), 84, CAST(2340 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (77, 71, 40, 3, CAST(245 AS Decimal(18, 0)), 85, CAST(735 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (78, 72, 51, 3, CAST(435 AS Decimal(18, 0)), 86, CAST(1305 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (79, 73, 53, 3, CAST(780 AS Decimal(18, 0)), 87, CAST(2340 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (80, 74, 53, 3, CAST(780 AS Decimal(18, 0)), 88, CAST(2340 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (47, 45, 16, 1, CAST(500 AS Decimal(18, 0)), 55, CAST(500 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (48, 46, 19, 1, CAST(240 AS Decimal(18, 0)), 56, CAST(240 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (49, 47, 19, 1, CAST(240 AS Decimal(18, 0)), 57, CAST(240 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (50, 48, 17, 5, CAST(350 AS Decimal(18, 0)), 58, CAST(1750 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (51, 49, 18, 5, CAST(450 AS Decimal(18, 0)), 59, CAST(2250 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (52, 50, 46, 3, CAST(390 AS Decimal(18, 0)), 60, CAST(1170 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (53, 51, 12, 3, CAST(300 AS Decimal(18, 0)), 61, CAST(900 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (54, 52, 19, 4, CAST(240 AS Decimal(18, 0)), 62, CAST(960 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (55, 53, 20, 4, CAST(140 AS Decimal(18, 0)), 63, CAST(560 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (56, 54, 16, 4, CAST(500 AS Decimal(18, 0)), 64, CAST(2000 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (57, 55, 18, 3, CAST(450 AS Decimal(18, 0)), 65, CAST(1350 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (58, 55, 13, 4, CAST(200 AS Decimal(18, 0)), 66, CAST(800 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (59, 56, 13, 3, CAST(200 AS Decimal(18, 0)), 67, CAST(600 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (60, 57, 9, 3, CAST(65 AS Decimal(18, 0)), 68, CAST(195 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (61, 57, 16, 3, CAST(500 AS Decimal(18, 0)), 69, CAST(1500 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (67, 62, 16, 3, CAST(500 AS Decimal(18, 0)), 75, CAST(1500 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (68, 63, 14, 3, CAST(250 AS Decimal(18, 0)), 76, CAST(750 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (69, 64, 15, 2, CAST(309 AS Decimal(18, 0)), 77, CAST(618 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (70, 65, 19, 2, CAST(240 AS Decimal(18, 0)), 78, CAST(480 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (71, 66, 21, 3, CAST(236 AS Decimal(18, 0)), 79, CAST(708 AS Decimal(18, 0)))
GO
INSERT [dbo].[ItemCompras] ([ItemCompra], [CompraId], [MedicamentoId], [Cantidad], [PrecioUnitario], [KardexId], [Total]) VALUES (72, 67, 13, 3, CAST(200 AS Decimal(18, 0)), 80, CAST(600 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[ItemCompras] OFF
GO
SET IDENTITY_INSERT [dbo].[Kardex] ON 
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (9, 9, CAST(N'2019-11-05' AS Date), N'CO 13', 3, 0, 3, CAST(65 AS Decimal(18, 0)), CAST(65 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (10, 4, CAST(N'2019-11-05' AS Date), N'CO 14', 1, 0, 1, CAST(45 AS Decimal(18, 0)), CAST(45 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (11, 10, CAST(N'2019-11-05' AS Date), N'CO 14', 2, 0, 2, CAST(45 AS Decimal(18, 0)), CAST(45 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (12, 11, CAST(N'2019-11-05' AS Date), N'CO 14', 1, 0, 1, CAST(34 AS Decimal(18, 0)), CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (13, 11, CAST(N'2019-11-05' AS Date), N'CO 15', 1, 0, 2, CAST(34 AS Decimal(18, 0)), CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (14, 10, CAST(N'2019-11-06' AS Date), N'CO 16', 2, 0, 4, CAST(45 AS Decimal(18, 0)), CAST(45 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (15, 11, CAST(N'2019-11-06' AS Date), N'CO 16', 1, 0, 2, CAST(34 AS Decimal(18, 0)), CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (16, 10, CAST(N'2019-11-06' AS Date), N'CO 17', 2, 0, 6, CAST(45 AS Decimal(18, 0)), CAST(45 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (17, 9, CAST(N'2019-11-08' AS Date), N'CO 18', 7, 0, 10, CAST(65 AS Decimal(18, 0)), CAST(65 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (18, 11, CAST(N'2019-12-12' AS Date), N'CO 19', 3, 0, 5, CAST(34 AS Decimal(18, 0)), CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (19, 10, CAST(N'2019-12-12' AS Date), N'CO 20', 3, 0, 7, CAST(45 AS Decimal(18, 0)), CAST(45 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (20, 10, CAST(N'2019-12-12' AS Date), N'CO 21', 1, 0, 8, CAST(45 AS Decimal(18, 0)), CAST(45 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (21, 11, CAST(N'2019-12-12' AS Date), N'CO 22', 1, 0, 6, CAST(34 AS Decimal(18, 0)), CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (22, 11, CAST(N'2019-12-12' AS Date), N'CO 23', 1, 0, 6, CAST(34 AS Decimal(18, 0)), CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (23, 11, CAST(N'2019-12-12' AS Date), N'CO 24', 1, 0, 6, CAST(34 AS Decimal(18, 0)), CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (24, 11, CAST(N'2019-12-12' AS Date), N'CO 27', 1, 0, 6, CAST(34 AS Decimal(18, 0)), CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (25, 9, CAST(N'2019-12-13' AS Date), N'CO 29', 7, 0, 17, CAST(65 AS Decimal(18, 0)), CAST(65 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (26, 10, CAST(N'2019-12-13' AS Date), N'CO 30', 2, 0, 9, CAST(45 AS Decimal(18, 0)), CAST(45 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (29, 12, CAST(N'2020-06-02' AS Date), N'CO 31', 5, 0, 5, CAST(300 AS Decimal(18, 0)), CAST(300 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (30, 16, CAST(N'2020-06-02' AS Date), N'CO 32', 3, 0, 3, CAST(500 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (31, 22, CAST(N'2020-06-02' AS Date), N'CO 32', 4, 0, 4, CAST(670 AS Decimal(18, 0)), CAST(670 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (32, 20, CAST(N'2020-06-02' AS Date), N'CO 33', 5, 0, 5, CAST(140 AS Decimal(18, 0)), CAST(140 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (33, 17, CAST(N'2020-06-02' AS Date), N'CO 33', 1, 0, 1, CAST(350 AS Decimal(18, 0)), CAST(350 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (34, 12, CAST(N'2020-06-02' AS Date), N'CO 33', 5, 0, 10, CAST(300 AS Decimal(18, 0)), CAST(300 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (35, 22, CAST(N'2020-06-02' AS Date), N'CO 34', 5, 0, 9, CAST(670 AS Decimal(18, 0)), CAST(670 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (36, 33, CAST(N'2020-06-02' AS Date), N'CO 34', 2, 0, 2, CAST(2500 AS Decimal(18, 0)), CAST(2500 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (37, 41, CAST(N'2020-06-02' AS Date), N'CO 35', 4, 0, 4, CAST(460 AS Decimal(18, 0)), CAST(460 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (38, 17, CAST(N'2020-06-02' AS Date), N'CO 35', 5, 0, 6, CAST(350 AS Decimal(18, 0)), CAST(350 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (39, 4, CAST(N'2020-06-02' AS Date), N'CO 36', 3, 0, 4, CAST(45 AS Decimal(18, 0)), CAST(45 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (40, 30, CAST(N'2020-06-02' AS Date), N'CO 36', 3, 0, 3, CAST(468 AS Decimal(18, 0)), CAST(468 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (41, 17, CAST(N'2020-06-02' AS Date), N'CO 36', 2, 0, 3, CAST(350 AS Decimal(18, 0)), CAST(350 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (42, 12, CAST(N'2020-06-02' AS Date), N'CO 37', 3, 0, 8, CAST(300 AS Decimal(18, 0)), CAST(300 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (43, 42, CAST(N'2020-06-02' AS Date), N'CO 37', 2, 0, 2, CAST(400 AS Decimal(18, 0)), CAST(400 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (44, 12, CAST(N'2020-06-02' AS Date), N'CO 38', 3, 0, 8, CAST(300 AS Decimal(18, 0)), CAST(300 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (45, 42, CAST(N'2020-06-02' AS Date), N'CO 38', 4, 0, 6, CAST(400 AS Decimal(18, 0)), CAST(400 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (46, 50, CAST(N'2020-06-02' AS Date), N'CO 39', 3, 0, 3, CAST(328 AS Decimal(18, 0)), CAST(328 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (47, 46, CAST(N'2020-06-02' AS Date), N'CO 39', 4, 0, 4, CAST(390 AS Decimal(18, 0)), CAST(390 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (48, 48, CAST(N'2020-06-02' AS Date), N'CO 40', 3, 0, 3, CAST(168 AS Decimal(18, 0)), CAST(168 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (49, 15, CAST(N'2020-06-02' AS Date), N'CO 40', 3, 0, 3, CAST(309 AS Decimal(18, 0)), CAST(309 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (50, 16, CAST(N'2020-06-02' AS Date), N'CO 41', 3, 0, 6, CAST(500 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (51, 11, CAST(N'2020-06-02' AS Date), N'CO 41', 3, 0, 8, CAST(34 AS Decimal(18, 0)), CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (52, 13, CAST(N'2020-06-02' AS Date), N'CO 42', 1, 0, 1, CAST(200 AS Decimal(18, 0)), CAST(200 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (53, 20, CAST(N'2020-06-02' AS Date), N'CO 43', 2, 0, 7, CAST(140 AS Decimal(18, 0)), CAST(140 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (54, 14, CAST(N'2020-06-02' AS Date), N'CO 44', 1, 0, 1, CAST(250 AS Decimal(18, 0)), CAST(250 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (55, 16, CAST(N'2020-06-02' AS Date), N'CO 45', 1, 0, 4, CAST(500 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (56, 19, CAST(N'2020-06-02' AS Date), N'CO 46', 1, 0, 1, CAST(240 AS Decimal(18, 0)), CAST(240 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (57, 19, CAST(N'2020-06-02' AS Date), N'CO 47', 1, 0, 2, CAST(240 AS Decimal(18, 0)), CAST(240 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (58, 17, CAST(N'2020-06-02' AS Date), N'CO 48', 5, 0, 6, CAST(350 AS Decimal(18, 0)), CAST(350 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (59, 18, CAST(N'2020-06-02' AS Date), N'CO 49', 5, 0, 5, CAST(450 AS Decimal(18, 0)), CAST(450 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (60, 46, CAST(N'2020-06-02' AS Date), N'CO 50', 3, 0, 7, CAST(390 AS Decimal(18, 0)), CAST(390 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (61, 12, CAST(N'2020-06-02' AS Date), N'CO 51', 3, 0, 8, CAST(300 AS Decimal(18, 0)), CAST(300 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (62, 19, CAST(N'2020-06-02' AS Date), N'CO 52', 4, 0, 5, CAST(240 AS Decimal(18, 0)), CAST(240 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (63, 20, CAST(N'2020-06-02' AS Date), N'CO 53', 4, 0, 9, CAST(140 AS Decimal(18, 0)), CAST(140 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (64, 16, CAST(N'2020-06-02' AS Date), N'CO 54', 4, 0, 7, CAST(500 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (65, 18, CAST(N'2020-06-02' AS Date), N'CO 55', 3, 0, 8, CAST(450 AS Decimal(18, 0)), CAST(450 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (66, 13, CAST(N'2020-06-02' AS Date), N'CO 55', 4, 0, 5, CAST(200 AS Decimal(18, 0)), CAST(200 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (67, 13, CAST(N'2020-06-02' AS Date), N'CO 56', 3, 0, 4, CAST(200 AS Decimal(18, 0)), CAST(200 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (68, 9, CAST(N'2020-06-02' AS Date), N'CO 57', 3, 0, 20, CAST(65 AS Decimal(18, 0)), CAST(65 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (69, 16, CAST(N'2020-06-02' AS Date), N'CO 57', 3, 0, 6, CAST(500 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (70, 22, CAST(N'2020-06-02' AS Date), N'CO 58', 1, 0, 5, CAST(670 AS Decimal(18, 0)), CAST(670 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (71, 18, CAST(N'2020-06-02' AS Date), N'CO 59', 3, 0, 8, CAST(450 AS Decimal(18, 0)), CAST(450 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (72, 16, CAST(N'2020-06-02' AS Date), N'CO 60', 2, 0, 5, CAST(500 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (73, 34, CAST(N'2020-06-02' AS Date), N'CO 60', 3, 0, 3, CAST(479 AS Decimal(18, 0)), CAST(479 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (74, 13, CAST(N'2020-06-02' AS Date), N'CO 61', 3, 0, 4, CAST(200 AS Decimal(18, 0)), CAST(200 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (75, 16, CAST(N'2020-06-02' AS Date), N'CO 62', 3, 0, 6, CAST(500 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (76, 14, CAST(N'2020-06-02' AS Date), N'CO 63', 3, 0, 4, CAST(250 AS Decimal(18, 0)), CAST(250 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (77, 15, CAST(N'2020-06-02' AS Date), N'CO 64', 2, 0, 5, CAST(309 AS Decimal(18, 0)), CAST(309 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (78, 19, CAST(N'2020-06-02' AS Date), N'CO 65', 2, 0, 3, CAST(240 AS Decimal(18, 0)), CAST(240 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (79, 21, CAST(N'2020-06-02' AS Date), N'CO 66', 3, 0, 3, CAST(236 AS Decimal(18, 0)), CAST(236 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (80, 13, CAST(N'2020-06-02' AS Date), N'CO 67', 3, 0, 4, CAST(200 AS Decimal(18, 0)), CAST(200 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (81, 15, CAST(N'2020-06-02' AS Date), N'CO 68', 3, 0, 6, CAST(309 AS Decimal(18, 0)), CAST(309 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (82, 19, CAST(N'2020-06-02' AS Date), N'CO 69', 1, 0, 2, CAST(240 AS Decimal(18, 0)), CAST(240 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (83, 45, CAST(N'2020-06-02' AS Date), N'CO 69', 3, 0, 3, CAST(180 AS Decimal(18, 0)), CAST(180 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (84, 53, CAST(N'2020-06-02' AS Date), N'CO 70', 3, 0, 3, CAST(780 AS Decimal(18, 0)), CAST(780 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (85, 40, CAST(N'2020-06-02' AS Date), N'CO 71', 3, 0, 3, CAST(245 AS Decimal(18, 0)), CAST(245 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (86, 51, CAST(N'2020-06-02' AS Date), N'CO 72', 3, 0, 3, CAST(435 AS Decimal(18, 0)), CAST(435 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (87, 53, CAST(N'2020-06-02' AS Date), N'CO 73', 3, 0, 6, CAST(780 AS Decimal(18, 0)), CAST(780 AS Decimal(18, 0)))
GO
INSERT [dbo].[Kardex] ([KardexId], [MedicamentoId], [Fecha], [Movimiento], [Entrada], [Salida], [Saldo], [UltimoCosto], [CostoPromedio]) VALUES (88, 53, CAST(N'2020-06-02' AS Date), N'CO 74', 3, 0, 6, CAST(780 AS Decimal(18, 0)), CAST(780 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[Kardex] OFF
GO
SET IDENTITY_INSERT [dbo].[Laboratorios] ON 
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (1, N'Afford')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (3, N'Agreed SRL')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (4, N'Agro Insumos SA')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (5, N'Agroinco SAAIyC')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (6, N'Agrovet Market Animal Health')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (7, N'Arasu SRL')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (8, N'Argos SRL')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (9, N'Arsa SRL')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (10, N'Aton SRL')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (11, N'Aviar SA')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (12, N'Bacteriol')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (13, N'Bayer Argentina')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (14, N'Bio Zoo SA de CV')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (41, N'BioChemiq')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (42, N'Boehringer Ingelheim')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (43, N'CDV')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (15, N'Centro Integral de Bioquìmica Veterinaria')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (44, N'Chemovet')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (45, N'Chinfield')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (16, N'Dr. Gray SACI')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (47, N'Equi Systems')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (46, N'Fatro-Von Fraken')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (48, N'Ganafort')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (17, N'Histopatologìa Veterniaria Cedevet')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (18, N'Holliday Scott SA')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (19, N'Induvet')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (49, N'Instituto Rosenbusch SA')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (60, N'INTA Rafaela')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (50, N'John Martin')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (51, N'Konig')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (20, N'Laboratorio Alvet')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (21, N'Laboratorio Anàlisis Clìnicos Mirysac')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (22, N'Laboratorio Colòn')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (23, N'Laboratorio de Aguas y Suelos Agropecuarios')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (24, N'Laboratorio de Anàlisis Lac-Vet')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (25, N'Laboratorio Labyes')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (26, N'Laboratorio LCA')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (27, N'Laboratorio Snauiwer')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (28, N'Laboratorio Veterinario Casilda SRL')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (29, N'Laboratorios Alton SACIF')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (30, N'Laboratorios Enco')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (31, N'Laboratorios Grin')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (52, N'Labyes')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (56, N'Mayors')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (55, N'Mivet')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (54, N'MSD Salud Animal')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (32, N'Nieser Argentina SA')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (33, N'Omegasur SA')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (53, N'Over')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (34, N'Proagro - Paraqueños')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (35, N'Rapela')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (38, N'Sintex SA')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (36, N'Sivabon')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (37, N'Step Argentina SA')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (39, N'Tecnològico Frances de Argentina')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (58, N'Tecnovax')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (57, N'Viterra')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (59, N'Windhoek')
GO
INSERT [dbo].[Laboratorios] ([LaboratorioId], [Nombre]) VALUES (40, N'Zootec CA')
GO
SET IDENTITY_INSERT [dbo].[Laboratorios] OFF
GO
SET IDENTITY_INSERT [dbo].[Localidades] ON 
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (19, N'Adolfo Alsina', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (20, N'Adolfo Gonzales Chaves', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (21, N'Alberti', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (22, N'Almirante Brown', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (24, N'Arrecifes', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (25, N'Ayacucho', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (23, N'Azul', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (26, N'Balcarce', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (27, N'Baradero', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (28, N'Benito Juarez', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (29, N'Berazategui', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (30, N'Berisso', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (31, N'Bolivar', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (32, N'Bragado', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (33, N'Brandsen', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (34, N'Campana', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (3, N'Cañuelas', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (35, N'Capitàn Sarmiento', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (36, N'Carlos Casares', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (37, N'Carlos Tejedor', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (38, N'Carmen de Areco', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (105, N'Carmen de Patagones', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (39, N'Castelli', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (40, N'Chacabuco', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (42, N'Chascomus', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (41, N'Chivilcoy', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (43, N'Colòn', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (150, N'Colon', 13)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (44, N'Coronel Dorrego', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (45, N'Coronel Pringles', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (46, N'Coronel Rosales', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (47, N'Coronel Suarez', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (16, N'Daireaux', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (49, N'Dolores', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (50, N'Ensenada', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (51, N'Escobar', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (52, N'Esteban Echeverrìa', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (53, N'Exaltaciòn de la Cruz', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (54, N'Ezeiza', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (55, N'Florencio Varela', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (56, N'Florentino Ameghino', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (57, N'General Alvarado', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (58, N'General Alvear', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (60, N'General Arenales', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (59, N'General Belgrano', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (61, N'General Guido', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (62, N'General Lamadrid', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (63, N'General Las Heras', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (64, N'General Lavalle', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (65, N'General Madariaga', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (66, N'General Paz', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (67, N'General Pinto', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (68, N'General Pueyrredòn', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (69, N'General Rodriguez', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (71, N'General San Martìn', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (70, N'General Viamonte', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (72, N'General Villegas', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (10, N'Goya', 12)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (15, N'Gualeguay', 13)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (73, N'Guaminì', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (74, N'Hipòlito Yrigoyen', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (75, N'Hurlingham', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (76, N'Ituzaingò', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (77, N'Josè C. Paz', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (78, N'Junìn', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (79, N'La Costa', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (80, N'La Matanza', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (81, N'La Plata', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (82, N'Lanùs', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (83, N'Laprida', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (84, N'Las Flores', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (85, N'Leandro N. Alem', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (86, N'Lezama', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (87, N'Lincoln', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (14, N'Loberia', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (1, N'Lobos', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (88, N'Lomas de Zamora', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (89, N'Lujàn', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (90, N'Magdalena', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (91, N'Maipù', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (92, N'Malvinas Argentinas', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (93, N'Mar Chiquita', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (94, N'Marcos Paz', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (95, N'Mercedes', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (96, N'Merlo', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (97, N'Monte Hermoso', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (99, N'Moreno', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (100, N'Moròn', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (101, N'Navarro', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (102, N'Necochea', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (103, N'Nueve de Julio', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (104, N'Olavarrìa', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (106, N'Pehuajò', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (107, N'Pellegrini', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (108, N'Pergamino', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (109, N'Pila', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (110, N'Pilar', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (111, N'Pinamar', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (112, N'Presidente Peròn', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (113, N'Puan', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (114, N'Punta Indio', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (115, N'Quilmes', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (116, N'Ramallo', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (117, N'Rauch', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (8, N'Resistencia', 20)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (12, N'Rio Tercero', 2)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (118, N'Rivadavia', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (119, N'Rojas', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (2, N'Roque Pèrez', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (121, N'Saavedra', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (122, N'Saladillo', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (123, N'Saliquelò', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (124, N'Salto', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (125, N'San Andrès de Giles', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (126, N'San Antonio de Areco', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (127, N'San Cayetano', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (129, N'San Fernando', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (128, N'San Isidro', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (130, N'San Miguel', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (98, N'San Miguel del Monte', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (131, N'San Nicolàs', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (132, N'San Pedro', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (17, N'San Rafael', 21)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (13, N'San Salvador', 5)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (133, N'San Vicente', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (11, N'Santa Rosa', 17)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (134, N'Tandìl', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (135, N'Tapalquè', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (136, N'Tigre', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (137, N'Tordillo', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (138, N'Tornquist', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (139, N'Trenque Lauquen', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (140, N'Tres Arroyos', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (141, N'Tres de Febrero', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (142, N'Tres Lomas', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (143, N'Veinticinco de Mayo', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (144, N'Vicente Lòpez', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (9, N'Victoria', 13)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (145, N'Villa Gesell', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (146, N'Villarino', 1)
GO
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (147, N'Zàrate', 1)
GO
SET IDENTITY_INSERT [dbo].[Localidades] OFF
GO
SET IDENTITY_INSERT [dbo].[Mascotas] ON 
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (4, 1, 14, 2, N'Fratacho', CAST(N'2018-12-24' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (5, 1, 14, 2, N'Iguanodonte', CAST(N'2017-09-13' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (9, 2, 21, 36, N'Hugo', CAST(N'2019-08-27' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (11, 2, 21, 17, N'Rupert', CAST(N'2019-09-13' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (12, 14, 61, 16, N'Lulu', CAST(N'2019-01-15' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (13, 14, 60, 13, N'Manteca', CAST(N'2018-03-14' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (14, 7, 105, 32, N'Mirco', CAST(N'2019-11-30' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (15, 3, 56, 21, N'Pepe', CAST(N'2017-07-11' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (16, 1, 40, 35, N'Catito', CAST(N'2019-11-01' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (17, 1, 46, 27, N'Puma', CAST(N'2018-11-13' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (18, 5, 112, 21, N'Neneco', CAST(N'2020-03-03' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (19, 20, 121, 13, N'Martita', CAST(N'2019-10-12' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (20, 14, 61, 26, N'Dolly', CAST(N'2018-03-13' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (21, 21, 124, 18, N'Juancho', CAST(N'2019-02-19' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (22, 2, 20, 28, N'Capucha', CAST(N'2018-11-06' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (23, 14, 61, 26, N'Party', CAST(N'2019-08-27' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (24, 13, 95, 33, N'Donatello', CAST(N'2016-03-15' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (25, 6, 99, 34, N'Ciria', CAST(N'2017-05-09' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (26, 15, 125, 31, N'Rocky Racoon', CAST(N'2019-10-11' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (27, 8, 77, 16, N'Donald', CAST(N'2017-11-07' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (28, 1, 48, 18, N'Gardfield', CAST(N'2020-03-05' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (29, 12, 83, 25, N'Pucho', CAST(N'2019-02-05' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (30, 18, 118, 14, N'Alvin', CAST(N'2019-09-14' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (31, 1, 48, 17, N'Gaturro', CAST(N'2019-12-06' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (32, 6, 101, 21, N'Vicky', CAST(N'2019-08-27' AS Date))
GO
INSERT [dbo].[Mascotas] ([MascotaId], [TipoDeMascotaId], [RazaId], [ClienteId], [Nombre], [FechaDeNacimiento]) VALUES (33, 8, 78, 28, N'Paco', CAST(N'2020-01-31' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Mascotas] OFF
GO
SET IDENTITY_INSERT [dbo].[Medicamentos] ON 
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (4, N'Qura Plus', 1, 1, 3, CAST(45.00 AS Decimal(18, 2)), 16, 3, N'10', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (9, N'Tafirol', 1, 1, 1, CAST(65.00 AS Decimal(18, 2)), 80, 5, N'12', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (10, N'Buscapina', 3, 2, 4, CAST(45.00 AS Decimal(18, 2)), 46, 2, N'12', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (11, N'tytytt', 3, 1, 3, CAST(34.00 AS Decimal(18, 2)), 47, 3, N'3', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (12, N'BioCobre', 7, 17, 4, CAST(300.00 AS Decimal(18, 2)), 59, 5, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (13, N'Caltrion', 7, 17, 4, CAST(200.00 AS Decimal(18, 2)), 39, 5, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (14, N'Ceftioforte', 4, 17, 4, CAST(250.00 AS Decimal(18, 2)), 44, 5, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (15, N'Cortobret B1', 7, 17, 4, CAST(309.00 AS Decimal(18, 2)), 18, 5, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (16, N'Parcillina', 4, 15, 4, CAST(500.00 AS Decimal(18, 2)), 29, 2, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (17, N'Shokade', 7, 17, 4, CAST(350.00 AS Decimal(18, 2)), 53, 5, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (18, N'Amino Lite', 7, 17, 42, CAST(450.00 AS Decimal(18, 2)), 31, 2, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (19, N'Azadieno', 5, 17, 42, CAST(240.00 AS Decimal(18, 2)), 19, 2, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (20, N'Baxin Duo x 250 mg', 4, 7, 42, CAST(140.00 AS Decimal(18, 2)), 21, 1, N'60', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (21, N'Tuberculina PPD Aviar x 5 ml', 16, 15, 43, CAST(236.00 AS Decimal(18, 2)), 8, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (22, N'AC 21 LA', 4, 17, 48, CAST(670.00 AS Decimal(18, 2)), 40, 5, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (23, N'Closantel 500 ml', 5, 15, 48, CAST(1090.00 AS Decimal(18, 2)), 5, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (24, N'Cobre x 250 ml', 7, 15, 48, CAST(500.00 AS Decimal(18, 2)), 5, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (25, N'Crema de ordeño x 500 ml', 10, 12, 48, CAST(236.00 AS Decimal(18, 2)), 10, 2, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (26, N'Crema de ordeño x 2 kgs', 10, 12, 48, CAST(1450.00 AS Decimal(18, 2)), 5, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (27, N'Curabicheras x 250 ml', 5, 21, 48, CAST(450.00 AS Decimal(18, 2)), 5, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (28, N'Curabicheras x 1 kg', 5, 12, 48, CAST(1590.00 AS Decimal(18, 2)), 5, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (29, N'Florfenicol x 100 ml', 4, 15, 48, CAST(358.00 AS Decimal(18, 2)), 5, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (30, N'Formax 1% x 500 ml', 5, 15, 48, CAST(468.00 AS Decimal(18, 2)), 6, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (31, N'Formax 3,5% x 500 ml', 5, 15, 48, CAST(790.00 AS Decimal(18, 2)), 4, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (32, N'Fort Spray Colirio x 250 ml', 4, 19, 48, CAST(200.00 AS Decimal(18, 2)), 20, 2, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (33, N'Ganafen x 5 lts', 6, 17, 48, CAST(2500.00 AS Decimal(18, 2)), 7, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (34, N'Cefalgen 500', 4, 7, 48, CAST(479.00 AS Decimal(18, 2)), 13, 2, N'8', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (35, N'Actinomicol 60 x 50 ml', 11, 15, 49, CAST(468.00 AS Decimal(18, 2)), 5, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (36, N'Antirràbica BHK x 1 ml', 4, 15, 49, CAST(10.00 AS Decimal(18, 2)), 5, 1, N'10', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (37, N'Campy 3', 4, 18, 49, CAST(346.00 AS Decimal(18, 2)), 3, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (38, N'Cicrogil x 100 gs', 5, 12, 49, CAST(560.00 AS Decimal(18, 2)), 3, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (39, N'Conjuntex x 250 ml', 4, 19, 49, CAST(230.00 AS Decimal(18, 2)), 40, 5, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (40, N'Amoxilina 200 x 100 ml', 4, 15, 53, CAST(245.00 AS Decimal(18, 2)), 13, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (41, N'Amoxilina 200 x 250 ml', 4, 15, 53, CAST(460.00 AS Decimal(18, 2)), 14, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (42, N'Cefakan 5 gr', 4, 15, 53, CAST(400.00 AS Decimal(18, 2)), 9, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (43, N'Ciromazina 1% x 20 kgs', 5, 1, 53, CAST(5090.00 AS Decimal(18, 2)), 5, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (44, N'Alergil Pet 5 mg', 12, 7, 34, CAST(350.00 AS Decimal(18, 2)), 20, 5, N'10', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (45, N'Atropina 5 ml', 8, 19, 34, CAST(180.00 AS Decimal(18, 2)), 103, 10, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (46, N'Cefatidina x 750 mg', 4, 7, 34, CAST(390.00 AS Decimal(18, 2)), 26, 1, N'10', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (47, N'Clean Eyes x 50 gr', 10, 1, 34, CAST(276.00 AS Decimal(18, 2)), 3, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (48, N'Ampicilina Complex 5 mg', 4, 15, 57, CAST(168.00 AS Decimal(18, 2)), 6, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (49, N'Engordan Plus Ade 10 ml', 7, 15, 57, CAST(409.00 AS Decimal(18, 2)), 5, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (50, N'Mucolisin x 100 ml', 14, 15, 57, CAST(328.00 AS Decimal(18, 2)), 5, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (51, N'Recovery x 500 ml', 7, 15, 57, CAST(435.00 AS Decimal(18, 2)), 7, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (52, N'Ranitidina WK x 500 ml', 12, 17, 59, CAST(410.00 AS Decimal(18, 2)), 4, 1, N'1', 0)
GO
INSERT [dbo].[Medicamentos] ([MedicamentoId], [NombreComercial], [TipoDeMedicamentoId], [FormaFarmaceuticaId], [LaboratorioId], [PrecioVenta], [UnidadesEnStock], [NivelDeReposicion], [CantidadesPorUnidad], [Suspendido]) VALUES (53, N'Ranitidina WK x 1000 ml', 12, 17, 59, CAST(780.00 AS Decimal(18, 2)), 13, 1, N'1', 0)
GO
SET IDENTITY_INSERT [dbo].[Medicamentos] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedores] ON 
GO
INSERT [dbo].[Proveedores] ([ProveedorId], [CUIT], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (1, N'20-25101343-9', N'SERGIO', N'YO', N'Arèvalo 3114', 1, 1, N'-', N'-', N'-')
GO
INSERT [dbo].[Proveedores] ([ProveedorId], [CUIT], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (5, N'20-13546980-1', N'CV', N'Mario Gonzales', N'Piñeiro 435', 32, 1, N'224-445678', N'224-467567', N'cv@hotmail.com')
GO
INSERT [dbo].[Proveedores] ([ProveedorId], [CUIT], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (6, N'20-19809879-9', N'Pet', N'Omar Batistuta', N'Gualeguay 45', 28, 1, N'113-458798', N'113-411890', N'petmascotas@gmail.com')
GO
INSERT [dbo].[Proveedores] ([ProveedorId], [CUIT], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (7, N'20-13567809-1', N'Canino', N'Marcelo Piragua', N'Alberdi 578', 50, 1, N'021-478764', N'021-417890', N'canino@hotmail.com')
GO
INSERT [dbo].[Proveedores] ([ProveedorId], [CUIT], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (8, N'25-30564134-9', N'Espacio Equino', N'Mercedes Laporte', N'Azcuènaga 78', 135, 1, N'3456-452678', N'3456-500989', N'espacioequino@gmail.com.ar')
GO
INSERT [dbo].[Proveedores] ([ProveedorId], [CUIT], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (9, N'20-25908999-1', N'Felinos y Cìa', N'juàn Rutherford', N'Avellaneda 34', 36, 1, N'2314-409234', N'2314-556787', N'felinosycia@hotmail.com')
GO
INSERT [dbo].[Proveedores] ([ProveedorId], [CUIT], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (10, N'25-19890987-9', N'Aves ', N'Ruth Lòpez', N'Chacabuco 790', 26, 1, N'209-407123', N'209-509890', N'aves@gmail.com')
GO
INSERT [dbo].[Proveedores] ([ProveedorId], [CUIT], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (11, N'25-19032810-8', N'Animals', N'Matìas Suarez', N'Alberdi 80', 80, 1, N'-', N'219-459089', N'animals@hotmail.com')
GO
INSERT [dbo].[Proveedores] ([ProveedorId], [CUIT], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (12, N'25-16029891-1', N'Medicina Animal', N'Inès Robledo', N'Sarmiento y Olavarrìa', 37, 1, N'109-3098765', N'-', N'medicinanimal@hotmail.com')
GO
INSERT [dbo].[Proveedores] ([ProveedorId], [CUIT], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (13, N'20-20781982-6', N'InsEx', N'Alberto Rodriguez', N'Alsina 78', 39, 1, N'-', N'298-98126789', N'insex@hotmail.com')
GO
INSERT [dbo].[Proveedores] ([ProveedorId], [CUIT], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (14, N'20-23109647-1', N'Felino`s', N'Franco Aleman', N'Alberdi 109', 52, 1, N'-', N'379-34789098', N'felinos@gmail.com')
GO
INSERT [dbo].[Proveedores] ([ProveedorId], [CUIT], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (15, N'20-32453758-9', N'CatCan', N'Ruben Gutierrez', N'Avellaneda 45', 36, 1, N'-', N'2245-23450989', N'catcan@gmail.com')
GO
INSERT [dbo].[Proveedores] ([ProveedorId], [CUIT], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (16, N'25-17900435-0', N'Mascota`s', N'Mariela Benavidez', N'Sarmiento 342', 26, 1, N'2134-489900', N'-', N'mascotas@hotmail.com')
GO
INSERT [dbo].[Proveedores] ([ProveedorId], [CUIT], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (17, N'20-28980214-8', N'VetMed', N'Jorge Ramirez', N'Suipacha 578', 84, 1, N'011-53679098', N'-', N'vetmed@hotmail.com')
GO
INSERT [dbo].[Proveedores] ([ProveedorId], [CUIT], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (18, N'25-32789019-9', N'Aves y Cìa', N'Gabriela Morales', N'Alberti 902', 27, 1, N'2651 490876', N'2651 780909', N'avesycia@hotmail.com')
GO
INSERT [dbo].[Proveedores] ([ProveedorId], [CUIT], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (19, N'20-34910712-9', N'Magma', N'Adabel Moreda', N'Avellaneda y Sucre', 31, 1, N'-', N'1456 490180', N'magma@hotmail.com')
GO
INSERT [dbo].[Proveedores] ([ProveedorId], [CUIT], [RazonSocial], [PersonaDeContacto], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico]) VALUES (20, N'25-32109518-0', N'Mamifero`s', N'Juana Del Valle', N'Libertad 109', 34, 1, N'-', N'1536 128990', N'mamiferos@hotmail.com')
GO
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
GO
SET IDENTITY_INSERT [dbo].[Provincias] ON 
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (1, N'Buenos Aires')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (9, N'Catamarca')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (20, N'Chaco')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (11, N'Chubut')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (2, N'Còrdoba')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (12, N'Corrientes')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (13, N'Entre Rios')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (19, N'Formosa')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (29, N'Islas Malvinas')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (5, N'Jujuy')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (17, N'La Pampa')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (8, N'La Rioja')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (21, N'Mendoza')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (4, N'Misiones')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (14, N'Neuquen')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (10, N'Rio Negro')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (6, N'Salta')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (22, N'San Juan')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (23, N'San Luis')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (15, N'Santa Cruz')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (3, N'Santa Fe')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (18, N'Santiago Del Estero')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (16, N'Tierra Del Fuego')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (24, N'Tucuman')
GO
SET IDENTITY_INSERT [dbo].[Provincias] OFF
GO
SET IDENTITY_INSERT [dbo].[Razas] ON 
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (14, 1, N'Scottish Foid')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (15, 2, N'Golden')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (16, 6, N'Holando-Argentina')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (18, 2, N'caniche')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (19, 2, N'Bulldog')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (20, 2, N'Poodle')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (21, 2, N'Pastor Alemàn')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (22, 2, N'Labrador')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (23, 2, N'Chihuahua')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (24, 2, N'Pug')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (25, 2, N'Boxer')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (26, 2, N'Galgo')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (27, 2, N'Rottweiler')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (28, 2, N'Pomerania')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (29, 2, N'Gran Danès')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (30, 2, N'Border Collie')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (31, 2, N'Collie')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (32, 2, N'Husky')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (33, 2, N'San Bernardo')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (34, 2, N'Doberman')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (35, 1, N'Persa')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (36, 1, N'Maine Coon')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (37, 1, N'Sphynx')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (38, 1, N'Bengala')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (39, 1, N'Savannah')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (40, 1, N'Angora Turco')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (41, 1, N'Azul Ruso')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (42, 1, N'Siberiano')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (43, 1, N'American Shothair')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (44, 1, N'Bombay')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (45, 1, N'Himalayo')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (46, 1, N'Devon Rex')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (47, 1, N'Balinès')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (48, 1, N'Ocicat')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (49, 1, N'Somalì')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (50, 1, N'Tonkinès')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (51, 1, N'LaPerm')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (52, 3, N'Àrabe')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (53, 3, N'Pura Sangre')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (54, 3, N'Appaloosa')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (55, 3, N'Shire')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (56, 3, N'Andalùz')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (57, 3, N'Mustang')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (58, 3, N'Morgan')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (59, 3, N'Percheròn')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (60, 14, N'Corriedale')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (61, 14, N'Merino')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (62, 14, N'Lincoln')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (63, 14, N'Argentino')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (64, 16, N'Hampshire')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (65, 16, N'Poland China')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (66, 17, N'Filibar')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (67, 17, N'Filidor')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (68, 17, N'Leghorn')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (69, 17, N'Plymouth Rock')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (70, 17, N'Rhode Island Red')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (71, 17, N'Sussex')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (72, 19, N'Comùn')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (73, 19, N'Piquicorto')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (74, 19, N'Careto')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (75, 8, N'Barcino')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (76, 8, N'Maicero')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (77, 8, N'Capuchino')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (78, 8, N'Crestòn')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (79, 8, N'Picazo')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (80, 8, N'Cabeza Negra')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (81, 12, N'Pecho Ancho')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (82, 12, N'Bronceado')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (83, 12, N'Borbòn Rojo')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (84, 12, N'Negro')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (85, 12, N'Nevado de Virginia')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (86, 12, N'Pizarra')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (87, 12, N'Narragansett')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (88, 12, N'Blanco')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (89, 12, N'Rojo de Las Ardenas')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (90, 12, N'Blanco Enano')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (91, 12, N'Crollwitzer')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (92, 13, N'Mora')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (93, 13, N'Radiada')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (94, 13, N'Mediterranea')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (95, 13, N'Terrestre Argentina')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (96, 13, N'Rusa')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (97, 6, N'Angus')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (98, 6, N'Hereford')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (99, 6, N'Brahman')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (100, 6, N'Brangus')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (101, 6, N'Limusin')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (102, 6, N'Criollo')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (103, 6, N'Jersey')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (104, 7, N'Angora')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (105, 7, N'Cabeza de Leòn')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (106, 7, N'Holandès')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (107, 7, N'Californiano')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (108, 7, N'Arlequìn')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (109, 7, N'Pannon White')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (110, 7, N'Azul de Viena')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (111, 11, N'Varias')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (112, 5, N'Varias')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (113, 18, N'Gigante Crema')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (114, 18, N'Gigante Negra')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (115, 18, N'Gigante Morada')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (116, 18, N'Gigante Gris')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (117, 18, N'Pigmea Neotropical')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (118, 18, N'De Tierra Copetuda')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (119, 18, N'Pigmea Montañesa')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (120, 18, N'Voladora del Norte')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (121, 20, N'Varios')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (122, 10, N'Asiàtico')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (123, 10, N'Del Cabo')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (124, 21, N'Varios')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (125, 15, N'Estandar')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (126, 15, N'Bull')
GO
INSERT [dbo].[Razas] ([RazaId], [TipoDeMascotaId], [Descripcion]) VALUES (127, 15, N'Whippet')
GO
SET IDENTITY_INSERT [dbo].[Razas] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposDeDocumento] ON 
GO
INSERT [dbo].[TiposDeDocumento] ([TipoDeDocumentoId], [Descripcion]) VALUES (3, N'Carnet Ext.')
GO
INSERT [dbo].[TiposDeDocumento] ([TipoDeDocumentoId], [Descripcion]) VALUES (2, N'DNI-LE')
GO
INSERT [dbo].[TiposDeDocumento] ([TipoDeDocumentoId], [Descripcion]) VALUES (6, N'Part. Nac.')
GO
INSERT [dbo].[TiposDeDocumento] ([TipoDeDocumentoId], [Descripcion]) VALUES (5, N'Pasaporte')
GO
INSERT [dbo].[TiposDeDocumento] ([TipoDeDocumentoId], [Descripcion]) VALUES (4, N'Ruc')
GO
SET IDENTITY_INSERT [dbo].[TiposDeDocumento] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposDeMascotas] ON 
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (18, N'ardilla')
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (11, N'Aves Grandes')
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (5, N'Aves Pequeñas')
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (3, N'Caballo')
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (16, N'Cerdo')
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (7, N'Conejo')
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (17, N'Gallina')
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (19, N'Ganso')
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (1, N'Gato')
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (15, N'Huròn')
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (21, N'Lagarto')
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (10, N'Leon')
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (20, N'Ofidio')
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (14, N'Oveja')
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (8, N'Pato')
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (12, N'Pavo')
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (2, N'Perro')
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (13, N'Tortuga')
GO
INSERT [dbo].[TiposDeMascotas] ([TipoDeMascotaId], [Descripcion]) VALUES (6, N'Vaca')
GO
SET IDENTITY_INSERT [dbo].[TiposDeMascotas] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposDeMedicamentos] ON 
GO
INSERT [dbo].[TiposDeMedicamentos] ([TipoDeMedicamentoId], [Descripcion]) VALUES (1, N'Analgèsicos Esteroidales')
GO
INSERT [dbo].[TiposDeMedicamentos] ([TipoDeMedicamentoId], [Descripcion]) VALUES (9, N'Antiàcidos e Inhibidores de la Acidez Gàstrica')
GO
INSERT [dbo].[TiposDeMedicamentos] ([TipoDeMedicamentoId], [Descripcion]) VALUES (4, N'Antibiòticos')
GO
INSERT [dbo].[TiposDeMedicamentos] ([TipoDeMedicamentoId], [Descripcion]) VALUES (11, N'Antiemèticos')
GO
INSERT [dbo].[TiposDeMedicamentos] ([TipoDeMedicamentoId], [Descripcion]) VALUES (15, N'Antiespasmòdicos')
GO
INSERT [dbo].[TiposDeMedicamentos] ([TipoDeMedicamentoId], [Descripcion]) VALUES (10, N'Antifùngicos')
GO
INSERT [dbo].[TiposDeMedicamentos] ([TipoDeMedicamentoId], [Descripcion]) VALUES (12, N'Antihistamìnicos')
GO
INSERT [dbo].[TiposDeMedicamentos] ([TipoDeMedicamentoId], [Descripcion]) VALUES (5, N'Antiparasitario Externo')
GO
INSERT [dbo].[TiposDeMedicamentos] ([TipoDeMedicamentoId], [Descripcion]) VALUES (6, N'Antiparasitario Interno')
GO
INSERT [dbo].[TiposDeMedicamentos] ([TipoDeMedicamentoId], [Descripcion]) VALUES (8, N'Corticoides')
GO
INSERT [dbo].[TiposDeMedicamentos] ([TipoDeMedicamentoId], [Descripcion]) VALUES (13, N'Laxantes')
GO
INSERT [dbo].[TiposDeMedicamentos] ([TipoDeMedicamentoId], [Descripcion]) VALUES (3, N'Miscelaneos')
GO
INSERT [dbo].[TiposDeMedicamentos] ([TipoDeMedicamentoId], [Descripcion]) VALUES (14, N'Mucolìticos')
GO
INSERT [dbo].[TiposDeMedicamentos] ([TipoDeMedicamentoId], [Descripcion]) VALUES (16, N'Proteìnas')
GO
INSERT [dbo].[TiposDeMedicamentos] ([TipoDeMedicamentoId], [Descripcion]) VALUES (7, N'Vitaminas y Minerales')
GO
SET IDENTITY_INSERT [dbo].[TiposDeMedicamentos] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposDeServicios] ON 
GO
INSERT [dbo].[TiposDeServicios] ([TipoDeServicioId], [Descripcion]) VALUES (1, N'Atencion Veterinaria')
GO
INSERT [dbo].[TiposDeServicios] ([TipoDeServicioId], [Descripcion]) VALUES (6, N'Baño')
GO
INSERT [dbo].[TiposDeServicios] ([TipoDeServicioId], [Descripcion]) VALUES (8, N'Cirugìa')
GO
INSERT [dbo].[TiposDeServicios] ([TipoDeServicioId], [Descripcion]) VALUES (11, N'Consultorìa')
GO
INSERT [dbo].[TiposDeServicios] ([TipoDeServicioId], [Descripcion]) VALUES (10, N'Peluquerìa')
GO
SET IDENTITY_INSERT [dbo].[TiposDeServicios] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposDeTareas] ON 
GO
INSERT [dbo].[TiposDeTareas] ([TipoDeTareaId], [Descripcion]) VALUES (3, N'Administrativo')
GO
INSERT [dbo].[TiposDeTareas] ([TipoDeTareaId], [Descripcion]) VALUES (4, N'Atenciòn')
GO
INSERT [dbo].[TiposDeTareas] ([TipoDeTareaId], [Descripcion]) VALUES (1, N'Veterinario')
GO
SET IDENTITY_INSERT [dbo].[TiposDeTareas] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Drogas_NombreDroga]    Script Date: 18/03/2021 20:17:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Drogas_NombreDroga] ON [dbo].[Drogas]
(
	[NombreDroga] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FormasFarmaceuticas_Descripcion]    Script Date: 18/03/2021 20:17:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_FormasFarmaceuticas_Descripcion] ON [dbo].[FormasFarmaceuticas]
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Laboratorios_Nombre]    Script Date: 18/03/2021 20:17:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Laboratorios_Nombre] ON [dbo].[Laboratorios]
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Localidades_ProvinciaId_NombreLocalidad]    Script Date: 18/03/2021 20:17:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Localidades_ProvinciaId_NombreLocalidad] ON [dbo].[Localidades]
(
	[NombreLocalidad] ASC,
	[ProvinciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Medicamentos_TipoDeMedicamentoId_NombreComercial]    Script Date: 18/03/2021 20:17:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Medicamentos_TipoDeMedicamentoId_NombreComercial] ON [dbo].[Medicamentos]
(
	[NombreComercial] ASC,
	[TipoDeMedicamentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Provincias_NombreProvincia]    Script Date: 18/03/2021 20:17:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Provincias_NombreProvincia] ON [dbo].[Provincias]
(
	[NombreProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TiposDeDocumento_Descripcion]    Script Date: 18/03/2021 20:17:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TiposDeDocumento_Descripcion] ON [dbo].[TiposDeDocumento]
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TiposDeMascotas_Descripcion]    Script Date: 18/03/2021 20:17:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TiposDeMascotas_Descripcion] ON [dbo].[TiposDeMascotas]
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TiposDeMedicamentos_Descripcion]    Script Date: 18/03/2021 20:17:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TiposDeMedicamentos_Descripcion] ON [dbo].[TiposDeMedicamentos]
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TiposDeServicios_Descripcion]    Script Date: 18/03/2021 20:17:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TiposDeServicios_Descripcion] ON [dbo].[TiposDeServicios]
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TiposDeTareas_Decripcion]    Script Date: 18/03/2021 20:17:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TiposDeTareas_Decripcion] ON [dbo].[TiposDeTareas]
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Compras] ADD  CONSTRAINT [DF_Compras_DetalleCompra]  DEFAULT ('') FOR [DetalleCompra]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Localidades] FOREIGN KEY([LocalidadId])
REFERENCES [dbo].[Localidades] ([LocalidadId])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Localidades]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Provincias] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincias] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Provincias]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_TiposDeDocumento] FOREIGN KEY([TipoDeDocumentoId])
REFERENCES [dbo].[TiposDeDocumento] ([TipoDeDocumentoId])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_TiposDeDocumento]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Proveedores] FOREIGN KEY([ProveedorId])
REFERENCES [dbo].[Proveedores] ([ProveedorId])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compra_Proveedores]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Localidades] FOREIGN KEY([LocalidadId])
REFERENCES [dbo].[Localidades] ([LocalidadId])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_Localidades]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Provincias] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincias] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_Provincias]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_TiposDeDocumento] FOREIGN KEY([TipoDeDocumentoId])
REFERENCES [dbo].[TiposDeDocumento] ([TipoDeDocumentoId])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_TiposDeDocumento]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_TiposDeTareas] FOREIGN KEY([TipoDeTareaId])
REFERENCES [dbo].[TiposDeTareas] ([TipoDeTareaId])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_TiposDeTareas]
GO
ALTER TABLE [dbo].[ItemCompras]  WITH CHECK ADD  CONSTRAINT [FK_ItemCompra_Compra] FOREIGN KEY([CompraId])
REFERENCES [dbo].[Compras] ([CompraId])
GO
ALTER TABLE [dbo].[ItemCompras] CHECK CONSTRAINT [FK_ItemCompra_Compra]
GO
ALTER TABLE [dbo].[ItemCompras]  WITH CHECK ADD  CONSTRAINT [FK_ItemCompra_Kardex] FOREIGN KEY([KardexId])
REFERENCES [dbo].[Kardex] ([KardexId])
GO
ALTER TABLE [dbo].[ItemCompras] CHECK CONSTRAINT [FK_ItemCompra_Kardex]
GO
ALTER TABLE [dbo].[ItemVenta]  WITH CHECK ADD  CONSTRAINT [FK_ItemVenta_Venta] FOREIGN KEY([VentaId])
REFERENCES [dbo].[Venta] ([VentaId])
GO
ALTER TABLE [dbo].[ItemVenta] CHECK CONSTRAINT [FK_ItemVenta_Venta]
GO
ALTER TABLE [dbo].[Kardex]  WITH CHECK ADD  CONSTRAINT [FK_Kardex_Medicamentos] FOREIGN KEY([MedicamentoId])
REFERENCES [dbo].[Medicamentos] ([MedicamentoId])
GO
ALTER TABLE [dbo].[Kardex] CHECK CONSTRAINT [FK_Kardex_Medicamentos]
GO
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_Clientes1] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([ClienteId])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_Clientes1]
GO
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_TiposDeMascotas1] FOREIGN KEY([TipoDeMascotaId])
REFERENCES [dbo].[TiposDeMascotas] ([TipoDeMascotaId])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_TiposDeMascotas1]
GO
ALTER TABLE [dbo].[Medicamentos]  WITH CHECK ADD  CONSTRAINT [FK_Medicamentos_FormasFarmaceuticas] FOREIGN KEY([FormaFarmaceuticaId])
REFERENCES [dbo].[FormasFarmaceuticas] ([FormaFarmaceuticaId])
GO
ALTER TABLE [dbo].[Medicamentos] CHECK CONSTRAINT [FK_Medicamentos_FormasFarmaceuticas]
GO
ALTER TABLE [dbo].[Medicamentos]  WITH CHECK ADD  CONSTRAINT [FK_Medicamentos_Laboratorios] FOREIGN KEY([LaboratorioId])
REFERENCES [dbo].[Laboratorios] ([LaboratorioId])
GO
ALTER TABLE [dbo].[Medicamentos] CHECK CONSTRAINT [FK_Medicamentos_Laboratorios]
GO
ALTER TABLE [dbo].[Medicamentos]  WITH CHECK ADD  CONSTRAINT [FK_Medicamentos_TiposDeMedicamentos] FOREIGN KEY([TipoDeMedicamentoId])
REFERENCES [dbo].[TiposDeMedicamentos] ([TipoDeMedicamentoId])
GO
ALTER TABLE [dbo].[Medicamentos] CHECK CONSTRAINT [FK_Medicamentos_TiposDeMedicamentos]
GO
ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD  CONSTRAINT [FK_Proveedores_Localidades] FOREIGN KEY([LocalidadId])
REFERENCES [dbo].[Localidades] ([LocalidadId])
GO
ALTER TABLE [dbo].[Proveedores] CHECK CONSTRAINT [FK_Proveedores_Localidades]
GO
ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD  CONSTRAINT [FK_Proveedores_Provincias] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincias] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Proveedores] CHECK CONSTRAINT [FK_Proveedores_Provincias]
GO
ALTER TABLE [dbo].[Razas]  WITH CHECK ADD  CONSTRAINT [FK_Razas_TiposDeMascotas] FOREIGN KEY([TipoDeMascotaId])
REFERENCES [dbo].[TiposDeMascotas] ([TipoDeMascotaId])
GO
ALTER TABLE [dbo].[Razas] CHECK CONSTRAINT [FK_Razas_TiposDeMascotas]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([ClienteId])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Clientes]
GO
USE [master]
GO
ALTER DATABASE [VeterinariaDeCavo] SET  READ_WRITE 
GO

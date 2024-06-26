USE [master]
GO
/****** Object:  Database [Artink]    Script Date: 27/5/2024 15:25:24 ******/
CREATE DATABASE [Artink]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'artink', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\artink.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'artink_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\artink_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Artink] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Artink].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Artink] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Artink] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Artink] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Artink] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Artink] SET ARITHABORT OFF 
GO
ALTER DATABASE [Artink] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Artink] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Artink] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Artink] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Artink] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Artink] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Artink] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Artink] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Artink] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Artink] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Artink] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Artink] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Artink] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Artink] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Artink] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Artink] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Artink] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Artink] SET RECOVERY FULL 
GO
ALTER DATABASE [Artink] SET  MULTI_USER 
GO
ALTER DATABASE [Artink] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Artink] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Artink] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Artink] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Artink] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Artink] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Artink', N'ON'
GO
ALTER DATABASE [Artink] SET QUERY_STORE = OFF
GO
USE [Artink]
GO
/****** Object:  UserDefinedFunction [dbo].[udf_TitleCase]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[udf_TitleCase] (@InputString VARCHAR(4000) )
RETURNS VARCHAR(4000)
AS
BEGIN
DECLARE @Index INT
DECLARE @Char CHAR(1)
DECLARE @OutputString VARCHAR(255)
SET @OutputString = LOWER(@InputString)
SET @Index = 2
SET @OutputString =
STUFF(@OutputString, 1, 1,UPPER(SUBSTRING(@InputString,1,1)))
WHILE @Index <= LEN(@InputString)
BEGIN
SET @Char = SUBSTRING(@InputString, @Index, 1)
IF @Char IN (' ', ';', ':', '!', '?', ',', '.', '_', '-', '/', '&','''','(')
IF @Index + 1 <= LEN(@InputString)
BEGIN
IF @Char != ''''
OR
UPPER(SUBSTRING(@InputString, @Index + 1, 1)) != 'S'
SET @OutputString =
STUFF(@OutputString, @Index + 1, 1,UPPER(SUBSTRING(@InputString, @Index + 1, 1)))
END
SET @Index = @Index + 1
END
RETURN ISNULL(@OutputString,'')
END

GO
/****** Object:  Table [dbo].[Canton]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Canton](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[IdProvincia] [tinyint] NOT NULL,
 CONSTRAINT [PK_canton] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[IdUsuarioRegistra] [smallint] NOT NULL,
	[IdUsuarioActualiza] [int] NULL,
 CONSTRAINT [PK_categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacto]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacto](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[IdProveedor] [tinyint] NOT NULL,
	[IdUsuarioRegistra] [smallint] NOT NULL,
	[IdUsuarioActualiza] [smallint] NOT NULL,
 CONSTRAINT [PK_contacto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[IdFactura] [smallint] NOT NULL,
	[IdProducto] [tinyint] NOT NULL,
	[IdServicio] [tinyint] NOT NULL,
	[IdTipoPago] [tinyint] NOT NULL,
	[Total] [money] NOT NULL,
	[Subtotal] [money] NOT NULL,
	[Impuesto] [money] NOT NULL,
	[Cantidad] [smallint] NOT NULL,
 CONSTRAINT [PK_detalleFactura] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distrito]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distrito](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[IdCanton] [tinyint] NOT NULL,
 CONSTRAINT [PK_distrito] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Consecutivo] [smallint] NOT NULL,
	[IdUsuario] [smallint] NOT NULL,
	[Fecha] [date] NOT NULL,
	[IdSucursal] [tinyint] NOT NULL,
 CONSTRAINT [PK_factura] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horario]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horario](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Dia] [date] NOT NULL,
	[Mes] [date] NOT NULL,
	[Anno] [date] NOT NULL,
	[Hora] [time](7) NOT NULL,
	[IdSucursal] [tinyint] NOT NULL,
	[IdUsuarioRegsitra] [smallint] NOT NULL,
	[IdUsuarioActualiza] [smallint] NULL,
 CONSTRAINT [PK_horario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[IdProducto] [tinyint] NOT NULL,
	[IdSucursal] [tinyint] NOT NULL,
	[Disponible] [tinyint] NOT NULL,
	[Minima] [tinyint] NOT NULL,
	[Maxima] [tinyint] NOT NULL,
	[UsuarioRegistra] [smallint] NOT NULL,
	[UsuarioActualiza] [smallint] NULL,
 CONSTRAINT [PK_inventario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Marca] [nvarchar](50) NOT NULL,
	[IdCategoria] [tinyint] NOT NULL,
	[Tarifa] [money] NOT NULL,
	[Sku] [nvarchar](50) NOT NULL,
	[Cantidad] [tinyint] NOT NULL,
	[Unidad] [nvarchar](50) NOT NULL,
	[IdUsuarioRegistra] [smallint] NOT NULL,
	[IdUsuarioActualiza] [smallint] NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[UsuarioRegistra] [smallint] NOT NULL,
	[UusarioActualiza] [smallint] NULL,
 CONSTRAINT [PK_proveedor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_provincia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Hora] [time](7) NOT NULL,
	[IdSucursal] [tinyint] NOT NULL,
	[IdHorario] [smallint] NOT NULL,
	[IdServicio] [tinyint] NOT NULL,
	[Pregunta1] [nvarchar](50) NOT NULL,
	[Pregunta2] [nvarchar](50) NOT NULL,
	[Pregunta3] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[IdUsuarioRegistra] [smallint] NOT NULL,
	[IdUsuarioActualiza] [smallint] NULL,
 CONSTRAINT [PK_reserva] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[IdUsuarioRegistra] [smallint] NOT NULL,
	[IdUsuarioActualiza] [smallint] NULL,
 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Tarifa] [money] NOT NULL,
	[Observacion] [varchar](50) NULL,
	[Activo] [bit] NOT NULL,
	[IdUsuarioRegistra] [smallint] NOT NULL,
	[IdUsuarioActualiza] [smallint] NULL,
	[IdTipoServicio] [tinyint] NOT NULL,
 CONSTRAINT [PK_servicio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](200) NOT NULL,
	[Activo] [bit] NOT NULL,
	[IdProvincia] [tinyint] NOT NULL,
	[IdCanton] [tinyint] NOT NULL,
	[IdDistrito] [smallint] NOT NULL,
	[IdUsuarioRegistra] [smallint] NOT NULL,
	[IdUsuarioActualiza] [smallint] NOT NULL,
 CONSTRAINT [PK_sucursal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPago]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPago](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Referencia] [int] NOT NULL,
 CONSTRAINT [PK_TipoPago] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoServicio]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoServicio](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Tiempo] [time](7) NOT NULL,
 CONSTRAINT [PK_TipoServicio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Cedula] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](200) NOT NULL,
	[Nacimiento] [date] NOT NULL,
	[Contrasenna] [varchar](50) NOT NULL,
	[Genero] [varchar](50) NOT NULL,
	[Activo] [smallint] NOT NULL,
	[Foto] [bit] NULL,
	[IdRol] [tinyint] NOT NULL,
	[IdProvincia] [tinyint] NOT NULL,
	[IdCanton] [tinyint] NOT NULL,
	[IdDistrito] [smallint] NOT NULL,
	[IdUsuarioRegistra] [smallint] NULL,
	[IdUsuarioActualiza] [smallint] NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioSucursal]    Script Date: 27/5/2024 15:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioSucursal](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [smallint] NOT NULL,
	[IdSucursal] [tinyint] NOT NULL,
 CONSTRAINT [PK_UsuarioSucursal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Canton]  WITH CHECK ADD  CONSTRAINT [FK_Canton_Provincia] FOREIGN KEY([IdProvincia])
REFERENCES [dbo].[Provincia] ([Id])
GO
ALTER TABLE [dbo].[Canton] CHECK CONSTRAINT [FK_Canton_Provincia]
GO
ALTER TABLE [dbo].[Contacto]  WITH CHECK ADD  CONSTRAINT [FK_Contacto_Proveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([Id])
GO
ALTER TABLE [dbo].[Contacto] CHECK CONSTRAINT [FK_Contacto_Proveedor]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Factura] FOREIGN KEY([IdFactura])
REFERENCES [dbo].[Factura] ([Id])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Factura]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Prodcuto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Prodcuto]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Servicio] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[Servicio] ([Id])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Servicio]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_TipoPago] FOREIGN KEY([IdTipoPago])
REFERENCES [dbo].[TipoPago] ([Id])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_TipoPago]
GO
ALTER TABLE [dbo].[Distrito]  WITH CHECK ADD  CONSTRAINT [FK_Distrito_Canton] FOREIGN KEY([IdCanton])
REFERENCES [dbo].[Canton] ([Id])
GO
ALTER TABLE [dbo].[Distrito] CHECK CONSTRAINT [FK_Distrito_Canton]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Sucursal] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursal] ([Id])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Sucursal]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Usuario]
GO
ALTER TABLE [dbo].[Horario]  WITH CHECK ADD  CONSTRAINT [FK_Horario_Sucursal] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursal] ([Id])
GO
ALTER TABLE [dbo].[Horario] CHECK CONSTRAINT [FK_Horario_Sucursal]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Producto]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Sucursal] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursal] ([Id])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Sucursal]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Usuario] FOREIGN KEY([IdUsuarioActualiza])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Usuario]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Horario] FOREIGN KEY([IdHorario])
REFERENCES [dbo].[Horario] ([Id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Horario]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Servicio] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[Servicio] ([Id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Servicio]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Sucursal] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursal] ([Id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Sucursal]
GO
ALTER TABLE [dbo].[Servicio]  WITH CHECK ADD  CONSTRAINT [FK_Servicio_TipoServicio] FOREIGN KEY([IdTipoServicio])
REFERENCES [dbo].[TipoServicio] ([Id])
GO
ALTER TABLE [dbo].[Servicio] CHECK CONSTRAINT [FK_Servicio_TipoServicio]
GO
ALTER TABLE [dbo].[Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Sucursal_Canton] FOREIGN KEY([IdCanton])
REFERENCES [dbo].[Canton] ([Id])
GO
ALTER TABLE [dbo].[Sucursal] CHECK CONSTRAINT [FK_Sucursal_Canton]
GO
ALTER TABLE [dbo].[Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Sucursal_Distrito] FOREIGN KEY([IdDistrito])
REFERENCES [dbo].[Distrito] ([Id])
GO
ALTER TABLE [dbo].[Sucursal] CHECK CONSTRAINT [FK_Sucursal_Distrito]
GO
ALTER TABLE [dbo].[Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Sucursal_Provincia] FOREIGN KEY([IdProvincia])
REFERENCES [dbo].[Provincia] ([Id])
GO
ALTER TABLE [dbo].[Sucursal] CHECK CONSTRAINT [FK_Sucursal_Provincia]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Canton] FOREIGN KEY([IdCanton])
REFERENCES [dbo].[Canton] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Canton]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Distrito] FOREIGN KEY([IdDistrito])
REFERENCES [dbo].[Distrito] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Distrito]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Provincia] FOREIGN KEY([IdProvincia])
REFERENCES [dbo].[Provincia] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Provincia]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO
ALTER TABLE [dbo].[UsuarioSucursal]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioSucursal_Sucursal] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursal] ([Id])
GO
ALTER TABLE [dbo].[UsuarioSucursal] CHECK CONSTRAINT [FK_UsuarioSucursal_Sucursal]
GO
ALTER TABLE [dbo].[UsuarioSucursal]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioSucursal_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[UsuarioSucursal] CHECK CONSTRAINT [FK_UsuarioSucursal_Usuario]
GO
USE [master]
GO
ALTER DATABASE [Artink] SET  READ_WRITE 
GO

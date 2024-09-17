USE [master]
GO
/****** Object:  Database [facturacion]    Script Date: 17/9/2024 11:17:26 ******/
CREATE DATABASE [facturacion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'facturacion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\facturacion.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'facturacion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\facturacion_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [facturacion] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [facturacion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [facturacion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [facturacion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [facturacion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [facturacion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [facturacion] SET ARITHABORT OFF 
GO
ALTER DATABASE [facturacion] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [facturacion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [facturacion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [facturacion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [facturacion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [facturacion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [facturacion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [facturacion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [facturacion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [facturacion] SET  ENABLE_BROKER 
GO
ALTER DATABASE [facturacion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [facturacion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [facturacion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [facturacion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [facturacion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [facturacion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [facturacion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [facturacion] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [facturacion] SET  MULTI_USER 
GO
ALTER DATABASE [facturacion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [facturacion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [facturacion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [facturacion] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [facturacion] SET DELAYED_DURABILITY = DISABLED 
GO
USE [facturacion]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 17/9/2024 11:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Articulos](
	[idarticulo] [int] IDENTITY(1,1) NOT NULL,
	[precio] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Articulos] PRIMARY KEY CLUSTERED 
(
	[idarticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 17/9/2024 11:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[idcliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[fechanac] [datetime] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[detallefacturas]    Script Date: 17/9/2024 11:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detallefacturas](
	[iddetalle] [int] IDENTITY(1,1) NOT NULL,
	[nrofactura] [int] NOT NULL,
	[idarticulo] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_detallefacturas] PRIMARY KEY CLUSTERED 
(
	[iddetalle] ASC,
	[nrofactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Factura]    Script Date: 17/9/2024 11:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[nrofactura] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[formapago] [int] NOT NULL,
	[cliente] [int] NOT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[nrofactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[detallefacturas]  WITH CHECK ADD  CONSTRAINT [FK_detallefacturas_Articulos] FOREIGN KEY([idarticulo])
REFERENCES [dbo].[Articulos] ([idarticulo])
GO
ALTER TABLE [dbo].[detallefacturas] CHECK CONSTRAINT [FK_detallefacturas_Articulos]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Clientes] FOREIGN KEY([cliente])
REFERENCES [dbo].[Clientes] ([idcliente])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Clientes]
GO
/****** Object:  StoredProcedure [dbo].[SP_Editar_Articulo]    Script Date: 17/9/2024 11:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Editar_Articulo]
 @idarticulo int,
 @Nombre varchar(50),
 @precio int
 AS
 BEGIN
BEGIN
 Update Articulos set Nombre = @Nombre, precio = @precio where idarticulo = @idarticulo
 END

 END
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_ARTICULO]    Script Date: 17/9/2024 11:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_ARTICULO]
 @idarticulo int
 AS
 BEGIN 
 delete from Articulos where idarticulo = @idarticulo
 END

GO
/****** Object:  StoredProcedure [dbo].[SP_Guardar_Articulo]    Script Date: 17/9/2024 11:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Guardar_Articulo]
 @Nombre varchar(50),
 @precio int
 AS
 BEGIN 
 insert into Articulos (Nombre,precio) values (@Nombre, @precio)
 END

GO
/****** Object:  StoredProcedure [dbo].[SP_InsertarDetalle]    Script Date: 17/9/2024 11:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertarDetalle]
@iddetalle int,
@nrofactura int,
@idarticulo int,
@cantidad int

AS
BEGIN
	insert into detallefacturas (iddetalle,nrofactura,idarticulo,cantidad) values (@iddetalle,@nrofactura,@idarticulo,@cantidad);
	
END

GO
/****** Object:  StoredProcedure [dbo].[SP_InsertarFactura]    Script Date: 17/9/2024 11:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertarFactura]
	@formapago int,
	@cliente int,
	@nrofactura int output
AS
BEGIN
	insert into Factura (fecha,formapago,cliente) values (GETDATE(),@formapago,@cliente);
	set @nrofactura = SCOPE_IDENTITY(); 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Articulos]    Script Date: 17/9/2024 11:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Obtener_Articulos]
AS
BEGIN
select * from Articulos
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerArticuloPorID]    Script Date: 17/9/2024 11:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ObtenerArticuloPorID]
 @idarticulo int
 AS
 BEGIN 
 select * from Articulos where idarticulo = @idarticulo;
 END

GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerFacturas]    Script Date: 17/9/2024 11:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ObtenerFacturas]
	
AS
BEGIN
	select * from factura
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerFacturasPorId]    Script Date: 17/9/2024 11:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ObtenerFacturasPorId]
@nrofactura int	
AS
BEGIN
	select * from factura where nrofactura = @nrofactura
END

GO
USE [master]
GO
ALTER DATABASE [facturacion] SET  READ_WRITE 
GO

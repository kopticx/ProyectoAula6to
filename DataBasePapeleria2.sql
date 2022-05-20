USE [master]
GO
/****** Object:  Database [Papeleria]    Script Date: 20/05/2022 05:32:04 a. m. ******/
CREATE DATABASE [Papeleria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Papeleria', FILENAME = N'C:\BasesSQL\Papeleria\Papeleria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Papeleria_log', FILENAME = N'C:\BasesSQL\Papeleria\Papeleria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Papeleria] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Papeleria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Papeleria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Papeleria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Papeleria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Papeleria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Papeleria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Papeleria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Papeleria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Papeleria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Papeleria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Papeleria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Papeleria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Papeleria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Papeleria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Papeleria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Papeleria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Papeleria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Papeleria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Papeleria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Papeleria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Papeleria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Papeleria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Papeleria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Papeleria] SET RECOVERY FULL 
GO
ALTER DATABASE [Papeleria] SET  MULTI_USER 
GO
ALTER DATABASE [Papeleria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Papeleria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Papeleria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Papeleria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Papeleria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Papeleria] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Papeleria', N'ON'
GO
ALTER DATABASE [Papeleria] SET QUERY_STORE = OFF
GO
USE [Papeleria]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 20/05/2022 05:32:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[IdPedido] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NULL,
	[IdUsuario] [int] NULL,
	[Cantidad] [int] NULL,
	[Total] [decimal](18, 0) NULL,
	[FechaPedido] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 20/05/2022 05:32:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[NombreProducto] [varchar](200) NOT NULL,
	[Descripcion] [varchar](1000) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[ImagenUrl1] [varchar](500) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[ImagenUrl2] [varchar](500) NULL,
	[ImagenUrl3] [varchar](500) NULL,
 CONSTRAINT [PK__Producto__09889210B9E38FD3] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoUsuario]    Script Date: 20/05/2022 05:32:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoUsuario](
	[IdTipo] [tinyint] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](30) NULL,
 CONSTRAINT [PK__TipoUsua__9E3A29A5D8A999C7] PRIMARY KEY CLUSTERED 
(
	[IdTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 20/05/2022 05:32:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](30) NULL,
	[Password] [varchar](64) NULL,
	[Email] [varchar](40) NULL,
	[Name] [varchar](100) NULL,
	[UserType] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 
GO
INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [Descripcion], [Precio], [ImagenUrl1], [Cantidad], [ImagenUrl2], [ImagenUrl3]) VALUES (1, N'Lápiz Smarty', N'
Lápiz con Goma Triangular Punta gruesa Bolsa con 4 Piezas Smarty', CAST(16.50 AS Decimal(18, 2)), N'https://res.cloudinary.com/kopticx/image/upload/v1652530923/211657-1200-auto_neacqq.jpg', 100, NULL, NULL)
GO
INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [Descripcion], [Precio], [ImagenUrl1], [Cantidad], [ImagenUrl2], [ImagenUrl3]) VALUES (2, N'Cuaderno 100 hojas Smarty', N'Cuaderno Cosido de 100 Hojas Profesional de Raya Smarty Plus', CAST(42.50 AS Decimal(18, 2)), N'https://res.cloudinary.com/kopticx/image/upload/v1652531335/207599-1200-auto_lmzrnl.jpg', 200, NULL, NULL)
GO
INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [Descripcion], [Precio], [ImagenUrl1], [Cantidad], [ImagenUrl2], [ImagenUrl3]) VALUES (3, N'
Bolígrafo Punto Mediano Paper Mate', N'
Bolígrafo Punto Mediano Stick Borrable Negro Blíster con 2 Piezas Erase Mate', CAST(48.80 AS Decimal(18, 2)), N'https://res.cloudinary.com/kopticx/image/upload/c_scale,w_400/v1652531713/211350-1200-auto_dqrt4s.jpg', 40, NULL, NULL)
GO
INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [Descripcion], [Precio], [ImagenUrl1], [Cantidad], [ImagenUrl2], [ImagenUrl3]) VALUES (4, N'Calculadora Científica Casio', N'Calculadora Científica de con 552 Funciones Casio', CAST(573.00 AS Decimal(18, 2)), N'https://res.cloudinary.com/kopticx/image/upload/v1652542803/205838-1200-auto_ozvc6u.jpg', 20, NULL, NULL)
GO
INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [Descripcion], [Precio], [ImagenUrl1], [Cantidad], [ImagenUrl2], [ImagenUrl3]) VALUES (5, N'
Lápices de Colores Caja con 24 Piezas + 4 Norma', N'
Lápices de Colores Caja con 24 Piezas + 4 Largos Redondos Norma', CAST(204.00 AS Decimal(18, 2)), N'https://res.cloudinary.com/kopticx/image/upload/v1652659420/213887-1200-auto_tmawhd.jpg', 40, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoUsuario] ON 
GO
INSERT [dbo].[TipoUsuario] ([IdTipo], [Tipo]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[TipoUsuario] ([IdTipo], [Tipo]) VALUES (2, N'Usuario')
GO
SET IDENTITY_INSERT [dbo].[TipoUsuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([IdUser], [UserName], [Password], [Email], [Name], [UserType]) VALUES (1, N'Kevin1020', N'4bf14cfaf7d2391ff591f02e8e24a0ccbe792ed52ecc04f28f17a4b8ff5a1587', N'fdzk800@gmail.com', N'Kevin Fernandez', 2)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK__Pedido__IdProduc__3F466844] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK__Pedido__IdProduc__3F466844]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUser])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([UserType])
REFERENCES [dbo].[TipoUsuario] ([IdTipo])
GO
USE [master]
GO
ALTER DATABASE [Papeleria] SET  READ_WRITE 
GO

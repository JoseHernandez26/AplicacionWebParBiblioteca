USE [BaseDeDatosBiblioteca]
GO
/****** Object:  Table [dbo].[HistorialDePrestamos]    Script Date: 6/10/2022 2:09:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialDePrestamos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](max) NOT NULL,
	[NombreCompleto] [varchar](max) NOT NULL,
	[FechaDeDevolucion] [datetime] NOT NULL,
	[IdPrestamo] [int] NULL,
 CONSTRAINT [PK_HistorialDePrestamos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistorialDePrestamosDelLibro]    Script Date: 6/10/2022 2:09:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialDePrestamosDelLibro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](max) NOT NULL,
	[NombreCompleto] [varchar](max) NOT NULL,
	[FechaDeDevolucion] [datetime] NOT NULL,
	[IdPrestamo] [int] NOT NULL,
 CONSTRAINT [PK_HistorialDePrestamosDelLibro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libros]    Script Date: 6/10/2022 2:09:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libros](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[Estado] [int] NOT NULL,
	[FechaDePublicacion] [datetime] NOT NULL,
	[Tipo] [int] NOT NULL,
 CONSTRAINT [PK_Libros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Movimiento]    Script Date: 05/03/2012 20:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Movimiento](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[geoUbicacion] [varchar](50) NULL,
	[logo] [image] NULL,
	[plantillaEstilo] [int] NOT NULL,
	[maxMarcasInadecuadasRecursoX] [int] NULL,
	[maxRecursosInadecuadosUsuarioZ] [int] NULL,
	[maxRecursosPopularesN] [int] NULL,
	[maxUltimosRecursosM] [int] NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Movimiento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Convocatorias]    Script Date: 05/03/2012 20:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Convocatorias](
	[id] [int] NOT NULL,
	[idMovimiento] [int] NOT NULL,
	[idAutor] [int] NOT NULL,
	[titulo] [varchar](50) NULL,
	[descripcion] [varchar](50) NULL,
	[geoUbicacion] [varchar](50) NULL,
	[inicio] [varchar](50) NULL,
	[fin] [varchar](50) NULL,
	[logo] [image] NULL,
	[minQuorum] [int] NULL,
 CONSTRAINT [PK_Convocatorias] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 05/03/2012 20:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] NOT NULL,
	[idMovimiento] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apodo] [varchar](50) NULL,
	[mail] [varchar](50) NULL,
	[contraseña] [varchar](50) NOT NULL,
	[geoUbicacion] [varchar](50) NULL,
	[fechaRegistro] [varchar](50) NULL,
	[banned] [bit] NULL,
	[privilegio] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioFacebook]    Script Date: 05/03/2012 20:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioFacebook](
	[idUsuario] [int] NOT NULL,
	[idFacebook] [int] NOT NULL,
	[idMovimiento] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioFacebook] PRIMARY KEY CLUSTERED 
(
	[idFacebook] ASC,
	[idMovimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Convocatorias_Convocatorias]    Script Date: 05/03/2012 20:44:23 ******/
ALTER TABLE [dbo].[Convocatorias]  WITH CHECK ADD  CONSTRAINT [FK_Convocatorias_Convocatorias] FOREIGN KEY([id])
REFERENCES [dbo].[Convocatorias] ([id])
GO
ALTER TABLE [dbo].[Convocatorias] CHECK CONSTRAINT [FK_Convocatorias_Convocatorias]
GO
/****** Object:  ForeignKey [FK_UsuarioFacebook_Users]    Script Date: 05/03/2012 20:44:23 ******/
ALTER TABLE [dbo].[UsuarioFacebook]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioFacebook_Users] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[UsuarioFacebook] CHECK CONSTRAINT [FK_UsuarioFacebook_Users]
GO

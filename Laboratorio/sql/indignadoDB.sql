/****** Object:  ForeignKey [FK_Convocatorias_Movimientos]    Script Date: 05/08/2012 13:07:38 ******/
ALTER TABLE [dbo].[Convocatorias] DROP CONSTRAINT [FK_Convocatorias_Movimientos]
GO
/****** Object:  ForeignKey [FK_Convocatorias_Usuarios]    Script Date: 05/08/2012 13:07:38 ******/
ALTER TABLE [dbo].[Convocatorias] DROP CONSTRAINT [FK_Convocatorias_Usuarios]
GO
/****** Object:  ForeignKey [FK_Layout_Movimiento]    Script Date: 05/08/2012 13:07:39 ******/
ALTER TABLE [dbo].[Movimiento] DROP CONSTRAINT [FK_Layout_Movimiento]
GO
/****** Object:  ForeignKey [FK_RssFeeds_Movimiento]    Script Date: 05/08/2012 13:07:39 ******/
ALTER TABLE [dbo].[RssFeeds] DROP CONSTRAINT [FK_RssFeeds_Movimiento]
GO
/****** Object:  ForeignKey [FK_UsuarioFacebook_Users]    Script Date: 05/08/2012 13:07:39 ******/
ALTER TABLE [dbo].[UsuarioFacebook] DROP CONSTRAINT [FK_UsuarioFacebook_Users]
GO
/****** Object:  Table [dbo].[UsuarioFacebook]    Script Date: 05/08/2012 13:07:39 ******/
ALTER TABLE [dbo].[UsuarioFacebook] DROP CONSTRAINT [FK_UsuarioFacebook_Users]
GO
DROP TABLE [dbo].[UsuarioFacebook]
GO
/****** Object:  Table [dbo].[RssFeeds]    Script Date: 05/08/2012 13:07:39 ******/
ALTER TABLE [dbo].[RssFeeds] DROP CONSTRAINT [FK_RssFeeds_Movimiento]
GO
DROP TABLE [dbo].[RssFeeds]
GO
/****** Object:  Table [dbo].[Convocatorias]    Script Date: 05/08/2012 13:07:38 ******/
ALTER TABLE [dbo].[Convocatorias] DROP CONSTRAINT [FK_Convocatorias_Movimientos]
GO
ALTER TABLE [dbo].[Convocatorias] DROP CONSTRAINT [FK_Convocatorias_Usuarios]
GO
DROP TABLE [dbo].[Convocatorias]
GO
/****** Object:  Table [dbo].[Movimiento]    Script Date: 05/08/2012 13:07:39 ******/
ALTER TABLE [dbo].[Movimiento] DROP CONSTRAINT [FK_Layout_Movimiento]
GO
ALTER TABLE [dbo].[Movimiento] DROP CONSTRAINT [DF_Movimiento_idLayout]
GO
DROP TABLE [dbo].[Movimiento]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 05/08/2012 13:07:39 ******/
DROP TABLE [dbo].[Usuarios]
GO
/****** Object:  Table [dbo].[Layouts]    Script Date: 05/08/2012 13:07:39 ******/
DROP TABLE [dbo].[Layouts]
GO
/****** Object:  Table [dbo].[Layouts]    Script Date: 05/08/2012 13:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Layouts](
	[id] [int] NOT NULL,
	[layoutFile] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Layouts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Layouts] ([id], [layoutFile]) VALUES (0, N'~/Views/Shared/_Default.cshtml')
/****** Object:  Table [dbo].[Usuarios]    Script Date: 05/08/2012 13:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idMovimiento] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apodo] [varchar](50) NULL,
	[mail] [varchar](50) NULL,
	[contraseña] [varbinary](50) NOT NULL,
	[latitud] [float] NOT NULL,
	[longitud] [float] NOT NULL,
	[fechaRegistro] [varchar](50) NULL,
	[banned] [bit] NULL,
	[privilegio] [smallint] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT [dbo].[Usuarios] ([id], [idMovimiento], [nombre], [apodo], [mail], [contraseña], [latitud], [longitud], [fechaRegistro], [banned], [privilegio]) VALUES (3, 0, N'Admin', N'Admin', N'admin@indignadoframwok.com', 0x7110EDA4D09E062AA5E4A390B0A572AC0D2C0220, 0, 0, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
/****** Object:  Table [dbo].[Movimiento]    Script Date: 05/08/2012 13:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Movimiento](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[habilitado] [bit] NOT NULL,
	[logo] [varchar](max) NULL,
	[idLayout] [int] NOT NULL CONSTRAINT [DF_Movimiento_idLayout]  DEFAULT ((0)),
	[descripcion] [varchar](max) NULL,
	[latitud] [float] NOT NULL,
	[longitud] [float] NOT NULL,
	[maxMarcasInadecuadasRecursoX] [int] NULL,
	[maxRecursosInadecuadosUsuarioZ] [int] NULL,
	[maxRecursosPopularesN] [int] NULL,
	[maxUltimosRecursosM] [int] NULL,
 CONSTRAINT [PK_Movimiento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Movimiento] ([id], [nombre], [habilitado], [logo], [idLayout], [descripcion], [latitud], [longitud], [maxMarcasInadecuadasRecursoX], [maxRecursosInadecuadosUsuarioZ], [maxRecursosPopularesN], [maxUltimosRecursosM]) VALUES (0, N'fdsg', 0, N'''default.jpg''', 0, N'dsfg', 12, 12, NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[Convocatorias]    Script Date: 05/08/2012 13:07:38 ******/
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
	[logo] [varchar](max) NULL,
	[latitud] [float] NOT NULL,
	[longitud] [float] NOT NULL,
	[inicio] [varchar](50) NULL,
	[fin] [varchar](50) NULL,
	[minQuorum] [int] NULL,
 CONSTRAINT [PK_Convocatorias] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Convocatorias] ([id], [idMovimiento], [idAutor], [titulo], [descripcion], [logo], [latitud], [longitud], [inicio], [fin], [minQuorum]) VALUES (0, 0, 3, N'prot', N'ya', NULL, 0, 0, NULL, NULL, 3)
/****** Object:  Table [dbo].[RssFeeds]    Script Date: 05/08/2012 13:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RssFeeds](
	[url] [nchar](10) NOT NULL,
	[idMovimiento] [int] NOT NULL,
	[tag] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RssFeeds] PRIMARY KEY CLUSTERED 
(
	[url] ASC,
	[idMovimiento] ASC,
	[tag] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioFacebook]    Script Date: 05/08/2012 13:07:39 ******/
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
/****** Object:  ForeignKey [FK_Convocatorias_Movimientos]    Script Date: 05/08/2012 13:07:38 ******/
ALTER TABLE [dbo].[Convocatorias]  WITH CHECK ADD  CONSTRAINT [FK_Convocatorias_Movimientos] FOREIGN KEY([idMovimiento])
REFERENCES [dbo].[Movimiento] ([id])
GO
ALTER TABLE [dbo].[Convocatorias] CHECK CONSTRAINT [FK_Convocatorias_Movimientos]
GO
/****** Object:  ForeignKey [FK_Convocatorias_Usuarios]    Script Date: 05/08/2012 13:07:38 ******/
ALTER TABLE [dbo].[Convocatorias]  WITH CHECK ADD  CONSTRAINT [FK_Convocatorias_Usuarios] FOREIGN KEY([idAutor])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Convocatorias] CHECK CONSTRAINT [FK_Convocatorias_Usuarios]
GO
/****** Object:  ForeignKey [FK_Layout_Movimiento]    Script Date: 05/08/2012 13:07:39 ******/
ALTER TABLE [dbo].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Layout_Movimiento] FOREIGN KEY([idLayout])
REFERENCES [dbo].[Layouts] ([id])
GO
ALTER TABLE [dbo].[Movimiento] CHECK CONSTRAINT [FK_Layout_Movimiento]
GO
/****** Object:  ForeignKey [FK_RssFeeds_Movimiento]    Script Date: 05/08/2012 13:07:39 ******/
ALTER TABLE [dbo].[RssFeeds]  WITH CHECK ADD  CONSTRAINT [FK_RssFeeds_Movimiento] FOREIGN KEY([idMovimiento])
REFERENCES [dbo].[Movimiento] ([id])
GO
ALTER TABLE [dbo].[RssFeeds] CHECK CONSTRAINT [FK_RssFeeds_Movimiento]
GO
/****** Object:  ForeignKey [FK_UsuarioFacebook_Users]    Script Date: 05/08/2012 13:07:39 ******/
ALTER TABLE [dbo].[UsuarioFacebook]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioFacebook_Users] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[UsuarioFacebook] CHECK CONSTRAINT [FK_UsuarioFacebook_Users]
GO

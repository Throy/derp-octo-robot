/****** Object:  ForeignKey [FK_Aprobaciones_Recrusos]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[Aprobaciones] DROP CONSTRAINT [FK_Aprobaciones_Recrusos]
GO
/****** Object:  ForeignKey [FK_Aprobaciones_Usuarios]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[Aprobaciones] DROP CONSTRAINT [FK_Aprobaciones_Usuarios]
GO
/****** Object:  ForeignKey [FK_Convocatorias_Movimientos]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[Convocatorias] DROP CONSTRAINT [FK_Convocatorias_Movimientos]
GO
/****** Object:  ForeignKey [FK_Convocatorias_Usuarios]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[Convocatorias] DROP CONSTRAINT [FK_Convocatorias_Usuarios]
GO
/****** Object:  ForeignKey [FK_Layout_Movimiento]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[Movimiento] DROP CONSTRAINT [FK_Layout_Movimiento]
GO
/****** Object:  ForeignKey [FK_RECURSO_USUARIOS]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[Recursos] DROP CONSTRAINT [FK_RECURSO_USUARIOS]
GO
/****** Object:  ForeignKey [FK_RssFeeds_Movimiento]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[RssFeeds] DROP CONSTRAINT [FK_RssFeeds_Movimiento]
GO
/****** Object:  ForeignKey [FK_UsuarioFacebook_Users]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[UsuarioFacebook] DROP CONSTRAINT [FK_UsuarioFacebook_Users]
GO
/****** Object:  Table [dbo].[RssFeeds]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[RssFeeds] DROP CONSTRAINT [FK_RssFeeds_Movimiento]
GO
DROP TABLE [dbo].[RssFeeds]
GO
/****** Object:  Table [dbo].[Convocatorias]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[Convocatorias] DROP CONSTRAINT [FK_Convocatorias_Movimientos]
GO
ALTER TABLE [dbo].[Convocatorias] DROP CONSTRAINT [FK_Convocatorias_Usuarios]
GO
DROP TABLE [dbo].[Convocatorias]
GO
/****** Object:  Table [dbo].[Movimiento]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[Movimiento] DROP CONSTRAINT [FK_Layout_Movimiento]
GO
ALTER TABLE [dbo].[Movimiento] DROP CONSTRAINT [DF_Movimiento_logo]
GO
ALTER TABLE [dbo].[Movimiento] DROP CONSTRAINT [DF_Movimiento_idLayout]
GO
DROP TABLE [dbo].[Movimiento]
GO
/****** Object:  Table [dbo].[UsuarioFacebook]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[UsuarioFacebook] DROP CONSTRAINT [FK_UsuarioFacebook_Users]
GO
DROP TABLE [dbo].[UsuarioFacebook]
GO
/****** Object:  Table [dbo].[Aprobaciones]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[Aprobaciones] DROP CONSTRAINT [FK_Aprobaciones_Recrusos]
GO
ALTER TABLE [dbo].[Aprobaciones] DROP CONSTRAINT [FK_Aprobaciones_Usuarios]
GO
DROP TABLE [dbo].[Aprobaciones]
GO
/****** Object:  Table [dbo].[Recursos]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[Recursos] DROP CONSTRAINT [FK_RECURSO_USUARIOS]
GO
DROP TABLE [dbo].[Recursos]
GO
/****** Object:  Table [dbo].[Layouts]    Script Date: 05/08/2012 21:19:38 ******/
DROP TABLE [dbo].[Layouts]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 05/08/2012 21:19:38 ******/
DROP TABLE [dbo].[Usuarios]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 05/08/2012 21:19:38 ******/
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
INSERT [dbo].[Usuarios] ([id], [idMovimiento], [nombre], [apodo], [mail], [contraseña], [latitud], [longitud], [fechaRegistro], [banned], [privilegio]) VALUES (3, 0, N'Admin', N'Admin', N'admin@indignadoframwok.com', 0x7110EDA4D09E062AA5E4A390B0A572AC0D2C0220, 0, 0, NULL, NULL, 4)
INSERT [dbo].[Usuarios] ([id], [idMovimiento], [nombre], [apodo], [mail], [contraseña], [latitud], [longitud], [fechaRegistro], [banned], [privilegio]) VALUES (4, 1, N'Agustin', N'Agustin', N'agustin@lavabit.com', 0x7110EDA4D09E062AA5E4A390B0A572AC0D2C0220, -33, -56, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
/****** Object:  Table [dbo].[Layouts]    Script Date: 05/08/2012 21:19:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Layouts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[layoutFile] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Layouts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Layouts] ON
INSERT [dbo].[Layouts] ([id], [layoutFile]) VALUES (0, N'~/Views/Shared/_Default.cshtml')
INSERT [dbo].[Layouts] ([id], [layoutFile]) VALUES (1, N'~/Views/Shared/_Layout1.cshtml')
SET IDENTITY_INSERT [dbo].[Layouts] OFF
/****** Object:  Table [dbo].[Recursos]    Script Date: 05/08/2012 21:19:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recursos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[titulo] [varchar](100) NOT NULL,
	[descripcion] [text] NULL,
	[logo] [varchar](max) NULL,
	[fecha] [datetime] NULL,
	[tipo] [int] NULL,
	[link] [varchar](max) NULL,
 CONSTRAINT [PK_Recursos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Aprobaciones]    Script Date: 05/08/2012 21:19:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aprobaciones](
	[idRecurso] [int] NULL,
	[idUsuario] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioFacebook]    Script Date: 05/08/2012 21:19:38 ******/
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
/****** Object:  Table [dbo].[Movimiento]    Script Date: 05/08/2012 21:19:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Movimiento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[habilitado] [bit] NOT NULL,
	[logo] [varchar](max) NULL CONSTRAINT [DF_Movimiento_logo]  DEFAULT ('default.jpg'),
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
SET IDENTITY_INSERT [dbo].[Movimiento] ON
INSERT [dbo].[Movimiento] ([id], [nombre], [habilitado], [logo], [idLayout], [descripcion], [latitud], [longitud], [maxMarcasInadecuadasRecursoX], [maxRecursosInadecuadosUsuarioZ], [maxRecursosPopularesN], [maxUltimosRecursosM]) VALUES (1, N'mov1', 0, N'''default.jpg''', 0, N'dsfg', 12, 12, NULL, NULL, NULL, NULL)
INSERT [dbo].[Movimiento] ([id], [nombre], [habilitado], [logo], [idLayout], [descripcion], [latitud], [longitud], [maxMarcasInadecuadasRecursoX], [maxRecursosInadecuadosUsuarioZ], [maxRecursosPopularesN], [maxUltimosRecursosM]) VALUES (2, N'andres', 0, NULL, 0, N'AndresNebel', 33, -56, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Movimiento] OFF
/****** Object:  Table [dbo].[Convocatorias]    Script Date: 05/08/2012 21:19:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Convocatorias](
	[id] [int] IDENTITY(1,1) NOT NULL,
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
SET IDENTITY_INSERT [dbo].[Convocatorias] ON
INSERT [dbo].[Convocatorias] ([id], [idMovimiento], [idAutor], [titulo], [descripcion], [logo], [latitud], [longitud], [inicio], [fin], [minQuorum]) VALUES (1, 1, 4, N'aasd', N'meeting 1', NULL, -33, -56, NULL, NULL, 123)
SET IDENTITY_INSERT [dbo].[Convocatorias] OFF
/****** Object:  Table [dbo].[RssFeeds]    Script Date: 05/08/2012 21:19:38 ******/
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
/****** Object:  ForeignKey [FK_Aprobaciones_Recrusos]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[Aprobaciones]  WITH CHECK ADD  CONSTRAINT [FK_Aprobaciones_Recrusos] FOREIGN KEY([idRecurso])
REFERENCES [dbo].[Recursos] ([id])
GO
ALTER TABLE [dbo].[Aprobaciones] CHECK CONSTRAINT [FK_Aprobaciones_Recrusos]
GO
/****** Object:  ForeignKey [FK_Aprobaciones_Usuarios]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[Aprobaciones]  WITH CHECK ADD  CONSTRAINT [FK_Aprobaciones_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Aprobaciones] CHECK CONSTRAINT [FK_Aprobaciones_Usuarios]
GO
/****** Object:  ForeignKey [FK_Convocatorias_Movimientos]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[Convocatorias]  WITH CHECK ADD  CONSTRAINT [FK_Convocatorias_Movimientos] FOREIGN KEY([idMovimiento])
REFERENCES [dbo].[Movimiento] ([id])
GO
ALTER TABLE [dbo].[Convocatorias] CHECK CONSTRAINT [FK_Convocatorias_Movimientos]
GO
/****** Object:  ForeignKey [FK_Convocatorias_Usuarios]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[Convocatorias]  WITH CHECK ADD  CONSTRAINT [FK_Convocatorias_Usuarios] FOREIGN KEY([idAutor])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Convocatorias] CHECK CONSTRAINT [FK_Convocatorias_Usuarios]
GO
/****** Object:  ForeignKey [FK_Layout_Movimiento]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Layout_Movimiento] FOREIGN KEY([idLayout])
REFERENCES [dbo].[Layouts] ([id])
GO
ALTER TABLE [dbo].[Movimiento] CHECK CONSTRAINT [FK_Layout_Movimiento]
GO
/****** Object:  ForeignKey [FK_RECURSO_USUARIOS]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[Recursos]  WITH CHECK ADD  CONSTRAINT [FK_RECURSO_USUARIOS] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Recursos] CHECK CONSTRAINT [FK_RECURSO_USUARIOS]
GO
/****** Object:  ForeignKey [FK_RssFeeds_Movimiento]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[RssFeeds]  WITH CHECK ADD  CONSTRAINT [FK_RssFeeds_Movimiento] FOREIGN KEY([idMovimiento])
REFERENCES [dbo].[Movimiento] ([id])
GO
ALTER TABLE [dbo].[RssFeeds] CHECK CONSTRAINT [FK_RssFeeds_Movimiento]
GO
/****** Object:  ForeignKey [FK_UsuarioFacebook_Users]    Script Date: 05/08/2012 21:19:38 ******/
ALTER TABLE [dbo].[UsuarioFacebook]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioFacebook_Users] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[UsuarioFacebook] CHECK CONSTRAINT [FK_UsuarioFacebook_Users]
GO

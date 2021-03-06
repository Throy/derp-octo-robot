/****** Object:  ForeignKey [FK_Aprobaciones_Recursos]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[Aprobaciones] DROP CONSTRAINT [FK_Aprobaciones_Recursos]
GO
/****** Object:  ForeignKey [FK_Aprobaciones_Usuarios]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[Aprobaciones] DROP CONSTRAINT [FK_Aprobaciones_Usuarios]
GO
/****** Object:  ForeignKey [FK_Asistencias_Convocatorias]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[Asistencias] DROP CONSTRAINT [FK_Asistencias_Convocatorias]
GO
/****** Object:  ForeignKey [FK_Asistencias_Usuarios]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[Asistencias] DROP CONSTRAINT [FK_Asistencias_Usuarios]
GO
/****** Object:  ForeignKey [FK_CategoriasTematicas_Movimientos]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[CategoriasTematicas] DROP CONSTRAINT [FK_CategoriasTematicas_Movimientos]
GO
/****** Object:  ForeignKey [FK_CatTemasConvocatorias_CategoriasTematicas]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[CatTemasConvocatorias] DROP CONSTRAINT [FK_CatTemasConvocatorias_CategoriasTematicas]
GO
/****** Object:  ForeignKey [FK_CatTemasConvocatorias_Convocatorias]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[CatTemasConvocatorias] DROP CONSTRAINT [FK_CatTemasConvocatorias_Convocatorias]
GO
/****** Object:  ForeignKey [FK_Convocatorias_Movimientos]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[Convocatorias] DROP CONSTRAINT [FK_Convocatorias_Movimientos]
GO
/****** Object:  ForeignKey [FK_Convocatorias_Usuarios]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[Convocatorias] DROP CONSTRAINT [FK_Convocatorias_Usuarios]
GO
/****** Object:  ForeignKey [FK_Intereses_CategoriasTematicas]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[Intereses] DROP CONSTRAINT [FK_Intereses_CategoriasTematicas]
GO
/****** Object:  ForeignKey [FK_Intereses_Usuarios]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[Intereses] DROP CONSTRAINT [FK_Intereses_Usuarios]
GO
/****** Object:  ForeignKey [FK_MarcasInadecuados_Recursos]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[MarcasInadecuados] DROP CONSTRAINT [FK_MarcasInadecuados_Recursos]
GO
/****** Object:  ForeignKey [FK_MarcasInadecuados_Usuarios]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[MarcasInadecuados] DROP CONSTRAINT [FK_MarcasInadecuados_Usuarios]
GO
/****** Object:  ForeignKey [FK_Layout_Movimiento]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[Movimiento] DROP CONSTRAINT [FK_Layout_Movimiento]
GO
/****** Object:  ForeignKey [FK_Notificaciones_Convocatorias]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[Notificaciones] DROP CONSTRAINT [FK_Notificaciones_Convocatorias]
GO
/****** Object:  ForeignKey [FK_Notificaciones_Usuarios]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[Notificaciones] DROP CONSTRAINT [FK_Notificaciones_Usuarios]
GO
/****** Object:  ForeignKey [FK_RECURSO_USUARIOS]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[Recursos] DROP CONSTRAINT [FK_RECURSO_USUARIOS]
GO
/****** Object:  ForeignKey [FK_RssFeeds_Movimiento]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[RssFeeds] DROP CONSTRAINT [FK_RssFeeds_Movimiento]
GO
/****** Object:  ForeignKey [FK_UsuarioFacebook_Users]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[UsuarioFacebook] DROP CONSTRAINT [FK_UsuarioFacebook_Users]
GO
/****** Object:  Table [dbo].[CatTemasConvocatorias]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[CatTemasConvocatorias] DROP CONSTRAINT [FK_CatTemasConvocatorias_CategoriasTematicas]
GO
ALTER TABLE [dbo].[CatTemasConvocatorias] DROP CONSTRAINT [FK_CatTemasConvocatorias_Convocatorias]
GO
DROP TABLE [dbo].[CatTemasConvocatorias]
GO
/****** Object:  Table [dbo].[RssFeeds]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[RssFeeds] DROP CONSTRAINT [FK_RssFeeds_Movimiento]
GO
DROP TABLE [dbo].[RssFeeds]
GO
/****** Object:  Table [dbo].[Asistencias]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[Asistencias] DROP CONSTRAINT [FK_Asistencias_Convocatorias]
GO
ALTER TABLE [dbo].[Asistencias] DROP CONSTRAINT [FK_Asistencias_Usuarios]
GO
DROP TABLE [dbo].[Asistencias]
GO
/****** Object:  Table [dbo].[Notificaciones]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[Notificaciones] DROP CONSTRAINT [FK_Notificaciones_Convocatorias]
GO
ALTER TABLE [dbo].[Notificaciones] DROP CONSTRAINT [FK_Notificaciones_Usuarios]
GO
DROP TABLE [dbo].[Notificaciones]
GO
/****** Object:  Table [dbo].[Intereses]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[Intereses] DROP CONSTRAINT [FK_Intereses_CategoriasTematicas]
GO
ALTER TABLE [dbo].[Intereses] DROP CONSTRAINT [FK_Intereses_Usuarios]
GO
DROP TABLE [dbo].[Intereses]
GO
/****** Object:  Table [dbo].[CategoriasTematicas]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[CategoriasTematicas] DROP CONSTRAINT [FK_CategoriasTematicas_Movimientos]
GO
DROP TABLE [dbo].[CategoriasTematicas]
GO
/****** Object:  Table [dbo].[Aprobaciones]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[Aprobaciones] DROP CONSTRAINT [FK_Aprobaciones_Recursos]
GO
ALTER TABLE [dbo].[Aprobaciones] DROP CONSTRAINT [FK_Aprobaciones_Usuarios]
GO
DROP TABLE [dbo].[Aprobaciones]
GO
/****** Object:  Table [dbo].[MarcasInadecuados]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[MarcasInadecuados] DROP CONSTRAINT [FK_MarcasInadecuados_Recursos]
GO
ALTER TABLE [dbo].[MarcasInadecuados] DROP CONSTRAINT [FK_MarcasInadecuados_Usuarios]
GO
DROP TABLE [dbo].[MarcasInadecuados]
GO
/****** Object:  Table [dbo].[Recursos]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[Recursos] DROP CONSTRAINT [FK_RECURSO_USUARIOS]
GO
DROP TABLE [dbo].[Recursos]
GO
/****** Object:  Table [dbo].[UsuarioFacebook]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[UsuarioFacebook] DROP CONSTRAINT [FK_UsuarioFacebook_Users]
GO
DROP TABLE [dbo].[UsuarioFacebook]
GO
/****** Object:  Table [dbo].[Convocatorias]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[Convocatorias] DROP CONSTRAINT [FK_Convocatorias_Movimientos]
GO
ALTER TABLE [dbo].[Convocatorias] DROP CONSTRAINT [FK_Convocatorias_Usuarios]
GO
DROP TABLE [dbo].[Convocatorias]
GO
/****** Object:  Table [dbo].[Movimiento]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[Movimiento] DROP CONSTRAINT [FK_Layout_Movimiento]
GO
ALTER TABLE [dbo].[Movimiento] DROP CONSTRAINT [DF_Movimiento_url]
GO
ALTER TABLE [dbo].[Movimiento] DROP CONSTRAINT [DF_Movimiento_logo]
GO
ALTER TABLE [dbo].[Movimiento] DROP CONSTRAINT [DF_Movimiento_idLayout]
GO
DROP TABLE [dbo].[Movimiento]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [DF_Usuarios_banned]
GO
ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [DF_Usuarios_privilegio]
GO
DROP TABLE [dbo].[Usuarios]
GO
/****** Object:  Table [dbo].[Layouts]    Script Date: 06/19/2012 19:01:55 ******/
DROP TABLE [dbo].[Layouts]
GO
/****** Object:  Table [dbo].[Layouts]    Script Date: 06/19/2012 19:01:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Layouts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[layoutFile] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Layouts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Layouts] ON
INSERT [dbo].[Layouts] ([id], [layoutFile], [name]) VALUES (0, N'~/Views/Shared/_Default.cshtml', N'Estilo 1')
INSERT [dbo].[Layouts] ([id], [layoutFile], [name]) VALUES (1, N'~/Views/Shared/_Layout1.cshtml', N'Estilo 2')
SET IDENTITY_INSERT [dbo].[Layouts] OFF
/****** Object:  Table [dbo].[Usuarios]    Script Date: 06/19/2012 19:01:55 ******/
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
	[apodo] [varchar](50) NOT NULL,
	[mail] [varchar](50) NULL,
	[contraseña] [varbinary](50) NOT NULL,
	[latitud] [float] NOT NULL,
	[longitud] [float] NOT NULL,
	[fechaRegistro] [datetime] NULL,
	[cantRecursosMarcadosInadecuados] [int] NULL,
	[cantRecursosDeshabilitados] [int] NULL,
	[banned] [bit] NOT NULL CONSTRAINT [DF_Usuarios_banned]  DEFAULT ((0)),
	[privilegio] [smallint] NOT NULL CONSTRAINT [DF_Usuarios_privilegio]  DEFAULT ((0)),
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Apodo_IdMovimiento] UNIQUE NONCLUSTERED 
(
	[idMovimiento] ASC,
	[apodo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT [dbo].[Usuarios] ([id], [idMovimiento], [nombre], [apodo], [mail], [contraseña], [latitud], [longitud], [fechaRegistro], [cantRecursosMarcadosInadecuados], [cantRecursosDeshabilitados], [banned], [privilegio]) VALUES (1, 0, N'admin', N'admin', N'admin@indignadoframwork.com', 0x7110EDA4D09E062AA5E4A390B0A572AC0D2C0220, -33, -56, CAST(0x0000A04400B58C90 AS DateTime), 0, 0, 0, 4)
INSERT [dbo].[Usuarios] ([id], [idMovimiento], [nombre], [apodo], [mail], [contraseña], [latitud], [longitud], [fechaRegistro], [cantRecursosMarcadosInadecuados], [cantRecursosDeshabilitados], [banned], [privilegio]) VALUES (2, 1, N'movadmin', N'movadmin', N'mov1@indignadoframwork.com', 0x7110EDA4D09E062AA5E4A390B0A572AC0D2C0220, -33, -56, CAST(0x0000A04500C64DA0 AS DateTime), 0, 0, 0, 2)
INSERT [dbo].[Usuarios] ([id], [idMovimiento], [nombre], [apodo], [mail], [contraseña], [latitud], [longitud], [fechaRegistro], [cantRecursosMarcadosInadecuados], [cantRecursosDeshabilitados], [banned], [privilegio]) VALUES (3, 2, N'movadmin', N'movadmin', N'andres@indignadoframwork.com', 0x7110EDA4D09E062AA5E4A390B0A572AC0D2C0220, -33, -56, CAST(0x0000A04500C64DA0 AS DateTime), 0, 0, 0, 2)
INSERT [dbo].[Usuarios] ([id], [idMovimiento], [nombre], [apodo], [mail], [contraseña], [latitud], [longitud], [fechaRegistro], [cantRecursosMarcadosInadecuados], [cantRecursosDeshabilitados], [banned], [privilegio]) VALUES (4, 3, N'movadmin', N'movadmin', N'tsi1@indignadoframwork.com', 0x7110EDA4D09E062AA5E4A390B0A572AC0D2C0220, -33, -56, CAST(0x0000A04500C64DA0 AS DateTime), 0, 0, 0, 2)
INSERT [dbo].[Usuarios] ([id], [idMovimiento], [nombre], [apodo], [mail], [contraseña], [latitud], [longitud], [fechaRegistro], [cantRecursosMarcadosInadecuados], [cantRecursosDeshabilitados], [banned], [privilegio]) VALUES (8, 1, N'Agustin', N'Agustin', N'agustin@lavabit.com', 0x7110EDA4D09E062AA5E4A390B0A572AC0D2C0220, -34.8409, -56.0489, CAST(0x0000A05500C5C100 AS DateTime), 0, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [idMovimiento], [nombre], [apodo], [mail], [contraseña], [latitud], [longitud], [fechaRegistro], [cantRecursosMarcadosInadecuados], [cantRecursosDeshabilitados], [banned], [privilegio]) VALUES (9, 1, N'Betto', N'Betto', N'betto@bettonet.com', 0x7110EDA4D09E062AA5E4A390B0A572AC0D2C0220, -33, -56, CAST(0x0000A05600C5C100 AS DateTime), 0, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [idMovimiento], [nombre], [apodo], [mail], [contraseña], [latitud], [longitud], [fechaRegistro], [cantRecursosMarcadosInadecuados], [cantRecursosDeshabilitados], [banned], [privilegio]) VALUES (10, 1, N'Coco', N'Coco', N'coco@lavabit.com', 0x7110EDA4D09E062AA5E4A390B0A572AC0D2C0220, -33, -56, CAST(0x0000A05700C5C100 AS DateTime), 0, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [idMovimiento], [nombre], [apodo], [mail], [contraseña], [latitud], [longitud], [fechaRegistro], [cantRecursosMarcadosInadecuados], [cantRecursosDeshabilitados], [banned], [privilegio]) VALUES (11, 1, N'Desinteresado', N'Desinteresado', N'desinteresado@nada.com', 0x7110EDA4D09E062AA5E4A390B0A572AC0D2C0220, -34.85, -56.15, CAST(0x0000A05800C5C100 AS DateTime), 0, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [idMovimiento], [nombre], [apodo], [mail], [contraseña], [latitud], [longitud], [fechaRegistro], [cantRecursosMarcadosInadecuados], [cantRecursosDeshabilitados], [banned], [privilegio]) VALUES (12, 1, N'Troll', N'Troll', N'troll@troller.com', 0x7110EDA4D09E062AA5E4A390B0A572AC0D2C0220, -33, -56, CAST(0x0000A05900C5C100 AS DateTime), 0, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [idMovimiento], [nombre], [apodo], [mail], [contraseña], [latitud], [longitud], [fechaRegistro], [cantRecursosMarcadosInadecuados], [cantRecursosDeshabilitados], [banned], [privilegio]) VALUES (20, 2, N'Agustin', N'Agustin', N'agus@ag.com', 0x7110EDA4D09E062AA5E4A390B0A572AC0D2C0220, -33, -56, CAST(0x0000A04F00C5C100 AS DateTime), 0, 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [idMovimiento], [nombre], [apodo], [mail], [contraseña], [latitud], [longitud], [fechaRegistro], [cantRecursosMarcadosInadecuados], [cantRecursosDeshabilitados], [banned], [privilegio]) VALUES (30, 3, N'Agustin', N'Agustin', N'agustin@lavabit.com', 0x7110EDA4D09E062AA5E4A390B0A572AC0D2C0220, -33, -56, CAST(0x0000A05000C5C100 AS DateTime), 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
/****** Object:  Table [dbo].[Movimiento]    Script Date: 06/19/2012 19:01:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Movimiento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[url] [nchar](100) NOT NULL CONSTRAINT [DF_Movimiento_url]  DEFAULT ((1)),
	[habilitado] [bit] NOT NULL,
	[logo] [varchar](max) NULL CONSTRAINT [DF_Movimiento_logo]  DEFAULT ('default.jpg'),
	[idLayout] [int] NOT NULL CONSTRAINT [DF_Movimiento_idLayout]  DEFAULT ((0)),
	[descripcion] [varchar](max) NULL,
	[latitud] [float] NOT NULL,
	[longitud] [float] NOT NULL,
	[maxMarcasInadecuadasRecursoX] [int] NOT NULL,
	[maxRecursosInadecuadosUsuarioZ] [int] NOT NULL,
	[maxRecursosPopularesN] [int] NOT NULL,
	[maxUltimosRecursosM] [int] NOT NULL,
 CONSTRAINT [PK_Movimiento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Movimiento] ON
INSERT [dbo].[Movimiento] ([id], [nombre], [url], [habilitado], [logo], [idLayout], [descripcion], [latitud], [longitud], [maxMarcasInadecuadasRecursoX], [maxRecursosInadecuadosUsuarioZ], [maxRecursosPopularesN], [maxUltimosRecursosM]) VALUES (1, N'Primer Movimiento!', N'mov1                                                                                                ', 1, N'default.jpg', 0, N'El primer movimiento de Indignado Framework', -34.83, -56.13, 2, 2, 5, 10)
INSERT [dbo].[Movimiento] ([id], [nombre], [url], [habilitado], [logo], [idLayout], [descripcion], [latitud], [longitud], [maxMarcasInadecuadasRecursoX], [maxRecursosInadecuadosUsuarioZ], [maxRecursosPopularesN], [maxUltimosRecursosM]) VALUES (2, N'andres', N'andres                                                                                              ', 1, NULL, 0, N'AndresNebel', -34, -56, 2, 2, 10, 20)
INSERT [dbo].[Movimiento] ([id], [nombre], [url], [habilitado], [logo], [idLayout], [descripcion], [latitud], [longitud], [maxMarcasInadecuadasRecursoX], [maxRecursosInadecuadosUsuarioZ], [maxRecursosPopularesN], [maxUltimosRecursosM]) VALUES (3, N'tsi1', N'tsi1                                                                                                ', 1, NULL, 1, N'tsi', -35, -57, 2, 2, 10, 20)
SET IDENTITY_INSERT [dbo].[Movimiento] OFF
/****** Object:  Table [dbo].[Convocatorias]    Script Date: 06/19/2012 19:01:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
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
	[fechaInicio] [datetime] NOT NULL,
	[fechaFin] [datetime] NOT NULL,
	[minQuorum] [int] NULL,
	[cantAsistencias] [int] NULL,
	[miAsistencia] [int] NULL,
	[estaConfirmada] [bit] NULL,
	[estaActiva] [bit] NULL,
 CONSTRAINT [PK_Convocatorias] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Convocatorias] ON
INSERT [dbo].[Convocatorias] ([id], [idMovimiento], [idAutor], [titulo], [descripcion], [logo], [latitud], [longitud], [fechaInicio], [fechaFin], [minQuorum], [cantAsistencias], [miAsistencia], [estaConfirmada], [estaActiva]) VALUES (1, 1, 4, N'La Paz', N'Liberen a los presos', NULL, -34.778, -56.268, CAST(0x0000A07700B54640 AS DateTime), CAST(0x0000A077015A11C0 AS DateTime), 123, 0, 0, 0, 0)
INSERT [dbo].[Convocatorias] ([id], [idMovimiento], [idAutor], [titulo], [descripcion], [logo], [latitud], [longitud], [fechaInicio], [fechaFin], [minQuorum], [cantAsistencias], [miAsistencia], [estaConfirmada], [estaActiva]) VALUES (2, 1, 8, N'Sueños de Libertad', N'Por la libertad de exprecion', NULL, -34.871, -56.167, CAST(0x0000A07800C5C100 AS DateTime), CAST(0x0000A078016A8C80 AS DateTime), 2, 0, 0, 0, 0)
INSERT [dbo].[Convocatorias] ([id], [idMovimiento], [idAutor], [titulo], [descripcion], [logo], [latitud], [longitud], [fechaInicio], [fechaFin], [minQuorum], [cantAsistencias], [miAsistencia], [estaConfirmada], [estaActiva]) VALUES (3, 1, 8, N'Carrasco', N'Bajen los impuestos', NULL, -34.886, -56.049, CAST(0x0000A07900D70EB0 AS DateTime), CAST(0x0000A07900DF4C10 AS DateTime), 0, 0, 0, 0, 0)
INSERT [dbo].[Convocatorias] ([id], [idMovimiento], [idAutor], [titulo], [descripcion], [logo], [latitud], [longitud], [fechaInicio], [fechaFin], [minQuorum], [cantAsistencias], [miAsistencia], [estaConfirmada], [estaActiva]) VALUES (4, 1, 8, N'Prado', N'No a las domas', NULL, -34.864, -56.204, CAST(0x0000A07A00E7CFC0 AS DateTime), CAST(0x0000A07A00F1B300 AS DateTime), 4, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Convocatorias] OFF
/****** Object:  Table [dbo].[UsuarioFacebook]    Script Date: 06/19/2012 19:01:55 ******/
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
/****** Object:  Table [dbo].[Recursos]    Script Date: 06/19/2012 19:01:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recursos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[apodoUsuario] [varchar](50) NULL,
	[titulo] [varchar](100) NOT NULL,
	[descripcion] [text] NULL,
	[fecha] [datetime] NULL,
	[tipo] [int] NULL,
	[urlLink] [varchar](max) NULL,
	[urlImage] [varchar](max) NULL,
	[urlVideo] [varchar](max) NULL,
	[urlThumb] [varchar](max) NULL,
	[cantAprobaciones] [int] NULL,
	[meGusta] [int] NULL,
	[cantMarcasInadecuado] [int] NULL,
	[yoMarqueInadecuado] [int] NULL,
	[deshabilitado] [int] NULL,
 CONSTRAINT [PK_Recursos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Recursos] ON
INSERT [dbo].[Recursos] ([id], [idUsuario], [apodoUsuario], [titulo], [descripcion], [fecha], [tipo], [urlLink], [urlImage], [urlVideo], [urlThumb], [cantAprobaciones], [meGusta], [cantMarcasInadecuado], [yoMarqueInadecuado], [deshabilitado]) VALUES (1, 8, NULL, N'Autito', N'El Autito 666: Camino al Infierno es el juego de carreras revolucionarazo by NaBUrean Prodooktionz. Elijas lo que elijas, vas a terminar en el infierno.', CAST(0x0000A06300B58C90 AS DateTime), 0, N'http://www.autito.tk', N'', N'', N'', 0, 0, 0, 0, 0)
INSERT [dbo].[Recursos] ([id], [idUsuario], [apodoUsuario], [titulo], [descripcion], [fecha], [tipo], [urlLink], [urlImage], [urlVideo], [urlThumb], [cantAprobaciones], [meGusta], [cantMarcasInadecuado], [yoMarqueInadecuado], [deshabilitado]) VALUES (2, 8, NULL, N'ReVerS', N'desconcertante...', CAST(0x0000A06400C64DA0 AS DateTime), 0, N'http://www.reverserers.tk', N'http://www.freewebs.com/naburean/rvs/rvs_fondo_estrella.jpg', N'', N'', 0, 0, 0, 0, 0)
INSERT [dbo].[Recursos] ([id], [idUsuario], [apodoUsuario], [titulo], [descripcion], [fecha], [tipo], [urlLink], [urlImage], [urlVideo], [urlThumb], [cantAprobaciones], [meGusta], [cantMarcasInadecuado], [yoMarqueInadecuado], [deshabilitado]) VALUES (3, 8, NULL, N'PngVol', N'Es lo que hay valor!', CAST(0x0000A06500D70EB0 AS DateTime), 0, N'', N'', N'', N'', 0, 0, 0, 0, 0)
INSERT [dbo].[Recursos] ([id], [idUsuario], [apodoUsuario], [titulo], [descripcion], [fecha], [tipo], [urlLink], [urlImage], [urlVideo], [urlThumb], [cantAprobaciones], [meGusta], [cantMarcasInadecuado], [yoMarqueInadecuado], [deshabilitado]) VALUES (4, 8, NULL, N'MIB 3', N'Pitbull back in time, La Pelicula que todos estamos esperando', CAST(0x0000A06600E7CFC0 AS DateTime), NULL, N'http://www.youtube.com/embed/LIDwgpBh0Aw', NULL, N'http://www.youtube.com/embed/LIDwgpBh0Aw', NULL, 0, 0, 0, 0, 0)
INSERT [dbo].[Recursos] ([id], [idUsuario], [apodoUsuario], [titulo], [descripcion], [fecha], [tipo], [urlLink], [urlImage], [urlVideo], [urlThumb], [cantAprobaciones], [meGusta], [cantMarcasInadecuado], [yoMarqueInadecuado], [deshabilitado]) VALUES (5, 12, NULL, N'Basura ', N'Soy vándalo y publico cualquier cosa!', CAST(0x0000A06700F890D0 AS DateTime), 0, N'', N'', N'', N'', 0, 0, 0, 0, 0)
INSERT [dbo].[Recursos] ([id], [idUsuario], [apodoUsuario], [titulo], [descripcion], [fecha], [tipo], [urlLink], [urlImage], [urlVideo], [urlThumb], [cantAprobaciones], [meGusta], [cantMarcasInadecuado], [yoMarqueInadecuado], [deshabilitado]) VALUES (6, 12, NULL, N'Mas Basura', N'Soy irritante, y me gusta', CAST(0x0000A068010951E0 AS DateTime), 0, N'', N'', N'', N'', 0, 0, 0, 0, 0)
INSERT [dbo].[Recursos] ([id], [idUsuario], [apodoUsuario], [titulo], [descripcion], [fecha], [tipo], [urlLink], [urlImage], [urlVideo], [urlThumb], [cantAprobaciones], [meGusta], [cantMarcasInadecuado], [yoMarqueInadecuado], [deshabilitado]) VALUES (7, 12, NULL, N'Spam Spam!', N'Estoy Aburrido!!!', CAST(0x0000A068010951E0 AS DateTime), 0, N'', N'', N'', N'', 0, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Recursos] OFF
/****** Object:  Table [dbo].[MarcasInadecuados]    Script Date: 06/19/2012 19:01:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarcasInadecuados](
	[idRecurso] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_MarcasInadecuados] PRIMARY KEY CLUSTERED 
(
	[idRecurso] ASC,
	[idUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aprobaciones]    Script Date: 06/19/2012 19:01:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aprobaciones](
	[idRecurso] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Aprobaciones] PRIMARY KEY CLUSTERED 
(
	[idRecurso] ASC,
	[idUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Aprobaciones] ([idRecurso], [idUsuario]) VALUES (3, 8)
INSERT [dbo].[Aprobaciones] ([idRecurso], [idUsuario]) VALUES (3, 9)
INSERT [dbo].[Aprobaciones] ([idRecurso], [idUsuario]) VALUES (4, 8)
/****** Object:  Table [dbo].[CategoriasTematicas]    Script Date: 06/19/2012 19:01:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CategoriasTematicas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idMovimiento] [int] NOT NULL,
	[titulo] [varchar](50) NOT NULL,
	[descripcion] [varchar](100) NULL,
	[miInteres] [int] NULL,
 CONSTRAINT [PK_CategoriasTematicas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CategoriasTematicas] ON
INSERT [dbo].[CategoriasTematicas] ([id], [idMovimiento], [titulo], [descripcion], [miInteres]) VALUES (1, 1, N'Ecologia', N'verde', NULL)
INSERT [dbo].[CategoriasTematicas] ([id], [idMovimiento], [titulo], [descripcion], [miInteres]) VALUES (2, 1, N'Libertad', N'azul', NULL)
INSERT [dbo].[CategoriasTematicas] ([id], [idMovimiento], [titulo], [descripcion], [miInteres]) VALUES (3, 1, N'Paz', N'blanco', NULL)
INSERT [dbo].[CategoriasTematicas] ([id], [idMovimiento], [titulo], [descripcion], [miInteres]) VALUES (4, 1, N'Violencia', N'rojo', NULL)
INSERT [dbo].[CategoriasTematicas] ([id], [idMovimiento], [titulo], [descripcion], [miInteres]) VALUES (5, 1, N'Justicia', N'gris', NULL)
SET IDENTITY_INSERT [dbo].[CategoriasTematicas] OFF
/****** Object:  Table [dbo].[Intereses]    Script Date: 06/19/2012 19:01:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Intereses](
	[idCategoriaTematica] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Intereses] PRIMARY KEY CLUSTERED 
(
	[idCategoriaTematica] ASC,
	[idUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Intereses] ([idCategoriaTematica], [idUsuario]) VALUES (1, 8)
INSERT [dbo].[Intereses] ([idCategoriaTematica], [idUsuario]) VALUES (1, 12)
INSERT [dbo].[Intereses] ([idCategoriaTematica], [idUsuario]) VALUES (2, 9)
INSERT [dbo].[Intereses] ([idCategoriaTematica], [idUsuario]) VALUES (2, 12)
INSERT [dbo].[Intereses] ([idCategoriaTematica], [idUsuario]) VALUES (3, 10)
INSERT [dbo].[Intereses] ([idCategoriaTematica], [idUsuario]) VALUES (3, 12)
/****** Object:  Table [dbo].[Notificaciones]    Script Date: 06/19/2012 19:01:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notificaciones](
	[idConvocatoria] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Notificaciones] PRIMARY KEY CLUSTERED 
(
	[idConvocatoria] ASC,
	[idUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Notificaciones] ([idConvocatoria], [idUsuario]) VALUES (2, 9)
INSERT [dbo].[Notificaciones] ([idConvocatoria], [idUsuario]) VALUES (2, 11)
INSERT [dbo].[Notificaciones] ([idConvocatoria], [idUsuario]) VALUES (2, 12)
INSERT [dbo].[Notificaciones] ([idConvocatoria], [idUsuario]) VALUES (3, 8)
INSERT [dbo].[Notificaciones] ([idConvocatoria], [idUsuario]) VALUES (3, 9)
INSERT [dbo].[Notificaciones] ([idConvocatoria], [idUsuario]) VALUES (3, 11)
INSERT [dbo].[Notificaciones] ([idConvocatoria], [idUsuario]) VALUES (3, 12)
INSERT [dbo].[Notificaciones] ([idConvocatoria], [idUsuario]) VALUES (4, 8)
INSERT [dbo].[Notificaciones] ([idConvocatoria], [idUsuario]) VALUES (4, 11)
INSERT [dbo].[Notificaciones] ([idConvocatoria], [idUsuario]) VALUES (4, 12)
/****** Object:  Table [dbo].[Asistencias]    Script Date: 06/19/2012 19:01:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asistencias](
	[idConvocatoria] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[hayAsistencia] [int] NOT NULL,
 CONSTRAINT [PK_Asistencias] PRIMARY KEY CLUSTERED 
(
	[idConvocatoria] ASC,
	[idUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RssFeeds]    Script Date: 06/19/2012 19:01:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RssFeeds](
	[url] [nchar](100) NOT NULL,
	[idMovimiento] [int] NOT NULL,
	[tag] [varchar](50) NOT NULL,
	[titulo] [varchar](50) NOT NULL,
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
INSERT [dbo].[RssFeeds] ([url], [idMovimiento], [tag], [titulo]) VALUES (N'http://180.com.uy/feed.php                                                                          ', 1, N'Otros', N'Portal 180')
INSERT [dbo].[RssFeeds] ([url], [idMovimiento], [tag], [titulo]) VALUES (N'http://180.com.uy/feed.php                                                                          ', 2, N'Otros', N'Portal 180')
INSERT [dbo].[RssFeeds] ([url], [idMovimiento], [tag], [titulo]) VALUES (N'http://180.com.uy/feed.php                                                                          ', 3, N'Otros', N'Portal 180')
INSERT [dbo].[RssFeeds] ([url], [idMovimiento], [tag], [titulo]) VALUES (N'http://cnnespanol.cnn.com/feed/                                                                     ', 1, N'Otros', N'CNN en español')
INSERT [dbo].[RssFeeds] ([url], [idMovimiento], [tag], [titulo]) VALUES (N'http://cnnespanol.cnn.com/feed/                                                                     ', 2, N'Otros', N'CNN en español')
INSERT [dbo].[RssFeeds] ([url], [idMovimiento], [tag], [titulo]) VALUES (N'http://www.elobservador.com.uy/rss/nacional/                                                        ', 1, N'Otros', N'El Observador')
INSERT [dbo].[RssFeeds] ([url], [idMovimiento], [tag], [titulo]) VALUES (N'http://www.montevideo.com.uy/anxml.aspx?59                                                          ', 1, N'Otros', N'Montevideo Portal')
INSERT [dbo].[RssFeeds] ([url], [idMovimiento], [tag], [titulo]) VALUES (N'http://www.montevideo.com.uy/anxml.aspx?59                                                          ', 2, N'Otros', N'Montevideo Portal')
/****** Object:  Table [dbo].[CatTemasConvocatorias]    Script Date: 06/19/2012 19:01:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatTemasConvocatorias](
	[idCategoriaTematica] [int] NOT NULL,
	[idConvocatoria] [int] NOT NULL,
 CONSTRAINT [PK_CattemasConvocatorias] PRIMARY KEY CLUSTERED 
(
	[idCategoriaTematica] ASC,
	[idConvocatoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CatTemasConvocatorias] ([idCategoriaTematica], [idConvocatoria]) VALUES (1, 4)
INSERT [dbo].[CatTemasConvocatorias] ([idCategoriaTematica], [idConvocatoria]) VALUES (2, 2)
INSERT [dbo].[CatTemasConvocatorias] ([idCategoriaTematica], [idConvocatoria]) VALUES (2, 3)
/****** Object:  ForeignKey [FK_Aprobaciones_Recursos]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[Aprobaciones]  WITH CHECK ADD  CONSTRAINT [FK_Aprobaciones_Recursos] FOREIGN KEY([idRecurso])
REFERENCES [dbo].[Recursos] ([id])
GO
ALTER TABLE [dbo].[Aprobaciones] CHECK CONSTRAINT [FK_Aprobaciones_Recursos]
GO
/****** Object:  ForeignKey [FK_Aprobaciones_Usuarios]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[Aprobaciones]  WITH CHECK ADD  CONSTRAINT [FK_Aprobaciones_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Aprobaciones] CHECK CONSTRAINT [FK_Aprobaciones_Usuarios]
GO
/****** Object:  ForeignKey [FK_Asistencias_Convocatorias]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[Asistencias]  WITH CHECK ADD  CONSTRAINT [FK_Asistencias_Convocatorias] FOREIGN KEY([idConvocatoria])
REFERENCES [dbo].[Convocatorias] ([id])
GO
ALTER TABLE [dbo].[Asistencias] CHECK CONSTRAINT [FK_Asistencias_Convocatorias]
GO
/****** Object:  ForeignKey [FK_Asistencias_Usuarios]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[Asistencias]  WITH CHECK ADD  CONSTRAINT [FK_Asistencias_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Asistencias] CHECK CONSTRAINT [FK_Asistencias_Usuarios]
GO
/****** Object:  ForeignKey [FK_CategoriasTematicas_Movimientos]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[CategoriasTematicas]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasTematicas_Movimientos] FOREIGN KEY([idMovimiento])
REFERENCES [dbo].[Movimiento] ([id])
GO
ALTER TABLE [dbo].[CategoriasTematicas] CHECK CONSTRAINT [FK_CategoriasTematicas_Movimientos]
GO
/****** Object:  ForeignKey [FK_CatTemasConvocatorias_CategoriasTematicas]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[CatTemasConvocatorias]  WITH CHECK ADD  CONSTRAINT [FK_CatTemasConvocatorias_CategoriasTematicas] FOREIGN KEY([idCategoriaTematica])
REFERENCES [dbo].[CategoriasTematicas] ([id])
GO
ALTER TABLE [dbo].[CatTemasConvocatorias] CHECK CONSTRAINT [FK_CatTemasConvocatorias_CategoriasTematicas]
GO
/****** Object:  ForeignKey [FK_CatTemasConvocatorias_Convocatorias]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[CatTemasConvocatorias]  WITH CHECK ADD  CONSTRAINT [FK_CatTemasConvocatorias_Convocatorias] FOREIGN KEY([idConvocatoria])
REFERENCES [dbo].[Convocatorias] ([id])
GO
ALTER TABLE [dbo].[CatTemasConvocatorias] CHECK CONSTRAINT [FK_CatTemasConvocatorias_Convocatorias]
GO
/****** Object:  ForeignKey [FK_Convocatorias_Movimientos]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[Convocatorias]  WITH CHECK ADD  CONSTRAINT [FK_Convocatorias_Movimientos] FOREIGN KEY([idMovimiento])
REFERENCES [dbo].[Movimiento] ([id])
GO
ALTER TABLE [dbo].[Convocatorias] CHECK CONSTRAINT [FK_Convocatorias_Movimientos]
GO
/****** Object:  ForeignKey [FK_Convocatorias_Usuarios]    Script Date: 06/19/2012 19:01:54 ******/
ALTER TABLE [dbo].[Convocatorias]  WITH CHECK ADD  CONSTRAINT [FK_Convocatorias_Usuarios] FOREIGN KEY([idAutor])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Convocatorias] CHECK CONSTRAINT [FK_Convocatorias_Usuarios]
GO
/****** Object:  ForeignKey [FK_Intereses_CategoriasTematicas]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[Intereses]  WITH CHECK ADD  CONSTRAINT [FK_Intereses_CategoriasTematicas] FOREIGN KEY([idCategoriaTematica])
REFERENCES [dbo].[CategoriasTematicas] ([id])
GO
ALTER TABLE [dbo].[Intereses] CHECK CONSTRAINT [FK_Intereses_CategoriasTematicas]
GO
/****** Object:  ForeignKey [FK_Intereses_Usuarios]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[Intereses]  WITH CHECK ADD  CONSTRAINT [FK_Intereses_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Intereses] CHECK CONSTRAINT [FK_Intereses_Usuarios]
GO
/****** Object:  ForeignKey [FK_MarcasInadecuados_Recursos]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[MarcasInadecuados]  WITH CHECK ADD  CONSTRAINT [FK_MarcasInadecuados_Recursos] FOREIGN KEY([idRecurso])
REFERENCES [dbo].[Recursos] ([id])
GO
ALTER TABLE [dbo].[MarcasInadecuados] CHECK CONSTRAINT [FK_MarcasInadecuados_Recursos]
GO
/****** Object:  ForeignKey [FK_MarcasInadecuados_Usuarios]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[MarcasInadecuados]  WITH CHECK ADD  CONSTRAINT [FK_MarcasInadecuados_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[MarcasInadecuados] CHECK CONSTRAINT [FK_MarcasInadecuados_Usuarios]
GO
/****** Object:  ForeignKey [FK_Layout_Movimiento]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Layout_Movimiento] FOREIGN KEY([idLayout])
REFERENCES [dbo].[Layouts] ([id])
GO
ALTER TABLE [dbo].[Movimiento] CHECK CONSTRAINT [FK_Layout_Movimiento]
GO
/****** Object:  ForeignKey [FK_Notificaciones_Convocatorias]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[Notificaciones]  WITH CHECK ADD  CONSTRAINT [FK_Notificaciones_Convocatorias] FOREIGN KEY([idConvocatoria])
REFERENCES [dbo].[Convocatorias] ([id])
GO
ALTER TABLE [dbo].[Notificaciones] CHECK CONSTRAINT [FK_Notificaciones_Convocatorias]
GO
/****** Object:  ForeignKey [FK_Notificaciones_Usuarios]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[Notificaciones]  WITH CHECK ADD  CONSTRAINT [FK_Notificaciones_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Notificaciones] CHECK CONSTRAINT [FK_Notificaciones_Usuarios]
GO
/****** Object:  ForeignKey [FK_RECURSO_USUARIOS]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[Recursos]  WITH CHECK ADD  CONSTRAINT [FK_RECURSO_USUARIOS] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Recursos] CHECK CONSTRAINT [FK_RECURSO_USUARIOS]
GO
/****** Object:  ForeignKey [FK_RssFeeds_Movimiento]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[RssFeeds]  WITH CHECK ADD  CONSTRAINT [FK_RssFeeds_Movimiento] FOREIGN KEY([idMovimiento])
REFERENCES [dbo].[Movimiento] ([id])
GO
ALTER TABLE [dbo].[RssFeeds] CHECK CONSTRAINT [FK_RssFeeds_Movimiento]
GO
/****** Object:  ForeignKey [FK_UsuarioFacebook_Users]    Script Date: 06/19/2012 19:01:55 ******/
ALTER TABLE [dbo].[UsuarioFacebook]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioFacebook_Users] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[UsuarioFacebook] CHECK CONSTRAINT [FK_UsuarioFacebook_Users]
GO

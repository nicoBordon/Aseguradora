USE [AseguradoraDB]
GO
/****** Object:  Table [dbo].[AtributoAdicional]    Script Date: 14/03/2022 15:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AtributoAdicional](
	[AtributoAdicionalID] [int] IDENTITY(1,1) NOT NULL,
	[TipoAtributoAdicionalID] [int] NOT NULL,
	[EsAfirmativo] [bit] NOT NULL,
	[PersonaID] [int] NOT NULL,
	[DetalleAtributo] [varchar](50) NULL,
 CONSTRAINT [PK_AtributoAdicional] PRIMARY KEY CLUSTERED 
(
	[AtributoAdicionalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 14/03/2022 15:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genero](
	[GeneroID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Genero] PRIMARY KEY CLUSTERED 
(
	[GeneroID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persona]    Script Date: 14/03/2022 15:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[PersonaID] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [nvarchar](100) NOT NULL,
	[Identificador] [nvarchar](50) NOT NULL,
	[Nacimiento] [date] NOT NULL,
	[GeneroID] [int] NOT NULL,
	[Estado] [bit] NOT NULL CONSTRAINT [DF_Persona_Estado]  DEFAULT ((1)),
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[PersonaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoAtributoAdicional]    Script Date: 14/03/2022 15:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoAtributoAdicional](
	[TipoAtributoAdicionalID] [int] IDENTITY(1,1) NOT NULL,
	[NombreTipoAtributo] [varchar](50) NOT NULL,
	[RequiereDetalle] [bit] NOT NULL CONSTRAINT [DF_TipoAtributoAdicional_requiereDetalle]  DEFAULT ((0)),
	[Estado] [bit] NOT NULL CONSTRAINT [DF_TipoAtributoAdicional_estado]  DEFAULT ((1)),
 CONSTRAINT [PK_TipoAtributoAdicional] PRIMARY KEY CLUSTERED 
(
	[TipoAtributoAdicionalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AtributoAdicional] ON 

INSERT [dbo].[AtributoAdicional] ([AtributoAdicionalID], [TipoAtributoAdicionalID], [EsAfirmativo], [PersonaID], [DetalleAtributo]) VALUES (1, 1, 0, 1, NULL)
INSERT [dbo].[AtributoAdicional] ([AtributoAdicionalID], [TipoAtributoAdicionalID], [EsAfirmativo], [PersonaID], [DetalleAtributo]) VALUES (2, 2, 1, 1, NULL)
INSERT [dbo].[AtributoAdicional] ([AtributoAdicionalID], [TipoAtributoAdicionalID], [EsAfirmativo], [PersonaID], [DetalleAtributo]) VALUES (3, 3, 0, 1, NULL)
INSERT [dbo].[AtributoAdicional] ([AtributoAdicionalID], [TipoAtributoAdicionalID], [EsAfirmativo], [PersonaID], [DetalleAtributo]) VALUES (4, 4, 1, 1, N'Hipertension')
INSERT [dbo].[AtributoAdicional] ([AtributoAdicionalID], [TipoAtributoAdicionalID], [EsAfirmativo], [PersonaID], [DetalleAtributo]) VALUES (5, 1, 1, 2, NULL)
INSERT [dbo].[AtributoAdicional] ([AtributoAdicionalID], [TipoAtributoAdicionalID], [EsAfirmativo], [PersonaID], [DetalleAtributo]) VALUES (6, 2, 1, 2, NULL)
INSERT [dbo].[AtributoAdicional] ([AtributoAdicionalID], [TipoAtributoAdicionalID], [EsAfirmativo], [PersonaID], [DetalleAtributo]) VALUES (7, 3, 0, 2, NULL)
INSERT [dbo].[AtributoAdicional] ([AtributoAdicionalID], [TipoAtributoAdicionalID], [EsAfirmativo], [PersonaID], [DetalleAtributo]) VALUES (8, 4, 0, 2, NULL)
SET IDENTITY_INSERT [dbo].[AtributoAdicional] OFF
SET IDENTITY_INSERT [dbo].[Genero] ON 

INSERT [dbo].[Genero] ([GeneroID], [Descripcion]) VALUES (1, N'FEMENINO')
INSERT [dbo].[Genero] ([GeneroID], [Descripcion]) VALUES (2, N'MASCULINO')
INSERT [dbo].[Genero] ([GeneroID], [Descripcion]) VALUES (3, N'NO BINARIO')
INSERT [dbo].[Genero] ([GeneroID], [Descripcion]) VALUES (4, N'NO DECLARA')
SET IDENTITY_INSERT [dbo].[Genero] OFF
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([PersonaID], [NombreCompleto], [Identificador], [Nacimiento], [GeneroID], [Estado]) VALUES (1, N'Juan Perez', N'40321123', CAST(N'1998-06-06' AS Date), 2, 1)
INSERT [dbo].[Persona] ([PersonaID], [NombreCompleto], [Identificador], [Nacimiento], [GeneroID], [Estado]) VALUES (2, N'Juana Perez', N'38951159', CAST(N'1998-02-02' AS Date), 1, 1)
SET IDENTITY_INSERT [dbo].[Persona] OFF
SET IDENTITY_INSERT [dbo].[TipoAtributoAdicional] ON 

INSERT [dbo].[TipoAtributoAdicional] ([TipoAtributoAdicionalID], [NombreTipoAtributo], [RequiereDetalle], [Estado]) VALUES (1, N'Maneja', 0, 1)
INSERT [dbo].[TipoAtributoAdicional] ([TipoAtributoAdicionalID], [NombreTipoAtributo], [RequiereDetalle], [Estado]) VALUES (2, N'Usa lentes', 0, 1)
INSERT [dbo].[TipoAtributoAdicional] ([TipoAtributoAdicionalID], [NombreTipoAtributo], [RequiereDetalle], [Estado]) VALUES (3, N'Diabético', 0, 1)
INSERT [dbo].[TipoAtributoAdicional] ([TipoAtributoAdicionalID], [NombreTipoAtributo], [RequiereDetalle], [Estado]) VALUES (4, N'Otra enfermedad', 1, 1)
SET IDENTITY_INSERT [dbo].[TipoAtributoAdicional] OFF
ALTER TABLE [dbo].[AtributoAdicional]  WITH CHECK ADD  CONSTRAINT [FK_AtributoAdicional_Persona] FOREIGN KEY([PersonaID])
REFERENCES [dbo].[Persona] ([PersonaID])
GO
ALTER TABLE [dbo].[AtributoAdicional] CHECK CONSTRAINT [FK_AtributoAdicional_Persona]
GO
ALTER TABLE [dbo].[AtributoAdicional]  WITH CHECK ADD  CONSTRAINT [FK_AtributoAdicional_TipoAtributoAdicional] FOREIGN KEY([TipoAtributoAdicionalID])
REFERENCES [dbo].[TipoAtributoAdicional] ([TipoAtributoAdicionalID])
GO
ALTER TABLE [dbo].[AtributoAdicional] CHECK CONSTRAINT [FK_AtributoAdicional_TipoAtributoAdicional]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Genero] FOREIGN KEY([GeneroID])
REFERENCES [dbo].[Genero] ([GeneroID])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Genero]
GO

USE [BasedeDatos1]
GO
/****** Object:  Table [dbo].[Articulo]    Script Date: 18/05/2022 12:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[seccion] [nvarchar](50) NULL,
	[nombreArticulo] [nvarchar](50) NULL,
	[precio] [money] NULL,
	[fecha] [datetime] NULL,
	[paisOrigen] [nvarchar](50) NULL,
 CONSTRAINT [PK__Table__3214EC07CD8CCA49] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 18/05/2022 12:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[direccion] [nvarchar](50) NULL,
	[poblacion] [nvarchar](50) NULL,
	[telefono] [nvarchar](50) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 18/05/2022 12:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[cCliente] [int] NULL,
	[fechaPedido] [datetime] NULL,
	[formadePago] [nvarchar](50) NULL,
	[cArticulo] [int] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articulo] ON 

INSERT [dbo].[Articulo] ([Id], [seccion], [nombreArticulo], [precio], [fecha], [paisOrigen]) VALUES (1, N'Ferreteria', N'Destornillador', 800.0000, CAST(N'2021-10-22T00:00:00.000' AS DateTime), N'ARG')
INSERT [dbo].[Articulo] ([Id], [seccion], [nombreArticulo], [precio], [fecha], [paisOrigen]) VALUES (2, N'Jugueteria', N'Muñeca Barbie', 4.5000, CAST(N'2020-01-24T00:00:00.000' AS DateTime), N'USA')
INSERT [dbo].[Articulo] ([Id], [seccion], [nombreArticulo], [precio], [fecha], [paisOrigen]) VALUES (3, N'Ferreteria', N'Alicates', 1.5000, CAST(N'2021-02-10T00:00:00.000' AS DateTime), N'ARG')
INSERT [dbo].[Articulo] ([Id], [seccion], [nombreArticulo], [precio], [fecha], [paisOrigen]) VALUES (4, N'Ferreteria', N'Martillo', 1.0800, CAST(N'2021-12-26T00:00:00.000' AS DateTime), N'ARG')
INSERT [dbo].[Articulo] ([Id], [seccion], [nombreArticulo], [precio], [fecha], [paisOrigen]) VALUES (5, N'Deportes ', N'Pelota de futbol', 2.5000, CAST(N'2021-12-04T00:00:00.000' AS DateTime), N'ARG')
INSERT [dbo].[Articulo] ([Id], [seccion], [nombreArticulo], [precio], [fecha], [paisOrigen]) VALUES (6, N'Ferreteria', N'Caño corrugado', 850.0000, CAST(N'2021-05-16T00:00:00.000' AS DateTime), N'ARG')
INSERT [dbo].[Articulo] ([Id], [seccion], [nombreArticulo], [precio], [fecha], [paisOrigen]) VALUES (7, N'Jugueteria', N'Triciclo', 1.1000, CAST(N'2021-03-09T00:00:00.000' AS DateTime), N'USA')
INSERT [dbo].[Articulo] ([Id], [seccion], [nombreArticulo], [precio], [fecha], [paisOrigen]) VALUES (8, N'Deportes', N'Pelota de tenis', 350.0000, CAST(N'2022-01-07T00:00:00.000' AS DateTime), N'USA')
INSERT [dbo].[Articulo] ([Id], [seccion], [nombreArticulo], [precio], [fecha], [paisOrigen]) VALUES (9, N'Ferreteria', N'Llave inglesa ', 1.5000, CAST(N'2021-02-08T00:00:00.000' AS DateTime), N'USA')
INSERT [dbo].[Articulo] ([Id], [seccion], [nombreArticulo], [precio], [fecha], [paisOrigen]) VALUES (10, N'Jugueteria', N'Hamacas', 2.4000, CAST(N'2022-01-24T00:00:00.000' AS DateTime), N'ARG')
INSERT [dbo].[Articulo] ([Id], [seccion], [nombreArticulo], [precio], [fecha], [paisOrigen]) VALUES (11, N'Hogar', N'Microondas ', 20.5000, CAST(N'2021-08-04T00:00:00.000' AS DateTime), N'ARG')
INSERT [dbo].[Articulo] ([Id], [seccion], [nombreArticulo], [precio], [fecha], [paisOrigen]) VALUES (12, N'Hogar', N'Smart TV 32"', 33.5000, CAST(N'2021-09-18T00:00:00.000' AS DateTime), N'ARG')
INSERT [dbo].[Articulo] ([Id], [seccion], [nombreArticulo], [precio], [fecha], [paisOrigen]) VALUES (13, N'Deportes ', N'Pelota de voley', 1.4000, CAST(N'2021-12-15T00:00:00.000' AS DateTime), N'PAR')
INSERT [dbo].[Articulo] ([Id], [seccion], [nombreArticulo], [precio], [fecha], [paisOrigen]) VALUES (14, N'Libreria', N'Marcadores', 4.3000, CAST(N'2022-03-15T00:00:00.000' AS DateTime), N'ENG')
INSERT [dbo].[Articulo] ([Id], [seccion], [nombreArticulo], [precio], [fecha], [paisOrigen]) VALUES (15, N'Libreria', N'Resma', 1.2500, CAST(N'2021-09-19T00:00:00.000' AS DateTime), N'ARG')
SET IDENTITY_INSERT [dbo].[Articulo] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([Id], [nombre], [direccion], [poblacion], [telefono]) VALUES (1, N'Libreria Rubén', N'David Luque 14', N'Córdoba', N'0351-216-0734')
INSERT [dbo].[Cliente] ([Id], [nombre], [direccion], [poblacion], [telefono]) VALUES (2, N'Venex', N'Félix Frías 1203', N'Córdoba', N'0810-555-8892')
INSERT [dbo].[Cliente] ([Id], [nombre], [direccion], [poblacion], [telefono]) VALUES (3, N'Compu Cordoba Computación', N'Bv Pte. Umberto Arturo Illia 545', N'Córdoba', N'0351 421-8377')
INSERT [dbo].[Cliente] ([Id], [nombre], [direccion], [poblacion], [telefono]) VALUES (4, N'Mundo Fix', N'Av. Emilio Olmos 188', N'Córdoba', N'0351 425-4922')
INSERT [dbo].[Cliente] ([Id], [nombre], [direccion], [poblacion], [telefono]) VALUES (5, N'La Ferretería', N'Bolívar 398', N'Rio Cuarto', N'0358 463-8801')
INSERT [dbo].[Cliente] ([Id], [nombre], [direccion], [poblacion], [telefono]) VALUES (6, N'Libreria "Las Estrellas"', N'Sarmiento Blvd. 1823', N'Villa Maria', N'0353 476-8317')
INSERT [dbo].[Cliente] ([Id], [nombre], [direccion], [poblacion], [telefono]) VALUES (7, N'Librería Arte Papel', N'San Martin 382', N'Villa Maria', N'0353 453-3853')
INSERT [dbo].[Cliente] ([Id], [nombre], [direccion], [poblacion], [telefono]) VALUES (8, N'WINIE', N'Corrientes 68', N'Córdoba', N'0351-125-4855')
INSERT [dbo].[Cliente] ([Id], [nombre], [direccion], [poblacion], [telefono]) VALUES (9, N'Heladería Venezia', N'Av. Duarte Quirós 2800', N'Villa Allende 124', N'0351 585-6426')
INSERT [dbo].[Cliente] ([Id], [nombre], [direccion], [poblacion], [telefono]) VALUES (10, N'Heladeria Glup''s', N'Av. Colon 14', N'Córdoba', N'0351 882-6055')
INSERT [dbo].[Cliente] ([Id], [nombre], [direccion], [poblacion], [telefono]) VALUES (11, N'Atrapacuentos', N'Belgrano 773', N'Córdoba', N' 0351-512-363')
INSERT [dbo].[Cliente] ([Id], [nombre], [direccion], [poblacion], [telefono]) VALUES (12, N'Jugueterías Cachavacha', N'Av. Velez Sarsfield 354', N'Córdoba', N'0351-570-4150')
INSERT [dbo].[Cliente] ([Id], [nombre], [direccion], [poblacion], [telefono]) VALUES (14, N'Ferretería Santa María', N'Av. La Plata 213', N'Cosquin', N'0354-259-4587')
INSERT [dbo].[Cliente] ([Id], [nombre], [direccion], [poblacion], [telefono]) VALUES (15, N'ENKANTO''S', N'Av. San Martin', N'Cosquin', N'0354-215-9852')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Pedido] ON 

INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (100, 2, CAST(N'2022-05-18T12:40:17.520' AS DateTime), N'Tarjeta', 12)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (101, 2, CAST(N'2022-05-18T12:40:27.817' AS DateTime), N'Contado', 11)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (102, 3, CAST(N'2022-05-18T12:41:08.330' AS DateTime), N'Cheque', 12)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (103, 4, CAST(N'2022-05-18T12:41:34.423' AS DateTime), N'Contado', 7)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (104, 5, CAST(N'2022-05-18T12:41:57.287' AS DateTime), N'Tarjeta', 3)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (105, 5, CAST(N'2022-05-18T12:42:09.520' AS DateTime), N'Tarjeta', 6)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (106, 5, CAST(N'2022-05-18T12:42:24.913' AS DateTime), N'Contado', 1)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (107, 6, CAST(N'2022-05-18T12:42:40.353' AS DateTime), N'Contado', 2)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (108, 7, CAST(N'2022-05-18T12:43:06.023' AS DateTime), N'Contado', 5)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (109, 7, CAST(N'2022-05-18T12:43:13.217' AS DateTime), N'Contado', 12)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (110, 7, CAST(N'2022-05-18T12:43:20.657' AS DateTime), N'Contado', 15)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (111, 7, CAST(N'2022-05-18T12:43:27.823' AS DateTime), N'Tarjeta', 6)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (112, 10, CAST(N'2022-05-18T12:44:04.970' AS DateTime), N'Contado', 6)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (113, 10, CAST(N'2022-05-18T12:44:12.703' AS DateTime), N'Tarjeta', 2)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (116, 14, CAST(N'2022-05-18T12:44:54.483' AS DateTime), N'Contado', 7)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (117, 14, CAST(N'2022-05-18T12:45:00.073' AS DateTime), N'Contado', 3)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (118, 14, CAST(N'2022-05-18T12:45:05.383' AS DateTime), N'Contado', 6)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (119, 7, CAST(N'2022-05-18T12:49:50.427' AS DateTime), N'Contado', 7)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (120, 3, CAST(N'2022-05-18T12:50:29.323' AS DateTime), N'Contado', 3)
INSERT [dbo].[Pedido] ([Id], [cCliente], [fechaPedido], [formadePago], [cArticulo]) VALUES (122, 12, CAST(N'2022-05-18T12:55:45.673' AS DateTime), N'Contado', 15)
SET IDENTITY_INSERT [dbo].[Pedido] OFF
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Articulo] FOREIGN KEY([cArticulo])
REFERENCES [dbo].[Articulo] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Articulo]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente] FOREIGN KEY([cCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente]
GO
/****** Object:  StoredProcedure [dbo].[Editar]    Script Date: 18/05/2022 12:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Editar](
@Id int,
@nombre nvarchar(50),
@direccion nvarchar(50),
@telefono nvarchar(50),
@poblacion nvarchar(50))
as
begin
	update Cliente set  nombre=@nombre, 
						direccion=@direccion, 
						telefono=@telefono, 
						poblacion=@poblacion
						Where Id = @Id
end
GO
/****** Object:  StoredProcedure [dbo].[Eliminar]    Script Date: 18/05/2022 12:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Eliminar](
@Id int
)
as 
begin
	delete from Cliente where Id = @Id  
end
GO
/****** Object:  StoredProcedure [dbo].[Guardar]    Script Date: 18/05/2022 12:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Guardar](
@nombre nvarchar(50),
@direccion nvarchar(50),
@telefono nvarchar(50),
@poblacion nvarchar(50))
as 
begin
	insert into Cliente(nombre, direccion, poblacion, telefono) values(@nombre, @direccion, @telefono, @poblacion )
end
GO
/****** Object:  StoredProcedure [dbo].[listar]    Script Date: 18/05/2022 12:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[listar]

as 
begin 
Select * from Cliente

end
GO
/****** Object:  StoredProcedure [dbo].[Obtener]    Script Date: 18/05/2022 12:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Obtener](
@IdCliente int)
as 
begin 
Select * from Cliente Where Id = @IdCliente 
end
GO

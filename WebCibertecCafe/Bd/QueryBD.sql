USE [CIBER_COFFEE]
GO
/****** Object:  Table [dbo].[CLIENT_REQUEST]    Script Date: 19/09/2021 12:21:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENT_REQUEST](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAMES] [varchar](50) NOT NULL,
	[SURNAMES] [varchar](80) NOT NULL,
	[MAIL] [varchar](100) NOT NULL,
	[TEL_NUM] [varchar](9) NOT NULL,
 CONSTRAINT [PK_CLIENT_REQUEST_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCT_LETTER]    Script Date: 19/09/2021 12:21:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCT_LETTER](
	[ID] [int] IDENTITY(1001,1) NOT NULL,
	[NAME] [varchar](50) NOT NULL,
	[DESCRIPTION] [varchar](500) NOT NULL,
	[IMAGE] [varchar](200) NULL,
	[PRECIO] [money] NULL,
	[STOCK] [int] NULL,
 CONSTRAINT [PK_PRODUCT_LETTER_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SALE_DETAIL]    Script Date: 19/09/2021 12:21:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SALE_DETAIL](
	[ID_CLIENT] [int] NULL,
	[ID_PRODUCT] [int] NULL,
	[QUANTITY_PRODUCT] [int] NOT NULL,
	[TOTAL] [decimal](10, 2) NOT NULL,
	[TOTAL_SALE] [decimal](10, 2) NOT NULL,
	[ID] [int] IDENTITY(2000,1) NOT NULL,
 CONSTRAINT [PK_DETAIL_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PRODUCT_LETTER] ON 
GO
INSERT [dbo].[PRODUCT_LETTER] ([ID], [NAME], [DESCRIPTION], [IMAGE], [PRECIO], [STOCK]) VALUES (1006, N'Expresso', N'Uno de los tipos de caf?? m??s b??sicos y sencillos, ??nicamente consta de un infusi??n de caf?? la cual se realiza hirviendo agua en contacto con el grano. Se puede preparar en pocos segundos. Se trata de un tipo de caf?? corto, y su tama??o suele ser de alrededor de 30 cl. Es habitual el uso de caf?? de la variante ar??biga. Habitualmente suele tener algo de espuma por encima.', N'~/Images/img1.png', 5.8000, 30)
GO
INSERT [dbo].[PRODUCT_LETTER] ([ID], [NAME], [DESCRIPTION], [IMAGE], [PRECIO], [STOCK]) VALUES (1007, N'Americano', N'El caf?? americano es un tipo de caf?? derivado del espresso el cual se caracteriza por a??adir una cantidad de agua mucho mayor de lo habitual en este tipo de preparaci??n, teniendo como resultado un producto con un sabor menos potente y algo m??s aguado, algo que lo hace menos amargo y facilita un sabor dulce. En este caso se realizar??a primero un espresso y a este se le a??adir??a externamente agua hirviendo.', N'~/Images/img2.png', 10.5000, 15)
GO
INSERT [dbo].[PRODUCT_LETTER] ([ID], [NAME], [DESCRIPTION], [IMAGE], [PRECIO], [STOCK]) VALUES (1009, N'Capuchino', N'El capuchino es otro de los caf??s m??s habituales, siendo semejante al caf?? con leche con la excepci??n de que en este caso solo encontraremos alrededor de un tercio de caf??, siendo el resto leche. Por lo general gran parte de esta es espumada, y suele a??ad??rsele de forma espolvoreada algo de cacao en polvo para darle un sabor m??s dulce.', N'~/Images/img3.png', 8.5000, 12)
GO
INSERT [dbo].[PRODUCT_LETTER] ([ID], [NAME], [DESCRIPTION], [IMAGE], [PRECIO], [STOCK]) VALUES (1010, N'Bomb??n', N'Una versi??n mucho m??s endulzada del caf?? con leche es la variante conocida caf?? bomb??n, en el que se sustituye la leche normal por la leche condensada. Lo habitual es que se ponga primero ??sta para luego agregar el caf??.', N'~/Images/img4.png', 15.3000, 20)
GO
SET IDENTITY_INSERT [dbo].[PRODUCT_LETTER] OFF
GO
ALTER TABLE [dbo].[SALE_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_CLIENT_SALE] FOREIGN KEY([ID_CLIENT])
REFERENCES [dbo].[CLIENT_REQUEST] ([ID])
GO
ALTER TABLE [dbo].[SALE_DETAIL] CHECK CONSTRAINT [FK_CLIENT_SALE]
GO
ALTER TABLE [dbo].[SALE_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_SALE] FOREIGN KEY([ID_PRODUCT])
REFERENCES [dbo].[PRODUCT_LETTER] ([ID])
GO
ALTER TABLE [dbo].[SALE_DETAIL] CHECK CONSTRAINT [FK_PRODUCT_SALE]
GO

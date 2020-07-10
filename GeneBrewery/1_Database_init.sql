USE [GeneBrewery]
GO
/****** Object:  Table [dbo].[Beer]    Script Date: 10-07-20 16:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Price] [decimal](3, 2) NOT NULL,
	[AlcoholDegree] [decimal](2, 1) NOT NULL,
	[BreweryId] [bigint] NOT NULL,
 CONSTRAINT [PK_Beer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BeerProvider]    Script Date: 10-07-20 16:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BeerProvider](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BeerId] [bigint] NOT NULL,
	[ProviderId] [bigint] NOT NULL,
	[AvailableQuantity] [int] NOT NULL,
 CONSTRAINT [PK_BeerProvider] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brewery]    Script Date: 10-07-20 16:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brewery](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Brewery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provider]    Script Date: 10-07-20 16:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provider](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Provider] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Beer]  WITH CHECK ADD  CONSTRAINT [FK_Beer_Brewery] FOREIGN KEY([BreweryId])
REFERENCES [dbo].[Brewery] ([Id])
GO
ALTER TABLE [dbo].[Beer] CHECK CONSTRAINT [FK_Beer_Brewery]
GO
ALTER TABLE [dbo].[BeerProvider]  WITH CHECK ADD  CONSTRAINT [FK_BeerProvider_Beer] FOREIGN KEY([BeerId])
REFERENCES [dbo].[Beer] ([Id])
GO
ALTER TABLE [dbo].[BeerProvider] CHECK CONSTRAINT [FK_BeerProvider_Beer]
GO
ALTER TABLE [dbo].[BeerProvider]  WITH CHECK ADD  CONSTRAINT [FK_BeerProvider_Provider] FOREIGN KEY([ProviderId])
REFERENCES [dbo].[Provider] ([Id])
GO
ALTER TABLE [dbo].[BeerProvider] CHECK CONSTRAINT [FK_BeerProvider_Provider]
GO

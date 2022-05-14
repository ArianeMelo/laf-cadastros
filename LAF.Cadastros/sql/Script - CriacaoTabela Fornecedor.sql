USE [LajfCadastroProdutosDB]
GO



/****** Object: Table [dbo].[Fornecedores] Script Date: 13/05/2022 20:17:32 ******/
SET ANSI_NULLS ON
GO



SET QUOTED_IDENTIFIER ON
GO



CREATE TABLE [dbo].[Fornecedores](
[Id] [uniqueidentifier] NOT NULL,
[Nome] [varchar](200) NOT NULL,
[Documento] [varchar](14) NOT NULL,
[TipoFornecedor] [int] NOT NULL,
[Ativo] [bit] NOT NULL,
CONSTRAINT [PK_Fornecedores] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
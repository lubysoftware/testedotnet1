CREATE TABLE [dbo].[Desenvolvedor] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Nome] VARCHAR (50) NULL,
    CONSTRAINT [PK_Desenvolvedor] PRIMARY KEY CLUSTERED ([Id] ASC)
);


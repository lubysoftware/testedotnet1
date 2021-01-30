CREATE TABLE [dbo].[Projeto] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Nome] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Projeto] PRIMARY KEY CLUSTERED ([Id] ASC)
);


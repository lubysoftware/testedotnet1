CREATE TABLE [dbo].[Relogio_Ponto] (
    [Id]               INT      IDENTITY (1, 1) NOT NULL,
    [Id_Desenvolvedor] INT      NOT NULL,
    [entrada]          DATETIME NOT NULL,
    [saida]            DATETIME NOT NULL,
    CONSTRAINT [PK_Relogio_Ponto] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Relogio_Ponto_Relogio_Ponto] FOREIGN KEY ([Id_Desenvolvedor]) REFERENCES [dbo].[Desenvolvedor] ([Id]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[Relogio_Ponto] NOCHECK CONSTRAINT [FK_Relogio_Ponto_Relogio_Ponto];


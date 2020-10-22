CREATE TABLE [dbo].[Person](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](250) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RegisterHour](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[DeveloperId] [bigint] NOT NULL,
 CONSTRAINT [PK_RegisterHour2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RegisterHour]  WITH CHECK ADD  CONSTRAINT [FK_RegisterHour_Person] FOREIGN KEY([DeveloperId])
REFERENCES [dbo].[Person] ([Id])
GO

ALTER TABLE [dbo].[RegisterHour] CHECK CONSTRAINT [FK_RegisterHour_Person]
GO

--Usuários de testes
insert into Person (Name)
values    ('Paulo Santos')
		, ('Roberto Silva')
		, ('Mariana Ribeiro')
		, ('Jessica Melos')
		, ('Alcione Dutra')		
		, ('Beatris Lemos')		
		, ('Gilberto Moreira')		
		, ('Hudson Santos')		
		, ('Paula Witzel')		
		, ('Felipe Gueds')

CREATE TABLE [dbo].[registros]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [email] VARCHAR(50) NOT NULL, 
    [nome] VARCHAR(100) NOT NULL, 
    [cidade] VARCHAR(100) NOT NULL, 
	[estado] VARCHAR(50) NOT NULL,
    [data_criacao] DATETIME NOT NULL
)
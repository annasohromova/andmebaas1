CREATE TABLE [dbo].[Tooded]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Toodenimetus] VARCHAR(30) NOT NULL, 
    [Kogus] INT NOT NULL, 
    [Hind] FLOAT NOT NULL, 
    [Pilt] TEXT NOT NULL, 
    [Kategooria] INT NOT NULL
)

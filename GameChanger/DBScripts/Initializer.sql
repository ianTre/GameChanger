
CREATE DATABASE DBGameChanger
GO

USE DBGameChanger
GO

CREATE TABLE  [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,

PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

 

INSERT INTO [dbo].[Country]
           ([Name])

     VALUES
           ('Argentina')

GO



CREATE TABLE  [dbo].[Province](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](100) NULL,
	[IdCountry] [int] FOREIGN KEY REFERENCES Country(Id) NOT NULL

 

PRIMARY KEY CLUSTERED
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

GO
INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Buenos Aires',1)

		   GO   

           INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Ciudad Autónoma de Buenos Aires',1)
		  		  GO   
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ( 'Catamarca',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Chaco',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Chubut',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Córdoba',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Corrientes',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Formosa',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Jujuy',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('La Pampa',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('La Rioja',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Mendoza',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Misiones',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Neuquén',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Río Negro',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Buenos Aires',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Salta',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('San Juan',1)
		   GO  
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('San Luis',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Santa Cruz',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Santa Fe',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Santiago del Estero',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Tierra del Fuego',1)
		    GO 
		   INSERT INTO [dbo].[Province]
           ([Name],[IdCountry])

     VALUES
           ('Tucumán',1)

 

 

GO



CREATE TABLE  [dbo].[UserAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Email] [varchar](200) NULL,
	[DNI] [varchar](200) NULL,
	[Name] [varchar](200) NULL,
	[Surname] [varchar](200) NULL,
	[IdCountry] [int] FOREIGN KEY REFERENCES Country(Id) NOT NULL,
	[IdProvince] [int] FOREIGN KEY REFERENCES Province(Id) NOT NULL,
	[CreationDate] [DateTime] NULL,
	[BirthDate] [DateTime] NULL,
	[Password] [varchar](200) NOT NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE UserAccount_Save
	
	
	@UserName varchar(50),
	@Email varchar(200),
	@DNI varchar(200),
	@Name varchar(200),
	@Surname varchar(200),
	@IdCountry int,
	@IdProvince int,
	@CreationDate DateTime,
	@BirthDate DateTime,
	@Password varchar(200),
	@IsActive bit
		 	 
AS
BEGIN
	
	INSERT INTO [dbo].[UserAccount]
           ([UserName]
           ,[Email]
           ,[DNI]
           ,[Name]
           ,[Surname]
           ,[IdCountry]
           ,[IdProvince]
           ,[CreationDate]
		   ,[BirthDate]
		   ,[Password]
		   ,[IsActive]
		   )
     VALUES
       (@UserName , @Email , @DNI , @Name , @Surname , @IdCountry , @IdProvince , @CreationDate,@BirthDate,@Password,@IsActive )
END


GO

CREATE PROCEDURE [dbo].[ProvinceGetAll]
    
AS
BEGIN
    SELECT * from Province
END



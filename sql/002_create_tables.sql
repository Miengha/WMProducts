use WritersHaven
go

if not exists(SELECT 1 FROM INFORMATION_SCHEMA.TABLES
           WHERE TABLE_NAME = 'User')
begin
    CREATE TABLE dbo.[User]
		 ( UserID INT IDENTITY(1,1) NOT NULL,
		   LoginName NVARCHAR(255)   NOT NULL,
		   PasswordHash BINARY(64)  NOT NULL,
		   Salt UNIQUEIDENTIFIER    NOT NULL
		   CONSTRAINT [PK_User_UserID] PRIMARY KEY CLUSTERED (UserID ASC))
end

if not exists(SELECT 1 FROM INFORMATION_SCHEMA.TABLES
           WHERE TABLE_NAME = 'Universes')
begin
    create table Universes
         ( Id				int           identity(1,1),
           [Name]			nvarchar(255) not null,
		   [Description]    nvarchar(255) not null,
		   UserID		int			  not null
           constraint pk_UniverseId primary key (Id)
		   constraint fk_UserUniverse FOREIGN KEY (UserID) REFERENCES [User](UserID))
end
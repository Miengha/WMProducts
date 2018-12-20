use WritersHaven
go

if exists(SELECT 1 FROM sys.procedures 
           WHERE object_id = OBJECT_ID(N'rsp_uspAddUser'))
begin
  drop procedure rsp_uspAddUser
end
go

Create PROCEDURE dbo.rsp_uspAddUser
    @pLogin NVARCHAR(255), 
    @pPassword NVARCHAR(255),
    @responseMessage NVARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
    DECLARE @salt UNIQUEIDENTIFIER=NEWID()
    BEGIN TRY
        INSERT INTO dbo.[User] (LoginName, PasswordHash, Salt)
        VALUES(@pLogin, HASHBYTES('SHA2_512', @pPassword+CAST(@salt AS NVARCHAR(36))), @salt)

       SET @responseMessage='Success'
    END TRY
    BEGIN CATCH
        SET @responseMessage=ERROR_MESSAGE() 
    END CATCH
END

SELECT @responseMessage as N'@responseMessage'
GO

grant execute on rsp_uspAddUser to public
go

if exists(SELECT 1 FROM sys.procedures 
           WHERE object_id = OBJECT_ID(N'rsp_uspLogin'))
begin
  drop procedure rsp_uspLogin
end
go

CREATE PROCEDURE dbo.rsp_uspLogin
    @pLoginName NVARCHAR(255),
    @pPassword NVARCHAR(255),
    @responseMessage NVARCHAR(255)='' OUTPUT
AS
BEGIN
    SET NOCOUNT ON
    DECLARE @userID INT
    IF EXISTS (SELECT TOP 1 UserID FROM [dbo].[User] WHERE LoginName=@pLoginName)
    BEGIN
        SET @userID=(SELECT UserID FROM [dbo].[User] WHERE LoginName=@pLoginName AND PasswordHash=HASHBYTES('SHA2_512', @pPassword+CAST(Salt AS NVARCHAR(36))))
       IF(@userID IS NULL)
           SET @responseMessage='Incorrect password'
       ELSE 
           SET @responseMessage='User successfully logged in'
    END
    ELSE
       SET @responseMessage='Invalid login'
END

SELECT @responseMessage as N'@responseMessage'
GO

grant execute on rsp_uspLogin to public
go

if exists(SELECT 1 FROM sys.procedures 
           WHERE object_id = OBJECT_ID(N'rsp_Users_Get'))
begin
  drop procedure rsp_Users_Get
end
go

create procedure rsp_Users_Get
as
  select UserID,
         LoginName
    from [User]
go

grant execute on rsp_Users_GetById to public
go

if exists(SELECT 1 FROM sys.procedures 
           WHERE object_id = OBJECT_ID(N'rsp_Users_GetById'))
begin
  drop procedure rsp_Users_GetById
end
go

create procedure rsp_Users_GetById
	(  @Id int)
as
  select UserID,
         LoginName
    from [User]
   where UserID = @Id
go

grant execute on rsp_Users_GetById to public
go

if exists(SELECT 1 FROM sys.procedures 
           WHERE object_id = OBJECT_ID(N'rsp_Users_GetByName'))
begin
  drop procedure rsp_Users_GetByName
end
go

create procedure rsp_Users_GetByName
	(  @Name nvarchar(255))
as
  select UserID,
         LoginName
    from [User]
   where LoginName = @Name
go

grant execute on rsp_Users_GetByName to public
go
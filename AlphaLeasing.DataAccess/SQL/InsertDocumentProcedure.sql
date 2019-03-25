CREATE PROCEDURE CreateDoc @name nvarchar(255), @date nvarchar(255), @userId int
AS
INSERT INTO [dbo].[Document]
([Name]
           ,[Date]
           ,[UserId])
     VALUES
           (@name
           , @date
           , @userId)
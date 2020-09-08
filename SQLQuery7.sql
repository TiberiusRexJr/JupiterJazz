-- =======================================================
-- Create Stored Procedure Template for Azure SQL Database
-- =======================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Eli
-- Create Date: 8-4-20
-- Description: 
-- =============================================
CREATE PROCEDURE Extras
(
    -- Add the parameters for the stored procedure here
    @fileName varchar = null,
	@contentType varchar=null,
    @email varchar = null,
	@picData varbinary=null
	
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    insert into dbo.WinningAtWalmart_Workers(ProfilePicture,ContentType)
	values (@picData,@contentType)
END
GO

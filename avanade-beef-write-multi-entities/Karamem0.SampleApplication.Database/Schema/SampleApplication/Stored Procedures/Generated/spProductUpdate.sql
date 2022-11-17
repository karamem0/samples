CREATE PROCEDURE [SampleApplication].[spProductUpdate]
  @ProductId AS UNIQUEIDENTIFIER,
  @ProductName AS NVARCHAR(255),
  @Price AS DECIMAL(15, 0),
  @UpdatedBy AS NVARCHAR(250) NULL = NULL,
  @UpdatedDate AS DATETIME2 NULL = NULL,
  @ReselectRecord AS BIT = 0
AS
BEGIN
  /*
   * This is automatically generated; any changes will be lost.
   */

  SET NOCOUNT ON;

  BEGIN TRY
    -- Wrap in a transaction.
    BEGIN TRANSACTION

    -- Set audit details.
    EXEC @UpdatedDate = fnGetTimestamp @UpdatedDate
    EXEC @UpdatedBy = fnGetUsername @UpdatedBy

    -- Check exists.
    DECLARE @PrevRowCount INT
    SET @PrevRowCount = (SELECT COUNT(*) FROM [SampleApplication].[Product] AS [p] WHERE [p].[ProductId] = @ProductId)
    IF @PrevRowCount <> 1
    BEGIN
      EXEC spThrowNotFoundException
    END

    -- Update the record.
    UPDATE [p] SET
        [p].[ProductName] = @ProductName,
        [p].[Price] = @Price,
        [p].[UpdatedBy] = @UpdatedBy,
        [p].[UpdatedDate] = @UpdatedDate
      FROM [SampleApplication].[Product] AS [p]
      WHERE [p].[ProductId] = @ProductId

    -- Commit the transaction.
    COMMIT TRANSACTION
  END TRY
  BEGIN CATCH
    -- Rollback transaction and rethrow error.
    IF @@TRANCOUNT > 0
      ROLLBACK TRANSACTION;

    THROW;
  END CATCH

  -- Reselect record.
  IF @ReselectRecord = 1
  BEGIN
    EXEC [SampleApplication].[spProductGet] @ProductId
  END
END

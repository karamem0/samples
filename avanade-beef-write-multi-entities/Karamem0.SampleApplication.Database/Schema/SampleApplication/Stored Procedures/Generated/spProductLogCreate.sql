CREATE PROCEDURE [SampleApplication].[spProductLogCreate]
  @LogId AS UNIQUEIDENTIFIER = NULL OUTPUT,
  @ProductId AS UNIQUEIDENTIFIER,
  @ProductName AS NVARCHAR(255),
  @Price AS DECIMAL(15, 0),
  @CreatedBy AS NVARCHAR(250) NULL = NULL,
  @CreatedDate AS DATETIME2 NULL = NULL,
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
    EXEC @CreatedDate = fnGetTimestamp @CreatedDate
    EXEC @CreatedBy = fnGetUsername @CreatedBy

    -- Create the record.
    DECLARE @InsertedIdentity TABLE([LogId] UNIQUEIDENTIFIER)

    INSERT INTO [SampleApplication].[ProductLog] (
      [ProductId],
      [ProductName],
      [Price],
      [CreatedBy],
      [CreatedDate]
    )
    OUTPUT inserted.LogId INTO @InsertedIdentity
    VALUES (
      @ProductId,
      @ProductName,
      @Price,
      @CreatedBy,
      @CreatedDate
    )

    -- Get the inserted identity.
    SELECT @LogId = [LogId] FROM @InsertedIdentity

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
    EXEC [SampleApplication].[spProductLogGet] @LogId
  END
END

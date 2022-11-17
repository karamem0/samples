CREATE PROCEDURE [SampleApplication].[spProductLogGet]
  @LogId AS UNIQUEIDENTIFIER
AS
BEGIN
  /*
   * This is automatically generated; any changes will be lost.
   */

  SET NOCOUNT ON;

  -- Execute the primary select query.
  SELECT
      [pl].[LogId],
      [pl].[ProductId],
      [pl].[ProductName],
      [pl].[Price],
      [pl].[CreatedBy],
      [pl].[CreatedDate],
      [pl].[UpdatedBy],
      [pl].[UpdatedDate]
    FROM [SampleApplication].[ProductLog] AS [pl]
      WHERE [pl].[LogId] = @LogId
END

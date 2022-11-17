CREATE PROCEDURE [SampleApplication].[spProductGet]
  @ProductId AS UNIQUEIDENTIFIER
AS
BEGIN
  /*
   * This is automatically generated; any changes will be lost.
   */

  SET NOCOUNT ON;

  -- Execute the primary select query.
  SELECT
      [p].[ProductId],
      [p].[ProductName],
      [p].[Price],
      [p].[CreatedBy],
      [p].[CreatedDate],
      [p].[UpdatedBy],
      [p].[UpdatedDate]
    FROM [SampleApplication].[Product] AS [p]
      WHERE [p].[ProductId] = @ProductId
END

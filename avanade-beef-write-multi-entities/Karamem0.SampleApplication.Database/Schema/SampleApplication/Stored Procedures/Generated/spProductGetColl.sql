CREATE PROCEDURE [SampleApplication].[spProductGetColl]
AS
BEGIN
  /*
   * This is automatically generated; any changes will be lost.
   */

  SET NOCOUNT ON;

  -- Select the requested data.
  SELECT
      [p].[ProductId],
      [p].[ProductName],
      [p].[Price],
      [p].[CreatedBy],
      [p].[CreatedDate],
      [p].[UpdatedBy],
      [p].[UpdatedDate]
    FROM [SampleApplication].[Product] AS [p]
END

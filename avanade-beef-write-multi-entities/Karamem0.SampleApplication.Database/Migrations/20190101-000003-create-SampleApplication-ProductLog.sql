BEGIN TRANSACTION

CREATE TABLE [SampleApplication].[ProductLog] (
	[LogId] UNIQUEIDENTIFIER NOT NULL DEFAULT (NEWSEQUENTIALID()) PRIMARY KEY,
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	[ProductName] NVARCHAR (255) NOT NULL,
	[Price] DECIMAL (15, 0) NOT NULL,
	[CreatedBy] NVARCHAR(250) NULL,
	[CreatedDate] DATETIME2 NULL,
	[UpdatedBy] NVARCHAR(250) NULL,
	[UpdatedDate] DATETIME2 NULL
);

COMMIT TRANSACTION

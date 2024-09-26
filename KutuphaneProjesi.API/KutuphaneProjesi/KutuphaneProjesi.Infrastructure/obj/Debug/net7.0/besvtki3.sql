BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId', N'CreatedDate', N'Discriminator', N'Status', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
    SET IDENTITY_INSERT [AspNetUserRoles] ON;
INSERT INTO [AspNetUserRoles] ([RoleId], [UserId], [CreatedDate], [Discriminator], [Status], [UpdatedDate])
VALUES ('1e5f19f8-43b0-45fe-b276-f37d9a6541d8', '5a2b12d5-b30d-4e67-b31f-5fe19a367485', NULL, N'UserRole', NULL, NULL),
('66d20726-5805-4468-86f2-63ae89d402c1', '7ca69cfa-88fc-4569-aed2-a1becaf4f9a6', NULL, N'UserRole', NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId', N'CreatedDate', N'Discriminator', N'Status', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
    SET IDENTITY_INSERT [AspNetUserRoles] OFF;
GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'bc6a5c7a-aff4-4e6c-8874-16815ed68065'
WHERE [Id] = '5a2b12d5-b30d-4e67-b31f-5fe19a367485';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'c7009578-b8c0-4676-9a16-c6d3fbccc881'
WHERE [Id] = '7ca69cfa-88fc-4569-aed2-a1becaf4f9a6';
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240923203845_AddUserRoleData', N'7.0.20');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Books]') AND [c].[name] = N'Publisher');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Books] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Books] ALTER COLUMN [Publisher] nvarchar(max) NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Books]') AND [c].[name] = N'Name');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Books] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Books] ALTER COLUMN [Name] nvarchar(max) NOT NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Books]') AND [c].[name] = N'Image');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Books] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Books] ALTER COLUMN [Image] nvarchar(max) NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Books]') AND [c].[name] = N'AuthorName');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Books] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Books] ALTER COLUMN [AuthorName] nvarchar(max) NULL;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Password');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [AspNetUsers] ALTER COLUMN [Password] nvarchar(max) NOT NULL;
GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'130ff882-6991-4ffe-8d87-7b2b4ee0b3b8'
WHERE [Id] = '5a2b12d5-b30d-4e67-b31f-5fe19a367485';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'5529459b-b751-4975-81a6-107de54c2623'
WHERE [Id] = '7ca69cfa-88fc-4569-aed2-a1becaf4f9a6';
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240924132426_UpdateToImage', N'7.0.20');
GO

COMMIT;
GO


IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [People] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(70) NOT NULL,
    [Email] varchar(100) NOT NULL,
    [Photo] varchar(100) NOT NULL,
    [Birthdate] datetime2 NOT NULL,
    [WhatsAppNumber] varchar(14) NOT NULL,
    CONSTRAINT [PK_People] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190928160429_Adding person entity on DB', N'2.2.6-servicing-10079');

GO


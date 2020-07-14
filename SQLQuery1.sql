
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/10/2019 05:28:48
-- Generated from EDMX file: C:\Users\ISHAN\source\repos\project\hikeforyourselfver3\Models\HikeModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-hikeforyourselfver3-20190915032733];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AspNetRoleAspNetUser_AspNetRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetRoleAspNetUser] DROP CONSTRAINT [FK_AspNetRoleAspNetUser_AspNetRole];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetRoleAspNetUser_AspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetRoleAspNetUser] DROP CONSTRAINT [FK_AspNetRoleAspNetUser_AspNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserHikeBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HikeBookings] DROP CONSTRAINT [FK_AspNetUserHikeBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_HikeBookingHiking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HikeBookings] DROP CONSTRAINT [FK_HikeBookingHiking];
GO
IF OBJECT_ID(N'[dbo].[FK_HikeRatingAspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HikeRatings] DROP CONSTRAINT [FK_HikeRatingAspNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_HikeRatingHiking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HikeRatings] DROP CONSTRAINT [FK_HikeRatingHiking];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AspNetRoleAspNetUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoleAspNetUser];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[HikeBookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HikeBookings];
GO
IF OBJECT_ID(N'[dbo].[HikeRatings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HikeRatings];
GO
IF OBJECT_ID(N'[dbo].[Hikings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hikings];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'HikeBookings'
CREATE TABLE [dbo].[HikeBookings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [AspNetUserId] nvarchar(128)  NOT NULL,
    [HikingId] int  NOT NULL
);
GO

-- Creating table 'Hikings'
CREATE TABLE [dbo].[Hikings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HikeName] nvarchar(max)  NOT NULL,
    [HikeLoc] nvarchar(max)  NOT NULL,
    [HikeDesc] nvarchar(max)  NOT NULL,
    [HikePrice] nvarchar(max)  NOT NULL,
    [HikeDate] datetime  NOT NULL
);
GO

-- Creating table 'HikeRatings'
CREATE TABLE [dbo].[HikeRatings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HikeComment] nvarchar(max)  NOT NULL,
    [Rating] nvarchar(max)  NOT NULL,
    [HikingId] int  NOT NULL,
    [AspNetUserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetRoleAspNetUser'
CREATE TABLE [dbo].[AspNetRoleAspNetUser] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HikeBookings'
ALTER TABLE [dbo].[HikeBookings]
ADD CONSTRAINT [PK_HikeBookings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Hikings'
ALTER TABLE [dbo].[Hikings]
ADD CONSTRAINT [PK_Hikings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HikeRatings'
ALTER TABLE [dbo].[HikeRatings]
ADD CONSTRAINT [PK_HikeRatings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetRoleAspNetUser'
ALTER TABLE [dbo].[AspNetRoleAspNetUser]
ADD CONSTRAINT [PK_AspNetRoleAspNetUser]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetRoleAspNetUser'
ALTER TABLE [dbo].[AspNetRoleAspNetUser]
ADD CONSTRAINT [FK_AspNetRoleAspNetUser_AspNetRole]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetRoleAspNetUser'
ALTER TABLE [dbo].[AspNetRoleAspNetUser]
ADD CONSTRAINT [FK_AspNetRoleAspNetUser_AspNetUser]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetRoleAspNetUser_AspNetUser'
CREATE INDEX [IX_FK_AspNetRoleAspNetUser_AspNetUser]
ON [dbo].[AspNetRoleAspNetUser]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [AspNetUserId] in table 'HikeBookings'
ALTER TABLE [dbo].[HikeBookings]
ADD CONSTRAINT [FK_AspNetUserHikeBooking]
    FOREIGN KEY ([AspNetUserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserHikeBooking'
CREATE INDEX [IX_FK_AspNetUserHikeBooking]
ON [dbo].[HikeBookings]
    ([AspNetUserId]);
GO

-- Creating foreign key on [HikingId] in table 'HikeRatings'
ALTER TABLE [dbo].[HikeRatings]
ADD CONSTRAINT [FK_HikeRatingHiking]
    FOREIGN KEY ([HikingId])
    REFERENCES [dbo].[Hikings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HikeRatingHiking'
CREATE INDEX [IX_FK_HikeRatingHiking]
ON [dbo].[HikeRatings]
    ([HikingId]);
GO

-- Creating foreign key on [HikingId] in table 'HikeBookings'
ALTER TABLE [dbo].[HikeBookings]
ADD CONSTRAINT [FK_HikeBookingHiking]
    FOREIGN KEY ([HikingId])
    REFERENCES [dbo].[Hikings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HikeBookingHiking'
CREATE INDEX [IX_FK_HikeBookingHiking]
ON [dbo].[HikeBookings]
    ([HikingId]);
GO

-- Creating foreign key on [AspNetUserId] in table 'HikeRatings'
ALTER TABLE [dbo].[HikeRatings]
ADD CONSTRAINT [FK_AspNetUserHikeRating]
    FOREIGN KEY ([AspNetUserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserHikeRating'
CREATE INDEX [IX_FK_AspNetUserHikeRating]
ON [dbo].[HikeRatings]
    ([AspNetUserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
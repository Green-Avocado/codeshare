CREATE TABLE [dbo].[Project] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (100)  NOT NULL,
    [QuickDescription] NVARCHAR (140)  NOT NULL,
    [Description]      NVARCHAR (MAX)  NULL,
    [LogoUrl]          NVARCHAR (2083) NULL,
    [SourceUrl]        NVARCHAR (2083) NULL,
    [CreationDate]     DATETIME        NOT NULL,
    [User_Id]          INT             NULL,
    [User_Id1]         INT             NULL,
    [User_Id2]         INT             NULL,
    [User_Id3]         INT             NULL,
    [Creator_Id]       INT             NULL,
    CONSTRAINT [PK_dbo.Project] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Project_dbo.ProjectUser_Creator_Id] FOREIGN KEY ([Creator_Id]) REFERENCES [dbo].[ProjectUser] ([Id]),
    CONSTRAINT [FK_dbo.Project_dbo.User_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_dbo.Project_dbo.User_User_Id1] FOREIGN KEY ([User_Id1]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_dbo.Project_dbo.User_User_Id2] FOREIGN KEY ([User_Id2]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_dbo.Project_dbo.User_User_Id3] FOREIGN KEY ([User_Id3]) REFERENCES [dbo].[User] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_User_Id]
    ON [dbo].[Project]([User_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_User_Id1]
    ON [dbo].[Project]([User_Id1] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_User_Id2]
    ON [dbo].[Project]([User_Id2] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_User_Id3]
    ON [dbo].[Project]([User_Id3] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Creator_Id]
    ON [dbo].[Project]([Creator_Id] ASC);


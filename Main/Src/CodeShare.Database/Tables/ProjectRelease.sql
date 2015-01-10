CREATE TABLE [dbo].[ProjectRelease] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (100) NOT NULL,
    [CreationDate]   DATETIME       NOT NULL,
    [Description]    NVARCHAR (MAX) NULL,
    [DownloadCount]  INT            NOT NULL,
    [ReleaseFile_Id] INT            NULL,
    [Project_Id]     INT            NULL,
    CONSTRAINT [PK_dbo.ProjectRelease] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ProjectRelease_dbo.Project_Project_Id] FOREIGN KEY ([Project_Id]) REFERENCES [dbo].[Project] ([Id]),
    CONSTRAINT [FK_dbo.ProjectRelease_dbo.ProjectFile_ReleaseFile_Id] FOREIGN KEY ([ReleaseFile_Id]) REFERENCES [dbo].[ProjectFile] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ReleaseFile_Id]
    ON [dbo].[ProjectRelease]([ReleaseFile_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Project_Id]
    ON [dbo].[ProjectRelease]([Project_Id] ASC);


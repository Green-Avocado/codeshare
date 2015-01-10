CREATE TABLE [dbo].[ProjectFile] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (255)  NOT NULL,
    [Url]               NVARCHAR (2083) NOT NULL,
    [ProjectRelease_Id] INT             NULL,
    CONSTRAINT [PK_dbo.ProjectFile] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ProjectFile_dbo.ProjectRelease_ProjectRelease_Id] FOREIGN KEY ([ProjectRelease_Id]) REFERENCES [dbo].[ProjectRelease] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectRelease_Id]
    ON [dbo].[ProjectFile]([ProjectRelease_Id] ASC);


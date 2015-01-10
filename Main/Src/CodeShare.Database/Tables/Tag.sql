CREATE TABLE [dbo].[Tag] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (20) NOT NULL,
    [ProjectOpening_Id] INT           NULL,
    [Project_Id]        INT           NULL,
    CONSTRAINT [PK_dbo.Tag] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Tag_dbo.Project_Project_Id] FOREIGN KEY ([Project_Id]) REFERENCES [dbo].[Project] ([Id]),
    CONSTRAINT [FK_dbo.Tag_dbo.ProjectOpening_ProjectOpening_Id] FOREIGN KEY ([ProjectOpening_Id]) REFERENCES [dbo].[ProjectOpening] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectOpening_Id]
    ON [dbo].[Tag]([ProjectOpening_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Project_Id]
    ON [dbo].[Tag]([Project_Id] ASC);


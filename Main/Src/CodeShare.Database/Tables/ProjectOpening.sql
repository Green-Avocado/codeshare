CREATE TABLE [dbo].[ProjectOpening] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Title]        NVARCHAR (100) NOT NULL,
    [Description]  NVARCHAR (MAX) NOT NULL,
    [CreationDate] DATETIME       NOT NULL,
    [Project_Id]   INT            NULL,
    CONSTRAINT [PK_dbo.ProjectOpening] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ProjectOpening_dbo.Project_Project_Id] FOREIGN KEY ([Project_Id]) REFERENCES [dbo].[Project] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Project_Id]
    ON [dbo].[ProjectOpening]([Project_Id] ASC);


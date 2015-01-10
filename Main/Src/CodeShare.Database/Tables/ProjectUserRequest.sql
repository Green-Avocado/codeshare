CREATE TABLE [dbo].[ProjectUserRequest] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [Message]           NVARCHAR (140) NOT NULL,
    [User_Id]           INT            NULL,
    [Project_Id]        INT            NULL,
    [RelatedOpening_Id] INT            NULL,
    CONSTRAINT [PK_dbo.ProjectUserRequest] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ProjectUserRequest_dbo.Project_Project_Id] FOREIGN KEY ([Project_Id]) REFERENCES [dbo].[Project] ([Id]),
    CONSTRAINT [FK_dbo.ProjectUserRequest_dbo.ProjectOpening_RelatedOpening_Id] FOREIGN KEY ([RelatedOpening_Id]) REFERENCES [dbo].[ProjectOpening] ([Id]),
    CONSTRAINT [FK_dbo.ProjectUserRequest_dbo.User_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[User] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_User_Id]
    ON [dbo].[ProjectUserRequest]([User_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Project_Id]
    ON [dbo].[ProjectUserRequest]([Project_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RelatedOpening_Id]
    ON [dbo].[ProjectUserRequest]([RelatedOpening_Id] ASC);


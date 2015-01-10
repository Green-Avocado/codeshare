CREATE TABLE [dbo].[ProjectUser] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [IsActive]   BIT      NOT NULL,
    [JoinDate]   DATETIME NOT NULL,
    [Role]       INT      NOT NULL,
    [User_Id]    INT      NULL,
    [Project_Id] INT      NULL,
    CONSTRAINT [PK_dbo.ProjectUser] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ProjectUser_dbo.Project_Project_Id] FOREIGN KEY ([Project_Id]) REFERENCES [dbo].[Project] ([Id]),
    CONSTRAINT [FK_dbo.ProjectUser_dbo.User_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[User] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_User_Id]
    ON [dbo].[ProjectUser]([User_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Project_Id]
    ON [dbo].[ProjectUser]([Project_Id] ASC);


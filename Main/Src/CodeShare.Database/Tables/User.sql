CREATE TABLE [dbo].[User] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [UserName]    NVARCHAR (100)  NOT NULL,
    [NickName]    NVARCHAR (100)  NULL,
    [AvatarUrl]   NVARCHAR (2083) NULL,
    [JoinDate]    DATETIME        NOT NULL,
    [Project_Id]  INT             NULL,
    [Project_Id1] INT             NULL,
    CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.User_dbo.Project_Project_Id] FOREIGN KEY ([Project_Id]) REFERENCES [dbo].[Project] ([Id]),
    CONSTRAINT [FK_dbo.User_dbo.Project_Project_Id1] FOREIGN KEY ([Project_Id1]) REFERENCES [dbo].[Project] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Project_Id]
    ON [dbo].[User]([Project_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Project_Id1]
    ON [dbo].[User]([Project_Id1] ASC);


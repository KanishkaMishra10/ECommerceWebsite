CREATE TABLE [dbo].[Role] (
    [role_id]   INT           IDENTITY (1, 1) NOT NULL,
    [role_name] NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([role_id] ASC)
);


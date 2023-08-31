CREATE TABLE [dbo].[User] (
    [user_id]       INT            IDENTITY (1, 1) NOT NULL,
    [first_name]    NVARCHAR (50)  NOT NULL,
    [last_name]     NVARCHAR (50)  NOT NULL,
    [email]         NVARCHAR (100) NOT NULL,
    [password_hash] NVARCHAR (100) NOT NULL,
    [role_id]       INT            NOT NULL,
    [address_id]    INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([user_id] ASC),
    FOREIGN KEY ([address_id]) REFERENCES [dbo].[User_Address] ([address_id]),
    FOREIGN KEY ([role_id]) REFERENCES [dbo].[Role] ([role_id])
);


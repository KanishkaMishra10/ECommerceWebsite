CREATE TABLE [dbo].[Cart] (
    [cart_id]    INT IDENTITY (1, 1) NOT NULL,
    [product_id] INT NOT NULL,
    [user_id]    INT NOT NULL,
    [quantity]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([cart_id] ASC),
    FOREIGN KEY ([product_id]) REFERENCES [dbo].[Product] ([product_id]),
    FOREIGN KEY ([user_id]) REFERENCES [dbo].[User] ([user_id])
);


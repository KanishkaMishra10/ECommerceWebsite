CREATE TABLE [dbo].[OrderItem] (
    [order_item_id] INT IDENTITY (1, 1) NOT NULL,
    [order_id]      INT NOT NULL,
    [quantity]      INT NOT NULL,
    [product_id]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([order_item_id] ASC),
    FOREIGN KEY ([order_id]) REFERENCES [dbo].[Order] ([order_id]),
    FOREIGN KEY ([product_id]) REFERENCES [dbo].[Product] ([product_id])
);


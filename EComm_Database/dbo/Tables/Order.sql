CREATE TABLE [dbo].[Order] (
    [order_id]      INT             IDENTITY (1, 1) NOT NULL,
    [user_id]       INT             NOT NULL,
    [order_date]    DATE            NOT NULL,
    [total_amount]  DECIMAL (10, 2) NOT NULL,
    [oder_status]   NVARCHAR (50)   NOT NULL,
    [delivery_date] DATETIME        NULL,
    [product_id]    INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([order_id] ASC),
    FOREIGN KEY ([product_id]) REFERENCES [dbo].[Product] ([product_id]),
    FOREIGN KEY ([user_id]) REFERENCES [dbo].[User] ([user_id])
);


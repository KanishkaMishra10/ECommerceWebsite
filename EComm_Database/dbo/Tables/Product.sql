CREATE TABLE [dbo].[Product] (
    [product_id]     INT            IDENTITY (1, 1) NOT NULL,
    [product_name]   INT            NOT NULL,
    [category_id]    INT            NOT NULL,
    [stock_quantity] INT            NOT NULL,
    [user_id]        INT            NOT NULL,
    [discount]       INT            NOT NULL,
    [price]          DECIMAL (18)   NOT NULL,
    [color]          NVARCHAR (20)  NOT NULL,
    [description]    NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([product_id] ASC),
    FOREIGN KEY ([category_id]) REFERENCES [dbo].[Category] ([category_id]),
    FOREIGN KEY ([user_id]) REFERENCES [dbo].[User] ([user_id])
);


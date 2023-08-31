CREATE TABLE [dbo].[User_Address] (
    [address_id]   INT            IDENTITY (1, 1) NOT NULL,
    [address_desc] NVARCHAR (255) NOT NULL,
    [add_state]    NVARCHAR (50)  NOT NULL,
    [city]         NVARCHAR (50)  NOT NULL,
    [pincode]      INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([address_id] ASC)
);


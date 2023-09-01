USE EComm;

CREATE TABLE [Role] (
    role_id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    role_name NVARCHAR(20) NOT NULL
);

CREATE TABLE Category (
    category_id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    category_name NVARCHAR(255) NOT NULL
);

CREATE TABLE User_Address (
    address_id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    address_desc NVARCHAR(255) NOT NULL,
	add_state NVARCHAR(50) NOT NULL,
	city NVARCHAR (50) NOT NULL,
	pincode INT NOT NULL
);

CREATE TABLE [User] (
    user_id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    first_name NVARCHAR(50) NOT NULL,
    last_name NVARCHAR(50) NOT NULL,
    email NVARCHAR(100) NOT NULL,
    password_hash NVARCHAR(100) NOT NULL,
	role_id INT NOT NULL,
	address_id INT NOT NULL,
	FOREIGN KEY (role_id) REFERENCES [Role](role_id),
	FOREIGN KEY (address_id) REFERENCES [User_Address](address_id)
);

CREATE TABLE [Product] (
    product_id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	product_name INT NOT NULL,
	category_id INT NOT NULL,
	stock_quantity INT NOT NULL,
    user_id INT NOT NULL,
	discount INT NOT NULL,
	price DECIMAL NOT NULL,
	color NVARCHAR(20) NOT NULL,
	[description] NVARCHAR(100) NOT NULL,
	FOREIGN KEY (user_id) REFERENCES [User](user_id),
	FOREIGN KEY (category_id) REFERENCES [Category](category_id)
);

CREATE TABLE [Order] (
    order_id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	user_id INT NOT NULL,
	order_date DATE NOT NULL,
    total_amount DECIMAL(10, 2) NOT NULL,
	oder_status NVARCHAR(50) NOT NULL,
	delivery_date DATETIME,
	product_id INT NOT NULL,
	FOREIGN KEY (user_id) REFERENCES [User](user_id),
	FOREIGN KEY (product_id) REFERENCES [Product](product_id)
);

CREATE TABLE Cart (
    cart_id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    product_id INT NOT NULL,
	user_id INT NOT NULL,
	quantity INT NOT NULL,
	FOREIGN KEY (product_id) REFERENCES [Product](product_id),
	FOREIGN KEY (user_id) REFERENCES [User](user_id)
);


CREATE TABLE OrderItem (
	order_item_id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	order_id INT NOT NULL,
	quantity INT NOT NULL,
	product_id INT NOT NULL,
	FOREIGN KEY (order_id) REFERENCES [Order](order_id),
	FOREIGN KEY (product_id) REFERENCES [Product](product_id)
);

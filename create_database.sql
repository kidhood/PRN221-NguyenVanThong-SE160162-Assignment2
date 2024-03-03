CREATE DATABASE InventoryManagement
GO
USE InventoryManagement
GO
CREATE TABLE account (
	id INT PRIMARY KEY IDENTITY,
	name NVARCHAR(256),
	"user_name" VARCHAR(30),
	password VARCHAR (100),
	role INT
)

CREATE TABLE supplier (
	id INT PRIMARY KEY IDENTITY,
	name NVARCHAR(256),
	phone VARCHAR(11),
	email VARCHAR(100),
	address NVARCHAR(256),
	is_delete bit
)

CREATE TABLE product (
	id INT PRIMARY KEY IDENTITY,
	name NVARCHAR(256),
	image_path VARCHAR(256),
	quantity INT DEFAULT 0,
	description NVARCHAR (256),
	price FLOAT,
	is_delete bit, 
	supplier_id INT
	CONSTRAINT FK_suppler FOREIGN KEY (supplier_id) REFERENCES  supplier (id)
)

CREATE TABLE "order" (
	id INT PRIMARY KEY IDENTITY,
	total_cost FLOAT DEFAULT 0,
	order_date DATETIME,
	account_id INT,
	CONSTRAINT FK_account FOREIGN KEY (account_id) REFERENCES  account (id)
)

CREATE TABLE order_detail (
	id INT PRIMARY KEY IDENTITY,
	quantiy INT DEFAULT 0,
	price float,
	product_id INT,
	order_id INT
	CONSTRAINT FK_order FOREIGN KEY (order_id) REFERENCES  "order" (id),
	CONSTRAINT FK_product FOREIGN KEY (product_id) REFERENCES  product (id),
)
      
      
    INSERT INTO account (name,user_name,password,[role]) VALUES
	 (N'Van Thong Staff',N'thongstaff',N'12345',1),
	 (N'Van Thong Manager',N'thongmanager',N'12345',2),
	 (N'Van Thong Admin',N'thongadmin',N'12345',3);

	INSERT INTO supplier (name,phone,email,address,is_delete) VALUES
	 (N'Coca company',N'0303030303',N'coca@gmail.com',N'1751 Palmer Road',0),
	 (N'Pepsi1',N'012345567',N'hehe@gmai.com',N'hihi, traidat',NULL),
	 (N'Mirinda',N'0123456578',N'hahaha',N'awd.asd..asd',1),
	 (N'book company',N'012345678',N'test@gmai.com',N'lvv/thuduc',0),
	 (N'new company',N'0123456789',N'test@gmail.com',N'123 le van viet. thu duc',0),
	 (N'hehe',N'123',N'123',N'123',1),
	 (N'bi dao company',N'0123456789',N'test@gmail.com',N'le van viet, thu duc',0);

INSERT INTO InventoryManagement.dbo.product (name,image_path,quantity,description,price,is_delete,supplier_id) VALUES
	 (N'Coca',N'/images/coca.jpg',151,N'Refreshing Coca Cole',1.99,1,1),
	 (N'Snack - new',N'/images/product/snack.jpg',10,N'Delicious Snack',3.0,0,NULL),
	 (N'Chips',N'/images/product/chip.jpg',87,N'Crunchy Potato Chips',4.0,0,NULL),
	 (N'Soda',N'/images/product/soda.jpg',1,N'Fizzy Soda',0.99,0,NULL),
	 (N'Chocolate',N'/images/product/kitkat.jpg',1,N'Smooth Milk Chocolate',4.99,0,NULL),
	 (N'Cookies',N'/images/product/cooki.jpg',150,N'Homemade Cookies',2.99,0,NULL),
	 (N'Juice',N'/images/product/juice.jpg',178,N'Fresh Fruit Juice',1.49,0,NULL),
	 (N'Water',N'/images/product/water.jpg',250,N'Bottled Water',0.75,0,NULL),
	 (N'Popcorn',N'/images/product/popcorn.jpg',120,N'Buttered Popcorn',2.29,0,NULL),
	 (N'Energy Drink',N'/images/product/energy.jpg',100,N'High-Energy Drink',3.49,0,NULL);
INSERT INTO InventoryManagement.dbo.product (name,image_path,quantity,description,price,is_delete,supplier_id) VALUES
	 (N'Pepsi',N'/images/product/pepsi.jpg',12,N'Here is drink',123.0,0,NULL),
	 (NULL,NULL,NULL,NULL,NULL,1,NULL),
	 (N'Snack',N'/images/product/snack.jpg',200,N'Delicious Snack',2.49,0,NULL),
	 (NULL,NULL,NULL,NULL,NULL,1,NULL),
	 (NULL,NULL,NULL,NULL,NULL,1,NULL),
	 (NULL,NULL,NULL,NULL,NULL,1,NULL),
	 (NULL,NULL,NULL,NULL,NULL,1,NULL),
	 (N'new product',N'urk/image',1,N'this is new product',1.0,1,3),
	 (NULL,NULL,NULL,NULL,NULL,1,NULL),
	 (NULL,NULL,NULL,NULL,NULL,1,NULL);

	
	INSERT INTO [order] (total_cost,order_date,account_id) VALUES
	 (8.98,'2024-02-17 18:51:05.620',1),
	 (7.98,'2024-02-17 18:53:27.917',1),
	 (6.99,'2024-02-17 18:54:22.027',1),
	 (3.0,'2024-02-18 22:43:40.080',1),
	 (24.0,'2024-02-18 22:50:58.977',1),
	 (1.98,'2024-02-18 22:51:42.003',1),
	 (8.0,'2024-02-18 22:52:31.993',1),
	 (9.98,'2024-02-18 22:52:42.387',1),
	 (8.0,'2024-02-18 22:53:44.460',1),
	 (0.99,'2024-02-18 22:53:56.050',1);
INSERT INTO [order] (total_cost,order_date,account_id) VALUES
	 (12.0,'2024-02-18 22:55:31.187',1),
	 (7.96,'2024-02-18 22:57:17.593',1),
	 (1.98,'2024-02-18 22:58:59.507',1),
	 (10.97,'2024-02-18 23:54:53.697',1),
	 (5.98,'2024-02-19 00:17:49.527',1),
	 (2.98,'2024-02-19 00:20:22.840',1);

	INSERT INTO order_detail (quantiy,product_id,order_id,price) VALUES
	 (1,3,1,1.99),
	 (1,4,1,3.0),
	 (1,5,1,3.99),
	 (1,4,2,3.0),
	 (1,5,2,3.99),
	 (1,6,2,0.99),
	 (1,5,3,3.99),
	 (1,4,3,3.0),
	 (1,4,4,3.0),
	 (6,5,5,4.0);
INSERT INTO order_detail (quantiy,product_id,order_id,price) VALUES
	 (2,6,6,0.99),
	 (2,5,7,4.0),
	 (2,7,8,4.99),
	 (2,5,9,4.0),
	 (1,6,10,0.99),
	 (3,5,11,4.0),
	 (3,6,12,0.99),
	 (1,7,12,4.99),
	 (2,6,13,0.99),
	 (1,6,14,0.99);
INSERT INTO order_detail (quantiy,product_id,order_id,price) VALUES
	 (2,7,14,4.99),
	 (1,6,15,0.99),
	 (1,7,15,4.99),
	 (2,9,16,1.49);



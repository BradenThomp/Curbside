CREATE TABLE product
(
	id UUID PRIMARY KEY NOT NULL,
	external_id VARCHAR (50) NOT NULL,
	product_name VARCHAR (50) NOT NULL,
	price DECIMAL NOT NULL
);

INSERT INTO product(id, external_id, product_name, price) Values
('1d07911d-bd58-461e-a420-3acf422c22fb', '1234', 'Boat', 12.00);
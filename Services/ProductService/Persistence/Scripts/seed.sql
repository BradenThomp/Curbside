connect productservicedb

CREATE TABLE product
(
 id UNIQUEIDENTIFIER PRIMARY KEY,
 system_id VARCHAR (50) NOT NULL,
 product_name VARCHAR (50) NOT NULL,
 price DECIMAL NOT NULL,
);
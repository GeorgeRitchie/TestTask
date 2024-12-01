-- Create the database
CREATE DATABASE ProductCategoryDB;
GO

-- Use the newly created database
USE ProductCategoryDB;
GO

-- Create the Categories table
CREATE TABLE Categories (
    CategoryID INT IDENTITY PRIMARY KEY,
    CategoryName NVARCHAR(255) NOT NULL
);

-- Create the Products table
CREATE TABLE Products (
    ProductID INT IDENTITY PRIMARY KEY,
    ProductName NVARCHAR(255) NOT NULL
);

-- Create the ProductCategories junction table for many-to-many relationship
CREATE TABLE ProductCategories (
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID),
    CategoryID INT NOT NULL FOREIGN KEY REFERENCES Categories(CategoryID),
    PRIMARY KEY (ProductID, CategoryID)
);

-- Insert sample data into Categories
INSERT INTO Categories (CategoryName)
VALUES
    ('Electronics'),
    ('Books'),
    ('Clothing'),
    ('Home & Kitchen');

-- Insert sample data into Products
INSERT INTO Products (ProductName)
VALUES
    ('Laptop'),
    ('Smartphone'),
    ('T-Shirt'),
    ('Cookware Set'),
    ('Wireless Mouse');

-- Insert sample data into ProductCategories
INSERT INTO ProductCategories (ProductID, CategoryID)
VALUES
    (1, 1), -- Laptop -> Electronics
    (2, 1), -- Smartphone -> Electronics
    (3, 3), -- T-Shirt -> Clothing
    (4, 4), -- Cookware Set -> Home & Kitchen
    (5, 1), -- Wireless Mouse -> Electronics
    (5, 4); -- Wireless Mouse -> Home & Kitchen
GO

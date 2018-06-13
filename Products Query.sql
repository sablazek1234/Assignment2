DROP DATABASE IF EXISTS Products;
CREATE DATABASE Products;
USE Products;

DELIMITER //

DROP PROCEDURE IF EXISTS makeProductsDatabase //
CREATE PROCEDURE makeProductsDatabase()
BEGIN

	CREATE TABLE tblCategory (
    CategoryID INTEGER AUTO_INCREMENT NOT NULL,
    Category VARCHAR (50) NOT NULL,
    Description VARCHAR (255) NOT NULL,
    PRIMARY KEY (CategoryID)
    );

	CREATE TABLE tblProduct (
    ProductID INTEGER AUTO_INCREMENT NOT NULL,
    CategoryID INTEGER NOT NULL,
    ProductName VARCHAR (50) NOT NULL,
    Origin BIT NOT NULL,
    ProductCondition VARCHAR (1) NOT NULL,
    Brand VARCHAR (50) NOT NULL,
    Quantity INTEGER (4) NOT NULL,
    PRIMARY KEY (ProductID),
    FOREIGN KEY (CategoryID) References tblCategory(CategoryID)
    );
    
    CREATE TABLE tblOrderDetails (
    OrderID INTEGER AUTO_INCREMENT NOT NULL,
    ProductID INTEGER NOT NULL,
    CustomerName VARCHAR (50) NOT NULL,
    CustomerPhone VARCHAR (20) NOT NULL,
    DateOfPurchase DATETIME NOT NULL,
    Price FLOAT NOT NULL,
    Quantity INTEGER (4) NOT NULL,
    PRIMARY KEY (OrderID),
    FOREIGN KEY (ProductID) References tblProduct(ProductID)
    );

END //

DELIMITER ;
CALL makeProductsDatabase();

DELIMITER //
CREATE PROCEDURE Category()
BEGIN
  INSERT INTO tblCategory VALUES(1,"Silverware", "A wide range of silverware from forks, spoons, plates, and kitchen knifes.");
  INSERT INTO tblCategory VALUES(2,"Cutting boards", "Different shapes and sizes of wood and plastic cutting boards.");
  INSERT INTO tblCategory VALUES(3,"Fridges", "Fridges that are perfect for keeping your food fresh.");
  INSERT INTO tblCategory VALUES(4,"Washing/Drying Machines", "We have the best washing and drying machines to make your clothes sparkle.");
  INSERT INTO tblCategory VALUES(5,"Toasters","Whether it's bread or pop-tarts, these toasters will heat them up to the perfect temperature.");
  INSERT INTO tblCategory VALUES(6,"Fans","Too hot in your house? No problem! We got all kinds of fans to keep you cool.");
     
END//

DELIMITER //
CREATE PROCEDURE Products()
BEGIN
  INSERT INTO tblProduct VALUES(1,2,"Bamboo Cutting Board",0,"N","N/A",10);
  INSERT INTO tblProduct VALUES(2,5,"Pop-up Toaster",1,"U","Breville",4);
  INSERT INTO tblProduct VALUES(3,6,"Ceiling Fan",1,"N","Emerson",1);
  INSERT INTO tblProduct VALUES(4,1,"Kitchen Knife Set",0,"D","Global",5);
  INSERT INTO tblProduct VALUES(5,4,"Washing Machine",1,"N","Panasonic",8);
  INSERT INTO tblProduct VALUES(6,3,"Mini-Fridge",0,"U","Haier",6);
     
END//

CALL Category();//
CALL Products();

/*
DELIMITER //
CREATE PROCEDURE OrderDetails()
BEGIN
  INSERT INTO tblOrderDetails VALUES(1,);
  INSERT INTO tblOrderDetails VALUES(2,);
  INSERT INTO tblOrderDetails VALUES(3,);
  INSERT INTO tblOrderDetails VALUES(4,);
  INSERT INTO tblOrderDetails VALUES(5,);
  INSERT INTO tblOrderDetails VALUES(6,);
     

END//

CALL OrderDetails();
*/
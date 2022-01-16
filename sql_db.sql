USE AUTOSHOP
GO

CREATE TABLE Car(
	id BIGINT PRIMARY KEY NOT NULL,
	name NVARCHAR(64) NOT NULL,
	shortDescription NVARCHAR(128) NOT NULL,
	longDescription text NOT NULL,
	price MONEY NOT NULL,
	category_id BIGINT REFERENCES CarCategory(id)
	);

CREATE TABLE CarCategory(
	id BIGINT PRIMARY KEY NOT NULL,
	name NVARCHAR(64) NOT NULL,
	description NVARCHAR(64) NOT NULL
);

INSERT INTO CarCategory(id,name,description) VALUES(1, 'Electric','from ppl to world with love')
GO
INSERT INTO CarCategory(id,name,description) VALUES(2, 'Diesel','poor for world')
GO
INSERT INTO CarCategory(id,name,description) VALUES(3, 'Straight ','from ppl to world with love')
GO

INSERT INTO Car(id,name,shortDescription,longDescription,price,category_id)
	VALUES(3,'Lamborgini Diablo','very exclusive car','long description about exclusive car',220000.200,3)


	SELECT * FROM Car;



INSERT INTO Car(id,name,shortDescription,longDescription,price,category_id)
	VALUES(4,'Porcshe 911','expensive car','911 powers',70000.900,3)

INSERT INTO Car(id,name,shortDescription,longDescription,price,category_id)
	VALUES(5,'Ford Taurus','Big car','Big toy for big man',10000.200,2)


SELECT * FROM Car;

SELECT * FROM Car catTable LEFT JOIN CarCategory carCategoryTable ON catTable.category_id = carCategoryTable.id;

CREATE PROCEDURE testProcedure
AS
	SET NOCOUNT ON
	SELECT * FROM Car
	RETURN
GO

EXECUTE testProcedure
GO

CREATE PROCEDURE testProcedure1
	@CarName NVARCHAR(64)
AS
	SET NOCOUNT ON
	SELECT * FROM Car
	WHERE name = @CarName
GO

DROP PROCEDURE testProcedure1
GO

EXECUTE testProcedure1 @CarName = 'Honda Accord'
GO

SELECT * FROM Car
GO

SET NOCOUNT ON
SELECT * FROM Car catTable LEFT JOIN CarCategory carCategoryTable ON catTable.category_id = carCategoryTable.id;
GO

CREATE PROCEDURE Sales.uspGetEmployeeSalesYTD  
    @SalesPerson nvarchar(50),  
    @SalesYTD money OUTPUT  
AS    
  
    SET NOCOUNT ON;

    SELECT @SalesYTD = SalesYTD  
    FROM Sales.SalesPerson AS sp  
    JOIN HumanResources.vEmployee AS e ON e.BusinessEntityID = sp.BusinessEntityID  
    WHERE LastName = @SalesPerson;

    RETURN;
GO 

CREATE PROCEDURE GetCarsWithPriceInterval
	@PriceFrom real,
	@PriceTo real
AS
	SET NOCOUNT ON;
	SELECT * FROM Car carTable
	WHERE carTable.price BETWEEN @PriceFrom and @PriceTo
	ORDER BY carTable.price

	RETURN;
GO

EXECUTE GetCarsWithPriceInterval @PriceFrom = 0, @PriceTo = 0;
GO

SELECT * FROM Car
GO

CREATE TABLE CarTEST(
	id BIGINT PRIMARY KEY NOT NULL,
	price MONEY NOT NULL)
GO

INSERT INTO CarTEST(id,price) VALUES (6,6554.312332)
GO

SELECT * FROM CarTEST
GO

SELECT * FROM carTEST 
WHERE CarTEST.price BETWEEN 100 and 10000000
GO
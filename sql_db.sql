USE AUTOSHOP
GO

CREATE TABLE Car(
	id BIGINT PRIMARY KEY NOT NULL,
	name NVARCHAR(64) NOT NULL,
	shortDescription NVARCHAR(128) NOT NULL,
	longDescription text NOT NULL,
	price float(3) NOT NULL,
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


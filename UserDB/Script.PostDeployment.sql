IF not exists (SELECT 1 FROM dbo.[User])
BEGIN
	INSERT INTO dbo.[User] (FirstName, LastName) 
	VALUES 
	('Víctor', 'Marri'),
	('Sue', 'Storm'), 
	('Reed','Richards'), 
	('Steve','Rogers');
END
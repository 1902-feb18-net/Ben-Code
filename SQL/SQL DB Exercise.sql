--CREATE SCHEMA DBExercise

GO
CREATE TABLE DBExercise.Employee (
	ID INT NOT NULL PRIMARY KEY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	SSN VARCHAR(11) NOT NULL UNIQUE,
	DepartmentID INT
)
GO

CREATE TABLE DBExercise.Department (
	ID INT NOT NULL ,
	--CONSTRAINT FK_Department_ID FOREIGN KEY(ID) REFERENCES Employee(DepartmentID),
	Name NVARCHAR(100) NOT NULL,
	Location NVARCHAR(100) NOT NULL

)

ALTER TABLE DBExercise.Employee ADD
	CONSTRAINT FK_Department_ID FOREIGN KEY(DepartmentID) REFERENCES DBExercise.Department(ID)

ALTER TABLE DBExercise.Department ADD
	CONSTRAINT PK_Department_ID PRIMARY KEY(ID)

ALTER TABLE DBExercise.EmpDetails ADD
	CONSTRAINT FK_Employee_ID FOREIGN KEY(EmployeeID) REFERENCES DBExercise.Employee(ID)

CREATE TABLE DBExercise.EmpDetails (
	EmployeeID INT NOT NULL UNIQUE,
	--CONSTRAINT FK_Employee_ID FOREIGN KEY(EmployeeID) REFERENCES Employee(ID),
	Salary INT NOT NULL,
	Address1 NVARCHAR(100),
	Address2 NVARCHAR(100),
	City NVARCHAR(100),
	State NVARCHAR(20),
	Country NVARCHAR(20)	
)

DROP TABLE DBExercise.EmpDetails

INSERT INTO DBExercise.Employee(ID, FirstName, LastName, SSN, DepartmentID) VALUES (1, 'Ben', 'Mages', '123-45-6789', 1)
INSERT INTO DBExercise.Employee(ID, FirstName, LastName, SSN, DepartmentID) VALUES (2, 'Allie', 'Mages', '234-56-6789', 3)
INSERT INTO DBExercise.Employee(ID, FirstName, LastName, SSN, DepartmentID) VALUES (3, 'Ruth', 'Noel', '333-44-5555', 2)

INSERT INTO DBExercise.Employee(ID, FirstName, LastName, SSN, DepartmentID) VALUES (4, 'Tina', 'Smith', '666-44-7777', 4)


INSERT INTO DBExercise.EmpDetails(EmployeeID, Salary, Address1, Address2, City, State, Country) VALUES
	(1, 60000, '214 MeSt', NULL, 'San Fransisco', 'CA', 'USA')

INSERT INTO DBExercise.EmpDetails(EmployeeID, Salary, Address1, Address2, City, State, Country) VALUES
	(2, 60000, '345 HipSt', NULL, 'Las Vegas', 'NV', 'USA')

INSERT INTO DBExercise.EmpDetails(EmployeeID, Salary, Address1, Address2, City, State, Country) VALUES
	(3, 60000, '214 MeSt', NULL, 'Las Vegas', 'NV', 'USA')

SELECT * FROM  DBExercise.Employee

SELECT * FROM  DBExercise.EmpDetails

INSERT INTO DBExercise.Department(ID, Name, Location) VALUES (1, 'Computing', 'Las Vegas')

INSERT INTO DBExercise.Department(ID, Name, Location) VALUES (2, 'Accounting', 'Las Vegas')

INSERT INTO DBExercise.Department(ID, Name, Location) VALUES (3, 'Sanitation', 'San Fransisco')

INSERT INTO DBExercise.Department(ID, Name, Location) VALUES (4, 'Marketing', 'San Fransisco')
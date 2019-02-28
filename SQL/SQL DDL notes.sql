-- DDL

-- DATA DEFINITION LANGUAGE

-- DDL operates on whole tables at a time, can't see individual rows
-- DDL also works with lots of other DB objects,  lke views, functions, procedures
--	trigger, constraints, etc.

-- To create, change, and delete these DB objects, we have:
-- CREATE, ALTER, DROP

-- GO is a special keyword to separate batches of commands
-- some commands demand to be in their own batch

CREATE SCHEMA Movie;
GO

-- CREATE TABLE:

-- CREATE TABLE get comma-separated list of columns
-- each column has name and data type
CREATE TABLE Movie.Movie(
	MovieId INT
)

SELECT * FROM Movie.Movie

-- we have ALTER TABLE to add or delete columns
--	(can also do other things)

ALTER TABLE Movie.Movie ADD 
	Title NVARCHAR(200);

-- delete an entire table
DROP TABLE Movie.Movie

-- we can specify restraints on each column

-- constraints:
--	NOT NULL
--	NULL (not really a constraint, just being explicit)
--		(default behavior)
--	PRIMARY KEY (sets PK, enforces uniqeness, sets a clustered index)
--		(implies NOT NULL, but we like to be explicit anyways)
--	UNIQUE (throw error if there's a duplicate, can be set on 
--		multiple columns taken together)
--	CHECk (an arbitrary condition that must be true for each row)
--	DEFAULT (give a default value for that column when inserted
--		without an explicit value) NULL is the default DEFAULT
--	FOREIGN KEY
--	IDENTITY (start, increment)(not exactly a constraint,  but similar!)
--		IDENTITY(10, 10) would count: 10, 20, 30, 40, etc.
--		default values are 1, 1 (count: 1, 2, 3, 4, etc.)
--	by default,  we aren't allowed to give explicit values for IDENTITY columns
--		you'd need to turn on IDENTITY_INSERT option

CREATE TABLE Movie.Movie (
	MovieId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Title NVARCHAR(200) NOT NULL,
	ReleaseDate DATETIME2 NOT NULL,
	DateModified DATETIME2 NOT NULL DEFAULT(GETDATE()),
	CONSTRAINT U_Movie_Title_Date UNIQUE (Title, ReleaseDate),
	CONSTRAINT CHK_DateNotTooEarly CHECK (ReleaseDate > '1900')

	-- CONSTRAINT PK_blah PRIMARY KEY (col1, col2) -- (composite PK)
)

INSERT INTO  Movie.Movie (Title, ReleaseDate)
VALUES ('LOTR: The Fellowship of the Ring', '2002'
);

DROP TABLE Movie.Genre

CREATE TABLE Movie.Genre (
	 GenreID INT NOT NULL PRIMARY KEY,
	 Name NVARCHAR(100) NOT NULL,
	 DateModified DATETIME2 DEFAULT(GETDATE()),
	 CHECK (Name != ' ')
)

SELECT * FROM Movie.Genre

ALTER TABLE Movie.Movie ADD
	GenreID INT NULL,
	CONSTRAINT FK_MOVIE_GENRE FOREIGN KEY(GenreID) REFERENCES Genre(GenreID);

-- Adding columns without some default (or allowing null as default) is not allowed
-- Workaround: allow NULL at first, fix up the existing rows, then add NOT NULL constraint

INSERT INTO Movie.Genre (Name) VALUES ('Action/Adventure')

UPDATE Movie.Movie SET GenreID = 1;

DELETE FROM Movie.Genre

ALTER TABLE Movie.Movie 
	ALTER COLUMN GenreID INT NOT NULL

-- computer columns
ALTER TABLE Movie.Movie ADD
	FullName AS (Title + ' ('+ CONVERT(NVARCHAR, YEAR(ReleaseDate)) + ')')

ALTER TABLE Movie.Movie DROP COLUMN FullName

SELECT * FROM Movie.Movie
-- computed columns have different  options like PERSISTED

-- views
GO
CREATE VIEW Movie.NewReleases AS
	SELECT * FROM Movie.Movie
	WHERE ReleaseDate > '2019-01-01';

SELECT * FROM Movie.NewReleases

INSERT INTO Movie.NewReleases (Title, ReleaseDate, GenreId) VALUES
	('LOTR: The Two Towers', '2019-09-01', (SELECT GenreId FROM Genre WHERE Name = 'Action/Adventure'))

GO
ALTER VIEW Movie.NewReleases AS
	SELECT * FROM Movie.Movie
	WHERE ReleaseDate > '2019-02-01';
GO

-- views provide an abstraction over the actual table structure
--	by running a query behind the scenes to generate what pretends 
--	to be a table

-- we can do inserts/updates/deletes through it too, but
--	only on columns that directly map to real table columns

-- variables in SQL server
-- they must start with @ sign
DECLARE @action AS INT;
SET @action = 1;

-- table-valued variables
DECLARE @MyTable AS TABLE (
	col1 INT, col2 INT
)

-- INSERT INTO @MyTable, etc.

-- user-defined functions
GO
CREATE FUNCTION Movie.MoviesReleaseInYear(@year INT)
RETURNS INT
AS 
BEGIN
	DECLARE @result INT;

	SELECT @result = COUNT(*)
	FROM Movie.Movie
	WHERE YEAR(ReleaseDate) = @year;

	RETURN @result;
END
GO

SELECT Movie.MoviesReleaseInYear(2002);

-- functions do not allow writing any data, only reading

-- 1. write a function to get the initials of a customer based on his ID (look up string functions)

GO
CREATE FUNCTION dbo.GetCustomerInitials(@Id INT)
RETURNS NVARCHAR(3)
AS
BEGIN
	DECLARE @initials NVARCHAR(3);

	-- in SQL, string indexing is 1-based
	SELECT @initials = SUBSTRING(Customer.FirstName, 1, 1) + SUBSTRING(Customer.LastName, 1, 1)
	FROM Customer
	WHERE Customer.CustomerId = @Id;

	RETURN @initials;
END
GO

SELECT dbo.GetCustomerInitials(1)
SELECT * FROM Customer
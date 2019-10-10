--computed columns -computed when read, not stored

--stored with option PERSISTED
--stored lazily - cached after multiple uses

ALTER TABLE Genre ADD
	FirstLetter AS (SUBSTRING(Name,1 ,1)) PERSISTED

ALTER TABLE Genre ADD
	Active BIT NOT NULL Default 1;

SELECT * FROM Genre

GO
--View - a 'table' that is actually computed from an underlying SELECT stmt
CREATE VIEW ActiveGenre AS
	SELECT * FROM Genre WHERE Active = 1;

UPDATE Genre
SET Active = 0
WHERE FirstLetter = 'R'

SELECT * From ActiveGenre


--Variables
--Only exist for duration of a batch of commands
--scalar (single cell)
--table-valued (intermediate table)

--scalar @name
DECLARE @maxid INT;
SELECT @maxid = MAX(GenreID) FROM Genre;
UPDATE Genre
SET Active = 0
FROM Genre
WHERE GenreID = @maxid;

--table @@name


--USER DEFINED Functions
--read only
CREATE FUNCTION TotalNumberOfGenres()
RETURNS INT
AS
BEGIN
	DECLARE @result INT;
	SELECT @result = COUNT(*) FROM GENRE
	RETURN @result
END

SELECT dbo.TotalNumberOfGenres();

GO
CREATE FUNCTION CustomerInitials3(@idTemp INT)
RETURNS NVARCHAR(10)
AS
BEGIN
	RETURN
	(
		SELECT CONCAT(SUBSTRING(FirstName,1,1), SUBSTRING(LastName,1,1))
		FROM Customer
		WHERE CustomerId = @idTemp
	)
END
GO

SELECT dbo.CustomerInitials3(4);

--Procedures - Functions WITH SCHEMABINDING
--Can modify DB
--Cannont run without EXECUTE stmt
--No return, but oup parameters
GO
CREATE PROCEDURE GenreQuestionMark
AS
BEGIN
	UPDATE Genre
	SET Name = Name + '!'
	FROM Genre
END
EXECUTE dbo.GenreQuestionMark
SELECT * FROM Genre;


--trigger 
--code that runs before/instead/after you insert/update/delete to a particular table



--a trigger can automatically mantain DateModified
CREATE TRIGGER 










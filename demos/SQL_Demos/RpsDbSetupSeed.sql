SELECT * FROM Players;
SELECT * FROM Rounds;
SELECT * FROM Games;
CREATE SCHEMA RpsGame;
CREATE DATABASE RpsGameDb;

CREATE TABLE Players
(
	PlayerId int PRIMARY KEY NOT NULL IDENTITY(1,1),
	PlayerFname NVARCHAR(20) NOT NULL,
	PlayerLname NVARCHAR(20) NOT NULL,
	PlayerAge int NULL,
	Country NVARCHAR(20) NULL,
	Street NVARCHAR(20) NULL,
	City NVARCHAR(20) NULL,
	State NVARCHAR(20) NULL,-- this could be a FK
	CONSTRAINT AgeUnder125 CHECK(PlayerAge < 125 AND PlayerAge > 0)
);

--add a date column
ALTER TABLE Players
ADD DateAdded DateTime DEFAULT(GetDate());

ALTER TABLE Players
ADD TestValue int;

INSERT INTO Players (PlayerFname, PlayerLname, PlayerAge,Country, Street, City, State)
VALUES('1Mark','1Moore', 32, 'USA', '123 Main St.', 'Crowley','Texas');

INSERT INTO Players (PlayerFname, PlayerLname, PlayerAge,Country, Street, City, State)
VALUES('Arely','Moore', 39, 'USA', '123 Main St.', 'Crowley','Texas');

INSERT INTO Players (PlayerFname, PlayerLname, PlayerAge)
VALUES('Arely','Garza-Roque Moore', 39);

--This insert does not work bc the PlayerLname is too long.
INSERT INTO Players (PlayerFname, PlayerLname, PlayerAge)
VALUES('Arely','Garza-Roque Moore de Monterrey, Nuevo Leon', 39);

--This insert does not work bc the PlayerLname is too long.
INSERT INTO Players (PlayerFname, PlayerLname, PlayerAge)
VALUES('Maya','Moore', 139);

SELECT * FROM Players;
DROP TABLE Players;

--Below the code for creating and seeding Game Table
CREATE TABLE Games
(
	GameId int PRIMARY KEY NOT NULL IDENTITY(1,1),
	Player1 int NOT NULL FOREIGN KEY REFERENCES Players(PlayerId),
	Player2 int NOT NULL FOREIGN KEY REFERENCES Players(PlayerId),
	GameWinner int NOT NULL FOREIGN KEY REFERENCES Players(PlayerId),
	DateAdded DateTime DEFAULT(GetDate())
);

SELECT * FROM Games;

--add a dateadded column
ALTER TABLE Games
ADD DateAdded DateTime DEFAULT(GetDate());

--add a winnder column
ALTER TABLE Games
ADD GameWinner int NOT NULL FOREIGN KEY REFERENCES Players(PlayerId);


INSERT INTO Games (Player1, Player2, GameWinner)
VALUES(1,2,1);

CREATE TABLE Rounds
(
	RoundId int PRIMARY KEY NOT NULL IDENTITY(1,1),
	Player1Choice int NOT NULL FOREIGN KEY REFERENCES Choices(ChoiceId),
	Player2Choice int NOT NULL FOREIGN KEY REFERENCES Choices(ChoiceId),
	GameId int NOT NULL FOREIGN KEY REFERENCES Games(GameId),
	DateAdded DateTime DEFAULT(GetDate())
);

INSERT INTO Rounds (Player1Choice, Player2Choice, GameId)
VALUES (1,2,1),(1,2,1);

CREATE TABLE Choices
(
	ChoiceId int PRIMARY KEY NOT NULL IDENTITY(1,1),
	ChoiceValue NVARCHAR(20) NOT NULL,
	-- add dateAdded
);

INSERT INTO Choices (ChoiceValue)
VALUES('PAPER'), ('ROCK'), ('SCISSORS');

SELECT * FROM Choices;
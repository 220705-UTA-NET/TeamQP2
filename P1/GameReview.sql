CREATE SCHEMA Review
GO
DROP TABLE Review.Game
DROP TABLE Review.GameTags
DROP TABLE Review.GamePlatform
DROP TABLE Review.GameReview
DROP TABLE Review.Reviewer

CREATE TABLE Review.Reviewer(
    ID INT PRIMARY KEY IDENTITY,
    UserName NVARCHAR(255) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL
)
CREATE TABLE Review.Game(
    ID INT PRIMARY KEY IDENTITY,
    GameTitle NVARCHAR(255) UNIQUE NOT NULL,
    GameDeveloper NVARCHAR(255) NOT NULL,
    GamePublisher NVARCHAR(255) NOT NULL,
    YearPublished INT NOT NULL
)
CREATE TABLE Review.GameReview(
    ID INT PRIMARY KEY IDENTITY,
    -- generic text field
    Review NVARCHAR(MAX),
    StarRating INT CHECK (StarRating <= 5 AND StarRating > 0) NOT NULL,
    UserName NVARCHAR(255) NOT NULL FOREIGN KEY REFERENCES Review.Reviewer(UserName),
    GameTitle NVARCHAR(255) NOT NULL FOREIGN KEY REFERENCES Review.Game(GameTitle),
    -- foreign key reference back to reviewer
    ReviewDate DATETIME NOT NULL,
    CONSTRAINT user_review UNIQUE(UserName,GameTitle)
)
CREATE TABLE Review.Platform(
    ID INT PRIMARY KEY IDENTITY,
    ConsoleName NVARCHAR(255) UNIQUE NOT NULL
)
CREATE TABLE Review.Tags(
    ID INT PRIMARY KEY IDENTITY,
    Genre NVARCHAR(255) UNIQUE NOT NULL
)
CREATE TABLE Review.GamePlatform(
    ID INT PRIMARY KEY IDENTITY,
    GameID INT FOREIGN KEY REFERENCES Review.Game(ID) ON DELETE CASCADE,
    PlatformID INT FOREIGN KEY REFERENCES Review.Platform(ID) ON DELETE CASCADE
)
CREATE TABLE Review.GameTags(
    ID INT PRIMARY KEY IDENTITY,
    GameID INT FOREIGN KEY REFERENCES Review.Game(ID) ON DELETE CASCADE,
    TagID INT FOREIGN KEY REFERENCES Review.Tags(ID) ON DELETE CASCADE
)
SELECT * FROM Review.Tags
SELECT * FROM Review.GameTags
SELECT * FROM Review.GamePlatform
SELECT * FROM Review.GameReview
INSERT INTO Review.Platform(ConsoleName) VALUES('Playstation')

INSERT INTO Review.GameTags(GameID,TagID) VALUES(2,1)
INSERT INTO Review.GameTags(GameID,TagID) VALUES(1,2)
INSERT INTO Review.GamePlatform(GameID,PlatformID) VALUES(1,2)


INSERT INTO Review.GamePlatform(GameID,PlatformID) VALUES(1,3)

SELECT t.Genre 
FROM Review.Game as g 
JOIN Review.GameTags as gt on g.ID = gt.GameID
JOIN Review.Tags as t on t.ID = gt.TagID
WHERE g.ID = 1

SELECT p.ConsoleName 
FROM Review.Game as g 
JOIN Review.GamePlatform as gp on g.ID = gp.GameID
JOIN Review.Platform as p on p.ID = gp.PlatformID
WHERE g.ID = 1

SELECT g.ID, g.GameTitle, g.GameDeveloper, g.YearPublished 
FROM Review.Game as g 
JOIN Review.GameTags as gt on gt.GameID = g.ID
JOIN Review.Tags as t on t.ID = gt.TagID
WHERE t.Genre = 'co-op'

SELECT g.ID, g.GameTitle, g.GameDeveloper, g.YearPublished 
FROM Review.Game as g 
JOIN Review.GamePlatform as gp on gp.GameID = g.ID
JOIN Review.Platform as p on p.ID = gp.PlatformID
WHERE p.ConsoleName = 'XBOX'

SELECT * FROM Review.Game
SELECT * FROM Review.Reviewer
SELECT * FROM Review.GameReview
SELECT * FROM Review.Tags
SELECT * From Review.Platform
SELECT * FROM Review.GamePlatform
SELECT * FROM Review.GameTags

INSERT INTO Review.Reviewer(UserName,Password) VALUES('LeBrando25','1234567879')
INSERT INTO Review.Game(GameTitle,GameDeveloper,GamePublisher,YearPublished) VALUES('Borderlands 2','Gearbox','2K Games',2012)
INSERT INTO Review.Game(GameTitle,GameDeveloper,GamePublisher,YearPublished) VALUES('Borderlands 3','Gearbox','2K Games',2019)
INSERT INTO Review.GameReview(Review,StarRating,UserName,GameTitle,ReviewDate) VALUES('Game Smacks',5,'LeBrando25','Borderlands 2',GETDATE())

INSERT INTO Review.Tags(Genre) 
SELECT 'Rogue-like'
WHERE NOT EXISTS (SELECT Genre FROM Review.Tags WHERE Genre = 'Rogue-like')

INSERT INTO Review.Platform(ConsoleName) 
SELECT 'Nintendo Switch'
WHERE NOT EXISTS (SELECT Genre FROM Review.Tags WHERE Genre = 'Nintendo Switch')
GO

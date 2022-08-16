CREATE SCHEMA Review
GO
DROP TABLE  Review.Game
CREATE TABLE Review.Reviewer(
    ID INT PRIMARY KEY IDENTITY,
    UserID NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    CONSTRAINT user_values UNIQUE(UserID,Password)
)
CREATE TABLE Review.Game(
    ID INT PRIMARY KEY IDENTITY,
    GameTitle NVARCHAR(255) NOT NULL,
    GameDeveloper NVARCHAR(255) NOT NULL,
    GamePublisher NVARCHAR(255) NOT NULL,
    YearPublished INT NOT NULL,
    CONSTRAINT game_values UNIQUE (GameTitle,GameDeveloper)
)
CREATE TABLE Review.GameReview(
    ID INT PRIMARY KEY IDENTITY,
    -- generic text field
    Review NVARCHAR(MAX),
    StarRating INT CHECK (StarRating <= 5 AND StarRating > 0) NOT NULL,
    ReviewerID INT NOT NULL FOREIGN KEY REFERENCES Review.Reviewer(ID),
    GameID INT NOT NULL FOREIGN KEY REFERENCES Review.Game(ID),
    -- foreign key reference back to reviewer
    ReviewDate DATETIME NOT NULL,
    CONSTRAINT user_review UNIQUE(ReviewerID,GameID)
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
SELECT * FROM Review.Game
INSERT INTO Review.Tags(Genre) VALUES('single-player')
INSERT INTO Review.GameTags(GameID,TagID) VALUES(1,1)
INSERT INTO Review.GameTags(GameID,TagID) VALUES(1,2)

SELECT t.Genre 
FROM Review.Game as g
JOIN Review.GameTags as gt on g.ID = gt.GameID
JOIN Review.Tags as t on t.ID = gt.TagID

GO

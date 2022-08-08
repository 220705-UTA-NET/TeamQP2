CREATE SCHEMA Review
GO

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
    GameGenre NVARCHAR(255) NOT NULL,
    YearPublished INT NOT NULL,
    CONSTRAINT game_values UNIQUE (GameTitle,GameDeveloper)
)
CREATE TABLE Review.GameReview(
    ID INT PRIMARY KEY IDENTITY,
    -- generic text field
    Review NVARCHAR(MAX),
    StarRating INT CHECK (StarRating <= 5 AND StarRating >+ 0) NOT NULL,
    ReviewerID INT NOT NULL FOREIGN KEY REFERENCES Review.Reviewer(ID),
    GameID INT NOT NULL FOREIGN KEY REFERENCES Review.Game(ID),
    -- foreign key reference back to reviewer
    ReviewDate DATETIME NOT NULL,
    CONSTRAINT user_review UNIQUE(ReviewerID,GameID)
)
GO
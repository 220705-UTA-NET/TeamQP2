using System;

namespace GameReviewAPI.Model
{
    public class Game
    {
        public int ID { get; set; }
        public string GameTitle { get; set; }
        public string GameDeveloper { get; set; }
        public string GameGenre { get; set; }
        public int YearPublished { get; set; }

        public Game(int iD, string gameTitle, string gameDeveloper, string gameGenre, int yearPublished)
        {
            this.ID = iD;
            this.GameTitle = gameTitle;
            this.GameDeveloper = gameDeveloper;
            this.GameGenre = gameGenre;
            this.YearPublished = yearPublished;
        }
    }
}

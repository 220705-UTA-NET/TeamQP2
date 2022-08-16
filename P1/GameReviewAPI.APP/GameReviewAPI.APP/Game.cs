namespace GameReviewAPI.APP
{
    public class Game
    {
        public int id { get; set; }
        public string gameTitle { get; set; }
        public string gameDeveloper { get; set; }
        public string gameGenre { get; set; }
        public int yearPublished { get; set; }

        public Game(string gameTitle, string gameDeveloper, string gameGenre, int yearPublished)
        {
            this.gameTitle = gameTitle;
            this.gameDeveloper = gameDeveloper;
            this.gameGenre = gameGenre;
            this.yearPublished = yearPublished;
        }
        public override string ToString()
        {
            return $"ID: {id} GameTitle: {gameTitle} GameDeveloper: {gameDeveloper} GameGenre: {gameGenre} YearPublished: {yearPublished}";
        }
    }
}

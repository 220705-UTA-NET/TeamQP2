using System;

namespace GameReviewAPI.Model
{
    public class Game
    {
        public int ID { get; set; }
        public string GameTitle { get; set; }
        public string GameDeveloper { get; set; }
        public string GamePublisher { get; set; }
        public List<Tag> Tags   { get; set; }
        public List<Platform> Platforms { get; set; }
        public int YearPublished { get; set; }

        public Game(int iD, string gameTitle, string gameDeveloper, string gamePublisher, List<Tag> Tags, List<Platform> Platforms, int yearPublished)
        {
            this.ID = iD;
            this.GameTitle = gameTitle;
            this.GameDeveloper = gameDeveloper;
            this.GamePublisher = gamePublisher;
            this.Tags = Tags;
            this.Platforms = Platforms;
            this.YearPublished = yearPublished;
        }
    }
}

namespace GameReviewAPI.Model
{
    public class Platform
    {
        public int Id { get; set; } 
        public string platform { get; set; }
        public Platform(int iD, string platform)
        {
            this.Id = iD;
            this.platform = platform;
        }
    }
}

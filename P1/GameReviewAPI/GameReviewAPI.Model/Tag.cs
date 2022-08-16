
namespace GameReviewAPI.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public string tag { get; set; }
        public Tag(int iD, string tag)
        {
            this.Id = iD;
            this.tag = tag;
        }
    }
}

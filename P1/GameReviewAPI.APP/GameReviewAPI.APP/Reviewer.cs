namespace GameReviewAPI.APP
{
    public class Reviewer
    {
        public int id { get; set; }
        public string userID { get; set; }
        public string password { get; set; }

        public Reviewer(string userID, string password)
        {
            this.userID = userID;
            this.password = password;
        }
        public override string ToString()
        {
            return $"ID: {id} UserID: {userID} Password: {password}";
        }

    }
}

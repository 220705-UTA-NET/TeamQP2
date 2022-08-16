using System;

namespace GameReviewAPI.Model
{
    public class Reviewer
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }

        public Reviewer(int iD, string userID, string password)
        {
            this.ID = iD;
            this.UserID = userID;
            this.Password = password;
        }
    }
}

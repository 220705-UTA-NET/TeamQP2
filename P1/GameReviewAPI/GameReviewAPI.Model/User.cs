using System;

namespace GameReviewAPI.Model
{
    public class User
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }

        public User(int iD, string userID, string password)
        {
            this.ID = iD;
            this.UserID = userID;
            this.Password = password;
        }
    }
}

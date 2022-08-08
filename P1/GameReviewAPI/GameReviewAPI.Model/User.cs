using System;

namespace GameReviewAPI.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(int UserID, string Username, string Password)
        {
            this.UserID = UserID;
            this.Username = Username;
            this.Password = Password;
        }
    }
}

using System;

namespace GameReviewAPI.Model
{
    public class User
    {
        public int ID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        public User(int iD, string userName, string password)
        {
            this.ID = iD;
            this.userName = userName;
            this.password = password;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FirstNetCore.Model.User
{
    //for simple, I'm not using the database to store the user data, just using a static class to replace it.
    public static class TestUserStorage
    {
        public static List<UserInfo> UserList { get; set; } = new List<UserInfo>() {
    new UserInfo { UserName = "User1",Password = "112233"}
  };
    }
}

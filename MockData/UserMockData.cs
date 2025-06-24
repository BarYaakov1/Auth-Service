using System.Collections.Generic;

public static class UserMockData
{
    public static List<User> GetUsers()
    {
        return new List<User>
        {
            new User { Username = "john", Password = "1234", IsLoggedIn = false },
            new User { Username = "alice", Password = "pass123", IsLoggedIn = false },
            new User { Username = "bob", Password = "qwerty", IsLoggedIn = false }
        };
    }
}

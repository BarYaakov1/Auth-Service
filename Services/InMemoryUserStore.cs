using System.Collections.Concurrent;

    public class InMemoryUserStore
    {
        private readonly Dictionary<string, User> _users = new();

        public InMemoryUserStore(IEnumerable<User> initialUsers)
        {
            foreach (var user in initialUsers)
            {
                AddUser(user);
            }
        }

        public bool ValidateCredentials(string username, string password)
        {
            return _users.TryGetValue(username, out var user) && user.Password == password;
        }

        public User? GetUser(string username)
        {
            _users.TryGetValue(username, out var user);
            return user;
        }

        public void SetLoginStatus(string username, bool isLoggedIn)
        {
            if (_users.TryGetValue(username, out var user))
            {
                user.IsLoggedIn = isLoggedIn;
            }
        }

        private void AddUser(User user)
        {
            _users[user.Username] = user;
        }
    }

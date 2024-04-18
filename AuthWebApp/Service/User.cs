namespace AuthWebApp.Service
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }
    }

    public static class UserAuthService
    {

        static List<User> user;

        static UserAuthService()
        {
            user = new List<User>
            {
                new User { Id = 1, Name = "Sree", Email = "admin@gmail.com", Password = "abcd123",Role = "Admin"},
                new User { Id = 2, Name = "Jhon", Email = "jhon@gmail.com", Password = "abcd123",Role = "Member"}
            };
        }

        public static User Authentication(string username, string password)
        {
             return user.FirstOrDefault(d => d.Email == username && d.Password == password);    
        }

    }
}

namespace UserRegClasses
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }



        public User(string user, string pas, string email)
        {


            if (user is not null && user.Length >= 5 && user.Length <= 20 
                && pas is not null && pas.Length >= 8
                && email is not null && email.EndsWith("@email.com"))
            {
                Username = user;
                Password = pas;
                Email = email;
            }
            else
            {
                throw new ArgumentException("Username must be between 5 and 20 characters and email must end with '@email.com'");
            }


        }
    }
}

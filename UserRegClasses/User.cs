

namespace UserRegClasses
{
    public class User
    {


        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        

        public User(string user, string pas, string email)
        {
            

            
            if (email is not null && email.EndsWith("@email.com"))
            {
                if (user is not null && user.Length >= 5 && user.Length <= 20)
                {
                    
                }
                else
                {
                    throw new ArgumentException("'Username must be between 5 and 20'");
                }

                if (pas is not null && pas.Length >= 8 && CheckIsCharacterSpecial(pas))
                {
                    Username = user;
                    Password = pas;
                    Email = email;
                }
                else
                {
                    throw new ArgumentException("'Password lenght must be over 8 characters, and needs a special sign'");
                }
                
            }
            else
            {
                throw new ArgumentException("email must end with '@email.com");
            }
            
            
        }

        private bool CheckIsCharacterSpecial(string password)
        {
            foreach (char c in password)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        public List<ArgumentException> errorHandler(List<ArgumentException> errors)
        {
            return errors;
        }

        /* Kolla igenom detta om du kan fixa!

            List<string>? errormessage = null;
           
            switch (user)
            {
                case string when user.Length < 5:
                    errormessage!.Add("Username must be at least 5 characters long.");
                    break;
                case string when user.Length > 20:
                    errormessage!.Add("Username cannot exceed 20 characters.");
                    break;
                default:
                    
                    break;
            }

            switch (pas)
            {
                case string when pas.Length < 8:
                    errormessage!.Add("Password must be over 8 characters");
                    break;
                case string when !CheckIsCharacterSpecial(pas):
                    errormessage!.Add("Password must include atleast one special character!");
                    break;
                default:
                    
                    break;
            }

            switch (email)
            {
                case string when !email.EndsWith("@email.com"):
                    errormessage!.Add("Email must end with '@email.com'");
                        break;
                default:
                    break;
            }


            List<ArgumentException> Errors = new();

            foreach (var strings in errormessage!)
            {
                Errors.Add(new ArgumentException(strings));

            }

            if (Errors.Count > 0)
            {
                errorHandler(Errors);
            }
            */
    }


}



using System.Text.RegularExpressions;

namespace UserRegClasses
{
    public class User
    {


        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        

        public User(string user, string pas, string email)
        {
            
            // If sats som går igenom alla argument som kommer in och kollar att alla requirements nås!
            
            if (email is not null && email.EndsWith("@email.com"))
            {
                if (user is not null && user.Length >= 5 && user.Length <= 20 && Regex.IsMatch(user, "^[a-zA-Z]+$"))
                {
                    
                }
                else
                {
                    throw new ArgumentException("'Username must be between 5 and 20, and must only include letters'");
                }

                if (pas is not null && pas.Length >= 8 && CheckIsCharacterSpecial(pas))
                {
                    Username = user;
                    Password = pas; // Ifall allt stämmer med requirements, sätt argumenten och tillge de till parametrerna och skapa usern.
                    Email = email;
                }
                else
                {
                    throw new ArgumentException("'Password lenght must be over 8 characters, and needs a special sign'"); // Annars kasta nån av dessa exceptions beroende på vilken if sats som fångar upp felet.
                }
                
            }
            else
            {
                throw new ArgumentException("email must end with '@email.com");
            }
            
            
        }

        private bool CheckIsCharacterSpecial(string password)
        {
            foreach (char c in password) // Checkar varje karaktär i passwordargument som skickas in
            {
                if (!char.IsLetterOrDigit(c)) // Om någon av chars är en vanlig bokstav eller siffra....
                {
                    return true; // Så triggas en bool som returnerar true!
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

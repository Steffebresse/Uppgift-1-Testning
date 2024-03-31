using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegClasses
{
    public class UserExperiment
    {


        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        List<string>? errormessage = new();


        public UserExperiment(string user, string pas, string email)
       {


            // Gjorde denna för att samla flera errors, ifall men gör mer än ett fel.
                

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

        public List<ArgumentException> errorHandler()
        {
            List<ArgumentException> Errors = new();
            foreach (var item in errormessage!)
            {
                Errors.Add(new ArgumentException(item));
            }

            return Errors;
        }
    }
}

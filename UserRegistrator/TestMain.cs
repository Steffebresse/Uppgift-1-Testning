using UserRegClasses;

namespace UserRegistrator
{
    public class TestMain
    {
        [Fact]
        public void Check_If_User_Added_Is_Unique()
        {
            // Arrange
            // Syftet är att testa om programmet säger ifrån ifall jag försöker lägga till två personer av samma namn.
            var user1 = new User("Josef", "12@34567a", "test@email.com");
            var user2 = new User("Josef", "12@34567a", "test@email.com");
            var userBank = new UserBank();

            // Act
            userBank.AddUser(user1);

            // Assert
            var exception = Assert.Throws<ArgumentException>(() => userBank.AddUser(user2));
            Assert.Equal("Username already exists.", exception.Message);

        }

        // Felet slänger ett argumentexcpetion då, ifall LINQ i AddUser Metoden hittar en User med samma namn.

        [Theory]
        [InlineData("JagÄrÖver20Karaktärer1234")] // Använder en datarow som kör testet med dessa två angivna alternativ.
        [InlineData("4Let")]
        public void Check_If_User_Created_With_Invalid_Username_Throws_Exception(string user)
        {
            // Arrange & Act

            var exception = Assert.Throws<ArgumentException>(() => new User($"{user}", "pas!sword", "whatever@email.com")); // Kör båda aöternativen, ett namn som är för kort, och ett som är för långt.
            
            // Assert
            Assert.Equal("'Username must be between 5 and 20, and must only include letters'", exception.Message); // Sedan skall exceptionet motsvara detta felmeddlande under båda testarna.
            
           
        }

        [Fact]
        public void Check_If_User_Created_With_Valid_Username_Lenght_With_Wrong_Formating()
        {
            // Arrange & Act

            var exception = Assert.Throws<ArgumentException>(() => new User($"Within20Chars", "pas!sword", "whatever@email.com")); // Kollar om användarnamn med rätt antal karaktärer triggar ett fel, ifall den inte har användarnamn A-Z

            // Assert
            Assert.Equal("'Username must be between 5 and 20, and must only include letters'", exception.Message); // Sedan skall exceptionet motsvara detta felmeddlande under båda testarna.


        }

        [Fact]
        public void Check_If_User_Has_Right_Formatting_For_Email()
        {
            // Arrange & Act
            
            var user1 = new User("Josef", "1234567@@a", "Gielinor@email.com");
            var exception = Assert.Throws<ArgumentException>(() => new User("Josef", "12345@67aa", "DåligEmail"));
            // Assert

            Assert.Equal("Gielinor@email.com", user1.Email); // Tanken är att också checka att det funkar, men detta säger inte så mycket, FIXA DETTA!
            Assert.Equal("email must end with '@email.com", exception.Message); // Checkar att excpetionet motsvarar det felmeddeleande som förväntas när jag inte följer kriteriet för mailen.
        }

        [Fact]
        public void Check_If_User_Message_When_Successfull_Works()
        {
            // Act
            var userbank = new UserBank();
            var user = new User("UserTest", "Jagheterst@efan1", "Stefan.kureljusic@email.com");
            // Arrange
            string success = userbank.AddUser(user); // Metoden returnerar en sträng ger ett medelande ifall man lyckats lägga till en användare, annars kastat ett ArgumentException
            // Assert
            Assert.Equal($"{user.Username} has been sucessfully created!", success); // Här checkar vi ifall det förväntade meddelandet motsvarar, meddelandet som skall komma!

        }

        [Theory]
        [InlineData("JagRättLängdMenUtanSpecialTecken")] // Använder en datarow som kör testet med dessa två angivna alternativ.
        [InlineData("KortM!")] // Kort lösen med specialtecken
        [InlineData("Nospec")] // Sedan ett lösenord som är kort utan specialtecken
        public void Check_If_Added_Users_PassWord_Contains_The_Right_Formatting(string password)
        {
            // Arrange
            var userbank = new UserBank();

            // Act and Arrange
            var exception = Assert.Throws<ArgumentException>(() => new User("Josef", password, "stefan@email.com")); // Här testar jag alternativet som angetts i InlineDatan!

            Assert.Equal("'Password lenght must be over 8 characters, and needs a special sign'", exception.Message); // Här confirmerar jag att det kastats det fel som förväntas!
        }

        
    }
}
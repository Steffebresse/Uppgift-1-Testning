using UserRegClasses;

namespace UserRegistrator
{
    public class TestMain
    {
        [Fact]
        public void Check_If_User_Added_Is_Unique()
        {
            // Arrange
            // Syftet �r att testa om programmet s�ger ifr�n ifall jag f�rs�ker l�gga till tv� personer av samma namn.
            var user1 = new User("Josef", "12@34567a", "test@email.com");
            var user2 = new User("Josef", "12@34567a", "test@email.com");
            var userBank = new UserBank();

            // Act
            userBank.AddUser(user1);

            // Assert
            var exception = Assert.Throws<ArgumentException>(() => userBank.AddUser(user2));
            Assert.Equal("Username already exists.", exception.Message);

        }

        // Felet sl�nger ett argumentexcpetion d�, ifall LINQ i AddUser Metoden hittar en User med samma namn.

        [Theory]
        [InlineData("Jag�r�ver20Karakt�rer1234")] // Anv�nder en datarow som k�r testet med dessa tv� angivna alternativ.
        [InlineData("4Let")]
        public void Check_If_User_Created_With_Invalid_Username_Throws_Exception(string user)
        {
            // Arrange & Act

            var exception = Assert.Throws<ArgumentException>(() => new User($"{user}", "pas!sword", "whatever@email.com")); // K�r b�da a�ternativen, ett namn som �r f�r kort, och ett som �r f�r l�ngt.
            
            // Assert
            Assert.Equal("'Username must be between 5 and 20, and must only include letters'", exception.Message); // Sedan skall exceptionet motsvara detta felmeddlande under b�da testarna.
            
           
        }

        [Fact]
        public void Check_If_User_Created_With_Valid_Username_Lenght_With_Wrong_Formating()
        {
            // Arrange & Act

            var exception = Assert.Throws<ArgumentException>(() => new User($"Within20Chars", "pas!sword", "whatever@email.com")); // Kollar om anv�ndarnamn med r�tt antal karakt�rer triggar ett fel, ifall den inte har anv�ndarnamn A-Z

            // Assert
            Assert.Equal("'Username must be between 5 and 20, and must only include letters'", exception.Message); // Sedan skall exceptionet motsvara detta felmeddlande under b�da testarna.


        }

        [Fact]
        public void Check_If_User_Has_Right_Formatting_For_Email()
        {
            // Arrange & Act
            
            var user1 = new User("Josef", "1234567@@a", "Gielinor@email.com");
            var exception = Assert.Throws<ArgumentException>(() => new User("Josef", "12345@67aa", "D�ligEmail"));
            // Assert

            Assert.Equal("Gielinor@email.com", user1.Email); // Tanken �r att ocks� checka att det funkar, men detta s�ger inte s� mycket, FIXA DETTA!
            Assert.Equal("email must end with '@email.com", exception.Message); // Checkar att excpetionet motsvarar det felmeddeleande som f�rv�ntas n�r jag inte f�ljer kriteriet f�r mailen.
        }

        [Fact]
        public void Check_If_User_Message_When_Successfull_Works()
        {
            // Act
            var userbank = new UserBank();
            var user = new User("UserTest", "Jagheterst@efan1", "Stefan.kureljusic@email.com");
            // Arrange
            string success = userbank.AddUser(user); // Metoden returnerar en str�ng ger ett medelande ifall man lyckats l�gga till en anv�ndare, annars kastat ett ArgumentException
            // Assert
            Assert.Equal($"{user.Username} has been sucessfully created!", success); // H�r checkar vi ifall det f�rv�ntade meddelandet motsvarar, meddelandet som skall komma!

        }

        [Theory]
        [InlineData("JagR�ttL�ngdMenUtanSpecialTecken")] // Anv�nder en datarow som k�r testet med dessa tv� angivna alternativ.
        [InlineData("KortM!")] // Kort l�sen med specialtecken
        [InlineData("Nospec")] // Sedan ett l�senord som �r kort utan specialtecken
        public void Check_If_Added_Users_PassWord_Contains_The_Right_Formatting(string password)
        {
            // Arrange
            var userbank = new UserBank();

            // Act and Arrange
            var exception = Assert.Throws<ArgumentException>(() => new User("Josef", password, "stefan@email.com")); // H�r testar jag alternativet som angetts i InlineDatan!

            Assert.Equal("'Password lenght must be over 8 characters, and needs a special sign'", exception.Message); // H�r confirmerar jag att det kastats det fel som f�rv�ntas!
        }

        
    }
}
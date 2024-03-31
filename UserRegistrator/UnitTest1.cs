using UserRegClasses;

namespace UserRegistrator
{
    public class UnitTest1
    {
        [Fact]
        public void Check_If_User_Added_Is_Unique()
        {
            // Arrange
            var user1 = new User("Josef", "12@34567a", "test@email.com");
            var user2 = new User("Josef", "12@34567a", "test@email.com");
            var userBank = new UserBank();

            // Act
            userBank.AddUser(user1);

            // Assert
            
            Assert.Throws<ArgumentException>(() => userBank.AddUser(user2));
        }



        [Theory]
        [InlineData("JagÄrÖver20Karaktärer1234")]
        [InlineData("4Let")]
        public void Check_If_User_Created_With_Invalid_Username_Throws_Exception(string user)
        {
            // Arrange & Act

            // Fixa till att Datorows som skall ge ut olika värden samt olika fellmeddelanden beroende på datat som skickas in
            
            var exception = Assert.Throws<ArgumentException>(() => new User($"{user}", "pas!sword", "whatever@email.com"));
            //var exception2 = Assert.Throws<ArgumentException>(() => new User("User", "pas!sword", "whatever@email.com"));
            // Assert
            Assert.Equal("'Username must be between 5 and 20'", exception.Message);
            // Assert.Equal("Username must be between 5 and 20 characters and email must end with '@email.com'", exception2.Message);
           


        }

        [Fact]
        public void Check_If_User_Has_Right_Formatting_For_Email()
        {
            // Arrange & Act
            
            var user1 = new User("Josef", "1234567@@a", "Gielinor@email.com");

            // Assert
            
            Assert.Equal("Gielinor@email.com", user1.Email);

            
            var exception = Assert.Throws<ArgumentException>(() => new User("Josef", "12345@67aa", "DåligEmail"));
            Assert.Equal("email must end with '@email.com", exception.Message);
        }

        [Fact]
        public void Check_If_User_Message_When_Successfull_Works()
        {

            var userbank = new UserBank();
            var user = new User("UserTest", "Jagheterst@efan1", "Stefan.kureljusic@email.com");

            string success = userbank.AddUser(user);

            Assert.Equal($"{user.Username} has been sucessfully created!", success);

        }

        [Fact]
        public void Check_If_Added_Users_PassWord_Contains_The_Right_Formatting()
        {
            // Arrange
            var userbank = new UserBank();

            // Act and Arrange
            var exception = Assert.Throws<ArgumentException>(() => new User("Josef", "LösenordetharingeSpecialTecken", "stefan@email.com"));

            Assert.Equal("'Password lenght must be over 8 characters, and needs a special sign'", exception.Message);
        }
    }
}
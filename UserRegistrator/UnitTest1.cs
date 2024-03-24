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

        [Fact]
        public void Check_If_User_Created_With_Invalid_Username_Throws_Exception()
        {
            // Arrange & Act
            
            var exception1 = Assert.Throws<ArgumentException>(() => new User("Jagäröver20karaktärerjagsvär1234", "password", "whatever@email.com"));
            var exception2 = Assert.Throws<ArgumentException>(() => new User("User", "password", "whatever@email.com"));
            // Assert
            Assert.Equal("Username must be between 5 and 20 characters and email must end with '@email.com'", exception1.Message);
            Assert.Equal("Username must be between 5 and 20 characters and email must end with '@email.com'", exception2.Message);

        }

        [Fact]
        public void Check_If_User_Has_Right_Formatting_For_Email()
        {
            // Arrange & Act
            
            var user1 = new User("Josef", "1234567@@a", "Gielinor@email.com");

            // Assert
            
            Assert.Equal("Gielinor@email.com", user1.Email);

            
            var exception = Assert.Throws<ArgumentException>(() => new User("Josef", "12345@67aa", "DåligEmail"));
            Assert.Equal("Username must be between 5 and 20 characters and email must end with '@email.com'", exception.Message);
        }

        [Fact]
        public void Check_If_User_Message_When_Successfull_Works()
        {

            var userbank = new UserBank();
            var user = new User("UserTest", "Jagheterstefan1", "Stefan.kureljusic@email.com");

           string success = userbank.AddUser(user);

           Assert.Equal($"{user.Username} has been sucessfully created!", success);

        }
    }
}
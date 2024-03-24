using UserRegClasses;

namespace UserRegistrator
{
    public class UnitTest1
    {
        [Fact]
        public void Check_If_User_Added_Is_Unique()
        {
            // Arrange
            var user1 = new User("Josef", "1234567");
            var user2 = new User("Josef", "1234567");
            var userBank = new UserBank();

            // Act
            userBank.AddUser(user1);

            // Assert
            // Ensure that attempting to add user2 throws an ArgumentException
            Assert.Throws<ArgumentException>(() => userBank.AddUser(user2));
        }

        [Fact]
        public void Check_If_User_Created_With_Invalid_Username_Throws_Exception()
        {
            // Arrange & Act
            // Attempt to create a user with an invalid username length
            var exception1 = Assert.Throws<ArgumentException>(() => new User("Jagäröver20karaktärerjagsvär1234", "password"));
            var exception2 = Assert.Throws<ArgumentException>(() => new User("User", "password"));
            // Assert
            Assert.Equal("Username must be between 5 and 20 characters!", exception1.Message);
            Assert.Equal("Username must be between 5 and 20 characters!", exception2.Message);

        }
    }
}
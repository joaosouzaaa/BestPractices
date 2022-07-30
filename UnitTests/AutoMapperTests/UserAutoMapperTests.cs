using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.Request.User;
using BestPractices.ApplicationService.Response.User;
using BestPractices.Domain.Entities;
using UnitTests.AutoMapperTests.BaseAutoMapper;

namespace UnitTests.AutoMapperTests
{
    public class UserAutoMapperTests : PageListBuild<User, UserResponseClient>
    {
        public User User = UserBuilder.NewObject().DomainBuild();

        [Fact]
        public void User_To_UserSaveRequest()
        {
            var userSaveRequest = User.MapTo<User, UserSaveRequest>();

            Assert.Equal(userSaveRequest.Email, User.Email);
            Assert.Equal(userSaveRequest.Password, User.PasswordHash);
        }

        [Fact]
        public void User_To_UserResponse()
        {
            var userResponse = User.MapTo<User, UserResponse>();

            Assert.Equal(userResponse.Email, User.Email);
            Assert.Equal(userResponse.Password, User.PasswordHash);
        }

        [Fact]
        public void User_To_UserResponseClient()
        {
            var userResponseClient = User.MapTo<User, UserResponseClient>();

            Assert.Equal(userResponseClient.Id, User.Id);
            Assert.Equal(userResponseClient.Email, User.Email);
        }
    }
}

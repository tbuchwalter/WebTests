using MyProject.Authorization;
using MyProject.Authorization.Users;
using MyProject.Identity;

namespace MyProject.Web.Tests
{
    public static class TestLoginHelper
    {
        private static readonly UserManager _userManager;
        private static readonly LogInManager _logInManager;
        private static readonly SignInManager _signInManager;

        static TestLoginHelper()
        {
            //_userManager = userManager;
            //_logInManager = logInManager;
            //_signInManager = signInManager;
        }

        public static async void  LoginUser(string username, string password)
        {
            await _logInManager.LoginAsync(username, password);
        }
    }
}

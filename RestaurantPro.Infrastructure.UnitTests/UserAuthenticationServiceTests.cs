﻿using System;
using System.Security;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantPro.Core.Services;
using RestaurantPro.Infrastructure.Repositories;
using RestaurantPro.Infrastructure.Services;

namespace RestaurantPro.Infrastructure.UnitTests
{
    [TestClass]
    public class UserAuthenticationServiceTests
    {
        private readonly IUserAuthenticationService _userAuthenticationService;
        private const string FailedAuthenticationMessage = "Authentication Failed!";

        public UserAuthenticationServiceTests()
        {
            _userAuthenticationService = new UserAuthenticationService(new UserRepository(new RestProContext()));
        }

        [TestMethod]
        public async Task AuthenticateUserWithCorrectNameCorrectPassword()
        {
            //Arrange
            string expectedUsername = "rkpadi";
            string password = "password";

            //Act
            var user = await _userAuthenticationService.AuthenticateUser(expectedUsername, 
                ConvertToSecureString(password));

            //Assert
            Assert.AreEqual(expectedUsername, user.Username);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException), FailedAuthenticationMessage)]
        public async Task AuthenticateUserWithCorrectNameWrongPassword()
        {
            //Arrange
            string expectedUsername = "rkpadi";
            string password = "pass";

            //Act
            var user = await _userAuthenticationService.AuthenticateUser(expectedUsername,
                ConvertToSecureString(password));
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException), FailedAuthenticationMessage)]
        public async Task AuthenticateUserWithWrongNameCorrectPassword()
        {
            //Arrange
            string expectedUsername = "rkgoat";
            string password = "password";

            //Act
            var user = await _userAuthenticationService.AuthenticateUser(expectedUsername,
                ConvertToSecureString(password));
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException), FailedAuthenticationMessage)]
        public async Task AuthenticateUserWithWrongNameWrongPassword()
        {
            //Arrange
            string expectedUsername = "zigi";
            string password = "pass";

            //Act
            var user = await _userAuthenticationService.AuthenticateUser(expectedUsername,
                ConvertToSecureString(password));
        }

        [Ignore]
        private SecureString ConvertToSecureString(string rawPassword)
        {
            //shall leave soon
            var encodedPassword = new SecureString();

            foreach (char c in rawPassword)
                encodedPassword.AppendChar(c);

            return encodedPassword;
        }
        
    }
}
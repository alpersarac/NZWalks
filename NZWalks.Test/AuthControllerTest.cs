using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NZWalks.API.Controllers;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.Test
{
    [TestFixture]
    public class AuthControllerTest
    {
        private AuthController _authController;
        private Mock<UserManager<IdentityUser>> _mockUserManager;
        private Mock<ITokenRepository> _mockTokenRepository;

        [SetUp]
        public void Setup()
        {
            _mockUserManager = new Mock<UserManager<IdentityUser>>(
                Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);

            _mockTokenRepository = new Mock<ITokenRepository>();

            _authController = new AuthController(_mockUserManager.Object, _mockTokenRepository.Object);
        }
        [TearDown]
        public void Teardown()
        {
            // Clean up resources, reset mocks, etc.
            _mockUserManager.Reset();
            _mockTokenRepository.Reset();
        }

        [Test]
        public async Task Register_ValidRequest_ReturnsOk()
        {
            // Arrange
            var registerRequestDTO = new RegisterRequestDTO
            {
                username = "testuser",
                password = "password",
                roles = new string[] { "role1", "role2" }
            };

            _mockUserManager.Setup(x => x.CreateAsync(It.IsAny<IdentityUser>(), registerRequestDTO.password))
                .ReturnsAsync(IdentityResult.Success);

            _mockUserManager.Setup(x => x.AddToRolesAsync(It.IsAny<IdentityUser>(), registerRequestDTO.roles))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _authController.Register(registerRequestDTO);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }
        [Test]
        public async Task Register_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var registerRequestDTO = new RegisterRequestDTO
            {
                username = "testuser",
                password = "password",
                roles = null // Invalid request with null roles
            };

            // Act
            var result = await _authController.Register(registerRequestDTO);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }
    }
}

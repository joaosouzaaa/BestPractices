﻿using BestPractices.Api.Controllers;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Response.BearerToken;
using BestPractices.ApplicationService.Response.User;
using BestPractices.Business.Settings.PaginationSettings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitTests.Builders.Helpers;

namespace UnitTests.ControllerTests
{
    public class UserControllerTests
    {
        Mock<IUserService> _service;
        UserController _controller;
        private Guid _userId = Guid.NewGuid();
        private string _email = "joaoasouza982@gmail.com";

        public UserControllerTests()
        {
            _service = new Mock<IUserService>();
            _controller = new UserController(_service.Object);
            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = Utils.BuildClaimPrincipal("name here", _userId, "actor here", _email)}
            };
        }

        [Fact]
        public async Task RegisterAsync_ReturnsTrue()
        {
            var userSaveRequest = UserBuilder.NewObject().SaveRequestBuild();
            _service.Setup(s => s.RegisterAsync(userSaveRequest)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.RegisterAsync(userSaveRequest);

            _service.Verify(s => s.RegisterAsync(userSaveRequest), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task RegisterAsync_ReturnsFalse()
        {
            var userSaveRequest = UserBuilder.NewObject().SaveRequestBuild();
            _service.Setup(s => s.RegisterAsync(userSaveRequest)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.RegisterAsync(userSaveRequest);

            _service.Verify(s => s.RegisterAsync(userSaveRequest), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task LoginAsync_ReturnsToken()
        {
            var userSaveRequest = UserBuilder.NewObject().SaveRequestBuild();
            var bearerTokenResponse = BearerTokenBuilder.NewObject().ResponseBuild();
            _service.Setup(s => s.LoginAsync(userSaveRequest)).Returns(Task.FromResult(bearerTokenResponse));

            var controllerResult = await _controller.LoginAsync(userSaveRequest);

            _service.Verify(s => s.LoginAsync(userSaveRequest), Times.Once());
            Assert.NotNull(controllerResult);
            Assert.Equal(controllerResult, bearerTokenResponse);
        }

        [Fact]
        public async Task LoginAsync_ReturnsNull()
        {
            var userSaveRequest = UserBuilder.NewObject().SaveRequestBuild();
            _service.Setup(s => s.LoginAsync(userSaveRequest)).Returns(Task.FromResult<BearerTokenResponse>(null));

            var controllerResult = await _controller.LoginAsync(userSaveRequest);

            _service.Verify(s => s.LoginAsync(userSaveRequest), Times.Once());
            Assert.Null(controllerResult);
        }

        [Fact]
        public async Task GetCurrentLoggedInUserAsync_ReturnsEntity()
        {
            var userResponseClient = UserBuilder.NewObject().ResponseClientBuild();
            _service.Setup(s => s.GetUserByEmailAsync(_email)).Returns(Task.FromResult(userResponseClient));

            var controllerResult = await _controller.GetCurrentLoggedInUserAsync();

            _service.Verify(s => s.GetUserByEmailAsync(_email), Times.Once());
            Assert.NotNull(controllerResult);
            Assert.Equal(controllerResult, userResponseClient);
        }

        [Fact]
        public async Task GetCurrentLoggedInUserAsync_ReturnsNull()
        {
            _service.Setup(s => s.GetUserByEmailAsync(_email)).Returns(Task.FromResult<UserResponseClient>(null));

            var controllerResult = await _controller.GetCurrentLoggedInUserAsync();

            _service.Verify(s => s.GetUserByEmailAsync(_email), Times.Once());
            Assert.Null(controllerResult);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsTrue()
        {
            _service.Setup(s => s.DeleteAsync(_userId.ToString())).Returns(Task.FromResult(true));

            var controllerResult = await _controller.DeleteAsync(_userId.ToString());

            _service.Verify(s => s.DeleteAsync(_userId.ToString()), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsFalse()
        {
            _service.Setup(s => s.DeleteAsync(_userId.ToString())).Returns(Task.FromResult(false));

            var controllerResult = await _controller.DeleteAsync(_userId.ToString());

            _service.Verify(s => s.DeleteAsync(_userId.ToString()), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsTrue()
        {
            var userUpdateRequest = UserBuilder.NewObject().UpdateRequestBuild();
            _service.Setup(s => s.UpdateAsync(userUpdateRequest)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.UpdateAsync(userUpdateRequest);

            _service.Verify(s => s.UpdateAsync(userUpdateRequest), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsFalse()
        {
            var userUpdateRequest = UserBuilder.NewObject().UpdateRequestBuild();
            _service.Setup(s => s.UpdateAsync(userUpdateRequest)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.UpdateAsync(userUpdateRequest);

            _service.Verify(s => s.UpdateAsync(userUpdateRequest), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsEntity()
        {
            var userResponseList = new List<UserResponseClient>
            {
                UserBuilder.NewObject().ResponseClientBuild()
            };
            _service.Setup(s => s.FindAllEntitiesAsync()).Returns(Task.FromResult(userResponseList));

            var controllerResult = await _controller.GetAllAsync();

            _service.Verify(s => s.FindAllEntitiesAsync(), Times.Once());
            Assert.NotNull(controllerResult);
            Assert.Equal(controllerResult, userResponseList);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsNull()
        {
            _service.Setup(s => s.FindAllEntitiesAsync()).Returns(Task.FromResult<List<UserResponseClient>>(null));

            var controllerResult = await _controller.GetAllAsync();

            _service.Verify(s => s.FindAllEntitiesAsync(), Times.Once());
            Assert.Null(controllerResult);
        }

        [Fact]
        public async Task GetAllWithPaginationAsync_ReturnsEntity()
        {
            var pageParams = PageParamsBuilder.NewObject().DomainBuild();
            var userResponseClientList = new List<UserResponseClient>
            {
                UserBuilder.NewObject().ResponseClientBuild()
            };
            var userResponseClientPageList = Utils.PageListBuilder<UserResponseClient>(userResponseClientList);
            _service.Setup(s => s.FindAllEntitiesWithPaginationAsync(pageParams)).Returns(Task.FromResult(userResponseClientPageList));

            var controllerResult = await _controller.GetAllWithPaginationAsync(pageParams);

            _service.Verify(s => s.FindAllEntitiesWithPaginationAsync(pageParams), Times.Once());
            Assert.NotNull(controllerResult);
            Assert.Equal(controllerResult, userResponseClientPageList);
        }

        [Fact]
        public async Task GetAllWithPaginationAsync_ReturnsNull()
        {
            var pageParams = PageParamsBuilder.NewObject().DomainBuild();
            _service.Setup(s => s.FindAllEntitiesWithPaginationAsync(pageParams)).Returns(Task.FromResult<PageList<UserResponseClient>>(null));

            var controllerResult = await _controller.GetAllWithPaginationAsync(pageParams);

            _service.Verify(s => s.FindAllEntitiesWithPaginationAsync(pageParams), Times.Once());
            Assert.Null(controllerResult);
        }
    }
}

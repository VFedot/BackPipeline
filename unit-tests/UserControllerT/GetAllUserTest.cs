using KudosShop.Controllers;
using KudosShop.Models;
using KudosShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudosShopUnitTest.UserController
{
    class GetAllUserTest
    {
        [Test]
        public void GetAllUser_ListOfUsersIsEmpty_BadRequestNoUsers()
        {
            var mockUsersManagementService = new Mock<IUsersManagementService>();
            var usersController = new UsersController(mockUsersManagementService.Object);

            var expectedResult = new BadRequestObjectResult("NO USERS");


            var actualResult = usersController.GetAllUsers();
            var convertedResult = actualResult as BadRequestObjectResult;
            Assert.AreEqual(convertedResult.Value, expectedResult.Value);

        }

    }
}

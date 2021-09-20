using KudosShop.Models;
using KudosShop.Validations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudosShopUnitTest.Validations
{
    class VismaToPersonTransactionValidationTest
    {
        [Test]
        public void CheckValidation_UserIsExisting_UserExists()
        {
            User user = new User() { UserId = 1 };

            Response responsbuilder = new Response();
            var expectedResult = responsbuilder.ResponseBuild(0);

            VismaToPersonTransactionValidation validator = new VismaToPersonTransactionValidation();
            var actualResult = validator.CheckValidation(user);

            Assert.AreEqual(expectedResult.Code, actualResult.Code);
        }
        [Test]
        public void CheckValidation_UserIsNotExisting_UserDontExist()
        {
            User user = null;

            Response responsbuilder = new Response();
            var expectedResult = responsbuilder.ResponseBuild(3);

            VismaToPersonTransactionValidation validator = new VismaToPersonTransactionValidation();
            var actualResult = validator.CheckValidation(user);

            Assert.AreEqual(expectedResult.Code, actualResult.Code);
        }
    }
}

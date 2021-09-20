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
    class PersonToPersonTransactionInputValidatonTest
    {

        [Test]
        public void CheckValidation_SenderAndReceiverExists_UserExist()
        {
            User sender = new User() { UserId = 1 };
            User receiver = new User() { UserId = 2 };
            int kudosAmount = 10;

            Response responsbuilder = new Response();
            var expectedResult = responsbuilder.ResponseBuild(0);

            PersonToPersonTransactionInputValidation validator = new PersonToPersonTransactionInputValidation();
            var actualResult = validator.CheckValidation(sender, receiver, kudosAmount);

            Assert.AreEqual(expectedResult.Code, actualResult.Code);
            
        }
        [Test]
        public void CheckValidation_SenderExist_ReceiverDontExist_UserDontExist()
        {
            User sender = new User() { UserId = 1 };
            User receiver = null;
            int kudosAmount = 10;

            Response responsbuilder = new Response();
            var expectedResult = responsbuilder.ResponseBuild(2);

            PersonToPersonTransactionInputValidation validator = new PersonToPersonTransactionInputValidation();
            var actualResult = validator.CheckValidation(sender, receiver, kudosAmount);

            Assert.AreEqual(expectedResult.Code, actualResult.Code);
        }
        [Test]
        public void CheckValidation_SenderDontExist_ReceiverExist_UserDontExist()
        {
            User sender = null;
            User receiver = new User() { UserId = 1 };
            int kudosAmount = 10;

            Response responsbuilder = new Response();
            var expectedResult = responsbuilder.ResponseBuild(1);

            PersonToPersonTransactionInputValidation validator = new PersonToPersonTransactionInputValidation();
            var actualResult = validator.CheckValidation(sender, receiver, kudosAmount);

            Assert.AreEqual(expectedResult.Code, actualResult.Code);
        }
        [Test]
        public void CheckValidation_KudosAmountLessOrEqualsToZero_InvalidKudosAmountInput()
        {
            User sender = new User() { UserId = 1 };
            User receiver = new User() { UserId = 2 };
            int kudosAmount = -10;

            Response responsbuilder = new Response();
            var expectedResult = responsbuilder.ResponseBuild(4);

            PersonToPersonTransactionInputValidation validator = new PersonToPersonTransactionInputValidation();
            var actualResult = validator.CheckValidation(sender, receiver, kudosAmount);

            Assert.AreEqual(expectedResult.Code, actualResult.Code);
        }
    }
}

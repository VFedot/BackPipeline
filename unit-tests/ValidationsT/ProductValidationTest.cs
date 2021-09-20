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
    class ProductValidationTest
    {
        [Test]
        public void CheckValidation_ProductIsExistingAndIsAvalable_ProductExists()
        {
            Product product = new Product() { ProductId = 1, ProductIsAvailable = true };

            Response responsbuilder = new Response();
            var expectedResult = responsbuilder.ResponseBuild(0);

            ProductValidation validator = new ProductValidation();
            var actualResult = validator.CheckValidation(product);

            Assert.AreEqual(expectedResult.Code, actualResult.Code);
        }
        [Test]
        public void CheckValidation_ProductIsExistingAndNotAvailable_ProductIsNotAvalable()
        {
            Product product = new Product() { ProductId = 1, ProductIsAvailable = false };

            Response responsbuilder = new Response();
            var expectedResult = responsbuilder.ResponseBuild(8);

            ProductValidation validator = new ProductValidation();
            var actualResult = validator.CheckValidation(product);

            Assert.AreEqual(expectedResult.Code, actualResult.Code);
        }
        [Test]
        public void CheckValidation_ProductIsNotExisting_ProductDontExist()
        {
            Product product = null;

            Response responsbuilder = new Response();
            var expectedResult = responsbuilder.ResponseBuild(7);

            ProductValidation validator = new ProductValidation();
            var actualResult = validator.CheckValidation(product);

            Assert.AreEqual(expectedResult.Code, actualResult.Code);
        }
        [Test]
        public void CheckValidation_ProductIsNotAvailable_ProductIsNotAvailable()
        {
            Product product = new Product() { ProductId = 1, ProductIsAvailable = false };

            Response responsbuilder = new Response();
            var expectedResult = responsbuilder.ResponseBuild(8);

            ProductValidation validator = new ProductValidation();
            var actualResult = validator.CheckValidation(product);

            Assert.AreEqual(expectedResult.Code, actualResult.Code);
        }
    }
}

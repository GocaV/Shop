using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Core.Contracts;
using Shop.Core.Models;
using Shop.Core.ViewModels;
using Shop.WebUI.Controllers;

namespace Shop.WebUI.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IndexPageDoesReturnProducts()
        {
            IRepository<Product> productContext = new Mocks.MockContext<Product>();
            IRepository<ProductCategory> productCategoryCotext = new Mocks.MockContext<ProductCategory>();

            productContext.Insert(new Product());

            HomeController controller = new HomeController(productContext, productCategoryCotext);

            var result = controller.Index() as ViewResult;
            var viewModel = (ProductListViewModel)result.ViewData.Model;

            Assert.AreEqual(1, viewModel.Products.Count());
        }
    }
}
           

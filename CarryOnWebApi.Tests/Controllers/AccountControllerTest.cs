using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarryOnWebApi;
using CarryOnWebApi.Controllers;
using Services;
using DAL;
using Services.Interfaces;

namespace CarryOnWebApi.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        #region Private Variable

        IAccountService accountService;
        ITransportAvService transportAvService;
        IDalManager dbManager;
        private ILogService logger;
        private IConfigurationProvider configuration;

        #endregion

        #region Test Initialize

        [TestInitialize]
        public void TestInitialize()
        {
            dbManager = new DalManagerMock();
            this.configuration = new Configuration();
            this.logger = new Log4NetLogService(configuration);
            accountService = new AccountService(logger, dbManager);
            transportAvService = new TransportAvService(dbManager, logger);
        }

        #endregion


        [TestMethod]
        public void LoginTest()
        {
            // Arrange
            AccountController accountController = new AccountController(accountService, logger, configuration);

            // Act
            var result = accountController.Login(new Models.LoginViewModel {Username="Test", Password="test" });

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

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
using DAL.Helper;

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
            //dbManager = new DalManagerMock();
            dbManager = new DalManager();
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


        [TestMethod]
        public void CreateUser()
        {
            // Arrange
            AccountController accountController = new AccountController(accountService, logger, configuration);

            var user = MockUserHelper.getUser_feModel();

            /* set random data */
            user.ID = Guid.NewGuid();
            user.NOME = "test data";
            user.UTEN = "test_data_" + new Random().Next(1, int.MaxValue).ToString();

            // Act
            var result = accountController.CreateUser(user);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UpdateUser()
        {
            // Arrange
            AccountController accountController = new AccountController(accountService, logger, configuration);

            var user = MockUserHelper.getUser_feModel();

            /* set random data */
            string randValue = new Random().Next(1, int.MaxValue).ToString();
            user.ID = Guid.NewGuid();
            user.NOME = "test data";
            user.UTEN = "test_data_" + randValue;
            user.EMAI = randValue + user.EMAI;
            
            // first create user
            var result = accountController.CreateUser(user);
            Assert.IsNotNull(result);

            // then update create user
            var userToUpdate = result.ResultData;
            userToUpdate.TELE = "55779911";
            result = accountController.UpdateUser(user);
            Assert.IsNotNull(result);

            // then get user to have password
            result = accountController.Login(new Models.LoginViewModel {Username = user.UTEN, Password=user.PASS });
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ResultData.TELE = "55779911");
            
            // then delete create user
            //result = accountController.DeleteUser(user);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

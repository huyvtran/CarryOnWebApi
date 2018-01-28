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
using Entities;
using DAL.Helper;
using DAL.Mapper;

namespace CarryOnWebApi.Tests.Controllers
{
    [TestClass]
    public class ReqGoodTransferControllerTest
    {
        #region Private Variable

        IReqGoodTransferService reqGoodTransferService;
        IDalManager dbManager;
        private ILogService logger;
        private IConfigurationProvider configuration;
        IAccountService accountService;

        #endregion

        #region Test Initialize

        [TestInitialize]
        public void TestInitialize()
        {
            dbManager = new DalManager();
            this.configuration = new Configuration();
            this.logger = new Log4NetLogService(configuration);
            reqGoodTransferService = new ReqGoodTransferService(dbManager, logger);
            accountService = new AccountService(logger, dbManager);
        }

        #endregion

        [TestMethod]
        public void GetAllNoFilters()
        {
            // Arrange
            ReqGoodTransferController reqGoodTransferController = new ReqGoodTransferController(reqGoodTransferService, logger, configuration);

            // filter params
            var filterParams = new SearchRtFilter();

            // Act
            var result = reqGoodTransferController.FilteredRqgtList(filterParams);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetRqgtDetails()
        {
            // Arrange
            ReqGoodTransferController reqGoodTransferController = new ReqGoodTransferController(reqGoodTransferService, logger, configuration);

            // First Add user if not existing
            AccountController accountController = new AccountController(accountService, logger, configuration);
            var userToAdd = MockUserHelper.getUser_feModel();
            userToAdd.UserName = userToAdd.UserEmail;
            var userAddResult = accountController.CreateUser(userToAdd);
            /* Check if the user is already existing */
            if (userAddResult.OperationResult == false && userAddResult.ResultMessage == Entities.enums.ErrorsEnum.USERNAME_ALREADY_PRESENT) {
                userToAdd = accountService.GetUserByEmail(userToAdd.UserEmail);
            }
            Assert.IsNotNull(userAddResult);

            // First Insert Rqgt
            var rqgtToAddDb = MockHelper.getRqgtList().FirstOrDefault();
            rqgtToAddDb.UserId = userToAdd.UserId;
            rqgtToAddDb.UserName = userToAdd.UserName;
            rqgtToAddDb.UserEmail = userToAdd.UserEmail;
            if (rqgtToAddDb == null) {
                return;
            }
            var rqgtToAddModel = ReqGoodTransferMapper.ReqGoodTransfer_DbToModel(rqgtToAddDb);
            var addResult = reqGoodTransferController.Post(rqgtToAddModel);
            // Assert
            Assert.IsNotNull(addResult);
            Assert.IsTrue(addResult.OperationResult);

            // Get Rqgt Details
            var detailsResult = reqGoodTransferController.GetRqgtDetails(rqgtToAddModel.Id);

            // Assert
            Assert.IsNotNull(detailsResult);
            Assert.IsTrue(detailsResult.OperationResult);
        }

        //[TestMethod]
        //public void GetAllNoFilters()
        //{
        //    // Arrange
        //    ReqGoodTransferController reqGoodTransferController = new ReqGoodTransferController(reqGoodTransferService, logger, configuration);

        //    // Act
        //    var result = reqGoodTransferController.Get(null, null);

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        [TestMethod]
        public void GetOptions()
        {
            // Arrange
            ReqGoodTransferController reqGoodTransferController = new ReqGoodTransferController(reqGoodTransferService, logger, configuration);

            // Act
            var result = reqGoodTransferController.GetOptionsList(new Guid("d67cf6fb-7469-448c-9d4e-00ad01efb8da"));

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

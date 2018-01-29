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

        #region Get Filtered and not filtered list

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

        #endregion

        #region Utility Function

        private UserModel AddUser_ForTest()
        {
            AccountController accountController = new AccountController(accountService, logger, configuration);
            var userToAdd = MockUserHelper.getUser_feModel();
            userToAdd.UserName = userToAdd.UserEmail;
            var userAddResult = accountController.CreateUser(userToAdd);
            /* Check if the user is already existing */
            if (userAddResult.OperationResult == false && userAddResult.ResultMessage == Entities.enums.ErrorsEnum.USERNAME_ALREADY_PRESENT)
            {
                userToAdd = accountService.GetUserByEmail(userToAdd.UserEmail);
            }
            Assert.IsNotNull(userAddResult);
            return userToAdd;
        }

        private ReqGoodTransferModel AddRqgt_ForTest(UserModel userToAdd)
        {
            // Arrange
            ReqGoodTransferController reqGoodTransferController = new ReqGoodTransferController(reqGoodTransferService, logger, configuration);

            var rqgtToAddDb = MockHelper.getRqgtList().FirstOrDefault();
            rqgtToAddDb.UserId = userToAdd.UserId;
            rqgtToAddDb.UserName = userToAdd.UserName;
            rqgtToAddDb.UserEmail = userToAdd.UserEmail;
            if (rqgtToAddDb == null)
            {
                return null;
            }
            var rqgtToAddModel = ReqGoodTransferMapper.ReqGoodTransfer_DbToModel(rqgtToAddDb);
            rqgtToAddModel.ReqGoodTransportOpt = MockHelper.getTransportOpt();
            var addResult = reqGoodTransferController.Post(rqgtToAddModel);
            // Assert
            Assert.IsNotNull(addResult);
            Assert.IsTrue(addResult.OperationResult);

            return rqgtToAddModel;
        }

        #endregion

        #region Add-Create User

        [TestMethod]
        public void AddRqgt()
        {
            // Arrange
            ReqGoodTransferController reqGoodTransferController = new ReqGoodTransferController(reqGoodTransferService, logger, configuration);

            // First Add user if not existing
            var userToAdd = AddUser_ForTest();

            var rqgtToAddDb = MockHelper.getRqgtList().FirstOrDefault();
            rqgtToAddDb.UserId = userToAdd.UserId;
            rqgtToAddDb.UserName = userToAdd.UserName + new Random().Next(1, int.MaxValue).ToString().Substring(0, 5);
            rqgtToAddDb.UserEmail = userToAdd.UserName;
            Assert.IsNotNull(rqgtToAddDb);

            var rqgtToAddModel = ReqGoodTransferMapper.ReqGoodTransfer_DbToModel(rqgtToAddDb);
            rqgtToAddModel.ReqGoodTransportOpt = MockHelper.getTransportOpt();
            var addResult = reqGoodTransferController.Post(rqgtToAddModel);
            // Assert
            Assert.IsNotNull(addResult);
            Assert.IsTrue(addResult.OperationResult);
        }

        #endregion

        #region Get Rqgt

        [TestMethod]
        public void GetRqgtDetails()
        {
            // Arrange
            ReqGoodTransferController reqGoodTransferController = new ReqGoodTransferController(reqGoodTransferService, logger, configuration);

            // First Add user if not existing
            var userToAdd = AddUser_ForTest();

            // First Insert Rqgt
            var rqgtToAddModel = AddRqgt_ForTest(userToAdd);

            // Get Rqgt Details
            var detailsResult = reqGoodTransferController.GetRqgtDetails(rqgtToAddModel.Id);

            // Assert
            Assert.IsNotNull(detailsResult);
            Assert.IsTrue(detailsResult.OperationResult);
        }

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

        #endregion

        #region Delete Rqgt

        [TestMethod]
        public void DeleteRqgt()
        {
            // Arrange
            ReqGoodTransferController reqGoodTransferController = new ReqGoodTransferController(reqGoodTransferService, logger, configuration);

            // First Add user if not existing
            var userToAdd = AddUser_ForTest();

            // First Insert Rqgt
            var rqgtToAddModel = AddRqgt_ForTest(userToAdd);

            // Delete Rqgt
            var detailsResult = reqGoodTransferController.Delete(rqgtToAddModel.Id);

            // Assert
            Assert.IsNotNull(detailsResult);
            Assert.IsTrue(detailsResult.OperationResult);
        }

        #endregion

        #region Update Rqgt

        [TestMethod]
        public void UpdateRqgt()
        {
            // Arrange
            ReqGoodTransferController reqGoodTransferController = new ReqGoodTransferController(reqGoodTransferService, logger, configuration);

            // First Add user if not existing
            var userToAdd = AddUser_ForTest();

            // First Insert Rqgt
            var rqgtToAddModel = AddRqgt_ForTest(userToAdd);

            // Get Rqgt Details
            var detailsResult = reqGoodTransferController.GetRqgtDetails(rqgtToAddModel.Id);
            // Assert
            Assert.IsNotNull(detailsResult);
            Assert.IsTrue(detailsResult.OperationResult);

            // Update Rqgt
            var rqgtToUpdateModel = detailsResult.ResultData;
            rqgtToUpdateModel.DateTransportFixed = DateTime.Today.AddYears(1);
            rqgtToUpdateModel.DateTransportInfo = "UPDATED";
            rqgtToUpdateModel.UserLang = "UPDATED";
            rqgtToUpdateModel.UserTEL2 = "UPDATED";
            rqgtToUpdateModel.UserTELE = "UPDATED";
            rqgtToUpdateModel.UserEmail = "UPDATED";
            rqgtToUpdateModel.UserLang = "UPDATED";
            rqgtToUpdateModel.fromAddress.formatted_address = "UPDATED";
            rqgtToAddModel.destAddress.formatted_address = "UPDATED";
            var updatedResult = reqGoodTransferController.Put(rqgtToUpdateModel);

            // Assert
            Assert.IsNotNull(updatedResult);
            Assert.IsTrue(updatedResult.OperationResult);
        }

        #endregion

    }
}

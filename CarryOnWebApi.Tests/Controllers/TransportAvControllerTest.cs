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
    public class TransportAvControllerTest
    {
        #region Private Variable

        IReqGoodTransferService reqGoodTransferService;
        ITransportAvService transportAvService;
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
            transportAvService = new TransportAvService(dbManager, logger);
            accountService = new AccountService(logger, dbManager);
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

        private TransportAvModel AddTrAv_ForTest(UserModel userToAdd)
        {
            // Arrange
            TransportAvController trAvController = new TransportAvController(transportAvService, logger, configuration);

            var trAvToAddDb = MockHelper.getTransportAvList().FirstOrDefault();
            trAvToAddDb.UserId = userToAdd.UserId;
            trAvToAddDb.UserName = userToAdd.UserName;
            trAvToAddDb.UserEmail = userToAdd.UserEmail;
            if (trAvToAddDb == null)
            {
                return null;
            }
            var trAvToAddModel = TransportAvMapper.TransportAv_DbToModel(trAvToAddDb);
            trAvToAddModel.ReqGoodTransportOpt = MockHelper.getTransportOpt();
            var addResult = trAvController.PublishItem(trAvToAddModel);
            // Assert
            Assert.IsNotNull(addResult);
            Assert.IsTrue(addResult.OperationResult);

            return trAvToAddModel;
        }

        #endregion

        #region Get My Transport Availabilities

        [TestMethod]
        public void GetOnlyMyTrAv()
        {
            // Arrange
            TransportAvController trAvController = new TransportAvController(transportAvService, logger, configuration);

            // First Add user if not existing
            var userToAdd = AddUser_ForTest();

            // First Insert TrAv
            var trAvToAddModel = AddTrAv_ForTest(userToAdd);

            // filter params
            var filterParams = new SearchRtFilter();
            filterParams.TranspAvFilter = new TransportAvModel();
            filterParams.TranspAvFilter.UserId = userToAdd.UserId;

            // Act
            var result = trAvController.MyFilteredTrAv(filterParams);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ResultData.Count >0);
        }

        #endregion

        #region Get Filtered and not filtered list

        [TestMethod]
        public void GetAllNoFilters()
        {
            // Arrange
            TransportAvController trAvController = new TransportAvController(transportAvService, logger, configuration);

            // filter params
            var filterParams = new SearchRtFilter();

            // Act
            var result = trAvController.FilteredTrAv(filterParams);

            // Assert
            Assert.IsNotNull(result);
        }

        #endregion

        #region Add-Create User

        [TestMethod]
        public void AddTrAv()
        {
            // Arrange
            TransportAvController trAvController = new TransportAvController(transportAvService, logger, configuration);

            // First Add user if not existing
            var userToAdd = AddUser_ForTest();

            var trAvToAddDb = MockHelper.getTransportAvList().FirstOrDefault();
            trAvToAddDb.UserId = userToAdd.UserId;
            trAvToAddDb.UserName = userToAdd.UserName;
            trAvToAddDb.UserEmail = userToAdd.UserEmail;
            Assert.IsNotNull(trAvToAddDb);

            var trAvToAddModel = TransportAvMapper.TransportAv_DbToModel(trAvToAddDb);
            trAvToAddModel.ReqGoodTransportOpt = MockHelper.getTransportOpt();
            var addResult = trAvController.PublishItem(trAvToAddModel);
            // Assert
            Assert.IsNotNull(addResult);
            Assert.IsTrue(addResult.OperationResult);
        }

        #endregion

        #region Get TrAv

        [TestMethod]
        public void GetTrAvDetails()
        {
            // Arrange
            TransportAvController trAvController = new TransportAvController(transportAvService, logger, configuration);

            // First Add user if not existing
            var userToAdd = AddUser_ForTest();

            // First Insert TrAv
            var trAvToAddModel = AddTrAv_ForTest(userToAdd);

            // Get TrAv Details
            var detailsResult = trAvController.GetTrAvDetails(trAvToAddModel.Id);

            // Assert
            Assert.IsNotNull(detailsResult);
            Assert.IsTrue(detailsResult.OperationResult);
        }

        #endregion

        #region Delete TrAv

        [TestMethod]
        public void DeleteTrAv()
        {
            // Arrange
            TransportAvController trAvController = new TransportAvController(transportAvService, logger, configuration);

            // First Add user if not existing
            var userToAdd = AddUser_ForTest();

            // First Insert TrAv
            var trAvToAddModel = AddTrAv_ForTest(userToAdd);

            // Delete TrAv
            var detailsResult = trAvController.Delete(trAvToAddModel.Id);

            // Assert
            Assert.IsNotNull(detailsResult);
            Assert.IsTrue(detailsResult.OperationResult);
        }

        #endregion

        #region Update TrAv

        [TestMethod]
        public void UpdateTrAv()
        {
            // Arrange
            TransportAvController trAvController = new TransportAvController(transportAvService, logger, configuration);

            // First Add user if not existing
            var userToAdd = AddUser_ForTest();

            // First Insert TrAv
            var trAvToAddModel = AddTrAv_ForTest(userToAdd);

            // Get TrAv Details
            var detailsResult = trAvController.GetTrAvDetails(trAvToAddModel.Id);
            // Assert
            Assert.IsNotNull(detailsResult);
            Assert.IsTrue(detailsResult.OperationResult);

            // Update TrAv
            var trAvToUpdateModel = detailsResult.ResultData;
            trAvToUpdateModel.DateTransportFixed = DateTime.Today.AddYears(1);
            trAvToUpdateModel.DateTransportInfo = "UPDATED";
            trAvToUpdateModel.UserLang = "UPDATED";
            trAvToUpdateModel.UserTEL2 = "UPDATED";
            trAvToUpdateModel.UserTELE = "UPDATED";
            trAvToUpdateModel.UserEmail = "UPDATED";
            trAvToUpdateModel.UserLang = "UPDATED";
            trAvToUpdateModel.fromAddress.formatted_address = "UPDATED";
            trAvToUpdateModel.fromAddress.geometry.location.lat = "UPDATED";
            trAvToUpdateModel.fromAddress.geometry.location.lng = "UPDATED";
            trAvToUpdateModel.destAddress.formatted_address = "UPDATED";
            trAvToUpdateModel.destAddress.geometry.location.lat = "UPDATED";
            trAvToUpdateModel.destAddress.geometry.location.lng = "UPDATED";
            if (trAvToUpdateModel.ReqGoodTransportOpt != null)
            {
                /* Add ReqGoodTransfer options items */
                foreach (var optItem in trAvToUpdateModel.ReqGoodTransportOpt)
                {
                    optItem.OptValue = "UPDATED";
                }
            }

            var updatedResult = trAvController.Put(trAvToUpdateModel);
                        
            // Assert
            Assert.IsNotNull(updatedResult);
            Assert.IsTrue(updatedResult.OperationResult);

            // Get TrAv Details after upload
            var afterUpdateResult = trAvController.GetTrAvDetails(trAvToUpdateModel.Id);
            // Assert
            Assert.IsNotNull(afterUpdateResult);
            Assert.IsTrue(afterUpdateResult.OperationResult);
            var updatedData = afterUpdateResult.ResultData;
            Assert.AreEqual(updatedData.DateTransportInfo, "UPDATED");
            Assert.AreEqual(updatedData.fromAddress.formatted_address, "UPDATED");
            Assert.AreEqual(updatedData.fromAddress.geometry.location.lat, "UPDATED");
            Assert.AreEqual(updatedData.fromAddress.geometry.location.lng, "UPDATED");
            Assert.AreEqual(updatedData.destAddress.formatted_address, "UPDATED");
            Assert.AreEqual(updatedData.destAddress.geometry.location.lat, "UPDATED");
            Assert.AreEqual(updatedData.destAddress.geometry.location.lng, "UPDATED");
            Assert.IsNotNull(updatedData.ReqGoodTransportOpt);
            Assert.IsTrue(updatedData.ReqGoodTransportOpt.Count>0);
            foreach (var optItem in updatedData.ReqGoodTransportOpt)
            {
                Assert.AreEqual(optItem.OptValue, "UPDATED");
            }
        }

        #endregion
    }
}

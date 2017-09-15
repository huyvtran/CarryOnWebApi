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
    public class ReqGoodTransferControllerTest
    {
        #region Private Variable

        IReqGoodTransferService reqGoodTransferService;
        IDalManager dbManager;
        private ILogService logger;
        private IConfigurationProvider configuration;

        #endregion

        #region Test Initialize

        [TestInitialize]
        public void TestInitialize()
        {
            dbManager = new DalManager();
            this.configuration = new Configuration();
            this.logger = new Log4NetLogService(configuration);
            reqGoodTransferService = new ReqGoodTransferService(dbManager, logger);
        }

        #endregion


        [TestMethod]
        public void GetAllNoFilters()
        {
            // Arrange
            ReqGoodTransferController reqGoodTransferController = new ReqGoodTransferController(reqGoodTransferService, logger, configuration);

            // Act
            var result = reqGoodTransferController.Get(null, null);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

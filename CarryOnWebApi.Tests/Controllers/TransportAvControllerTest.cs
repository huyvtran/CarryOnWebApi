﻿using System;
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
    public class TransportAvControllerTest
    {
        #region Private Variable

        IReqGoodTransferService reqGoodTransferService;
        ITransportAvService transportAvService;
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
            transportAvService = new TransportAvService(dbManager, logger);
        }

        #endregion


        [TestMethod]
        public void GetAllNoFilters()
        {
            // Arrange
            TransportAvController transportAvController = new TransportAvController(transportAvService, logger, configuration);

            // Act
            var result = transportAvController.Get(null);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
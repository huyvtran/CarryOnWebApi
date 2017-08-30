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

        #endregion

        #region Test Initialize

        [TestInitialize]
        public void TestInitialize()
        {
            dbManager = new DalManager();
            reqGoodTransferService = new ReqGoodTransferService(dbManager);
        }

        #endregion


        [TestMethod]
        public void GetAllNoFilters()
        {
            // Arrange
            ReqGoodTransferController reqGoodTransferController = new ReqGoodTransferController(reqGoodTransferService);

            // Act
            var result = reqGoodTransferController.Get(null);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

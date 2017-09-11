using CarryOnWebApi.CustomAttributes;
using CarryOnWebApi.Models;
using Entities;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace CarryOnWebApi.Controllers
{
    public class ReqGoodTransferController : ApiController
    {
        private readonly IReqGoodTransferService _reqGoodTransferService;
        private ILogService logger;
        private IConfigurationProvider configuration = null;

        public ReqGoodTransferController() { }

        public ReqGoodTransferController(IReqGoodTransferService reqGoodTransferService, ILogService logger,
            IConfigurationProvider _config)
        {
            _reqGoodTransferService = reqGoodTransferService;
            this.logger = logger;
            configuration = _config;
        }

        // GET: api/ReqGoodTransfer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //[AuthorizeUser]
        public ResultModel<List<ReqGoodTransferModel>> Get(Guid? id)
        {
            logger.LogApi(() => Get(id), null);

            var resultModel = new ResultModel<List<ReqGoodTransferModel>>();
            resultModel.ResultData = _reqGoodTransferService.GetReqGoodTransfer(id);

            /* Return data */
            resultModel.OperationResult = true;
            return resultModel;
        }

        [AuthorizeUser]
        [HttpPost]

        public ResultModel<List<ReqGoodTransferModel>> GetFiltered(FilterParams filterparams)
        {
            logger.LogApi(() => GetFiltered(filterparams), null);

            var resultModel = new ResultModel<List<ReqGoodTransferModel>>();

            /* TO BE DEVELOPED */
            resultModel.ResultData = _reqGoodTransferService.GetReqGoodTransfer(null);

            /* Return data */
            resultModel.OperationResult = true;
            return resultModel;
        }

        // POST: api/ReqGoodTransfer
        [AuthorizeUser]
        [HttpPost]
        public BaseResultModel Post(ReqGoodTransferModel rqtModel)
        {
            //var user = RouteData.Values["user"] as UserModel;
            var user = configuration.UserInfo;

            logger.LogApi(() => Post(rqtModel), user.UTEN);

            var resultModel = _reqGoodTransferService.InsertReqGoodTransfer(rqtModel, user);

            /* Return data */
            return resultModel;
        }

        // PUT: api/ReqGoodTransfer/5
        [AuthorizeUser]
        [HttpPut]
        public BaseResultModel Put(ReqGoodTransferModel rqtModel)
        {
            var user = configuration.UserInfo;
            logger.LogApi(() => Put(rqtModel), user.UTEN);

            var resultModel = _reqGoodTransferService.UpdateReqGoodTransfer(rqtModel, user);

            /* Return data */
            return resultModel;
        }

        // DELETE: api/ReqGoodTransfer/5
        [AuthorizeUser]
        [HttpDelete]
        public BaseResultModel Delete(Guid rgtId)
        {
            var user = configuration.UserInfo;
            logger.LogApi(() => Delete(rgtId), user.UTEN);

            var resultModel = _reqGoodTransferService.DeleteReqGoodTransfer(rgtId, user);

            return resultModel;
        }
    }
}

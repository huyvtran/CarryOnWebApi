using CarryOnWebApi.CustomAttributes;
using CarryOnWebApi.Models;
using CarryOnWebApi.Utility;
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

        [HttpPost]
        //[AuthorizeUser]
        [Route("api/ReqGoodTransfer/FilteredRqgtList")]
        public ResultModel<List<ReqGoodTransferModel>> FilteredRqgtList(SearchRtFilter filterparams)
        {
            logger.LogApi(() => FilteredRqgtList(filterparams), null);

            var resultModel = new ResultModel<List<ReqGoodTransferModel>>();
            
            resultModel.ResultData = _reqGoodTransferService.GetReqGoodTransferList(filterparams);

            /* Return data */
            resultModel.OperationResult = true;
            return resultModel;
        }

        [HttpPost]
        //[AuthorizeUser]
        [Route("api/ReqGoodTransfer/MyFilteredTrAv")]
        public ResultModel<List<ReqGoodTransferModel>> MyFilteredRqgtList(SearchRtFilter filterparams)
        {
            logger.LogApi(() => FilteredRqgtList(filterparams), null);

            var resultModel = new ResultModel<List<ReqGoodTransferModel>>();

            Guid? _userId = (filterparams != null && filterparams.RqgtFilter != null && (filterparams.RqgtFilter.UserId != Guid.Empty)) ? (Guid?)filterparams.RqgtFilter.UserId : null;
            resultModel.ResultData = _reqGoodTransferService.MyGetReqGoodTransferList(_userId);

            /* Return data */
            resultModel.OperationResult = true;
            return resultModel;
        }

        [AuthorizeUser]
        //[HttpPost]
        [Route("api/ReqGoodTransfer/GetRqgtDetails")]
        public ResultModel<ReqGoodTransferModel> GetRqgtDetails(Guid _id)
        {
            logger.LogApi(() => GetRqgtDetails(_id), null);

            var resultModel = new ResultModel<ReqGoodTransferModel>();
            
            resultModel.ResultData = _reqGoodTransferService.GetReqGoodTransferDetails(_id);

            /* Return data */
            resultModel.OperationResult = true;
            return resultModel;
        }

        //[Route("api/ReqGoodTransfer/UserTestModel")]
        //[HttpPost]
        //public IEnumerable<UserTestModel> ObtainUserTestModel()
        //{
        //    return new List<UserTestModel> {
        //        new UserTestModel {
        //            Name = "Mario",
        //            Surename = "Rossi",
        //            Telephone = "0514578965",
        //        },
        //        new UserTestModel {
        //            Name = "Marco",
        //            Surename = "Lolli",
        //            Telephone = "875489632",
        //        }
        //    };
        //}

        [Route("api/ReqGoodTransfer/GetOptionsList")]
        //[AuthorizeUser]
        public ResultModel<Dictionary<string, string>> GetOptionsList(Guid? id)
        {
            logger.LogApi(() => GetOptionsList(id), null);

            var resultModel = new ResultModel<Dictionary<string, string>>();
            resultModel.ResultData = _reqGoodTransferService.GetOptionsList(id);

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
            var user = SharedConfig.UserInfo ?? UtilityHelper.getStandardUser();

            logger.LogApi(() => Post(rqtModel), user.UserEmail);

            var resultModel = _reqGoodTransferService.InsertReqGoodTransfer(rqtModel, user);

            /* Return data */
            return resultModel;
        }

        // PUT: api/ReqGoodTransfer/5
        [AuthorizeUser]
        [HttpPut]
        public BaseResultModel Put(ReqGoodTransferModel rqtModel)
        {
            var user = SharedConfig.UserInfo ?? UtilityHelper.getStandardUser();
            logger.LogApi(() => Put(rqtModel), user.UserEmail);

            var resultModel = _reqGoodTransferService.UpdateReqGoodTransfer(rqtModel, user);

            /* Return data */
            return resultModel;
        }

        // DELETE: api/ReqGoodTransfer/5
        [AuthorizeUser]
        [HttpDelete]
        public BaseResultModel Delete(Guid rgtId)
        {
            var user = SharedConfig.UserInfo ?? UtilityHelper.getStandardUser();
            logger.LogApi(() => Delete(rgtId), user.UserEmail);

            var resultModel = _reqGoodTransferService.DeleteReqGoodTransfer(rgtId, user);

            return resultModel;
        }
    }
}

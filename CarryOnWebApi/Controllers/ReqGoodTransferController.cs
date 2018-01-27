﻿using CarryOnWebApi.CustomAttributes;
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
        
        [Route("api/ReqGoodTransfer/Get")]
        //[AuthorizeUser]
        //public ResultModel<List<ReqGoodTransferModel>> Get(Guid? id, Guid? userId)
        //{
        //    logger.LogApi(() => Get(id, userId), null);

        //    var resultModel = new ResultModel<List<ReqGoodTransferModel>>();
        //    resultModel.ResultData = _reqGoodTransferService.GetReqGoodTransfer(id, userId);

        //    /* Return data */
        //    resultModel.OperationResult = true;
        //    return resultModel;
        //}
        public List<UserTestModel> Get(Guid? id, Guid? userId)
        {
            return new List<UserTestModel> {
                new UserTestModel {
                    Name = "Mario",
                    Surename = "Rossi",
                    Telephone = "0514578965",
                },
                new UserTestModel {
                    Name = "Marco",
                    Surename = "Lolli",
                    Telephone = "875489632",
                }
            };
        }

        //[AuthorizeUser]
        [HttpPost]

        [Route("api/ReqGoodTransfer/FilteredRqgt")]
        public ResultModel<List<ReqGoodTransferModel>> FilteredRqgt(SearchRtFilter filterparams)
        {
            logger.LogApi(() => FilteredRqgt(filterparams), null);

            var resultModel = new ResultModel<List<ReqGoodTransferModel>>();

            /* TO BE DEVELOPED */
            Guid? _id = (filterparams != null && filterparams.RqgtFilter != null) ? (Guid?)filterparams.RqgtFilter.Id : null;
            Guid? _userId = (filterparams != null && filterparams.RqgtFilter != null) ? (Guid?)filterparams.RqgtFilter.UserId : null;
            resultModel.ResultData = _reqGoodTransferService.GetReqGoodTransfer(_id, _userId);

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
            var user = SharedConfig.UserInfo;

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
            var user = SharedConfig.UserInfo;
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
            var user = SharedConfig.UserInfo;
            logger.LogApi(() => Delete(rgtId), user.UserEmail);

            var resultModel = _reqGoodTransferService.DeleteReqGoodTransfer(rgtId, user);

            return resultModel;
        }
    }
}

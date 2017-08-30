using CarryOnWebApi.CustomAttributes;
using Entities;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarryOnWebApi.Controllers
{
    public class ReqGoodTransferController : BaseController
    {
        private readonly IReqGoodTransferService _reqGoodTransferService;

        public ReqGoodTransferController(IReqGoodTransferService reqGoodTransferService)
        {
            _reqGoodTransferService = reqGoodTransferService;
        }

        // GET: api/ReqGoodTransfer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [AuthorizeByToken]

        public ResultModel<List<ReqGoodTransferModel>> Get(Guid? id)
        {
            var resultModel = new ResultModel<List<ReqGoodTransferModel>>();
            resultModel.ResultData = _reqGoodTransferService.GetReqGoodTransfer(id);

            /* Return data */
            resultModel.OperationResult = true;
            return resultModel;
        }

        [AuthorizeByToken]
        [HttpPost]

        public ResultModel<List<ReqGoodTransferModel>> GetFiltered(FilterParams filterparams)
        {
            var resultModel = new ResultModel<List<ReqGoodTransferModel>>();

            /* TO BE DEVELOPED */
            resultModel.ResultData = _reqGoodTransferService.GetReqGoodTransfer(null);

            /* Return data */
            resultModel.OperationResult = true;
            return resultModel;
        }

        // POST: api/ReqGoodTransfer
        [AuthorizeByToken]
        [HttpPost]
        public BaseResultModel Post(ReqGoodTransferModel rqtModel)
        {
            var user = RouteData.Values["user"] as UserModel;
            var resultModel = _reqGoodTransferService.InsertReqGoodTransfer(rqtModel, user);

            /* Return data */
            return resultModel;
        }

        // PUT: api/ReqGoodTransfer/5
        [AuthorizeByToken]
        [HttpPut]
        public BaseResultModel Put(ReqGoodTransferModel rqtModel)
        {
            var user = RouteData.Values["user"] as UserModel;
            var resultModel = _reqGoodTransferService.UpdateReqGoodTransfer(rqtModel, user);

            /* Return data */
            return resultModel;
        }

        // DELETE: api/ReqGoodTransfer/5
        [AuthorizeByToken]
        [HttpDelete]
        public BaseResultModel Delete(Guid rgtId)
        {
            var user = RouteData.Values["user"] as UserModel;
            var resultModel = _reqGoodTransferService.DeleteReqGoodTransfer(rgtId);

            return resultModel;
        }
    }
}

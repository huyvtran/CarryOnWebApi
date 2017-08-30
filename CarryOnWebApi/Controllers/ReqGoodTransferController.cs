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

        // POST: api/ReqGoodTransfer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ReqGoodTransfer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ReqGoodTransfer/5
        public void Delete(int id)
        {
        }
    }
}

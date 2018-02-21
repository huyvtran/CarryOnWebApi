using CarryOnWebApi.CustomAttributes;
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
    public class TransportAvController : ApiController
    {
        private readonly ITransportAvService _transportAvService;
        private ILogService logger;
        private IConfigurationProvider configuration = null;

        public TransportAvController() { }

        public TransportAvController(ITransportAvService transportAvService, ILogService logger,
            IConfigurationProvider _config)
        {
            _transportAvService = transportAvService;
            this.logger = logger;
            configuration = _config;
        }
        
        //[AuthorizeUser]
        //[Route("api/TransportAv/Get")]
        //public ResultModel<List<TransportAvModel>> Get(Guid? id, Guid? userId)
        //{
        //    logger.LogApi(() => Get(id, userId), null);

        //    var resultModel = new ResultModel<List<TransportAvModel>>();
        //    resultModel.ResultData = _transportAvService.GetTransportAv(id, userId);

        //    /* Return data */
        //    resultModel.OperationResult = true;
        //    return resultModel;
        //}

        [HttpPost]

        [Route("api/TransportAv/FilteredTrAv")]
        public ResultModel<List<TransportAvModel>> FilteredTrAv(SearchRtFilter filterparams)
        {
            logger.LogApi(() => FilteredTrAv(filterparams), null);

            var resultModel = new ResultModel<List<TransportAvModel>>();

            /* TO BE DEVELOPED */
            resultModel.ResultData = _transportAvService.GetTransportAv(filterparams);

            /* Return data */
            resultModel.OperationResult = true;
            return resultModel;
        }

        [Route("api/TransportAv/MyFilteredRqgtList")]
        public ResultModel<List<TransportAvModel>> MyFilteredTrAv(SearchRtFilter filterparams)
        {
            logger.LogApi(() => FilteredTrAv(filterparams), null);

            var resultModel = new ResultModel<List<TransportAvModel>>();
            
            Guid? _userId = (filterparams != null && filterparams.TranspAvFilter != null && (filterparams.TranspAvFilter.UserId != Guid.Empty)) ? (Guid?)filterparams.TranspAvFilter.UserId : null;
            resultModel.ResultData = _transportAvService.MyGetTransportAv(_userId);

            /* Return data */
            resultModel.OperationResult = true;
            return resultModel;
        }

        [AuthorizeUser]
        //[HttpPost]
        [Route("api/ReqGoodTransfer/GetTrAvDetails")]
        public ResultModel<TransportAvModel> GetTrAvDetails(Guid _id)
        {
            logger.LogApi(() => GetTrAvDetails(_id), null);

            var resultModel = new ResultModel<TransportAvModel>();

            resultModel.ResultData = _transportAvService.GetTrAvDetails(_id);

            /* Return data */
            resultModel.OperationResult = true;
            return resultModel;
        }

        // POST: api/TransportAv
        [AuthorizeUser]
        [HttpPost]
        [Route("api/TransportAv/PublishItem")]
        public BaseResultModel PublishItem(TransportAvModel rqtModel)
        {
            //var user = RouteData.Values["user"] as UserModel;
            var user = SharedConfig.UserInfo ?? UtilityHelper.getStandardUser();

            logger.LogApi(() => PublishItem(rqtModel), user.UserEmail);

            var resultModel = _transportAvService.InsertTransportAv(rqtModel, user);

            /* Return data */
            return resultModel;
        }

        // PUT: api/TransportAv/5
        [AuthorizeUser]
        [HttpPut]
        public BaseResultModel Put(TransportAvModel rqtModel)
        {
            var user = SharedConfig.UserInfo ?? UtilityHelper.getStandardUser();
            logger.LogApi(() => Put(rqtModel), user.UserEmail);

            var resultModel = _transportAvService.UpdateTransportAv(rqtModel, user);

            /* Return data */
            return resultModel;
        }

        // DELETE: api/TransportAv/5
        [AuthorizeUser]
        [HttpDelete]
        public BaseResultModel Delete(Guid rgtId)
        {
            var user = SharedConfig.UserInfo ?? UtilityHelper.getStandardUser();
            logger.LogApi(() => Delete(rgtId), user.UserEmail);

            var resultModel = _transportAvService.DeleteTransportAv(rgtId, user);

            return resultModel;
        }
    }
}

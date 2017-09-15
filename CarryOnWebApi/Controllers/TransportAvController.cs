using CarryOnWebApi.CustomAttributes;
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
        [Route("api/TransportAv/Get")]
        public ResultModel<List<TransportAvModel>> Get(Guid? id, Guid? userId)
        {
            logger.LogApi(() => Get(id, userId), null);

            var resultModel = new ResultModel<List<TransportAvModel>>();
            resultModel.ResultData = _transportAvService.GetTransportAv(id, userId);

            /* Return data */
            resultModel.OperationResult = true;
            return resultModel;
        }

        [AuthorizeUser]
        [HttpPost]

        [Route("api/TransportAv/FilteredTrAv")]
        public ResultModel<List<TransportAvModel>> FilteredTrAv(SearchRtFilter filterparams)
        {
            logger.LogApi(() => FilteredTrAv(filterparams), null);

            var resultModel = new ResultModel<List<TransportAvModel>>();

            /* TO BE DEVELOPED */
            Guid? _id = (filterparams != null && filterparams.TranspAvFilter != null) ? (Guid?)filterparams.TranspAvFilter.Id : null;
            Guid? _userId = (filterparams != null && filterparams.TranspAvFilter != null) ? (Guid?)filterparams.TranspAvFilter.UserId : null;
            resultModel.ResultData = _transportAvService.GetTransportAv(_id, _userId);

            /* Return data */
            resultModel.OperationResult = true;
            return resultModel;
        }

        // POST: api/TransportAv
        [AuthorizeUser]
        [HttpPost]
        public BaseResultModel Post(TransportAvModel rqtModel)
        {
            //var user = RouteData.Values["user"] as UserModel;
            var user = configuration.UserInfo;

            logger.LogApi(() => Post(rqtModel), user.UTEN);

            var resultModel = _transportAvService.InsertTransportAv(rqtModel, user);

            /* Return data */
            return resultModel;
        }

        // PUT: api/TransportAv/5
        [AuthorizeUser]
        [HttpPut]
        public BaseResultModel Put(TransportAvModel rqtModel)
        {
            var user = configuration.UserInfo;
            logger.LogApi(() => Put(rqtModel), user.UTEN);

            var resultModel = _transportAvService.UpdateTransportAv(rqtModel, user);

            /* Return data */
            return resultModel;
        }

        // DELETE: api/TransportAv/5
        [AuthorizeUser]
        [HttpDelete]
        public BaseResultModel Delete(Guid rgtId)
        {
            var user = configuration.UserInfo;
            logger.LogApi(() => Delete(rgtId), user.UTEN);

            var resultModel = _transportAvService.DeleteTransportAv(rgtId, user);

            return resultModel;
        }
    }
}

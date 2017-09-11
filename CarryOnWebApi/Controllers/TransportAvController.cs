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

        // GET: api/TransportAv
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //[AuthorizeUser]
        public ResultModel<List<TransportAvModel>> Get(Guid? id)
        {
            logger.LogApi(() => Get(id), null);

            var resultModel = new ResultModel<List<TransportAvModel>>();
            resultModel.ResultData = _transportAvService.GetTransportAv(id);

            /* Return data */
            resultModel.OperationResult = true;
            return resultModel;
        }

        [AuthorizeUser]
        [HttpPost]

        public ResultModel<List<TransportAvModel>> GetFiltered(FilterParams filterparams)
        {
            logger.LogApi(() => GetFiltered(filterparams), null);

            var resultModel = new ResultModel<List<TransportAvModel>>();

            /* TO BE DEVELOPED */
            resultModel.ResultData = _transportAvService.GetTransportAv(null);

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

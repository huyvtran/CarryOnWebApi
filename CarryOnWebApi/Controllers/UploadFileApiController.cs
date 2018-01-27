using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using CarryOnWebApi.Models;
using CarryOnWebApi.Providers;
using CarryOnWebApi.Results;
using Services.Interfaces;
using Entities.enums;
using Entities;
using CarryOnWebApi.CustomAttributes;
//using System.Web.Mvc;
//using System.Web.Http.Results;

namespace CarryOnWebApi.Controllers
{
    public class UploadFileApiController : ApiController
    {
        [HttpPost]
        public BaseResultModel UploadJsonFile()
        {
            var ret = new BaseResultModel { OperationResult = true };
            HttpResponseMessage response = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/UploadFile/" + postedFile.FileName);
                    //postedFile.SaveAs(filePath);
                }
            }
            return ret;
        }
    }
}

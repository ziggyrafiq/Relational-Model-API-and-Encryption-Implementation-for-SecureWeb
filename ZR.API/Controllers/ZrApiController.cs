/************************************************************************************************************
*  COPYRIGHT BY ZIGGY RAFIQ (ZAHEER RAFIQ)
*  LinkedIn Profile URL Address: https://www.linkedin.com/in/ziggyrafiq/ 
*
*  System   :  	ZR Demo Project 01 - Book Api
*  Date     :  	25/09/2022
*  Author   :  	Ziggy Rafiq (https://www.ziggyrafiq.com)
*  Notes    :  	
*  Reminder :	PLEASE DO NOT CHANGE OR REMOVE AUTHOR NAME.
*
************************************************************************************************************/

using ZR.API.Extensions;
using ZR.Business.Security;
using ZR.Business.Security.Interfaces;
using ZR.Business.Services.Interfaces;
using ZR.Resources.Extensions;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ZR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZrApiController : BaseApiController
    {


        private readonly ILoggerManagerService _logger;
        private readonly IDataProtector _dataProtector;
        private readonly IRsaCryptograper _rsaCryptograper;
        

        public ZrApiController(ILoggerManagerService loggerManagerService, IRsaCryptograper rsaCryptograper)
        {
            _logger = loggerManagerService;
            _rsaCryptograper = rsaCryptograper;
            //_dataProtector = dataProtectionProvider.CreateProtector(GetType().FullName);

            // _rsaCryptograper = rsaCryptograper;
        }


        /// <summary>
        /// This is just a Mock Up Api Call
        /// </summary>
        /// <response code="200">Return All Data/response>
        /// <response code="404">No Data Found</response>
        /// <response code="500">Internal Error</response>
         [HttpGet]
        [Route("/IS")]
        [SwaggerOperation("GetAll")]
 
        public virtual IActionResult GetAll([FromQuery] string? something)
        {
            // DpApiCryptographer dpApiCryptographer = new DpApiCryptographer();


            //string ziggy = dpApiCryptographer.Encrypt(something);
            var ziggy = _rsaCryptograper.Encrypt(something);






            return StatusCode(200, ziggy);

        }
    }
}
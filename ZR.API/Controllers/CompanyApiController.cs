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


using ZR.API.DataContracts;
using ZR.API.Extensions;
using ZR.Business.Services.Interfaces;
using ZR.Infrastructure.Models;
using ZR.API.DataContracts;
using ZR.Resources.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using ZR.Business.Security.Interfaces;
using Newtonsoft.Json;

namespace ZR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyApiController : BaseApiController
    {
        private readonly ILoggerManagerService _logger;
        private readonly IRsaCryptograper _rsaCryptograper;

        public CompanyApiController(ILoggerManagerService loggerManagerService, IRsaCryptograper rsaCryptograper)
        {
            _logger = loggerManagerService;
            _rsaCryptograper = rsaCryptograper; 

        }


        [HttpGet("GetAll")]
        [SwaggerOperation("GetAll")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Company>), description: "Success")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(List<Company>), description: "Internal Error")]
        public async Task<IActionResult> Get(string? test)
        {
            var data = await _Services.Service<ICompanyService>().AsyncGetAll();

            if (!string.IsNullOrWhiteSpace(test))
            {
                var enData = _rsaCryptograper.Encrypt(test);
                var deData = _rsaCryptograper.Decrypt(enData);
                _logger.LogInfo("All companies fetched from the database");

                return StatusCode(200, deData);
            }
            else
            {
                List<Company> jsonData = new List<Company>();
                jsonData.AddRange(data.ToList());
                

                
                 
                

                var enData = _rsaCryptograper.Encrypt(jsonData.ToString());
                var deData = _rsaCryptograper.Decrypt(enData);
                _logger.LogInfo("All companies fetched from the database");

                return StatusCode(200, deData);
            } 
        }




        [SwaggerOperation("Get All Companies Show Not Encrypted")]
        [HttpGet("GetAllNotEncrypted")]
        public async Task<IActionResult> GetAllNotEncrypted()
        {

            var data = await _Services.Service<ICompanyService>().AsyncGetAll();
            //var enData = _rsaCryptograper.Encrypt(data.ToString());
            _logger.LogInfo("All companies fetched from the database");

            return StatusCode(200, data);

        }

        [SwaggerOperation("Get Data and Decrypted It")]
        [HttpGet("GetDataAndDecrypted")]
        public async Task<IActionResult> GetDataAndDecrypted(string data)
        {

           // var data = await _Services.Service<ICompanyService>().AsyncGetAll();
            var enData = _rsaCryptograper.Decrypt(data.ToString());
            _logger.LogInfo("All companies fetched from the database");
            List<CompanyDto> jsonData = new List<CompanyDto>();
            jsonData = JsonConvert.DeserializeObject<List<CompanyDto>>(enData);
            string data1 = enData;
            return StatusCode(200, jsonData);

        }


        [HttpGet("{id}")]
        [SwaggerOperation("GeyByID")]
        [SwaggerResponse(statusCode: 200, type: typeof(Company), description: "Success")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == null)
            {
                _logger.LogError("Company ID t sent from client is null.");
                return BadRequest("Company ID object is null");
            }

            var data = await _Services.Service<ICompanyService>().AsyncGetById(id);
            _logger.LogInfo($"Company Data by Id {id} fetched from the database");
            return StatusCode(200, data);
            
        }


        
        [HttpPost]
        [SwaggerOperation("Add New Company")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto data)
        {
            if (data == null)
            {
                _logger.LogError("CompanyForCreationDto object sent from client is null.");
                return BadRequest("CompanyForCreationDto object is null");
            }

            await _Services.Service<ICompanyService>().AsyncAdd(data);
            _logger.LogInfo("CompanyForCreationDto Added to Database.");
            return Ok(data);
        }

        
        [HttpPut("Update/{id}")]
        [SwaggerOperation("Update Company")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(List<Company>), description: "Internal Error")]
        public async Task<IActionResult> Put([FromBody] CompanyForCreationDto data)
        {
            if (data == null)
            {
                _logger.LogError("CompanyForCreationDto object sent from client is null.");
                return StatusCode(500,data);
            }

            await _Services.Service<ICompanyService>().AsyncUpdate(data);

            _logger.LogInfo($"Data for Company {data.CompanyId}  has been updated");
            return StatusCode(200,data);
        }

        
        [HttpPut("SoftDelete/{id}")]
        [SwaggerOperation("Soft Delete Company")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(List<Company>), description: "Internal Error")]
        public async Task<IActionResult> SoftDelete([FromBody] CompanyForCreationDto data)
        {
            if (data == null)
            {
                _logger.LogError("CompanyForCreationDto object sent from client is null.");
                return StatusCode(500, data);
            }

            await _Services.Service<ICompanyService>().AsyncUpdate(data);

            _logger.LogInfo($"Company {data.CompanyId} and name {data.CompanyName}  has been soft deleted");
            return StatusCode(200, data);
        }


        [SwaggerOperation("DeleteCompany")]
        [HttpDelete("{id}")]
        public async Task<IActionResult>  Delete([FromRoute][Required] Guid id)
        {
            if (String.IsNullOrWhiteSpace(id.ToString()))
            {
                _logger.LogError("CompanyForCreationDto object sent from client is null.");
                return StatusCode(500, id);
            }
            
            await _Services.Service<ICompanyService>().AsyncDelete(id);
            _logger.LogInfo($"Company {id}  has been Deleted");
            return StatusCode(200,id);
        }




    }
}

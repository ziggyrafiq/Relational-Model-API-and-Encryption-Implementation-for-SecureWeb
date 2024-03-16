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
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ZR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DropDownListApiController : BaseApiController
    {
        private readonly ILoggerManagerService _logger;

        public DropDownListApiController(ILoggerManagerService loggerManagerService)
        {
            _logger = loggerManagerService;
        }

        [HttpGet("GetAll")]
        [SwaggerOperation("GetAll")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<DropDownList>), description: "Success")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(List<DropDownList>), description: "Internal Error")]
        public async Task<IActionResult> Get()
        {
            var data = await _Services.Service<IDropDownListService>().AsyncGetAll();
            return StatusCode(200, data);
        }

        [HttpGet("{id}")]
        [SwaggerOperation("GeyByID")]
        [SwaggerResponse(statusCode: 200, type: typeof(DropDownList), description: "Success")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == null)
            {
                _logger.LogError("DropDownList ID t sent from client is null.");
                return BadRequest("DropDownList ID object is null");
            }

            var data = await _Services.Service<IDropDownListService>().AsyncGetById(id);
            _logger.LogInfo($"Get DropDownList Data by id {id} fetched from the database");
            return StatusCode(200, data);
        }

        
        [HttpPost]
        [SwaggerOperation("Add New DropDownList")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        public async Task<IActionResult> Post([FromBody] DropDownList data)
        {
            if (data == null)
            {
                _logger.LogError("DropDownListDto object sent from client is null.");
                return BadRequest("DropDownListDto object is null");
            }

            await _Services.Service<IDropDownListService>().AsyncAdd(data);
            _logger.LogInfo("DropDownListDto Added to Database.");
            return Ok(data);
        }

               
        [HttpPut("Update/{id}")]
        [SwaggerOperation("Update DropDownList")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(List<Company>), description: "Internal Error")]
        public async Task<IActionResult> Update([FromBody] DropDownList data)
        {
            if (data == null)
            {
                _logger.LogError("DropDownListDto object sent from client is null.");
                return StatusCode(500, data);
            }

            await _Services.Service<IDropDownListService>().AsyncUpdate(data);

            _logger.LogInfo($"Data for DropDownList {data.DropDownListId}  has been updated");
            return StatusCode(200, data);
        }

       
        [HttpPut("SoftDelete/{id}")]
        [SwaggerOperation("Soft Delete DropDownList")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(List<Company>), description: "Internal Error")]
        public async Task<IActionResult> SoftDelete([FromBody] DropDownList data)
        {
            if (data == null)
            {
                _logger.LogError("CompanyForCreationDto object sent from client is null.");
                return StatusCode(500, data);
            }

            await _Services.Service<IDropDownListService>().AsyncUpdate(data);

            _logger.LogInfo($"DropDownList {data.DropDownListId} and name {data.Name}  has been soft deleted");
            return StatusCode(200, data);
        }

              
        
        [HttpDelete("{id}")]
        [SwaggerOperation("Delete DropDownList")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Company>), description: "Success")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(List<Company>), description: "Internal Error")]
        public async Task<IActionResult> Delete([FromRoute][Required] Guid id)
        {
            if (String.IsNullOrWhiteSpace(id.ToString()))
            {
                _logger.LogError("DropDownList object sent from client is null.");
                return StatusCode(500, id);
            }

            await _Services.Service<IDropDownListService>().AsyncDelete(id);
            _logger.LogInfo($"DropDownList {id}  has been Deleted");
            return StatusCode(200, id);
        }
    }
}

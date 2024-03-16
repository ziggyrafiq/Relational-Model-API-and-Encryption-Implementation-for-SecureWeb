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
    public class ContactApiController : BaseApiController
    {
        private readonly ILoggerManagerService _logger;

        public ContactApiController(ILoggerManagerService loggerManagerService)
        {
            _logger = loggerManagerService;
        }

        [HttpGet("GetAll")]
        [SwaggerOperation("GetAll")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Contact>), description: "Success")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(List<Contact>), description: "Internal Error")]
        public async Task<IActionResult> Get()
        {
            var data = await _Services.Service<IContactService>().AsyncGetAll();
            return StatusCode(200, data);
        }

        [HttpGet("{id}")]
        [SwaggerOperation("GeyByID")]
        [SwaggerResponse(statusCode: 200, type: typeof(Contact), description: "Success")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == null)
            {
                _logger.LogError("Contact ID t sent from client is null.");
                return BadRequest("Contact ID object is null");
            }

            var data = await _Services.Service<IContactService>().AsyncGetById(id);
            _logger.LogInfo($"Get Contact Data by id {id} fetched from the database");
            return StatusCode(200, data);
        }

       
        [HttpPost]
        [SwaggerOperation("Add New Contact")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        public async Task<IActionResult> Post([FromBody] Contact data)
        {
            if (data == null)
            {
                _logger.LogError("CompanyForCreationDto object sent from client is null.");
                return BadRequest("CompanyForCreationDto object is null");
            }

            await _Services.Service<IContactService>().AsyncAdd(data);
            _logger.LogInfo("CompanyForCreationDto Added to Database.");
            return Ok(data);
        }

        
        [HttpPut("Update/{id}")]
        [SwaggerOperation("Update Contact")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(List<Company>), description: "Internal Error")]
        public async Task<IActionResult> Update([FromBody] Contact data)
        {
            if (data == null)
            {
                _logger.LogError("Contact object sent from client is null.");
                return StatusCode(500, data);
            }

            await _Services.Service<IContactService>().AsyncUpdate(data);

            _logger.LogInfo($"Data for Contact {data.ContactId}  has been updated");
            return StatusCode(200, data);
        }

       
        [HttpPut("SoftDelete/{id}")]
        [SwaggerOperation("Soft Delete Contact")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(List<Company>), description: "Internal Error")]
        public async Task<IActionResult> SoftDelete([FromBody] Contact data)
        {
            if (data == null)
            {
                _logger.LogError("Contact object sent from client is null.");
                return StatusCode(500, data);
            }

            await _Services.Service<IContactService>().AsyncUpdate(data);

            _logger.LogInfo($"Contact {data.ContactId} and name {data.DisplayName}  has been soft deleted");
            return StatusCode(200, data);
        }


       
        [HttpDelete("{id}")]
        [SwaggerOperation("Delete Contact")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Company>), description: "Success")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(List<Company>), description: "Internal Error")]
        public async Task<IActionResult> Delete([FromRoute][Required] Guid id)
        {
            if (String.IsNullOrWhiteSpace(id.ToString()))
            {
                _logger.LogError("Contact object sent from client is null.");
                return StatusCode(500, id);
            }

            await _Services.Service<IContactService>().AsyncDelete(id);
            _logger.LogInfo($"Contact {id}  has been Deleted");
            return StatusCode(200, id);
        }
    }
}

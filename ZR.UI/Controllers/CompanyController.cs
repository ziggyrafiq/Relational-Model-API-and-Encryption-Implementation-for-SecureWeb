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


using ZR.Business.Security.Interfaces;
using ZR.Business.Services.Interfaces;
using ZR.Resources.Dtos;
using ZR.Resources.Extensions;
using ZR.UI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ZR.UI.Controllers
{
    public class CompanyController : BaseSiteController
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly IRsaCryptograper _rsaCryptograper;

        public CompanyController(ILogger<CompanyController> logger, IRsaCryptograper rsaCryptograper)
        {
            _logger = logger;
            _rsaCryptograper = rsaCryptograper;
        }


        public async Task<IActionResult> Index()
        {
            List<CompanyDto> companyDtosList = new List<CompanyDto>();
            using (HttpClient? httpClient = new HttpClient())
            {
                //if have time put get the REST API URL From a Json file as well as the files
                string apiUrlAddress = "https://localhost:7135/api/CompanyApi/GetAll";
                using (HttpResponseMessage? response = await httpClient.GetAsync(apiUrlAddress))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    string enData = _rsaCryptograper.Decrypt(apiResponse.ToString());
                    companyDtosList = JsonConvert.DeserializeObject<List<CompanyDto>>(enData);
                }
            }
            return View(companyDtosList);
        }

        //public IActionResult Index()
        //{
        //    //var data =  _Service.Service<ICompanyService>().AsyncGetAll();

        //    return View();
        //}
    }
}

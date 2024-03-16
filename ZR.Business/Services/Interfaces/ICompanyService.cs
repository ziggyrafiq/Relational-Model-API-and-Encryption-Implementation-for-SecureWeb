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


using ZR.Infrastructure.Models;
using ZR.Resources.Dtos;

namespace ZR.Business.Services.Interfaces
{
    public interface ICompanyService : IService
    {

        Task<List<Company>> AsyncGetAll();

        Task<Company> AsyncGetById(Guid id);


        Task AsyncAdd( CompanyForCreationDto model);
        

        Task AsyncUpdate(CompanyForCreationDto model);

        Task AsyncSoftDelete(Guid id);
        Task AsyncDelete(Guid id);

    }
}

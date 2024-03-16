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

namespace ZR.Business.Services.Interfaces
{
    public interface IAddressService : IService
    {


        Task<List<Address>> AsyncGetAll();

        Task<Address> AsyncGetById(Guid id);


        Task<Address> AsyncAdd(Address model);

        Task<Address> AsyncUpdate(Address model);

        Task AsyncSoftDelete(Guid id);
        Task AsyncDelete(Guid id);
    }
}

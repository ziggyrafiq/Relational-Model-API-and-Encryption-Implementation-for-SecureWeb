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
    public interface IContactService : IService
    {
        Task<List<Contact>> AsyncGetAll();

        Task<Contact> AsyncGetById(Guid id);


        Task<Contact> AsyncAdd(Contact model);

        Task<Contact> AsyncUpdate(Contact model);

        Task AsyncSoftDelete(Guid id);
        Task AsyncDelete(Guid id);
    }
}

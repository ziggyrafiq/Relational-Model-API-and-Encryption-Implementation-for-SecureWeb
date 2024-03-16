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


using ZR.Business.Services.Interfaces;
using ZR.Infrastructure.Models;
using ZR.Infrastructure.UnitOfWork;

namespace ZR.Business.Services
{
    public class ContactService : IContactService
    {
        private readonly UnitOfWork _UnitOfWork;

        public ContactService(UnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("UnitOfWork is passing a NULL refernce. Please check if you can passed the UnitOfWork cobject correctly");
            }

            _UnitOfWork = unitOfWork;

        }


        public async Task<List<Contact>> AsyncGetAll()
        {
            return await Task.Run(() =>

               _UnitOfWork.Repository<Contact>()
               .Get()
               .OrderBy(o => o.ContactId)
               .ToList());
        }


        public async Task<Contact> AsyncGetById(Guid id)
        {

            return await Task.Run(() => _UnitOfWork.Repository<Contact>().AsyncGetByID(id));
        }


        public async Task<Contact> AsyncAdd(Contact model)
        {
            await _UnitOfWork.Repository<Contact>().AsyncInsert(model);
            await _UnitOfWork.SaveAsync();
            return model;
        }

        public async Task<Contact> AsyncUpdate(Contact model)
        {
            await _UnitOfWork.Repository<Contact>().AsyncUpdate(model);
            await _UnitOfWork.SaveAsync();

            return model;
        }
        public async Task AsyncSoftDelete(Guid id)
        {
            Contact? dataModel = await AsyncGetById(id);
            dataModel.IsSoftDeleted = true;
            dataModel.IsActive = false;
            await AsyncUpdate(dataModel);
        }

        public async Task AsyncDelete(Guid id)
        {
            await _UnitOfWork.Repository<Contact>().AsyncDelete(id);

            await _UnitOfWork.SaveAsync();
        }

        public void Dispose()
        {
            _UnitOfWork.Dispose();
            GC.Collect(); ;
        }
    }
}


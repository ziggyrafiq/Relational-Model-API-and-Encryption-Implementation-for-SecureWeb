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
using ZR.Resources.DtoAssembler;
using ZR.Resources.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ZR.Business.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly UnitOfWork _UnitOfWork;

        public CompanyService(UnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("UnitOfWork is passing a NULL refernce. Please check if you can passed the UnitOfWork cobject correctly");
            }

            _UnitOfWork = unitOfWork;

        }
                
        public async Task<List<Company>> AsyncGetAll()
        {
            return await Task.Run(() =>

               _UnitOfWork.Repository<Company>()
               .Get()
               .OrderBy(o => o.CompanyId)
               .ToList());
        }


        public async Task<Company> AsyncGetById(Guid id)
        {

            return await Task.Run(() => _UnitOfWork.Repository<Company>().AsyncGetByID(id));
        }


        public async Task AsyncAdd(CompanyForCreationDto model)
        {
            await _UnitOfWork.Repository<Company>().AsyncInsert(CompanyAssembler.CompanyWriteToModelFromDto(model));
            await _UnitOfWork.SaveAsync();
            
            
        }

        public async Task  AsyncUpdate(CompanyForCreationDto model)
        {

            
            await _UnitOfWork.Repository<Company>().AsyncUpdate(CompanyAssembler.CompanyWriteToModelFromDto(model));
            await _UnitOfWork.SaveAsync();

             
        }
        public async Task AsyncSoftDelete(Guid id)
        {
            Company? dataModel = await AsyncGetById(id);

            dataModel.IsSoftDeleted = true;
            dataModel.IsSoftDeleted = false;
            dataModel.IsActive = false;
            ;
            await AsyncUpdate(CompanyAssembler.CompanyWriteToDtoFromModel(dataModel));
        }

        public async Task AsyncDelete(Guid id)
        {
            await _UnitOfWork.Repository<Company>().AsyncDelete(id);

            await _UnitOfWork.SaveAsync();
        }

        public void Dispose()
        {
            _UnitOfWork.Dispose();
            GC.Collect(); ;
        }
    }
}

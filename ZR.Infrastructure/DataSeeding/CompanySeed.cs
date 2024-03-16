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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.Infrastructure.DataSeeding
{
    public class CompanySeed : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(e => e.CompanyId).HasColumnName("CompanyId");

            builder.Property(x => x.CompanyId).ValueGeneratedOnAdd();
            Random random = new Random();
            
            builder.HasData
                (
                    new Company
                    {
                        RegistrantType=  Models.Enums.RegistrantTypeEnum.UK_Limited_Company,
                        CompanyId = Guid.NewGuid(),
                        CompanyName= "Wonka Industries",
                        RegistrationNumber = random.Next(000000000, 999999999).ToString(),
                        TrandingAs= "WI Ltd",
                        IsActive=true,
                        IsSoftDeleted=false,
                        IsHardDeleted=false
                    },
                    new Company
                    {
                        RegistrantType = Models.Enums.RegistrantTypeEnum.None_UK_Corporation,
                        CompanyId = Guid.NewGuid(),
                        CompanyName = "Acme Corp",
                        RegistrationNumber = random.Next(000000000, 999999999).ToString(),
                        TrandingAs = "Acme Corp",
                        IsActive = true,
                        IsSoftDeleted = false,
                        IsHardDeleted = false
                    },
                    new Company
                    {
                         RegistrantType = Models.Enums.RegistrantTypeEnum.UK_Industrial_Registered_Company,
                         CompanyId = Guid.NewGuid(),
                         CompanyName = "Stark Industries",
                        RegistrationNumber = random.Next(000000000, 999999999).ToString(),
                        TrandingAs = "Stark Ind",
                         IsActive = true,
                         IsSoftDeleted = false,
                         IsHardDeleted = false
                    }

            );



        }
    }
}

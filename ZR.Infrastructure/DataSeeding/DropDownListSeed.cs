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

namespace ZR.Infrastructure.DataSeeding
{
    public class DropDownListSeed : IEntityTypeConfiguration<DropDownList>
    {
        public void Configure(EntityTypeBuilder<DropDownList> builder)
        {
            builder.Property(e => e.DropDownListId).HasColumnName("DropDownListId");

            builder.Property(x => x.DropDownListId).ValueGeneratedOnAdd();

            builder.HasData
           (
                new DropDownList
                {
                    DropDownListId = 1,
                    Name = "--Select Title--",
                    Value = String.Empty,
                    GroupName = "Name-Group-Tiles",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                },
                new DropDownList
                {
                    DropDownListId = 2,
                    Name = "Master",
                    Value = "Master",
                    GroupName = "Name-Group-Tiles",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                },
                new DropDownList
                {
                    DropDownListId = 3,
                    Name = "Mr",
                    Value = "Mr",
                    GroupName = "Name-Group-Tiles",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                },
                new DropDownList
                {
                    DropDownListId =4,
                    Name = "Miss",
                    Value = "Miss",
                    GroupName = "Name-Group-Tiles",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                },
                new DropDownList
                {
                    DropDownListId = 5,
                    Name = "Mrs",
                    Value = "Mrs",
                    GroupName = "Name-Group-Tiles",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                },
                new DropDownList
                {
                    DropDownListId = 6,
                    Name = "Ms",
                    Value = "Ms",
                    GroupName = "Name-Group-Tiles",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                },
                new DropDownList
                {
                    DropDownListId = 7,
                    Name = "Sir",
                    Value = "Sir",
                    GroupName = "Name-Group-Tiles",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                },
                new DropDownList
                {
                    DropDownListId = 8,
                    Name = "Dr",
                    Value = "Dr",
                    GroupName = "Name-Group-Tiles",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                },
                new DropDownList
                {
                    DropDownListId = 9,
                    Name = "Prof",
                    Value = "Prof",
                    GroupName = "Name-Group-Tiles",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                },
                new DropDownList
                {
                    DropDownListId = 10,
                    Name = "Lord",
                    Value = "Lord",
                    GroupName = "Name-Group-Tiles",
                    IsActive = true,
                    IsSoftDeleted = false,
                    IsHardDeleted = false
                }

            );



        }
    }
}

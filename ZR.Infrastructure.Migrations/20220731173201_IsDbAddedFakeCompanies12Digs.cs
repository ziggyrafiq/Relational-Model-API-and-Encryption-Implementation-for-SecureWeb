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


using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZR.Infrastructure.Migrations
{
    public partial class IsDbAddedFakeCompanies12Digs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("19e1e6a1-d02c-4747-9590-d6a069b52bfa"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("d0c4776e-3788-4526-b553-b18e41b5148e"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("d2fe81f8-b903-4db2-b290-1c47f6ad4802"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyName", "IsActive", "IsHardDeleted", "IsSoftDeleted", "RegistrantType", "RegistrationNumber", "TrandingAs" },
                values: new object[] { new Guid("75103f00-2a4a-4a61-84f3-d90ba14ca8cc"), "Acme Corp", true, false, false, 12, "", "Acme Corp" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyName", "IsActive", "IsHardDeleted", "IsSoftDeleted", "RegistrantType", "RegistrationNumber", "TrandingAs" },
                values: new object[] { new Guid("7b76814b-9b99-4c92-b837-7316ef13a096"), "Stark Industries", true, false, false, 9, "", "Stark Ind" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyName", "IsActive", "IsHardDeleted", "IsSoftDeleted", "RegistrantType", "RegistrationNumber", "TrandingAs" },
                values: new object[] { new Guid("bb289cb4-8777-4e6f-b00b-4361143270c2"), "Wonka Industries", true, false, false, 1, "ystem.Random", "WI Ltd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("75103f00-2a4a-4a61-84f3-d90ba14ca8cc"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("7b76814b-9b99-4c92-b837-7316ef13a096"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("bb289cb4-8777-4e6f-b00b-4361143270c2"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyName", "IsActive", "IsHardDeleted", "IsSoftDeleted", "RegistrantType", "RegistrationNumber", "TrandingAs" },
                values: new object[] { new Guid("19e1e6a1-d02c-4747-9590-d6a069b52bfa"), "Wonka Industries", true, false, false, 1, "ystem.Random", "WI Ltd" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyName", "IsActive", "IsHardDeleted", "IsSoftDeleted", "RegistrantType", "RegistrationNumber", "TrandingAs" },
                values: new object[] { new Guid("d0c4776e-3788-4526-b553-b18e41b5148e"), "Acme Corp", true, false, false, 12, "ystem.Random", "Acme Corp" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyName", "IsActive", "IsHardDeleted", "IsSoftDeleted", "RegistrantType", "RegistrationNumber", "TrandingAs" },
                values: new object[] { new Guid("d2fe81f8-b903-4db2-b290-1c47f6ad4802"), "Stark Industries", true, false, false, 9, "ystem.Random", "Stark Ind" });
        }
    }
}

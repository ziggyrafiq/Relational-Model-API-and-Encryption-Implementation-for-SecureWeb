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
    public partial class IsDbAddedFakeCompanies12DigsZR1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("57a66932-d659-44e5-8a54-78860c9b86f8"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("7975e7ce-de2e-49e5-905c-6cc983b8b42b"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("f5f5b103-82be-46cc-befc-7c853a2e19e3"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyName", "IsActive", "IsHardDeleted", "IsSoftDeleted", "RegistrantType", "RegistrationNumber", "TrandingAs" },
                values: new object[] { new Guid("0be7a761-f9ae-4ed1-9e68-447fc0737104"), "Acme Corp", true, false, false, 12, "343305255", "Acme Corp" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyName", "IsActive", "IsHardDeleted", "IsSoftDeleted", "RegistrantType", "RegistrationNumber", "TrandingAs" },
                values: new object[] { new Guid("30be080d-ae46-422c-ab92-795fbac5b02f"), "Stark Industries", true, false, false, 9, "44220638", "Stark Ind" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyName", "IsActive", "IsHardDeleted", "IsSoftDeleted", "RegistrantType", "RegistrationNumber", "TrandingAs" },
                values: new object[] { new Guid("e04220d4-e823-4138-8c6a-30058bb65fb7"), "Wonka Industries", true, false, false, 1, "469903960", "WI Ltd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("0be7a761-f9ae-4ed1-9e68-447fc0737104"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("30be080d-ae46-422c-ab92-795fbac5b02f"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("e04220d4-e823-4138-8c6a-30058bb65fb7"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyName", "IsActive", "IsHardDeleted", "IsSoftDeleted", "RegistrantType", "RegistrationNumber", "TrandingAs" },
                values: new object[] { new Guid("57a66932-d659-44e5-8a54-78860c9b86f8"), "Acme Corp", true, false, false, 12, "12", "Acme Corp" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyName", "IsActive", "IsHardDeleted", "IsSoftDeleted", "RegistrantType", "RegistrationNumber", "TrandingAs" },
                values: new object[] { new Guid("7975e7ce-de2e-49e5-905c-6cc983b8b42b"), "Stark Industries", true, false, false, 9, "12", "Stark Ind" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyName", "IsActive", "IsHardDeleted", "IsSoftDeleted", "RegistrantType", "RegistrationNumber", "TrandingAs" },
                values: new object[] { new Guid("f5f5b103-82be-46cc-befc-7c853a2e19e3"), "Wonka Industries", true, false, false, 1, "12", "WI Ltd" });
        }
    }
}

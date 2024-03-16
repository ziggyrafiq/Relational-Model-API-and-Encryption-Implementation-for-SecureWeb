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
    public partial class IsDbAddedFakeCompaniesAndNameTitles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyName", "IsActive", "IsHardDeleted", "IsSoftDeleted", "RegistrantType", "RegistrationNumber", "TrandingAs" },
                values: new object[,]
                {
                    { new Guid("19e1e6a1-d02c-4747-9590-d6a069b52bfa"), "Wonka Industries", true, false, false, 1, "ystem.Random", "WI Ltd" },
                    { new Guid("d0c4776e-3788-4526-b553-b18e41b5148e"), "Acme Corp", true, false, false, 12, "ystem.Random", "Acme Corp" },
                    { new Guid("d2fe81f8-b903-4db2-b290-1c47f6ad4802"), "Stark Industries", true, false, false, 9, "ystem.Random", "Stark Ind" }
                });

            migrationBuilder.UpdateData(
                table: "DropDownList",
                keyColumn: "DropDownListId",
                keyValue: 1,
                columns: new[] { "GroupName", "Name", "Value" },
                values: new object[] { "Name-Group-Tiles", "--Select Title--", "" });

            migrationBuilder.InsertData(
                table: "DropDownList",
                columns: new[] { "DropDownListId", "GroupName", "IsActive", "IsHardDeleted", "IsSoftDeleted", "Name", "Value" },
                values: new object[,]
                {
                    { 2, "Name-Group-Tiles", true, false, false, "Master", "Master" },
                    { 3, "Name-Group-Tiles", true, false, false, "Mr", "Mr" },
                    { 4, "Name-Group-Tiles", true, false, false, "Miss", "Miss" },
                    { 5, "Name-Group-Tiles", true, false, false, "Mrs", "Mrs" },
                    { 6, "Name-Group-Tiles", true, false, false, "Ms", "Ms" },
                    { 7, "Name-Group-Tiles", true, false, false, "Sir", "Sir" },
                    { 8, "Name-Group-Tiles", true, false, false, "Dr", "Dr" },
                    { 9, "Name-Group-Tiles", true, false, false, "Prof", "Prof" },
                    { 10, "Name-Group-Tiles", true, false, false, "Lord", "Lord" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "DropDownList",
                keyColumn: "DropDownListId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DropDownList",
                keyColumn: "DropDownListId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DropDownList",
                keyColumn: "DropDownListId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DropDownList",
                keyColumn: "DropDownListId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DropDownList",
                keyColumn: "DropDownListId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DropDownList",
                keyColumn: "DropDownListId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DropDownList",
                keyColumn: "DropDownListId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DropDownList",
                keyColumn: "DropDownListId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DropDownList",
                keyColumn: "DropDownListId",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "DropDownList",
                keyColumn: "DropDownListId",
                keyValue: 1,
                columns: new[] { "GroupName", "Name", "Value" },
                values: new object[] { "Test Group", "Test Data", "TestData" });
        }
    }
}

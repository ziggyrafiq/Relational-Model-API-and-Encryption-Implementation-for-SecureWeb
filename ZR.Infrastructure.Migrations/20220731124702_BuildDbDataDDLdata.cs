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


using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZR.Infrastructure.Migrations
{
    public partial class BuildDbDataDDLdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DropDownList",
                columns: new[] { "DropDownListId", "GroupName", "IsActive", "IsHardDeleted", "IsSoftDeleted", "Name", "Value" },
                values: new object[] { 1, "Test Group", true, false, false, "Test Data", "TestData" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DropDownList",
                keyColumn: "DropDownListId",
                keyValue: 1);
        }
    }
}

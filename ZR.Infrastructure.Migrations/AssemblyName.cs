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

using System.Reflection;

namespace ZR.Infrastructure.Migrations
{
    public abstract class AssemblyName
    {
        public string GetName { get; } = Assembly.GetEntryAssembly().GetName().Name.ToString();

        //"ZR.Infrastructure.Migrations";

    }
}
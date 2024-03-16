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


using Microsoft.AspNetCore.DataProtection;

namespace ZR.Business.Security
{
    public class DpApiCryptographer
    {
        private readonly IDataProtector _dataProtector;


        public string Encrypt(string text)
        {
            string? proteced = _dataProtector.Protect(text);

            return proteced;
        }
        public string Decrypt(string text)
        {
            string? proteced = _dataProtector.Unprotect(text);

            return proteced;
        }



    }
}

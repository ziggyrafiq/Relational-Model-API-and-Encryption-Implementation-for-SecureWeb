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


using ZR.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace ZR.UI.Extensions
{
    public class BaseSiteController : Controller
    {
        ServiceManager _Manager;
        internal ServiceManager Services
        {
            get
            {
                if (_Manager == null)
                {
                    _Manager = new ServiceManager();

                    if (User != null && User.Identity != null && !string.IsNullOrWhiteSpace(User.Identity.Name))
                    {

                        _Manager = new ServiceManager();
                    }
                }

                return _Manager;
            }
        }
    }
}

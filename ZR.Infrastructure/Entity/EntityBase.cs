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


using ZR.Infrastructure.Entity.Interfaces;

namespace ZR.Infrastructure.Entity
{
    public abstract class EntityBase : IEntityBase
    {
        public virtual bool IsActive { get; set; }

        public virtual bool IsSoftDeleted { get; set; }
        public virtual bool IsHardDeleted { get; set; }
    }
}

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


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
 

namespace ZR.Infrastructure.Entities
{
    public class DbEntitiesConfiguration : IDesignTimeDbContextFactory<DbEntities>
    { 
        public DbEntities CreateDbContext(string[] args)
        {


            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile(@Directory.GetCurrentDirectory() + "../appsettings.json")
                 .Build();



            string? connectionString = configuration.GetConnectionString("DefaultConnection").ToString();
            // "Data Source=Developer-PC;Initial Catalog=IsApiDbDev;Persist Security Info=True;Trusted_Connection=True";


            DbContextOptionsBuilder<DbEntities>? builder = new DbContextOptionsBuilder<DbEntities>();


            builder.EnableSensitiveDataLogging();
            //builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            builder.UseSqlServer(connectionString.ToString());
            Console.WriteLine($"{connectionString} is here");
            //            builder.UseSqlServer(connectionString.ToString(), b => b.MigrationsAssembly("ZR.Infrastructure.Migrations"));

            builder.UseSqlServer(connectionString.ToString(), x=> x.MigrationsAssembly("ZR.Infrastructure.Migrations"));
            
            Console.WriteLine("ZR Note : Database Config is Runing ");

            return new DbEntities(builder.Options);
        }

      
    }
}

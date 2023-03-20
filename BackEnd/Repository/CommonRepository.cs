using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace BackEnd.Repository
{
    public class CommonRepository
    {
        protected NpgsqlConnection conn;
        public CommonRepository(){
            IConfiguration myConfig=new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appSettings.json")
            .Build();
            conn=new NpgsqlConnection(myConfig.GetConnectionString("PgConn"));
        }
    }
}
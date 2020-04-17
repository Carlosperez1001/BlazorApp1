using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID_DataAccessLibrary
{
    public class sqlDataAccess : IsqlDataAccess
    {
   
        private readonly IConfiguration _config;
        public string ConnectionStringName { get; set; } = "Default";
        public sqlDataAccess(IConfiguration config)
        {

            _config = config;


        }
        public async Task<List<T>> LoadData<T, U>(string mySql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(mySql, parameters);
                return data.ToList();
            }

        }

        public async Task SaveData<T>(string mySql, T parameters)
        {

            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                await connection.ExecuteAsync(mySql, parameters);

            }

        }
    }
}

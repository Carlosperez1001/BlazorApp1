using System.Collections.Generic;
using System.Threading.Tasks;

namespace RFID_DataAccessLibrary
{
    public interface IsqlDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string mySql, U parameters);
        Task SaveData<T>(string mySql, T parameters);
    }
}
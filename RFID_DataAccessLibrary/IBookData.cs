using RFID_DataAccessLibrary.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RFID_DataAccessLibrary
{
    public interface IBookData
    {
        Task<List<BookModel>> GetBook();
        Task InsertBook(BookModel book);
    }

}
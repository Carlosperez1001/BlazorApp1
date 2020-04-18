using RFID_DataAccessLibrary.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RFID_DataAccessLibrary
{
    public class BookData : IBookData
    {
        private readonly IsqlDataAccess _db;
        public BookData(IsqlDataAccess db)
        {
            _db = db;
        }
      

        public Task<List<BookModel>> GetBook()
        {
            string mySql = "select * from item_book.books";
            return _db.LoadData<BookModel, dynamic>(mySql, new { });
        }
        public Task InsertBook(BookModel book)
        {
            string mySql = "@INSERT INTO Book (Book_id, Book_Title, Book_Autor, Book_RFID_EPC, Book_RFID_TimeStamp, Book_RFID_RSSI) " +
                "VALUE(@Book_id, @Book_Title, @Book_Autor, @Book_RFID_EPC, @Book_RFID_TimeStamp, @Book_RFID_RSSI)";

            return _db.SaveData(mySql, book);
        }
    }
}

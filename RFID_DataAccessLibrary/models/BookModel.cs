using System;
using System.Collections.Generic;
using System.Text;

namespace RFID_DataAccessLibrary.models
{
  public  class BookModel
    {
        public string Book_id { get; set; }
        public string Book_Title { get; set; }
        public Byte[] Book_Image { get; set; }
        public string Book_Autor { get; set; }
        public string Book_RFID_EPC { get; set; }
        public string Book_RFID_TimeStamp { get; set; }
        public string Book_RFID_RSSI { get; set; }
    }
}

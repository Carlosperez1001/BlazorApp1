using System;
using System.Collections.Generic;
using System.Text;

namespace RFID_DataAccessLibrary.models
{
  public  class UnknownItemModel
    {
      
      
        public UnknownItemModel(String EPC, String timeStamp, String RSSI)
        {
            this.RSSI = RSSI;
            this.EPC = EPC;
            this.TimeStamp = timeStamp;
        }

        public string EPC { get; set; }
        public string TimeStamp { get; set; }
        public string RSSI { get; set; }
    }
}

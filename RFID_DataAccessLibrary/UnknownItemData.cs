using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ThingMagic;

namespace RFID_DataAccessLibrary.models
{
    public class UnknownItemData
    {
        public UnknownItemData(String EPC, String timeStamp, String RSSI)
        {
            this.RSSI = RSSI;
            this.EPC = EPC;
            this.TimeStamp = timeStamp;
        }

        public string EPC { get; set; }
        public string TimeStamp { get; set; }
        public string RSSI { get; set; }

        private static List<UnknownItemData> UnknownList = new List<UnknownItemData>();

        public static List<UnknownItemData> getUnknownRFIDList()
        {
            return UnknownList;
        }
        public static void addUnknownRFIDItem(String EPC, String TimeStamp, String RSSI)
        {
            UnknownList.Add(new UnknownItemData(EPC = EPC, TimeStamp = TimeStamp.ToString(), RSSI = RSSI));
            Console.WriteLine(EPC + "   " + TimeStamp);
        }
        public static void RemoveUnknownRFIDItem(UnknownItemData selectedItem)
        {
            UnknownList.Remove(UnknownList.Where(i => i.EPC == selectedItem.EPC).Single());
        }

        public static void RemoveALL()
        {
            UnknownList.Clear();
        }
        public static bool CheckList(TagReadDataEventArgs e)
        {
            //Check dt if EPC already exist. 
            
            if (UnknownList.Any(p => p.EPC == e.TagReadData.EpcString))
            {
                var list = UnknownList.First(f => f.EPC == e.TagReadData.EpcString);
                var index = UnknownList.IndexOf(list);
                UnknownList[index].TimeStamp = e.TagReadData.Time.ToString();
                UnknownList[index].RSSI = e.TagReadData.Rssi.ToString();

                // double distance =  Math.Pow((-30 - Double.Parse(UnknownList[index].RSSI)) / (10 * 2), 10);
                // UnknownList[index].RSSI = distance.ToString();

                Console.WriteLine("[Update Unknown Tag] " + e.TagReadData.EpcString + e.TagReadData.Time.ToString() + " -  " + e.TagReadData.Rssi);
                return true;
            }
            else
            {
                addUnknownRFIDItem(e.TagReadData.EpcString, e.TagReadData.Time.ToString(), e.TagReadData.Rssi.ToString());
                return false;
            }
        }
    }
}




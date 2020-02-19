using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControlFakes2
{
    public class EntryNotification : IEntryNotification
    {
        public void NotifyEntryDenied()
        {
            Console.WriteLine("Entry Denied");
        }

        public void NotifyEntryGranted()
        {
            Console.WriteLine("Entry Granted");
        }
    }
}

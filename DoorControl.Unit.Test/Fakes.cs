using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoorControlFakes2;

namespace DoorControlUnitTest
{
    public class FakeDoor : IDoor
    {
        public int CloseCount { get; private set; }
        public int Opencount { get; private set; }

        public FakeDoor()
        {
            CloseCount = 0;
            Opencount = 0;
        }

        public void Close()
        {
            CloseCount++;
        }

        public void Open()
        {
            Opencount++;
        }

    }

    public class FakeAlarm : IAlarm
    {
        public int countAlarm { get; private set; } 

        public FakeAlarm()
        {
            countAlarm = 0;
        }
        public void RaiseAlarm()
        {
            countAlarm++;
        }
    }

    public class FakeEntryNotifation : IEntryNotification
    {
        public int NotifyEntryGrantedCounter { get; set; }
            
        public int NotifyEntryDeniedCounter { get; set; }
        public void NotifyEntryDenied()
        {
            NotifyEntryDeniedCounter++;
        }

        public void NotifyEntryGranted()
        {
            NotifyEntryGrantedCounter++;
        }
    }

    public class FakeUserValidation : IUserValidation
    {
        public bool ValidateEntryRequest(string id)
        {
            if (id=="1")
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }

}

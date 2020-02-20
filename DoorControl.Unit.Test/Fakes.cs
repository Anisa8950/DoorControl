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
        public int opencounter{get; set; }
        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
           opencounter++;
        }
    }

    public class FakeAlarm : IAlarm
    {
        public void RaiseAlarm()
        {
            throw new NotImplementedException();
        }
    }

    public class FakeEntryNotifation : IEntryNotification
    {
        public int NotifyEntryGrantedCounter { get; set; }
        public void NotifyEntryDenied()
        {
            throw new NotImplementedException();
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

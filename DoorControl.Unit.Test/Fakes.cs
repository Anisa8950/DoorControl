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
        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            throw new NotImplementedException();
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
        public void NotifyEntryDenied()
        {
            throw new NotImplementedException();
        }

        public void NotifyEntryGranted()
        {
            throw new NotImplementedException();
        }
    }

    public class FakeUserValidation : IUserValidation
    {
        public bool ValidateEntryRequest(string id)
        {
            throw new NotImplementedException();
        }
    }

}

using System;
using NUnit.Framework;
using DoorControlFakes2;

namespace DoorControlUnitTest
{
    [TestFixture]
    public class DoorControlUTFakes
    {
        private DoorControlReal _doorControl;
        private FakeAlarm _alarm;
        private FakeDoor _door;
        private FakeEntryNotifation _entryNotifation;
        private FakeUserValidation _userValidation;

        [SetUp]
        public void SetUp()
        {
            _alarm = new FakeAlarm();
            _door = new FakeDoor();
            _entryNotifation = new FakeEntryNotifation();
            _userValidation = new FakeUserValidation();

            _doorControl = new DoorControlReal(_door, _entryNotifation, _userValidation, _alarm);           
        }

        [Test]
        public void firstTest()
        {

        }

    }
}

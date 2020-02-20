using System;
using NUnit.Framework;
using DoorControlFakes2;

namespace DoorControlUnitTest
{
    [TestFixture]
    public class DoorControlUTFakes
    {
        private DoorControlReal uut;
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

            uut = new DoorControlReal(_door, _entryNotifation, _userValidation, _alarm);           
        }

        [Test]
        public void firstTest()
        {
            uut.RequestEntry("au123456");
        }

        [Test]
        public void RequestEntry_DoorclosedAndUserValid_doorOpen()
        {

            // setup
            uut._doorstate = DoorControlReal.DoorState.DoorClosed;
           

            //act

            //_userValidation.ValidateEntryRequest("1");
            uut.RequestEntry("1");


            //assert
            Assert.That(_door.opencounter,Is.EqualTo(1));

            Assert.That(_entryNotifation.NotifyEntryGrantedCounter, Is.EqualTo(1));

            Assert.That(uut._doorstate,Is.EqualTo(DoorControlReal.DoorState.DoorOpening));
        } 






    }
}

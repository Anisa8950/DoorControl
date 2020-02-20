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

        #region Method_DoorOpen
        [Test]
        public void InitialStateDoorOpning_StateChangedDoorCloseningAndCloseCalled()
        {
            uut._doorstate = DoorControlReal.DoorState.DoorOpening;
            uut.DoorOpen();
            Assert.That(uut._doorstate, Is.EqualTo(DoorControlReal.DoorState.DoorClosing));
            Assert.That(_door.CloseCount, Is.EqualTo(1));
        }

        [Test]
        public void InitalStateDoorClosed_StateChangedDoorBreachedAndRaiseAlarmCalled()
        {
            uut._doorstate = DoorControlReal.DoorState.DoorClosed;
            uut.DoorOpen();
            Assert.That(uut._doorstate, Is.EqualTo(DoorControlReal.DoorState.DoorBreached));
            Assert.That(_alarm.countAlarm, Is.EqualTo(1));
        }

        [Test]
        public void InitalStateDoorClosening_SameStateAndNoCalles()
        {
            uut._doorstate = DoorControlReal.DoorState.DoorClosing;
            uut.DoorOpen();
            Assert.That(uut._doorstate, Is.EqualTo(DoorControlReal.DoorState.DoorClosing));
            Assert.That(_door.CloseCount, Is.EqualTo(0));
            Assert.That(_alarm.countAlarm, Is.EqualTo(0));
        }

        [Test]
        public void InitalStateDoorBreached_SameStateAndNoCalles()
        {
            uut._doorstate = DoorControlReal.DoorState.DoorBreached;
            uut.DoorOpen();
            Assert.That(uut._doorstate, Is.EqualTo(DoorControlReal.DoorState.DoorBreached));
            Assert.That(_door.CloseCount, Is.EqualTo(0));
            Assert.That(_alarm.countAlarm, Is.EqualTo(0));
        }
        #endregion

        #region Metod_DoorClose

        [Test]
        public void InitalStateDoorOpning_StateChangedDoorClosed()
        {
            uut._doorstate = DoorControlReal.DoorState.DoorOpening;
            uut.DoorClose();
            Assert.That(uut._doorstate, Is.EqualTo(DoorControlReal.DoorState.DoorClosed));

        }

        [Test]
        public void InitalStateDoorClosening_StateChangedDoorClosed()
        {
            uut._doorstate = DoorControlReal.DoorState.DoorClosing;
            uut.DoorClose();
            Assert.That(uut._doorstate, Is.EqualTo(DoorControlReal.DoorState.DoorClosed));
        }

        [Test]
        public void InitalStateDoorBreached_StateChangedDoorClosed()
        {
            uut._doorstate = DoorControlReal.DoorState.DoorBreached;
            uut.DoorClose();
            Assert.That(uut._doorstate, Is.EqualTo(DoorControlReal.DoorState.DoorClosed));
        }

        [Test]
        public void InitalStateDoorClosed_SameState()
        {
            uut._doorstate = DoorControlReal.DoorState.DoorClosed;
            uut.DoorClose();
            Assert.That(uut._doorstate, Is.EqualTo(DoorControlReal.DoorState.DoorClosed));
        }
        #endregion

    }
}

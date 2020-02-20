using System;
using NUnit.Framework;
using NSubstitute;
using DoorControlFakes2;


namespace DoorControl.Unit.Test
{
    [TestFixture]
    public class DoorControllUTSubsitute
    {
        private DoorControlReal uut;
        private IAlarm _alarm;
        private IDoor _door;
        private IEntryNotification _entryNotifation;
        private IUserValidation _userValidation;

        [SetUp]
        public void SetUp()
        {
            _alarm = Substitute.For<IAlarm>();
            _door = Substitute.For<IDoor>();
            _entryNotifation = Substitute.For<IEntryNotification>();
            _userValidation = Substitute.For<IUserValidation>();

            uut = new DoorControlReal(_door, _entryNotifation, _userValidation, _alarm);
        }

        #region Method_DoorOpen
        [Test]
        public void InitialStateDoorOpning_StateChangedDoorCloseningAndCloseCalled()
        {
            uut._doorstate = DoorControlReal.DoorState.DoorOpening;
            uut.DoorOpen();
            Assert.That(uut._doorstate, Is.EqualTo(DoorControlReal.DoorState.DoorClosing));
            _door.Received(1).Close();
        }

        [Test]
        public void InitalStateDoorClosed_StateChangedDoorBreachedAndRaiseAlarmCalled()
        {
            uut._doorstate = DoorControlReal.DoorState.DoorClosed;
            uut.DoorOpen();
            Assert.That(uut._doorstate, Is.EqualTo(DoorControlReal.DoorState.DoorBreached));
            _alarm.Received(1).RaiseAlarm();
        }

        [Test]
        public void InitalStateDoorClosening_SameStateAndNoCalles()
        {
            uut._doorstate = DoorControlReal.DoorState.DoorClosing;
            uut.DoorOpen();
            Assert.That(uut._doorstate, Is.EqualTo(DoorControlReal.DoorState.DoorClosing));
            _door.DidNotReceive().Close();
            _alarm.DidNotReceive().RaiseAlarm();
        }

        [Test]
        public void InitalStateDoorBreached_SameStateAndNoCalles()
        {
            uut._doorstate = DoorControlReal.DoorState.DoorBreached;
            uut.DoorOpen();
            Assert.That(uut._doorstate, Is.EqualTo(DoorControlReal.DoorState.DoorBreached));
            _door.DidNotReceive().Close();
            _alarm.DidNotReceive().RaiseAlarm();
        }
        #endregion
    }
}

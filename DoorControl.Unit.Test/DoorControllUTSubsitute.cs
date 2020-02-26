using System;
using NUnit.Framework;
using NSubstitute;
using DoorControlFakes2;
using NSubstitute.Core.Arguments;
using NSubstitute.ReceivedExtensions;


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
        public void InitialStateDoorOpening_StateChangedDoorCloseningAndCloseCalled()
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

        #region Method_DoorClose

        [Test]
        public void InitalStateDoorOpening_StateChangedDoorClosed()
        {
            uut._doorstate = DoorControlReal.DoorState.DoorOpening;
            uut.DoorClose();
            Assert.That(uut._doorstate, Is.EqualTo(DoorControlReal.DoorState.DoorClosed));

        }



        #endregion

        #region Method_RequestEntry_DoorClosed

        [Test]
        public void RequestEntry_DoorclosedAndUserValid_OpenCalledAndEntryGrantedAndStateChangedDoorOpening()
        {
            //Arrange
            uut._doorstate = DoorControlReal.DoorState.DoorClosed;
            _userValidation.ValidateEntryRequest(Arg.Any<string>()).Returns(true);

            //Act
            uut.RequestEntry("bla");

            //Assert
            _door.Received(1).Open();
            _entryNotifation.Received(1).NotifyEntryGranted();
            Assert.That(uut._doorstate, Is.EqualTo(DoorControlReal.DoorState.DoorOpening));
        }


        [Test]
        public void RequestEntry_DoorclosedAndUserInvalid_EntryDenied()
        {
            //Arrange
            uut._doorstate = DoorControlReal.DoorState.DoorClosed;
            _userValidation.ValidateEntryRequest(Arg.Any<string>()).Returns(false);

            //Act
            uut.RequestEntry("bla");

            //Assert
            _entryNotifation.Received(1).NotifyEntryDenied();
        }
        
        #endregion

        #region Method_RequestEntry_DoorNotClosed

        
        [Test]
        public void RequestEntry_InitialStateDoorOpeningAndUserValid_SameStateAndNoCalles()
        {
            //Arrange
            uut._doorstate = DoorControlReal.DoorState.DoorOpening;
            _userValidation.ValidateEntryRequest(Arg.Any<string>()).Returns(true);

            //Act
            uut.RequestEntry("bla");

            // Assert
            _door.Received(0).Open();
            _entryNotifation.DidNotReceive().NotifyEntryGranted();
            Assert.That(uut._doorstate, Is.EqualTo(DoorControlReal.DoorState.DoorOpening));
            _entryNotifation.DidNotReceive().NotifyEntryDenied();

        }

        [Test]
        public void RequestEntry_InitialStateDoorClosingAndUserValid_SameStateAndNoCalles()
        {
            //Arrange
            uut._doorstate = DoorControlReal.DoorState.DoorClosing;
            _userValidation.ValidateEntryRequest(Arg.Any<string>()).Returns(true);

            //Act
            uut.RequestEntry("bla");

            //Assert
            _door.Received(0).Open();
            _entryNotifation.DidNotReceive().NotifyEntryGranted();
            Assert.That(uut._doorstate, Is.EqualTo(DoorControlReal.DoorState.DoorClosing));
            _entryNotifation.DidNotReceive().NotifyEntryDenied();

        }

        [Test]
        public void RequestEntry_InitialStateDorBreached_SameStateAndNoCalles()
        {
            //Arrange
            uut._doorstate = DoorControlReal.DoorState.DoorBreached;
            _userValidation.ValidateEntryRequest(Arg.Any<string>()).Returns(true);

            //Act
            uut.RequestEntry("bla");

            //Assert
            _door.Received(0).Open();
            _entryNotifation.DidNotReceive().NotifyEntryGranted();
            Assert.That(uut._doorstate, Is.EqualTo(DoorControlReal.DoorState.DoorBreached));
            _entryNotifation.DidNotReceive().NotifyEntryDenied();
        }


        #endregion



    }
}

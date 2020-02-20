using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControlFakes2
{
    public class DoorControlReal
    {
        public enum DoorState
        {
            DoorClosed,
            DoorOpening,
            DoorClosing,
            DoorBreached
        }

        public DoorState _doorstate { get; set; }
        private IDoor _door;
        private IEntryNotification _entryNotification;
        private IUserValidation _userValidation;
        private IAlarm _alarm;

        public DoorControlReal(IDoor door, IEntryNotification entryNotification, IUserValidation userValidation, IAlarm alarm)
        {
            _door = door;
            _entryNotification = entryNotification;
            _userValidation = userValidation;
            _alarm = alarm;

            _doorstate = DoorState.DoorClosed;
        }

        public void RequestEntry(string id)
        {
            if (_doorstate == DoorState.DoorClosed)
            {
                if (_userValidation.ValidateEntryRequest(id) == true)
                {
                    _door.Open();
                    _entryNotification.NotifyEntryGranted();
                    _doorstate = DoorState.DoorOpening;
                }
                else
                {
                    _entryNotification.NotifyEntryDenied();
                }
            }
        }

        public void DoorOpen()
        {   
            if(_doorstate==DoorState.DoorOpening)
            {
                _doorstate = DoorState.DoorClosing;
                _door.Close();

            }else if(_doorstate==DoorState.DoorClosed)
            {
                _doorstate = DoorState.DoorBreached;
                _alarm.RaiseAlarm();
            }            
        }

        public void DoorClose()
        {            
            _doorstate = DoorState.DoorClosed;
        }

    }
}

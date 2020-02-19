using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControlFakes2
{
    public class DoorControl
    {
        private enum DoorState
        {
            DoorClosed,
            DoorOpening,
            DoorClosing,
            DoorBreached
        }

        private DoorState _doorstate;
        private IDoor _door;
        private IEntryNotification _entryNotification;
        private IUserValidation _userValidation;
        private IAlarm _alarm;

        public DoorControl(IDoor door, IEntryNotification entryNotification, IUserValidation userValidation, IAlarm alarm)
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
            _doorstate = DoorState.DoorClosing;
            _door.Close();
        }

        public void DoorClose()
        {            
            _doorstate = DoorState.DoorClosed;
        }

    }
}

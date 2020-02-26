using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControlFakes2
{
    public class Door : IDoor
    {
        public void Close()
        {
            Console.WriteLine("DOOR CLOSENING");
        }

        public void Open()
        {
            Console.WriteLine("DOOR OPENING");
        }
    }
}

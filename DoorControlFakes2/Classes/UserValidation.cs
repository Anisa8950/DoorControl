using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControlFakes2
{
    public class UserValidation : IUserValidation
    {
        public bool ValidateEntryRequest(string id)
        {
            throw new NotImplementedException();
        }
    }
}

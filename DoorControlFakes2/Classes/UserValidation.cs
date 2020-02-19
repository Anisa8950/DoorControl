using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControlFakes2
{
    public class UserValidation : IUserValidation
    {

        private List<string> _list;

        public UserValidation()
        {
            _list.Add("au123456");
            _list.Add("au987654");
        }

        public bool ValidateEntryRequest(string id)
        {
            bool valid = false;
            foreach (var item in _list)
            {
                if(id==item)
                {
                    valid = true;
                }
            }
            return valid;
        }
    }
}

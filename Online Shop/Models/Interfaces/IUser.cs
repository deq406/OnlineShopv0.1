using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Models.Interfaces
{
    interface IUser
    {
        string Login { get; set; }

        string Password { get; set; }
    }
}

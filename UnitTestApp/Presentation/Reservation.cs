using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestApp.Presentation
{
    public class Reservation
    {
            public  User MadeBy { get; set; }
            public bool CanBeCancelledBy(User user)
            {
                if (user.IsAdmin) return true;
                if (MadeBy.Equals(user)) return true;
                return false;
            }
    }
}

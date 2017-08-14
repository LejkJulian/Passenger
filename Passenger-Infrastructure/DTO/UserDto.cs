using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Infrastructure.DTO
{
    public class UserDto//anemic class zwracamy do API tylko to co chcemy, nie całosc klasy DDD. Za dużo informacji
    {
        public Guid ID { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        
    }
}

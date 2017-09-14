using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.EF
{
   public  class ConnectionSettings
    {
        public bool InMemoryConnection { get; set; }
        public string ConnectionString { get; set; }
    }
}

using Passengers.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Repositories
{
    public interface IDriverRepository
    {

        Driver GetID(Guid UserID);
        IEnumerable<Driver> GetAll();
        void Add(Driver driver);
        void Update(Driver driver);
        void Remove(Driver driver);

        //chyba nie wiem jak on działa
        //Driver GetUserID(Guid UserID);
        //IEnumerable<Driver> GetAll();
        //Vehicle Get(string Name);
        //IEnumerable<Route> GetRoute();
        //IEnumerable<DailyRoute> GetDailyRoute();
    }
}


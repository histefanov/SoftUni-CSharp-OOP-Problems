using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
        public override ICar GetByName(string name)
        {
            var result = base.GetAll().FirstOrDefault(c => c.Model == name);
            return result;
        }
    }
}

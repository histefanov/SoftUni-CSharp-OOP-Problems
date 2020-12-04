using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly ICollection<IGun> _models;

        public GunRepository()
        {
            _models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => _models as IReadOnlyCollection<IGun>;

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            _models.Add(model);
        }

        public IGun FindByName(string name)
        {
            return _models.FirstOrDefault(g => g.Name == name);
        }

        public bool Remove(IGun model)
        {
            return _models.Remove(model);
        }
    }
}

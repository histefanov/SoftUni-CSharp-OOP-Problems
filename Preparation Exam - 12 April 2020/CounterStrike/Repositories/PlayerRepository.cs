using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly ICollection<IPlayer> _models;

        public PlayerRepository()
        {
            _models = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => _models as IReadOnlyCollection<IPlayer>;

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            _models.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            return _models.FirstOrDefault(p => p.Username == name);
        }

        public bool Remove(IPlayer model)
        {
            return _models.Remove(model);
        }
    }
}

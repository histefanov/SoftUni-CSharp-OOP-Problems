using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        private ICollection<T> _models;

        public Repository()
        {
            _models = new List<T>();
        }

        public void Add(T model)
        {
            _models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return _models as IReadOnlyCollection<T>;
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return _models.Remove(model);
        }
    }
}

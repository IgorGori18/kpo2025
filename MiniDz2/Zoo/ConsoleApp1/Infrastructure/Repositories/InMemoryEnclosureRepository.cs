using System.Collections.Generic;
using System.Linq;
using Zoo.Application.Interfaces;
using Zoo.Domain.Entities;

namespace Zoo.Infrastructure.Repositories
{
    /// <summary>
    /// Реализация репозитория вольеров в памяти.
    /// </summary>
    public class InMemoryEnclosureRepository : IEnclosureRepository
    {
        private static List<Enclosure> _enclosures = new List<Enclosure>();
        private static int _nextId = 1;

        public Enclosure Add(Enclosure enclosure)
        {
            enclosure.Id = _nextId++;
            _enclosures.Add(enclosure);
            return enclosure;
        }

        public bool Remove(int id)
        {
            var enclosure = _enclosures.FirstOrDefault(e => e.Id == id);
            if (enclosure == null) return false;
            _enclosures.Remove(enclosure);
            return true;
        }

        public Enclosure GetById(int id)
        {
            return _enclosures.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Enclosure> GetAll()
        {
            return _enclosures;
        }

        public void Update(Enclosure enclosure)
        {
            var index = _enclosures.FindIndex(e => e.Id == enclosure.Id);
            if (index != -1)
            {
                _enclosures[index] = enclosure;
            }
        }
    }
}
using System.Collections.Generic;
using Zoo.Domain.Entities;

namespace Zoo.Application.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория вольеров.
    /// </summary>
    public interface IEnclosureRepository
    {
        Enclosure Add(Enclosure enclosure);
        bool Remove(int id);
        Enclosure GetById(int id);
        IEnumerable<Enclosure> GetAll();
        void Update(Enclosure enclosure);
    }
}
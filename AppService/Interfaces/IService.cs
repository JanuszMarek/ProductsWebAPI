using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> GetEntites();

        T GetById(Guid id);

        void Delete(Guid id);

        bool Exists(Guid id);
    }
}

using Entities.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IRepository<T> where T: IEntity
    {
        T GetById(Guid id);

        IEnumerable<T> GetAll();

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        bool Exists(Guid id);

        bool Save();
    }
}

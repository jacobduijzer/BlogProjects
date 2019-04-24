using System;
using System.Collections.Generic;

namespace SharedKernel.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T Get(Guid id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fromulaApi.Model;

namespace fromulaApi.Repository
{
    public interface IFormulaRepo<T> where T : class
    {
        // Here in this case we are using T so that if there are multiple Tables or models to be updated or add we would not have to make functions for them bcz generic repo pattern wil
        // do this for us
        Task<IEnumerable<T>> All();
        Task<T?> GetByID(int id);
        // it can be bool or anything depends upon ur logic
        Task<bool> Delete(T entity);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
    }
}
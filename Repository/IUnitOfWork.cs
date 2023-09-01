using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fromulaApi.Repository
{
    public interface IUnitOfWork
    {
        IDriverRepositary Drivers {get;}
        Task CompleteAsync();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fromulaApi.Repository
{
    public interface IDriverRepositary : IFormulaRepo<Model.Driver>
    {
        Task<Model.Driver?> GetByDriverNumber(int driverNumber);
    }
}
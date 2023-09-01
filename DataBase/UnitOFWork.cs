using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fromulaApi.Repository;
using fromulaApi.Repository.Implementation;

namespace fromulaApi.DataBase
{                                          // Garabge collections
    public class UnitOFWork : IUnitOfWork, IDisposable
    {
        public IDriverRepositary Drivers {get; private set;}
        private readonly FormulaDatabase _context;
        public UnitOFWork(FormulaDatabase context)
        {
            _context = context;
            Drivers =  new DriverRepository(_context);
            
        }
        public async Task CompleteAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();        }
    }
}
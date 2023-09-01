using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fromulaApi.DataBase;
using fromulaApi.Model;
using Microsoft.EntityFrameworkCore;

namespace fromulaApi.Repository.Implementation
{
    public class DriverRepository : FormulaRepositary<Driver>, IDriverRepositary
    {
        public DriverRepository(FormulaDatabase context) : base(context)
        {
        }

        public override async Task<Driver?> GetByID(int id)
        {
            try
            {
                return await _context.Drivers.AsNoTracking().FirstOrDefaultAsync(d=>d.Id==id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        public async Task<Driver?> GetByDriverNumber(int driverNumber)
        {
            try
            {
                return await _context.Drivers.FirstOrDefaultAsync(d=>d.DriverNumber==driverNumber);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
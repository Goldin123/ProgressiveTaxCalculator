using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.InMemory.Database.Repository.Interface
{
    public interface IProgressiveTaxCalculatorInMemoryRepository
    {
        Task InitialiseDatabase();
    }
}

using Lab4.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Entities
{
    public interface IRateService
    {
        public Task<IEnumerable<Rate>> GetRates(DateTime date);
    }
}

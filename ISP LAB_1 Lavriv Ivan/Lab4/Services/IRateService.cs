using System;
using System.Collections.Generic;

namespace ISP_LAB_1_Lavriv_Ivan
{
    public interface IRateService
    {
        Task<IEnumerable<Rate>> GetRates(DateTime date);
    }
}

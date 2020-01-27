using System.Collections.Generic;
using pdv.Models;

namespace pdv.Contracts
{
    public interface IBillRepository
    {
        List<Bill> CalculateChange(Pdv pdv);
    }
}

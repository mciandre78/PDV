using System.Collections.Generic;
using pdv.Models;

namespace pdv.Contracts
{
    public interface IPdvRepository
    {
        IEnumerable<Pdv> GetListByValue(decimal value);
    }
}

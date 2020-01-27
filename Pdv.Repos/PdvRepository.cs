using pdv.Models;
using pdv.Contracts;
using pdv.Services;
using System.Linq;
using System.Collections.Generic;
using pdv.Data;

namespace pdv.Repos
{
    public class PdvRepository : GenericRepository<Pdv>, IPdvRepository
    {
        private readonly DataContext _DbContext;

        public PdvRepository(DataContext context) : base(context)
        {
            this._DbContext = context;
        }
        
        public IEnumerable<Pdv> GetListByValue(decimal value) 
        {
            return (from p in this._DbContext.Pdvs 
                    where p.Price.Equals(value)
                    select p);
        }
    }
}

using pdv.Data;
using pdv.Contracts;
using System.Threading.Tasks;

namespace pdv.Repos
{
    public class UnitOfWork : IUnitOfWork        
    {
        private readonly DataContext _DbContext;

        public PdvRepository PdvRepository { get; private set; }
        public BillRepository BillRepository { get; private set; }

        public UnitOfWork(DataContext context)
        {
            this._DbContext = context;
            this.PdvRepository = new PdvRepository(this._DbContext);
            this.BillRepository = new BillRepository(this._DbContext);
        }

        public async Task Commit()
        {
           await this._DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._DbContext.Dispose();
        }
    }
}

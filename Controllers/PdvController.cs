using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pdv.Models;
using pdv.Contracts;
using pdv.Repos;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace pdv.Controllers
{
    [ApiController]
    [Route ("v1/pdv")]
    public class PdvController {

        private readonly UnitOfWork _UnitOfWork;

        public PdvController(IUnitOfWork unitOfWork)
        {
            this._UnitOfWork = unitOfWork as UnitOfWork;
        }

        [HttpGet]
        [Route ("")]
        public async Task<ActionResult<List<Pdv>>> Get() {
            dynamic model = new ExpandoObject();
            model.Pdv = this._UnitOfWork.PdvRepository.GetAll();
            return await model.Pdv;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Bill>>> Post([FromBody] Pdv model)
        {
            
            this._UnitOfWork.PdvRepository.Add(model);
            await this._UnitOfWork.Commit();

            return this._UnitOfWork.BillRepository.CalculateChange(model);
        }
    }
}
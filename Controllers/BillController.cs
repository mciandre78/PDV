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
    [Route ("v1/bill")]
    public class BillController {

        private readonly UnitOfWork _UnitOfWork;

        public BillController(IUnitOfWork unitOfWork)
        {
            this._UnitOfWork = unitOfWork as UnitOfWork;
        }

        [HttpGet]
        [Route ("")]
        public async Task<ActionResult<List<Bill>>> Get() {
            dynamic model = new ExpandoObject();
            model.Bill = this._UnitOfWork.BillRepository.GetAll();
            return await model.Bill;
        }        
    }
}
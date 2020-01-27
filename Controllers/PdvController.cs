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
            decimal change = model.AmountPaid - model.Price;
            
            //Change limit
            if (change >= 10000)
                return null;

            this._UnitOfWork.PdvRepository.Add(model);
            
            await this._UnitOfWork.Commit();
            
            List<Bill> lBills = this._UnitOfWork.BillRepository.CalculateChange(model);

            foreach (Bill bill in lBills)
                bill.IdPdv = model.Id;
            
            this._UnitOfWork.BillRepository.AddRange(lBills);

            return this._UnitOfWork.BillRepository.CalculateChange(model);
        }
    }
}
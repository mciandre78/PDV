using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pdv.Models;
using pdv.Contracts;
using pdv.Repos;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using pdv.Data;
using Microsoft.EntityFrameworkCore;

namespace pdv.Controllers
{
    [ApiController]
    [Route ("v1/pdv")]
    public class PdvController {
                
        [HttpGet]
        [Route ("")]
        public async Task<ActionResult<List<Pdv>>> Get([FromServices] DataContext context)
        {
            return await context.Pdvs.ToListAsync();            
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Bill>>> Post(
            [FromServices] DataContext context,
            [FromBody] Pdv model)
        {
            BillRepository billRepository = new BillRepository(context);
            decimal change = model.AmountPaid - model.Price;
            
            //Change limit
            if (change >= 10000)
                return null;

            context.Pdvs.Add(model);
            
            List<Bill> lBills = billRepository.CalculateChange(model);

            //context.Bills.UpdateRange(lBills);

            context.SaveChanges();

            return lBills;
        }
    }
}
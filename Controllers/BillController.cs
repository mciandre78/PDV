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
    [Route ("v1/bill")]
    public class BillController {
              
        [HttpGet]
        [Route ("")]
        public async Task<ActionResult<List<Bill>>> Get([FromServices] DataContext context) {
                        
            return await context.Bills.ToListAsync();
        }        
    }
}
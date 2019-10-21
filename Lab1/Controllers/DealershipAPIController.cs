// I, Deanna Stender, student number 000732962, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1.Data;
using Lab1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealershipAPIController : ControllerBase
    {
        private readonly DealershipMgr _dealershipMgr = new DealershipMgr();

        // GET: api/DealershipAPI
        [HttpGet]
        public IEnumerable<Dealership> Get()
        {
            return _dealershipMgr.GetDealerships();
        }

        // GET: api/DealershipAPI/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Dealership> GetDealership(int id)
        {
            var dealership = _dealershipMgr.GetDealership(id);

            if (dealership == null)
            {
                return NotFound();
            }

            return dealership;
        }

        // POST: api/DealershipAPI
        [HttpPost]
        public ActionResult<Dealership> Post(Dealership dealership)
        {
            if (ModelState.IsValid)
            {
                _dealershipMgr.AddDealership(dealership);
            }
            return CreatedAtAction("GetDealership", new { id = dealership.ID }, dealership);
        }

        // PUT: api/DealershipAPI/5
        [HttpPut("{id}")]
        public ActionResult<Dealership> Put(int id, Dealership dealership)
        {
            if (id != dealership.ID)
            {
                return BadRequest();
            }

            if (dealership == null)
            {
                return NotFound();
            }

            return _dealershipMgr.UpdateDealership(dealership);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Dealership> Delete(int id)
        {
            var dealership = _dealershipMgr.DeleteDealership(id);

            if (dealership == null)
            {
                return NotFound();
            }
            return dealership;
        }
    }
}

using ChamCong2.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamCong2.API.Controllers
{
    [Route("api/timesheets")]
    [ApiController]
    public class TimeSheetController : ControllerBase
    {
        private readonly IInterfaceRepository interfaceRepository;

        public TimeSheetController(IInterfaceRepository interfaceRepository)
        {
            this.interfaceRepository = interfaceRepository;
        }
        [HttpPost("checkin")]
        [Authorize]
        public async Task<ActionResult> CheckIn(CreatePlan createPlan)
        {
            var result = await interfaceRepository.CheckIn(createPlan);
            return Ok(await interfaceRepository.CheckIn(createPlan));
        }
        [HttpPut("{id}/checkout")]
        [Authorize]
        public async Task<ActionResult> Checkout(int id, [FromBody] PlanCheckout planCheckout)
        {
            // await userRepository.CheckOut(id, planCheckout);
            return BadRequest(await interfaceRepository.CheckOut(id, planCheckout));

        }
    }
}

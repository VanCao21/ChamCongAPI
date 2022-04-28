using ChamCong2.API.Models;
using ChamCong2.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamCong2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IInterfaceRepository interfaceRepository;

        public UserController(IInterfaceRepository interfaceRepository)
        {
            this.interfaceRepository = interfaceRepository;
        }
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult> GetUser()
        {
            try
            {
                return Ok(await interfaceRepository.GetUsers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Đã có lỗi");
                //throw;
            }

        }
        [HttpGet("{id:int}")]
        //[Authorize]
        public async Task<ActionResult<im_User>> GetUsers(int id)
        {
            try
            {
                var result = await interfaceRepository.GetUser(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Đã có lỗi");
              
            }
        }
        //[HttpPost("CheckIn")]
        ////[Authorize]
        //public async Task<ActionResult<im_User>> CheckIn(CreatePlan createPlan)
        //{
        //    //var result = await userRepository.CheckIn(createPlan);
        //    //return Helper.TransformData(result);
        //    //return await userRepository.CheckIn(result);
        //    return Ok(await interfaceRepository.CheckIn(createPlan));
        //}
        //[HttpPut("{id}/checkout")]
        //[Authorize]
        //public async Task<ActionResult> Checkout(int id, [FromBody] PlanCheckout planCheckout)
        //{
        //    // await userRepository.CheckOut(id, planCheckout);
        //    return BadRequest(await interfaceRepository.CheckOut(id, planCheckout));

        //}
    }
}

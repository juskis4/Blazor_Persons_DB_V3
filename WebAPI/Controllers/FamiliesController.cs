using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliesController : ControllerBase
    {
        private IFamilyService _familyService;

            public FamiliesController(IFamilyService familyService)
            {
                _familyService = familyService;
            }

            [HttpGet]
            public async Task<ActionResult<IList<Family>>> GetFamilies([FromQuery] int? id)
            {
                try
                {
                    IList<Family> families = await _familyService.GetAllFamiliesAsync();

                    if (id != null) //filter by id
                    {
                        families = families.Where(adult => adult.Id == id).ToList();
                    }

                    return Ok(families);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpGet]
            [Route("{id:int}")]
            public async Task<ActionResult<Family>> GetFamily([FromRoute] int id)
            {
                try
                {
                    Family family = await _familyService.GetFamilyAsync(id);
                    return Ok(family);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPost]
            public async Task<ActionResult<Family>> AddFamily([FromBody] Family family)
            {
                try
                {
                    Family added = await _familyService.AddFamilyAsync(family);
                    return Created($"/{added.Id}", added);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPatch]
            [Route("{id:int}")]
            public async Task<ActionResult<Family>> UpdateFamily([FromBody] Family family)
            {
                try
                {
                    Family updatedFamily = await _familyService.UpdateAsync(family);
                    return Ok(updatedFamily);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpDelete]
            [Route("{id:int}")]
            public async Task<ActionResult> DeleteTodo([FromRoute] int id)
            {
                try
                {
                    await _familyService.RemoveFamilyAsync(id);
                    Console.WriteLine("Delete: " + id);
                    return Ok();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }
    }
}
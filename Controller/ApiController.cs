using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using novaAPI.Data;
using novaAPI.Models;
using novaAPI.ViewModels;

namespace novaAPI.Controller
{
    // Controller e métodos
    [ApiController]
    [Route("v1")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        [Route("apis")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context)
        {
            var apis = await context.Apis
                .AsNoTracking()
                .ToListAsync();
            return Ok(apis);
        }

        [HttpGet]
        [Route("apis/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var api = await context.Apis
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return api == null
                ? NotFound()
                : Ok(api);
        }

        [HttpPost("apis")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateApiViewModel model)
        {
            if (
                !ModelState.IsValid)

                return BadRequest();

            var api = new Api
            {
                Date = DateTime.Now,
                Done = false,
                Title = model.Title
            };

            try
            {
                await context.Apis.AddAsync(api);
                await context
                    .SaveChangesAsync();
                return Created($"v1/apis/{api.Id}", api);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("apis/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateApiViewModel model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)

                return BadRequest();

            var api = await context
                .Apis
                .FirstOrDefaultAsync(x => x.Id == id);

            if (api == null)
                return NotFound();

            try
            {
                api.Title = model.Title;

                context.Apis.Update(api);
                await context
                    .SaveChangesAsync();
                return Ok(api);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("apis/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var api = await context
                .Apis
                .FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.Apis.Remove(api);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
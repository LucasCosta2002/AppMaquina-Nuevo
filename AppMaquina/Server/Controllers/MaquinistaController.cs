using AppMaquinaBD.Data.Entity;
using AppMaquinaBD.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppMaquina.Shared.DTO;
using System.Net;
using System.IO.Pipelines;

namespace AppMaquina.Server.Controllers
{
    [ApiController]
    [Route("/Maquinistas")]
    public class MaquinistaController : ControllerBase
    {
        private readonly Context context;

        public MaquinistaController(Context context)
        {
            this.context = context;
        }

        [HttpGet("{DNI:string}")]
        public async Task<ActionResult<Maquinista>> Get(string dni)
        {
            var exist = await context.Maquinistas.AnyAsync(x => x.DNI == dni);
            if (!exist)
            {
                return NotFound("Usuario no existente");
            }

            return await context.Maquinistas.FirstOrDefaultAsync(maquinista => maquinista.DNI == dni);
        }

        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<Maquinista>> Get(int id)
        //{
        //    var exist = await context.Maquinistas.AnyAsync(x => x.Id == id);
        //    if (!exist)
        //    {
        //        return NotFound("Usuario no existente");
        //    }

        //    return await context.Maquinistas.FirstOrDefaultAsync(maquinista => maquinista.Id == id);
        //}

        [HttpPost]
        public async Task<ActionResult<Maquinista>> Post(Maquinista maquinista)
        {
            try
            {
                context.Maquinistas.Add(maquinista);
                await context.SaveChangesAsync();
                return maquinista;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

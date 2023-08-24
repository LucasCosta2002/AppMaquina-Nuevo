using AppMaquinaBD.Data.Entity;
using AppMaquinaBD.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppMaquina.Shared.DTO;
using System.Net;
using System.IO.Pipelines;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AppMaquina.Server.Controllers
{
    [ApiController]
    [Route("api/Maquinistas")]
    public class MaquinistaController : ControllerBase
    {
        private readonly Context context;

        public MaquinistaController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Maquinista>>> Get()
        {
            var maquinistas = await context.Maquinistas.ToListAsync();

            if (maquinistas == null || maquinistas.Count == 0)
            {
                return BadRequest("no hay maquinistas registrados");
            }
            return maquinistas;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Maquinista>> Get(int id)
        {
            var existe = await context.Maquinistas.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El maquinista {id} no existe");
            }
            return await context.Maquinistas.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(MaquinistaDTO maquinista)
        {
            try
            {
                //var maquinistaDTO = new Maquinista
                //{
                //    DNI = maquinista.DNI,
                //    Nombre = maquinista.Nombre,
                //    Telefono = maquinista.Telefono,
                //    Password = maquinista.Password,

                //};
                context.Add(maquinista);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}

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
    [Route("api/maquinistas")]
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
            //consultar tabla y traer el maquinista

            return await context.Maquinistas.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Maquinista>> Post(MaquinistaDTO maquinista)
        {
            try
            {
                var maquinistaNuevo = new Maquinista
                {
                    DNI = maquinista.DNI,
                    Nombre = maquinista.Nombre,
                    Telefono = maquinista.Telefono,
                };
                await context.AddAsync(maquinistaNuevo);
                await context.SaveChangesAsync();
                return maquinistaNuevo;
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Maquinista maquinista, int id)
        {
            //Comprobar que el id que pasen sea el mismo que en el body
            if (id != maquinista.Id )
            {
                return BadRequest("Id invalido");
            }
            //comprobar que ese id exista en la base de datos
            var exist = await context.Maquinistas.AnyAsync(e => e.Id == id);
            if (!exist)
            {
                return BadRequest("El Maquinista no existe");
            }

            //actualizar
            context.Update(maquinista);
            await context.SaveChangesAsync();
            return Ok("Actualizado con Exito");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) 
        {
            //comprobar que ese id exista en la base de datos
            var exist = await context.Maquinistas.AnyAsync(e => e.Id == id);
            if (!exist)
            {
                return BadRequest("El Maquinista no existe");
            }

            //Asignar el id ingreasado a la entidad a borrar
            Maquinista maquinista = new Maquinista();
            maquinista.Id = id;

            context.Remove(maquinista);
            await context.SaveChangesAsync();
            return Ok("Eliminado con exito");
        }
    }
}

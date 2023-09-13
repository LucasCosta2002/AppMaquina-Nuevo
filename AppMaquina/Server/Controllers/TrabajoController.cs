using AppMaquina.Shared.DTO;
using AppMaquinaBD.Data;
using AppMaquinaBD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppMaquina.Server.Controllers
{
    [ApiController]
    [Route("api/trabajos")]
    public class TrabajoController : ControllerBase
    {
        private readonly Context context;

        public TrabajoController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Trabajo>>> Get()
        {
            var trabajo = await context.Trabajos.ToListAsync();

            if (trabajo is null || trabajo.Count == 0)
            {
                return BadRequest("No hay Trabajos registrados");
            }

            return trabajo;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Trabajo>> Get(int id)
        {
            var existe = await context.Trabajos.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return BadRequest("No existe ese trabajo");
            }

            //consultar tabla y traer el cliente
            return await context.Trabajos.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Trabajo>> Post(TrabajoDTO trabajoDTO)
        {
            //no hay comprobacion, un cliente puede tener mas de un trabajo en la zona
            try
            {
                var nuevoTrabajo = new Trabajo
                {
                    Fecha = trabajoDTO.Fecha,
                    Hectareas = (int)trabajoDTO.Hectareas,
                    Agroquimico = trabajoDTO.Agroquimico,
                    Ubicacion = trabajoDTO.Ubicacion
                };

                
                var clienteContext = await context.Clientes.FirstOrDefaultAsync(c => c.Id == trabajoDTO.ClienteId);
                var maquinistaContext = await context.Maquinistas.FirstOrDefaultAsync(m => m.Id == trabajoDTO.MaquinistaId);

                if (clienteContext is not null) 
                {
                    nuevoTrabajo.ClienteId = clienteContext.Id;
                }
                if (clienteContext is not null)
                {
                    nuevoTrabajo.MaquinistaId = clienteContext.Id;
                }

                context.Trabajos.Add(nuevoTrabajo);
                await context.SaveChangesAsync();
                return nuevoTrabajo;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Trabajo trabajo, int id)
        {
            //Comprobar que el id que pasen sea el mismo que en el body
            if (id != trabajo.Id)
            {
                return BadRequest("Id invalido");
            }
            //comprobar que ese id exista en la base de datos
            var exist = await context.Trabajos.AnyAsync(e => e.Id == id);
            if (!exist)
            {
                return BadRequest("El Trabajo no existe");
            }

            //actualizar
            context.Update(trabajo);
            await context.SaveChangesAsync();
            return Ok("Actualizado con Exito");
        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            //comprobar que ese id exista en la base de datos
            var exist = await context.Trabajos.AnyAsync(e => e.Id == id);
            if (!exist)
            {
                return BadRequest("El Trabajo no existe");
            }

            //Asignar el id ingreasado a la entidad a borrar
            Trabajo trabajo = new Trabajo();
            trabajo.Id = id;

            context.Remove(trabajo);
            await context.SaveChangesAsync();
            return Ok("Eliminado con exito");
        }
    }
}

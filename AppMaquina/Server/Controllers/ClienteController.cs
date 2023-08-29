using AppMaquina.Shared.DTO;
using AppMaquinaBD.Data;
using AppMaquinaBD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppMaquina.Server.Controllers
{
    [ApiController]
    [Route("api/Clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly Context context;

        public ClienteController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            var clientes = await context.Clientes.ToListAsync();

            if (clientes is null || clientes.Count == 0)
            {
                return BadRequest("No hay CLientes registrados");
            }

            return clientes;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            //comprobar que exista el cliente
            var existe = await context.Clientes.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return BadRequest("No existe el Cliente");
            }

            //consultar tabla y traer el cliente
            return await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }


        [HttpPost]
        public async Task<ActionResult<Cliente>> Post(ClienteDTO cliente)
        {
            try
            {
                //traer plantilla
                var clienteNuevo = new Cliente
                {
                    Nombre = cliente.Nombre,
                    Telefono = cliente.Telefono,
                    CUIL = cliente.CUIL
                };
                //agragarlo al context
                await context.AddAsync(clienteNuevo);
                await context.SaveChangesAsync();
                return clienteNuevo;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Cliente cliente, int id)
        {
            //Comprobar que el id que pasen sea el mismo que en el body
            if (id != cliente.Id)
            {
                return BadRequest("Id invalido");
            }
            //comprobar que ese id exista en la base de datos
            var exist = await context.Clientes.AnyAsync(e => e.Id == id);
            if (!exist)
            {
                return BadRequest("El Cliente no existe");
            }

            //actualizar
            context.Update(cliente);
            await context.SaveChangesAsync();
            return Ok("Actualizado con Exito");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            //comprobar que ese id exista en la base de datos
            var exist = await context.Clientes.AnyAsync(e => e.Id == id);
            if (!exist)
            {
                return BadRequest("El Cliente no existe");
            }

            //Asignar el id ingreasado a la entidad a borrar
            Cliente cliente = new Cliente();
            cliente.Id = id;

            context.Remove(cliente);
            await context.SaveChangesAsync();
            return Ok("Eliminado con exito");
        }
    }
}

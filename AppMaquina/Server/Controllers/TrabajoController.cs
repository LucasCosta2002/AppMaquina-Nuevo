using AppMaquinaBD.Data;
using AppMaquinaBD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppMaquina.Server.Controllers
{
    [ApiController]
    [Route("api/Trabajos")]
    public class TrabajoController : ControllerBase
    {
        private readonly Context context;

        public TrabajoController(Context context)
        {
            this.context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Trabajo>>> Get()
        //{
        //    return await context.Trabajos.ToListAsync();
        //}
        //[HttpPost]

        ////TrabajoDTO con email
        //public async Task<IActionResult> Post(Trabajo trabajo)
        //{
        //    try
        //    {
        //        //var maquinista = await context.Maquinistas.FirstOrDefaultAsync(maquinista => maquinista.Email == email);
        //        var nuevoTrabajo = new Trabajo
        //        {
        //            Fecha = trabajo.Fecha,
        //            Hectareas = (int)trabajo.Hectareas,
        //            Agroquimico = trabajo.Agroquimico,
        //            Ubicacion = trabajo.Ubicacion,
        //            //MaquinistaId = maquinista.Id,
        //            ClienteId = trabajo.ClienteId
        //        };

        //        context.Trabajos.Add(nuevoTrabajo);
        //        await context.SaveChangesAsync();
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}

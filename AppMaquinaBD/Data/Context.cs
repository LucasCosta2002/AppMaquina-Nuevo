using AppMaquinaBD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMaquinaBD.Data
{
    //Context es la base de datos
    public class Context : DbContext
    {

        public DbSet<Maquinista> Maquinistas => Set<Maquinista>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Trabajo> Trabajos => Set<Trabajo>();

        public Context(DbContextOptions options) : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Trabajo>(o =>
        //    {
        //        o.Property(b => b.Pago).HasColumnType("Decimal(10,8)");
        //    });

        //    var cascadeFKs = modelBuilder.Model.GetEntityTypes()
        //        .SelectMany(t => t.GetForeignKeys())
        //        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        //    foreach (var fk in cascadeFKs)
        //    {
        //        fk.DeleteBehavior = DeleteBehavior.Restrict;
        //    }

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}

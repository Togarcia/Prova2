using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;  //import per les anotacions
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace RiskProyecto
{
    class Context : DbContext
    {
        //Crea el context. Crea una DB per defecte (es a dir, MS SQL Server, amb nom "Test")
        public Context() : base("RiskBD")
        {

        }

        //Mapeig als POCOS.
        public DbSet<Jugador> Jugador { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Continente> Continente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists); //update, pero crea la DB!
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProvaContext>());  //aquest seria un metode update pero si canvies el model (els POCOS) reinicia la DB
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());  //equivaldria a un create

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Region>()
                .HasMany(r => r.Regions)
                .WithMany(re => re.Regions2)
                .Map(m =>
                    {
                        m.ToTable("Vecinos");
                    });


        }
    }
}

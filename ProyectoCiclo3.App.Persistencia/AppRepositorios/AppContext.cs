using Microsoft.EntityFrameworkCore;
using ProyectoCiclo3.App.Dominio;

namespace ProyectoCiclo3.App.Persistencia
{
    public class AppContext: DbContext{
        public DbSet<Encomienda> Encomienda { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                // optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ProyectoCiclo03");
                optionsBuilder.UseSqlServer("Data Source = misiontic2021equipo10.database.windows.net; Initial Catalog = ProyectoCiclo03; User ID=admin_equipo10_grupo27;Password=xxx");
            }
        }
    }
}


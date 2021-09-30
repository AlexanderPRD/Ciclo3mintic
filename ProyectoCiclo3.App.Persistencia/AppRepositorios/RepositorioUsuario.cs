using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioUsuario
    {
        List<Usuario> Usuario;
 
    public RepositorioUsuario()
        {
            Usuario= new List<Usuario>()
            {
                new Usuario{id=1,nombre="Mario",apellido= "Sánchez",direccion= "Carrera 27",telefono= "8945412121"},
                new Usuario{id=2,nombre="Camila",apellido= "Rodriguez",direccion= "Calle 96",telefono= "895656562"},
                new Usuario{id=3,nombre="Maria Carolina",apellido= "Perez",direccion= "Avenida Sur con 14",telefono= "12145454"} 
            };
        }
 
        public IEnumerable<Usuario> GetAll()
        {
            return Usuario;
        }
 
        public Usuario GetUsuarioWithId(int id){
            return Usuario.SingleOrDefault(b => b.id == id);
        }

        public Usuario Update(Usuario newUsuario){

            var user= Usuario.SingleOrDefault(b => b.id == newUsuario.id);

            if(usuario != null){
                user.nombre = newUsuario.nombre;
                user.apellido = newUsuario.apellido;
                user.direccion = newUsuario.direccion;
                user.telefono = newUsuario.telefono;
                // user.ciudad = newUsuario.ciudad;
            }
        return user;
        }

    }
}

using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioUsuario
    {
        List<Usuario> Usuario;

        private readonly AppContext _appContext = new AppContext(); 
 
     // public RepositorioUsuario()
     //     {
     //         Usuario= new List<Usuario>()
     //         {
     //             new Usuario{id=1,nombre="Mario",apellido= "Sánchez",direccion= "Carrera 27",telefono= "8945412121"},
      //             new Usuario{id=2,nombre="Camila",apellido= "Rodriguez",direccion= "Calle 96",telefono= "895656562"},
      //             new Usuario{id=3,nombre="Maria Carolina",apellido= "Perez",direccion= "Avenida Sur con 14",telefono= "12145454"} 
      //         };
      //     }
 
        public IEnumerable<Usuario> GetAll()
        {
           return _appContext.Usuario;
        }



        // public IEnumerable<Usuario> GetAll()
        // {
        //     return Usuario;
        // }
 
        // public Usuario GetUsuarioWithId(int id){
        //     return Usuario.SingleOrDefault(b => b.id == id);
        // }

        public Usuario GetUsuarioWithId(int id){
            return _appContext.Usuario.Find(id);
        }

        // public Usuario Update(Usuario newUsuario){

        //     var user= Usuario.SingleOrDefault(b => b.id == newUsuario.id);

        //     if(user != null){
        //         user.nombre = newUsuario.nombre;
        //         user.apellido = newUsuario.apellido;
        //         user.direccion = newUsuario.direccion;
        //         user.telefono = newUsuario.telefono;
        //         // user.ciudad = newUsuario.ciudad;
        //     }
        // return user;
        // }

        // public Usuario Create(Usuario newUsuario)
        // {
        //    if(Usuario.Count > 0){
        //    newUsuario.id=Usuario.Max(r => r.id) +1; 
        //     }else{
        //        newUsuario.id = 1; 
        //     }
        //    Usuario.Add(newUsuario);
        //    return newUsuario;
        // }
        public Usuario Create(Usuario newUsuario){
            var addUsuario = _appContext.Usuario.Add(newUsuario);
            _appContext.SaveChanges();
            return addUsuario.Entity;
        }

        public Usuario Update(Usuario newUsuario){
            var user = _appContext.Usuario.Find(newUsuario.id);

            if(user != null){
                user.nombre = newUsuario.nombre;
                user.apellido = newUsuario.apellido;
                user.direccion = newUsuario.direccion;
                user.telefono = newUsuario.telefono;
                user.ciudad = newUsuario.ciudad;
                //Guardar en base de datos
                 _appContext.SaveChanges();
            }
            return user;
        }

        public void Delete(int id)  {
        var user = _appContext.Usuario.Find(id);
        if (user == null)
            return;
        _appContext.Usuario.Remove(user);
        _appContext.SaveChanges();
        }



        // public void Delete(int id)
        // {
        // var user= Usuario.SingleOrDefault(b => b.id == id);
        // Usuario.Remove(user);
        // return;
        // }



    }
}


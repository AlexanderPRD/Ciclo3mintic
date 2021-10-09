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
 
 
        public IEnumerable<Usuario> GetAll()
        {
           return _appContext.Usuario;
        }


        public Usuario GetUsuarioWithId(int id){
            return _appContext.Usuario.Find(id);
        }

       


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
                //user.ciudad = newUsuario.ciudad;
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

    }
}


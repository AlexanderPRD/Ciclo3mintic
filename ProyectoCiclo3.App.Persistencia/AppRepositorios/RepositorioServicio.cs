using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioServicio
    {
        // List<Servicio> Servicio;

        private readonly AppContext _appContext = new AppContext(); 
 

        public IEnumerable<Servicio> GetAll()
        {
           return _appContext.Servicio;
        }


        public Servicio GetServicioWithId(int id){
            return _appContext.Servicio.Find(id);
        }

   
        public Servicio Create(Servicio newServicio){
            var addServicio = _appContext.Servicio.Add(newServicio);
            _appContext.SaveChanges();
            return addServicio.Entity;
        }

        public Servicio Update(Servicio newServicio){
            var servi = _appContext.Servicio.Find(newServicio.id);

            if(servi != null){
                servi.origen = newServicio.origen;
                servi.destino = newServicio.destino;
                servi.fecha = newServicio.fecha;
                servi.hora = newServicio.hora;
                servi.encomienda = newServicio.encomienda;

                //Guardar en base de datos
                 _appContext.SaveChanges();
            }
            return servi;
        }

        public void Delete(int id)  {
        var servi = _appContext.Servicio.Find(id);
        if (servi == null)
            return;
        _appContext.Servicio.Remove(servi);
        _appContext.SaveChanges();
        }

    }
}

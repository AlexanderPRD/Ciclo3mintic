using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioEncomienda
    {
        List<Encomienda> Encomienda;

        private readonly AppContext _appContext = new AppContext(); 
 

        public IEnumerable<Encomienda> GetAll()
        {
           return _appContext.Encomienda;
        }


        public Encomienda GetEncomiendaWithId(int id){
            return _appContext.Encomienda.Find(id);
        }

   
        public Encomienda Create(Encomienda newEncomienda){
            var addEncomienda = _appContext.Encomienda.Add(newEncomienda);
            _appContext.SaveChanges();
            return addEncomienda.Entity;
        }

        public Encomienda Update(Encomienda newEncomienda){
            var enco = _appContext.Encomienda.Find(newEncomienda.id);

            if(enco != null){
                enco.descripcion = newEncomienda.descripcion;
                enco.peso = newEncomienda.peso;
                enco.tipo = newEncomienda.tipo;
                enco.presentacion = newEncomienda.presentacion;

                //Guardar en base de datos
                 _appContext.SaveChanges();
            }
            return enco;
        }

        public void Delete(int id)  {
        var enco = _appContext.Encomienda.Find(id);
        if (enco == null)
            return;
        _appContext.Encomienda.Remove(enco);
        _appContext.SaveChanges();
        }

    }
}


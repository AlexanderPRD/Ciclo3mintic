using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioEncomienda
    {
        //List<Encomienda> encomienda;

        private readonly AppContext _appContext = new AppContext();

        public IEnumerable<Encomienda> GetAll()
        {   //El "_appContext.(Nombre exacto de la entidad), trae los datos extraidos de la base de datos.
            return _appContext.Encomienda;
        }
 
        public Encomienda GetEncomiendaWithId(int id){
            //Traer de la lista de "Encomienda" un encomienda con este identificador(Id).
            return _appContext.Encomienda.Find(id);
        }

        public Encomienda Create(Encomienda newEncomienda)
        {
            var addEncomienda = _appContext.Encomienda.Add(newEncomienda);//Agregar un nuevo elemento a la encomienda.
            _appContext.SaveChanges();//Para guardar la entidad que se acaba de crear.
            return addEncomienda.Entity; //Entity es para retornar la encomienda que se acaba de crear
        }


        public Encomienda Update(Encomienda newEncomienda){
            var user = _appContext.Encomienda.Find(newEncomienda.id);

            if(encomienda != null){
                encomienda.descripción = newEncomienda.descripción;
                encomienda.peso = newEncomienda.peso;
                encomienda.tipo = newEncomienda.tipo;
                encomienda.presentacion = newEncomienda.presentacion;
                //Guardar en base de datos.
                _appContext.SaveChanges();
            }
            
        return encomienda;
        }
        public void Delete(int id){
        var encomienda = _appContext.Encomienda.Find(id);
        if (encomienda == null)
            return;
        _appContext.Encomienda.Remove(encomienda);
        _appContext.SaveChanges();
        }

    }
}
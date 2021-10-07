using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoCiclo3.App.Persistencia.AppRepositorios;
using ProyectoCiclo3.App.Dominio;

 
namespace ProyectoCiclo3.App.Frontend.Pages
{
    public class FormServicioModel : PageModel
    {
       private readonly RepositorioServicio RepositorioServicio;
       [BindProperty]
              public Servicio Servicio {get;set;}
 
        public FormServicioModel(RepositorioServicio RepositorioServicio)
       {
            this.RepositorioServicio=RepositorioServicio;
       }
 

        public IActionResult OnPost()
        { 
            if(!ModelState.IsValid)
            {
                return Page();
            }
            // if(Servicio.id>0)
            // {
            Servicio = RepositorioServicio.Create(Servicio);
            
            return RedirectToPage("./List");
        }
    }
}

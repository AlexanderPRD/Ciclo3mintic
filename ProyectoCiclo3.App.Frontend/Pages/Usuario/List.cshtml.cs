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
    public class ListUsuarioModel : PageModel
    {
       [BindProperty]
        public Usuario usuar {get;set;}

        private readonly RepositorioUsuario repositorioUsuario;
        public IEnumerable<Usuario> Usuario {get;set;}
 
    public ListUsuarioModel(RepositorioUsuario repositorioUsuario)
    {
        this.repositorioUsuario=repositorioUsuario;
     }
 
    public void OnGet()
    {
        Usuario=repositorioUsuario.GetAll();
    }

    public IActionResult OnPost()
    {
        if(usuar.id>0)
        {
        repositorioUsuario.Delete(usuar.id);
        }
        return RedirectToPage("./List");
    }

    
    }
}


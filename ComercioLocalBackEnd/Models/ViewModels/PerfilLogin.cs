using System.ComponentModel.DataAnnotations;

namespace ComercioLocalBackEnd.Models.ViewModels
{

    public class PerfilLogin
    {

        [Required]
        public string Email{get;set;}
        [Required]
        public string Senha{get;set;}

    }
}
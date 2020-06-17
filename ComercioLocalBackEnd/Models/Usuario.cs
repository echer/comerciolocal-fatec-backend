using System;
using System.ComponentModel.DataAnnotations;

namespace ComercioLocalBackEnd.Models{

    public class Usuario:Entity{

        [Required]
        public string Nome{get; set;}
        public string DataNascimento{get;set;}
        [Required]
        public string Email{get; set;}
        [Required]
        public string Senha{get; set;}
        [Required]
        public string TelefoneMovel{get; set;}
        public string TelefoneFixo{get; set;}

    }

}
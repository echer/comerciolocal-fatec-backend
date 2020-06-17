using System;
using System.ComponentModel.DataAnnotations;

namespace ComercioLocalBackEnd.Models{

    public class UsuarioUpdate{
        [Required]
        public string Nome{get; set;}
        public string DataNascimento{get;set;}
        public string Senha{get; set;}
        public string TelefoneMovel{get; set;}
        public string TelefoneFixo{get; set;}
    }
}
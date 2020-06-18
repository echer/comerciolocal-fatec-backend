using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComercioLocalBackEnd.Models{

    public class Perfil:Entity{

        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [Required]
        public string Razao{get; set;}    
        [Required]
        public string Fantasia{get; set;}
        [Required]
        public string DataAbertura{get;set;}
        [Required]
        public string CNPJ{get; set;}
        public string Site{get; set;}
        [Required]
        public string Descricao{get; set;}
        [Required]
        public string CEP{get;set;}
        [Required]
        public string Logradouro{get;set;}
        public string Numero{get;set;}
        public string Complemento{get;set;}
        [Required]
        public string UF{get;set;}
        [Required]
        public string Pais{get;set;}
        [Required]
        public string Segmento{get;set;}

        public ICollection<Promocao> Promocoes { get; set; }

        public Perfil(){
            
        }

    }
}
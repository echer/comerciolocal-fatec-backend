using System;
using System.ComponentModel.DataAnnotations;

namespace ComercioLocalBackEnd.Models{

    public class Perfil:Entity{

        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Razao{get; set;}    
        public string Fantasia{get; set;}
        public string DataAbertura{get;set;}
        public string CNPJ{get; set;}
        public string Site{get; set;}
        public string Descricao{get; set;}
        public string CEP{get;set;}
        public string Logradouro{get;set;}
        public string Endereco{get;set;}
        public string Complemento{get;set;}
        public string UF{get;set;}
        public string Pais{get;set;}
        public string Segmento{get;set;}

        public Perfil(){
            
        }

    }
}
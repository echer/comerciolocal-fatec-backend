using System;
using System.ComponentModel.DataAnnotations;

namespace ComercioLocalBackEnd.Models{

    public class Promocao:Entity{
        public Guid PerfilId { get; set; }
        public Perfil Perfil{get;set;}
        public string DataInicio{get;set;}
        public string DataFim{get;set;}
        [Required]
        public string Descricao{get;set;}
        //TODO VERIFICAR TRANSMISSAO DA IMAGEM SE DER
        public string MidiaPromocao{get;set;}
        public string CupomPromocao{get;set;}

        public Promocao(){
            
        }

    }
}
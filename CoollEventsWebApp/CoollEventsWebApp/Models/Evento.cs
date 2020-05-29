using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoollEventsWebApp.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DataEvento { get; set; }
        public string HorarioInicio { get; set; }
        public string HorarioTermino { get; set; }
        public int Publico { get; set; }
        public int Oculto { get; set; }
        public int MaxPessoas { get; set; }
        public int Descricao { get; set; }
        public string Imagem { get; set; }
        public string Logo { get; set; } // Verificar
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public int Id_tipo { get; set; }
        public int Id_usuario { get; set; }
        public int Id_convidado { get; set; } //    
        public int Id_lista { get; set; }   //

        //Verificar os campos finais (FK'S) para ver se será necessário
        //Verificar qual tabela puxará qual.
    }
}
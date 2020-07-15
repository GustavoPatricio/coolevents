using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace CoollEventsWebApp.Models {
    public class EventoView {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DataEvento { get; set; }
        public string Inicio { get; set; }
        public string Fim { get; set; }
        public int PessoasConfirmadas { get; set; }
        public int MaxPessoas { get; set; }
        public string Descricao { get; set; }
        public string Logo { get; set; }
        public string Background { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string TipoEvento { get; set; }


        public static EventoView GetEventoById(int idEvento) {

            EventoView evento = new EventoView();

            BDConexao conexao = new BDConexao();
            conexao.command.CommandText = @"SELECT 
                NOME, DATA_EVENTO, INICIO, FIM, MAX_PESSOAS, 
                (SELECT COUNT(*) FROM tbl_convidado WHERE ID_EVENTO = @IDEVENTO) AS [PESSOAS CONFIRMADAS], 
                DESCRICAO, LOGO, BACKGROUND, UF, CIDADE, CEP, BAIRRO, LOGRADOURO, NUMERO,
                COMPLEMENTO, (SELECT TIPO FROM tbl_tipoevento WHERE ID_TIPO = (SELECT ID_TIPO FROM TBL_EVENTO WHERE ID_EVENTO = @IDEVENTO)) AS [TIPO EVENTO]
                FROM tbl_evento where id_evento = @IDEVENTO";

            conexao.command.Parameters.Add("@IDEVENTO", SqlDbType.VarChar).Value = idEvento;

            conexao.connection.Open();

            SqlDataReader dr = conexao.command.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    evento.Id = idEvento;
                    evento.Nome = dr.GetString(0);
                    evento.DataEvento = dr.GetDateTime(1).ToString();
                    evento.Inicio = dr.GetTimeSpan(2).ToString();
                    evento.Fim = dr.GetTimeSpan(2).ToString();
                    evento.MaxPessoas = dr.GetInt32(4);
                    evento.PessoasConfirmadas = dr.GetInt32(5);
                    evento.Descricao = dr.GetString(6);
                    evento.Logo = dr.GetString(7);
                    evento.Background = dr.GetString(8);
                    evento.UF = dr.GetString(9);
                    evento.Cidade = dr.GetString(10);
                    evento.CEP = dr.GetString(11);
                    evento.Bairro = dr.GetString(12);
                    evento.Logradouro = dr.GetString(13);
                    evento.Numero = Convert.ToInt32(dr.GetString(14));
                    evento.Complemento = dr.GetString(15);
                    evento.TipoEvento = dr.GetString(16);
                }
            }
            conexao.connection.Close();
            return evento;
        }

    }
}
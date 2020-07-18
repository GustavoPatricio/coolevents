using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace CoollEventsWebApp.Models {
    public class EventoTemplate {

        public int idEvento { get; set; }
        public string Nome { get; set; }
        public string Logo { get; set; }
        public string Data_evento { get; set; }
        public string Descricao { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public static List<EventoTemplate> GetAll() {
            List<EventoTemplate> eventos = new List<EventoTemplate>();

            BDConexao conexao = new BDConexao();
            conexao.command.CommandText = "Select id_evento, nome, logo, data_evento, descricao, cidade, UF from tbl_evento where oculto = 0 and publico = 1";
            conexao.connection.Open();
            SqlDataReader dr = conexao.command.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    EventoTemplate evento = new EventoTemplate();
                    evento.idEvento = dr.GetInt32(0);
                    evento.Nome = dr.GetString(1);
                    evento.Logo = dr.GetString(2);
                    evento.Data_evento = Convert.ToString(dr.GetDateTime(3));
                    evento.Descricao = dr.GetString(4);
                    evento.Cidade = dr.GetString(5);
                    evento.UF = dr.GetString(6);

                    //adiciona evento
                    eventos.Add(evento);
                }
            }

            return eventos;
        }

        public static List<EventoTemplate> GetMyEvents() {
            List<EventoTemplate> eventos = new List<EventoTemplate>();

            BDConexao conexao = new BDConexao();
            conexao.command.CommandText = "Select id_evento, nome, logo, data_evento, descricao, cidade, UF from tbl_evento where id_usuario = @IDUSUARIO ";
            conexao.command.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = HttpContext.Current.Session["idUsuario"];
            conexao.connection.Open();
            SqlDataReader dr = conexao.command.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    EventoTemplate evento = new EventoTemplate();
                    evento.idEvento = dr.GetInt32(0);
                    evento.Nome = dr.GetString(1);
                    evento.Logo = dr.GetString(2);
                    evento.Data_evento = Convert.ToString(dr.GetDateTime(3));
                    evento.Descricao = dr.GetString(4);
                    evento.Cidade = dr.GetString(5);
                    evento.UF = dr.GetString(6);

                    //adiciona evento
                    eventos.Add(evento);
                }
            }

            return eventos;
        }
        public static List<EventoTemplate> GetEventsImIn() {
            List<EventoTemplate> eventos = new List<EventoTemplate>();

            BDConexao conexao = new BDConexao();
            conexao.command.CommandText = @"Select id_evento, nome, logo, data_evento, descricao, cidade, UF 
                from tbl_evento WHERE id_evento in (SELECT ID_EVENTO FROM TBL_CONVIDADO WHERE ID_USUARIO = @IDUSUARIO AND CONFIRMADO = 1)";

            conexao.command.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = HttpContext.Current.Session["idUsuario"];
            conexao.connection.Open();
            SqlDataReader dr = conexao.command.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    EventoTemplate evento = new EventoTemplate();
                    evento.idEvento = dr.GetInt32(0);
                    evento.Nome = dr.GetString(1);
                    evento.Logo = dr.GetString(2);
                    evento.Data_evento = Convert.ToString(dr.GetDateTime(3));
                    evento.Descricao = dr.GetString(4);
                    evento.Cidade = dr.GetString(5);
                    evento.UF = dr.GetString(6);

                    //adiciona evento
                    eventos.Add(evento);
                }
            }

            return eventos;
        }

        public static List<EventoTemplate> GetEventosByName(string nome) {
            List<EventoTemplate> eventos = new List<EventoTemplate>();

            BDConexao conexao = new BDConexao();
            conexao.command.CommandText = "Select id_evento, nome, logo, data_evento, descricao, cidade, UF from tbl_evento where oculto = 0 and publico = 1 and nome like @NOME";
            conexao.command.Parameters.Add("@NOME", SqlDbType.VarChar).Value = "%" + nome + "%";
            conexao.connection.Open();
            SqlDataReader dr = conexao.command.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    EventoTemplate evento = new EventoTemplate();

                    evento.idEvento = dr.GetInt32(0);
                    evento.Nome = dr.GetString(1);
                    evento.Logo = dr.GetString(2);
                    evento.Data_evento = Convert.ToString(dr.GetDateTime(3));
                    evento.Descricao = dr.GetString(4);
                    evento.Cidade = dr.GetString(5);
                    evento.UF = dr.GetString(6);

                    //adiciona evento
                    eventos.Add(evento);
                }
            }

            return eventos;
        }
    }
}
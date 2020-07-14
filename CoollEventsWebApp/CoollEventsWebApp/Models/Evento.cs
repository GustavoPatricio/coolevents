using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CoollEventsWebApp.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DataEvento { get; set; }
        public string DataCriacao { get; set; }
        public string Inicio { get; set; }
        public string Fim { get; set; }
        public bool Publico { get; set; }
        public bool Oculto { get; set; }
        public int MaxPessoas { get; set; }
        public string Descricao { get; set; }
        public HttpPostedFileBase Logo { get; set; } 
        public HttpPostedFileBase Background { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string TipoEvento { get; set; }
        public int Id_usuario { get; set; }

        public void Cadastrar() {

            string urlLogo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(Logo.FileName);

            string urlBackground = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(Background.FileName);

            var path = (@"C:\ImageProvider\public\eventoLogo\" +  urlLogo);
            Logo.SaveAs(path);

            path = (@"C:\ImageProvider\public\eventoBackground\" + urlBackground);
            Background.SaveAs(path);

            BDConexao conexao = new BDConexao();
            conexao.command.CommandText = "INSERT INTO TBL_EVENTO OUTPUT INSERTED.ID_EVENTO values (@NOME, @DATA_EVENTO, @DATA_CRIACAO, @INICIO, @FIM, @PUBLICO, @OCULTO, @MAX_PESSOAS, @DESCRICAO, @LOGO, @BACKGROUND, " +
                "@UF, @CIDADE, @CEP, @BAIRRO, @LOGRADOURO, @NUMERO, @COMPLEMENTO, @ID_TIPO, @ID_USUARIO)";

            conexao.command.Parameters.Add("@NOME", SqlDbType.VarChar).Value = Nome;
            conexao.command.Parameters.Add("@DATA_EVENTO", SqlDbType.DateTime).Value = DataEvento;
            conexao.command.Parameters.Add("@DATA_CRIACAO", SqlDbType.DateTime).Value = DateTime.Now;
            conexao.command.Parameters.Add("@INICIO", SqlDbType.Time).Value = Inicio;
            conexao.command.Parameters.Add("@FIM", SqlDbType.Time).Value = Fim;
            conexao.command.Parameters.Add("@PUBLICO", SqlDbType.Bit).Value = Publico;
            conexao.command.Parameters.Add("@OCULTO", SqlDbType.Bit).Value = false;
            conexao.command.Parameters.Add("@MAX_PESSOAS", SqlDbType.Int).Value = MaxPessoas;
            conexao.command.Parameters.Add("@DESCRICAO", SqlDbType.NVarChar).Value = Descricao;
            conexao.command.Parameters.Add("@LOGO", SqlDbType.NVarChar).Value = urlLogo;
            conexao.command.Parameters.Add("@BACKGROUND", SqlDbType.VarChar).Value = urlBackground;
            conexao.command.Parameters.Add("@UF", SqlDbType.Char).Value = UF;
            conexao.command.Parameters.Add("@CIDADE", SqlDbType.VarChar).Value = Cidade;
            conexao.command.Parameters.Add("@CEP", SqlDbType.VarChar).Value = CEP;
            conexao.command.Parameters.Add("@BAIRRO", SqlDbType.NVarChar).Value = Bairro;
            conexao.command.Parameters.Add("@LOGRADOURO", SqlDbType.NVarChar).Value = Logradouro;
            conexao.command.Parameters.Add("@NUMERO", SqlDbType.Int).Value = Numero;
            conexao.command.Parameters.Add("@COMPLEMENTO", SqlDbType.VarChar).Value = Complemento;
            conexao.command.Parameters.Add("@ID_TIPO", SqlDbType.Int).Value = TipoEvento;
            conexao.command.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = HttpContext.Current.Session["idUsuario"];

            conexao.connection.Open();
            int idUsuario = (int) conexao.command.ExecuteScalar();
            conexao.connection.Close();
            Id = idUsuario;

        }

        public void GetEventoById(int idEvento) {
            BDConexao conexao = new BDConexao();
            conexao.command.CommandText = @"SELECT 
                NOME, DATA_EVENTO, INICIO, FIM, MAX_PESSOAS, 
                (SELECT COUNT(*) FROM tbl_convidado WHERE ID_EVENTO = @IDEVENTO) AS [PESSOAS CONFIRMADAS], 
                DESCRICAO, LOGO, BACKGROUND, UF, CIDADE, CEP, BAIRRO, LOGRADOURO, NUMERO,
                COMPLEMENTO, (SELECT TIPO FROM tbl_tipoevento WHERE ID_TIPO = (SELECT ID_TIPO FROM TBL_EVENTO WHERE ID_EVENTO = @IDEVENTO)) AS [TIPO EVENTO]
                FROM tbl_evento where id_evento = @IDEVENTO";

            conexao.command.Parameters.Add("@IDEVENTO", SqlDbType.VarChar).Value = idEvento;

            //continuar com data reader
        }

        public static List<Tipo> GetTipos() {
            List<Tipo> lista_de_tipos = new List<Tipo>();


            BDConexao conexao = new BDConexao();
            conexao.connection.Open();
            conexao.command.CommandText = "SELECT ID_TIPO,TIPO FROM TBL_TIPOEVENTO";

            SqlDataReader dr = conexao.command.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Tipo tipo = new Tipo();
                    tipo.Id = dr.GetInt32(0);
                    tipo.Nome = dr.GetString(1);
                    lista_de_tipos.Add(tipo);
                }
            }
            conexao.connection.Close();

            return lista_de_tipos;
            
        } 
    }

    public class Tipo {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class EventoeTipo {
        Evento evento = new Evento();
        Tipo tipo = new Tipo();
    }
}
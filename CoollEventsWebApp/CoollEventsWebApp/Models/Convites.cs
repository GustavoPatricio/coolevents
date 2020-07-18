using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace CoollEventsWebApp.Models {
    public class Convites {

        public int Id_evento { get; set; }
        public string Logo { get; set; }
        public string Nome { get; set; }
        public string DataEvento { get; set; }


        public static List<Convites> RetornarConvites() {
            List<Convites> convites = new List<Convites>();

            BDConexao conexao = new BDConexao();
            conexao.command.CommandText = "select id_evento, logo, tbl_evento.NOME, tbl_evento.DATA_EVENTO " +
                "from tbl_evento where " +
                "ID_EVENTO in (select id_evento from tbl_convidado where ID_USUARIO = @IDUSUARIO and CONFIRMADO = 0)";
            conexao.command.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = HttpContext.Current.Session["idUsuario"];

            conexao.connection.Open();

            SqlDataReader dr = conexao.command.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Convites convite = new Convites();
                    convite.Id_evento = dr.GetInt32(0);
                    convite.Logo = dr.GetString(1);
                    convite.Nome = dr.GetString(2);
                    convite.DataEvento = dr.GetDateTime(3).ToString();

                    convites.Add(convite);
                }
            }

            conexao.connection.Close();

            return convites;
        }

        public static void ConfirmarPresenca(int idEvento) {
            BDConexao conexao = new BDConexao();
            conexao.command.CommandText = "UPDATE tbl_convidado SET CONFIRMADO = 1 WHERE ID_USUARIO = @IDUSUARIO AND ID_EVENTO = @IDEVENTO";
            conexao.command.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = HttpContext.Current.Session["idUsuario"];
            conexao.command.Parameters.Add("@IDEVENTO", SqlDbType.Int).Value = idEvento;

            conexao.connection.Open();
            var linhasfetadas = (int)conexao.command.ExecuteNonQuery();

            if(linhasfetadas == 0)
            {
                conexao.command.CommandText = "INSERT INTO TBL_CONVIDADO VALUES (@IDUSUARIO, @IDEVENTO, 1)";
                conexao.command.ExecuteNonQuery();
            }


            conexao.command.CommandText = "select count(*) from tbl_convidado where id_evento = @IDEVENTO and confirmado = 1";

            int confirmados = (int)conexao.command.ExecuteScalar();

            conexao.command.CommandText = "select max_pessoas from tbl_evento where id_evento = @IDEVENTO";

            int max = (int)conexao.command.ExecuteScalar();

            if (max == 0)
            {
                conexao.connection.Close();
                return;
            }

            if(confirmados >= max)
            {
                conexao.command.CommandText = "UPDATE TBL_EVENTO SET OCULTO = 1 WHERE ID_EVENTO = @IDEVENTO";

                conexao.command.ExecuteNonQuery();
            }

            conexao.connection.Close();
        }
    }
}
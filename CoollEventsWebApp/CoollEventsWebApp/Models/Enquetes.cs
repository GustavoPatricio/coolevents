using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CoollEventsWebApp.Models {
    public class Enquetes {

        public int Id { get; set; }
        public string TipoEnquete { get; set; }
        public string Imagem { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string PrazoResposta { get; set; }

        public static List<Enquetes> GetAll() {

            List<Enquetes> enquetes = new List<Enquetes>();

            BDConexao conexao = new BDConexao( );
            conexao.command.CommandText = @"
                select ID_ENQUETE, tbl_tipoevento.TIPO, IMAGEM, TITULO, TEXTO, PRAZO FROM tbl_enquete LEFT JOIN tbl_tipoevento ON tbl_enquete.ID_TIPO = tbl_tipoevento.ID_TIPO
                where ID_ENQUETE not in (select id_enquete from tbl_resultado where id_usuario = @IDUSUARIO) AND OCULTO = 0";

            conexao.command.Parameters.Add("@IDUSUARIO", SqlDbType.VarChar).Value = HttpContext.Current.Session["idUsuario"];

            conexao.connection.Open();

            SqlDataReader dr = conexao.command.ExecuteReader();

            if(dr.HasRows)
            {
                while (dr.Read())
                {
                    Enquetes enquete = new Enquetes();
                    enquete.Id = dr.GetInt32(0);
                    enquete.TipoEnquete = dr.GetString(1);
                    enquete.Imagem = dr.GetString(2);
                    enquete.Titulo = dr.GetString(3);
                    enquete.Texto = dr.GetString(4);
                    enquete.PrazoResposta = dr.GetDateTime(5).ToString();

                    enquetes.Add(enquete);
                }
            }

            conexao.connection.Close();

            return enquetes;
        }

    }
}
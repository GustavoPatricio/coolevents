using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace CoollEventsWebApp.Models {
    public class Enquete {

        public int Id { get; set; }
        public string id_Tipo { get; set; }
        public string Imagem { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Prazo { get; set; }
        public int Oculto { get; set; }
        public int Valor { get; set; }
        public string QUESTAO_A { get; set; }
        public string ALTERNATIVA_AA { get; set; }
        public string ALTERNATIVA_AB { get; set; }
        public string ALTERNATIVA_AC { get; set; }
        public string ALTERNATIVA_AD { get; set; }
        public string QUESTAO_B { get; set; }
        public string ALTERNATIVA_BA { get; set; }
        public string ALTERNATIVA_BB { get; set; }
        public string ALTERNATIVA_BC { get; set; }
        public string ALTERNATIVA_BD { get; set; }
        public EnqueteResposta Resposta { get; set; }

        public Enquete GetEnqueteById(int id) {

            Enquete enquete = new Enquete();

            BDConexao conexao = new BDConexao();
            conexao.command.CommandText = @"SELECT * FROM TBL_ENQUETE WHERE ID_ENQUETE = @IDENQUETE";

            conexao.command.Parameters.Add("@IDENQUETE", SqlDbType.Int).Value = id;

            conexao.connection.Open();

            SqlDataReader dr = conexao.command.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    this.Id = dr.GetInt32(0);
                    this.Imagem = dr.GetString(2);
                    this.Titulo = dr.GetString(3);
                    this.Texto = dr.GetString(4);
                    this.Prazo = dr.GetDateTime(5).ToString().Substring(0, 10);
                    this.Valor = dr.GetInt32(7);
                    this.QUESTAO_A = dr.GetString(8);
                    this.ALTERNATIVA_AA = dr.GetString(9);
                    this.ALTERNATIVA_AB = dr.GetString(10);
                    this.ALTERNATIVA_AC = dr.GetString(11);
                    this.ALTERNATIVA_AD = dr.GetString(12);
                    this.QUESTAO_B = dr.GetString(13);
                    this.ALTERNATIVA_BA = dr.GetString(14);
                    this.ALTERNATIVA_BB = dr.GetString(15);
                    this.ALTERNATIVA_BC = dr.GetString(16);
                    this.ALTERNATIVA_BD = dr.GetString(17);
                }
            }

            conexao.connection.Close();

            return enquete;
        }
    }

    public class EnqueteResposta {

        public int Id { get; set; }
        public int Id_Enquete { get; set; }
        public int Id_Usuario { get; set; }
        public string Realizado { get; set; }
        public char QUESTAO_A { get; set; }
        public char QUESTAO_B { get; set; }
        public int Pontuacao { get; set; }

        public void Submit() {
            BDConexao conexao = new BDConexao();
            conexao.command.CommandText = @"INSERT INTO TBL_RESULTADO VALUES (@IDENQUETE, @IDUSUARIO, @REALIZADO, @QUESTAOA, @QUESTAOB, @PONTUACAO)";
            conexao.command.Parameters.Add("@IDENQUETE", SqlDbType.Int).Value = Id_Enquete;
            conexao.command.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = HttpContext.Current.Session["idUsuario"];
            conexao.command.Parameters.Add("@REALIZADO", SqlDbType.DateTime).Value = DateTime.Today;
            conexao.command.Parameters.Add("@QUESTAOA", SqlDbType.Char).Value = QUESTAO_A;
            conexao.command.Parameters.Add("@QUESTAOB", SqlDbType.Char).Value = QUESTAO_B;
            conexao.command.Parameters.Add("@PONTUACAO", SqlDbType.Int).Value = Pontuacao;

            conexao.connection.Open();
            conexao.command.ExecuteNonQuery();

            conexao.command.CommandText = @"update tbl_usuario set PONTUACAO = (select sum(pontuacao) from tbl_resultado) WHERE ID_USUARIO = @IDUSUARIO";


            conexao.command.ExecuteNonQuery();
            conexao.connection.Close();

        }

    }
}
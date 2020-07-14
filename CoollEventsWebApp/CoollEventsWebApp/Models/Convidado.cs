using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace CoollEventsWebApp.Models {
    public class Convidado {
        public static void Cadastrar(string email, int idEvento) {

            BDConexao conexao = new BDConexao();


            conexao.command.CommandText = "INSERT INTO tbl_convidado(id_usuario, id_evento, CONFIRMADO)  VALUES ((SELECT ID_USUARIO FROM TBL_USUARIO WHERE EMAIL = @EMAIL), @ID_EVENTO, 0)";

            conexao.command.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = email;
            conexao.command.Parameters.Add("@ID_EVENTO", SqlDbType.Int).Value = idEvento;

            conexao.connection.Open();
            conexao.command.ExecuteNonQuery();
            conexao.connection.Close();
        }
        public static bool Verificar(string email) {

            BDConexao conexao = new BDConexao();


            conexao.command.CommandText = "SELECT COUNT(*) FROM TBL_USUARIO WHERE EMAIL = @EMAIL";

            conexao.command.Parameters.Add("@EMAIL" , SqlDbType.VarChar).Value = email;

            conexao.connection.Open();
            int possui = (int) conexao.command.ExecuteScalar();
            conexao.connection.Close();

            if (possui == 0) return false;
            else return true;
        }
    } 
}
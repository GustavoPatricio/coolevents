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


            conexao.command.CommandText = "INSERT INTO tbl_convidado VALUES (" +
                "(SELECT ID_USUARIO FROM TBL_USUARIO WHERE EMAIL = @EMAIL), " +
                "@ID_EVENTO" +
                ")";

            conexao.command.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = email;
            conexao.command.Parameters.Add("@ID_EVENTO", SqlDbType.Int).Value = idEvento;

            conexao.connection.Open();
            conexao.command.ExecuteNonQuery();
            conexao.connection.Close();
        }
    }
}
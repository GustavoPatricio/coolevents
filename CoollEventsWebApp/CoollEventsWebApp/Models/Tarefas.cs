using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CoollEventsWebApp.Models {
    public class Tarefas {

        public int Id_tarefa { get; set; }
        public string Tarefa { get; set; }
        public int Id_evento { get; set; }
        public int Id_convidado { get; set; }

        public void Cadastrar() {

            BDConexao conexao = new BDConexao();

            conexao.command.CommandText = "INSERT INTO TBL_TAREFA(TAREFA, ID_EVENTO) VALUES (@TAREFA, @ID_EVENTO)";
            conexao.command.Parameters.Add("@TAREFA", SqlDbType.VarChar).Value = Tarefa;
            conexao.command.Parameters.Add("@ID_EVENTO", SqlDbType.Int).Value = Id_evento;

            conexao.connection.Open();
            conexao.command.ExecuteNonQuery();
            conexao.connection.Close();

        }
    }
}
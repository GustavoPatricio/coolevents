using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CoollEventsWebApp.Models;

namespace CoollEventsWebApp.Models
{
    public class Usuario {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }
        public string DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Foto { get; set; }
        public string Apelido { get; set; }
        public string Civil { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Descricao { get; set; }
        public int Pontuacao { get; set; }
    
        //public bool Check() {
            
        //}

        public bool Cadastrar() {
            try {
                this.Pontuacao = 0;

                BDConexao conexao = new BDConexao();

                conexao.command.CommandText = "INSERT INTO tbl_USUARIO values (@NOME, @SOBRENOME, @EMAIL, @SENHA, @NASC, @SEXO, null, @APELIDO, @CIVIL, @UF, " +
                    "@CIDADE, @CEP, @BAIRRO, @LOGRADOURO, @NUMERO, @COMPLEMENTO, @DESCRICAO, @PONTUACAO)";

                conexao.command.Parameters.Add("@NOME", SqlDbType.NVarChar).Value = Nome;
                conexao.command.Parameters.Add("@SOBRENOME", SqlDbType.NVarChar).Value = Sobrenome;
                conexao.command.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = Email;
                conexao.command.Parameters.Add("@SENHA", SqlDbType.NVarChar).Value = CoolEventsEncrypter.Encrypt(Senha);
                conexao.command.Parameters.Add("@NASC", SqlDbType.Date).Value = DataNascimento;
                conexao.command.Parameters.Add("@SEXO", SqlDbType.Char).Value = Sexo;
                conexao.command.Parameters.Add("@APELIDO", SqlDbType.NVarChar).Value = Apelido;
                conexao.command.Parameters.Add("@CIVIL", SqlDbType.NVarChar).Value = Civil;
                conexao.command.Parameters.Add("@UF", SqlDbType.NVarChar).Value = UF;
                conexao.command.Parameters.Add("@CIDADE", SqlDbType.NVarChar).Value = Cidade;
                conexao.command.Parameters.Add("@CEP", SqlDbType.NVarChar).Value = CEP;
                conexao.command.Parameters.Add("@BAIRRO", SqlDbType.NVarChar).Value = Bairro;
                conexao.command.Parameters.Add("@LOGRADOURO", SqlDbType.NVarChar).Value = Logradouro;
                conexao.command.Parameters.Add("@NUMERO", SqlDbType.VarChar).Value = Numero;
                conexao.command.Parameters.Add("@COMPLEMENTO", SqlDbType.NVarChar).Value = Complemento;
                conexao.command.Parameters.Add("@DESCRICAO", SqlDbType.NVarChar).Value = Descricao;
                conexao.command.Parameters.Add("@PONTUACAO", SqlDbType.Int).Value = Pontuacao;

                conexao.connection.Open();
                conexao.command.ExecuteNonQuery();
                conexao.connection.Close();

                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }


        public Usuario GetUser(int id) {
            Usuario user = new Usuario();

            BDConexao conexao = new BDConexao();

            conexao.command.CommandText = "SELECT * from tbl_USUARIO WHERE ID_USUARIO = @IDUSUARIO";
            conexao.command.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = id;

            conexao.connection.Open();
       
            SqlDataReader dr = conexao.command.ExecuteReader();

            

            if (dr.HasRows)
            {
                dr.Read();

                user.Id = dr.GetInt32(0).ToString();
                user.Nome = dr.GetString(1);
                user.Sobrenome = dr.GetString(2);
                user.Email = dr.GetString(3);
                //user.Senha = dr.GetString(4);
                user.DataNascimento = Convert.ToString(dr.GetDateTime(5));
                user.Sexo = dr.GetString(6);
                //user.Foto = dr.GetString(7);
                user.Apelido = dr.GetString(8);
                user.Civil = dr.GetString(9);
                user.UF = dr.GetString(10);
                user.Cidade = dr.GetString(11);
                user.CEP = dr.GetString(12);
                user.Bairro = dr.GetString(13);
                user.Logradouro = dr.GetString(14);
                user.Numero = dr.GetString(15);
                user.Complemento = dr.GetString(16);
                user.Descricao = dr.GetString(17);
                user.Pontuacao = dr.GetInt32(18);

                conexao.connection.Close();
                return user;
                
            }
            else {
                conexao.connection.Close();
                return null;
            }
        }
    }
}
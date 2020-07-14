using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CoollEventsWebApp.Models;
using System.Web.Helpers;

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

                conexao.command.CommandText = "INSERT INTO tbl_USUARIO values (@NOME, @SOBRENOME, @EMAIL, @SENHA, @NASC, @GENERO, @FOTO, @APELIDO, @CIVIL, @UF, " +
                    "@CIDADE, @CEP, @BAIRRO, @LOGRADOURO, @NUMERO, @COMPLEMENTO, @DESCRICAO, @PONTUACAO)";

                conexao.command.Parameters.Add("@NOME", SqlDbType.NVarChar).Value = Nome;
                conexao.command.Parameters.Add("@SOBRENOME", SqlDbType.NVarChar).Value = Sobrenome;
                conexao.command.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = Email;
                conexao.command.Parameters.Add("@SENHA", SqlDbType.NVarChar).Value = CoolEventsEncrypter.Encrypt(Senha);
                conexao.command.Parameters.Add("@NASC", SqlDbType.Date).Value = DataNascimento;
                conexao.command.Parameters.Add("@GENERO", SqlDbType.Char).Value = Sexo;
                conexao.command.Parameters.Add("@FOTO", SqlDbType.NVarChar).Value = "";
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
                user.Foto = dr.GetString(7);
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

        public bool UpdateUser(Usuario usuario, int idUsuario) {

            try { 
                BDConexao conexao = new BDConexao();

                string command = "exec updateUsuario " +
                    "@IDUSUARIO = @_ID, " +
                    "@NOME = @_NOME, " +
                    "@SOBRENOME = @_SOBRENOME, " +
                    "@EMAIL = @_EMAIL, " +
                    "@NASC = @_NASC, " +
                    "@GENERO = @_SEXO, " +
                    "@APELIDO = @_APELIDO, " +
                    "@CIVIL = @_CIVIL, " +
                    "@UF = @_UF, " +
                    "@CIDADE = @_CIDADE, " +
                    "@CEP = @_CEP, " +
                    "@BAIRRO = @_BAIRRO, " +
                    "@LOGRADOURO = @_LOGRADOURO," +
                    "@NUMERO = @_NUMERO, " +
                    "@COMPLEMENTO = @_COMPLEMENTO," +
                    "@DESCRICAO = @_DESCRICAO";

                conexao.command.CommandText = command;
                conexao.command.Parameters.Add("@_ID", SqlDbType.Int).Value = idUsuario;
                conexao.command.Parameters.Add("@_NOME", SqlDbType.VarChar).Value = usuario.Nome;
                conexao.command.Parameters.Add("@_SOBRENOME", SqlDbType.VarChar).Value = usuario.Sobrenome;
                conexao.command.Parameters.Add("@_EMAIL", SqlDbType.VarChar).Value = usuario.Email;
                conexao.command.Parameters.Add("@_NASC", SqlDbType.Date).Value = usuario.DataNascimento;
                conexao.command.Parameters.Add("@_SEXO", SqlDbType.Char).Value = usuario.Sexo;
                conexao.command.Parameters.Add("@_APELIDO", SqlDbType.VarChar).Value = usuario.Apelido;
                conexao.command.Parameters.Add("@_CIVIL", SqlDbType.VarChar).Value = usuario.Civil;
                conexao.command.Parameters.Add("@_UF", SqlDbType.Char).Value = usuario.UF;
                conexao.command.Parameters.Add("@_CIDADE", SqlDbType.VarChar).Value = usuario.Cidade;
                conexao.command.Parameters.Add("@_CEP", SqlDbType.VarChar).Value = usuario.CEP;
                conexao.command.Parameters.Add("@_BAIRRO", SqlDbType.VarChar).Value = usuario.Bairro;
                conexao.command.Parameters.Add("@_LOGRADOURO", SqlDbType.VarChar).Value = usuario.Logradouro;
                conexao.command.Parameters.Add("@_NUMERO", SqlDbType.Int).Value = usuario.Numero;
                conexao.command.Parameters.Add("@_COMPLEMENTO", SqlDbType.VarChar).Value = usuario.Complemento;
                conexao.command.Parameters.Add("@_DESCRICAO", SqlDbType.VarChar).Value = usuario.Descricao;

                conexao.connection.Open();
                conexao.command.ExecuteNonQuery();
                conexao.connection.Close();

                return true;
            }
            catch(Exception Ex) {  
                return false;
            }
        }

        public static int TrocarSenha(int idUsuario, string senhaAtual, string SenhaNova) {
            try
            {
                string cryptoSenhaAtual = CoolEventsEncrypter.Encrypt(senhaAtual); 
                string cryptoSenhaNova = CoolEventsEncrypter.Encrypt(SenhaNova); 

                BDConexao conexao = new BDConexao();
                conexao.connection.Open();
                conexao.command.CommandText = "SELECT COUNT(*) FROM TBL_USUARIO WHERE SENHA = @_SENHA AND ID_USUARIO = @IDUSUARIO";
                conexao.command.Parameters.Add("@_SENHA", SqlDbType.VarChar).Value = cryptoSenhaAtual;
                conexao.command.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = idUsuario;

                if((int)conexao.command.ExecuteScalar() == 0)
                {
                    return 0;
                }

                conexao.command.Parameters.Clear();

                conexao.command.CommandText = "UPDATE TBL_USUARIO SET SENHA = @_NOVASENHA WHERE ID_USUARIO = @IDUSUARIO";
                conexao.command.Parameters.Add("@_NOVASENHA", SqlDbType.VarChar).Value = cryptoSenhaNova;
                conexao.command.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = idUsuario;

                conexao.command.ExecuteNonQuery();

                conexao.connection.Close();
                return 1;
            }
            catch (Exception)
            {
                return 2;
            }
        }

        public static bool SaveUserImageById(int idUsuario, string fileName) {
            try
            {
                BDConexao conexao = new BDConexao();
                conexao.command.CommandText = "UPDATE TBL_USUARIO SET foto = @FILENAME WHERE ID_USUARIO = @IDUSUARIO";
                conexao.command.Parameters.Add("@FILENAME", SqlDbType.VarChar).Value = fileName;
                conexao.command.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = idUsuario;

                conexao.connection.Open();
                conexao.command.ExecuteNonQuery();
                conexao.connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
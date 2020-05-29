﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

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
        public char Sexo { get; set; }
        public string Foto { get; set; }
        public string Apelido { get; set; }
        public string Civil { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Descricao { get; set; }
        public int Pontuacao { get; set; }
    
        //public bool Check() {
            
        //}

        public bool Cadastrar() {
            try {
                BDConexao conexao = new BDConexao();

                conexao.command.CommandText = "INSERT INTO tbl_USUARIO values (@NOME, @SOBRENOME, @EMAIL, @SENHA, @NASC, @SEXO, @FOTO, @APELIDO, @CIVIL, @UF, " +
                    "@CIDADE, @CEP, @BAIRRO, @LOGRADOURO, @NUMERO, @COMPLEMENTO, @DESCRICAO, @PONTUACAO)";

                conexao.command.Parameters.Add("@NOME", SqlDbType.NVarChar).Value = Nome;
                conexao.command.Parameters.Add("@SOBRENOME", SqlDbType.NVarChar).Value = Sobrenome;
                conexao.command.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = Email;
                conexao.command.Parameters.Add("@SENHA", SqlDbType.NVarChar).Value = Senha;
                conexao.command.Parameters.Add("@NASC", SqlDbType.Date).Value = DataNascimento;
                conexao.command.Parameters.Add("@SEXO", SqlDbType.Char).Value = Sexo;
                conexao.command.Parameters.Add("@APELIDO", SqlDbType.NVarChar).Value = Apelido;
                conexao.command.Parameters.Add("@UF", SqlDbType.NVarChar).Value = UF;
                conexao.command.Parameters.Add("@CIDADE", SqlDbType.NVarChar).Value = Cidade;
                conexao.command.Parameters.Add("@CEP", SqlDbType.NVarChar).Value = CEP;
                conexao.command.Parameters.Add("@BAIRRO", SqlDbType.NVarChar).Value = Bairro;
                conexao.command.Parameters.Add("@LOGRADOURO", SqlDbType.NVarChar).Value = Logradouro;
                conexao.command.Parameters.Add("@NUMERO", SqlDbType.Int).Value = Numero;
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class LoginsController : ApiController
    {

        public string Get(string user, string pass)
        {
            if (!(string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass)))
            {
                Models.Login l = new Models.Login("", 0);
                Conexao c = new Conexao();
                c.OpenConnection();
                var criptoPass = Cripto.sha256encrypt(pass);
                try
                {
                    c.Cmd = new SqlCommand("Select ID FROM Login Where Usuario = @v1", c.Con);
                    c.Cmd.Parameters.AddWithValue("@v1", user);
                    c.Dr = c.Cmd.ExecuteReader();

                    if (c.Dr.Read())
                    {
                        l.ID = Convert.ToInt32(c.Dr["ID"]);
                        c.Cmd = new SqlCommand("Select Nome_Usuario FROM Login Where Senha = @v1 and ID = @V2", c.Con);
                        c.Cmd.Parameters.AddWithValue("@v1", criptoPass);
                        c.Cmd.Parameters.AddWithValue("@v2", l.ID);
                        c.Dr = c.Cmd.ExecuteReader();
                        if (c.Dr.Read())
                        {
                            l.Nome = Convert.ToString(c.Dr["Nome_Usuario"]);
                            return "Login efetuado com sucesso! Bem vindo " + l.Nome;
                        }
                        else
                            return "Login incorreto!";
                    }
                    else
                    {
                        return "Login incorreto!";
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Login incorreto!" + e.Message);
                }
                finally
                {
                    c.CloseConnection();
                }
            }
            else
            {
                return "Preencha todos os dados";
            }
        }

        public string Post(string user, string pass, string nome)
        {
            if (!(string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(nome)))
            {
                Conexao c = new Conexao();
                c.OpenConnection();
                var criptoPass = Cripto.sha256encrypt(pass);
                try
                {
                    c.Cmd = new SqlCommand("Select ID FROM Login Where Usuario = @v1", c.Con);
                    c.Cmd.Parameters.AddWithValue("@v1", user);
                    c.Dr = c.Cmd.ExecuteReader();
                    if (c.Dr.Read())
                    {
                        return "Usuário já existe";
                    }
                    else
                    {
                        c.Cmd = new SqlCommand("INSERT INTO LOGIN (USUARIO, SENHA, NOME_USUARIO) VALUES (@V1, @V2, @V3)", c.Con);
                        c.Cmd.Parameters.AddWithValue("@v1", user);
                        c.Cmd.Parameters.AddWithValue("@v2", criptoPass);
                        c.Cmd.Parameters.AddWithValue("@v3", nome);
                        c.Dr = c.Cmd.ExecuteReader();
                        return "Usuário cadastrado com sucesso";
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    c.CloseConnection();
                }
            }
            else
            {
                return "Preencha todos os dados";
            }
        }

        public string Delete(string user, string pass)
        {
            if (!(string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass)))
            {
                Models.Login l = new Models.Login("", 0);
                Conexao c = new Conexao();
                c.OpenConnection();
                var criptoPass = Cripto.sha256encrypt(pass);
                try
                {
                    c.Cmd = new SqlCommand("Select ID, NOME_USUARIO FROM Login Where Usuario = @v1", c.Con);
                    c.Cmd.Parameters.AddWithValue("@v1", user);
                    c.Dr = c.Cmd.ExecuteReader();
                    if (c.Dr.Read())
                    {
                        l.ID = Convert.ToInt32(c.Dr["ID"]);
                        l.Nome = Convert.ToString(c.Dr["Nome_Usuario"]);

                        c.Cmd = new SqlCommand("Select ID FROM Login Where ID = @v1 and Senha = @v2", c.Con);
                        c.Cmd.Parameters.AddWithValue("@v1", l.ID);
                        c.Cmd.Parameters.AddWithValue("@v2", criptoPass);
                        c.Dr = c.Cmd.ExecuteReader();
                        if (c.Dr.Read())
                        {
                            c.Cmd = new SqlCommand("DELETE FROM Login Where ID = @v1", c.Con);
                            c.Cmd.Parameters.AddWithValue("@v1", l.ID);
                            c.Dr = c.Cmd.ExecuteReader();
                            return "Usuário excluído";
                        }
                        else
                        {
                            return "Senha incorreta";
                        }
                    }
                    else
                    {
                        return "Usuário não encontrado";
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    c.CloseConnection();
                }
            }
            else
            {
                return "Preencha todos os dados";
            }
        }
    }
}

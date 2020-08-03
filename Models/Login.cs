using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Login
    {
        public string Usuario { get; set; }

        public string Password { get; set; }

        public string Nome { get; set; }


        public Login(string user, string pass, string nome )
        {
            this.Usuario = user;
            this.Password = pass;
            this.Nome = nome;
        }
    }
}
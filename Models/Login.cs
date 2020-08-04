using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Login
    {

        public string Nome { get; set; }

        public int ID { get; set; }

        public Login(string nome, int id)
        {
            this.Nome = nome;
            this.ID = id;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace WebApi.Controllers
{
    public class LoginsController : ApiController
    {
            public string Get()
            {
                return "Login efetuado!";
            }

            public void Post(string nome, string pass)
            {
                
            }

            public void Delete(string nome)
            {
                //clientes.RemoveAt(clientes.IndexOf(clientes.First(x => x.Nome.Equals(nome))));
            }
    }
}

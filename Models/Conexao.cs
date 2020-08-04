using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient; 
using System.Configuration; 

namespace WebApi.Models
{
    public class Conexao
    {
        public SqlConnection Con;
        public SqlCommand Cmd;
        public SqlDataReader Dr;
        public SqlTransaction Tr;    

        
        public void OpenConnection() 
        {
            Con = new SqlConnection("Server=tcp:dbploomes.database.windows.net,1433;Initial Catalog=PloomesAPI;Persist Security Info=False;User ID=adminPloomes;Password=Ploomes123;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            Con.Open(); 
        }

        public void CloseConnection() 
        {
            Con.Close(); 
        }
    }
}
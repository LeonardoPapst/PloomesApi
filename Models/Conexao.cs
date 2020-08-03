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
        protected SqlConnection Con;    
        protected SqlCommand Cmd;       
        protected SqlDataReader Dr;     
        protected SqlTransaction Tr;    

        
        protected void OpenConnection() 
        {
            Con = new SqlConnection("Server=tcp:dbploomes.database.windows.net,1433;Initial Catalog=PloomesAPI;Persist Security Info=False;User ID=adminPloomes;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            Con.Open(); 
        }

        protected void CloseConnection() 
        {
            Con.Close(); 
        }
    }
}
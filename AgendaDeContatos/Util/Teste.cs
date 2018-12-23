using System.Configuration;
using System.Data.SqlClient;

namespace AgendaDeContatos.Util
{
    public class Teste
    {
        public SqlConnection con { get; set; }
        public void Conectar()
        {
            con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["AgendaContatos"].ConnectionString);
            con.Open();
        }
        public void Desconectar()
        {
            con.Close();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyAspProject.Pages.clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> listClients = new List<ClientInfo>();
        public void OnGet()
        {
            try
            {
                string connectionstring = "Data Source =.\\SQLEXPRESS; Initial Catalog = Sportsoutlet; Integrated Security = True; Trust Server Certificate = True";              
                using (SqlConnection connection = new SqlConnection(connectionstring))
             {
                connection.Open();
                string sql = "SELECT * FROM clients";
                using (SqlCommand command = new SqlCommand(sql, connection)) 
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClientInfo clientInfo = new ClientInfo();
                            clientInfo.id = "" + reader.GetInt32(0);
                            clientInfo.name = reader.GetString(1);
                            clientInfo.email = reader.GetString(2);
                            clientInfo.phone = reader.GetString(3);
                            clientInfo.address = reader.GetString(4);
                            clientInfo.created_at = reader.GetString(5).ToString();
                            listClients = new List<ClientInfo>();



                        }


                    }
                }

            }
        }
            catch (Exception ex)

            {
                Console.WriteLine("Exception: " + ex.ToString());

            }

        }
    }
    public class ClientInfo
    {
        public string id;
        public string name;
        public string email;
        public string phone;
        public string address;
        public string created_at;

    }
}

using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace AgileWorksTauriS.Pages.AgileWorks
{
    public class IndexModel : PageModel
    {

        public List<SupportTickets> listTickets = new List<SupportTickets>();    
       
        
        public void OnGet()
        {
            try
            {       
                String connectionstring = "server=localhost;uid=root;pwd=;database=agileWorks";
             
                using (MySqlConnection connection = new MySqlConnection(connectionstring))
                {
                    connection.Open();
                    String query = "SELECT * FROM tickets where is_completed <> 1 ORDER BY deadLine desc;";            
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {                        
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            
                            overDueChecker _overDueChecker = new overDueChecker();


                            while (reader.Read())
                            {
                                SupportTickets supportTicket = new SupportTickets();
                                supportTicket.id = "" + reader.GetInt32(0);
                                supportTicket.comment = reader.GetString(1);
                                supportTicket.createDate = reader.GetDateTime(2).ToString();
                                supportTicket.deadLine = reader.GetDateTime(3).ToString();                                                     
                                
                                supportTicket.color = _overDueChecker.getTicketLineColor(supportTicket.deadLine);

                                listTickets.Add(supportTicket);
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Exception: " + err.ToString());                
            }
        }
    }

    public class SupportTickets
    {
        public String id;
        public String comment;
        public String createDate;
        public String deadLine;
        public String color;
    }
}

using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace AgileWorksTauriS.Pages.AgileWorks
{
    public class addTicketModel : PageModel
    {
        public SupportTickets supportTicket = new SupportTickets();
        public string errorMessage = "";
        public string successMessage = "";
        
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            supportTicket.comment = Request.Form["comment"];
            supportTicket.deadLine = Request.Form["deadLine"];

            if (supportTicket.comment == "" || supportTicket.deadLine == "") 
            {
                errorMessage = "Fill out all the fields";
                return;
            }

            try
            {
                String connectionstring = "server=localhost;uid=root;pwd=;database=agileWorks";
                using (MySqlConnection connection = new MySqlConnection(connectionstring))
                {
                    connection.Open();
                    String qi = "INSERT INTO tickets "        +
                                "(comment, deadLine) VALUES " +
                                "(@comment, @deadLine);"      ;

                    using (MySqlCommand command = new MySqlCommand(qi, connection))
                    {
                        command.Parameters.AddWithValue("@comment", supportTicket.comment);
                        command.Parameters.AddWithValue("@deadLine", supportTicket.deadLine);

                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception err)
            {
                errorMessage = err.Message;
                return;
            }
          
            supportTicket.comment = ""; supportTicket.deadLine = "";
            successMessage = "New Ticket Added";

            Response.Redirect("/AgileWorks/TableView");

        }
    }
}

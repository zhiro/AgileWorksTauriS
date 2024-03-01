using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace AgileWorksTauriS.Pages.AgileWorks
{
    public class addTicketModel : PageModel
    {
        public SupportTickets supportTicket { get; set; } = new SupportTickets();
        public string errorMessage = "";
        public string successMessage = "";
        
        public void OnGet()
        {
            supportTicket.createDate = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");            
        }

        public void OnPost() 
        {
            supportTicket.comment = Request.Form["comment"];
            supportTicket.deadLine = Request.Form["deadLine"];
            supportTicket.createDate = Request.Form["createDate"];
            

            if (supportTicket.comment == "") 
            {
                errorMessage = "Please add a ticket description ";
                OnGet();
                return;
            }

            if (supportTicket.deadLine == "")
            {                
                errorMessage = "DeadLine can't be empty";
                OnGet();
                return;
            }            

            try
            {
                String connectionstring = "server=localhost;uid=root;pwd=;database=agileWorks";
                using (MySqlConnection connection = new MySqlConnection(connectionstring))
                {
                    connection.Open();
                    String qi = "INSERT INTO tickets " +
                                "(comment, createDate, deadLine) VALUES " +
                                "(@comment, @createDate, @deadLine);";

                    using (MySqlCommand command = new MySqlCommand(qi, connection))
                    {
                        command.Parameters.AddWithValue("@comment", supportTicket.comment);
                        command.Parameters.AddWithValue("@createDate", supportTicket.createDate);
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

            supportTicket.comment = "";
            supportTicket.deadLine = "";
            successMessage = "New Ticket Added";                        

            OnGet();
        }
    }
}

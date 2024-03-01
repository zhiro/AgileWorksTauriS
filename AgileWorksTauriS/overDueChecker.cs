namespace AgileWorksTauriS
{
    public class overDueChecker
    {

        public String getTicketLineColor(String dueDate)
        {
            String color = "black";

            DateTime deadLine = DateTime.Parse(dueDate);            

            bool overDue = isTicketOverDue(DateTime.Now.ToLocalTime(), deadLine) ;            

            if (overDue) { color = "red"; }

            return color;

        }


        public bool isTicketOverDue(DateTime curTime, DateTime dueDate)
        {
            bool overDue = false;
            TimeSpan cutOff = new TimeSpan(1, 0, 0);
            TimeSpan diff = dueDate.Subtract(curTime);

            if (cutOff > diff)
            {
                overDue = true;
            }

            return overDue;
        }
    }
}

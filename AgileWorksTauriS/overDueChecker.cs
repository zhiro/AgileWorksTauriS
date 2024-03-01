namespace AgileWorksTauriS
{
    public class overDueChecker
    {

        public String getTicketLineColor(String dueDate)
        {
            String color = "black";

            DateTime deadLine = DateTime.Parse(dueDate);
            //DateTime time_now = DateTime.Now.ToLocalTime();

            TimeSpan diff = findTimeDiff(DateTime.Now.ToLocalTime(), deadLine) ;
            
            TimeSpan overDue = new TimeSpan(1, 0, 0);

            if (overDue > diff)
            {
                color = "red";
                //color = "blue";
            }

            return color;

        }


        public TimeSpan findTimeDiff(DateTime curTime, DateTime dueDate)
        {
            TimeSpan diff = dueDate.Subtract(curTime);
            return diff;
        }


    }
}

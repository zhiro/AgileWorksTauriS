namespace AgileWorksTauriS
{

    public class systemTimeProvider
    {
        public virtual DateTime UtcNow()
        {
            return DateTime.UtcNow;
        } 
    }

    public class overDueCheckerSettings
    {
        public virtual int PassedCurrentDeadlineInHours()
        {
            return -1;
        }
    }
    
    public class overDueChecker
    {
        private readonly systemTimeProvider _provider;
        private readonly overDueCheckerSettings _timeSkip;
        
        public overDueChecker(systemTimeProvider provider, overDueCheckerSettings timeSkip)
        {
            _provider = provider;
            _timeSkip = timeSkip;
        }

        
        public String getTicketLineColor(DateTime deadLineUtc)
        {
            bool overDue = _provider.UtcNow().AddHours(_timeSkip.PassedCurrentDeadlineInHours()) <= deadLineUtc ;
            return overDue ? "red" : "black";
        }
    }
}

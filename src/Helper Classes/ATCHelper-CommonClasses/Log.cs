namespace ATCHelper_CommonClasses
{
    public class Log
    {
        private string _Application;
        public string Application { get { return _Application; } set { _Application = value; } }

        private string _Exception;
        public string Exception { get { return _Exception; } set { _Exception = value; } }

        private string _StackTrace;
        public string StackTrace { get { return _StackTrace; } set { _StackTrace = value; } }

        private string _Action;
        public string Action { get { return _Action; } set { _Action = value; } }

        //private ATC_Helper.Classes.flightplan _FlightPlan;
        //public ATC_Helper.Classes.flightplan FlightPlan { get { return _FlightPlan; } set { _FlightPlan = value; } }

        private ATCHelper_CommonClasses.Fields _Fields;
        public ATCHelper_CommonClasses.Fields Fields { get { return _Fields; } set { _Fields = value; } }


    }
}

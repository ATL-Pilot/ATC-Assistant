using System.Collections.Generic;

namespace ATC_Helper.Classes
{
    public class Route
    {
        private List<Waypoint> _waypoints;
        public List<Waypoint> Waypoints
        {
            get
            {
                if (_waypoints == null)
                    _waypoints = new List<Waypoint>();

                return _waypoints;
            }
            set
            {
                if (_waypoints == null)
                    _waypoints = new List<Waypoint>();
                _waypoints = value;
            }
        }
    }
}

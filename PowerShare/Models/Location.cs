using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerShare.Models
{
    public class Location
    {
        protected int _userId;
        protected double _longitude;
        protected double _latitude; 
        public Location()
        {

        }
        public Location(int UserID, double longitude, double latitude)
        {
            UserId = UserID;
            Longitude = longitude;
            Latitude = latitude;
        }
        public int UserId {
            get { return _userId; }
            set { _userId = value; }
        }
        public double Longitude {
            get { return _longitude; }
            set { _longitude= value; }
        }

        public double Latitude {
            get { return _latitude; }
            set { _latitude = value; }
        }
    }
}

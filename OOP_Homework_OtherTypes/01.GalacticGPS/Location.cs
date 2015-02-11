﻿using System;


namespace _01.GalacticGPS
{
    public struct Location
    {
        private double latitude;
        private double longitude;
        private Planet planet;

        public Location(double latitude, double longitude, Planet planet)
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public double Latitude 
        {
            get { return this.latitude; }
            set { this.latitude = value; }
        }
        public double Longitude
        {
            get { return this.longitude; }
            set { this.longitude = value; }
        }
        public Planet Planet 
        {
            get { return this.planet; }
            set { this.planet = value; }
        }

        public override string ToString()
        {
            string output = "";
            output += String.Format("{0}, {1} - {2}", this.Latitude, this.Longitude, this.Planet);
            return output;
        }
    }
}

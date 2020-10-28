using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSix_Repository
{
    public enum VehicleType { Gas, Hybrid, Electric}
    public class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public double Mileage { get; set; }
        public VehicleType VehicleType { get; set; }
        public bool isGreen
        {
            get
            {
                switch (VehicleType)
                {
                    case VehicleType.Hybrid:
                    case VehicleType.Electric:
                        return true;
                    default:
                        return false;
                }
            }

        }
        public Vehicle() { }
        public Vehicle( string make, string model, string year, double mileage, VehicleType vehicleType)
        {
            Make = make;
            Model = model;
            Year = year;
            Mileage = mileage;
            VehicleType = vehicleType;
        }

    }
}

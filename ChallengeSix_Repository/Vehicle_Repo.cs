using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSix_Repository
{
    class Vehicle_Repo
    {
        private List<Vehicle> _vehicleDirectory = new List<Vehicle>();
        //crud methods

        //CREATE
        public bool AddVehicle(Vehicle vehicle)
        {
            int startingCount = _vehicleDirectory.Count;
            _vehicleDirectory.Add(vehicle);
            bool wasAdded = (_vehicleDirectory.Count > startingCount) ? true : false;
            return wasAdded;

        }

        //READ
        public List<Vehicle> GetVehicles()
        {
            return _vehicleDirectory;
        }

        public Vehicle GetVehicleByMake(string make)
        {
            foreach (Vehicle vehicle in _vehicleDirectory)
            {
                if (vehicle.Make.ToLower() == make.ToLower())
                {
                    return vehicle;
                }

            }
            return null;
        }
        //UPDATE

        public bool UpdateVehicle(string make, Vehicle updatedVehicle)
        {
            Vehicle oldVehicle = GetVehicleByMake(make);
            if (oldVehicle != null)
            {
                oldVehicle.Make = updatedVehicle.Make;
                oldVehicle.Model = updatedVehicle.Model;
                oldVehicle.Year = updatedVehicle.Year;
                oldVehicle.Mileage = updatedVehicle.Mileage;
                oldVehicle.VehicleType = updatedVehicle.VehicleType;
                return true;
            }
            else
            {
                return false;
            }
        }

        //DELETE

        public bool DeleteVehicle(Vehicle existingVehicle)
        {
            bool deleteResult = _vehicleDirectory.Remove(existingVehicle);
            return deleteResult;
        }
    }
}

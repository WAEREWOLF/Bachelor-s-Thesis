using System;

namespace LogicModel
{
    public enum FuelType { diesel, GPL, petrol, electric, hybrid }

    public class Specification : BaseIdentifier
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Mileage { get; set; }
        public FuelType GetFuelType { get; set; }
        public string Power { get; set; }
        public string BodyType { get; set; }
        public int NrOfDoors { get; set; }
        public string GearBox { get; set; }
        public string EngineSize { get; set; }
        public string Emissions { get; set; }
        public string Color { get; set; }
        public bool IsNegotiable { get; set; }
        public bool IsFullOptions { get; set; }
        public bool HasABS { get; set; }
        public bool HasESP { get; set; }
        public bool HasWarranty { get; set; }
        public bool HasLogHistory { get; set; }
        public bool HasCruiseControl { get; set; }
        public bool HasDualZoneClimate { get; set; }
        public bool HasFullElectricWin { get; set; }
        public bool HasHeatedSeats { get; set; }
        public bool HasVentedSeats { get; set; }
        public bool HasElectricMirrors { get; set; }
        public bool HasHeatedStWheel { get; set; }
        public bool HadAccident { get; set; }

        public override bool Equals(Object obj)
        {
            if (!obj.GetType().Equals(typeof(Specification)))
            {
                return false;
            }
            Specification currentObj = obj as Specification;

            bool retValue = false;
            if (currentObj != null)
            {
                retValue = Make == currentObj.Make &&
                           Model == currentObj.Model &&
                           Year == currentObj.Year &&
                           Mileage == currentObj.Mileage &&
                           GetFuelType == currentObj.GetFuelType &&
                           Power == currentObj.Power &&
                           BodyType == currentObj.BodyType &&
                           NrOfDoors == currentObj.NrOfDoors &&
                           GearBox == currentObj.GearBox &&
                           EngineSize == currentObj.EngineSize &&
                           Color == currentObj.Color &&
                           IsNegotiable == currentObj.IsNegotiable &&
                           IsFullOptions == currentObj.IsFullOptions &&
                           HasABS == currentObj.HasABS &&
                           HasESP == currentObj.HasESP &&
                           HasWarranty == currentObj.HasWarranty &&
                           HasLogHistory == currentObj.HasLogHistory &&
                           HasCruiseControl == currentObj.HasCruiseControl &&
                           HasDualZoneClimate == currentObj.HasDualZoneClimate &&
                           HasFullElectricWin == currentObj.HasFullElectricWin &&
                           HasHeatedSeats == currentObj.HasHeatedSeats &&
                           HasVentedSeats == currentObj.HasVentedSeats &&
                           HasElectricMirrors == currentObj.HasElectricMirrors &&
                           HasHeatedStWheel == currentObj.HasHeatedStWheel &&
                           HadAccident == currentObj.HadAccident;
            }

            return retValue;
        }
    }
}
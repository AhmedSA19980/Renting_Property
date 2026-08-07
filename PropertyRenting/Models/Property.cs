using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Property
    {
       public int PropertyID { get; set; }
        public int CountryID { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string? PlaceDescription { get; set; }

        public int ContainerID { get; set; }
        public byte NumberOfBedrooms { get; set; }
        public byte NumberOfBathrooms { get; set; }
        public byte PropertyTypeID { get; set; }


        public decimal Price { get; set; }
        public string Name { get; set; }



        /*public Property()
        {
            this.PropertyID = -1;
            this.CountryID = -1;
            this.City = "";
            this.Address = "";
            this.PlaceDescription = "";
            this.ContainerID = -1;
            this.NumberOfBedrooms =0;
            this.NumberOfBathrooms = 0;
            this.PropertyTypeID = 0;
            this.Price = 0;
            this.Name = "";

        }*/
       /* public Property(int propertyId , int countryID , string city  ,string address , string placeDes , 
            int containerId ,byte numberOfBedrooms , byte numberOfBathrooms , byte PropertyId)
        {
            this.PropertyID = propertyId;
            this.CountryID = countryID;
            this.City = city;
            this.Address = address;
            this.PlaceDescription = placeDes;
            this.ContainerID = containerId;
            this.NumberOfBedrooms = numberOfBedrooms;
            this.NumberOfBathrooms = numberOfBathrooms;
            this.PropertyTypeID = PropertyId;
            this.Price = Price;
            this.Name = Name;

        }*/

        public Models.Container Container { get; set; }
      
    }
}

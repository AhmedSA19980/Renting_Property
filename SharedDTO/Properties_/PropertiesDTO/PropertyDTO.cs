

namespace SharedDTOLayer.Properties_.PropertiesDTO
{


    public class PropertyDTO
    {
        public PropertyDTO(int PropertyID, int CountryID, string City, string Address,
          string? PlaceDescription, int ContainerID,
         byte NumberOfBedRooms, byte NumberOfBathRooms, byte PropertyTypeID, decimal Price, string Name)
        {
            this.PropertyID = PropertyID;
            this.CountryID = CountryID;
            this.City = City;
            this.Address = Address;
            this.PlaceDescription = PlaceDescription;
            this.ContainerID = ContainerID;
            this.NumberOfBedrooms = NumberOfBedRooms;
            this.NumberOfBathrooms = NumberOfBathRooms;
            this.PropertyTypeID = PropertyTypeID;
            this.Price = Price;
            this.Name = Name;



        }

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

    }

}
